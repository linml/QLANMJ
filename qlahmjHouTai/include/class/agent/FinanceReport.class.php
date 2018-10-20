<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class FinanceReport extends Base {
	
	
	/**
	 * 获取历史天数记录
	 * @param string $start
	 * @param string $page_size
	*/
	public static function getMonthHistoryByMonth($month ='',$type='') {
		$db = self::__instance (pigcms_report);
		if(empty($month)){
			$month =date('n');
		}
		
		$Monthfirday=date("Y-m-d",strtotime(date('Y-').$month .'-01'));

	    $Monthendday=date("Y-m-d",strtotime("$Monthfirday +1 month -1 day"));

	    if(date('n')==$month){
	    	$monthdays = date('d');
	    	$cycle='M';
	    }else{
	    	$cycle='MOK';
	    	$monthdays = date("d",strtotime("$Monthfirday +1 month -1 day"));
	    }

		$sql = "SELECT DATE_FORMAT(date,'%Y-%m-%d') as date,count(cycle) as typeCount,room,cost,agent,gamer,invite,cash,IFNULL(dlexcard,0) as dlexcard,pay FROM game_report where date BETWEEN '$Monthfirday' and '$Monthendday' and game = '".GAME_CASH_NAME."' and (cycle='$type' OR cycle='D') AND DATE_FORMAT(date,'%Y') = '".date("Y")."'order by date desc";

		$list = $db->query ( $sql )->fetchAll ();
		if($monthdays!=count($list)){
			$monthCashData  = array();
			//删除本月的表
			$db->query("DELETE FROM game_report where  game = '".GAME_CASH_NAME."' and cycle = '$cycle' and DATE_FORMAT(date,'%Y') = '".date("Y")."' and DATE_FORMAT(date,'%c') = '$month'");
			$i = 0;
			while($i<$monthdays){
				if($i == 0 && date('m')==$month){
					$tempCashData = self::redealWithReportsWhenDataIsWrong($month,'D',$i);
				}else{
					$tempCashData = self::redealWithReportsWhenDataIsWrong($month,'DOK',$i);
				}
				array_push($monthCashData,$tempCashData);
				$i++;
			}

			$list = $monthCashData;
		}
		//获取当月数据
		$month_Data = self::getMonthDataByMonth($month);
		array_push($list,$month_Data);
		if ($list) {
			return $list;
		}
		return array ();
	}

	//获取月份对应的值
	public static function getMonthDataByMonth($month=''){
		$db = self::__instance (pigcms_report);
		if($month<=0){return null;}
		$where="";
		$d_Month = date("Y-m-d",strtotime(date('Y-').($month).'-1'));
		if(date('m')==$month){
			$cycle='M';
		}else{
			$cycle='MOK';
			$where =" and DATE_FORMAT(date,'%Y-%m-%d') = '$d_Month' ";
		}
		$sql="SELECT '月统计' as date,room,cost,agent,gamer,invite,cash,IFNULL(dlexcard,0) as dlexcard,pay FROM game_report where game = '".GAME_CASH_NAME."' and cycle='$cycle' $where AND DATE_FORMAT(date,'%Y') = '".date('Y')."' order by date";
		$result = $db->query($sql)->fetch();
		if($result){
			return $result;
		}else{
			self::redealWithReportsWhenDataIsWrong($month,$cycle);
			return $db->query($sql)->fetch();
		}
		return array();
	}

	//重建缓存数据
	public static function redealWithReportsWhenDataIsWrong($month='',$DMtype='',$realIndex=''){
		if(empty($month)||empty($DMtype)) return;
		$db = self::__instance(pigcms_report);
		if(strpos($DMtype, "M")!==false){
			$thisMonthFirstDay = date("Y-m-d",strtotime(date('Y-').$month .'-01'));
			$thisMonthEndDay = date('m')=='$month' ? date("Y-m-d",strtotime("+1 day")):date("Y-m-d",strtotime("$thisMonthFirstDay +1 month"));
		}else if(strpos($DMtype, "D")!==false){
			$Monthfirday=date("Y-m-d",strtotime(date('Y-').$month .'-01'));
	    	$Monthendday=date('m')==$month ? date('Y-m-d') : date("Y-m-d",strtotime("$Monthfirday +1 month -1 day"));
			$thisMonthFirstDay=date("Y-m-d",strtotime("$Monthendday -$realIndex day"));
			$thisMonthEndDay=date("Y-m-d",strtotime("$Monthendday -$realIndex day +1 day"));
		}
		$cashData = array('cycle'=>$DMtype);
		//代理表中
		$agentArrayData = self::reportAgentSql($thisMonthFirstDay,$thisMonthEndDay);
		//游戏表中
		$gameArrayData = self::reportGameSql($thisMonthFirstDay,$thisMonthEndDay);
			
		$cashData = array_merge($cashData,$agentArrayData);
		$cashData = array_merge($cashData,$gameArrayData);
		
		$db->query("DELETE FROM game_report where  game = '".GAME_CASH_NAME."' and cycle = '$DMtype' and date ='$thisMonthFirstDay' and DATE_FORMAT(date,'%Y') = '".date("Y")."' and DATE_FORMAT(date,'%c') = '$month'");
		$db->insert('game_report',$cashData);
		return $cashData;
	}

	public static function reportAgentSql($thisMonthFirstDay='',$thisMonthEndDay=''){

		$db = self::__instance();

		//邀请次数
		$invitationCount = $db->query("SELECT DATE_FORMAT(addtime,'%Y-%m') months, COUNT(id) as num FROM pigcms_game_user where addtime BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months ")->fetch();
		//代理注册  
		$agentRegisterCount = $db->query("SELECT DATE_FORMAT(addtime,'%Y%m') months, COUNT(id) as num FROM pigcms_dl_users where addtime BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months")->fetch();
		//代理售钻
		$agentSellCount = $db->query("SELECT DATE_FORMAT(addtime,'%Y%m') months, SUM(traded_num) as num FROM pigcms_traded_admin_log where eid!=0 AND addtime BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months")->fetch();
		//提现
		$agentCashTXCount = $db->query("SELECT DATE_FORMAT(addtime,'%Y%m') months, sum(money) as num from pigcms_cash_log where addtime BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months ")->fetch();
		return array(
			'date' => $thisMonthFirstDay,
			'game' => GAME_CASH_NAME,
			'invite' => $invitationCount['num'] !=null?$invitationCount['num']:0 ,
			'agent' =>  $agentRegisterCount['num'] !=null?$agentRegisterCount['num']:0,
			'pay' =>  $agentCashTXCount['num'] !=null?$agentCashTXCount['num']/100:0,
			'dlexcard'=>$agentSellCount['num'] !=null?$agentSellCount['num']:0
		);
	}

	public static function reportGameSql($thisMonthFirstDay='',$thisMonthEndDay=''){
		$db = self::__instance(pigcms_game);
		//注册人数
		$registerCount = $db->query("SELECT  DATE_FORMAT(m_RegisterTime,'%Y%m') months, count(m_lUid) as num FROM `ninedt_user` where m_RegisterTime BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' and m_sNickName != 'default user' GROUP BY months")->fetch();
		//创建房间数量
		$createdRoomCount = $db->query("SELECT  DATE_FORMAT(created,'%Y%m') months, count(id) as num FROM ninedt_battle_log where created BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months")->fetch();
		//耗钻情况
		$consumeCostCount = $db->query("SELECT DATE_FORMAT(created,'%Y%m') months, ABS(sum(cost0+cost1+cost2+cost3+cost4))as num FROM ninedt_battle_log where created BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months")->fetch();
		//流水
		$accountCashCount = $db->query("SELECT DATE_FORMAT(created,'%Y%m') months, sum(amount) as num FROM yxpay where status=2 and created BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months")->fetch();

		return array(
			'room' => $createdRoomCount['num'] !=null?$createdRoomCount['num']:0,
			'cost' => $consumeCostCount['num'] !=null?$consumeCostCount['num']:0,
			'gamer' => $registerCount['num'] !=null?$registerCount['num']:0,
			'cash' => $accountCashCount['num'] !=null?$accountCashCount['num']/100:0
		);
	}
	
}