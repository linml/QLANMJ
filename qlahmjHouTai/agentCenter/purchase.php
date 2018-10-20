<?php 
require ('../include/init.inc.php');
$method = $diamond = $discount =  '';
extract ( $_REQUEST, EXTR_IF_EXISTS );

if($method=='getDicountDiamond'&& !empty($diamond) && !empty($discount)){
	$result = DrawMoney::getOnvertedMoney($diamond,$discount);
	exit($result);
}
//获取代理等级
$levelData = AgentCenter::getAgentLevleByLevelid(UserSession::getAgentLevelId());
Template::assign ('levelData', $levelData);
Template::display ( 'agentcenter/toPurchase.tpl');