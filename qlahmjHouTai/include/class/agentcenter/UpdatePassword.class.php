<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class UpdatePassword extends Base {
	private static $agentinfo = "agent_info";
	private static $column    = ["pw"];

	/**
	 * [checkpsw 验证密码]
	 * @Author   李龙
	 * @DateTime 2018-08-06T11:14:31+0800
	 * @param    string                   $agentid [代理id]
	 * @param    string                   $prepsw  [输入的密码]
	 * @return   [type]                            [返回是否]
	 */
	public static function checkpsw($agentid='',$prepsw=''){
		if(empty($agentid)||empty($prepsw)) return ;

		$db = self::__instance();
		$where = ["agentid" => $agentid];

		$pw = $db->select(self::$agentinfo,self::$column,$where);

		if($pw[0]['pw'] == md5($prepsw)){
			return 1;
		}
		return 0;
	}

	/**
	 * [updatepsw 修改密码]
	 * @Author   李龙
	 * @DateTime 2018-08-07T08:51:01+0800
	 * @param    string                   $agentid [代理id]
	 * @param    string                   $newpsw  [新密码]
	 * @return   [type]                            [返回是否成功]
	 */
	public static function updatepsw($agentid='',$newpsw=''){
		if(empty($agentid)||empty($newpsw)) return ;
		$db = self::__instance();
		$where = ["agentid" => $agentid];
		$data = ["pw" => md5($newpsw)];
		$result = $db->update(self::$agentinfo,$data,$where);
		return 0 + $result;
	}
}