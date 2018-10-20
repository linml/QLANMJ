<?php
require ('../include/init.inc.php');
require_once "ApiConfig.php";
// require('../payInterfacegzzh/GzzhRequest.php');
$result = array (
		'status' => 0,
		'msg' => '' 
);
$uri = HttpRequest::parse_request_uri ();
$iplist = array ();

if (!empty( $iplist )) {
	$ip = $_SERVER["REMOTE_ADDR"];
	
	if (! in_array ( $ip, $iplist )) {
		echo $ip;
		exit ();
	}
}
if (!function_exists( $uri )) {
	$result['status'] = 0;
	$result['msg'] = '请求连接不存在';
	echo json_encode ( $result );
	exit ();
}
// var_dump ( $uri );

if (strtolower ( $uri ) == 'invitecode') {
	$uid = $code = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
		"uid" => $uid,
		'code' => $code 
	) );
} elseif (strtolower ( $uri ) == 'existinvite') {
	$uid = $code = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
			"uid" => $uid,
			'code' => $code 
	) );
} elseif (strtolower ( $uri ) == 'getversoin') {
	$version = $type = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
			"version" => $version,
			'type' => $type 
	) );
} elseif (strtolower ( $uri ) == 'unifiedorder') {
	$uid = "";
	$payment = "";
	$price = "";
	$number = "";
	$payment_way = "";
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
			"uid" => $uid,
			"payment" => $payment,
			"price" => $price,
			"number" => $number,
			"payment_way" => $payment_way 
	) );
} elseif (strtolower ( $uri ) == 'calculateorder') {
	$out_trade_no = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
			"out_trade_no" => $out_trade_no 
	) );
} elseif (strtolower ( $uri ) == 'checkorderstate') { // 查询订单状态
	$out_trade_no = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
			"out_trade_no" => $out_trade_no 
	) );
} elseif (strtolower ( $uri ) == 'iospayswitch') {
	$res = call_user_func ( $uri, array () );
} elseif (strtolower ( $uri ) == 'loglogin') {
	$uid = '';
	$account = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
		"uid" => $uid,
		"account" => $account 
	) );
} elseif (strtolower ( $uri ) == 'sharegems') {
	$uid = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	
	$res = call_user_func ( $uri, array (
			"uid" => $uid 
	) );
} elseif (strtolower ( $uri ) == 'gettuserbyuid') {
	$uid = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	
	$res = call_user_func ( $uri, array (
			"uid" => $uid 
	) );
} elseif (strtolower ( $uri ) == 'sellgems') {
	$uid = '';
	$toplayerid = '';
	$gemsnumber = '';
	$account = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	
	$res = call_user_func ( $uri, array (
			"uid" => $uid,
			"toplayerid" => $toplayerid,
			"gemsnumber" => $gemsnumber,
			"account" => $account
	) );
} elseif (strtolower ( $uri ) == 'test') {
	call_user_func ( $uri);
} elseif (strtolower ( $uri ) == 'existagent') {
	$uid= '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
			"uid" => $uid
		
	) );
} elseif ($uri == 'onOrderComplete') {

	$out_trade_no = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$ret = Order::onOrderComplete_byJS($out_trade_no);

	$result['status'] = 0;
	$result['msg'] = $ret;
	echo json_encode($result);
	exit();

} else {
	$result['status'] = 0;
	$result['msg'] = '请求连接不存在';
	echo json_encode ( $result );
	exit ();
}
/**
 * 获取订单状态
 */
function checkorderstate($args) {
	if (empty ( $args ) || empty ( $args['out_trade_no'] )) {
		$result['status'] = 0;
		$result['msg'] = '订单编号不能为空';
	} else {
		try {
			$postoid = $args['out_trade_no'];
			$order = Order::getOrder_byOutTradeNo ( $postoid );
			if ($order) {
				$result['status'] = 1;
				$result['ostatus'] = $order['status'];
			} else {
				$result['status'] = 0;
				$result['ostatus'] = - 2;
				$result['msg'] = '订单不存在';
			}
			echo json_encode ( $result );
			exit ();
		} catch ( Exception $e ) {
			$result['status'] = 0;
			$result['ostatus'] = - 1;
			$result['msg'] = '请求异常';
			echo json_encode ( $data );
			exit ();
		}
	}
	echo json_encode ( $result );
}

/**
 * 获取ios开关
 *
 * @param unknown $args        	
 */
