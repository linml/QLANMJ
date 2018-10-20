<?php
require ('../include/init.inc.php');
$user_group = $method = $user_name = $user_id = $page_no = $search = $gameType = $typeName = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );
/*if($gameType ==''){
	$gameType ='majiang';
}*/
//通过游戏服务器，获取准确的在线人数
$ch = curl_init ();
// $url = GAME_SERVER_HOST.'/getOnlineUser?sign='.md5(GAME_SERVER_TOKEN).'&type='.$gameType;
$url = GAME_SERVER_HOST.'/getOnlineUser?sign='.md5(GAME_SERVER_TOKEN);
STools::log('\n');
STools::log($url);
curl_setopt ( $ch, CURLOPT_URL, $url );
curl_setopt ( $ch, CURLOPT_TIMEOUT, 5 );
curl_setopt ( $ch, CURLOPT_RETURNTRANSFER, 1 );
curl_setopt ( $ch, CURLOPT_CUSTOMREQUEST, 'GET' );
$res = curl_exec ( $ch );
$onlineplayers = null;
if($res){
	$onlineplayers = json_decode($res,TRUE);
	if($onlineplayers){
		$onlineplayers = $onlineplayers['data'];
	}
}
if(!$onlineplayers){
	$onlineplayers = array();
}
/*if($gameType=='majiang'){
	$gameType ='zhipai';
	$typeName = '点击查看纸牌';
}else if($gameType=='zhipai'){
	$gameType ='majiang';
	$typeName = '点击查看麻将';
}*/
// var_dump($onlineplayers);
// START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;

$row_count = !$onlineplayers ? 0 : count($onlineplayers);

$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;

$ids = array_slice($onlineplayers,($page_no -1) * $page_size,$page_size);

$agents = GamePlayer::getPlayerByIds($ids);

$page_html = Pagination::showPager ( "onlineplayer.php", $page_no, $page_size, $row_count );

Template::assign ( 'count', $row_count );
Template::assign ( 'agents', $agents );
Template::assign ( 'page_no', $page_no );
// Template::assign ( 'typeName', $typeName );
// Template::assign ( 'gameType', $gameType );
Template::assign ( 'page_html', $page_html );
Template::display ( 'agent/onlineplayer.tpl' );