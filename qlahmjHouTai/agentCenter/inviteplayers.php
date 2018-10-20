<?php 
require ('../include/init.inc.php');

//获取代理ID
$agentid = UserSession::getAgentId();
//通过代理获取代理信息
$userInfo = Players::getPlayerInfoByUserid(UserSession::getAgentUserId());

$shareData = array('bgName'=>'invite','iconName'=>$userInfo["picfile"],

	'icon'=>array('pos'=>array('x'=>99 ,'y'=>188 ),'size'=>array('width'=>95,'height'=>95)),

	'qrcodeData'=>array('url' =>'http://'.$_SERVER['HTTP_HOST'].'/share/pushbind.php?agentid='.$agentid ,'userid'=>$userInfo['userid'],'icon_url'=>$userInfo["picfile"]),

	'qrcode'=>array('pos'=>array('x'=>254 ,'y'=>576 ),'size'=>array('width'=>245,'height'=>245)),

	'font'=> array('fontSize'=>18,'angle'=>0,'x'=>110,'y'=>303,'color'=>array('r'=>88,'g'=>42,'b'=>146,'alpha'=>0))
);

$shareImages =  PhpqrCode::getSharePlayersQrCode($shareData);

Template::assign ( 'shareImages',$shareImages );
Template::display ( 'agentcenter/toInvitePlayers.tpl' );