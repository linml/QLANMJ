<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class Proportion extends Base {
	
	//计算提成
	public static function calculateProportion($order) {
		//获得代理关系
		$invitecode = self::get_invitecode_By_ud( $order['uid'] );
		//获取提成比例
		$proportionlevel = self::getLevel();
		if (!$invitecode) {
			return;
		}
		self::calculate_LY( $order, $invitecode, $proportionlevel );
	}
	
	public static function calculate_LY($order, $invitecode, $proportionlevel) {
		//proportion 比率
		//order['payment'] 付款数量
		$proportion0 = $order['payment']; 
		
		//三级提成 可抽三层
		$leve1 = 'manager_t_player_a'; 
		$leve2 = 'manager_t_manager_a';
		$leve3 = 'old_manager_t_manager_a';
		//一层15% 二层8% 三层6%
		$proportion1 = $proportion0 * $proportionlevel[$leve1] / 100;
		$proportion2 = $proportion0 * $proportionlevel[$leve2] / 100;
		$proportion3 = $proportion0 * $proportionlevel[$leve3] / 100;
		
		//二级提成 可抽二层
		$leve1_B = 'manager_t_player_b';
		$leve2_B = 'manager_t_manager_b';
		//一层15% 二层6%
		$B_proportion1 = $proportion0 * $proportionlevel[$leve1_B] / 100;
		$B_proportion2 = $proportion0 * $proportionlevel[$leve2_B] / 100;
		
		//一级提成 可抽一层
		$level1_C = 'manager_t_player_c';
		//一层15%
		$C_proportion1 = $proportion0 * $proportionlevel[$level1_C] / 100;

		//区域代理
		$A1 = 'are_manager_t';
		//8%
		$A_proportion1 = $proportion0 * $proportionlevel[$A1] / 100;

		
		//isagent_uid1 -> osa_t_agent.agent_uid   上级ID
		//givegems1    -> osa_t_agent.givegems    转钻权限 1为开启
		//agent_type1  -> osa_t_agent.agent_type  代理类型 0为不提成

		//第一层代理
		if (isset( $invitecode['isagent_uid1'] ) && !empty($invitecode['isagent_uid1']) && $invitecode['givegems1'] == 1 && $invitecode['agent_type1'] != 0) {
			$level = '';
			$profitRate = '';

			if($invitecode['agent_type1'] == 3){
				$level = $leve1;
				$profitRate = $proportion1;

			}else if($invitecode['agent_type1'] == 2){
				$level = $leve1_B;
				$profitRate = $B_proportion1;

			}else if($invitecode['agent_type1'] == 4){
				$level = $level1_C;
				$profitRate = $C_proportion1;
			
			}else{
				//由于找的是 agent_line , 所以不会出现区域代理
			}

			if(!empty($level)){
				$isagent_uid = "isagent_uid1"; // 提成uid
				$agentearnings_uid = "agent_earnings_uid1"; // 代理原收益
				$order_t_type = 'manager_t_1'; // 订单上提成类型
				self::execute_zt($profitRate, $isagent_uid, $level, $agentearnings_uid, $order, $invitecode, $proportionlevel, $order_t_type, $proportion0);
			}
		}

		//第二层代理
		if (isset( $invitecode['isagent_uid2'] ) && !empty($invitecode['isagent_uid2']) && $invitecode['givegems2'] == 1 && $invitecode['agent_type2'] != 0) {
			$level = '';
			$profitRate = '';

			if($invitecode['agent_type2'] == 3){
				$level = $leve2;
				$profitRate = $proportion2;

			}else if($invitecode['agent_type2'] == 2){
				$level = $leve2_B;
				$profitRate = $B_proportion2;

			}else{
				//由于找的是 agent_line , 所以不会出现区域代理
			}

			if(!empty($level)){
				$isagent_uid = "isagent_uid2"; // 提成uid
				$agentearnings_uid = "agent_earnings_uid2"; // 代理原收益
				$order_t_type = 'manager_t_2'; // 订单上提成类型
				self::execute_zt ( $profitRate, $isagent_uid, $level, $agentearnings_uid, $order, $invitecode, $proportionlevel, $order_t_type, $proportion0 );
			}
		}

		//第三层代理
		if (isset ( $invitecode['isagent_uid3'] ) && !empty($invitecode['isagent_uid3']) && $invitecode['givegems3'] == 1 && $invitecode['agent_type3'] != 0){
			$level = '';
			$profitRate = '';

			if($invitecode['agent_type3'] == 3){
				$level = $leve3;
				$profitRate = $proportion3;

			}else{
				//由于找的是 agent_line , 所以不会出现区域代理
			}

			if(!empty($level)){
				$isagent_uid = "isagent_uid3"; // 提成uid
				$agentearnings_uid = "agent_earnings_uid3"; // 代理原收益
				$order_t_type = 'manager_t_3'; // 订单上提成类型
				self::execute_zt ( $profitRate, $isagent_uid, $level, $agentearnings_uid, $order, $invitecode, $proportionlevel, $order_t_type, $proportion0 );
			}
		}

		//区域代理
		if (isset( $invitecode['area_agent_uid_of_uid0']) && !empty($invitecode['area_agent_uid_of_uid0']) 
			&& $invitecode['area_agent_uid_of_uid0'] !=0
			&& $invitecode['area_agent_type0'] !=0
			&& $invitecode['area_agent_uid_of_uid0'] != $invitecode['isagent_uid1']
			&& $invitecode['area_agent_uid_of_uid0'] != $invitecode['isagent_uid2']
			&& $invitecode['area_agent_uid_of_uid0'] != $invitecode['isagent_uid3']
			)
		{
			$level = '';
			$profitRate = '';

			if($invitecode['area_agent_type0'] == 1){
				$level = $A1;
				$profitRate = $A_proportion1;
			}else{
				//异常数据
			}

			if(!empty($level)){
				$isagent_uid = "area_agent_uid_of_uid0"; // 提成uid
				$agentearnings_uid = "area_agent_earnings_of_uid0"; // 代理原收益
				$order_t_type = 'are_manager_t_1'; // 订单上提成类型
				self::execute_zt ( $profitRate, $isagent_uid, $level, $agentearnings_uid, $order, $invitecode, $proportionlevel, $order_t_type, $proportion0 );
			}	
		}
	}

	//$proportion0       提成值
	//$isagent_uid       用于从代理链中提取代理ID的KEY isagent_uid1, isagent_uid2, isagent_uid3, area_agent_uid_of_uid0
	//$leve              提成类型 
	//$agentearnings_uid 原提成值 agent_earnings_uid1, agent_earnings_uid2, agent_earnings_uid3, area_agent_earnings_of_uid0
	//$order             订单实例
	//$invitecode        代理链实例
	//$proportionlevel   提成信息实例
	//$order_t_type      订单上提成类型 未知 manager_t_1, manager_t_2, manager_t_3, are_manager_t_1
	//$payment_base      支付值
	public static function execute_zt($proportion0, $isagent_uid, $leve, $agentearnings_uid, $order, $invitecode, $proportionlevel, $order_t_type, $payment_base) {
		//保存提成明细
		self::proportion_detail_sql( $proportion0, $isagent_uid, $leve, $agentearnings_uid, $order, $invitecode, $proportionlevel, $payment_base );
		//更新代理收益信息
		self::proportion_sql( $proportion0, $isagent_uid, $invitecode );
		//修改订单提成信息
		self::updateorder_sql( $proportion0, $order_t_type, $order );
		//保存代理收益记录
		self::add_agent_earnings_record_sql( $proportion0, $isagent_uid, $agentearnings_uid, $order, $invitecode );
	}
	
	//保存提成明细
	public static function proportion_detail_sql($proportion, $isagent_uid, $proportion_level, $agentearnings_uid, $order, $invitecode, $proportionlevel, $payment_base) {			
		$db = self::__instance ();
		$sql = "INSERT INTO `osa_t_proportion_detail`
						( `oid`, `proportion_uid`, `proportion_level`
				       , `payment`, `proportion`, `propor_payment`
						, `after_the_proportion_earnings`,`payment_base`)
						VALUES ( " . $order['oid'] . ", " . $invitecode[$isagent_uid] . ", '$proportion_level
		                   ', " . $order['payment'] . ", " . $proportionlevel[$proportion_level] . ", $proportion
		                     , " . ($proportion + $invitecode[$agentearnings_uid]) . "," . $payment_base . ");";
			
		$db->query ( $sql );
	}
	
	//更新代理收益信息
	public static function proportion_sql($proportion, $isagent_uid, $invitecode) {
		$db = self::__instance ();
		$sql = "update osa_t_agent set earnings=earnings+$proportion,history_count_earnings=history_count_earnings+$proportion where agent_uid=".$invitecode[$isagent_uid].";";
		$db->query ( $sql );
	}
	
	//修改订单提成类型
	public static function updateorder_sql($proportion, $t_type, $order) {
		$db = self::__instance ();
		$sql = "update osa_t_order set $t_type=$proportion where oid= ".$order['oid']."; ";
		$db->query ( $sql );
	}
	
	//保存代理收益记录
	public static function add_agent_earnings_record_sql($proportion, $isagent_uid, $agentearnings_uid, $order, $invitecode) {
		$db = self::__instance ();
		$sql = "INSERT INTO `osa_t_agent_earnings_record` ( `uid`, `oid`, `settlement_record_id`,`Settlement_type`, `earnings`, `after_the_earnings`) VALUES( $invitecode[$isagent_uid], " . $order['oid'] . ", 0, 0, $proportion, ($proportion + $invitecode[$agentearnings_uid]));";
		$db->query ( $sql );
	}
	
	/**
	 * 代理商收益记录
	 */
	public static function add_agent_earnings_record($uid, $oid, $settlement_record_id, $Settlement_type, $earnings, $after_the_earnings) {
		$db = self::__instance ();
		$sql = "INSERT INTO `osa_t_agent_earnings_record` ( `uid`, `oid`, `settlement_record_id`
				,`Settlement_type`, `earnings`, `after_the_earnings`) VALUES
				( $uid, $oid, $settlement_record_id, '$Settlement_type', $earnings, $after_the_earnings);";
		$db->query ( $sql );
	}
	
	//获取提成关系
	public static function get_invitecode_By_ud($uid) {
		$db = self::__instance ();
		$sql = "select 
			t0.userid as uid0, a0.agent_uid as isagent_uid0 , a0.givegems as givegems0 , a0.earnings as agent_earnings_uid0,a0.agent_type as agent_type0, i0.area_agent_uid as area_agent_uid_of_uid0 , area0.givegems as area_givegems0,area0.earnings as  area_agent_earnings_of_uid0,area0.agent_type as area_agent_type0 
 			,i1.uid as uid1, a1.agent_uid as isagent_uid1 , a1.givegems as givegems1 , a1.earnings as agent_earnings_uid1,a1.agent_type as agent_type1, i1.area_agent_uid as area_agent_uid_of_uid1 , area1.givegems as area_givegems1,area1.earnings as  area_agent_earnings_of_uid1,area1.agent_type as area_agent_type1 
  			,i2.uid as uid2, a2.agent_uid as isagent_uid2 , a2.givegems as givegems2 , a2.earnings as agent_earnings_uid2,a2.agent_type as agent_type2, i2.area_agent_uid as area_agent_uid_of_uid2 , area2.givegems as area_givegems2,area2.earnings as  area_agent_earnings_of_uid2,area2.agent_type as area_agent_type2  
  			,i3.uid as uid3, a3.agent_uid as isagent_uid3 , a3.givegems as givegems3 , a3.earnings as agent_earnings_uid3,a3.agent_type as agent_type3, i3.area_agent_uid as area_agent_uid_of_uid3 , area3.givegems as area_givegems3,area3.earnings as  area_agent_earnings_of_uid3,area3.agent_type as area_agent_type3 
  
			from t_users t0 
			left join osa_t_agent a0 on t0.userid=a0.agent_uid
			left join osa_t_invitecode i0 on t0.userid=i0.uid
			left join osa_t_agent area0 on i0.area_agent_uid=area0.agent_uid

			left join osa_t_invitecode i1 on i0.agent_line_uid=i1.uid
			left join osa_t_agent a1 on i1.uid=a1.agent_uid
			left join osa_t_agent area1 on i1.area_agent_uid=area1.agent_uid

			left join osa_t_invitecode i2 on i1.agent_line_uid=i2.uid
			left join osa_t_agent a2 on i2.uid=a2.agent_uid
			left join osa_t_agent area2 on i2.area_agent_uid=area2.agent_uid

			left join osa_t_invitecode i3 on i2.agent_line_uid=i3.uid
			left join osa_t_agent a3 on i3.uid=a3.agent_uid
			left join osa_t_agent area3 on i3.area_agent_uid=area3.agent_uid
			where t0.userid=$uid";
		$list = $db->query ( $sql )->fetch ();
		if ($list) {
			return $list;
		}
		return array ();
	}
	
	/**
	 * 获取提成比例
	 */
	public static function getLevel() {
		$db = self::__instance ();
		$data = array (
				"are_manager_t" => 0,
				"t_level" => 0,
				"old_manager_t_manager_a" => 0,
				"manager_t_manager_a" => 0,
				"manager_t_player_a" => 0,
				"manager_t_manager_b" => 0,
				"manager_t_player_b" => 0,
				"manager_t_player_c" => 0,
				"touch_a" => 0,
				"touch_b" => 0,
				"touch_c" => 0 
		);
		$sql = "select * from osa_t_config where k in('are_manager_t','t_level'
				,'old_manager_t_manager_a','manager_t_manager_a','manager_t_player_a'
				,'manager_t_manager_b','manager_t_player_b','manager_t_player_c','touch_a','touch_b','touch_c')";
		$list = $db->query ( $sql )->fetchAll ();
		if ($list) {
			foreach ( $list as $k => $v ) {
				$data[$v['k']] = $v['value'];
			}
		}
		return $data;
	}
	
	/**
	 * 修改提成比例
	 */
	public static function updateLevel($level, $level_data) {
		if (! $level_data || ! is_array ( $level_data )) {
			return false;
		}
		$db = self::__instance ();
		$condition = array (
				'k' => $level 
		);
		$id = $db->update ( "osa_t_config", $level_data, $condition );
		return $id;
	}
	
	/**
	 * 表名
	 */
	private static $table_name = 'users';
	
	/**
	 * 查询字段
	 */
	private static $columns = 'oid,weixin_out_trade_no, uid, payment, price, number, create_time, status, payment_time, payment_ way, proportion_status';
	/**
	 * 获取表名
	 * 
	 * @return string
	 */
	public static function getTableName() {
		return parent::$table_prefix_t . self::$table_name;
	}

	public static function get_T_Users_By_Id($id) {
		$db = self::__instance ();
		$sql = "select *  from t_users  where id=$id";
		$list = $db->query ( $sql )->fetch ();
		if ($list) {
			return $list;
		}
		return array ();
	}
}