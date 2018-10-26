<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class GamePlayer extends Base {
	// 表名
	private static $user_info = 'user_info';
	private static $user_account = 'user_account';
	private static $agent_info = 'agent_info';
	private static $user_stat = 'user_stat';

	/**
	 * [getWhere 获取条件]
	 * @Author   李龙
	 * @DateTime 2018-09-03T16:35:32+0800
	 * @param    string                   $s_type   [description]
	 * @param    string                   $contains [description]
	 * @return   [type]                             [description]
	 */
	public static function getWhere($s_type='',$contains=''){
		if(empty($s_type)||empty($contains)) return ;
		switch ($s_type) {
			case '1':
				$s_type = " and ui.nickname like '%$contains%' ";
				break;
			case '2':
				$s_type = " and ui.userid = '$contains'";
				break;
			case '3':
				$contains = parent::getAUInfo('userid',$contains);
				$s_type = " and ui.agentid = '".$contains['Magentid']."'";
				break;
			case '4':
				$s_type = " and b.nickname like '%$contains%' ";
				break;
			default:
				break;
		}
		$where = " where 1=1 ".$s_type;
		return $where;
	}

	/**
	 * [getAllUsers 获取玩家表数据]
	 * @Author   李龙
	 * @DateTime 2018-08-24T15:24:59+0800
	 * @return   [type]                   [返回结果集]
	 */
	public static function getAllUsers($start='',$page_size,$where){
		if($page_size) $limit = " limit $start,$page_size";else return;
		$db    = self::__instance();
		$sql   = 'SELECT
					ui.userid,
					ui.nickname,
					ui.isname,
					ua.diamond,
					ua.gold,
					ua.qidou,
					ua.grift,
					ui.viplevel,
					ui.status,
					ui.addtime,
					ui.agentid,
					b.userid as buserid,
					b.nickname as bnickname,
					ai.agentname,
					(select sum(op.rmb) from order_pay op where op.auid = ui.userid AND op.userflag = "U" AND op.accounttype = "VD" group by op.auid) as sumrmb
				FROM
					user_info ui
				LEFT JOIN user_account ua ON ui.userid = ua.userid
				LEFT JOIN agent_info ai ON ai.agentid = ui.agentid
				LEFT JOIN user_info b ON ai.userid = b.userid '.$where.' order by ui.addtime desc '.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getCountUsers 查询玩家表条目数]
	 * @Author   李龙
	 * @DateTime 2018-08-24T15:29:58+0800
	 * @return   [type]                   [返回玩家表条目数]
	 */
	public static function getCountUsers($where){
		$db = self::__instance();
		$sql = 'SELECT
					count(ui.userid)
				FROM
					user_info ui
				LEFT JOIN user_account ua ON ui.userid = ua.userid
				LEFT JOIN agent_info ai ON ai.agentid = ui.agentid
				LEFT JOIN user_info b ON ai.userid = b.userid '.$where;
		$result = $db->query($sql)->fetchColumn();
		return 0 + $result;
	}
	/**
	 * [getUserById 根据玩家id查询特定玩家信息]
	 * @Author   李龙
	 * @DateTime 2018-08-24T17:54:31+0800
	 * @param    [type]                   $userid [玩家id]
	 * @return   [type]                           [特定玩家信息]
	 */
	public static function getUserById($userid=''){
		if(empty($userid)) return ;
		$db = self::__instance();
		$sql = 'select ui.userid,ui.nickname,ua.diamond from '.self::$user_info.' ui left join '.self::$user_account.' ua on ui.userid = ua.userid where ui.userid = '.$userid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * fixme
	 * [addGemsForUser 为玩家增加钻石]
	 * @Author   李龙
	 * @DateTime 2018-08-24T18:11:25+0800
	 * @param    string                   $userid [玩家id]
	 * @return   [int]                           [是否成功]
	 */
	public static function SendDiamond($userid='',$diamond='',$money='',$type='',$remark=''){
		$adminid = UserSession::getUserId();
		if(empty($userid)) return ;
		$db = self::__instance();
		$produce = "call sp_admin_user_transfer(".$adminid.",".$userid.",".$diamond.",".$money.",".$type.",'".$remark."',@p_out)";
		$db->exec($produce);
		return $db->query('select @p_out')->fetch(PDO::FETCH_ASSOC)['@p_out'];
	}

	/**
	 * [showInfo 根据userid查询用户信息]
	 * @Author   李龙
	 * @DateTime 2018-08-25T10:40:22+0800
	 * @param    string                   $userid [玩家userid]
	 * @return   [type]                           [返回玩家信息]
	 */
	public static function showInfo($userid=''){
		if(empty($userid)) return ;
		$db = self::__instance();
		$sql = 'SELECT
					ui.picfile,
					ui.userid,
					ui.nickname,
					ui.addtime,
					ui.refereeid,
					ui.logintime,
					IFNULL(us.roomcnt, 0) AS roomcnt,
					ui.status,
					ui.realname,
					ui.idcard,
					(
						SELECT
							nickname
						FROM
							'.self::$user_info.' 
						where userid = ui.refereeid
					) AS refereename
				FROM
					'.self::$user_info.' ui
				LEFT JOIN '.self::$user_stat.' us ON ui.userid = us.userid
				WHERE
					ui.userid = '.$userid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [updateUserStatus 根据玩家Id更改玩家状态]
	 * @Author   李龙
	 * @DateTime 2018-08-25T15:03:46+0800
	 * @param    string                   $userid [玩家id]
	 * @param    string                   $status [状态]
	 * @return   [type]                           [返回成功与否]
	 */
	public static function updateUserStatus($userid='',$status=''){
		if(empty($userid)||empty($status)) return ;
		$db = self::__instance();
		$update = 'update '.self::$user_info.' set status = '.($status-1).' where userid = '.$userid;
		// $set = ["status" => $status];
		// $where = ["userid" => $userid];
		// $result = $db->update(self::$user_info,$set,$where);
		$result = $db->exec($update);
		return 0 + $result;
	}

	/**
	 * [changeParentAgent 修改玩家的绑定关系]
	 * @Author   李龙
	 * @DateTime 2018-08-25T16:07:48+0800
	 * @param    string                   $userid  [玩家id]
	 * @param    string                   $agentid [代理id]
	 * @return   [type]                            [返回执行结果]
	 */
	public static function changeParentAgent($userid='',$agentid=''){
		if(empty($userid)||empty($agentid)) return;
		if($agentid == 1) $agentid = 0;
		$db = self::__instance();
		$produce = 'call sp_user_bind_change('.$userid.','.$agentid.',@p_out)';
		$db->query($produce);
		return $db->query("select @p_out")->fetch(PDO::FETCH_ASSOC)['@p_out'];
	}

	/**
	 * [getUserAccountById 通过玩家ID获取玩家钻石余额]
	 * @Author   李龙
	 * @DateTime 2018-10-18T14:11:51+0800
	 * @param    string                   $userid [description]
	 * @return   [type]                           [description]
	 */
	public static function getUserAccountById($userid=''){
		if(empty($userid)) return;
		$db = self::__instance();
		$sql = "SELECT
					diamond
				FROM
					user_account
				WHERE
					userid = $userid ";
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result['diamond'];
	}
}