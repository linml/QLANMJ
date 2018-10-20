<?php
require ('../include/init.inc.php');
$startdate = $enddate = $page_no = $s_type = $contains = $s_status = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );
$where = TopupEarnings::getWhere($startdate,$enddate,$s_type,$contains,$s_status);
//START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;
$row_count = TopupEarnings::getOrderCount ($where);
$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;
$orderRecordList = TopupEarnings::getOrderRecordList($start,$page_size,$where);
$page_html=Pagination::showPager("topupearnings.php?startdate=$startdate&enddate=$enddate&s_type=$s_type&contains=$contains&s_status=$s_status",$page_no,$page_size,$row_count);
Template::assign ( '_REQUEST', json_encode($_REQUEST));
Template::assign ( 'orderRecordList', $orderRecordList );
Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );
Template::display ( 'agent/topupearnings.tpl' );