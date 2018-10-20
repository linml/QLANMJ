<?php
require ('../include/init.inc.php');

$agentname = $wechatnum = '';
extract($_REQUEST,EXTR_IF_EXISTS);
$agentid    = UserSession::getAgentId();
$AgentInfo  = UpdateMyInfo::getInfo($agentid);

if(Common::isPost()&&($agentname != $AgentInfo['agentname'] || $wechatnum != $AgentInfo['wechatnum'])){
	$result	= UpdateMyInfo::updateInfo($agentid,$agentname,$wechatnum);
	if($result){
			echo '<script>alert("修改成功!").windows.location.href="/agentCenter/Mine.php"</script>';
			$AgentInfo  = UpdateMyInfo::getInfo($agentid);
			Template::assign ('AgentInfo', $AgentInfo);

		}else{
			Template::assign ('AgentInfo', $AgentInfo);
		}
}else{
	Template::assign ('AgentInfo', $AgentInfo);
}

Template::display ('agentcenter/toUpdateMyInfo.tpl');