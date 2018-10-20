<?php
require ('../include/init.inc.php');
$agent = $clubId = $agentName= $gameId= $page_no='';
extract ( $_REQUEST, EXTR_IF_EXISTS );
if(!empty($clubId)){
	// START 数据库查询及分页数据
	$page_size = PAGE_SIZE;
	$page_no = $page_no < 1 ? 1 : $page_no;
	$row_count = ClubManage::getClubGameUserDataToPagingCount($clubId,$gameId);
	$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
	$total_page = $total_page < 1 ? 1 : $total_page;
	$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
	$start = ($page_no - 1) * $page_size;
	$clubGameUserArray = ClubManage::getClubGameUserDataToPaging($clubId,$gameId,$start,$page_size);
}
$page_html = Pagination::showPager ( "clubGameUser.php?gameId=$gameId&clubId=$clubId", $page_no, $page_size, $row_count );

Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );
Template::assign ( 'clubGameUserArray', $clubGameUserArray );
Template::display ( 'agent/clubGameUser.tpl' );