function iospayswitch($args) {
	try {
		$result = array (
				'status' => '',
				'message' => '' 
		);
		$config = Notice::getiospayswitch ();
		$result['status'] = 'OK';
		$result['message'] = '成功';
		$result['data'] = $config;
		echo json_encode ( $result );
	} catch ( Exception $e ) {
		$result = array (
				'status' => '',
				'message' => '' 
		);
		$result['status'] = 'fail';
		$result['message'] = $e->getMessage ();
	}
}
/**
 * 下订单
 */
function unifiedorder($args) {
	if (empty ( $args ) || empty ( $args['uid'] )) {
		$result['status'] = 0;
		$result['msg'] = 'uid不能为空';
	}
	if (empty ( $args ) || empty ( $args['out_trade_no'] )) {
		$result['status'] = 0;
		$result['msg'] = 'uid不能为空';
	} elseif (empty ( $args ) || empty ( $args['payment'] )) {
		$result['status'] = 0;
		$result['msg'] = 'payment不能为空';
	} elseif (empty ( $args ) || empty ( $args['price'] )) {
		$result['status'] = 0;
		$result['msg'] = 'price不能为空';
	} elseif (empty ( $args ) || empty ( $args['number'] )) {
		$result['status'] = 0;
		$result['msg'] = 'number不能为空';
	} elseif (empty ( $args ) || empty ( $args['payment_way'] )) {
		$result['status'] = 0;
		$result['msg'] = 'payment_way不能为空';
	} else {
		// begin 生产自定义订单数据，保存数据库
		$transaction_id = $args['out_trade_no'];
		$uid = $args['uid'];
		$payment = $args['payment'];
		$price = $args['price'];
		$number = $args['number'];
		$payment_way = $args['payment_way'];
		$input_data = array (
				'transaction_id' => $transaction_id,
				'uid' => $uid,
				'payment' => $payment,
				'price' => $price,
				'number' => $number,
				'status' => 0,
				'payment_way' => $payment_way,
				'proportion_status' => 0 
		);
		$oid = Order::addOrder ( $input_data );
		$result['status'] = 1;
		$result['msg'] = '下单成功';
		$result['out_trade_no'] = $transaction_id;
	}
	
	echo json_encode ( $result );
}
/**
 * 是否存在绑定
 *
 * @param unknown $args        	
 */
function existinvite($args) {
	if (empty ( $args ) || empty ( $args['uid'] )) {
		$result['status'] = 0;
		$result['msg'] = 'UID不能为空';
	} else {
		$ExistInvite = Agent::ExistInvite ( $args['uid'] );
		if ($ExistInvite && $ExistInvite['parent_uid'] != 0) {
			$result['status'] = 0;
			$result['msg'] = '绑定关系已存在！';
		} else {
			$result['status'] = 1;
			$result['msg'] = '未绑定！';
		}
	}
	echo json_encode ( $result );
}

//绑定邀请码
function invitecode($args) {
	$result['status'] = 1;
	
	if (empty ( $args ) || empty ( $args['uid'] ) || empty ( $args['code'] )) {
		$result['status'] = 0;
		$result['msg'] = 'UID或邀请码不能为空';
	} else if ($args['uid'] == $args['code']) {
		$result['status'] = 0;
		$result['msg'] = '邀请码错误！';
	} else if (! is_numeric ( $args['code'] )) {
		$result['status'] = 0;
		$result['msg'] = '邀请码不存在！';
	}
	if ($result['status'] == 0) {
		echo json_encode ( $result );
		return;
	}
	
	$user = Sell::getTuserByUid ( $args['uid'] );
	$code = Agent::getAgentByAgentuid ( $args['code'] );
	if (!$user) {
		$result['status'] = 0;
		$result['msg'] = '玩家UID不存在';
	} else if (!$code || $code['agent_status'] != 1) {
		$result['status'] = 0;
		$result['msg'] = '邀请码无效';
	}
	if ($result['status'] == 0) {
		echo json_encode($result);
		return;
	}
	
	//STools::log("invitecode uid".$args['uid'].":\n");
	//STools::log(Agent::ExistInvite($args['uid']));
	$ret = ApiDll::onBindAgent(array (
		"userId" => $args['uid'],
		"code" => $args['code'],
	));

	if($ret !== "success"){
		$result['status'] = 0;
		$result['msg'] = $ret;
	}

	echo json_encode($result);
}

