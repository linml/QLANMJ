<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class JSRecord extends Base {
	
	/**
	 * [getDayJSRecord 获取日统计数据]
	 * @Author   李龙
	 * @DateTime 2018-09-29T09:37:20+0800
	 * @param    string                   $time [description]
	 * @param    string                   $type [description]
	 * @return   [type]                         [description]
	 */
	public static function getDayJSRecord($time='',$type='',$start,$page_size){
		if($page_size) $limit = " limit $start,$page_size ";
		if(empty($time)) $time = " AND DATE_FORMAT( addtime,'%Y-%m') = DATE_FORMAT( SYSDATE(),'%Y-%m') ";else $time = " AND DATE_FORMAT( addtime,'%Y-%m') = '$time' ";
		if(!empty($type)){
			if(($type-1)>0){
				$type = " AND groupid > 0 ";
			}else{
				$type = " AND groupid = 0 ";
			}
		}else{
			$type = "";
		}
		$where = " WHERE 1=1 AND RoomCost > 0 $time $type ";
		$db = self::__instance();
		$sql = 'SELECT DATE_FORMAT(addtime,"%Y-%m-%d") AS addtime,
				COUNT(tableid) AS counttable,
				SUM(RoomCost) AS sumroomcost,
				SUM(CASE WHEN gameid = "51" THEN 1 ELSE 0 END) AS counttableBJ,
				SUM(CASE WHEN gameid = "51" THEN RoomCost ELSE 0 END) AS sumroomcostBJ, 
				SUM(CASE WHEN gameid = "100" THEN 1 ELSE 0 END) AS counttableHQ,
				SUM(CASE WHEN gameid = "100" THEN RoomCost ELSE 0 END) AS sumroomcostHQ,
				SUM(CASE WHEN gameid = "161" THEN 1 ELSE 0 END) AS counttableLQ,
				SUM(CASE WHEN gameid = "161" THEN RoomCost ELSE 0 END) AS sumroomcostLQ
				FROM order_settlement '.$where.'
				GROUP BY DATE_FORMAT(addtime,"%Y-%m-%d")
				ORDER BY DATE_FORMAT(addtime,"%Y-%m-%d") DESC 
				'.$limit.' 
				';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getMonthJSRecord 获取月统计数据]
	 * @Author   李龙
	 * @DateTime 2018-09-29T09:37:45+0800
	 * @return   [type]                   [description]
	 */
	public static function getMonthJSRecord($time='',$type='',$start,$page_size){
		if($page_size) $limit = " limit $start,$page_size ";
		if(empty($time)) $time = " AND DATE_FORMAT( addtime,'%Y') = DATE_FORMAT( SYSDATE(),'%Y') ";else $time = " AND DATE_FORMAT( addtime,'%Y') = '$time' ";
		if(!empty($type)){
			if(($type-1)>0){
				$type = " AND groupid > 0 ";
			}else{
				$type = " AND groupid = 0 ";
			}
		}else{
			$type = "";
		}
		$where = " WHERE 1=1 AND RoomCost $time $type ";
		$db = self::__instance();
		$sql = 'SELECT DATE_FORMAT(addtime,"%Y-%m") AS addtime,
				COUNT(tableid) AS counttable,
				SUM(RoomCost) AS sumroomcost,
				SUM(CASE WHEN gameid = "51" THEN 1 ELSE 0 END) AS counttableBJ,
				SUM(CASE WHEN gameid = "51" THEN RoomCost ELSE 0 END) AS sumroomcostBJ, 
				SUM(CASE WHEN gameid = "100" THEN 1 ELSE 0 END) AS counttableHQ,
				SUM(CASE WHEN gameid = "100" THEN RoomCost ELSE 0 END) AS sumroomcostHQ,
				SUM(CASE WHEN gameid = "161" THEN 1 ELSE 0 END) AS counttableLQ,
				SUM(CASE WHEN gameid = "161" THEN RoomCost ELSE 0 END) AS sumroomcostLQ
				FROM order_settlement '.$where.'
				GROUP BY DATE_FORMAT(addtime,"%Y-%m") 
				ORDER BY DATE_FORMAT(addtime,"%Y-%m") DESC 
				'.$limit.'				
				';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}


	/**
	 * [getJSGameRecordCount 获取rowCount]
	 * @Author   李龙
	 * @DateTime 2018-09-29T17:14:48+0800
	 * @param    string                   $method [description]
	 * @param    string                   $time   [description]
	 * @param    string                   $type   [description]
	 * @return   [type]                           [description]
	 */
	public static function getJSGameRecordCount($method='',$time='',$type=''){
		if(!empty($type)){
			if(($type-1)>0){
				$type = " AND groupid > 0 ";
			}else{
				$type = " AND groupid = 0 ";
			}
		}else{
			$type = "";
		}
		switch ($method) {
			case 'day':
				if(empty($time)) $time = " AND DATE_FORMAT( addtime,'%Y-%m') = DATE_FORMAT( SYSDATE(),'%Y-%m') ";else $time = " AND DATE_FORMAT( addtime,'%Y-%m') = '$time' ";
				if(!empty($type)){
					if(($type-1)>0){
						$type = " AND groupid > 0 ";
					}else{
						$type = " AND groupid = 0 ";
					}
				}else{
				$type = "";
				}
				$where = " WHERE 1=1 AND RoomCost > 0 $time $type ";
				$sql = 'SELECT count(*) FROM (SELECT count(DATE_FORMAT(addtime, "%Y-%m-%d")) FROM order_settlement '.$where.' GROUP BY DATE_FORMAT(addtime, "%Y-%m-%d")) AS c ';
				break;
			case 'month':
				if($page_size) $limit = " limit $start,$page_size ";
				if(empty($time)) $time = " AND DATE_FORMAT( addtime,'%Y') = DATE_FORMAT( SYSDATE(),'%Y') ";else $time = " AND DATE_FORMAT( addtime,'%Y') = '$time' ";
				if(!empty($type)){
					if(($type-1)>0){
						$type = " AND groupid > 0 ";
					}else{
						$type = " AND groupid = 0 ";
					}
				}else{
					$type = "";
				}
				$where = " WHERE 1=1 AND RoomCost $time $type ";
				$sql = 'select count(*) from (SELECT count(DATE_FORMAT(addtime,"%Y-%m"))
				FROM order_settlement '.$where.'  
				GROUP BY DATE_FORMAT(addtime,"%Y-%m") 
				) as c';
				break;
			default:
				if(empty($time)) $time = " AND DATE_FORMAT( addtime,'%Y-%m') = DATE_FORMAT( SYSDATE(),'%Y-%m') ";else $time = " AND DATE_FORMAT( addtime,'%Y-%m') = '$time' ";
				if(!empty($type)){
					if(($type-1)>0){
						$type = " AND groupid > 0 ";
					}else{
						$type = " AND groupid = 0 ";
					}
				}else{
				$type = "";
				}
				$where = " WHERE 1=1 AND RoomCost > 0 $time $type ";
				$sql = 'SELECT count(*) FROM (SELECT count(DATE_FORMAT(addtime, "%Y-%m-%d")) FROM order_settlement '.$where.' GROUP BY DATE_FORMAT(addtime, "%Y-%m-%d")) AS c ';
				break;
		}
		$db = self::__instance();
		return 0 + $db->query($sql)->fetchColumn();
	}
}