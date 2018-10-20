<?php
require ('../include/init.inc.php');
$method = $module_id = '';
extract ( $_GET, EXTR_IF_EXISTS );

if ($method == 'del' && ! empty ( $module_id )) {
	$menus = StrongUpdate::getModuleMenu ( $module_id );
	$result = StrongUpdate::delModule ( $module_id );
	if ($result) {
		SysLog::addLog ( UserSession::getUserName (), 'DELETE', '强更新版本', $module_id, json_encode ( $menus ) );
		Common::exitWithSuccess ( '版本删除成功', 'agent/strongupdate.php' );
	}
}

$modules = StrongUpdate::getAllModules ();
$confirm_html = OSAdmin::renderJsConfirm ( "icon-remove" );
Template::assign ( 'modules', $modules );
Template::assign ( 'osadmin_action_confirm', $confirm_html );
Template::display ( 'agent/strongupdate.tpl' );