//登录记录
function loglogin($args) {
	if (empty($args) || (empty($args['uid']) && empty($args['account']))) {
		$result['status'] = 0;
		$result['msg'] = 'uid 或 account 参数不能为空';

	} else {
		if (!empty($args['uid'])) $user = Sell::getTuserByUid ( $args['uid'] );
		else if(!empty($args['account'])) $user = Sell::getTuserByaccount ( $args['account'] );

		if (!$user) {
			$result['status'] = 0;
			$result['msg'] = '未找到此玩家';

		} else {
			if ($user['is_invitecode'] == 0) {
				// 老用户没有有绑定
				$ExistInvite = Agent::ExistInvite($user['userid']);
				if (!$ExistInvite) {
					$invite_data = array (
						'uid' => $user['userid'],
						'parent_uid' => 0,
						'agent_line_uid' => 0,
						'area_agent_uid' => 0 
					);
					$row = Agent::Invitecode($invite_data);
				}
				$data2 = array (
					'is_invitecode' => 1 
				);
				User::update_T_User( $user['userid'], $data2 );
			}
			
			$data = array (
					'userid' => $user['userid'],
					'last_login_time' => date ( "Y-m-d H:i:s" ),
					'register_time' => $user['create_time'],
					'version' => $args['version'],
					'client' => $args['client'] 
			);
			$row = Agent::logLogin( $data );
			
			$data2 = array (
				'last_login_time' => date("Y-m-d H:i:s")
				//'version' => $args['version'],
				//'client' => $args['client'] 
			);
			
			User::update_T_User ( $user['userid'], $data2 );
			
			if ($row > 0) {
				$result['status'] = 1;
				$result['msg'] = '记录成功';
			} else {
				$result['status'] = 0;
				$result['msg'] = '记录失败';
			}

			ApiActivityDll::activity ( $user );
		}
	}
	
	echo json_encode ( $result );
}

/**
 * 分享获房卡
 */
function sharegems($args) {
	if (empty ( $args ) || empty ( $args['uid'] )) {
		$result['status'] = 0;
		$result['msg'] = '玩家ID不能为空';
	} else {
		$user = Sell::getTuserByUid ( $args['uid'] );
		if (! $user) {
			$result['status'] = 0;
			$result['msg'] = '玩家ID不存在';
		} else {
			$row = Share::GetShare ( $args['uid'], date ( "Y-m-d" ) );
			if ($row) {
				$result['status'] = 0;
				$result['msg'] = '已分享';
			} else {
				$gems = ApiConfig::share_send_gems;
				//暂时关闭分享送钻
				$input_data = array (
						'uid' => $args['uid'],
						'gems' => $gems,
						'after_the_gems' => $gems + $user['gems'],
						'type' => "shareadd" 
				);
				Gems::addGemsRecord ( $input_data );
				$update_data = array (
						'gems' => $gems + $user['gems'] 
				);
				Gems::updateTuserGems ( $args['uid'], $update_data );

				$data = array (
						'uid' => $args['uid'],
						'gems' => $gems,
						'after_the_gems' => $gems + $user['gems'],
						'create_time' => date ( "Y-m-d" ) 
				);
				Share::add_Share_log ( $data );
				$result['status'] = 1;
				$result['msg'] = "恭喜获分享福利：" . $gems . "钻石";
				// $result['msg'] = "分享成功";
			}
		}
	}
	echo json_encode ( $result );
}

/**
 * 转卡前获取用户
 *
 * @param unknown $args        	
 */
function gettuserbyuid($args) {
	if (empty ( $args ) || empty ( $args['uid'] )) {
		$result['status'] = 0;
		$result['msg'] = 'uid  参数不能为空';
	} else {
		$user = Sell::getTuserByUid ( $args['uid'] );
		
		if ($user) {
			$result['status'] = 1;
			$result['msg'] = '';
			$result['data'] = array(
				'name' => base64_decode ( $user['name'] ),
				'userid' => $user['userid'],
				'gems' => $user['gems'],
				);
		} else {
			$result['status'] = 0;
			$result['msg'] = '用户不存在';
		}
	}
	
	echo json_encode ( $result );
}

