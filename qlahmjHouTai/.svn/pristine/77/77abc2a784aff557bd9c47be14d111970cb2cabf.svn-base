<?php
require ('../include/init.inc.php');
require_once "ApiConfig.php";
// require('../payInterfacegzzh/GzzhRequest.php');
$result = array (
		'status' => 0,
		'msg' => '' 
);
$uri = HttpRequest::parse_request_uri ();

if (! function_exists ( $uri )) {
	$result['status'] = 0;
	$result['msg'] = '请求连接不存在';
	echo json_encode ( $result );
	exit ();
}
// var_dump ( $uri );

if (strtolower ( $uri ) == 'cz') {
	$transaction_id = $uid = $total_fee = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
			"transaction_id"=>$transaction_id,
			"uid" => $uid,
			"total_fee" => $total_fee
	) );
}  else {
	$result['status'] = 0;
	$result['msg'] = '请求连接不存在';
	echo json_encode ( $result );
	exit ();
}

function cz($args) {

	// begin 下单
	list($s1, $s2) = explode(' ', microtime());
	//$mic = (float)sprintf('%.0f', (floatval($s1) + floatval($s2)) * 10000);
	$transaction_id = "855" . date ( "YmdHis" ) . rand ( pow ( 10, (7 - 1) ), pow ( 10, 7 ) - 1 );
	$uid = $args["uid"];
	$payment = $args["total_fee"];
	switch ($payment)
	{
			
	}
	$price = 100; // 需要修改
	$number = $payment / $price; // 需要修改
	$preferential_number = 0;
	$body = "ios充值";

	$input_data = array (
			'transaction_id'=>$args["transaction_id"],
			'out_trade_no' => $transaction_id,
			'uid' => $uid,
			'payment' => $payment, // $payment,
			'price' => $price,
			'number' => $number,
			'preferential_number' => $preferential_number,
			'status' => 0,
			'payment_way' => "weixin",
			'proportion_status' => 0 ,
			'create_time'=>date("Y-m-d H:i:s")
	);
	$oid = Order::addOrder ( $input_data );

	// end生产自定义订单数据，保存数据库
	if($oid)
	{
	    Calculate::CalculateOrder_weixin( $input_data[ "out_trade_no"]);
	    $result['status']=1;
	    $result['msg']="成功";
	}
	else {
		 $result['status']=1;
		 $result['msg']="失败";
	}

	echo json_encode ( $result );
}

