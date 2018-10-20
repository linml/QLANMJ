<?php 
if(!defined('ACCESS')){
	exit('Access denied');
}
class MyEarning extends Base{
	private static $agent_info = 'agent_info';
	private static $log_funds_agent = 'log_funds_agent';
	private static $agent_return_log = 'agent_return_log';

	/**
	 * [getWhere 对参数进行处理]
	 * @Author   李龙
	 * @DateTime 2018-09-03T17:03:24+0800
	 * @param    string                   $agentid   [代理id]
	 * @param    string                   $dirAgent  [上级代理昵称或者ID]
	 * @param    string                   $startdate [开始时间]
	 * @param    string                   $enddate   [结束时间]
	 * @return   [type]                              [description]
	 */
	public static function getWhere($agentid='',$dirAgent='',$startdate='',$enddate=''){
		if(!empty($agentid)){
			$ret = parent::getAUInfo('userid',$agentid);
			$agentid = ' and ai.agentid = '.$ret['Magentid'];
		}else{
			$agentid = '';
		}

		if(!empty($dirAgent)){
			$ret = parent::getAUInfo('userid',$dirAgent);		
			$dirAgent = " and (ai.parentid = '".$ret['Magentid']."' or ai.agentname like '%".$ret['Mnickname']."%')";
		}else{
			$dirAgent = '';
		}
		if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
		if($startdate&&$enddate) $time = " and lfa.addtime between '$startdate' and '$enddate' ";else $time = "";
		// if(!empty($startdate)&&!empty($enddate)){
		// 	$time = " and lfa.addtime between '".$startdate."' and '".$enddate."'";
		// }else{
		// 	$time = '';
		// }
			$where = $agentid.$dirAgent.$time;
		return $where;
	}
	/**
	 * [getRebatListCount 佣金记录表统计]
	 * @Author   李龙
	 * @DateTime 2018-08-29T10:04:11+0800
	 * @param    string                   $start     [description]
	 * @param    string                   $page_size [description]
	 * @return   [type]                              [返回条目数]
	 */
	public static function getRebatListCount($where){
		$db = self::__instance();
		$sql = 'SELECT
					count(lfa.id)
				FROM
					'.self::$log_funds_agent.' lfa
				LEFT JOIN '.self::$agent_info.' ai ON lfa.agentid = ai.agentid
				LEFT JOIN '.self::$agent_return_log.' arl ON arl.relationid = lfa.relationid
				AND arl.agentid = lfa.agentid
				LEFT JOIN user_info ui ON ai.userid = ui.userid
				WHERE
					lfa.accounttype = "RM"
				AND lfa.fundtype = "86" '.$where;
		$result = $db->query($sql)->fetchColumn();
		return 0 + $result;
	}

	/**
	 * [getRebateList 佣金记录表列表数据]
	 * @Author   李龙
	 * @DateTime 2018-08-29T10:04:32+0800
	 * @param    [type]                   $limit     [description]
	 * @param    [type]                   $where     [description]
	 * @return   [type]                              [返回结果集]
	 */
	public static function getRebateList($limit='',$where){
		$db = self::__instance();
		$sql = 'SELECT
					lfa.agentid,
					ai.userid,
					ui.nickname,
					ai.agentname,
					ai.levelid,
					lfa.fundtype,
					lfa.fundmoney,
					lfa.agomoney,
					arl.returnlevel,
					lfa.addtime,
					lfa.relationid
				FROM
					'.self::$log_funds_agent.' lfa
				LEFT JOIN '.self::$agent_info.' ai ON lfa.agentid = ai.agentid
				LEFT JOIN '.self::$agent_return_log.' arl ON arl.relationid = lfa.relationid
				AND arl.agentid = lfa.agentid
				LEFT JOIN user_info ui ON ai.userid = ui.userid
				WHERE
					lfa.accounttype = "RM"
				AND lfa.fundtype = "86" '.$where.'
				ORDER BY
					lfa.addtime DESC,
					arl.returnlevel ASC'.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}
}