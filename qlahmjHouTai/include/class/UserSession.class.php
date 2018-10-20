<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class UserSession {
	const SESSION_NAME = "session_admin";
	/**
	 * 代理商数据
	 * 
	 * @var unknown
	 */
	const SESSION_NAME_AGENT = "session_agent";

	public static function setSessionInfo($user_info) {
		$_SESSION[self::SESSION_NAME] = $user_info;
		return true;
	}


	public static function getSessionInfo() {
		$user_info = array ();
		$user_info = $_SESSION[self::SESSION_NAME];
		return $user_info;
	}
	
	/**
	 * 代理商cookie
	 * 
	 * @param unknown $Agent_info        	
	 * @return boolean
	 */
	public static function setSessionAgentInfo($Agent_info) {
		$_SESSION[self::SESSION_NAME_AGENT] = $Agent_info;
		return true;
	}

	/**
	 * 代理商cookie
	 * 
	 * @param unknown $Agent_info        	
	 * @return boolean
	 */
	public static function getSessionAgentInfo() {
		return $_SESSION[self::SESSION_NAME_AGENT];
	}

	/**
	 * cookie中获取代理商agent_uid
	 * 
	 * @return unknown
	 */
	public static function getAgentUid() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME_AGENT]['agent_uid'];
		return $agent_uid;
	}
	
	/**
	 * 代理级别
	 * 
	 * @return unknown
	 */
	/**
	 * [getAgentUserId 获取Session中代理的用户id]
	 * @Author   李龙
	 * @DateTime 2018-08-03T12:44:33+0800
	 * @return   [string]                   [userid]
	 */
	public static function getAgentUserId() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME_AGENT]['userid'];
		return $agent_uid;
	}
	/**
	 * [getAgentId 获取session中代理的id]
	 * @Author   李龙
	 * @DateTime 2018-08-03T14:49:17+0800
	 * @return   [type]                   [返回代理id]
	 */
	public static function getAgentId() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME_AGENT]['agentid'];
		return $agent_uid;
	}

	/**
	 * [getLevelId 获取登录等级]
	 * @Author   李爽
	 * @DateTime 2018-08-04T16:40:50+0800
	 * @return   [type]                   [返回等级]
	 */
	public static function getAgentLevelId(){
		return $_SESSION[self::SESSION_NAME_AGENT]['levelid'];
	}

	/**
	 * [getAgentParentId 获取当前玩家上级代理]
	 * @Author   李爽
	 * @DateTime 2018-08-06T13:31:58+0800
	 * @return   [type]                   [返回上级代理ID]
	 */
	public static function getAgentParentId(){
		return $_SESSION[self::SESSION_NAME_AGENT]['parentid'];
	}






	public static function getAgentType() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME_AGENT]['agent_type'];
		return $agent_uid;
	}

	public static function getAgentName() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME_AGENT]['agentname'];
		return $agent_uid;
	}
	public static function getAgentCard_number() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME_AGENT]['card_number'];
		return $agent_uid;
	}
	public static function getAgentId_number() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME_AGENT]['id_number'];
		return $agent_uid;
	}
	public static function getAgentPhone_number() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME_AGENT]['phone_number'];
		return $agent_uid;
	}


	public static function setAgentName($agent_uid) {
		$_SESSION[self::SESSION_NAME_AGENT]['name'] = $agent_uid;
		
	}
	public static function setAgentCard_number($agent_uid) {
		$_SESSION[self::SESSION_NAME_AGENT]['card_number'] = $agent_uid;
	}
	public static function setAgentId_number($agent_uid) {
		$_SESSION[self::SESSION_NAME_AGENT]['id_number'] = $agent_uid;
	}
	public static function setAgentPhone_number($agent_uid) {
		$_SESSION[self::SESSION_NAME_AGENT]['phone_number'] = $agent_uid;
	}
	
	
	/**
	 * cookie中获取代理商状态
	 * 
	 * @return unknown
	 */
	public static function getAgentStatus() {
		$agent_uid = '';
		$agent_uid = $_SESSION[self::SESSION_NAME]['status'];
		return $agent_uid;
	}
	public static function getUserName() {
		$user_name = '';
		$user_name = $_SESSION[self::SESSION_NAME]['user_name'];
		return $user_name;
	}
	public static function getUserId() {
		$admin_id = '';
		$admin_id = $_SESSION[self::SESSION_NAME]['user_id'];
		return $admin_id;
	}
	public static function getRealName() {
		$real_name = '';
		$real_name = $_SESSION[self::SESSION_NAME]['real_name'];
		return $real_name;
	}
	public static function getUserGroup() {
		$purviews = '';
		$purviews = $_SESSION[self::SESSION_NAME]['user_group'];
		return $purviews;
	}
	public static function getTemplate() {
		$template = '';
		$template = $_SESSION[self::SESSION_NAME]['template'];
		return $template;
	}
	public static function clear() {
		$_SESSION[self::SESSION_NAME] = null;
		return true;
	}
	public static function reload() {
		$current_user_info = self::getSessionInfo ();
		$user_info = User::getUserById (ADMIN, $current_user_info['user_id'] );
		if ($user_info['status'] != 1) {
			Common::jumpUrl ( "panel/login.php" );
			return;
		}
		$user_group = UserGroup::getGroupById ( $user_info['user_group'] );
		$user_info['group_id'] = $user_group['group_id'];
		$user_info['user_role'] = $user_group['group_role'];
		$user_info['shortcuts_arr'] = explode ( ',', $user_info['shortcuts'] );
		$menu = MenuUrl::getMenuByUrl ( '/admin/setting.php' );
		if (strpos ( $user_group['group_role'], $menu['menu_id'] )) {
			$user_info['setting'] = 1;
		}
		$user_info['login_time'] = Common::getDateTime ( $user_info['login_time'] );
		UserSession::setSessionInfo ( $user_info );
	}
}