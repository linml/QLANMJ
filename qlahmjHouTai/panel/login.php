<?php
require ('../include/init.inc.php');
$user_name = $password = $remember = $verify_code='';
extract ( $_POST, EXTR_IF_EXISTS );
if (Common::isPost ()) {
	if(strtolower($verify_code) != strtolower($_SESSION['osa_verify_code'])){
		OSAdmin::alert("error",ErrorMessage::VERIFY_CODE_WRONG);
	}else{
		$user_info = User::checkPassword (ADMIN, $user_name, $password );
		if ($user_info) {
			if($user_info['status']==1){
				User::loginDoSomething(ADMIN,$user_info['user_id']);
				
				if($remember){
					$encrypted = OSAEncrypt::encrypt($user_info['user_id']);
					User::setCookieRemember(ADMIN,urlencode($encrypted),30);
				}
				/*//设置登录系统记录 
				$ip = Common::getIp();
				SysLog::addLog ( $user_name, 'LOGIN', 'User' ,UserSession::getUserId(),json_encode(array("IP" => $ip)));*/

				/*if(UserSession::getAgentUid() && UserSession::getAgentUid()!=0) {
					Common::jumpUrl ( 'agentcenter/summary.php' );
				} else {
					Common::jumpUrl ( 'panel/index.php' );
				}*/
				Common::jumpUrl ( 'panel/index.php' );
			}else{
				OSAdmin::alert("error",ErrorMessage::BE_PAUSED);
			}
		} else {
			OSAdmin::alert("error",ErrorMessage::USER_OR_PWD_WRONG);
			// SysLog::addLog ( $user_name, 'LOGIN','User' ,'' , json_encode(ErrorMessage::USER_OR_PWD_WRONG) );
		}
	}
}

$_POST['user_name'] ='admin';
$_POST['password'] ='0000';

Template::assign ( '_POST',$_POST );
Template::assign ( 'page_title','登入' );
Template::Display ( 'login.tpl' );

?>