<?php 
require ('../include/init.inc.php');
require_once ADMIN_BASE_LIB."WxPay/pay/WxCash.class.php";
$money =  '';
extract ( $_REQUEST, EXTR_IF_EXISTS );

// 金额的验证
if(empty($money)){exit("<script>alert('金额有误！');window.location.href='../agentCenter/drawmoney.php';</script>");}

if($money < 100){exit("<script>alert('单笔提现金额必须大于100(元)！');window.location.href='../agentCenter/drawmoney.php';</script>");}

$agentid = UserSession::getAgentId();
if(empty($agentid)){exit("<script>alert('SESSION_AGENTID 丢失,请重新登陆！');window.location.href='../agentCenter/drawmoney.php';</script>");}

$agentInfo = AgentCenter::getAgentInfoByAgentId($agentid);
//验证代理是否有金额小于体现金额
if($agentInfo['rmb'] < $money){exit("<script>alert('提现金额不能大于账户余额！');window.location.href='../agentCenter/drawmoney.php';</script>");}

$tools = new WxCash();
//获取微信code 
$wxData = $tools->GetOpenid();

if(empty($wxData['unionid'])) exit("<script>alert('UNIONID获取失败！');</script>");

//获取存储的opendid 和 检测
$userSNSInfo = Players::getUserSNSByUserid(UserSession::getAgentUserId());
if(empty($userSNSInfo)){exit("<script>alert('读取玩家UNIONID错误,请校验数据库！');window.location.href='../agentCenter/drawmoney.php';</script>");}

if($userSNSInfo['unionId'] != $wxData['unionid']){exit("<script>alert('请用注册的微信进行提现！');window.location.href='../agentCenter/drawmoney.php';</script>");}

//判断OPENID存在情况
if($userSNSInfo['openId'] != $wxData['openid']){
	if(!Players::updateUserSNSOpenidByUserid(UserSession::getAgentUserId(),$wxData['openid'])){
		exit("<script>alert('数据库OPENID修正有误！');window.location.href='../agentCenter/drawmoney.php';</script>");
	}
}
//进行下单处理
$orderResult = WxPay::weCashToOrder($money,0.00,0.00);

if(!is_null($orderResult)){
	if($orderResult==-1) 
		$msg = "提现订单失败！";
	else
		$msg ="提现成功，请等待审核！";
}else
	$msg="未知错误！";

exit("<script>alert('".$msg."');window.location.href='../agentCenter/drawmoney.php';</script>");