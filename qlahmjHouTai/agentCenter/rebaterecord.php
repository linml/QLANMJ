<?php 
require ('../include/init.inc.php');
$method = $endDate = $page_no = '';
extract($_REQUEST,EXTR_IF_EXISTS);
$page_no = $page_no < 1 ? 1 : $page_no;

if($method == 'loadData'){
	$rebateRecordList = RebateRecord::getRebateRecordList(($page_no-1)*PAGE_SIZE,PAGE_SIZE,$endDate);

	$incomeExpend = RebateRecord::getIncomeAndExpend($endDate);

	if(empty($endDate)) $date = date('Y年m月',time());else $date = date('Y年m月',strtotime($endDate));
	exit(json_encode(array('recordData'=>$rebateRecordList,'DateTime'=>$date,'incomeExpend'=>$incomeExpend)));
}

Template::assign ('rebateRecordList', $rebateRecordList);
Template::assign ('date', $endDate);
Template::assign ('incomeExpend', $incomeExpend);
Template::display ('agentcenter/toRebateRecord.tpl');