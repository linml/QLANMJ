<?php 
if(!defined('ACCESS')) {
	exit('Access denied.');
}

class FriendsCircleInfo extends Base {
	// 表名
	private static $friend_info = 'friend_info';
	private static $friend_game = 'friend_game';
	private static $friend_user = 'friend_user';
	private static $game_info   = 'game_info';
	private static $user_info   = 'user_info'; 
	/**
	 * [getFriendInfo 亲友圈信息]
	 * @Author   李龙
	 * @DateTime 2018-08-07T17:15:39+0800
	 * @param    string                   $friendid [朋友圈id]
	 * @return   [array]                             [朋友圈信息]
	 */
	public static function getFriendInfo($friendid = ''){
		if(empty($friendid)) return ;
		$db =self:: __instance();
		$sql = 'select fi.friendid,fi.friendname,fi.addtime,ui.nickname,gi.gamename,(select count(*) from '.self::$friend_user.' where friendid = '.$friendid.') as counts from '.self::$friend_info.' as fi left join '.self::$friend_game.' as fg on fi.friendid=fg.friendid left join '.self::$game_info.' as gi on fg.gameid=gi.gameid left join '.self::$user_info.' as ui on fi.userid = ui.userid where fi.friendid = '.$friendid;
		$result = $db->query($sql)->fetch();
		if($result){
			return $result;
		}
		return array();
	}
}



