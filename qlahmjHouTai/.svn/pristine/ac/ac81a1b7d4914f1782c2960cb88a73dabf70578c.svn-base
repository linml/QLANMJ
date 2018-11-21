<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}

class WelfareRecord extends Base {
	/**
	 * [getWhere 搜索条件处理]
	 * @Author   李龙
	 * @DateTime 2018-10-22T14:33:06+0800
	 * @param    string                   $type        [description]
	 * @param    string                   $contain     [description]
	 * @param    string                   $welfareType [description]
	 * @param    string                   $startdate   [description]
	 * @param    string                   $enddate     [description]
	 * @return   [type]                                [description]
	 */
	public static function getWhere($type='',$contain='',$welfareType='',$startdate='',$enddate=''){
		if($contain){
			switch ($type) {
				case '1':
					$t = " AND ui.userid = '$contain' ";
					break;
				case '2':
					$t = " AND ui.nickname like '%$contain%' ";				
					break;
				case '3':
					$t = " AND b.userid = '$contain' ";
					break;
				case '4':
					$t = " AND b.nickname like '%$contain%' ";
					break;
				default:
					# code...
					break;
			}
		}else{
			$t = "";
		}
		if($welfareType) $welfare = " AND ua.activityid = '$welfareType'";else $welfare = "";
		$startdate = $startdate." 00:00:00";
		$enddate = $enddate." 23:59:59";
		if($startdate&&$enddate) $time = " and ual.addtime between '$startdate' and '$enddate' ";
		$where = " WHERE 1=1 $t $welfare $time ";
		return $where;
	}

	/**
	 * [getWelfareRecord 获取福利记录]
	 * @Author   李龙
	 * @DateTime 2018-10-22T14:33:25+0800
	 * @param    string                   $where [description]
	 * @return   [type]                          [description]
	 */
	public static function getWelfareRecord($where='',$limit){
		$db = self::__instance();
		$sql = "SELECT
					ual.addtime,
					ual.userid,
					ui.nickname,
					ua.activityid,
					ua.activityname,
					ua.activitymark
				FROM
					user_activity_log ual
				LEFT JOIN user_info ui ON ual.userid = ui.userid
				LEFT JOIN user_activity ua ON ual.activityid = ua.activityid
				LEFT JOIN agent_info ai ON ai.agentid = ui.agentid 
				LEFT JOIN user_info b ON ai.userid = b.userid  
				$where 
				ORDER BY ual.addtime DESC  
				$limit
				";
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getRowCount 计算数据总条目]
	 * @Author   李龙
	 * @DateTime 2018-10-22T14:33:44+0800
	 * @param    [type]                   $where [description]
	 * @return   [type]                          [description]
	 */
	public static function getRowCount($where){
		$db = self::__instance();
		$sql = "SELECT
					count(ual.logid)
				FROM
					user_activity_log ual
				LEFT JOIN user_info ui ON ual.userid = ui.userid
				LEFT JOIN user_activity ua ON ual.activityid = ua.activityid
				LEFT JOIN agent_info ai ON ai.agentid = ui.agentid 
				LEFT JOIN user_info b ON ai.userid = b.userid
				$where 
				";
		$result = $db->query($sql)->fetchColumn();
		return 0 + $result;
	}

	/**
	 * [getWelFareType 获取活动类型信息]
	 * @Author   李龙
	 * @DateTime 2018-10-22T13:42:20+0800
	 * @return   [type]                   [description]
	 */
	public static function getWelFareType(){
		$db = self::__instance();
		$sql = "select activityid,activityname from user_activity where status = '1' ";
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}
}