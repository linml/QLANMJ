<?php 
require ('../include/init.inc.php');
$method = $endDate = $page_no = '' ;
extract($_REQUEST,EXTR_IF_EXISTS);
$page_no = $page_no < 1 ? 1 : $page_no;
if($method == 'loadData'&&!empty($page_no)){
	$DrawMoneyRecordList =  DrawMoneyRecord::getDrawMoneyRecord(($page_no-1)*PAGE_SIZE,PAGE_SIZE,$endDate);
	if(empty($endDate)) $date = date('Y年m月',time());else $date = date('Y年m月',strtotime($endDate));
	exit(json_encode(array('recordData'=>$DrawMoneyRecordList,'DateTime'=>$date)));
}



// START数据库查询及分页数据
// $page_size = PAGE_SIZE;
// $page_no = $page_no < 1 ? 1 : $page_no;
// $row_count = DrawMoneyRecord::getAllCountByAgentId($agentid,$startDate,$endDate);
// $total_page=$row_count%$page_size==0?$row_count/$page_size:ceil($row_count/$page_size);
// $total_page=$total_page<1 ? 1:$total_page;t
// $page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
// $start = ($page_no - 1) * $page_size;
// $data =  DrawMoneyRecord::getDrawMoneyRecordList($agentid,$start,$page_size,$startDate,$endDate);
// $page_html = Pagination::showPager ( "DrawMoneyRecord.php", $page_no, $page_size, $row_count );

Template::assign ('data', $data);
Template::assign ('page_html', $page_html);
Template::assign('startDate',$startDate);
Template::assign('endDate',$endDate);
Template::display ('agentcenter/toDrawMonyRecord.tpl');