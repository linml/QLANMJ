<?php
require ('../include/init.inc.php');
$fromuid = $touid = $startdate = $enddate = $page_no = $gameType = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );


//START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no=$page_no<1?1:$page_no;
$row_count = Gems::getSellGemsRecordCount($fromuid,$touid,$gameType,$startdate,$enddate);
$total_page=$row_count%$page_size==0?$row_count/$page_size:ceil($row_count/$page_size);
$total_page=$total_page<1?1:$total_page;
$page_no=$page_no>($total_page)?($total_page):$page_no;
$start = ($page_no - 1) * $page_size;

if(empty($fromuid) && empty($touid) && empty($startdate) && empty($enddate) && empty($gameType)){
	//存在
	if(file_exists(TEMPLATE_CACHE.'sellgemslist.json')&&json_decode(file_get_contents(TEMPLATE_CACHE.'sellgemslist.json'), true)[$page_no]){
		// 从文件中读取数据到PHP变量  
		$json_string = file_get_contents(TEMPLATE_CACHE.'sellgemslist.json');  
		$jsonData = json_decode($json_string,true);
		if(strtotime($jsonData['timePoint'])<strtotime(date('Y-m-d'))){
			$records = Gems::getSellGemsRecord($fromuid,$touid,$gameType,$startdate,$enddate,$start,$page_size);
			$jsonData['timePoint'] = date('Y-m-d');
			$jsonData= array($page_no =>$records ,'timePoint'=>date('Y-m-d'));
			$json_string = json_encode($jsonData);
			file_put_contents(TEMPLATE_CACHE.'sellgemslist.json', $json_string);  
		}
		// 把JSON字符串转成PHP数组  
		$records = $jsonData[$page_no];   
	}else{
		$records = Gems::getSellGemsRecord($fromuid,$touid,$gameType,$startdate,$enddate,$start,$page_size);
		// 把PHP数组转成JSON字符串  
		if(file_exists(TEMPLATE_CACHE.'sellgemslist.json')){
			$json_string = file_get_contents(TEMPLATE_CACHE.'sellgemslist.json');
			// $jsonData = json_decode($json_string,JSON_FORCE_OBJECT);
			$jsonData = json_decode($json_string,true);
			$jsonData[$page_no] = $records;
			$json_string = json_encode($jsonData);
		}else{
			// $json_string = json_encode(array($arrayData));
			$arrayData = array($page_no=>$records,'timePoint'=>date('Y-m-d'));
			$json_string = json_encode($arrayData);
		}
		// 写入文件  
		file_put_contents(TEMPLATE_CACHE.'sellgemslist.json', $json_string);  
	}
}else{
	$records = Gems::getSellGemsRecord($fromuid,$touid,$gameType,$startdate,$enddate,$start,$page_size);
}

$page_html=Pagination::showPager("sellgemslist.php?fromuid=$fromuid&touid=$touid&gameType=$gameType&startdate=$startdate&enddate=$enddate&page_no=$page_no",$page_no,$page_size,$row_count);

Template::assign ( '_REQUEST', $_REQUEST);
Template::assign ( 'records', $records );
Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );

Template::display ( 'agent/sellgemslist.tpl' );