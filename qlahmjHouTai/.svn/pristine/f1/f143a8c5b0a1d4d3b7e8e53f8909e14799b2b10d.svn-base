<?php
require ('../include/init.inc.php');
$month = $method='';
extract ( $_REQUEST, EXTR_IF_EXISTS );

if($method=='redealTimeRightNow'){
	FinanceReport::redealWithReportsWhenDataIsWrong(date('n'),'D',0);
	FinanceReport::redealWithReportsWhenDataIsWrong(date('n'),'M');
	exit('{"result":"OK"}');
}
$month_Report = FinanceReport::getMonthHistoryByMonth( $month,'DOK');

Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'diffrentTime', CASH_TIME);
Template::assign ( 'm_Report', $month_Report );
Template::display ( 'agent/financeReport.tpl' );