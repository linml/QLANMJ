<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class PresentGems extends Base{
	/*
	 * 获取房卡数量
	 */
	public static function getGems() {
		STools::log("\n is start start ");
		$db = self::__instance ();
		$sql = "select * from t_gems limit 1";
		$list = $db->query ( $sql )->fetchAll ();
		return $list;
	}
	/*
	 * 修改房卡数量
	 */
	public static function updateGems($level_data) {
		if (! $level_data || ! is_array ( $level_data )) {
			return false;
		}
		$db = self::__instance ();
		$condition = array (
				'id' => 1 
		);
		$id = $db->update ( "t_gems", $level_data, $condition );
		return $id;
	}
}