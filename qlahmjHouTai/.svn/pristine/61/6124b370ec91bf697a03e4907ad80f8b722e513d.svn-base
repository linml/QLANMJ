<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class TransferRecord extends Base {

	/*已经用到的*/
	public static function getAllTransferRecordCount($agentid ='' ,$topAgent='', $type = '',$m_type='',$startDate ='',$endDate = '') {
		$db = self::__instance ();
		$where=" where 1 = 1 ";
		if($type){
			$where.=" and istop = $type";
		}
		if($topAgent){
			$where.=" and eid = 0";
		}
		if($agentid){
			$where.=" and agentid ='$agentid' or nickname  like '%$agentid%' ";
		}
		if($m_type){
			$where = $where.' and type = '.$m_type;
		}
		if($startDate){
			$where = $where." and date(addtime) >= '".$startDate."' ";
		}
		if($endDate){
			$where = $where." and date(addtime) <= '".$endDate."' ";
		}
		$sql ="select COUNT(*) as count  from (

				(select eid,dl_uid,nickname ,type,addtime from pigcms_traded_admin_log) t1

				LEFT JOIN

				(select id, user_game_id as agentid ,istop from pigcms_dl_users) t2

				ON  t1.dl_uid = t2.id

			) $where ";
			// var_dump($sql);
		return 0 + ($db->query ($sql)->fetchColumn ());
	}

	/**
	 * 获取代理商列表
	 * 
	 * @param string $start        	
	 * @param string $page_size        	
	 */
	public static function getAllTransferRecord($agentid ='' ,$topAgent='', $type = '' ,$m_type='',$startDate ='',$endDate = '',$start = '', $page_size = '') {
		$db = self::__instance (); 	
		$limit = "";
		$where=" where 1 = 1 ";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		if($type){
			$where.=" and istop = $type";
		}
		if($topAgent){
			$where.=" and eid = 0";
		}
		if($agentid){
			$where.=" and agentid =  '$agentid' or nickname like '%$agentid%' ";
		}
		if($m_type){
			$where = $where.' and type = '.$m_type;
		}
		if($startDate){
			$where = $where." and date(addtime) >= '".$startDate."' ";
		}
		if($endDate){
			$where = $where." and date(addtime) <= '".$endDate."' ";
		}
		$sql ="select agentid ,nickname ,istop,traded_num,traded_info,traded_money,IF(eid=0,'官方', agentTopid) as agentTopid,IF(eid=0,'官方',rechargePerson) as rechargePerson,type,adminName,addtime from (

				(select eid,dl_uid,traded_num,traded_info,traded_money,nickname,type,adminName,addtime from pigcms_traded_admin_log) t1 

				LEFT JOIN

				(select id, user_game_id as agentid ,istop,flowpoint from pigcms_dl_users) t2

				ON  t1.dl_uid = t2.id

				LEFT JOIN 

				(select id,user_game_id as agentTopid ,nickName as rechargePerson from pigcms_dl_users) t3

				ON t1.eid = t3.id
			) $where order by addtime desc $limit ";

		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}

}