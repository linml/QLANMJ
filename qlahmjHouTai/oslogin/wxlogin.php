<?php 
require ('../include/init.inc.php');
$APPID = 'wx4a98d29526a1f737';
$unionid = getUnionId();
if($unionid){
	$agent = OScheck::checkOSisAgentByUnionId($unionid);
	if($agent['status'] == '1'){
		User::loginDoSomething(AGENT,$agent['agentid']);
		$encrypted = OSAEncrypt::encrypt($agent['agentid']);
		User::setCookieRemember(AGENT,urlencode($encrypted),30);
		Common::jumpUrl ( 'agentCenter/home.php' );
	}else{
		echo("<script>alert('".ErrorMessage::BE_PAUSED."');</script>");
		// OSAdmin::alert("error",ErrorMessage::BE_PAUSED);
	}
}else{
	echo("<script>alert('非法登陆！');</script>");
}
function getUnionId(){
	//通过code获得openid
	if (!isset($_GET['code'])){
		//触发微信返回code码
		$redirctUrl = $_SERVER['HTTP_HOST'].$_SERVER['PHP_SELF'];
		$curl = "http://lamj.qilehuyu.cn/redirect.php?redirectUrl=".$redirctUrl."&".$_SERVER["QUERY_STRING"];
		Header("Location: $curl");
		exit();
	} else {
		//获取code码，以获取openid
	    $code = $_GET['code'];
		// $openid = $this->GetOpenidFromMp($code);
		$url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx4a98d29526a1f737&secret=41a9b68c15f9e09201f20de590125b92&code=$code&grant_type=authorization_code";
		$result = Base::curl_init($url);
		$ret = json_decode($result,true);
		// var_dump($ret['unionid']);exit();
		return $ret['unionid'];
	}
}


