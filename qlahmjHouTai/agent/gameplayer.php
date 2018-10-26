<?php
require ('../include/init.inc.php');
$page_no = $method = $userid = $diamond = $money = $m_type = $agentid = $status = $s_type = $contains = $remark = $type = $limit =  $where = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );
if($method == 'getGameMessage'&&!empty($userid)){
	$GameMessage = GamePlayer::getUserById($userid);
	exit(json_encode($GameMessage));
}

if($method == 'SendDiamond'&&!empty($userid)&&!empty($type)){
	$diamond = $diamond + 0;
	$money = $money + 0;
	$result = GamePlayer::SendDiamond($userid,$diamond,$money,$type,$remark);
	if($result == 1){
		$userId   = intval($userid);
		$diamondAccount = GamePlayer::getUserAccountById($userid);
		$moneyBag = "2|".intval($diamondAccount);
		$time = time();
		$url = "http://api.test.qileah.cn/web/Manage.PushUserMoneyMag";
		$ql_appid = "ql_8k6p1061ir04";
		$secret = "iggplpi029ashcan39421oa86n16wn9d";
		$api_version = "1";
		$stringA = "api_version=$api_version&moneyBag=$moneyBag&ql_appid=ql_8k6p1061ir04&timestamp=$time&userId=$userId";
		$stringSignTemp = "api.test.qileah.cn/web/Manage.PushUserMoneyMag"."?".$stringA."&".$secret;
		$sign = strtoupper(sha1($stringSignTemp));
		$post_data = array(
			"userId"=>$userId,
			"moneyBag"=>$moneyBag,
			"ql_appid"=>$ql_appid,
			"api_version"=>1,
			"sign"=>$sign,
			"timestamp"=>$time
		);
		$exit = Base::curl_post($url,$post_data);
		exit($exit);
	}
}
if($method == 'changeParentAgent'&&!empty($agentid)&&!empty($userid)){
	$result = GamePlayer::changeParentAgent($userid,$agentid);
	exit(json_encode($result));
}
if($method == 'showInfo'&&!empty($userid)){
	$Info = GamePlayer::showInfo($userid);
	exit(json_encode($Info));
}
if($method == 'updateUserStatus'&&!empty($userid)&&!empty($status)){
	$result = GamePlayer::updateUserStatus($userid,$status);
	if($result == 0){
		$result = '未做更新,请联系管理员';
	}else if($result == 1){
		$result = '更新成功';
	}
	exit(json_encode($result));
}

$where = GamePlayer::getWhere($s_type,$contains);

$page_size = PAGE_SIZE;

$row_count = GamePlayer::getCountUsers($where);
$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no < 1 ? 1 : $page_no;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;
$gameplayerList = GamePlayer::getAllUsers($start,$page_size,$where);
$page_html = Pagination::showPager ("gameplayer.php?s_type=$s_type&contains=$contains",$page_no,$page_size,$row_count,$limit);
Template::assign ( 'List',$gameplayerList );
Template::assign ( '_REQUEST',json_encode($_REQUEST) );
Template::assign ( 'page_html',$page_html );
Template::display ( 'agent/gameplayer.tpl' );