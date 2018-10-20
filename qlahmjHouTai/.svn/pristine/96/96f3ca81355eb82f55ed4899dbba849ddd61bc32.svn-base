<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class GemsRecord extends Base {
	// 表名
	private static $log_funds_agent = 'log_funds_agent';
	private static $agent_transfer  = 'agent_transfer';
	
	/**
	 * [getDiamonRecord1 获取钻石记录]
	 * @Author   李龙
	 * @DateTime 2018-09-14T14:49:23+0800
	 * @param    [type]                   $start    [description]
	 * @param    [type]                   $pagesize [description]
	 * @param    [type]                   $endDate  [description]
	 * @return   [type]                             [description]
	 */
	public static function getDiamonRecord($start,$pagesize,$endDate){
		if($pagesize) $limit = " limit $start,$pagesize";
		if(!empty($endDate))  $where =" and unix_timestamp(addtime) > unix_timestamp('". $endDate."')" ;
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return ;
		$db = self::__instance();
		$sql = 'SELECT
					fundtype,
					fundmoney,
					addtime,
					agomoney,
					relationid
				FROM
					log_funds_agent
				WHERE
					accounttype = "VD"
				AND agentid = '.$agentid.$where.' order by addtime desc '.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		foreach ($result as $key => $value) {
			if($result[$key]['fundtype'] == '81'){
				$result[$key] = array_merge($result[$key],self::getRechargeUsers($result[$key]['relationid']));
			}else if($result[$key]['fundtype'] == '82'){
				$result[$key] = array_merge($result[$key],self::getSendAgents($result[$key]['relationid']));
			}
		}
		if($result) return $result;else return array();
	}

	/**
	 * [getRechargeUsers1 给玩家充钻]
	 * @Author   李龙
	 * @DateTime 2018-09-14T14:49:42+0800
	 * @param    string                   $relationid [description]
	 * @return   [type]                               [description]
	 */
	public static function getRechargeUsers($relationid=''){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)||empty($relationid)) return ;
		$db = self::__instance();
		$sql = 'SELECT
					at.agentid,
					at.auid,
					ui.userid,
					ui.nickname
				FROM
					agent_transfer at
				LEFT JOIN user_info ui ON at.auid = ui.userid
				WHERE
					at.id = "'.$relationid.'"';
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getSendAgents1 代理划拨]
	 * @Author   李龙
	 * @DateTime 2018-09-14T14:50:03+0800
	 * @param    string                   $relationid [description]
	 * @return   [type]                               [description]
	 */
	public static function getSendAgents($relationid=''){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)||empty($relationid)) return ;
		$db = self::__instance();
		$sql = 'SELECT
					at.agentid,
					at.auid,
					c.userid as cuserid,
					c.nickname as cnickname,
					d.userid as duserid,
					d.nickname as dnickname
				FROM
					agent_transfer at
				LEFT JOIN agent_info ai ON at.agentid = ai.agentid
				LEFT JOIN agent_info b ON at.auid = b.agentid
				LEFT JOIN user_info c ON ai.userid = c.userid
				LEFT JOIN user_info d ON b.userid = d.userid
				WHERE
					at.id = "'.$relationid.'"';
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result['agentid'] == $agentid){
			array_push($result,'me');
		}else if($result['auid'] == $agentid){
			array_push($result, 'others');
		}
		if($result) return $result;else return array();
	}
}