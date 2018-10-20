<?php
require ('../include/init.inc.php');
$method = $agent_uid = $page_no = $search = $st = $et = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );

// START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;

if ($search && $st && $et) {
	$row_count = TopuSummary::getSumCountSearch ( $st, $et );
	
	$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
	$total_page = $total_page < 1 ? 1 : $total_page;
	$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
	$start = ($page_no - 1) * $page_size;
	
	$agents = TopuSummary::getAllSumSearch ( $st, $et, $start, $page_size );
} else {
	$row_count = TopuSummary::getSumCount ();
	$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
	$total_page = $total_page < 1 ? 1 : $total_page;
	$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
	$start = ($page_no - 1) * $page_size;
	$agents = TopuSummary::getAllSum ( $start, $page_size );
}
//计算统计数据
$summary_data = array(
	'totalpayment'=>0,
	'usercount'=>0,
	'ordercount'=>0,
	'arppu'=>0,
	'payperorder'=>0,
	'totalagentprofit'=>0,
	'agentproportion'=>0,
);
//获取概况数据，按时间，无分页
$res = TopuSummary::getPaymentSummaryInfo ( $st, $et);
if($res){
	$summary_data['totalpayment'] = $res['payment'];
	$summary_data['usercount'] = $res['usercount'];
	$summary_data['ordercount'] = $res['ordercount'];
}
if($summary_data['usercount'] != 0){
	$summary_data['arppu'] = round($summary_data['totalpayment']/$summary_data['usercount']);
}
if($summary_data['ordercount'] != 0){
	$summary_data['payperorder'] = round($summary_data['totalpayment']/$summary_data['ordercount']);
}
//获取代理的总收益
$p = Agent::getProfitByDate(null,$st,$et);
if($p){
	$summary_data['totalagentprofit'] = $p;
}
if($summary_data['totalpayment'] != 0){
	$summary_data['agentproportion'] = round($summary_data['totalagentprofit']*100.00/$summary_data['totalpayment'],2);
}
// var_dump($summary_data);
Template::assign ( 'summary_data', $summary_data  );

$page_html = Pagination::showPager ( "topusummary.php?st=$st&et=$et&search=$search", $page_no, $page_size, $row_count );
Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'agents', $agents );

Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );

Template::display ( 'agent/topusummary.tpl' );