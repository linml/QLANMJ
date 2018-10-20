<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class PlayersInfo extends Base {

	private static $table_name = 'user_info';
	private static $columns = 'userid,useraccount,pw,nickname,gender,email,mobile,addtime,status,isname,realname,idcard,refereeid,agentid,keystring,viplevel,picfile,logintime,loginip';

	public static function getTableName(){
		return self::$table_name;
	}

	public static function get_PlayersInfo($userid){
		$db 		= self::__instance();
		$condition  = ['userid' => $userid];
		$list       = $db->select(self::$table_name,self::$columns,$condition);
		if($list){
			return $list[0];
		}
		return array();
	}
}