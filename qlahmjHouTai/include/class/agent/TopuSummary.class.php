<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class TopuSummary extends Base {
	
	/**
	 * 获取玩家总数
	 *
	 * @return number
	 */
	public static function getSumCount() {
		$db = self::__instance ();
		return 0 + ($db->query ( "select count(dt)
				from (
				select date( o.create_time) dt ,sum(o.payment) payment
				from osa_t_order o
				where o.`status` = 1 

				group by  date( o.create_time)
				) c
				" )->fetchColumn ());
	}
	/**
	 * 查询获取玩家总数
	 *
	 * @return number
	 */

	public static function getSumCountSearch($st, $et) {
		$db = self::__instance ();
		return 0 + ($db->query ( "select count(dt)
				from (
				select date( o.create_time) dt ,sum(o.payment) payment
				from osa_t_order o
				where o.`status` = 1
						and date( o.create_time) >='$st' and date( o.create_time) <='$et'
				group by  date( o.create_time)
				) c
				" )->fetchColumn ());
	}
	/**
	 * 获取玩家列表
	 *
	 * @param string $start        	
	 * @param string $page_size        	
	 */
	public static function getAllSum($start = '', $page_size = '') {
		$db = self::__instance ();
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		$sql = "select date( o.create_time) dt ,sum(o.payment) payment,count(distinct(uid))as usercount,count(1) as ordercount
				from osa_t_order o
				where o.`status` = 1 

				group by  date( o.create_time)

				order by  date(o.create_time) desc $limit";
		
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
	public static function getAllSumSearch($st, $et,$start = '', $page_size = '') {
		$db = self::__instance ();
		$limit = "";
		if ($page_size) {
			$limit = " limit $start,$page_size ";
		}
		$sql = "select date( o.create_time) dt ,sum(o.payment) payment,count(distinct(uid))as usercount,count(1) as ordercount
		from osa_t_order o
		where o.`status` = 1
		and date( o.create_time) >='$st' and date( o.create_time) <='$et'
		group by  date( o.create_time)
	
		order by  date(o.create_time) desc $limit";
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			return $list;
		}
		return array ();
	}

	
	public static function getPaymentSummaryInfo($st, $et){
		$db = self::__instance ();
		$sql = "select sum(o.payment) payment,count(distinct(uid))as usercount,count(1) as ordercount
		from osa_t_order o ";
		$where = " where o.`status` = 1 ";
		if(!empty($st)){
			$where = $where." and date( o.create_time) >='$st' ";
		}
		if(!empty($et)){
			$where = $where." and date( o.create_time) <='$et' ";
		}
		$sql = $sql.$where;
		// var_dump($sql);
		$list = $db->query ( $sql )->fetch();
		if ($list) {
			return $list;
		}
		return array ();
	}
}