<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class RebateRecord extends Base{

	private static $agent_return_log = 'agent_return_log';
	private static $log_funds_agent = 'log_funds_agent';
	private static $agent_transfer = 'agent_transfer';
	/**
	 * [getRebateRecordList 返佣记录列表信息]
	 * @Author   李龙
	 * @DateTime 2018-08-10T16:34:41+0800
	 * @param    [string]                   $agentid [代理id]
	 * @return   [array ]                            [返回数组]
	 */
	public static function getRebateRecordList($start,$pagesize,$endDate){
		if ($pagesize) $limit = " limit $start,$pagesize ";
		if ($endDate){
			 	$date = " AND lfa.addtime between '$endDate' and NOW()";
			}else{
				$date = " AND DATE_FORMAT(lfa.addtime,'%Y-%m') = DATE_FORMAT(curdate(),'%Y-%m')";
			}
		$agentid = UserSession::getAgentId();
		$db = self::__instance();
		$sql = "select lfa.relationid,lfa.fundtype FROM ".self::$log_funds_agent." lfa WHERE lfa.accounttype='RM' AND lfa.agentid = ".$agentid.$date." order by lfa.addtime desc ".$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		$agentMaidRecodeData = array();
		foreach ($result as $key => $value) {
			if($result[$key]['fundtype']=='83'){
				$data = self::getAgentCashOutDiamond($result[$key]['relationid']);
				if(!empty($data))
				array_push($agentMaidRecodeData,$data);
			}else if($result[$key]['fundtype']=='85'){
				$data = self::getAgentOutCash($result[$key]['relationid']);
				if(!empty($data))
				array_push($agentMaidRecodeData,$data);
			}else if($result[$key]['fundtype']=='86'){
				$data = self::getPlayerMaid($result[$key]['relationid']);
				if(!empty($data))
				array_push($agentMaidRecodeData,$data);
			}else return array();
		}

		if($agentMaidRecodeData)return $agentMaidRecodeData;else return array();
	}

	/**
	 * [getPlayerMaid 获取玩家充值代理返利类型]
	 * @Author   李爽
	 * @DateTime 2018-08-11T14:41:26+0800
	 * @param    [type]                   $agentid    [代理ID]
	 * @param    [type]                   $relationid [订单号]
	 * @return   [type]                               [返回查询结果集]
	 */
	public static function getPlayerMaid($relationid){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)||empty($relationid)) return;
		$db = self::__instance();
		$sql="SELECT arl.userid,lfa.fundtype,arl.paynum,lfa.fundmoney,lfa.addtime,arl.returnlevel FROM ".self::$log_funds_agent." lfa , ".self::$agent_return_log." arl WHERE lfa.relationid = arl.relationid  AND accounttype ='RM' AND fundtype='86' AND lfa.agentid=".$agentid." AND arl.agentid = ".$agentid." AND lfa.relationid= '".$relationid."'";
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}

	/**
	 * [getAgentCashOutDiamond 获取现金转钻石]
	 * @Author   李爽
	 * @DateTime 2018-08-11T14:45:29+0800
	 * @param    [type]                   $agentid    [代理ID]
	 * @param    [type]                   $relationid [订单号]
	 * @return   [type]                               [结果]
	 */
	public static function getAgentCashOutDiamond($relationid){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)||empty($relationid)) return;
		$db = self::__instance();
		$sql="SELECT lfa.agentid,lfa.fundtype,lfa.fundmoney,atf.diamond ,lfa.addtime FROM ".self::$log_funds_agent." lfa ,".self::$agent_transfer." atf WHERE lfa.relationid = atf.id AND  lfa.accounttype='RM' AND lfa.fundtype='83' AND lfa.agentid=".$agentid." AND lfa.relationid= '".$relationid."'";
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}

	/**
	 * [getAgentOutCash 获取提现记录]
	 * @Author   李爽
	 * @DateTime 2018-08-11T14:48:07+0800
	 * @param    [type]                   $agentid    [代理ID]
	 * @param    [type]                   $relationid [订单号]
	 * @return   [type]                               [结果集]
	 */
	public static function getAgentOutCash($relationid){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)||empty($relationid)) return;
		$db = self::__instance();
		$sql="select lfa.fundtype,lfa.fundmoney,lfa.addtime FROM ".self::$log_funds_agent." lfa WHERE lfa.accounttype='RM' AND lfa.fundtype='85' AND lfa.agentid=".$agentid." AND lfa.relationid= '".$relationid."'";
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}


	/**
	 * [getIncomeAndExpend 获取查询月或本月的收支]
	 * @Author   李龙
	 * @DateTime 2018-08-14T12:04:40+0800
	 * @param    [string]                   $endDate [日期]
	 * @return   [array ]                            [返回结果集]
	 */
	public static function getIncomeAndExpend($endDate){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return User::logout();
		$db = self::__instance();
		if ($endDate){
			 	$date = " AND lfa.addtime between '".$endDate."' and NOW()";
			}else{
				$date = " AND DATE_FORMAT(addtime,'%Y-%m') = DATE_FORMAT(curdate(),'%Y-%m')";
			}
		$sql = "select IFNULL(-sum(case when lfa.fundmoney < 0 then lfa.fundmoney end),0) as expend,IFNULL(sum(case when lfa.fundmoney > 0 then lfa.fundmoney end),0) as income from ".self::$log_funds_agent." as lfa where lfa.accounttype = 'RM' and lfa.agentid = ".$agentid.$date;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result; else return array();
	}
}