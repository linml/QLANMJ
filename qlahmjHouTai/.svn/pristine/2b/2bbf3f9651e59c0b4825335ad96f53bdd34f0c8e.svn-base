<?php
require ('../include/init.inc.php');
$startdate = $enddate = $page_no = $method = $ownerid = $tableid = $game = $setid = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );
$gameInfo = OpenRecord::getGameInfo();
$where = OpenRecord::getWhere($startdate,$enddate,$tableid,$game,$ownerid);
if($method == 'showDetail' && !empty($setid)){
	$result = OpenRecord::getRoomDetail($setid);
	exit(json_encode($result));
}
//START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no<1?1:$page_no;
$row_count = OpenRecord::getGameRoomCount($where);
$total_page = $row_count%$page_size==0?$row_count/$page_size:ceil($row_count/$page_size);
$total_page = $total_page<1?1:$total_page;
$page_no = $page_no>($total_page)?($total_page):$page_no;
$start = ($page_no - 1) * $page_size;
$gameRoomList = OpenRecord::getGameRoomList($start,$page_size,$where);  
$page_html=Pagination::showPager("openRecord.php?ownerid=$ownerid&tableid=$tableid&game=$game&startdate=$startdate&enddate=$enddate",$page_no,$page_size,$row_count);
if($method == 'download'){
	$filename = '开房记录'.time();
	$header = ['游戏','方式','房间号','付费方式','扣费','玩法','玩家','战绩','创建时间'];
	$index = ['gamename','groupid','tableid','RoomCostType','RoomCost','mark','nickname','moneynum','addtime'];
	$where = OpenRecord::getWhere($startdate,$enddate,$tableid,$game,$ownerid);
	$gameRoomList = OpenRecord::getGameRoomList($start,$page_size,$where); 
	foreach ($gameRoomList as $key => $value) {
		if($gameRoomList[$key]['groupid'] == null) $gameRoomList[$key]['groupid'] = '组局';else $gameRoomList[$key]['groupid'] = '俱乐部';
		if($gameRoomList[$key]['RoomCostType'] == '1'){
			$gameRoomList[$key]['RoomCostType'] = 'AA';
		}else if($gameRoomList[$key]['RoomCostType'] == '2'){
			$gameRoomList[$key]['RoomCostType'] = '房主';
		}else if($gameRoomList[$key]['RoomCostType'] == '3'){
			$gameRoomList[$key]['RoomCostType'] = '圈主';
		}else{
			$gameRoomList[$key]['RoomCostType'] = '暂无';
		}
	}
	Base::createtable($gameRoomList,$filename,$header,$index);
}
Template::assign ( '_REQUEST', json_encode($_REQUEST) );
// Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'gameInfo', $gameInfo );
Template::assign ( 'gameRoomList', $gameRoomList );
Template::assign ( 'page_html', $page_html );
Template::display ( 'agent/openRecord.tpl' );