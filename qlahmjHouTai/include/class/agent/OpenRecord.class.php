<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class OpenRecord extends Base {
	
	private static $order_settlement = 'order_settlement';
	private static $order_settlement_detail = 'order_settlement_detail';
	private static $game_info = 'game_info';
	private static $user_info = 'user_info';
	
	/**
	 * [getWhere 处理筛选条件]
	 * @Author   李龙
	 * @DateTime 2018-09-06T10:09:12+0800
	 * @param    [type]                   $startdate [开始日期]
	 * @param    [type]                   $enddate   [结束日期]
	 * @param    [type]                   $ownerid   [房主ID]
	 * @param    [type]                   $tableid    [房间号]
	 * @param    [type]                   $game      [游戏ID]
	 * @return   [type]                              [description]
	 */
	public static function getWhere($startdate,$enddate,$tableid,$game,$ownerid){
		if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
		if($startdate&&$enddate) $time = " and os.addtime between '$startdate' and '$enddate' ";else $time = "";
		if($ownerid) $ownerid = " AND (SELECT count(DISTINCT osd.setid) from order_settlement_detail osd where osd.userid = $ownerid and os.setid=osd.setid ) > 0 "; else $ownerid = "";
		if($tableid) $tableid = " and os.tableid = ".$tableid;else $tableid = "";
		if($game) $game = " and os.gameid = ".$game;else $game = "";
		$where = " where 1=1 AND os.RoomCost > 0 ".$tableid.$ownerid.$game.$time;
		return $where;
	}

	/**
	 * [getSetIdByUserid 通过房主id找到setid]
	 * @Author   李龙
	 * @DateTime 2018-10-08T16:29:00+0800
	 * @param    string                   $ownerid [description]
	 * @return   [type]                            [description]
	 */
	public static function getSetIdByUserid($ownerid=''){
		if(empty($ownerid)) return ;
		$db = self::__instance();
		$sql = 'select setid from order_settlement_detail where userid = '.$ownerid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getGameRoomList 获取房间信息]
	 * @Author   李龙
	 * @DateTime 2018-09-06T09:38:57+0800
	 * @param    [type]                   $start     [开始]
	 * @param    [type]                   $page_size [每页显示条目]
	 * @param    [type]                   $where     [筛选条件]
	 * @return   [type]                              [返回结果集]
	 */
	public static function getGameRoomList($start='',$page_size='',$where){	
		if($page_size) $limit = " limit $start,$page_size";
		$db = self::__instance();
		$sql = 'select aa.* ,
				(select gi.gamename from game_info gi where gi.gameid=aa.gameid) gamename,
				(select ui.nickname from user_info ui where ui.userid=aa.ownerid) nickname,
				(select osd.moneynum from order_settlement_detail osd where osd.setid=aa.setid and osd.userid=aa.ownerid) moneynum
				from 
				(SELECT
									os.setid,
									os.gameid,
									os.groupid,
									os.roomid,
									os.tableid,
									os.RoomCostType,
									os.RoomCost,
									os.mark,
									os.ownerid,
									os.addtime,
									os.gamenum
								FROM
									order_settlement os
				       '.$where.' order by os.addtime desc '.$limit.' 
				    ) aa ';
		$osdata = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($osdata) return $osdata;else return array();
	}

	/**
	 * [getUserMoneyNum 获取玩家在对局中战绩]
	 * @Author   李龙
	 * @DateTime 2018-09-06T09:38:16+0800
	 * @param    [type]                   $setid  [对局ID]
	 * @param    [type]                   $userid [description]
	 * @return   [type]                           [description]
	 */
	public static function getUserMoneyNum($setid,$userid){
		if(empty($setid)||empty($userid))return ;
		$db = self::__instance();
		$sql = 'select moneynum from '.self::$order_settlement_detail.' osd where setid = '.$setid.' and userid = '.$userid;
		$data = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($data) return $data;
	}

	/**
	 * [getGameRoomCount 计算房间表条目用于分页]  err
	 * @Author   李龙
	 * @DateTime 2018-09-06T09:52:25+0800
	 * @param    [type]                   $where [筛选条件]
	 * @return   [type]                          [返回条目数]
	 */
	public static function getGameRoomCount($where){
		$db = self::__instance();
		$sql = 'SELECT
				count(os.setid)
				FROM
					order_settlement os
       			'.$where;
		return 0 + $db->query($sql)->fetchColumn();
	}

	/**
	 * [getGameInfo 查询游戏列表信息]
	 * @Author   李龙
	 * @DateTime 2018-09-06T10:43:38+0800
	 * @return   [type]                   [description]
	 */
	public static function getGameInfo(){
		$db = self::__instance();
		$sql = 'select gameid,gamename from '.self::$game_info;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getRoomDetail 获取房间内的玩家信息列表]
	 * @Author   李龙
	 * @DateTime 2018-09-06T13:38:59+0800
	 * @param    [type]                   $setid [description]
	 * @return   [type]                          [description]
	 */
	public static function getRoomDetail($setid){
		if(empty($setid)) return ;
		$db = self::__instance();
		$sql = 'select osd.userid,ui.nickname,osd.moneynum from '.self::$order_settlement_detail.' osd left join '.self::$user_info.' ui on ui.userid = osd.userid where osd.setid = '.$setid;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}
}