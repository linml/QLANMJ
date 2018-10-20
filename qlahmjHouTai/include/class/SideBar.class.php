<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class SideBar {
	
	//显示可见菜单
	const SHOW_MENU = 1;
	
	/**
	 * [getTree 获取侧边栏数据树]
	 * @Author   李爽
	 * @DateTime 2018-07-26T15:38:53+0800
	 * @return   [type]                   [结果集]
	 */
	public static function getTree() {
		//功能菜单
		$data = array ();
		$data = Module::getAllModules(1);
		$user_info = UserSession::getSessionInfo();
		//用户的权限
		$access = MenuUrl::getMenuByRole ( $user_info['user_role'] );
		foreach ( $data as $k => $module ) {
			$list = MenuUrl::getlistByModuleId ($module['module_id'],'sidebar' );
			if (! $list) {
				unset ( $data[$k] );
				continue;
			}
			//去除无权限访问的
			foreach ( $list as $key => $value ) {
				if (! in_array ( $value['menu_url'], $access )) {
					unset ( $list[$key] );
				}
			}
			$data[$k]['menu_list'] = $list;
		}
		return $data;
	}
	
	public static function getMenuShortCuts() {
		$user_info = UserSession::getSessionInfo ();
		//功能菜单
		$data = array ();
		$data = Module::getAllModule ();
		$user_info = UserSession::getSessionInfo();
		//用户的权限
		$access = MenuUrl::getMenuByRole ( $user_info['user_role'] );
		foreach ( $data as $k => $module ) {
			$list = MenuUrl::getlistByModuleId ('shortcut' , $module['module_id']);
			if (! $list) {
				unset ( $data[$k] );
				continue;
			}
			//去除无权限访问的
			foreach ( $list as $key => $value ) {
				if (! in_array ( $value['menu_url'], $access )) {
					unset ( $list[$key] );
				}
			}
			$data[$k]['menu_list'] = $list;
		}
		return $data;
	}
	
}