//转钻
function sellgems($args) {
	$result['status'] = 1;

	if(empty($args)){
		$result['status'] = 0;
		$result['msg'] = '参数不能为空';

	} else if (empty($args['account']) ) {
		$result['status'] = 0;
		$result['msg'] = '账号不能为空';

	} else if (empty ($args['gemsnumber']) || !is_numeric($args['gemsnumber']) || $args['gemsnumber'] <= 0) {
		$result['status'] = 0;
		$result['msg'] = '钻石数量不合法';

	} else if (empty($args['uid']) || !is_numeric( $args['uid'] )) {
		$result['status'] = 0;
		$result['msg'] = 'ID不合法';
		
	} else if (empty ( $args['toplayerid']) || !is_numeric ( $args['toplayerid'] )) {
		$result['status'] = 0;
		$result['msg'] = '目标ID不合法';

	} else if ($args['uid'] == $args['toplayerid']){
		$result['status'] = 0;
		$result['msg'] = '不可以转给自己';

	} else {
		$user = Sell::getTuserByaccount($args['account']);
		$target = Sell::getTuserByUid($args['toplayerid']);
		if($user && $target){
			$uid = $user['userid'];
			//echo("<script>alert('is array:".$uid."');</script>");
			$isAgent = Agent::getAgentByAgentuid($uid);
			$toplayerid = $args['toplayerid'];
			if (!$isAgent || $isAgent['givegems'] == 0 || $isAgent['agent_status'] != 1) {
				$result['status'] = 0;
				$result['msg'] = '没有赠送权限';
			} else {
				$gemsnumber = $args['gemsnumber'];

				if ($user['gems'] < $gemsnumber) {
					$result['status'] = 0;
					$result['msg'] = "钻石数量不可以大于自己的剩余数";
				}
			}
		}else{
			$result['status'] = 0;
			if(!$target){
				$result['msg'] = '未找到赠送目标玩家';
			}else{
				$result['msg'] = '未找到赠送者';
			}
		}
	}

	if($result['status'] == 0) {
		echo json_encode ( $result );
		exit ();
	}
	//echo("<script>alert('uid::".$uid."');</script>");
	//echo("<script>alert('toplayerid::".$toplayerid."');</script>");
	//echo("<script>alert('gemsnumber::".$gemsnumber."');</script>");
	Sell::SellGems( $uid, $toplayerid, $gemsnumber );
	Sell::SellGemsRecord( $uid,        0, $toplayerid, $gemsnumber,   $user['gems'] - $gemsnumber, 'subtract' );
	Sell::SellGemsRecord( $toplayerid, 0,        $uid, $gemsnumber, $target['gems'] + $gemsnumber,      'add' );

	$result['status'] = 1;
	$result['msg'] = "转卡成功";
	echo json_encode( $result );
}

function getversoin($args) {
	// SysLog::addLog ( "强更", '获取参数', 'getversoin' ,'计算参数', json_encode($args) );
	if (empty ( $args ) || empty ( $args['version'] )) {
		$result['status'] = 0;
		$result['msg'] = '版本号不能为空';
	} elseif (empty ( $args ) || empty ( $args['type'] )) {
		$result['status'] = 0;
		$result['msg'] = '类型不能为空';
	} else {
		
		$version = StrongUpdate::getModuleByName ( $args['version'] );
		
		if ($version) {
			if (($args['type'] == 'ios') && $version['ios'] == 1) {
				$result['status'] = 1;
				$result['msg'] = '强更';
				$result['data']['url'] = $version['ios_url'];
			} elseif (strtolower ( $args['type'] ) == 'android' && $version['android'] == 1) {
				$result['status'] = 1;
				$result['msg'] = '强更';
				$result['data']['url'] = $version['android_url'];
			} else {
				
				$result['status'] = 0;
				$result['msg'] = '不强更';
			}
		} else {
			$result['status'] = 0;
			$result['msg'] = '不强更';
		}
	}
	
	echo json_encode ( $result );
}
/**
 * 代理商可以转钻石，看到商城
 * 开通转钻石权限，才可以到看到商城，转钻
 * @param unknown $args
 */
function existagent($args) {
	if (empty ( $args ) || empty ( $args['uid'] )) {
		$result['status'] = 0;
		$result['msg'] = 'UID不能为空';
	} else {
		$ExistInvite = Agent::getAgentByAgentuid( $args['uid'] );
		if ($ExistInvite && $ExistInvite['givegems'] == 1 ) {
			$result['status'] = 1;
			$result['msg'] = '是代理！';
		} else {
			$result['status'] = 0;
			$result['msg'] = '不是代理！';
		}
	}
	echo json_encode ( $result );
}

function onOrderComplete(){}

function test() {
	$exist_order = Order::getOrder_byOutTradeNo ( "8866201706301823597888644" );
	Proportion::calculateProportion($exist_order);
}
