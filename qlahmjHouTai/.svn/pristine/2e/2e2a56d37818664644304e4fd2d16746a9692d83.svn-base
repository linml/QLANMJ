<?php 
require ('../include/init.inc.php');
$method = $userid = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );
if($method=="unbindRelationship"&&!empty($userid)){
	$result = Players::getPlayerUnbindRelationship($userid);
	exit($result);
}
$palyerInfo = Players::getPlayerInfoByUserid($userid);

Template::assign ('palyerInfo', $palyerInfo);
Template::display ( 'agentcenter/toPlayersInfo.tpl');