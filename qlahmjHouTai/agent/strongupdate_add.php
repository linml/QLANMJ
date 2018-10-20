<?php
require ('../include/init.inc.php');
$versoin = $ios = $ios_url = $android = $android_url ='';
extract ( $_POST, EXTR_IF_EXISTS );

if (Common::isPost ()) {
	$exist = StrongUpdate::getModuleByName($versoin);
	if($exist){
		OSAdmin::alert("error","版本冲突");
	}else if($versoin ==""){
		OSAdmin::alert("error","版本号不能为空");
	}else{
		$input_data = array ('versoin' => $versoin, 'ios' => $ios, 'ios_url' => $ios_url 
				,'android' =>$android,'android_url' =>$android_url
				,'create_time'=>date("Y-m-d H:i:s")
		);
		$module_id = StrongUpdate::addModule ( $input_data );
		if ($module_id) {
			SysLog::addLog ( UserSession::getUserName(), 'ADD', '强更新版本' , $module_id, json_encode($input_data) );
			Common::exitWithSuccess ('强更新版本添加成功','agent/strongupdate.php');
		}
	}
}

Template::assign("_POST" ,$_POST);
Template::display('agent/strongupdate_add.tpl' );