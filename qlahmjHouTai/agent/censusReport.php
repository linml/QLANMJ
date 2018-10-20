<?php
require ('../include/init.inc.php');
$month = $method='';
set_time_limit(0);//0表示不限时
extract ( $_REQUEST, EXTR_IF_EXISTS );

if($method=='redealTimeRightNow'){
	CensusReport::redealWithCensusReportsWhenDataIsWrong(date('n'),'D',0);
	CensusReport::redealWithCensusReportsWhenDataIsWrong(date('n'),'M');
	exit('{"result":"OK"}');
}
$month_Report = CensusReport::getCensusReportsMonthHistoryByMonth($month,'DOK');

Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'diffrentTime', CASH_TIME);
Template::assign ( 'm_Report', $month_Report );
Template::display ( 'agent/censusReport.tpl' );