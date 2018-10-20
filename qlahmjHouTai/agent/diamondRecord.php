<?php 
require ('../include/init.inc.php');
$page_no = $method = $type = $contains = $startdate = $enddate = $flag = $index ='';
extract ( $_REQUEST, EXTR_IF_EXISTS );

// exit(var_dump($index));
if(empty($method)) $method ="getRechargeDiamondRecod";
if(empty($index)) $index = 1;
$where = DiamondRecord::getWhere($method,$type,$contains,$startdate,$enddate);

// START 数据库查询及分页数据
$page_no = $page_no < 1 ? 1 : $page_no;
$page_size = PAGE_SIZE;
$row_count = DiamondRecord::getRowCount($method,$where);
$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
$total_page = $total_page < 1 ? 1 : $total_page;
$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;

if($flag==2){
	switch ($method) {
		case 'getRechargeDiamondRecod':
			$where = DiamondRecord::getWhere($method,$type,$contains,$startdate,$enddate);
			$result = DiamondRecord::getRechargeDiamondRecod($start,$page_size,$where);
			exit(json_encode($result));
			break;
		case 'getAgentTransferRecord':
			$where = DiamondRecord::getWhere($method,$type,$contains,$startdate,$enddate);
			$result = DiamondRecord::getAgentTransferRecord($start,$page_size,$where);
			exit(json_encode($result));
			break;
		case 'buyDiamondRecord':
			$where = DiamondRecord::getWhere($method,$type,$contains,$startdate,$enddate);
			$result = DiamondRecord::buyDiamondRecord($start,$page_size,$where);
			exit(json_encode($result));
			break;
		case 'systemTransfer':
			$where = DiamondRecord::getWhere($method,$type,$contains,$startdate,$enddate);
			$result = DiamondRecord::systemTransfer($start,$page_size,$where);
			exit(json_encode($result));
			break;
		case 'systemSendAndSold':
			$where = DiamondRecord::getWhere($method,$type,$contains,$startdate,$enddate);
			$result = DiamondRecord::systemSendAndSold($start,$page_size,$where);
			exit(json_encode($result));
			break;
		default:
			break;
	}
}

$page_html = Pagination::showPager ( "diamondRecord.php?method=$method&flag=1&type=$type&contains=$contains&startdate=$startdate&enddate=$enddate&index=$index", $page_no, $page_size, $row_count );

Template::assign ( 'agentsList', $agentsList );
Template::assign ( 'page_no', json_encode($page_no) );
Template::assign ( 'method', json_encode($method) );
Template::assign ( '_REQUEST', json_encode($_REQUEST) );
Template::assign ( 'index', $index);
Template::assign ( 'page_html', $page_html );
Template::display ( 'agent/diamondRecord.tpl' );
