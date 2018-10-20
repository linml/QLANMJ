<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class OnlineUsers extends Base {
	
	
	public static function getGamesCount() {
		$db = self::__instance ();
		return 0 + ($db->query ( "select count(r.uuid )
from  t_rooms r
				" )->fetchColumn ());
	}
	/**
	 * 获取房间
	 *
	 * @return number
	 */

	public static function getGames($start = '', $page_size = '') {
		$db = self::__instance ();
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		$sql = "select r.* ,FROM_UNIXTIME(r.create_time, '%Y-%m-%d %H:%i:%S')  as rt
from  t_rooms r  order by r.create_time desc $limit";
	
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}
	
	//在线房间计算
	public static function getRoomCountByUserIds($ids){
		if(!$ids){
			return 0;
		}
		$db=self::__instance();
		$sql = "select count(1)
		FROM t_rooms 
		where id in (
			select roomid 
			from t_users 
			where roomid is not null
			and userid in (".join(',',$ids).")
		);";
		return 0 + $db->query ( $sql )->fetchColumn ();
	}
	public static function getRoomByUserIds($ids,$start=’‘,$page_size=’‘){
		if(!$ids){
			return array();
		}
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		$db=self::__instance();
		$sql = "select id, FROM_UNIXTIME(create_time, '%Y-%m-%d %H:%i:%S')  as create_time,
		user_id0,user_name0,user_id1,user_name1,user_id2,user_name2,user_id3,user_name3 
		FROM t_rooms 
		where id in (
			select roomid 
			from t_users 
			where roomid is not null
			and userid in (".join(',',$ids).")
		) order by create_time desc $limit ;";
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}

	
}