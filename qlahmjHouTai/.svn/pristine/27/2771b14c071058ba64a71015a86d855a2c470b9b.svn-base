<?php 
require ('../include/init.inc.php');
$method = $userid = '';
extract($_REQUEST,EXTR_IF_EXISTS);

$agentid = UserSession::getAgentId();
$result  = Mine::getAgentInfo($agentid);
if(!empty($method)&&!empty($userid)){
	$result = User::logout(AGENT);
	exit($result);
}
Template::assign ('result', $result);
Template::display ( 'agentcenter/Mine.tpl' );