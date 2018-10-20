<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class AgentPurchase extends Base {

	/*已经用到的*/
		public static function getAllAgentPurchaseCount($agentid ='' , $type = '') {
		$db = self::__instance ();
		$where=" where 1 = 1 ";
		if($agentid){
			$where.=" and user_game_id ='$agentid' or nickname = '$agentid' ";
		}
		if($type){
			$where.=" and istop = $type ";
		}
		$sql ="select COUNT(*) as count  from (

				(select dl_uid,nickname from pigcms_traded_admin_log WHERE eid = 0) t1

				LEFT JOIN

				(select id, user_game_id from pigcms_dl_users) t2

				ON  t1.dl_uid = t2.id

			) $where ";

		return 0 + ($db->query ($sql)->fetchColumn ());
	}

	/**
	 * 获取代理商列表
	 * 
	 * @param string $start        	
	 * @param string $page_size        	
	 */
	public static function getAllAgentPurchase($agentid ='' , $type = '' ,$start = '', $page_size = '') {
		$db = self::__instance (); 	
		$limit = "";
		$where=" where 1 = 1 ";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		if($agentid){
			$where.=" and user_game_id =  '$agentid' or nickname = '$agentid' ";
		}
		if($type){
			$where.=" and istop = $type";
		}
	
		$sql ="select user_game_id ,IFNULL(rechargePerson,'管理员') as rechargePerson,tel,nickname,istop,flowpoint,traded_num,addtime from (

				(select eid,dl_uid,traded_num,nickname,addtime from pigcms_traded_admin_log WHERE eid = 0) t1

				LEFT JOIN

				(select id, user_game_id ,tel,istop,flowpoint from pigcms_dl_users) t2

				ON  t1.dl_uid = t2.id

				LEFT JOIN 

				(select id,nickName as rechargePerson from pigcms_dl_users) t3

				ON t1.eid = t3.id
			) $where $limit";
		//echo  $sql;
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}

}