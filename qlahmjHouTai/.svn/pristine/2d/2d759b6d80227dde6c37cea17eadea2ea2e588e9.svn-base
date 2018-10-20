
<?php
require ('../include/init.inc.php');
$method = $page_no = $agentid = $topAgent = $agent_type  = $startDate = $endDate = $m_type='';

extract ( $_REQUEST, EXTR_IF_EXISTS );

// START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;
$row_count = TransferRecord::getAllTransferRecordCount ($agentid,$topAgent,$agent_type,$m_type,$startDate,$endDate);
$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;
$agents = TransferRecord::getAllTransferRecord ( $agentid,$topAgent,$agent_type ,$m_type,$startDate,$endDate,$start, $page_size );

$page_html = Pagination::showPager ( "transferRecord.php?agentid=$agentid&agent_type=$agent_type&topAgent=$topAgent&m_type=$m_type&startDate=$startDate&endDate=$endDate", $page_no, $page_size, $row_count );

Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'agents', $agents );
Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );

Template::display ( 'agent/transferRecord.tpl' );