<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class ClubManage extends Base {
	private static $friend_info = 'friend_info';
	private static $friend_game = 'friend_game';
	private static $friend_user = 'friend_user';
	private static $agent_info = 'agent_info';
	private static $user_info = 'user_info';
	private static $game_info = 'game_info';
	private static $friend_stat_day = 'friend_stat_day';

	/**
	 * [getWhere 筛选条件的处理]
	 * @Author   李龙
	 * @DateTime 2018-09-03T18:27:01+0800
	 * @param    string                   $id       [类型]
	 * @param    string                   $contains [内容]
	 * @return   [type]                             [description]
	 */
	public static function getWhere($id='',$contains=''){
		if(!empty($id)&&!empty($contains)) $where = " and $id = $contains";else $where = '';
		return $where;
	}

	/**
	 * [getFriendInfo 成员信息]
	 * @Author   李龙
	 * @DateTime 2018-09-03T18:25:24+0800
	 * @param    string                   $where     [筛选条件]
	 * @param    string                   $start     [开始]
	 * @param    string                   $page_size [页数目]
	 * @param    string                   $order     [排序]
	 * @return   [type]                              [description]
	 */
	public static function getFriendInfo($where='',$start='',$page_size='',$order=''){
		if(empty($page_size)) return;else $limit = " limit $start,$page_size";
		if(empty($order)) $order = " order by fi.addtime desc ";else $order = " order by members ".$order;
		$db = self::__instance();
		$sql = 'SELECT
					fi.addtime,
					fi.userid,				
					fi.friendid,
					fi.friendname,				
					count(fu.userid) AS members
				FROM
					friend_info fi
				LEFT JOIN friend_user fu ON fi.friendid = fu.friendid where fi.status = "1" '.$where.'
				GROUP BY fi.friendid '.$order.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		foreach ($result as $key => $value) {
			$result[$key] = array_merge($result[$key], self::getRuleDesc($result[$key]['friendid']));
			$result[$key] = array_merge($result[$key], self::getNickName($result[$key]['userid']));
		}
		if($result) return $result;else return array();
	}	

	public static function getRuleDesc($friendid=''){
		if(empty($friendid)) return ;
		$db = self::__instance();
		$sql = 'select ruledesc from friend_game where status = "1" and friendid = '.$friendid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}	
	public static function getNickName($userid){
		if(empty($userid)) return ;
		$db = self::__instance();
		$sql = 'select nickname from user_info where userid = '.$userid;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getFriendCount 获取亲友圈数目]
	 * @Author   李龙
	 * @DateTime 2018-09-03T18:00:56+0800
	 * @param    [type]                   $where [筛选条件]
	 * @return   [type]                          [返回数目]
	 */
	public static function getFriendCount($where){
		$db = self::__instance();
		$sql = 'SELECT
					count(fi.friendid)
				FROM
					friend_info fi
				WHERE fi.status = "1"
				 '.$where;
		return 0 + $db->query($sql)->fetchColumn();
	}

	/**
	 * [getFriendUserList 获取亲友圈玩家表]
	 * @Author   李龙
	 * @DateTime 2018-09-06T14:38:30+0800
	 * @param    [type]                   $friendid [亲友圈ID]
	 * @return   [type]                             [description]
	 */
	public static function getFriendUserList($friendid){
		if(empty($friendid)) return;
		$db = self::__instance();
		$sql = 'select fu.userid,fu.isadmin,fu.addtime,ui.nickname from '.self::$friend_user.' fu left join '.self::$user_info.' ui on fu.userid = ui.userid where fu.friendid = '.$friendid;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getFriendData 获取亲友圈的信息]
	 * @Author   李龙
	 * @DateTime 2018-09-06T15:29:48+0800
	 * @param    [type]                   $friendid [亲友圈ID]
	 * @return   [type]                             [description]
	 */
	public static function getClubData($friendid){
		if(empty($friendid)) return;
		$db = self::__instance();
		$sql = 'SELECT
					fsd.dateid,
					fsd.roomcnt,
					fsd.roomamt,
					gi.gamename
				FROM
					friend_stat_day fsd
				LEFT JOIN game_info gi ON gi.gameid = fsd.gameid
				WHERE
				DATE_FORMAT(fsd.dateid,"%Y-%m") = DATE_FORMAT(SYSDATE(),"%Y-%m")
				AND fsd.friendid = '.$friendid.' 
				ORDER BY fsd.dateid DESC ';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;
	}

	/**
	 * [disBand 解散亲友圈]
	 * @Author   李龙
	 * @DateTime 2018-10-13T11:51:38+0800
	 * @param    [type]                   $friendid [亲有圈ID]
	 * @return   [type]                             [description]
	 */
	public static function disBand($friendid){
		if(empty($friendid)) return;
		$db = self::__instance();
		$sql = 'update friend_info fi set fi.status = "0" where fi.friendid = '.$friendid;
		$result = $db->exec($sql);
		return 0 + $result;
	}
}