<?php 
require ('../include/init.inc.php');
$userid = $method = $money='';
extract($_REQUEST,EXTR_IF_EXISTS);


if($method=='playerRecharge'&&!empty($userid)&&!empty($money)){
	//1、获取要返回的钻石数量
	$currencyCount = GemsRecharge::getRechargeConfig($money,1);
	//2、获取要加赠的钻石
	$bonusCount = GemsRecharge::getRechargeConfig($money,2);
	if(empty($currencyCount)) exit('5');
	//3、调用充值
	$result = GemsRecharge::toRechargeThePlayer($userid,$money,$currencyCount,$bonusCount);
	//4、处理返回信息
	exit($result);
}
Template::assign('MyAccountDiamond',GemsRecharge::getAccountDiamond());
Template::assign ('userid', $userid);
Template::display ( 'agentcenter/toGemsRecharge.tpl' );