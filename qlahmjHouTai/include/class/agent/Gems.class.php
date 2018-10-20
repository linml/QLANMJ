<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class Gems extends Base {
	/*
	转送房卡记录查询
	*/
	public static function getSellGemsRecord($gameid = '',$roomid = '',$gameType ='' ,$startDate = '' ,$endDate = '',$start = '', $page_size = ''){
		$db=self::__instance(pigcms_game);
		$sql= "select temp.userid,temp.name,temp.room,temp.payway,temp.type,temp.jushu, temp.cost,temp.time from (

			select uid0 as userid, nickname0 as name, room_id as room , if(payway=1,'AA支付','房主支付') as payway, room_type as type , jushu ,ABS(cost0) as cost , created as time from ninedt_battle_log where uid0 !=0 

			UNION ALL

			select uid1 ,nickname1 as name, room_id as room , if(payway=1,'AA支付','房主支付') as payway , room_type as type , jushu ,ABS(cost1) as cost ,  created as time from ninedt_battle_log where uid1 !=0  

			UNION ALL

			select uid2 , nickname2 as name, room_id as room , if(payway=1,'AA支付','房主支付')as payway , room_type as type , jushu ,ABS(cost2) as cost , created as time from ninedt_battle_log where uid2 !=0  

			UNION ALL

			select uid3 , nickname3 as name, room_id as room , if(payway=1,'AA支付','房主支付')as payway , room_type as type , jushu ,ABS(cost3) as cost, created as time from ninedt_battle_log where uid3 !=0 
			
			UNION ALL

			select uid4 , nickname4 as name, room_id as room , if(payway=1,'AA支付','房主支付') as payway, room_type as type , jushu ,ABS(cost4) as cost, created as time from ninedt_battle_log where uid4 !=0 

		) temp";

		$where = " where 1 = 1 ";
		if($gameid){
			$where = $where.' and temp.userid = '.$gameid;
		}
		if($roomid){
			$where = $where.' and temp.room = '.$roomid;
		}

		if($gameType){
			$where.=" and temp.type = '$gameType'";
		}
		if($startDate){
			$where = $where." and date(temp.time) >= '".$startDate."' ";
		}
		if($endDate){
			$where = $where." and date(temp.time) <= '".$endDate."' ";
		}
		$where = $where.' order by temp.time desc ';
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		// var_dump($sql.$where.$limit);
		$list = $db->query($sql.$where.$limit)->fetchAll();
		if ($list) {
			return $list;
		}
		return array ();
	}

	public static function getSellGemsRecordCount($gameid = '',$roomid = '',$gameType ='' ,$startDate = '' ,$endDate = ''){
		$db=self::__instance(pigcms_game);
		$sql= "select count(1) as count from (

			select uid0 as userid,room_id as room, room_type as type,created as time from ninedt_battle_log where uid0 !=0 

			UNION ALL

			select uid1 , room_id as room,room_type as type,created as time from ninedt_battle_log where uid1 !=0  

			UNION ALL

			select uid2 , room_id as room,room_type as type,created as time from ninedt_battle_log where uid2 !=0  

			UNION ALL

			select uid3 ,room_id as room, room_type as type,created as time from ninedt_battle_log where uid3 !=0 
			
			UNION ALL

			select uid4 , room_id as room,room_type as type,created as time from ninedt_battle_log where uid4 !=0 

		)temp ";

		$where = " where 1 = 1 ";
		if($gameid){
			$where = $where.' and temp.userid = '.$gameid;
		}
		if($roomid){
			$where = $where.' and temp.room = '.$roomid;
		}

		if($gameType){
			$where.=" and temp.type = '$gameType'";
		}

		if($startDate){
			$where = $where." and date(temp.time) >= '".$startDate."' ";
		}
		if($endDate){
			$where = $where." and date(temp.time) <= '".$endDate."' ";
		}
		// var_dump($sql.$where);
		$count = 0 + $db->query($sql.$where)->fetchColumn();
		// var_dump('$count');
		return $count;
	}
}