<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class ApiActivityDll extends Base {
	/**
	 * 
	 * @param unknown $user玩家
	 */
	static public function activity($user) {
		// 未扫描
		$invitecode_pre = ApiDll::getInvitecode_pre( $user['unionid'] );
		if (!$invitecode_pre) return;
		
		$isExistSweepAgent = ApiDll::getInvitecode_pre_by_unionid_and_sweep_agent ( $user['unionid'], 1 );
		$isExistSweepPlayer = ApiDll::getInvitecode_pre_by_unionid_and_sweep_agent ( $user['unionid'], 0 );
		//扫描代理
		if ($isExistSweepAgent && $isExistSweepAgent['status'] == 0) {
			// 处理扫描业务
			$Invitecode_pre_data = array (
				'status' => 1 
			);
			ApiActivityDll::updateInvitecode_pre_by_unionid_and_uid ( $user['unionid'], $isExistSweepAgent['uid'], $Invitecode_pre_data );

			/*$data = array (
				"userId" => $user['userid'],
				"code" => $isExistSweepAgent['uid']
			);*/

			$ret = ApiDll::onBindAgent(array (
				"userId" => $user['userid'],
				"code" => $isExistSweepAgent['uid']
			));
		}


		//扫描玩家
		if ($isExistSweepPlayer && $isExistSweepPlayer['status'] == 0) {
			// 处理扫描业务
			$Invitecode_pre_data = array (
				'status' => 1 
			);
			ApiActivityDll::updateInvitecode_pre_by_unionid_and_uid ( $user['unionid'], $isExistSweepPlayer['uid'], $Invitecode_pre_data );
			
			//$uid = $user['userid'];
			//$code = $isExistSweepPlayer['uid'];

			ApiDll::onBindCommonUserInvite(array (
				"userId" => $user['userid'],
				"code" => $isExistSweepPlayer['uid']
			));

			/*
				$gems = 0;
				$area_agent_uid = 0;
				// 被扫描玩家二维码 送钻
				$user2 = Sell::getTuserByUid ( $code );
				// 记录房卡记录
				$input_data2 = array (
						'uid' => $code,
						'gems' => ApiConfig::sweep_not_invite_send_gems,
						'after_the_gems' => ApiConfig::sweep_not_invite_send_gems + $user2['gems'],
						'type' => "bySweepadd" 
				);
				Gems::addGemsRecord ( $input_data2 );
				// 增加房卡
				$update_data2 = array (
						'gems' => ApiConfig::sweep_not_invite_send_gems + $user2['gems'] 
				);
				Gems::updateTuserGems ( $code, $update_data2 );
				
				// 记录房卡记录
				$input_data = array (
						'uid' => $uid 
				);
				$input_data['type'] = 'sweepPlayerAdd';
				$gems = ApiConfig::sweep_not_invite_send_gems;
				$input_data['gems'] = $gems;
				$input_data['after_the_gems'] = $gems + $user['gems'];
				Gems::addGemsRecord ( $input_data );
				// 增加房卡
				$update_data = array (
						'gems' => $gems + $user['gems'] 
				);
				Gems::updateTuserGems ( $uid, $update_data );
			*/
		}
	}

	public static function updateInvitecode_pre_by_unionid($unionid, $data) {
		if (! $data || ! is_array ( $data )) {
			return false;
		}
		$db = self::__instance ();
		$condition = array (
				"unionid" => $unionid 
		);
		$id = $db->update ( "osa_t_invitecode_pre", $data, $condition );
		
		return $id;
	}
	
	public static function updateInvitecode_pre_by_unionid_and_uid($unionid, $uid, $data) {
		if (! $data || ! is_array ( $data )) {
			return false;
		}
		$db = self::__instance ();
		$condition = array (
				"AND" =>array(
				"unionid" => $unionid,			
				"uid" => $uid 
						)
		);
		$id = $db->update ( "osa_t_invitecode_pre", $data, $condition );
		
		return $id;
	}
}