<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class Touch extends Base {
	
	public static function updateiospayswitch($user_data) {
		$db = self::__instance ();
		$condition=array("k"=>'iospayswitch');
		$id = $db->update ( 'osa_t_config', $user_data, $condition );
		return $id;
	}
	public static function getiospayswitch() {
		$db = self::__instance ();
		$data = array (
				"iospayswitch" => 0,
		);
		$sql = "select * from osa_t_config  where  k in('iospayswitch')";
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			foreach ( $list as $k => $v ) {
				$data[$v['k']] = $v['value'];
			}
		}
		return $data;
	}
	public static function updateNotice($user_id,$user_data) {
		if (! $user_data || ! is_array ( $user_data )) {
			return false;
		}
		$db=self::__instance();
		$condition=array("id"=>$user_id);
		$id = $db->update ( 'osa_t_notice', $user_data, $condition );
		return $id;
	}
	public static function getTouchById($id) {
	
		$db = self::__instance ();
		$sql = "select *  from osa_t_touch_recode  where id=$id";
		//echo  $sql;
		$list = $db->query ( $sql )->fetch (); // self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	public static function delNotice($id) {
		if (! $id || ! is_numeric ( $id )) {
			return false;
		}
		$db=self::__instance();
		$condition = array("id"=>$id);
		$result = $db->delete ('osa_t_notice', $condition );
		return $result;
	}
	/**
	 * 修改对碰
	 * @param unknown $id
	 * @param unknown $data
	 */
	public static function updateTouch($id, $data) {
		if (! $data || ! is_array ( $data )) {
			return false;
		}
		$db = self::__instance ();
		$condition = array (
				"id" => $id
		);
		$id = $db->update ( "osa_t_touch_recode", $data, $condition );
		return $id;
	}
	/**
	 * 
	 * @param unknown $data
	 * @return boolean|PDOStatement
	 */
	public static function updateTouchStatus($data) {
		if (! $data || ! is_array ( $data )) {
			return false;
		}
		//echo 'update osa_t_touch_recode set status=' . $data['status'] . ' ,note= ' . $data['note'] . ' where id=' . $data['id']  ;
		$db = self::__instance ();
		$list = $db->query ( 'update osa_t_touch_recode set status=' . $data['status'] . ' ,note= "' . $data['note'] . '" where id=' . $data['id'] );
		if ($list) {
			return $list;
		}
		return array ();
	}
	/**
	 * 获取对碰条数
	 * @param string $condition
	 * @return number
	 */
	public static function count($condition = '') {
		$db=self::__instance();
		$num = $db->count ( 'osa_t_touch_recode', $condition );
		return $num;
	}
	/**
	 * 获取所有对碰
	 * @param string $start
	 * @param string $page_size
	 */
	public static function getAllTouch( $agent_uid , $start ='' ,$page_size='' ) {
		$db=self::__instance();
		$limit ="";
		if($page_size){
			$limit =" limit $start,$page_size ";
		}
		$where = "";
		
		if($agent_uid)
		{
			$where=' where touch_uid = '.$agent_uid;
		}
		
		$sql = "select * from osa_t_touch_recode $where order by create_time desc $limit";
		
		$list=$db->query($sql)->fetchAll();
		if ($list) {
			return $list;
		}
		return array ();
	}
	public static function addNotice($data) {
		if (! $data || ! is_array ( $data )) {
			return false;
		}
		$db = self::__instance ();
		$id = $db->insert ( 'osa_t_notice', $data );
		return $id;
	}
	
}