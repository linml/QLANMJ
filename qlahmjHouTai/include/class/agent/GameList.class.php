<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}

class GameList extends Base {

	/**
	 * [gamelist 游戏列表]
	 * @Author   李龙
	 * @DateTime 2018-09-20T14:08:22+0800
	 * @return   [type]                   [description]
	 */
	public static function getGamelist(){
		$db = self::__instance();
		$sql = 'SELECT
					gameid,
					gamename,
					gametype,
					gamestatus,
					gamecity,
					GameDesc
				FROM
					game_info';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [updateInfo 对传递来的信息作出更新]
	 * @Author   李龙
	 * @DateTime 2018-10-20T17:43:45+0800
	 * @param    [type]                   $sql  [参数]
	 * @return   [type]                           [description]
	 */
	public static function updateInfo($sql){
		if(empty($sql)) return;
		$db = self::__instance();
		$result = $db->exec($sql);
		return 0 + $result;
	}
}