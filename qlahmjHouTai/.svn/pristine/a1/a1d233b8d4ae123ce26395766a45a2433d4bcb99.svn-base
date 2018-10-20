
<?php
require ('../include/init.inc.php');
$method =$agentid = $t1agent = $agentName = $agent_type= $page_no = $gems =$money = $m_type=$notebook= '';

extract ( $_REQUEST, EXTR_IF_EXISTS );
if($_POST['method']){
	$method = $_POST['method'];
}
if($_POST['agentid']){
	$agentid = $_POST['agentid'];
}
if($_POST['agentName']){
	$agentName = $_POST['agentName'];
}
if($_POST['gems']){
	$gems = $_POST['gems'];
}

if ($method == 'getAgentByAgentId' && ! empty ( $agentid )) {

	$agentChildrenData = AgentReports::getAgentByAgentId($agentid);
	exit(json_encode($agentChildrenData));
} 

if($method == 'addGems' && !empty($agentid) && !empty($gems)&&!empty($agentName) &&!empty($m_type)){
	if($m_type==1&&empty($money))exit('{"result":"false"}');
	AgentReports::updateAgentGemByAgentId($agentid,$gems);
	$username = UserSession::getUserName();
	$recordData  = array('eid' => 0,'dl_uid'=> $agentid ,'traded_info'=>$notebook,'traded_num'=>$gems,'traded_money'=>$money ,'nickname'=>$agentName,'type'=>$m_type,'adminName'=>$username );
	AgentReports::insertAgentReportsRecord($recordData);
	exit();
}

// START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;
$row_count = AgentReports::getAllAgentReportsCount ($agentid,$t1agent,$agent_type);
$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;
$agents = AgentReports::getAllAgentReports ( $agentid,$t1agent,$agent_type ,$start, $page_size );
$userGoupId = UserSession::getUserGroup() <= GROUP_CONFIGURE ? true : false ; 
$page_html = Pagination::showPager ( "agentReports.php?agentid=$agentid&t1agent=$t1agent&agent_type=$agent_type", $page_no, $page_size, $row_count );

Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'agents', $agents );
Template::assign ( 'group_judge', $userGoupId );
Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );

Template::display ( 'agent/agentReports.tpl' );