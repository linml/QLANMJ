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

	if($result == 1){
		$userId   = intval($userid);
		$diamondAccount = GamePlayer::getUserAccountById($userid);
		$moneyBag = "2|".intval($diamondAccount);
		$time = time();
		$url = "http://api.test.qileah.cn/web/Manage.PushUserMoneyMag";
		$ql_appid = "ql_8k6p1061ir04";
		$secret = "iggplpi029ashcan39421oa86n16wn9d";
		$api_version = "1";
		$stringA = "api_version=$api_version&moneyBag=$moneyBag&ql_appid=ql_8k6p1061ir04&timestamp=$time&userId=$userId";
		$stringSignTemp = "api.test.qileah.cn/web/Manage.PushUserMoneyMag"."?".$stringA."&".$secret;
		$sign = strtoupper(sha1($stringSignTemp));
		$post_data = array(
			"userId"=>$userId,
			"moneyBag"=>$moneyBag,
			"ql_appid"=>$ql_appid,
			"api_version"=>1,
			"sign"=>$sign,
			"timestamp"=>$time
		);
		Base::curl_post($url,$post_data);
	}

	//4、处理返回信息
	exit($result);
}
Template::assign('MyAccountDiamond',GemsRecharge::getAccountDiamond());
Template::assign ('userid', $userid);
Template::display ( 'agentcenter/toGemsRecharge.tpl' );