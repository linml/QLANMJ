<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class FinanceReport extends Base {

	/**
	 * [getDayWhere 查询月份数据参数处理]
	 * @Author   李龙
	 * @DateTime 2018-10-13T15:33:55+0800
	 * @param    string                   $month [description]
	 * @return   [type]                          [description]
	 */
	public static function getDayWhere($month=''){
		if($month) $where = " and DATE_FORMAT(a.addtime,'%Y-%m') = '$month' ";else $where = " and DATE_FORMAT(a.addtime,'%Y-%m') = DATE_FORMAT(SYSDATE(),'%Y-%m')";
		return $where;
	}

	/**
	 * [getMonthWhere 查询年份数据参数处理]
	 * @Author   李龙
	 * @DateTime 2018-10-13T15:34:13+0800
	 * @param    string                   $year [description]
	 * @return   [type]                         [description]
	 */
	public static function getMonthWhere($year=''){
		if($year) $where = " and DATE_FORMAT(a.addtime,'%Y') = '$year' ";else $where = " and DATE_FORMAT(a.addtime,'%Y') = DATE_FORMAT(SYSDATE(),'%Y')";
		return $where;
	}

	/**
	 * [getRowCountDay 计算每月数据的显示条目]
	 * @Author   李龙
	 * @DateTime 2018-10-13T15:45:30+0800
	 * @param    [type]                   $dayWhere [description]
	 * @return   [type]                             [description]
	 */
	public static function getRowCountDay($dayWhere){
		if(empty($dayWhere)) return;
		$db = self::__instance();
		$sql = 'SELECT
					COUNT(aa.counts)
				FROM
					(
						SELECT
							count(*) AS counts
						FROM
							agent_return_log a
						WHERE
							1 = 1 
						'.$dayWhere.' 
						GROUP BY
							DATE_FORMAT(a.addtime, "%Y-%m-%d")
					) aa';
		return 0 + $db->query($sql)->fetchColumn();
	}

	/**
	 * [getRowCountMonth 计算每年信息显示条目]
	 * @Author   李龙
	 * @DateTime 2018-10-13T15:46:30+0800
	 * @param    [type]                   $monthWhere [description]
	 * @return   [type]                               [description]
	 */
	public static function getRowCountMonth($monthWhere){
		if(empty($monthWhere)) return;
		$db = self::__instance();
		$sql = 'SELECT
					COUNT(aa.counts)
				FROM
					(
						SELECT
							count(*) AS counts
						FROM
							agent_return_log a
						WHERE
							1 = 1 
						'.$monthWhere.' 
						GROUP BY
							DATE_FORMAT(a.addtime, "%Y-%m")
					) aa';
		return 0 + $db->query($sql)->fetchColumn();
	}

	/**
	 * [getDayData 获取某一个月的数据]
	 * @Author   李龙
	 * @DateTime 2018-10-13T16:33:56+0800
	 * @param    [type]                   $dayWhere [description]
	 * @return   [type]                             [description]
	 */
	public static function getDayData($dayWhere){
		$db = self::__instance();
		$sql = 'select aa.*,
				(select sum(a.rmb) 
				from agent_transfer a 
				where a.cashtype = "C" 
				and a.status = "1" 
				and DATE_FORMAT(a.addtime,"%Y-%m-%d") = aa.addtime 
				group by DATE_FORMAT(a.addtime,"%Y-%m-%d")) as sumrmb,
				(select sum(op.rmb) from order_pay op where op.status = "1" and op.userflag = "U" and op.accounttype="VD" and DATE_FORMAT(op.addtime,"%Y-%m-%d") = aa.addtime) as sumcharge,
				(select sum(at.rmb) from log_funds_agent lfa 
left join agent_transfer at on lfa.relationid = at.id and at.status = "1"
where lfa.accounttype = "VD" and DATE_FORMAT(lfa.addtime,"%Y-%m-%d") = aa.addtime and lfa.fundtype = "83"
GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m-%d")) as sumatrmb,
				(select sum(op.rmb) from log_funds_agent lfa 
left join order_pay op on lfa.relationid = op.id and op.status = "1"
where lfa.accounttype = "VD" and DATE_FORMAT(lfa.addtime,"%Y-%m-%d") = aa.addtime and lfa.fundtype = "80"
GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m-%d")) as sumoprmb,
				(select sum(ot.rmb) from order_transfer ot where ot.accounttype = "VD" and (ot.transfertype = "1" OR ot.transfertype = "3") AND DATE_FORMAT(ot.addtime,"%Y-%m-%d") = aa.addtime) as sumselldiamond
				FROM
				(SELECT
					DATE_FORMAT(a.addtime, "%Y-%m-%d") AS addtime,
					sum( CASE WHEN a.returnlevel = "1" THEN	a.paynum ELSE 0 END ) AS sumpaynum,
					sum( CASE WHEN a.returnlevel = "1" THEN a.returnrmb	ELSE 0 END ) AS onerebate,
					sum( CASE WHEN a.returnlevel = "2" THEN a.returnrmb ELSE 0 END ) AS tworebate,
					sum( CASE WHEN a.returnlevel = "3" THEN a.returnrmb ELSE 0 END ) AS threerebate
				FROM
					agent_return_log a
				WHERE
					1=1 '.$dayWhere.'
				GROUP BY
					DATE_FORMAT(a.addtime, "%Y-%m-%d")
				ORDER BY
					DATE_FORMAT(a.addtime, "%Y-%m-%d") DESC ) aa';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getMonthData 获取某年每月的数据]
	 * @Author   李龙
	 * @DateTime 2018-10-13T16:34:19+0800
	 * @param    [type]                   $monthWhere [description]
	 * @return   [type]                               [description]
	 */
	public static function getMonthData($monthWhere){
		$db = self::__instance();
		$sql = 'select aa.*,
				(select sum(a.rmb) 
				from agent_transfer a 
				where a.cashtype = "C" 
				and a.status = "1" 
				and DATE_FORMAT(a.addtime,"%Y-%m") = aa.addtime 
				group by DATE_FORMAT(a.addtime,"%Y-%m")) as sumrmb,
				(select sum(op.rmb) from order_pay op where op.status = "1" and op.userflag = "U" and op.accounttype="VD" and DATE_FORMAT(op.addtime,"%Y-%m") = aa.addtime) as sumcharge,
				(select sum(at.rmb) from log_funds_agent lfa 
left join agent_transfer at on lfa.relationid = at.id and at.status = "1"
where lfa.accounttype = "VD" and DATE_FORMAT(lfa.addtime,"%Y-%m") = aa.addtime and lfa.fundtype = "83"
GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m")) as sumatrmb,
				(select sum(op.rmb) from log_funds_agent lfa 
left join order_pay op on lfa.relationid = op.id and op.status = "1"
where lfa.accounttype = "VD" and DATE_FORMAT(lfa.addtime,"%Y-%m") = aa.addtime and lfa.fundtype = "80"
GROUP BY DATE_FORMAT(lfa.addtime,"%Y-%m")) as sumoprmb,
				(select sum(ot.rmb) from order_transfer ot where ot.accounttype = "VD" and (ot.transfertype = "1" OR ot.transfertype = "3") AND DATE_FORMAT(ot.addtime,"%Y-%m") = aa.addtime) as sumselldiamond
				FROM
				(SELECT
					DATE_FORMAT(a.addtime, "%Y-%m") AS addtime,
					sum( CASE WHEN a.returnlevel = "1" THEN	a.paynum ELSE 0 END ) AS sumpaynum,
					sum( CASE WHEN a.returnlevel = "1" THEN a.returnrmb	ELSE 0 END ) AS onerebate,
					sum( CASE WHEN a.returnlevel = "2" THEN a.returnrmb ELSE 0 END ) AS tworebate,
					sum( CASE WHEN a.returnlevel = "3" THEN a.returnrmb ELSE 0 END ) AS threerebate
				FROM
					agent_return_log a
				WHERE
					1=1 '.$monthWhere.'
				GROUP BY
					DATE_FORMAT(a.addtime, "%Y-%m")
				ORDER BY
					DATE_FORMAT(a.addtime, "%Y-%m") DESC ) aa';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}
}