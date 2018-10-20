<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class OnlinePlayer extends Base {
	
	
	public static function getGamesCount() {
		$db = self::__instance ();
		return 0 + ($db->query ( "select count(*) from (
					select tu0.*,inv.parent_uid,ag.agent_uid, r0.uuid,FROM_UNIXTIME(r0.create_time, '%Y-%m-%d %H:%i:%S') as rt
					from t_rooms r0
					left join t_users tu0 on r0.user_id0 = tu0.userid
					left join osa_t_invitecode inv on tu0.userid=inv.uid
					left join osa_t_agent ag on tu0.userid=ag.agent_uid
					where  r0.user_id0 is not null and  r0.user_id0 !=0
					union

					select tu1.*,inv.parent_uid,ag.agent_uid, r1.uuid,FROM_UNIXTIME(r1.create_time, '%Y-%m-%d %H:%i:%S') as rt
					from t_rooms r1
					left join t_users tu1 on r1.user_id1 = tu1.userid
					left join osa_t_invitecode inv on tu1.userid=inv.uid
					left join osa_t_agent ag on tu1.userid=ag.agent_uid
					where  r1.user_id1 is not null and  r1.user_id1 !=0
					union

					select tu2.*,inv.parent_uid,ag.agent_uid, r2.uuid,FROM_UNIXTIME(r2.create_time, '%Y-%m-%d %H:%i:%S') as rt
					from  t_rooms r2 
					left join t_users tu2 on r2.user_id2 = tu2.userid
					left join osa_t_invitecode inv on tu2.userid=inv.uid
					left join osa_t_agent ag on tu2.userid=ag.agent_uid
					where  r2.user_id2 is not null and  r2.user_id2 !=0
					union

					select tu3.*,inv.parent_uid,ag.agent_uid, r3.uuid,FROM_UNIXTIME(r3.create_time, '%Y-%m-%d %H:%i:%S') as rt
					from  t_rooms r3 
					left join t_users tu3 on r3.user_id3 = tu3.userid
					left join osa_t_invitecode inv on tu3.userid=inv.uid
					left join osa_t_agent ag on tu3.userid=ag.agent_uid
					where  r3.user_id3 is not null and  r3.user_id3 !=0
		) t 
				" )->fetchColumn ());
	}
	/**
	 * 获取房间
	 *
	 * @return number
	 */

	public static function getGames($start = '', $page_size = '') {
		$db = self::__instance ();
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		$sql = "select * from (
					select tu0.*,inv.parent_uid,ag.agent_uid, r0.uuid,FROM_UNIXTIME(r0.create_time, '%Y-%m-%d %H:%i:%S') as rt
					from t_rooms r0
					left join t_users tu0 on r0.user_id0 = tu0.userid
					left join osa_t_invitecode inv on tu0.userid=inv.uid
					left join osa_t_agent ag on tu0.userid=ag.agent_uid
					where  r0.user_id0 is not null and  r0.user_id0 !=0
					union

					select tu1.*,inv.parent_uid,ag.agent_uid, r1.uuid,FROM_UNIXTIME(r1.create_time, '%Y-%m-%d %H:%i:%S') as rt
					from t_rooms r1
					left join t_users tu1 on r1.user_id1 = tu1.userid
					left join osa_t_invitecode inv on tu1.userid=inv.uid
					left join osa_t_agent ag on tu1.userid=ag.agent_uid
					where  r1.user_id1 is not null and  r1.user_id1 !=0
					union

					select tu2.*,inv.parent_uid,ag.agent_uid, r2.uuid,FROM_UNIXTIME(r2.create_time, '%Y-%m-%d %H:%i:%S') as rt
					from  t_rooms r2 
					left join t_users tu2 on r2.user_id2 = tu2.userid
					left join osa_t_invitecode inv on tu2.userid=inv.uid
					left join osa_t_agent ag on tu2.userid=ag.agent_uid
					where  r2.user_id2 is not null and  r2.user_id2 !=0
					union

					select tu3.*,inv.parent_uid,ag.agent_uid, r3.uuid,FROM_UNIXTIME(r3.create_time, '%Y-%m-%d %H:%i:%S') as rt
					from  t_rooms r3 
					left join t_users tu3 on r3.user_id3 = tu3.userid
					left join osa_t_invitecode inv on tu3.userid=inv.uid
					left join osa_t_agent ag on tu3.userid=ag.agent_uid
					where  r3.user_id3 is not null and  r3.user_id3 !=0
		) t order by rt desc
		$limit";
	
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}
	
	
}