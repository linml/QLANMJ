<?php 
require ('../include/init.inc.php');
$friendid = '';
extract ( $_REQUEST,EXTR_IF_EXISTS );
$friendInfo = FriendsCircleInfo::getFriendInfo($friendid);
Template::assign ('friendInfo', $friendInfo);
Template::display ( 'agentcenter/toFriendsCircleInfo.tpl');