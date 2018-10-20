<?php
require ('../include/init.inc.php');
$method = $type = $page_no = $agent_uid = $startDate = $endDate =$id = $agentid = $where = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );

//处理 否定的提现订单
if($method == 'dealFalseDrawMoney'&&!empty($id)){
	//判断订单存在
	// $orderCount = WxPay::checkWxCasOrderIsExist($id);
	//调用订单存储过程
	$uWeCashOrderData = array(
			'order_no' =>$id,
			'agentid'=>UserSession::getAgentId(),
			'status'=> 2,
			'transaction_id'=> $id
		);
	$uWeCashResult = WxPay::updateWeCashOrder($uWeCashOrderData);
	//返回处理结果
	exit($uWeCashResult);
}
$where = DrawReview::getWhere($startDate,$endDate);
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;
$row_count = DrawReview::getAllCount ($where);
$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;

if($page_size) $limit = " limit $start,$page_size";else $limit = '';


$page_html = Pagination::showPager ("drawreview.php?startDate=$startDate&endDate=$endDate",$page_no, $page_size, $row_count);
$drawInfoList = DrawReview::getDrawMoneyRecord($limit,$where);
$getMoneyPendingAndProcessed = DrawReview::getMoneyPendingAndProcessed();
Template::assign ( 'drawInfoList', $drawInfoList );
Template::assign ( 'page_html', $page_html );
Template::assign ( 'pendAndProc', $getMoneyPendingAndProcessed );
Template::assign ( '_REQUEST', $_REQUEST );
Template::display ( 'agent/drawreview.tpl' );