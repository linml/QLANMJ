<?php
require ('../include/init.inc.php');
$startdate = $enddate =$method = $agentid = $page_no = $dirAgent = $where = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );
$where = MyEarning::getWhere($agentid,$dirAgent,$startdate,$enddate);
//START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no=$page_no<1?1:$page_no;
$row_count = MyEarning::getRebatListCount ($where);
$total_page=$row_count%$page_size==0?$row_count/$page_size:ceil($row_count/$page_size);
$total_page=$total_page<1?1:$total_page;
$page_no=$page_no>($total_page)?($total_page):$page_no;
$start = ($page_no - 1) * $page_size;
if($page_size) $limit = " limit $start,$page_size";
$RebateList = MyEarning::getRebateList($limit,$where);
$page_html=Pagination::showPager("myearnings.php?where=$where&dirAgent=$dirAgent&agentid=$agentid&startdate=$startdate&enddate=$enddate",$page_no,$page_size,$row_count);
Template::assign( 'page_no', $page_no );
Template::assign( 'where', $where );
Template::assign( 'RebateList', $RebateList );
Template::assign( '_REQUEST', $_REQUEST );
Template::assign( 'page_html', $page_html );
Template::display ( 'agent/myearnings.tpl' );

