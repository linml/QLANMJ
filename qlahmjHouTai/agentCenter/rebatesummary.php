<?php
require ('../include/init.inc.php');
$page_no = $type = '';

extract($_REQUEST,EXTR_IF_EXISTS);
if(empty($type)) $type=1;
$agentid = UserSession::getAgentId();
$page_no = $page_no < 1 ? 1 : $page_no;
$page_size = PAGE_SIZE;
$row_count = RebateSummary::getRebateCountsByAgentId($agentid,$type);

if($row_count > 30) $row_count=PAGE_SIZE*2;else $row_count;

$total_page=$row_count%$page_size==0?$row_count/$page_size:ceil($row_count/$page_size);
$total_page=$total_page<1?1:$total_page;


$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;

$result = RebateSummary::getRebate($agentid,$type,$start,$page_size);
$page_html = Pagination::showPager ( "RebateSummary.php?type=$type", $page_no, $page_size, $row_count );

Template::assign('result',$result);
Template::assign('_REQUEST',$_REQUEST);
Template::assign ( 'page_html', $page_html );
Template::assign ( 'type', $type );
Template::display ('agentcenter/toRebateSummary.tpl');