<?php
require ('../include/init.inc.php');
require ('../include/class/share/jssdk.php');

//判断二维码代理解析出来的代理ID是否存在
if(empty($_REQUEST['agentid'])){echo("<script>alert('二维码解析有误！');</script>"); return;}
$agentid = $_REQUEST['agentid'];

//1、 判断代理ID是否有效
if($agentid!=76 && AgentCenter::toJudgeAgentIsExistByAgentId($agentid)<=0) {echo("<script>alert('代理不存在！');</script>"); return;}

// 2、 获取微信code
if(empty($_GET['code'])){
	$redirctUrl = $_SERVER['HTTP_HOST'].$_SERVER['PHP_SELF'];
	$url = "http://lamj.qilehuyu.cn/redirect.php?redirectUrl=".$redirctUrl."&".$_SERVER["QUERY_STRING"];
	Header("Location: $url"); 
	exit();
}

if(empty($_GET['code'])) {echo("<script>alert('授权code获取失败！');</script>"); return;}

// 3、获取微信access_token
$acces_token = JSSDK::getAccessToken($_GET['code']);


if(empty($acces_token->access_token)){echo("<script>alert('获取Token失败！');</script>"); return;}

// 4、根据access_toke 获取用户信息
$userInfo = JSSDK::getUserInfoByAccessToken($acces_token->access_token,$acces_token->openid);

if(empty($userInfo->unionid)){echo("<script>alert('获取玩家信息失败！');</script>"); return;}

//5、判断玩家是否已注册
if($sns_userid = Players::checkPlayerIsIvited($userInfo->unionid,$userInfo->openid)){
	// 处理玩家上级代理的重新绑定
	if(Players::getPlayerInfoByUserid($sns_userid['userid'])['agentid']==0){
		if(Players::updatePlayerBindAgentid($sns_userid['userid'],$agentid)>0){
			echo("<script>alert('玩家重新绑定成功！');</script>"); 
			Template::display ( 'sharedownload/download.tpl' ); 
			exit();
		}else{
			echo("<script>alert('玩家重新绑定失败！</br> ".$sns_userid['userid']."');</script>"); 
			exit();
		}
	}else{
		echo("<script>alert('玩家已注册！');</script>"); 
		Template::display ( 'sharedownload/download.tpl' ); 
		exit();
	}
}

//6、创建玩家账户
$AUResult = JSSDK::addUserAccount($userInfo->nickname,$userInfo->sex,$agentid,$userInfo->headimgurl,$userInfo->unionid,$userInfo->openid);

if($AUResult===0)
	echo("<script>alert('玩家已注册或者代理不存在！');</script>");
else if($AUResult===-1)
	echo("<script>alert('开通玩家账号有误！');</script>");

Template::display ( 'sharedownload/download.tpl' ); //重新做页面

?>