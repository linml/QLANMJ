<?php

require ('../include/init.inc.php');
require ('../WxpayAPI_php_v3/example/WxPay.JsApiPay.php');

$real_name = $mobile = '';
extract( $_POST, EXTR_IF_EXISTS );
//微信登陆进来都作为后台的群主用户组 3 也就是代理商
$user_group = 3;	
$remember = true;

//请求申请
if (Common::isPost()) {
	
	//判断身份参数
	if (empty($_SESSION["unionid"]) || empty($_SESSION["playerid"])) {
		OSAdmin::alert("error", "请求错误" );
		Template::Display ( 'registerwx.tpl' );
		exit();
	}

	//判断提交的联系人信息参数
	if(empty($real_name) || empty($mobile)) {
		OSAdmin::alert ( "error", ErrorMessage::NEED_PARAM );
		Template::Display ( 'registerwx.tpl' );
		exit();
	}

	$input_data = array (
		'user_name' => $_SESSION["playerid"],
		'password'  => md5( $_SESSION["playerid"].'8866' ),
		'real_name' => $real_name,
		'mobile'    => $mobile,
		'email'     => "",
		'user_desc' => "微信端创建",
		'user_group'=> $user_group,
		'unionid'   => $_SESSION["unionid"]
	);
	$user_id = User::addUser( $input_data );

	if(!$user_id){
		echo '<h3>创建用户失败：'.$_SESSION["playerid"].'，请联系管理员处理。</h3>';
		exit();
	}
	$_SESSION["osauserid"] = $user_id;


	//查找是否已经是代理
	$exist_agent = Agent::getAgentByAgentuid ( $_SESSION["playerid"]);
	if (!$exist_agent) {
		//如果还不是代理，添加代理
		$input_agent_data = array (
			'agent_uid'    => $_SESSION["playerid"],
			'osa_user_id'  => $user_id,
			'agent_status' => 0,
			'unionid'      => $_SESSION["unionid"],
			'create_time'  => date ( "Y-m-d H:i:s" ) 
		);
		Agent::addAgent( $input_agent_data );
	}
	doLogin($user_id, $_SESSION["playerid"]);
	exit();
}

$tools = new JsApiPay ();
$UnionID = $tools->GetUnionID();

if (empty($UnionID)) {
	echo '<h1>微信授权失败</h1>';
	exit();
}

//判断该微信是否已经登录游戏
$player = GamePlayer::getPlayerByUnionId($UnionID);
if($player && $player['userid']){
	$playerId = $player['userid'];
}else{
	//跳转到游戏下载界面
	echo '<h1>您还没有登录过游戏，请先登录游戏再访问微信后台。<br><a href="/sharedownload">点击此处进入下载页面</a><h1>';
	exit();
}

//保存session
$_SESSION["unionid"] = $UnionID;
$_SESSION["playerid"] = $playerId;

//查询是否已经有后台账号
$user = Loginwx::getUserBy_unionid( $UnionID );
if (!$user) {
	//如果还没有用户账号，则跳转补充联系方式页面，等提交后一并简历账号
	Template::assign('page_title', '代理商申请');
	Template::Display('registerwx.tpl');

} else {
	//登录后台
	if($user['status'] == 1){
		doLogin($user['user_id'], $playerId);
	}else{
		echo '<h1>您的账户已经被暂停，请联系管理员处理。</h1>';
		exit ();
	}
}

//身份验证成功后，登录处理
function doLogin($userId, $playerId){
	//初始化功能展示及保存相关数据至session
	User::loginDoSomething($userId);

	//保存cookie相关信息 未验证
	if ($remember) {
		$encrypted = OSAEncrypt::encrypt( $userId );
		User::setCookieRemember( urlencode ( $encrypted ), 30 );
	}

	$ip = Common::getIp();
	SysLog::addLog($playerId, 'LOGIN', 'User', $userId, json_encode(array("IP" => $ip)));

	$agentUid = UserSession::getAgentUid();
	if (!empty($agentUid)) {
		Common::jumpUrl('agentcenter/summary.php');
	} 
	else {
		echo '<h1>非代理身份无法进入代理后台，请联系管理员：'.$userId.'</h1>';
		exit();
	}
}

?>