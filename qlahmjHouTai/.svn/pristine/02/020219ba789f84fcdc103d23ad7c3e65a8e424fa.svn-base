<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class AgentRebateRecord extends Base {

	/**
	 * [getWhere 处理参数]
	 * @Author   李龙
	 * @DateTime 2018-09-03T16:47:47+0800
	 * @param    string                   $s_type    [搜索类型]
	 * @param    string                   $contains  [搜索内容]
	 * @param    string                   $s_grade   [等级]
	 * @param    string                   $s_ischeck [是否审核]
	 * @param    string                   $s_admin   [管理]
	 * @return   [type]                              [description]
	 */
	public static function getWhere($type='',$contains=''){
		if(!empty($contains)){
			switch ($type) {
				case '1':
					$q_id = " and ui.userid = '$contains' ";
					break;
				case '2':
					$q_id = " and ui.nickname like '%$contains%' ";
					break;
				case '3':
					$ret = parent::getAUInfo('userid',$contains);		
					$q_id = " and ai.parentid = ".$ret['Magentid']." ";
					break;
				default:
					break;
			}
		}
		$where = ' where 1=1 '.$q_id;
		return $where;
	}

	/**
	 * [getRebateSumList 代理报表数据]
	 * @Author   李龙
	 * @DateTime 2018-09-20T16:20:21+0800
	 * @param    [type]                   $start     [description]
	 * @param    string                   $page_size [description]
	 * @param    [type]                   $where     [description]
	 * @return   [type]                              [description]
	 */
	public static function getRebateSumList($start,$page_size='',$startdate='',$enddate='',$where){
		if($page_size) $limit = " limit $start,$page_size";
		if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
		if($startdate&&$enddate) $time = " and a.addtime between '$startdate' and '$enddate' ";else $time = " and DATE_FORMAT( a.addtime,'%Y-%m' ) = DATE_FORMAT( CURDATE(),'%Y-%m' ) ";
		$db = self::__instance();
		$sql = 'select aa.*,
				(SELECT ai.userid from agent_info ai where ai.agentid = aa.agentid) as userid,
				(select ui.nickname from user_info ui left join agent_info ai on ai.userid = ui.userid where ai.agentid = aa.agentid) as nickname,
				(select ui.userid from agent_info ai left join agent_info b on ai.parentid = b.agentid left join user_info ui on b.userid = ui.userid where ai.agentid = aa.agentid ) as upuserid,
				(select ui.nickname from agent_info ai left join agent_info b on ai.parentid = b.agentid left join user_info ui on b.userid = ui.userid where ai.agentid = aa.agentid ) as upnickname,
				(select al.name from agent_level al left join agent_info ai on al.levelid = ai.levelid where ai.agentid = aa.agentid) as name,
				(select sum(fundmoney) from log_funds_agent a where aa.agentid = a.agentid and a.fundtype ="81" and a.accounttype = "VD" '.$time.' group by a.agentid) as sumfundmoney
				FROM
				(SELECT   
				a.agentid,
				sum(CASE WHEN a.returnlevel = "1" THEN a.paynum ELSE 0 END) AS sumpaynum,
				sum(CASE WHEN a.returnlevel = "1" THEN a.returnrmb ELSE 0 END) AS onerebate,
				sum(CASE WHEN a.returnlevel = "2" THEN a.returnrmb ELSE 0 END) AS tworebate,
				sum(CASE WHEN a.returnlevel = "3" THEN a.returnrmb ELSE 0 END) AS threerebate
				from agent_return_log a
				left join agent_info ai on ai.agentid = a.agentid
				left join user_info ui on ai.userid = ui.userid
				'.$where.$time.'
				GROUP BY a.agentid '.$limit.') aa ';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}


	/**
	 * [getRowCount 获取信息条目]
	 * @Author   李龙
	 * @DateTime 2018-09-25T14:15:18+0800
	 * @param    string                   $startdate [开始时间]
	 * @param    string                   $enddate   [结束时间]
	 * @param    [type]                   $where     [筛选条件]
	 * @return   [type]                              [description]
	 */
	public static function getRowCount($startdate='',$enddate='',$where){
		if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
		if($startdate&&$enddate) $time = " and a.addtime between '$startdate' and '$enddate' ";else $time = " and DATE_FORMAT( a.addtime,'%Y-%m' ) = DATE_FORMAT( CURDATE(),'%Y-%m' ) ";
		$db = self::__instance();
		$sql = 'select count(*) from (SELECT
					count(*)
				FROM
					agent_return_log a
				LEFT JOIN agent_info ai ON ai.agentid = a.agentid
				LEFT JOIN user_info ui ON ai.userid = ui.userid
				'.$where.$time.'
				GROUP BY
					a.agentid) aa';
		return 0 + $db->query($sql)->fetchColumn();
	}

	/**
	 * [getDayData 获取日数据]
	 * @Author   李龙
	 * @DateTime 2018-09-25T14:19:14+0800
	 * @param    string                   $agentid    [玩家ID]
	 * @param    string                   $startdate [开始时间]
	 * @param    string                   $enddate   [结束时间]
	 * @return   [type]                              [description]
	 */
	public static function getDayData($agentid='',$startdate='',$enddate=''){
		if(empty($agentid)) return ;
		if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
		if($startdate&&$enddate) $time = " and a.addtime between '$startdate' and '$enddate' ";else $time = " and DATE_FORMAT( a.addtime,'%Y-%m' ) = DATE_FORMAT( CURDATE(),'%Y-%m' ) ";
		$db = self::__instance();
		$sql = 'select aa.*,
				(select sum(a.fundmoney) from log_funds_agent a 
				where aa.agentid = a.agentid 
				and a.fundtype = "81" 
				and a.accounttype = "VD" 
				AND DATE_FORMAT(a.addtime,"%Y-%m") = aa.addtime
				group by DATE_FORMAT(a.addtime,"%Y-%m-%d")) as sumfundmoney
				FROM
				(SELECT
					a.agentid,
					DATE_FORMAT(a.addtime, "%Y-%m-%d") AS addtime,
					sum( CASE WHEN a.returnlevel = "1" THEN	a.paynum ELSE 0 END) AS sumpaynum,
					sum( CASE WHEN a.returnlevel = "1" THEN a.returnrmb	ELSE 0 END ) AS onerebate,
					sum( CASE WHEN a.returnlevel = "2" THEN a.returnrmb ELSE 0 END ) AS tworebate,
					sum( CASE WHEN a.returnlevel = "3" THEN a.returnrmb ELSE 0 END ) AS threerebate
				FROM
					agent_return_log a
				WHERE
					a.agentid = '.$agentid.$time.'
				GROUP BY
					DATE_FORMAT(a.addtime, "%Y-%m-%d")
				ORDER BY
					DATE_FORMAT(a.addtime, "%Y-%m-%d") DESC) aa';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getMonthData 获取月数据]
	 * @Author   李龙
	 * @DateTime 2018-09-25T14:19:31+0800
	 * @param    string                   $agentid [玩家ID]
	 * @return   [type]                           [description]
	 */
	public static function getMonthData($agentid=''){
		if(empty($agentid)) return ;	
		$db = self::__instance();
		$sql = 'select 
				aa.*,
				(select sum(a.fundmoney) 
				from log_funds_agent a 
				where aa.agentid = a.agentid 
				and a.fundtype = "81" 
				and a.accounttype ="VD" 
				AND DATE_FORMAT(a.addtime,"%Y-%m") = aa.addtime
				group by DATE_FORMAT(a.addtime,"%Y-%m")) as sumfundmoney
				from 
				(SELECT
				a.agentid,
				DATE_FORMAT(a.addtime,"%Y-%m") AS addtime, 
				sum(CASE WHEN a.returnlevel = "1" THEN a.paynum ELSE 0 END) as sumpaynum, 
				sum(CASE WHEN a.returnlevel = "1" THEN a.returnrmb ELSE 0 END) AS onerebate, 
				sum(CASE WHEN a.returnlevel = "2" THEN a.returnrmb ELSE 0 END) AS tworebate, 
				sum(CASE WHEN a.returnlevel = "3" THEN a.returnrmb ELSE 0 END) AS threerebate 
				from agent_return_log a
				WHERE a.agentid = '.$agentid.' 
				group by DATE_FORMAT(a.addtime,"%Y-%m") 
				order by DATE_FORMAT(a.addtime,"%Y-%m") DESC) aa';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}
}

