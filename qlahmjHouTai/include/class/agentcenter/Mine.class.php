<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class Mine extends Base {
	// 表名
	private static $agentinfo   = 'agent_info';
	private static $user_info   = 'user_info';
	private static $agent_level = 'agent_level';
	/**
	 * [getAgentInfo 取个人中心数据]
	 * @Author   李龙
	 * @DateTime 2018-08-04T14:20:51+0800
	 * @param    string                   $agentid [代理id]
	 * @return   [array]                            [个人中心数据]
	 */
	public static function getAgentInfo($agentid = ''){
		if(empty($agentid)) return;
		$db = self::__instance();	
		$sql = "select ai.userid,ai.wechatname,al.name,ui.picfile from ".self::$agentinfo." as ai left join ".self::$agent_level." as al on ai.levelid=al.levelid left join ".self::$user_info." as ui on ai.userid = ui.userid where ai.agentid = $agentid limit 1;";
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result){
			return $result;
		}
		return array();
	}
}