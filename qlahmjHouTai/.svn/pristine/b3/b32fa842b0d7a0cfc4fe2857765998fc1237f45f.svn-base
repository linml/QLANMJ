<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class DrawMoneyRecord extends Base {
	// 表名
	private static $agent_transfer = 'agent_transfer';
	/**
	 * [getDrawMoneyRecord 提现记录列表信息]
	 * @Author   李龙
	 * @DateTime 2018-08-08T18:02:37+0800
	 * @param    string                   $agnetid   [代理id]
	 * @param    string                   $startDate [开始日期]
	 * @param    string                   $endDate   [结束日期]
	 * @param    string                   $start     [开始页]
	 * @param    string                   $page_size [页数]
	 * @return   [array]                             [结果集]
	 */
	public static function getDrawMoneyRecord($start = '',$page_size = '',$endDate = ''){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return ;
		if(!empty($endDate))  $where =" and unix_timestamp(addtime) > unix_timestamp('". $endDate."')" ;
		if($page_size){
			$limit = " limit $start,$page_size";
		}
		$db = self::__instance();
		$sql = 'select `rmb`,`status`,`addtime` from '.self::$agent_transfer.' where cashtype = "C" and agentid = '.$agentid.$where.' order by addtime desc'.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result){
			return $result;
		}
		return array();
	}

	/**
	 * [getAllCountByAgentId 获取数据条目数]
	 * @Author   李龙
	 * @DateTime 2018-08-23T10:20:38+0800
	 * @param    string                   $agentid   [代理id]
	 * @param    string                   $startDate [开始时间]
	 * @param    string                   $endDate   [结束时间]
	 * @return   [int]                              [返回整形]
	 */
	public static function getAllCountByAgentId($agentid = '',$startDate = '',$endDate = ''){
		if(empty($agentid)) return ;

		empty($startDate)?($startDate='2018-7-23'):$startDate;
		empty($endDate)?($endDate='2030-7-23'):$endDate;

		$where = " and addtime between '{$startDate}' and '{$endDate}' ";

		$db = self::__instance();
		$sql = 'select count(*) from '.self::$agent_transfer.' where cashtype = "C" and agentid = '.$agentid .$where;
		return 0 + $db->query($sql)->fetchColumn();
	}
}