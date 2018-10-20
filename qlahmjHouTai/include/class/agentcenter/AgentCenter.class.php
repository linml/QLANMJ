<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class AgentCenter extends Base {

	// 表名
	private static $agent_info = 'agent_info';
	private static $agent_account = 'agent_account';
	private static $agent_level = 'agent_level';
	private static $user_info = 'user_info';



	
	/**

 	 * [getAgentBindAgentCount 获取绑定代理]
 	 * @Author   李爽
 	 * @DateTime 2018-08-11T09:28:51+0800
 	 * @param    [type]                   $agentid [代理ID]
 	 * @return   [type]                            [代理数]
 	 */
 	public static function getAgentBindAgentCount($agentid){
 		if(empty($agentid)) return;
 		$db = self::__instance();
 		$sql ="select count(agentid) from ".self::$agent_info." ui where ui.parentid = ".$agentid;
 		return 0 + $db ->query($sql)->fetchColumn();
 	}
 	
	/**
	 * [getAllAgentsByAgentId 获取代理列表信息]
	 * @Author   李龙
	 * @DateTime 2018-08-11T10:03:23+0800
	 * @param    string                   $agentid   [代理Id]
	 * @param    int                   $start     [开始页]
	 * @param    int                   $page_size [每页显示条目]
	 * @return   [array]                              [返回明细]
	 */
	public static function getAllAgentsByAgentId($agentid='',$start='',$page_size=''){
		if(empty($agentid)) return;
		$db = self::__instance();
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		$sql = 'SELECT
					ai.agentid,
					ui.userid,
					ui.nickname,
					IFNULL(
						ui.picfile,
						"/assets/avatars/tark.png"
					) AS picfile,
					ai.wechatname,
					al.name
				FROM
					agent_info AS ai
				LEFT JOIN user_info AS ui ON ai.userid = ui.userid
				LEFT JOIN agent_level AS al ON ai.levelid = al.levelid
				WHERE ai.parentid = '.$agentid.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		foreach ($result as $key => $value) {
			if($result[$key]['agentid']){
				$playerCount = Players::getAgentBindPlayerCount($result[$key]['agentid']);
				$result[$key]['binduser'] = $playerCount;
			}
		}
		if($result) return $result; else return array();
	}

	/**
	 * [getAgentsInfoByAgentId 获取代理信息]
	 * @Author   李爽
	 * @DateTime 2018-08-03T17:49:49+0800
	 * @param    string                   $agentid [代理ID]
	 * @return   [type]                            [代理对象数组]
	 */
	public static function getAgentsInfoByAgentId($agentid=''){
		if(empty($agentid)) return;
		$db = self::__instance();
		$sql='SELECT ui.picfile,ui.userid,ai.wechatname ,al.`name`,ai.agentid,ai.addtime,ai.logintime,(select count(ui.userid) from '.self::$user_info.' as ui left join '.self::$agent_info.' as ai on ui.agentid = ai.agentid = '. $agentid .') as binduser FROM '.self::$agent_info." as ai,".self::$agent_level." al,".self::$agent_account." aa,".self::$user_info ." ui WHERE ai.agentid = aa.agentid AND ai.userid = ui.userid AND ai.levelid = al.levelid AND ai.agentid=".$agentid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}


	/**
	 * [getAgentUnbindRelationship 解散代理关系]
	 * @Author   李爽
	 * @DateTime 2018-08-13T14:09:01+0800
	 * @param    [type]                   $agentid [代理ID]
	 * @return   [type]                            [description]
	 */
	public static function getAgentUnbindRelationship($agentid){
		if(empty($agentid)) return;
		$db = self::__instance();
		$sql="CALL sp_agent_log(".$agentid.",0,2,@u_out)";
		$db->exec($sql);
		return $db->query('select @u_out')->fetch(PDO::FETCH_ASSOC)['@u_out'];
	}


	/**
	 * [toJudgeAgentIsExist 通过玩家ID获取代理数量]
	 * @Author   李爽
	 * @DateTime 2018-08-04T16:23:34+0800
	 * @param    string                   $playerid [玩家ID]
	 * @return   [type]                             [数量]
	 */
	public static function toJudgeAgentIsExist($playerid=''){
		if(empty($playerid)) return;
		$db = self::__instance();
		$condition =array('userid'=>$playerid);
		$result = $db->count(self::$agent_info,$condition);
		if($result>0) return $result; else return false;
	}

	/**
	 * [toJudgeAgentIsExistByAgentId 通过代理ID获取代理数量]
	 * @Author   李爽
	 * @DateTime 2018-08-04T16:23:34+0800
	 * @param    string                   $playerid [玩家ID]
	 * @return   [type]                             [数量]
	 */
	public static function toJudgeAgentIsExistByAgentId($agentid=''){
		if(empty($agentid)) return;
		$db = self::__instance();
		$condition =array('agentid'=>$agentid);
		$result = $db->count(self::$agent_info,$condition);
		if($result>0) return $result; else return false;
	}
	

	/**
	 * [getUpLevelByAgentLevle 获取下级代理级别]
	 * @Author   李爽
	 * @DateTime 2018-08-04T16:37:36+0800
	 * @param    string                   $levelid [代理等级]
	 * @return   [type]                            [返回下级代理结果集]
	 */
	public static function getUpLevelByAgentLevel($levelid=''){
		if(empty($levelid)) return;
		$db = self::__instance();
		$sql="SELECT levelid,`name` ,FLOOR(discount*100) as discount  FROM ".self::$agent_level." WHERE levelid >".$levelid;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();

	}

	/**
	 * [getAgentLevleByLevelid 获取代理级别]
	 * @Author   李爽
	 * @DateTime 2018-08-14T09:17:12+0800
	 * @param    [type]                   $levelid [级别ID]
	 * @return   [type]                            [代理级别集]
	 */
	public static function getAgentLevleByLevelid($levelid){
		if(empty($levelid)) return;
		$db = self::__instance();
		$sql ="select levelid,name,discount from ".self::$agent_level ." where levelid = ".$levelid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}


	/**
	 * [toAddAgent 增加代理]
	 * @Author   李爽
	 * @DateTime 2018-08-06T17:49:31+0800
	 * @param    [type]                   $playerid   [玩家ID]
	 * @param    [type]                   $nickname   [代理昵称]
	 * @param    [type]                   $wechat     [微信号]
	 * @param    [type]                   $wechatname [微信昵称]
	 * @param    [type]                   $tel        [电话]
	 * @param    [type]                   $leveld     [等级]
	 * @return   [type]                               [返回信息]
	 */
	public static function toAddAgent($playerid,$nickname,$wechat,$wechatname,$tel,$leveld){
		if(empty($playerid)||empty($nickname)||empty($tel)||empty($wechat)||empty($wechatname)||empty($leveld))return;
		$db = self::__instance();
		$parentid = UserSession::getAgentId();
		if(empty($parentid)) return;
		$produce = "call sp_agent_add(".$playerid.",'".$tel."','".$wechat."','".$wechatname."','".md5('123456')."','".$leveld."','".$nickname."',".$parentid.",@taa_out)";
		//执行存储过程
		$db->query($produce);
		//调用存储用户变量
		return $db->query("select @taa_out")->fetch(PDO::FETCH_ASSOC)['@taa_out'];
	}

	/**
	 * [getAgentInfoByAgentId 获取代理基本信息]
	 * @Author   李爽
	 * @DateTime 2018-08-06T18:01:10+0800
	 * @param    [type]                   $agentid [代理ID]
	 * @return   [type]                            [代理信息集合]
	 */
	public static function getAgentInfoByAgentId($agentid){
		if(empty($agentid)) return;
		$db = self::__instance();
		$sql="SELECT ai.agentid,ai.userid,ai.levelid,al.name,al.discount,ai.status,aa.rmb,FLOOR(aa.diamond) as diamond FROM ".self::$agent_info." ai,".self::$agent_account." aa ,".self::$agent_level." al WHERE ai.agentid=aa.agentid AND ai.levelid = al.levelid AND ai.agentid=".$agentid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else array();
	}

	/**
	 * [allotDiamondsToTheAgent 划拨钻石给代理]
	 * @Author   李爽
	 * @DateTime 2018-08-08T09:24:10+0800
	 * @param    [type]                   $toAgentId     [要充值代理ID]
	 * @param    [type]                   $diamondCount [充值]
	 * @return   [type]                                 [返回充值信息]
	 */
	public static function allotDiamondsToTheAgent($toAgentId,$diamondCount){
		$ret = parent::getAUInfo('userid',$toAgentId);
		$toAgentId = $ret['Magentid'];
		if(empty($toAgentId)||empty($diamondCount))return;
		$db = self::__instance();
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return -1;
		$progress = "call sp_agent_transfer_agent(".$agentid.",".$toAgentId.",".$diamondCount.",@dtt_out)";
		$db->exec($progress);
		return $db->query('select @dtt_out')->fetch()['@dtt_out'];
	}


	/**
 	 * [getAgentBindIndirectPlayerCount 获取间接绑定玩家数]
 	 * @Author   李爽
 	 * @DateTime 2018-08-10T19:52:52+0800
 	 * @param    [type]                   $agentid [代理ID]
 	 * @return   [type]                            [返回绑定数]
 	*/
 	public static function getAgentBindIndirectPlayerCount($agentid){
 		if(empty($agentid))return;
 		$db = self::__instance();
 		$sql="SELECT COUNT(ui.userid) FROM ".self::$user_info." ui WHERE ui.agentid IN (SELECT ai.agentid FROM ".self::$agent_info." ai WHERE ai.parentid='".$agentid."')";
 		return 0 + $db->query($sql)->fetchColumn();
 	}
	
}