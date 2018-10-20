<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class WxPay extends Base {
	
	/**
	 * [getWxPayOrderNo 获取订单账号]
	 * @Author   李爽
	 * @DateTime 2018-09-17T10:20:20+0800
	 * @param    [type]                   $agentid [description]
	 * @return   [type]                            [description]
	 */
	private static function getWxPayOrderNo($agentid){
		if(empty($agentid))return;
		return "1076" . $agentid . explode(" ",microtime())[1];
	}

	/**
	 * [getWxPayOrder 支付下单]
	 * @Author   李爽
	 * @DateTime 2018-08-15T09:32:20+0800
	 * @param    [type]                   $money [金额]
	 * @param    [type]                   $coin  [钻石]
	 * @return   [type]                          [返回信息]
	 */
	public static function getWxPayOrder($money,$coin){
		if(empty($money)||empty($coin)) return;
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return;
		$order_no = self::getWxPayOrderNo($agentid);
		$db = self::__instance();
		$db->exec("call sp_agent_pay('".$order_no."',".$agentid.",".$money.",".$coin.",@od_out)");
		return $db->query("select @od_out")->fetch(PDO::FETCH_ASSOC)["@od_out"];
	}

	/**
	 * [agentPurchaseNotify 微信支付回掉]
	 * @Author   李爽
	 * @DateTime 2018-08-16T16:52:29+0800
	 * @param    [type]                   $notifyArray [description]
	 * @return   [type]                                [description]
	*/
	public static function agentPurchaseNotify($notifyArray){
		if(empty($notifyArray)) return;
		$db = self::__instance();
		$db->exec("call sp_agent_pay_update('".$notifyArray['order_no']."','".$notifyArray['status']."',".$notifyArray['total_fee'].",'".$notifyArray['transaction_id']."','1',@ap_out)");
		return $db->query('select @ap_out')->fetch(PDO::FETCH_ASSOC)[@ap_out];
	}

	/**
	 * [checkOrderNoIsExit 检查订单]
	 * @Author   李爽
	 * @DateTime 2018-08-16T15:17:16+0800
	 * @param    [type]                   $order_no [订单号]
	 * @return   [type]                             [是否存在]
	 */
	public static function checkOrderNoIsExit($order_no){
		if(empty($order_no)) return;
		$db = self::__instance();
		$sql ="select count(id) from order_pay where id = ".$order_no ." and status = 0";
		return 0 + $db->query($sql)->fetchColumn();
	}


	/**
	 * [weCashToOrder 提现下订单]
	 * @Author   李爽
	 * @DateTime 2018-08-21T13:58:15+0800
	 * @param    [type]                   $money [description]
	 * @return   [type]                          [description]
	 */
	public function weCashToOrder($money,$gift,$cashratio){
		if(empty($money)||!isset($gift)||!isset($cashratio)) return;
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return;
		$order_no = self::getWxPayOrderNo($agentid);
		$db = self::__instance();
		$db->exec("call sp_agent_out_cash('".$order_no."',".$agentid.",".$money.",".$gift.",".$cashratio.",@co_out)");
		return $db->query("select @co_out")->fetch(PDO::FETCH_ASSOC)["@co_out"];
	}

	/**
	 * [updateWeCashOrder 更新订单]
	 * @Author   李爽
	 * @DateTime 2018-08-21T14:15:50+0800
	 * @param    [type]                   $weCashArray [订单数据]
	 * @return   [type]                                [返回订单结果]
	*/
	public function updateWeCashOrder($weCashArray){
		if(empty($weCashArray)) return;
		$db = self::__instance();
		$db->exec("call sp_agent_out_cash_update('".$weCashArray['order_no']."',".$weCashArray['agentid'].",".$weCashArray['transaction_id'].",'".$weCashArray['status']."',@aocu_out)");
		return $db->query('select @aocu_out')->fetch(PDO::FETCH_ASSOC)["@aocu_out"];
	}

	/**
	 * [checkWxCasOrderIsExist 查询提现订单]
	 * @Author   李爽
	 * @DateTime 2018-08-29T14:35:13+0800
	 * @param    [type]                   $order_no [订单号]
	 * @return   [type]                             [description]
	 */
	public function checkWxCasOrderIsExist($order_no,$agentid){
		if(empty($order_no)||empty($agentid)) return;
		$db = self::__instance();
		$sql ="select count(id) from agent_transfer where id = ".$order_no ." and status = 0 and agentid = ".$agentid;
		return 0 + $db->query($sql)->fetchColumn();
	}

	/**
	 * [getWxCashOrderByOrderNo 获取订单信息]
	 * @Author   李爽
	 * @DateTime 2018-08-29T15:35:46+0800
	 * @param    [type]                   $order_no [订单号]
	 * @return   [type]                             [description]
	 */
	public function getWxCashOrderByOrderNo($order_no,$agentid){
		if(empty($order_no)||empty($agentid)) return;
		$db = self::__instance();
		$sql ="select rmb,gift,status from agent_transfer where id = ".$order_no ." and status = 0 and agentid = ".$agentid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}
}