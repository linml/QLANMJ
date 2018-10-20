<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class TopupEarnings extends Base {
	// 表名
	private static $order_pay = 'order_pay';
	private static $agent_info = 'agent_info';
	private static $user_info = 'user_info';

	/**
	 * [getWhere 处理查询的参数]
	 * @Author   李龙
	 * @DateTime 2018-09-04T10:40:34+0800
	 * @return   [type]                   [返回where条件语句]
	 */
	public static function getWhere($startdate,$enddate,$s_type,$contains,$s_status){
		if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
		if($startdate&&$enddate) $time = " and op.addtime between '$startdate' and '$enddate' ";else $time = "";
		if(!empty($contains)){
			switch ($s_type) {
				case '1':
					$q_id = " and ui.userid = '$contains' ";
					break;
				case '2':
					$q_id = " and ui.nickname like '%$contains%' ";
					break;
				case '3':
					$q_id = " and b.userid = '$contains' ";
					break;
				case '4':
					$q_id = " and b.nickname like '%$contains%' ";
					break;
				default:
					# code...
					break;
			}
		}
		if(!empty($s_status)){
			$q_status = " and op.status =  ".$s_status;
		}
		 
		$where = ' where 1=1 and op.userflag = "U" and op.accounttype="VD" '.$q_id.$q_status.$time;
		return $where;
	}

	/**
	 * [getOrderRecordList 订单列表]
	 * @Author   李龙
	 * @DateTime 2018-09-04T10:58:47+0800
	 * @return   [type]                   [description]
	 */
	public static function getOrderRecordList($start,$page_size='',$where){
		if($page_size) $limit = " limit $start,$page_size";
		$db  = self::__instance();
		$sql = 'SELECT
					op.id,
					op.auid,
					op.realrmb,
					op.paytype,
					op.status,
					op.addtime,
					ui.userid,
					ui.nickname,
					ui.agentid,
					b.userid as buserid,
					b.nickname as bnickname
				FROM
					'.self::$order_pay.' op
				left join '.self::$user_info.' ui on ui.userid = op.auid
				left join '.self::$agent_info.' ai on ui.agentid = ai.agentid
				left join '.self::$user_info.' b on ai.userid = b.userid'.$where.' ORDER BY op.addtime DESC '.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getOrderCount 查询订单条目数]
	 * @Author   李龙
	 * @DateTime 2018-09-04T11:47:58+0800
	 * @param    [type]                   $where [筛选条件]
	 * @return   [type]                          [返回条目数]
	 */

	public static function getOrderCount($where){
		$db = self::__instance();
		$sql = 'SELECT
					count(op.id)
				FROM
					'.self::$order_pay.' op
				left join '.self::$user_info.' ui on ui.userid = op.auid
				left join '.self::$agent_info.' ai on ui.agentid = ai.agentid
				left join '.self::$user_info.' b on ai.userid = b.userid '.$where;
		return 0 + $db->query($sql)->fetchColumn();
	}
}