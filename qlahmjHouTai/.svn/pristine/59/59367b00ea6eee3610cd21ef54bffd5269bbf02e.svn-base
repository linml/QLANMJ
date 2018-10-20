<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class StrongUpdate extends Base {
	
	// 表名
	private static $table_name = 'module';
	// 查询字段
	private static $columns = 'id, versoin, ios, ios_url, android,android_url,create_time,update_time';
	
	public static function getTableName(){
		return parent::$table_prefix.self::$table_name;
	}
	
	//列表 
	public static function getAllModules() {
		$db=self::__instance();
		$conditon=array();
		
		$order = ' create_time desc';
		$condition['ORDER']=$order;
		$list = $db->select ( "osa_t_versoin", self::$columns, $condition );
		if ($list) {
			return $list;
		}
		return array ();
	}
	
	public static function addModule($module_data) {
		if (! $module_data || ! is_array ( $module_data )) {
			return false;
		}
		$db=self::__instance();
		$id = $db->insert ( 'osa_t_versoin', $module_data );
		return $id;
	}
	
	public static function getModuleById($module_id) {
		if (! $module_id || ! is_numeric ( $module_id )) {
			return false;
		}
		$db=self::__instance();
		$condition['module_id'] = $module_id;
		$list = $db->select ( self::getTableName(), self::$columns, $condition );
		if ($list) {
			return $list[0];
		}
		return array ();
	}
	
	public static function getModuleByName($module_name) {
		if (! $module_name) {
			return false;
		}
		$db=self::__instance();
		$condition['versoin'] = $module_name;
		$list = $db->select ( 'osa_t_versoin',  self::$columns, $condition );
		if ($list) {
			return $list[0];
		}
		return array ();
	}
	
	public static function getModuleMenu($module_id) {
		if (! $module_id || ! is_numeric ( $module_id )) {
			return false;
		}
		$db=self::__instance();
		$sql="select * from osa_t_versoin where id=$module_id";
		$list = $db->query($sql)->fetchAll();
		if ($list) {
			return $list[0];
		}
		return array ();
	}
	
	public static function updateModuleInfo($module_id,$module_data) {
		if (! $module_data || ! is_array ( $module_data )) {
			return false;
		}
		$db=self::__instance();
		$condition=array("module_id"=>$module_id);
		$id = $db->update ( self::getTableName(), $module_data, $condition );
		return $id;
	}
	
	public static function delModule($module_id) {
		if (! $module_id || ! is_numeric ( $module_id )) {
			return false;
		}
		$db=self::__instance();
		$condition = array("id"=>$module_id);
		$result = $db->delete ( "osa_t_versoin", $condition );
		return $result;
	}
	
	public static function getModuleForOptions() {
		$module_options_array = array ();
		$module_list = self::getAllModules (1);
		foreach ( $module_list as $module ) {
			$module_options_array[$module['module_id']] = $module['module_name'];
		}
		return $module_options_array;
	}
	
}