<?php
require ('../include/init.inc.php');
$method = $agent_uid = $page_no = $search = $st = $et = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );

// START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;

if ($search && $st && $et) {
	$row_count = StatRemain::getSumCountSearch ( $st, $et );
	
	$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
	$total_page = $total_page < 1 ? 1 : $total_page;
	$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
	$start = ($page_no - 1) * $page_size;
	
	$agents = StatRemain::getAllSumSearch ( $st, $et, $start, $page_size );
} else {
	$row_count = StatRemain::getSumCount ();
	$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
	$total_page = $total_page < 1 ? 1 : $total_page;
	$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
	$start = ($page_no - 1) * $page_size;
	$agents = StatRemain::getAllSum ( $start, $page_size );
}

$page_html = Pagination::showPager ( "statremain.php", $page_no, $page_size, $row_count );
Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'agents', $agents );

Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );

Template::display ( 'agent/statremain.tpl' );