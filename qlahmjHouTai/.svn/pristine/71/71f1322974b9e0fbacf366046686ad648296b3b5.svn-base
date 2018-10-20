<?php
require ('../include/init.inc.php');
$user_name = $playerid = $password = $confirmpassword =$real_name=$mobile= $email = $user_desc= $remember = $verify_code = '';
$user_group=3;
extract ( $_POST, EXTR_IF_EXISTS );

if (Common::isPost ()) {
	$exist = User::getUserByName($user_name);
	$exist_agent = Agent::getAgentByAgentuid($playerid);
	$exist_Tusers = Agent::getTusersByUid($playerid);
	if($password!=$confirmpassword && isset($password))
	{	echo("<script>alert('1');</script>");
		OSAdmin::alert("error",ErrorMessage::Confirm_Password_Mistake);
	}
	elseif(strtolower($verify_code) != strtolower($_SESSION['osa_verify_code'])){
		echo("<script>alert('2');</script>");
		OSAdmin::alert("error",ErrorMessage::VERIFY_CODE_WRONG);
	}
	elseif($exist){
		echo("<script>alert('3');</script>");
		OSAdmin::alert("error",ErrorMessage::NAME_CONFLICT);
	}elseif($exist_agent)
	{	echo("<script>alert('4');</script>");
		OSAdmin::alert("error",ErrorMessage::AGENT_UID_CONFLICT);
	}
	elseif (!$exist_Tusers)
	{	echo("<script>alert('5');</script>");
		OSAdmin::alert("error",ErrorMessage::TUSER_NOT_EXIST);
	}
	else if($password=="" || $real_name=="" || $mobile =="" ||  $user_group <= 0 ){
		echo("<script>alert('6');</script>");
		OSAdmin::alert("error",ErrorMessage::NEED_PARAM);
	}else{
		echo("<script>alert('7');</script>");

		$input_data = array ('user_name' => $user_name, 'password' => md5 ( $password ), 'real_name' => $real_name, 'mobile' => $mobile, 'email' => $email, 'user_desc' => $user_desc, 'user_group' => $user_group );
		$user_id = User::addUser ( $input_data );
		echo("<script>alert('playerid:".$playerid."');</script>");
		$input_agent_data = array ('agent_uid' => $playerid,'osa_user_id'=>$user_id,'agent_status'=>0,'create_time'=>date("Y-m-d H:i:s"));
		Agent::addAgent($input_agent_data);
		echo("<script>console.log('input_agent_data:".$input_agent_data."');</script>");
		//exit();
		if ($user_id) {
			//登录
			$user_info = User::checkPassword ( $user_name, $password );
			if ($user_info) {
				if($user_info['status']==1){
					//setSession
					User::loginDoSomething($user_info['user_id']);
					if($remember){
						$encrypted = OSAEncrypt::encrypt($user_info['user_id']);
						User::setCookieRemember(urlencode($encrypted),30);
					}
					$ip = Common::getIp();
					SysLog::addLog ( $user_name, 'LOGIN', 'User' ,UserSession::getUserId(),json_encode(array("IP" => $ip)));
					Common::jumpUrl ( 'panel/index.php' );
				}else{
					OSAdmin::alert("error",ErrorMessage::BE_PAUSED);
				}
			} else {
				OSAdmin::alert("error",ErrorMessage::USER_OR_PWD_WRONG);
				SysLog::addLog ( $user_name, 'LOGIN','User' ,'' , json_encode(ErrorMessage::USER_OR_PWD_WRONG) );
			}
		}else{
			OSAdmin::alert("error");
		}
	}
}

Template::assign ( '_POST',$_POST );
Template::assign ( 'page_title','注册' );
Template::Display ( 'register.tpl' );