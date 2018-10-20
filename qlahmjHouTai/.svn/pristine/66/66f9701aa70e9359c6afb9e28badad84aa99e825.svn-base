<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class AgentReports extends Base {

	/*已经用到的*/
	public static function getAllAgentReportsCount($agentid ='' ,$t1Agent='', $type = '') {
		$db = self::__instance ();
		$where=" where 1 = 1 ";
		if($type){
			$where.=" and istop =$type ";
		}
		if($agentid){
			$where.=" and user_game_id ='$agentid' or gName like '%$agentid%' ";
		}
		if($t1Agent){
			$where.="and t1UserId = '$t1Agent' or directName like '%$t1Agent%'";
		}
		$sql ="select COUNT(user_game_id) as count  from (

			(select s_id as s1 ,user_game_id,nickName as gName,weChat,tel,istop,addtime from pigcms_dl_users) t1 

			LEFT JOIN 

			(select id,user_game_id as t1UserId ,nickName as directName from pigcms_dl_users ) t2 

			ON t1.s1 = t2.id
			
		) $where ";
		return 0 + ($db->query ($sql)->fetchColumn ());
	}

	/**
	 * 获取代理商列表
	 * 
	 * @param string $start        	
	 * @param string $page_size        	
	 */
	public static function getAllAgentReports($agentid ='' ,$t1Agent='', $type = '' ,$start = '', $page_size = '') {
		$db = self::__instance (); 	
		$limit = "";
		$where=" where 1 = 1 ";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		if($type){
			$where.=" and istop =$type";
		}
		if($agentid){
			$where.=" and user_game_id =  '$agentid' or nickName like '%$agentid%' ";
		}
		if($t1Agent){
			$where.="and t1UserId = '$t1Agent' or directName like '%$t1Agent%'";
		}
		$sql ="SELECT user_game_id, nickName, istop, IFNULL(fx_money, 0) AS fx_money, IFNULL(tx_money, 0) AS tx_money, Cash, cardNum, IFNULL(count, 0) AS count, IFNULL(top2, 0) AS top2, IFNULL(top3, 0) AS top3 FROM (

			( SELECT dl.id,s_id , dl.user_game_id, dl.nickName, dl.istop, ROUND(dl.Cash / 100, 2) AS Cash, dl.cardNum, addtime FROM pigcms_dl_users dl ) t1

			LEFT JOIN 

			(select id,user_game_id as t1UserId ,nickName as directName from pigcms_dl_users ) t2 ON t1.s_id = t2.id

			LEFT JOIN 

			( SELECT ROUND(SUM(fx_count) / 100, 2) AS fx_money, eid, userid FROM pigcms_cash_add_log GROUP BY eid HAVING eid != userid ) t3 ON t1.id = t3.eid

			LEFT JOIN 

			( SELECT ROUND(SUM(money / 100), 2) AS tx_money, eid FROM pigcms_cash_log WHERE ispay = 1 GROUP BY eid  ) t4 ON t1.id = t4.eid

					LEFT JOIN 

			( SELECT s_id, count( CASE WHEN istop = 2 THEN istop END ) AS top2, count( CASE WHEN istop = 3 THEN istop END ) AS top3 FROM pigcms_dl_users GROUP BY s_id ) t5 ON t1.id = t5.s_id

					LEFT JOIN 

			( SELECT COUNT(*) AS count, CODE FROM pigcms_game_user GROUP BY `code` ) t6 ON t1.user_game_id = t6.`code`

		) $where ORDER BY addtime desc $limit";

		$list = $db->query ( $sql )->fetchAll ();
		foreach ($list as $key => $value) {
			$list[$key]['money'] = self::getAgentAllCashByagentid($list[$key]['user_game_id'])/100;
		}
		if ($list) {
			return $list;
		}
		return array ();
	}

	//获取代理绑定的代理
	//
	public static function getAgentByAgentId($aid){
		$db = self::__instance();
		$sql="select id,user_game_id,nickName,cardNum from pigcms_dl_users where user_game_id =".$aid;
		$result = $db->query($sql)->fetchAll();
		if($result) return $result;
		return array();
	}

	// 代理后台充值钻石
	public static function updateAgentGemByAgentId($agentid,$gems){
		$db = self::__instance();
		$sql ="UPDATE pigcms_dl_users SET cardNum = cardNum + ".$gems." WHERE id =  ".$agentid;
		$db->query($sql);
	}

	public static function insertAgentReportsRecord($reportData) {
		if (!$reportData || ! is_array ( $reportData )) {
			return false;
		}
		$db=self::__instance();
		$id = $db->insert ( "pigcms_traded_admin_log", $reportData );
		return $id;
	}

	//获取代理充值金额
	public static function getAgentAllCashByagentid($agentid){
		$db = self::__instance(pigcms_game);
		$sql="SELECT sum(amount) FROM yxpay WHERE to_user IN (select m_lUid from ninedt_user WHERE m_lAgent = $agentid) and status=2";
		return 0+$db->query($sql)->fetchColumn();
	}

}	