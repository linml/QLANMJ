<?php
if (! defined ( 'ACCESS' )) {	exit ( 'Access denied.' );
}
class Share extends Base {

	public static function GetShare($uid,$create_time) {
	
		$db=self::__instance();
		$sql= "select *  from osa_t_gems_share where uid=$uid and create_time='$create_time'";
		//echo $sql;
		$list = $db->query($sql)->fetch();
		if ($list) {
			return $list;
		}
		return array ();

	}
	
	public static function add_Share_log($order_data) {
	
		if (! $order_data || ! is_array ( $order_data )) {
				
			return false;
		}
	
		$db=self::__instance();
		$id = $db->insert ( "osa_t_gems_share", $order_data );
	
		return $id;
	}
}