<?php
require ('../include/init.inc.php');
$method = $gameUserid = $agentid ='';
extract ( $_REQUEST, EXTR_IF_EXISTS );



if($method=='getGameInfor'&&!empty($gameUserid)){
	$bingAgentData = GamePlayer::getGameUserByUserid($gameUserid);
	if($bingAgentData) 
		exit(json_encode($bingAgentData));
	exit('{"result":"玩家不存在,请检查玩家ID是否正确！"}');
}

if($method=='getAgentInfor'&&!empty($agentid)){
	$bingAgentData = Agent::getAgentByOsaUserId($agentid);
	if($bingAgentData) 
		exit(json_encode($bingAgentData));
	exit('{"result":"代理不存在,请检查代理ID是否正确！"}');
}

if($method=='changeAgentRelationShip'&&!empty($gameUserid)&&trim($agentid)!=''){
	$result = Agent::changeAgentRelationShip($gameUserid,$agentid);
	if($agentid==0){
		exit('{"result":"'.$gameUserid.' 已成功解除代理关系"}');
	}else{
		exit('{"result":"'.$result.'"}');
	}
}

Template::assign ( '_REQUEST', $_REQUEST );
Template::display ( 'agent/agentBinding.tpl' );