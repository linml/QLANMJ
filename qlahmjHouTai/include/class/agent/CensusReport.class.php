<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class CensusReport extends Base {

	/**
	 * [getMonthWhere 对选择的月份参数进行处理]
	 * @Author   李龙
	 * @DateTime 2018-10-16T09:17:26+0800
	 * @param    string                   $month [description]
	 * @return   [type]                          [description]
	 */
	public static function getMonthWhere($month=''){
		if($month) $where = " and DATE_FORMAT(os.addtime,'%Y-%m') = '$month' ";else $where = " and DATE_FORMAT(os.addtime,'%Y-%m') = DATE_FORMAT(SYSDATE(),'%Y-%m')";
		return $where;
	}

	/**
	 * [getYearWhere 对选择的年份参数进行处理]
	 * @Author   李龙
	 * @DateTime 2018-10-16T09:17:51+0800
	 * @param    string                   $year [description]
	 * @return   [type]                         [description]
	 */
	public static function getYearWhere($year=''){
		if($year) $where = " and DATE_FORMAT(os.addtime,'%Y') = '$year' ";else $where = " and DATE_FORMAT(os.addtime,'%Y') = DATE_FORMAT(SYSDATE(),'%Y')";
		return $where;
	}

	/**
	 * [getMonthData 获取每月数据]
	 * @Author   李龙
	 * @DateTime 2018-10-16T09:18:54+0800
	 * @param    string                   $monthWhere [description]
	 * @return   [type]                               [description]
	 */
	public static function getMonthData($monthWhere=''){
		$db = self::__instance();
		$sql = 'SELECT
				 aa.*,
				(SELECT sum( CASE WHEN lfa.fundtype = "80" THEN lfa.fundmoney ELSE 0 END) FROM log_funds_agent lfa WHERE lfa.accounttype = "VD" AND DATE_FORMAT(lfa.addtime,"%Y-%m-%d") = aa.addtime GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m-%d")) AS sumchargediamond,
				(SELECT sum( CASE WHEN lfa.fundtype = "82" THEN lfa.fundmoney ELSE 0 END) FROM log_funds_agent lfa WHERE lfa.accounttype = "VD" AND DATE_FORMAT(lfa.addtime,"%Y-%m-%d") = aa.addtime GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m-%d")) AS sumtransdiamond,
				(SELECT sum( CASE WHEN lfa.fundtype ="83" THEN lfa.fundmoney ELSE 0 END) FROM log_funds_agent lfa WHERE lfa.accounttype = "VD" AND DATE_FORMAT(lfa.addtime,"%Y-%m-%d") = aa.addtime GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m-%d")) AS sumindiamond,
				(SELECT sum( CASE WHEN ot.transfertype = "1" THEN lfu.fundmoney ELSE 0 END ) FROM log_funds_user lfu LEFT JOIN order_transfer ot ON lfu.relationid = ot.id WHERE ot.accounttype = "VD" AND DATE_FORMAT(lfu.addtime,"%Y-%m-%d") = aa.addtime GROUP BY DATE_FORMAT(lfu.addtime,"%Y-%m-%d")) AS sumselldiamond,
				(SELECT sum( CASE WHEN ot.transfertype = "3" THEN lfu.fundmoney ELSE 0 END ) FROM log_funds_user lfu LEFT JOIN order_transfer ot ON lfu.relationid = ot.id WHERE ot.accounttype = "VD" AND lfu.fundmoney > 0 AND DATE_FORMAT(lfu.addtime,"%Y-%m-%d") = aa.addtime GROUP BY DATE_FORMAT(lfu.addtime,"%Y-%m-%d")) AS sumsenddiamond,
				(SELECT count( ai.agentid ) FROM agent_info ai WHERE DATE_FORMAT(ai.addtime,"%Y-%m-%d") = aa.addtime GROUP BY DATE_FORMAT(ai.addtime,"%Y-%m-%d")) AS newagentadd
				FROM 
				(SELECT DATE_FORMAT(os.addtime,"%Y-%m-%d") AS addtime,COUNT(os.tableid) AS counttable,SUM(os.RoomCost*os.FeeUserCount) AS sumroomcost FROM order_settlement os WHERE 1=1 AND os.RoomCost > 0 '.$monthWhere.' GROUP BY DATE_FORMAT(os.addtime,"%Y-%m-%d") ORDER BY addtime DESC ) aa
				';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getYearData 获取每年数据]
	 * @Author   李龙
	 * @DateTime 2018-10-16T09:19:10+0800
	 * @return   [type]                   [description]
	 */
	public static function getYearData($yearWhere=''){
		$db = self::__instance();
		$sql = 'SELECT
				 aa.*,
				(SELECT sum( CASE WHEN lfa.fundtype = "80" THEN lfa.fundmoney ELSE 0 END) FROM log_funds_agent lfa WHERE lfa.accounttype = "VD" AND DATE_FORMAT(lfa.addtime,"%Y-%m") = aa.addtime GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m")) AS sumchargediamond,
				(SELECT sum( CASE WHEN lfa.fundtype = "82" THEN lfa.fundmoney ELSE 0 END) FROM log_funds_agent lfa WHERE lfa.accounttype = "VD" AND DATE_FORMAT(lfa.addtime,"%Y-%m") = aa.addtime GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m")) AS sumtransdiamond,
				(SELECT sum( CASE WHEN lfa.fundtype ="83" THEN lfa.fundmoney ELSE 0 END) FROM log_funds_agent lfa WHERE lfa.accounttype = "VD" AND DATE_FORMAT(lfa.addtime,"%Y-%m") = aa.addtime GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m")) AS sumindiamond,
				(SELECT sum( CASE WHEN ot.transfertype = "1" THEN lfu.fundmoney ELSE 0 END ) FROM log_funds_user lfu LEFT JOIN order_transfer ot ON lfu.relationid = ot.id WHERE ot.accounttype = "VD" AND DATE_FORMAT(lfu.addtime,"%Y-%m") = aa.addtime GROUP BY DATE_FORMAT(lfu.addtime,"%Y-%m")) AS sumselldiamond,
				(SELECT sum( CASE WHEN ot.transfertype = "3" THEN lfu.fundmoney ELSE 0 END ) FROM log_funds_user lfu LEFT JOIN order_transfer ot ON lfu.relationid = ot.id WHERE ot.accounttype = "VD" AND lfu.fundmoney > 0 AND DATE_FORMAT(lfu.addtime,"%Y-%m") = aa.addtime GROUP BY DATE_FORMAT(lfu.addtime,"%Y-%m")) AS sumsenddiamond,
				(SELECT count( ai.agentid ) FROM agent_info ai WHERE DATE_FORMAT(ai.addtime,"%Y-%m") = aa.addtime GROUP BY DATE_FORMAT(ai.addtime,"%Y-%m")) AS newagentadd
				FROM 
				(SELECT DATE_FORMAT(os.addtime,"%Y-%m") AS addtime,COUNT(os.tableid) AS counttable,SUM(os.RoomCost*os.FeeUserCount) AS sumroomcost FROM order_settlement os WHERE 1=1 AND os.RoomCost > 0 '.$yearWhere.' GROUP BY DATE_FORMAT(os.addtime,"%Y-%m") ORDER BY addtime DESC ) aa
				';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}
}