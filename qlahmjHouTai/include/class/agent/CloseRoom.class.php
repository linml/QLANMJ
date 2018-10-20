<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class CloseRoom extends Base {
	
	/*
	 * 获取提成比例
	 */
	public static function getMessage() {
		$db = self::__instance ();
		$data = array (
				"server_maintenance" => array('key_value'=>'')
		);
		$sql = "select * from osa_system  where key_name in('server_maintenance')";
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			foreach ( $list as $k  ) {
				$data[$k['key_name']]['key_value'] = $k['key_value'];
			}
		}
		return $data;
	}
	/*
	 * 修改提成比例
	 */
     public static function updateMessage($level, $level_data) {
		if (! $level_data || ! is_array ( $level_data )) {
			return false;
		}
		$db = self::__instance ();
		$condition = array (
				'key_name' => $level 
		);
		$id = $db->update ( "osa_system", $level_data, $condition );
		return $id;
	}
	
}