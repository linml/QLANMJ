<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class RechargeRecord extends Base {
	
	//获取充值记录
	public static function getRechargeRecord($agentid = '',$gameid = '' ,$m_type='',$startDate = '' ,$endDate = '',$start = '', $page_size = ''){
		$db=self::__instance(pigcms_game);
		$sql= "select created,IF(from_agent=1008,'官方',agentid) as agentid ,IF(from_agent=1008,'官方',agentName) as agentName,gameid,gameName,amount,`status`,total,openid,wxnick from (

				(select from_agent,to_user,amount ,`status`,created ,total,openid,wxnick from dailipay) t1 

				LEFT JOIN 

				(select m_lUid as agentid ,m_sNickName as agentName from ninedt_user )t2 

				ON t1.from_agent = t2.agentid

				LEFT JOIN 

				(select m_lUid as gameid ,m_sNickName as gameName from ninedt_user ) t3 

				ON t1.to_user = t3.gameid
			)";

		$where = " where 1 = 1 ";
		if($gameid){
			$where = $where.' and gameid = '.$gameid;
		}
		if($agentid){
			$where = $where.' and from_agent = '.$agentid;
		}
		if($m_type){
			$where = $where.' and openid = '.$m_type;
		}
		if($startDate){
			$where = $where." and date(created) >= '".$startDate."' ";
		}
		if($endDate){
			$where = $where." and date(created) <= '".$endDate."' ";
		}

		$where = $where.' order by created desc ';
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}

		$list = $db->query($sql.$where.$limit)->fetchAll();
		if ($list) {
			return $list;
		}
		return array ();
	}
	
	public static function getRechargeRecordCount($agentid = '' ,$gameid = '',$m_type='',$startDate = '' ,$endDate = ''){
		$db=self::__instance(pigcms_game);
		$sql= "select COUNT(*) as count from dailipay";

		$where = " where 1 = 1 ";
		if($gameid){
			$where = $where.' and to_user = '.$gameid;
		}
		if($agentid){
			$where = $where.' and from_agent = '.$agentid;
		}
		if($m_type){
			$where = $where.' and openid = '.$m_type;
		}
		if($startDate){
			$where = $where." and date(created) >= '".$startDate."' ";
		}
		if($endDate){
			$where = $where." and date(created) <= '".$endDate."' ";
		}

		$count = 0 + $db->query($sql.$where)->fetchColumn();

		return $count;
	}
	
}