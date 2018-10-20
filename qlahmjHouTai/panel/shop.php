<?php
require ('../include/init.inc.php');
$method = $shop_id = $shop_name = $shop_price = $shop_gems = $shop_discount = $shop_state = '';

extract ( $_REQUEST, EXTR_IF_EXISTS );

if ($method == 'shop_edit') {
	//STools::log("\nshop_edit is start\n");
	STools::log("id:".$shop_id."name:".$shop_name."price:".$shop_price."gems:".$shop_gems."discount:".$shop_discount."state:".$shop_state);
	$data = array (
		"name" => $shop_name,
		"price" => $shop_price,
		"gems" => $shop_gems,
		"discount" => $shop_discount,
		"state" => $shop_state
	);
	$result = Shoping::updateShopInfo($shop_id,$data);
	echo json_encode (array('status' => $result));
	exit ();
}
/*// START 数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;
if ($search && $user_name) {
	$row_count = Agent::getAllUsersCountSearch ( $user_name );
	
	$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
	$total_page = $total_page < 1 ? 1 : $total_page;
	$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
	$start = ($page_no - 1) * $page_size;
	
	$agents = Agent::getAllAgentSearch ( $user_name, $start, $page_size );
} else {
	$row_count = Agent::getAllUsersCount ();
	$total_page = $row_count % $page_size == 0 ? $row_count / $page_size : ceil ( $row_count / $page_size );
	$total_page = $total_page < 1 ? 1 : $total_page;
	$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
	$start = ($page_no - 1) * $page_size;
	$agents = Agent::getAllAgent ( $start, $page_size );
	// var_dump($agents);
}

$page_html = Pagination::showPager ( "agent.php?user_name=$user_name&search=$search", $page_no, $page_size, $row_count );
*/
/*$module_options_list = Agent::getAgentForOptions ();
$module_options_list[0] = "请选择";
ksort ( $module_options_list );
Template::assign ( 'module_options_list', $module_options_list );*/
$shops = Shoping::getAllShopingInfo();
//var_dump($shops);
Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'shops', $shops);
//STools::log($shops);
/*Template::assign ( 'page_no', $page_no );
Template::assign ( 'page_html', $page_html );*/

Template::display ( 'agent/shopping.tpl' );