<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}


class Players extends Base {
	// 表名
	private static $user_info = 'user_info';
	private static $user_account = 'user_account';
	private static $agent_info = 'agent_info';
	private static $user_snsinfo = 'user_snsinfo';

	/**
	 * [getAgentBindPlayerCount 获取游戏玩家数量数据]
	 * @Author   李爽
	 * @DateTime 2018-08-03T13:35:33+0800
	 * @param    string                   $agentId [代理ID]
	 * @return   [type]                   [返回绑定玩家数]
	 */
	public static function getAgentBindPlayerCount($agentid=''){
		if(empty($agentid)) return;
		$db = self::__instance();
		$condition = ["agentid" => $agentid];
		return 0 + $db->count(self::$user_info ,$condition);
	}

	/**
	 * [getBindAgentIndrectPlayerCount 获取绑定代理下面代理的玩家绑定数量总和]
	 * @Author   李爽
	 * @DateTime 2018-08-24T13:53:08+0800
	 * @param    string                   $agentid [代理ID]
	 * @return   [type]                            [间接绑定玩家数量]
	 */
	public static function getBindAgentIndrectPlayerCount($agentid=''){
		if(empty($agentid)) return;
		$db = self::__instance();
		$sql="SELECT COUNT(ui.userid) FROM ".self::$user_info." ui WHERE ui.agentid IN (SELECT ai.agentid FROM ".self::$agent_info." ai WHERE ai.parentid = ".$agentid.")";
		return 0 + $db->query($sql)->fetchColumn();
	}
	/**
	 * [getAllPlayersByAgentId 获取玩家列表数据]
	 * @Author   李爽
	 * @DateTime 2018-08-03T14:13:42+0800
	 * @param    string                   $agentid   [代理ID]
	 * @param    string                   $player    [玩家ID]
	 * @param    string                   $start     [起始数]
	 * @param    string                   $page_size [页大小]
	 * @return   [type]                              [玩家列表数组]
	 */
	public static function getAllPlayersByAgentId($agentid='',$userid='', $start = '', $page_size = ''){
		if(empty($agentid)) return;
		$db = self::__instance();
		if($userid){
			$where.=" AND ui.userid = ".$userid;
		}

		if($agentid){
			$where.=" AND ui.agentid = ".$agentid;
		}
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		
		$sql ="select ui.nickname,ui.userid,ui.picfile,ua.diamond from ".self::$user_info." ui,".self::$user_account."  ua where ui.userid=ua.userid $where order by ui.addtime $limit";
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		foreach ($result as $key => $value) {
			if($result[$key]['userid'])
				$result[$key] = array_merge($result[$key],self::getPlayerGameNum($result[$key]['userid']));
		}
		if($result) return $result; else return array();
	}

	public static function getAllPlayersCountByAgentId($agentid='',$player=''){
		if(empty($agentid)) return;
		$db = self::__instance();
		$where =" where 1=1 ";
		if($player){
			$where.=" AND userid = ".$player;
		}

		if($agentid){
			$where.=" AND agentid = ".$agentid;
		}

		$sql ="select count(*) from ".self::$user_info .$where;
		return 0 + $db->query($sql)->fetchColumn ();
	}

	/**
	 * [getPlayerInfoByUserid 通过玩家id获取玩家资料]
	 * @Author   李龙
	 * @DateTime 2018-08-17T13:49:17+0800
	 * @param    string                   $userid [玩家id]
	 * @return   [type]                           [返回结果集]
	 */
	public static function getPlayerInfoByUserid($userid=''){
		if(empty($userid)) return;
		$db= self::__instance();
		$sql = "select ui.nickname,ui.userid,ui.picfile,ua.diamond,ui.agentid,ui.addtime,ui.logintime from ".self::$user_info." ui,".self::$user_account." ua where ui.userid=ua.userid AND ui.userid = ".$userid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}

	/**
	 * [updatePlayerBindAgentid 修改绑定玩家上家代理]
	 * @Author   李爽
	 * @DateTime 2018-08-28T10:24:21+0800
	 * @param    [type]                   $userid  [玩家ID]
	 * @param    [type]                   $agentid [上级代理]
	 * @return   [type]                            [返回执行结果]
	 */
	public static function updatePlayerBindAgentid($userid,$agentid){
		if(empty($userid)||empty($agentid))return;
		$db = self::__instance();
		$sql ="update ".self::$user_info." ui set ui.agentid = ".$agentid . " where ui.userid = " . $userid;
		return 0 + $db ->query($sql);
	}


	/**
	 * [getPlayerUnbindRelationship 解散玩家关系]
	 * @Author   李爽
	 * @DateTime 2018-08-13T14:09:01+0800
	 * @param    [type]                   $userid [代理ID]
	 * @return   [type]                            [description]
	 */
	public static function getPlayerUnbindRelationship($userid){
		if(empty($userid)) return;
		$db = self::__instance();
		$sql="CALL sp_user_log(".$userid.",0,2,@pu_out)";
		$db->exec($sql);
		return $db->query('select @pu_out')->fetch(PDO::FETCH_ASSOC)['@pu_out'];
	}

	/**
	 * [getPlayerGameNum 玩家游戏次数]
	 * @Author   李龙
	 * @DateTime 2018-10-10T18:03:27+0800
	 * @param    string                   $userid [description]
	 * @return   [type]                           [description]
	 */
	public static function getPlayerGameNum($userid = ''){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return ;
		$db = self::__instance();
		$sql = 'SELECT
					SUM( aa.cnt ) AS cnt 
				FROM
					(
				SELECT
					COUNT( osd.id ) AS cnt 
				FROM
					order_settlement os,
					order_settlement_detail osd 
				WHERE
					os.setid = osd.setid 
					AND osd.userid = '.$userid.' 
					AND os.RoomCost > 0 
					) aa ';
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}

	/**
	 * [checkPlayerIsIvited 验证玩家是否已经注册]
	 * @Author   李爽
	 * @DateTime 2018-08-21T18:13:07+0800
	 * @param    [type]                   $unionId [description]
	 * @param    [type]                   $openid  [description]
	 * @return   [type]                            [description]
	 */
	public static function checkPlayerIsIvited($unionId,$openid){
		if(empty($unionId)||empty($openid)) return;
		$db = self::__instance();
		$sql = 'SELECT userid FROM '.self::$user_snsinfo.' WHERE unionId ="'.$unionId.'" or openId = "'.$openid.'"';
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}

	/**
	 * [getUserSNSByUserid 根据Agentid获取openid]
	 * @Author   李爽
	 * @DateTime 2018-08-30T15:14:03+0800
	 * @param    [type]                   $userid [玩家ID]
	 * @return   [type]                            [description]
	 */
	public static function getUserSNSByUserid($userid){
		if(empty($userid)) return;
		$db = self::__instance();
		$sql = 'SELECT unionId,openId FROM '.self::$user_snsinfo.' WHERE userid ='.$userid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}

	/**
	 * [updateUserSNSOpenidByUserid 修改openid]
	 * @Author   李爽
	 * @DateTime 2018-09-29T16:12:29+0800
	 * @param    [type]                   $userid [玩家ID]
	 * @return   [type]                           [description]
	 */
	public static function updateUserSNSOpenidByUserid($userid,$openId){
		if(empty($userid)||empty($openId)) return;
		$db = self::__instance();
		$sql = "UPDATE ".self::$user_snsinfo." SET openId = '".$openId."' WHERE userid = " .$userid;
		return $db ->query($sql) > 0;
	}
}
