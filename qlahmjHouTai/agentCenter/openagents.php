<?php 
require ('../include/init.inc.php');
$method = $playerid = $nickName=$tel=$wechat=$wechatName = $leviled ='';
extract($_REQUEST,EXTR_IF_EXISTS);

return ;

if($method=='valiPlayer'&&!empty($playerid)){
	$agentid = UserSession::getAgentId();
	if(empty($agentid)) return;
	
	//1、查询玩家是否合法
	$result = OpenAgents::getValidatePlayerByAgentId($agentid,$playerid);

	if(is_null($result))exit(json_encode(array('status'=>1))); //参数为空问题

	if(empty($result))exit(json_encode(array('status'=>2))); // 查询结果为空
	//2、判断此玩家是否是代理
	$agentCount = AgentCenter::toJudgeAgentIsExist($playerid);

	if($agentCount>0) exit(json_encode(array('status'=>4)));
	
	exit(json_encode(array('name'=>$result[0]['nickname'],'status'=>3))); //查询结果正常
}else if($method=='addAgent'&&!empty($playerid)&&!empty($nickName)&&
	!empty($tel)&&!empty($wechat)&&!empty($wechatName)&&!empty($leviled)){
	//添加代理信息
	$taa_out = AgentCenter::toAddAgent($playerid,$nickName,$wechat,$wechatName,$tel,$leviled);
	exit($taa_out);
}

//获取代理等级
$levleData = AgentCenter::getUpLevelByAgentLevel(UserSession::getAgentLevelId());
Template::assign ('levleData', $levleData);
Template::display ( 'agentcenter/toOpenAgents.tpl' );