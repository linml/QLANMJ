<?php 
require ('../include/init.inc.php');
$agentid = $method ='';
extract($_REQUEST,EXTR_IF_EXISTS);
if($method=='unbindRelationship'&&!empty($agentid)){
	$result = AgentCenter::getAgentUnbindRelationship($agentid);
	exit($result);
}
$agentsInfo = AgentCenter::getAgentsInfoByAgentId($agentid);

Template::assign ('_REQUEST', $_REQUEST);
Template::assign ('agentsInfo', $agentsInfo);
Template::assign ('agentid', $agentid);
Template::display ( 'agentcenter/toAgentsInfo.tpl');