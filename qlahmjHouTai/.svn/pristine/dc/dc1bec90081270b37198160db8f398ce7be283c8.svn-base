<?php
if(!defined('ACCESS')) {exit('Access denied.');}

class Loginwx extends Base{
	
	public static function addUser($user_data) {
		if (! $user_data || ! is_array ( $user_data )) {
			return false;
		}
		$db=self::__instance();
		$id = $db->insert ( "osa_user", $user_data );
		return $id;
	}
	

	public static function getUserBy_unionid($unionid) {
		$db=self::__instance();

		$ret = $db->select("osa_user", "*",["unionid"=>$unionid]);
		//$sql= "select *  from osa_user where unionid='$unionid' ";
		//$list = $db->query($sql)->fetch();
		return $ret[0];
	}
}