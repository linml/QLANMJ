<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class Notice extends Base {
	
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
	public static function getswitch($type) {
		$db = self::__instance ();
		$data = array (
				"switch" => 0,
		);
		$sql = "select * from osa_t_config  where  k in('$type')";
		$list = $db->query ( $sql )->fetch ();
		if ($list) {
			
				$data['switch'] = $list['value'];
			
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
	public static function getNoticeById($id) {
	
		$db = self::__instance ();
		$sql = "select *  from osa_t_notice  where id=$id";
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
	public static function count($condition = '') {
		$db=self::__instance();
		$num = $db->count ( 'osa_t_notice', $condition );
		return $num;
	}
	public static function getAllNotice( $start ='' ,$page_size='' ) {
		$db=self::__instance();
		$limit ="";
		if($page_size){
			$limit =" limit $start,$page_size ";
		}
		$sql = "select * from osa_t_notice order by create_time desc $limit";
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