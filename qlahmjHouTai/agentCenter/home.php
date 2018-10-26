<?php 
require ('../include/init.inc.php');
$method = '';
$agentid       = UserSession::getAgentId();
//获取代理基本信息
$AgentsInfo    = Home::getAgentAccountInformation($agentid);

//获取代理当天返利情况
$agentMaidData = Home::getAgentMaidByAgentId(UserSession::getAgentId());
//获取代理绑定数量
$agentBindData = Home::getAgentBindInforCountbyAgentid();

$getDayActiveData = Home::getDayActive();
$getDayReturnData = Home::getDayReturn();

$dateid     = array_column($getDayActiveData, 'dateid');
$dateidArr = array();
foreach ($dateid as $key => $value) {
	array_push($dateidArr,substr($value, 5));
}
$activeData = array_column($getDayActiveData, 'dayreturn');
$returnData = array_column($getDayReturnData, 'dayreturn');
$maxReturn = max($returnData);
Template::assign ('AgentsInfo',$AgentsInfo);
Template::assign ('agentMaidData',$agentMaidData);
Template::assign ('agentBindData',$agentBindData);
Template::assign ('dateidArr',json_encode($dateidArr));
Template::assign ('activeData',json_encode($activeData));
Template::assign ('returnData',json_encode($returnData));
Template::assign ('maxReturn',json_encode($maxReturn));
Template::display ( 'agentcenter/Home.tpl' );