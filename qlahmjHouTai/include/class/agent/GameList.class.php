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
					gamestatus
				FROM
					game_info';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}
}