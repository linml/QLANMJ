<?php 
require ('../include/init.inc.php');

$userid = UserSession::getAgentUserId();
//获取title信息
$friendTitleInfo = FriendsCircle::getFriendTiltleInformation();

$friendscirclesList = FriendsCircle::getFriendList($userid);

Template::assign ('friendTitleInfo', $friendTitleInfo);
Template::assign ('friendscirclesList', $friendscirclesList);
Template::display ( 'agentcenter/FriendsCircle.tpl' );