<?php 
require ('../include/init.inc.php');
$prepsw = $newpsw = $confirmpsw = '';
extract($_REQUEST,EXTR_IF_EXISTS);
$agentid = UserSession::getAgentId();
if(Common::isPost()){
	if(UpdatePassword::checkpsw($agentid,$prepsw)){
		if($prepsw!=$newpsw){
			$result = UpdatePassword::updatepsw($agentid,$newpsw);
			if($result){
				echo '<script>alert("密码修改成功！")</script>';
				$_SESSION['session_agent'] = null;
				header("Location: /agentLogin.php");
				exit();
			}else{
				echo '<script>alert("密码修改失败！")</script>';
			}
		}else{
			echo '<script>alert("设置密码与旧密码相同！")</script>';
		}
	}else{
		echo '<script>alert("密码验证失败！")</script>';
	}
}
Template::display ('agentcenter/toUpdatePassword.tpl');