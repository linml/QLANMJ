<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class AgentAnalysis extends Base {

	/*已经用到的*/
	public static function getAllAgentAnalysisCount($agentid ='' , $topAgent ='' , $type = '') {
		$db = self::__instance ();
		$where=" where 1 = 1 ";
		if($type){
			$where.=" and istop =$type ";
		}
		if($agentid){
			$where.=" and user_game_id ='$agentid' or nickName like '%$agentid%' ";
		}

		if($topAgent){
			$where .= " and topAgent = $topAgent";
		}

		$sql ="SELECT COUNT(user_game_id) as count  from (

			(SELECT s_id,user_game_id,nickName,istop  from pigcms_dl_users ) tb1

			LEFT JOIN

			(SELECT id,user_game_id as topAgent FROM pigcms_dl_users ) tb2

			ON tb1.s_id = tb2.id

		) $where ";
		return 0 + ($db->query ($sql)->fetchColumn ());
	}

	/**
	 * 获取代理商列表
	 * 
	 * @param string $start        	
	 * @param string $page_size      
	 *   	
	 */
	public static function getAllAgentAnalysis($agentid ='' , $topAgent ='' ,$type = '' ,$start = '', $page_size = '',$startDate ='',$endDate = '') {
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

		if($topAgent){
			$where .= " and topAgent = $topAgent";
		}

		if($startDate){
			$wh_t .=" and date(addtime) >= '".$startDate."' ";
		}
		if($endDate){
			$wh_t .= " and date(addtime) <= '".$endDate."' ";
		}

		$sql ="SELECT user_game_id,nickName,istop,IFNULL(cz_num,0) as cz_num,IFNULL(cz_money,0) as cz_money,IFNULL(cz_d_money,0) as cz_d_money,

		IFNULL(yqfx_num,0) as yqfx_num,IFNULL(zjfx_num,0) as zjfx_num/*,IFNULL(bjfx_num,0) as bjfx_num,IFNULL(hxfx_num,0) as hxfx_num*/ FROM (

		(SELECT id,s_id,user_game_id,nickName,istop ,addtime from pigcms_dl_users ) tb1

		LEFT JOIN

		(SELECT dl_uid,SUM(traded_num) as cz_num,IFNULL(SUM(traded_money),0) as cz_money FROM pigcms_traded_admin_log WHERE eid = 0 $wh_t GROUP BY dl_uid ) tb2

		ON tb1.id = tb2.dl_uid

		LEFT JOIN 

		(SELECT eid ,ROUND(SUM(cz_count),2) as cz_d_money from pigcms_cash_add_log tp1 WHERE yqfx_type = 0 AND userid IN (SELECT userid FROM pigcms_game_user WHERE `code` =  (SELECT user_game_id FROM pigcms_dl_users WHERE id = tp1.eid)) $wh_t GROUP BY eid
		) tb3
		
		ON tb1.id = tb3.eid

		LEFT JOIN 

		(SELECT eid,ROUND(SUM(fx_count/100),2) as yqfx_num FROM pigcms_cash_add_log tp1 WHERE yqfx_type > 0 AND userid IN (SELECT userid FROM pigcms_game_user WHERE `code` =  (SELECT user_game_id FROM pigcms_dl_users WHERE id = tp1.eid)) $wh_t GROUP BY eid ) tb4

		ON tb1.id = tb4.eid
		
		LEFT JOIN

		(SELECT eid,ROUND(SUM(fx_count/100),2) as zjfx_num FROM pigcms_cash_add_log tp1 WHERE userid IN (SELECT userid FROM pigcms_game_user WHERE `code` =  (SELECT user_game_id FROM pigcms_dl_users WHERE id = tp1.eid)) $wh_t GROUP BY eid) tb5

		ON tb1.id = tb5.eid

		LEFT JOIN 

		(SELECT id,user_game_id as topAgent FROM pigcms_dl_users ) tb6

		ON tb1.s_id = tb6.id

		/*LEFT JOIN

		(SELECT eid,s_id,ROUND(SUM(fx_count/100),2) as bjfx_num FROM ( 

			(select eid,fx_count,userid FROM pigcms_cash_add_log) tp1

			LEFT JOIN 

			(SELECT id,s_id ,istop FROM pigcms_dl_users ) tp2

			ON tp1.eid = tp2.id
		)

		WHERE userid IN (SELECT userid FROM pigcms_game_user WHERE `code` = (SELECT user_game_id FROM pigcms_dl_users WHERE id =  tp1.eid))

		AND (SELECT istop FROM pigcms_dl_users WHERE id = tp2.s_id) = 2

		GROUP BY s_id,eid ) tb6

		ON tb1.id = tb6.eid

		LEFT JOIN 

		(SELECT eid,s_id,ROUND(SUM(fx_count/100),2) as hxfx_num FROM ( 

			(select eid,fx_count,userid FROM pigcms_cash_add_log) tp1

			LEFT JOIN 

			(SELECT id,s_id ,istop FROM pigcms_dl_users ) tp2

			ON tp1.eid = tp2.id
		)

		WHERE userid IN (SELECT userid FROM pigcms_game_user WHERE `code` = (SELECT user_game_id FROM pigcms_dl_users WHERE id =  tp1.eid))

		AND (SELECT istop FROM pigcms_dl_users WHERE id = tp2.s_id) = 1

		GROUP BY s_id,eid )tb7

		ON tb1.id = tb7.eid*/
		) $where ORDER BY cz_d_money DESC $limit";
		// var_dump($sql);
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}

}	