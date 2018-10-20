<?php 
require_once ADMIN_BASE_LIB."WxPay/lib/WxPay.Config.class.php";
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class GemsRecharge extends Base {
	private static $agent_account = 'agent_account';
	/**
	 * [getRechargeConfig 获取钻石金额 [$type] 1 普通 2 加钻]
	 * @Author   李爽
	 * @DateTime 2018-08-07T16:28:57+0800
	 * @param    [type]                   $money [金额]
	 * @param    [type]                   $type  [选择类型]
	 * @return   [type]                          [返回钻石数量]
	 */
	public static function getRechargeConfig($money,$type){
		if(empty($money)) return;if(empty($type)) $type =1;
		$rechargeConfigName = $type == 1 ? WxPayConfig::GLOBLE_MONEY_INDET_CARD : ($type==2?WxPayConfig::GLOBLE_Bind_AGENT_GIVE_CARD:'');
		$money*=100;
		return  0  + json_decode($rechargeConfigName,true)[$money];
	}

	/**
	 * [toRechargeThePlayer 代理给玩家充值]
	 * @Author   李爽
	 * @DateTime 2018-08-07T16:53:01+0800
	 * @param    [type]                   $playerid      [玩家ID]
	 * @param    [type]                   $money         [金额]
	 * @param    [type]                   $currencyCount [基本钻石]
	 * @param    [type]                   $bonusCount    [加赠钻石]
	 * @return   [type]                                  [返回参数值]
	 */
	public static function toRechargeThePlayer($playerid,$money,$currencyCount,$bonusCount){
		if(empty($playerid)||empty($money)||empty($currencyCount)) return;
		$db = self::__instance();
		//1、获取代理ID
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return;
		$progress = "call sp_agent_transfer_user(".$agentid.",".$playerid.",".$money.",".$currencyCount.",".$bonusCount.",@o_out)";
		$db->exec($progress);
		return $db->query("select @o_out")->fetch(PDO::FETCH_ASSOC)['@o_out'];
	}

	/**
	 * [getAccountDiamond 当前代理账号钻石]
	 * @Author   李龙
	 * @DateTime 2018-08-31T17:04:06+0800
	 * @return   [type]                   [description]
	 */
	public static function getAccountDiamond(){
		$agentid = UserSession::getAgentId();
		if(empty($agentid)) return;
		$db = self::__instance();
		$sql = 'select diamond from '.self::$agent_account.' where agentid = '.$agentid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		return 0 + $result['diamond'];
	}
}