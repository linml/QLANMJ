
<?php
require ('../include/init.inc.php');
$method =$agentid = $agentName = $agent_type= $page_no = $startDate = $endDate =  $topAgent = '';

extract ( $_REQUEST, EXTR_IF_EXISTS );
if(empty($startDate)){
	$startDate = date("Y-m-d",strtotime(date('Y-m').'-01'));
	$_REQUEST['startDate'] = $startDate;
}
if(empty($endDate)){
	$endDate = date("Y-m-d");
	$_REQUEST['endDate'] = $endDate;
}

// START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;
$row_count = AgentAnalysis::getAllAgentAnalysisCount ($agentid,$topAgent,$agent_type);
$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;
$agents = AgentAnalysis::getAllAgentAnalysis( $agentid,$topAgent,$agent_type ,$start, $page_size,$startDate,$endDate);
// exit(var_dump($agents));
$userGoupId = UserSession::getUserGroup() <= GROUP_CONFIGURE ? true : false ; 
$page_html = Pagination::showPager ( "agentAnalysis.php?agentid=$agentid&agent_type=$agent_type&startDate=$startDate&endDate=$endDate&topAgent=$topAgent", $page_no, $page_size, $row_count );

Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'agents', $agents );
Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );

Template::display ( 'agent/agentAnalysis.tpl' );