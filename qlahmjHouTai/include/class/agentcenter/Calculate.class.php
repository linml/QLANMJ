<?php
if(!defined('ACCESS')) {exit('Access denied.');}

class Calculate extends Base {

	//表名
	private static $table_name = 'order';
	public static function getTableName(){
		return parent::$table_prefix_osa_t.self::$table_name;
	}

	//处理支付成功订单
	public static function calculateOrder($order){

		if(!$order) return "orderIsNull";
		if($order["status"] != 0) return "orderHasbeenComplete";

		$tUser = GameUser::getUser($order['uid']);
		if(!$tUser) return "notFindTUser:".$order['uid'];
		
		//记录
		Gems::addGemsRecord([
			'uid'  => $order['uid'],
			'oid'  => $order['oid'],
			'gems' => $order['number'],
			'after_the_gems' => $order['number']+$tUser['gems'],
			'type' => "add"
		]);

		//增加
		if(GameUser::addGems($order['uid'], $order['number'], $order['uid'])){
			Order::onOrderChangeState($order['oid'], "addGemsFinish");
		}

		//处理提成
		Proportion::calculateProportion($order);

		//修改提成状态
		Order::onOrderChangeState($order['oid'], "proportionFinish");

		return "success";
	}

}