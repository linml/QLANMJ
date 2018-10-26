<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class LeaderBoard extends Base {

	/**
	 * [getWhere 处理搜索参数]
	 * @Author   李龙
	 * @DateTime 2018-10-16T17:45:44+0800
	 * @param    [type]                   $type     [description]
	 * @param    [type]                   $contains [description]
	 * @param    [type]                   $start    [description]
	 * @param    [type]                   $end      [description]
	 * @return   [type]                             [description]
	 */
	public static function getWhere($type,$contains,$starttime,$endtime){
		if(empty($contains)) $type = "";
		if($type == 1){
			$type = " and osd.userid = '$contains' ";
		}else if($type == 2){
			$type = " and ui.nickname like '%$contains%'";
		}else{
			$type = "";
		}
		if(empty($starttime)||empty($endtime)){
			$time = " AND DATE_FORMAT(os.addtime,'%Y-%m-%d') = DATE_FORMAT(SYSDATE(),'%Y-%m-%d') ";
		}else if($starttime >= $endtime){
			$time = " AND DATE_FORMAT(os.addtime,'%Y-%m-%d') = '$starttime' ";
		}else{
			$time = " AND DATE_FORMAT(os.addtime,'%Y-%m-%d') BETWEEN '$starttime' AND '$endtime' ";
		}
		return $type.$time;
	}

	/**
	 * [getBoard 获取排行榜]
	 * @Author   李龙
	 * @DateTime 2018-10-16T17:46:03+0800
	 * @param    string                   $where  [description]
	 * @param    string                   $gameid [description]
	 * @return   [type]                           [description]
	 */
	public static function getBoard($where='',$gameid='',$limit){
		if(empty($gameid)) $count = " ,count(osd.setid) AS count ";
		if($gameid == "51") $count = " ,count(CASE WHEN os.gameid = '51' THEN os.setid ELSE NULL END) AS count ";
		if($gameid == "100") $count = " ,count(CASE WHEN os.gameid = '100' THEN os.setid ELSE NULL END) AS count ";
		if($gameid == "161") $count = " ,count(CASE WHEN os.gameid = '161' THEN os.setid ELSE NULL END) AS count ";
		$db = self::__instance();
		$sql = 'SELECT
				osd.userid,
				ui.nickname
				'.$count.'
				FROM order_settlement_detail osd
				LEFT JOIN order_settlement os ON os.setid = osd.setid AND os.RoomCost > 0
				LEFT JOIN user_info ui ON osd.userid = ui.userid
				WHERE 1=1 
				'.$where.' 
				GROUP BY osd.userid
				ORDER BY count DESC
				'.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getRowCount 计算总数]
	 * @Author   李龙
	 * @DateTime 2018-10-17T10:19:04+0800
	 * @param    [type]                   $where [description]
	 * @return   [type]                          [description]
	 */
	public static function getRowCount($where){
		$db = self::__instance();
		$sql = 'SELECT
					count(1)
				FROM
					(
						SELECT
							count(*)
						FROM
							order_settlement_detail osd
						LEFT JOIN order_settlement os ON os.setid = osd.setid
						AND os.RoomCost > 0
						LEFT JOIN user_info ui ON osd.userid = ui.userid
						WHERE
							1 = 1
						'.$where.'
						GROUP BY
							osd.userid
					) aa ';
		return 0 + $db->query($sql)->fetchColumn();
	}
}