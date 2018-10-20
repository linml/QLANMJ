<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class ApiDll extends Base {
	/**
	 * 获取用户扫描代理 或 普通用户
	 * @param unknown $unionid
	 * @param unknown $sweep_agent
	 * @return mixed
	*/
	public  static function getInvitecode_pre_by_unionid_and_sweep_agent($unionid,$sweep_agent)
	{
		$db = self::__instance ();
		$sql = "select *  from osa_t_invitecode_pre  where unionid='$unionid' and sweep_agent=$sweep_agent";
		//var_dump($sql);
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	/**
	 * ApiDll获取绑定前数据
	 * @param unknown $unionid
	 * @return mixed
	 */
	public  static function getInvitecode_pre_by_unionid_and_uid($unionid,$uid)
	{
		$db = self::__instance ();
		$sql = "select * from osa_t_invitecode_pre  where unionid='$unionid' and uid=$uid";
		//var_dump($sql);
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	/**
	 * 根据uid 获取代理信息
	 * @param unknown $Uid
	 * @return mixed
	 */
	public static function getAgentByUid($Uid) {
		$db = self::__instance ();
		$sql = "select *  from osa_t_agent  where agent_uid=$Uid";
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	/**
	 * 用户是否登录过
	 * @param unknown $uid
	 * @return mixed
	 */
    public  static function getLogin($uid)
	{
		$db = self::__instance ();
		$sql = "select *  from osa_t_log_login  where userid=$uid";
		//var_dump($sql);
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	
	/**
	 * ApiDll保存玩家二维
	 * @param unknown $group_data
	 * @return boolean|string
	 */
	public static function addInvitecode_pre( $input_data) {
		if (! $input_data || ! is_array ( $input_data )) {
			return false;
		}
		$db = self::__instance ();
		$id = $db->insert ( 'osa_t_invitecode_pre', $input_data );
		return $id;
	}
	/**
	 * ApiDll获取绑定前数据
	 * @param unknown $unionid
	 * @return mixed
	 */
	public  static function getInvitecode_pre($unionid)
	{
		$db = self::__instance ();
		$sql = "select * from osa_t_invitecode_pre where unionid='$unionid'";
		//var_dump($sql);
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	
	public static function getTuserByunionid($UnionID) {
		$db = self::__instance ();
		$sql = "select *  from t_users  where unionid='$UnionID'";
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	/**
	 * ApiDll根据玩家id获取玩家
	 */
	public static function getTuserByUid($Uid) {
		$db = self::__instance ();
		$sql = "select *  from t_users  where userid=$Uid";
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	/**
	 * ApiDll根据玩家id获取玩家二维码
	 */
	public static function getTuserQrcodeByUid($Uid) {
		$db = self::__instance ();
		$sql = "select *  from osa_t_user_qrcode  where uid=$Uid";
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	/**
	 * ApiDll保存玩家二维
	 * @param unknown $group_data
	 * @return boolean|string
	 */
	public static function addUserQrcode( $input_data) {
		if (! $input_data || ! is_array ( $input_data )) {
			return false;
		}
		$db = self::__instance ();
		$id = $db->insert ( 'osa_t_user_qrcode', $input_data );
		return $id;
	}
	
	//绑定代理事件
	public static function onBindAgent($args){
		$userId = $args["userId"];
		$code = $args["code"];
		$area_agent_uid = 0;

		$ExistInvite = Agent::ExistInvite($userId);
		$ExistCodeInvite = Agent::ExistInvite($code);

		//绑定关系已存在
		//在什么情况下存在绑定信息但上级id是0? ————玩家自行下载游戏时
		if ($ExistInvite && $ExistInvite['parent_uid'] != 0) {
			return "hasbeenBind";
		//不能绑定下级玩家
		} else if ($ExistCodeInvite && $ExistCodeInvite['parent_uid'] == $userId) {
			return "bindFail";
		}

		//STools::log("into onBindAgent");

		//没有绑定 预绑定
		if (!$ExistInvite) {
			$invite_data = array (
				'uid' =>  $user['userid'],
				'parent_uid' => 0,
				'agent_line_uid' => 0,
				'area_agent_uid' => 0
			);
			$row = Agent::Invitecode ( $invite_data );
		}

		//设置用户为已绑定上级
		$data2 = array (
			'is_invitecode' => 1
		);
		User::update_T_User($user['userid'], $data2 );
		
		//如果上级为区域代理或上级绑定了区域代理
		$agent = Agent::getAgentByAgentuid ($code);
		if ($agent && $agent['agent_type'] == 1) {
			$area_agent_uid = $code;
		} else {
			if ($ExistCodeInvite) {
				$area_agent_uid = $ExistCodeInvite['area_agent_uid'];
			}
		}

		//更新绑定数据
		$invite_data = array (
			'parent_uid' => $code,
			'agent_line_uid' => $code,
			'area_agent_uid' => $area_agent_uid 
		);
		$row = Agent::update_Invitecode ( $userId, $invite_data );

		//更新所有绑定自己的用户的区域代理属性
		Agent::recursive($area_agent_uid, $userId, 1);
		
		//赠送上级玩家钻石
		{
			$user2 = Sell::getTuserByUid($code);
			$gems = ApiConfig::sweep_not_invite_send_gems;
			//记录
			$input_data2 = array (
				'uid' => $code,
				'gems' => $gems,
				'after_the_gems' => $gems + $user2['gems'],
				'type' => "bySweepadd"
			);
			Gems::addGemsRecord ( $input_data2 );
			//赠送
			GameUser::addGems($code, $gems, "ADD_CHILD");
			/*$update_data2 = array (
				'gems' => $gems + $user2['gems']
			);
			Gems::updateTuserGems ( $code, $update_data2 );*/
		}

		//赠送玩家钻石
		{
			$gems = ApiConfig::invite_agent_send_gems;
			$user = GameUser::getUser($userId);
			//记录
			$input_data = array (
				'uid' => $userId,
				'type' => 'sweepAgentAdd',
				'gems' => $gems,
				'after_the_gems' => $gems + $user['gems']
			);
			Gems::addGemsRecord ( $input_data );
			//赠送
			GameUser::addGems($userId, $gems, "BIND_AGENT");
			/*$update_data = array (
				'gems' => $gems + $user['gems'] 
			);
			Gems::updateTuserGems( $userId, $update_data );*/
		}

		return "success";
	}

	//被普通用户邀请事件
	public static function onBindCommonUserInvite($args){
		$userId = $args["userId"];
		$code = $args["code"];

		//为邀请者送钻
		{
			$inviter = Sell::getTuserByUid($code);
			$gems = ApiConfig::sweep_not_invite_send_gems;
			//记录
			$recordData = array (
				'uid' => $code,
				'gems' => $gems,
				'after_the_gems' => $gems + $inviter['gems'],
				'type' => "bySweepadd" 
			);
			Gems::addGemsRecord($recordData);

			//增加
			$updateData = array (
				'gems' => $gems + $inviter['gems'] 
			);
			Gems::updateTuserGems($code, $updateData);
		}

		//为玩家送钻
		{
			$user = Sell::getTuserByUid($userId);
			$gems = ApiConfig::sweep_not_invite_send_gems;
			//记录
			$recordData = array (
				'uid' => $userId,
				'gems' => $gems,
				'after_the_gems' => $gems + $user['gems'],
				'type' => "bySweepadd"
			);
			Gems::addGemsRecord( $input_data );
			//增加
			$updateData = array (
				'gems' => $gems + $user['gems'] 
			);
			Gems::updateTuserGems($userId, $update_data);
		}
	}
}