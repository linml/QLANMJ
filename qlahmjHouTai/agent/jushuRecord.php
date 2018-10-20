<?php
require ('../include/init.inc.php');
$method = $page_no = $type = $flag = $flag = $index = $time = $monthtime = $yeartime = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );
if(empty($monthtime)){
	$monthtime = date("Y-m",strtotime(date('Y-m')));
}
if(empty($yeartime)){
	$yeartime = date("Y");
}

//START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no=$page_no<1?1:$page_no;
$row_count = JSRecord::getJSGameRecordCount($method,$time,$type);
$total_page=$row_count%$page_size==0?$row_count/$page_size:ceil($row_count/$page_size);
$total_page=$total_page<1?1:$total_page;
$page_no=$page_no>($total_page)?($total_page):$page_no;
$start = ($page_no - 1) * $page_size;
$page_html=Pagination::showPager("jushuRecord.php?method=$method&time=$time&type=$type&flag=1&monthtime=$monthtime&yeartime=$yeartime",$page_no,$page_size,$row_count);
if($flag == 2){
	switch($method){
		case 'day':
			$dayRecord = JSRecord::getDayJSRecord($time,$type,$start,$page_size);	
			exit(json_encode($dayRecord));
			break;
		case 'month':
			$monthRecord = JSRecord::getMonthJSRecord($time,$type,$start,$page_size);
			exit(json_encode($monthRecord));
			break;
		default:
			break;
	}
}

$page_html=Pagination::showPager("jushuRecord.php?method=$method&time=$time&type=$type&flag=1&monthtime=$monthtime&yeartime=$yeartime",$page_no,$page_size,$row_count);
Template::assign ( '_REQUEST', $_REQUEST);
Template::assign ( 'time', json_encode($time));
Template::assign ( 'yeartime', json_encode($yeartime));
Template::assign ( 'monthtime', json_encode($monthtime));
Template::assign ( 'index', json_encode($index));
Template::assign ( 'page_no', json_encode($page_no) );
Template::assign ( 'method', json_encode($method));
Template::assign ( '_REQUEST', json_encode($_REQUEST) );
Template::assign ( 'page_html', $page_html );
Template::display ( 'agent/jushuRecord.tpl' );