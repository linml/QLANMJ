<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class OpenAgents extends Base {
	
	private static $user_info = 'user_info';

	/**
	 * [getValidatePlayerByAgentId 验证输入数据是否合法]
	 * @Author   李爽
	 * @DateTime 2018-08-04T14:49:44+0800
	 * @param    string                   $agentid [代理ID]
	 * @param    string                   $player  [玩家ID]
	 * @return   [type]                            [返回结果]
	 */
	public static function getValidatePlayerByAgentId($agentid='',$player=''){
		if(empty($agentid)||empty($player)) return;
		$db = self::__instance();
		$condition = array("AND"=>array(
				'agentid'=>$agentid,
				'userid'=>$player
		));
		$columes =" userid,nickname ";
		$result = $db->select(self::$user_info,$columes,$condition);
		if($result) return $result; else return false;
	}
}