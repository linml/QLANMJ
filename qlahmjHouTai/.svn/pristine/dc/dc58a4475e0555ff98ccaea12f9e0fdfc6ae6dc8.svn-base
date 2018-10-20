<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class Order extends Base {
	
	// 表名
	private static $table_name = 'order';

	public static function getTableName(){
		return parent::$table_prefix_osa_t.self::$table_name;
	}

	//修改订单
	//oid 修改目标	
	public static function updateOrder($oid, $group_data) {
		if (!$group_data || !is_array ( $group_data )) {
			return false;
		}
		$db = self::__instance();
		$condition = array("oid"=>$oid);
		$id = $db->update( self::getTableName(), $group_data, $condition );
		return $id;
	}

	//改变订单状态
	//oid 修改目标
	//state 状态标志 "addGemsFinish" "proportionFinish" 
	public static function onOrderChangeState($oid, $state){
		$db = self::__instance();
		$condition = array("oid"=>$oid);
		
		if($state === "addGemsFinish") $updateData = ["status"=>1];
		else if($state === "proportionFinish") $updateData = ["proportion_status"=>1];

		$ret = $db->update(self::getTableName(), $updateData, $condition);
		if($ret === false){
			SysLog::addLog("oid:".$oid, "onOrderChangeState", "Order", "", ["oid"=>$oid, "state"=>$state, "errData"=>$db->error()], 2);
            return false;
		}
		return true;
	}	
	
	//添加订单
	public static function addOrder($orderData) {
		if (!$orderData || !is_array($orderData)) return false;
		
		$db=self::__instance();
		$db->insert(self::getTableName(), $orderData);
	}

	//获取订单信息
	//out_trade_no 目标订单号
	public static function getOrder_byOutTradeNo($outTradeNo) {
		$db=self::__instance();
		$ret = $db->select(self::getTableName(), "*", ["out_trade_no"=>$outTradeNo]);

		if ($ret) return $ret[0];
		else return null;		
	}	

	//接收到JS端订单支付成功的消息, 并对其进行处理
	public static function onOrderComplete_byJS($outTradeNo){

		/*$data = [
			"transaction_id"    => $orderData["transactionId"],
			"out_trade_no"      => $orderData["outTradeNo"],
			"uid"               => $orderData["userId"],
			"payment"           => $orderData["payment"],
			"price"             => $orderData["payment"],
			"number"            => $orderData["number"],
			"status"            => 0,
			"payment_way"       => "wx",
			"proportion_status" => 0
		];

		self::addOrder($data);*/

		$order = self::getOrder_byOutTradeNo($outTradeNo);
		if(!$order){
			SysLog::addLog("userId:".$order["uid"], "getOrder_byOutTradeNo", "Order", "", ["outTradeNo"=>$outTradeNo], 2);
			return "notFindOrder";
		}else{
			return Calculate::calculateOrder($order);
		}
	}

	//找到所有未被处理过的订单, 并进行处理
	public static function scanAllOrder(){

	}
}