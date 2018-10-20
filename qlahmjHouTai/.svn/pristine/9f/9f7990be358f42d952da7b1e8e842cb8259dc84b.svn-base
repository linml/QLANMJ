<?php 
require ('../include/init.inc.php');
require_once ADMIN_BASE_LIB."WxPay/pay/WxCash.class.php";
$order_no = $agentid =  '';
extract ( $_REQUEST, EXTR_IF_EXISTS );

// 金额的验证
if(empty($order_no) || empty($agentid)){exit("订单号或代理ID有误！");}

//验证代理是否有金额小于体现金额
if(WxPay::checkWxCasOrderIsExist($order_no,$agentid)!=1){exit("提现订单有误！");}

//获取玩家OPENID 
$openid = Players::getUserSNSByUserid(Agent::getUserIdByAgentid($agentid))['openId'];

if(empty($openid)) exit("OPENID获取失败！");
//获取订单信息
$orderMInfo = WxPay::getWxCashOrderByOrderNo($order_no,$agentid);
if(empty($orderMInfo)) {exit("订单信息获取失败！");}

if($orderMInfo['status']!=0){exit("提现订单已被处理！");}
$oderData = array(
	'partner_trade_no' =>$order_no,
	'openid'=>$openid,
	'check_name'=>'NO_CHECK',
	'amount'=>$orderMInfo['rmb']*100,
	'desc'=>'代理商提现'
);

$tools = new WxCash();
$wecashResult = $tools->WeChatCash($oderData);

$uWeCashOrderData = array(
			'order_no' =>$order_no,
			'agentid'=>$agentid,
		);
if ($wecashResult['return_code'] == 'SUCCESS' && $wecashResult['result_code'] == 'SUCCESS') {
    //1、成功的业务处理
    $uWeCashOrderData['transaction_id'] =  $wecashResult['payment_no'];
    $uWeCashOrderData['status'] =  1;
    $isrr = array(
        'code'=>true,
        'msg' =>'提现成功！',
    );
} else {
	//2、失败的业务处理
	$uWeCashOrderData['transaction_id'] =  $order_no;
    $uWeCashOrderData['status'] =  2;
    $isrr = array(
        'code' => false,
        'msg' => (string)$wecashResult['return_msg']."\n".(string)$wecashResult['err_code']
    );
}

$cashOrderResult = WxPay::updateWeCashOrder($uWeCashOrderData);

if($cashOrderResult==-1){
	$isrr['code'] = false;
	if($isrr['code'])
		$isrr['msg'] ='提现失败';
	else 
		$isrr['msg'] =$isrr['msg']."\n".'提现失败';
}else if($cashOrderResult==0){
	$isrr['code'] = false;
	if($isrr['code'])
		$isrr['msg'] ='无订单号或余额不足';
	else 
		$isrr['msg'] =$isrr['msg']."\n".'无订单号或余额不足';
}
exit($isrr['msg']);