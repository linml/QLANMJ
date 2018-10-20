<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class Sell extends Base {
	
	// 表名
	private static $table_name = 'order';
	// 查询字段
	private static $columns = 'oid,weixin_out_trade_no, uid, payment, price, number, create_time, status, payment_time, payment_ way, proportion_status';

	public static function getTableName(){
		return parent::$table_prefix_osa_t.self::$table_name;
	}

	//转房卡
	public static function SellGems($AgentUid, $toplayerid, $gemsnumber) {
		$db=self::__instance();
		$sellgems_sql =  "update t_users set gems=gems-".$gemsnumber." where userid =".$AgentUid.";";
		$sellgems_sql .= "update t_users set gems=gems+".$gemsnumber." where userid =".$toplayerid.";";
		//echo $sellgems_sql;
		$db->query ( $sellgems_sql );
	}

	//转房卡记录
	public static function SellGemsRecord($uid, $oid, $selluid, $gems, $after_the_gems, $type) {

		$db=self::__instance();
		$db->insert("osa_t_gems_record",[
			"uid"            => $uid,
			"oid"            => $oid,
			"selluid"        => $selluid,
			"gems"           => $gems,
			"after_the_gems" => $after_the_gems,
			"type"           => $type,
		]);

		//$sellgems_sql = "INSERT INTO osa_t_gems_record (uid, oid, selluid, gems, after_the_gems,type) VALUES ({$uid}, {$oid}, {$selluid}, {$gems}, {$after_the_gems},'{$type}');";
		//$db->query ( $sellgems_sql );
	}

	//修改订单
	public static function updateOrder($oid,$group_data) {
		if (! $group_data || ! is_array ( $group_data )) {
			return false;
		}
		$db=self::__instance();
		$condition=array("oid"=>$oid);
		$id = $db->update ( self::getTableName(), $group_data,$condition );
		return $id;
	}
	
	/*
	 * 根据玩家id获取玩家
	 */
	public static function getTuserByUid($Uid) {
		$db=self::__instance();
		$sql= "select userid,account,unionid,name,sex,headimg,lv,exp,coins,gems,roomid,create_time,last_login_time from t_users  where userid=$Uid";
		$list = $db->query($sql)->fetch();// self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	public static function getTuserByaccount($account) {
		$db=self::__instance();
		$sql= "select userid,account,unionid,name,sex,headimg,lv,exp,coins,gems,roomid,create_time,last_login_time from t_users  where account='$account'";
		$list = $db->query($sql)->fetch();// self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	
}