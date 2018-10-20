<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class UpdateMyInfo extends Base {
	// 表名
	private static $agent_info = "agent_info";
	private static $column     = ["userid","wechatname","mobilenum","agentname","wechatnum","addtime"];

	/**
	 * [getInfo 获取代理账号信息]
	 * @Author   李龙
	 * @DateTime 2018-08-04T15:38:07+0800
	 * @param    string                   $agentid [代理id]
	 * @return   [type]                            [返回账号信息]
	 */
	public static function getInfo($agentid = ''){
		if(empty($agentid)) return ;

		$db = self::__instance();
		$where = ["agentid" => $agentid];

		$result = $db->select(self::$agent_info,self::$column,$where);


		if($result){
			return $result[0];
		}
		return array();
	}

	/**
	 * [updateInfo 修改账号信息]
	 * @Author   李龙
	 * @DateTime 2018-08-04T17:03:22+0800
	 * @param    [type]                   $agentid   [代理id]
	 * @param    [type]                   $agentname [代理姓名]
	 * @param    [type]                   $wechatnum [微信账号]
	 * @return   [type]                              [返回结果]
	 */
	public static function updateInfo($agentid,$agentname,$wechatnum){
		if(empty($agentid)||empty($agentname)||empty($wechatnum)) return;

		$db = self::__instance();
		$where= ["agentid" => $agentid];
		$data = [
			"agentname" => $agentname,
			"wechatnum"=> $wechatnum,
		];

		$result = $db->update(self::$agent_info,$data,$where);
		return 0 + $result;
	}
}