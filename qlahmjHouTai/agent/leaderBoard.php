<?php
$type = $contains = $gameid = $starttime = $endtime = $page_no = '';
require ('../include/init.inc.php');
extract ( $_REQUEST, EXTR_IF_EXISTS );
if(empty($starttime)){
	$starttime = date("Y-m-d");
	$_REQUEST['starttime'] = $starttime;
}

if(empty($endtime)){
	$endtime = date("Y-m-d");
	$_REQUEST['endtime'] = $endtime;
}

$where = LeaderBoard::getWhere($type,$contains,$starttime,$endtime);
$gameInfo = OpenRecord::getGameInfo();

// START 数据库查询及分页数据
$page_no = $page_no < 1 ? 1 : $page_no;
$page_size = PAGE_SIZE;
$row_count = LeaderBoard::getRowCount ($where);
$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;
if($page_size) $limit = " limit $start,$page_size";else $limit = '';
$page_html = Pagination::showPager ( "leaderBoard.php?type=$type&contains=$contains&gameid=$gameid&starttime=$starttime&endtime=$endtime", $page_no, $page_size, $row_count );

$board = LeaderBoard::getBoard($where,$gameid,$limit);
Template::assign ( 'gameInfo', $gameInfo );
Template::assign ( 'board', $board );
Template::assign ( 'page_html', $page_html );
Template::assign ( '_REQUEST1', $_REQUEST );
Template::assign ( '_REQUEST', json_encode($_REQUEST) );
Template::display ( 'agent/LeaderBoard.tpl' );
