<?php
require ('../include/init.inc.php');
$server_maintenance = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );

$message = CloseRoom::getMessage();

if (Common::isPost ()) {
	$level_data=array('key_value'=>$server_maintenance);
	$result = CloseRoom::updateMessage("server_maintenance", $level_data);
	if ($result>=0) {
		SysLog::addLog ( UserSession::getUserName(), '关闭房间', '' ,'', $server_maintenance );
		Common::exitWithSuccess ( '关闭通知设置完成','agent/closeroom.php' );
	} else {
		OSAdmin::alert("error");
	}
}



Template::assign ( 'message', $message );

Template::display ( 'agent/closeroom.tpl' );