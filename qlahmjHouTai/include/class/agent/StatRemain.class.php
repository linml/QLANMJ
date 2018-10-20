<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class StatRemain extends Base {
	

	/**
	 * 获取玩家总数
	 * @return number
	 */
	public static function getSumCount() {
		$db = self::__instance ();
		return 0 + ($db->query ( "select count(*) from osa_t_stat_remain order by stat_time desc" )->fetchColumn ());
	}
	/**
	 * 查询获取玩家总数
	 * @param unknown $st
	 * @param unknown $et
	 * @return number
	 */
	public static function getSumCountSearch($st,$et) {
		$db = self::__instance ();
		return 0 + ($db->query ( "select count(*) 
				from osa_t_stat_remain 
				where date(stat_time)>='$st' and date(stat_time)<='$et'
				order by stat_time desc" )->fetchColumn ());
	}
	/**
	 * 获取玩家列表
	 * @param string $start
	 * @param string $page_size
	 */
	public static function getAllSum($start = '', $page_size = '') {
		$db = self::__instance ();
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		$sql = "select s.dru,s.login_count,s.second_day,s.third_day,s.seventh_day,s.fourteen_day,s.thirtieth_day,date(s.stat_time)  dt 
		from osa_t_stat_remain s order by stat_time desc
		$limit";
		
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}
	/**
	 * 查询
	 * @param string $start
	 * @param string $page_size
	 */
	public static function getAllSumSearch($st,$et,$start = '', $page_size = '') {
		$db = self::__instance ();
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		$sql = "select s.dru,s.login_count,s.second_day,s.third_day,s.seventh_day,s.fourteen_day,s.thirtieth_day,date(s.stat_time)  dt 
		from osa_t_stat_remain s 
		where date(s.stat_time)>='$st' and date(s.stat_time)<='$et'
		order by stat_time desc
		$limit";
	
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}
	
}