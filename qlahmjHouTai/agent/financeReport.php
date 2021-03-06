<?php
require ('../include/init.inc.php');
$method = $month = $year = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );

if(empty($month)){
	$_REQUEST['month'] = date("Y-m",strtotime(date('Y-m')));
}
if(empty($year)){
	$_REQUEST['year'] = date("Y");
}

$dayWhere = FinanceReport::getDayWhere($month);
$monthWhere = FinanceReport::getMonthWhere($year);

$dayData = FinanceReport::getDayData($dayWhere);
$monthData = FinanceReport::getMonthData($monthWhere);

if($method == 'yearsearch'){
	$monthData = FinanceReport::getMonthData($monthWhere);
	exit(json_encode($monthData));
}

Template::assign ( '_REQUEST', json_encode($_REQUEST) );
Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'method', $method );
Template::assign ( 'dayData', $dayData );
Template::assign ( 'monthData', $monthData );
Template::display ( 'agent/financeReport.tpl' );