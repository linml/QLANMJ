<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class CensusReport extends Base {
	
	
	/**
	 * 获取历史天数记录
	 * @param string $start
	 * @param string $page_size
	*/
	public static function getCensusReportsMonthHistoryByMonth($month ='',$type='') {
		if(empty($month)){
			$month =date('n');
		}
		$db = self::__instance (pigcms_report);
		$monthCashData  = array();
	    //计算当前月天数
	    if(date('n')==$month){
	    	$monthdays = date('d');
	    	//获取当前日期缓存数据
		    $Monthfirday_d = date('Y-m-d');
		    $Monthendday_d=date("Y-m-d",strtotime("$Monthfirday +1 day"));
		    $daysDData = self::getDaysCensusByMonthType($db,'D',$Monthfirday_d,$Monthendday_d);
		    //查看当天数据记录
		    if(count($daysDData)!=1){
				$tempCashData = self::redealWithCensusReportsWhenDataIsWrong($month,'D',0);
				array_push($monthCashData,$tempCashData);
		    }else{
				//合并数据
				$monthCashData = array_merge($monthCashData,$daysDData);
		    }
	    }else{
	    	$monthdays = date("d",strtotime(date('Y-').$month ."-01 +1 month -1 day"));
	    }
	    //获取选取页面
		$Monthfirday=date("Y-m-d",strtotime(date('Y-').$month .'-01'));
	    $Monthendday=date("Y-m-d",strtotime("$Monthfirday +1 month -1 day"));
	    $daysDOKData = self::getDaysCensusByMonthType($db,'DOK',$Monthfirday,$Monthendday);
	    $daysDOKDistintCount = self::getTypeCountFromCensusReport($db,'DOK',$Monthfirday,$Monthendday);
	    //历史天数缓存数据是否有误
	    if(($monthdays-(date('n')==$month ? 1 : 0))!=count($daysDOKData)
	    	||$daysDOKDistintCount!=($monthdays-(date('n')==$month ? 1 : 0))){
	    	$i = date('n')==$month ? 1 : 0;
	    	$new_monthCashData = array();
			while($i<$monthdays){
				$dayTime = date('Y-m-d',strtotime(date('Y-').$month.'-'.$monthdays." -$i day"));
				$cashTempDate = self::getDayFromDateTime($db,$dayTime,'D');

				if(count($cashTempDate)!=1){
					$tempCashData = self::redealWithCensusReportsWhenDataIsWrong($month,'DOK',$i);
					array_push($new_monthCashData,$tempCashData);
				}else if($cashTempDate[0]['cycle']=='D'){
					//进行旧天数数据进行更新
					$tempCashData = self::redealWithCensusReportsWhenDataIsWrong($month,'DOK',$i);
					array_push($new_monthCashData,$tempCashData);
				}else{
					$new_monthCashData = array_merge($new_monthCashData,$cashTempDate);
				}
				$i++;
			}
			//参数转接赋值
			$daysDOKData = $new_monthCashData;
	    }
	    //合并数据
		$monthCashData = array_merge($monthCashData,$daysDOKData);

		//获取当月数据
		$monthM_OR_MOKData = self::getCensusReportMonthDataByMonth($db,$month);
		array_push($monthCashData,$monthM_OR_MOKData);
		if ($monthCashData) {
			return $monthCashData;
		}
		return array ();
	}

	//获取某天的数据 天 D  月 M 
	public static function getDayFromDateTime($db='',$DayTime='',$cycle=''){
		if(empty($db)||empty($DayTime)||empty($cycle))return;
		$sql="SELECT DATE_FORMAT(date,'%Y-%m-%d') as date,cycle,open,gems,register,login,active,s_retention,t_retention,se_retention,rechargeCount,

				rechargeMoney ,n_rechargeCount,n_rechargeMoney,rate,n_rate,diamondThree,diamondTwo,diamondOne,diamondFive,n_diamondOne,

				n_diamondFive,n_diamondZero,nowPepole FROM census_report WHERE game='".GAME_CASH_NAME."' AND date ='$DayTime' AND cycle LIKE '$cycle%'";
		$result = $db->query($sql)->fetchAll();
		if($result) return $result; else return array();
	}
	//获取日期不重复
	public static function getTypeCountFromCensusReport($db='',$type ='',$Monthfirday='',$Monthendday=''){
		if(empty($db)||empty($type)||empty($Monthfirday)||empty($Monthendday)) return;
		$sql="SELECT COUNT(DISTINCT date) as count FROM census_report where date BETWEEN '$Monthfirday' and '$Monthendday' and game = '".GAME_CASH_NAME."' and cycle='$type'";
		return 0 + $db->query($sql)->fetch()['count'];
	}
	//按类型获取缓存数据
	public static function getDaysCensusByMonthType($db='',$type ='',$Monthfirday='',$Monthendday=''){
		if(empty($db)||empty($type)||empty($Monthfirday)||empty($Monthendday)) return;
		$sql="SELECT DATE_FORMAT(date,'%Y-%m-%d') as date,cycle,open,gems,register,login,active,s_retention,t_retention,se_retention,rechargeCount,

				rechargeMoney ,n_rechargeCount,n_rechargeMoney,rate,n_rate,diamondThree,diamondTwo,diamondOne,diamondFive,n_diamondOne,

				n_diamondFive,n_diamondZero,nowPepole  FROM census_report where date BETWEEN '$Monthfirday' and '$Monthendday' and game = '".

				GAME_CASH_NAME."' and cycle='$type' order by date desc";
		$list = $db->query($sql)->fetchAll();
		if($list) return $list; else return array();
	}
	//获取月份对应的值
	public static function getCensusReportMonthDataByMonth($db='',$month=''){
		if(empty($db)||empty($month))return;
		if($month<=0){return null;}
		$where="";
		$d_Month = date("Y-m-d",strtotime(date('Y-').($month).'-1'));
		if(date('m')==$month){
			$cycle='M';
		}else{
			$cycle='MOK';
		}
		$where =" and DATE_FORMAT(date,'%Y-%m-%d') = '$d_Month' ";
		$sql="SELECT '月统计' as date,open,gems,register,login,active,s_retention,t_retention,se_retention,rechargeCount,

				rechargeMoney ,n_rechargeCount,n_rechargeMoney,rate,n_rate,diamondThree,diamondTwo,diamondOne,diamondFive,n_diamondOne,

				n_diamondFive,n_diamondZero,nowPepole  FROM census_report where game = '".GAME_CASH_NAME."' and cycle='$cycle' $where order by date";
		$result = $db->query($sql)->fetch();
		if($result){
			return $result;
		}else{
			//没有当月数据的时候，检测是否跳过上月
			$lastMonthDate = date("Y-m-d",strtotime("$d_Month -1 month"));
			$lastMonthEndDate = date('Y-m-d',strtotime("$lastMonthDate +1 month -1  day"));
			//处理跳转月的天数数据重建
			$censusDaysData = self::getDaysCensusByMonthType($db,'D',$lastMonthDate,$lastMonthEndDate);
			foreach ($censusDaysData as $key => $value) {
				if($censusDaysData[$key]['cycle']=='D'){
					$d_type = date('d',strtotime($lastMonthEndDate)) - date('d',strtotime($censusDaysData[$key]['date']));
					$result = self::redealWithCensusReportsWhenDataIsWrong(date('n',strtotime($lastMonthDate)),'DOK',$d_type);
				}
			}
			//处理跳转月的月数据重建
			$censsusMonthsData =  self::getDayFromDateTime($db,$lastMonthDate,'M');
			if($censsusMonthsData[0]['cycle']=='M'){
				self::redealWithCensusReportsWhenDataIsWrong(date('n',strtotime($lastMonthDate)),'MOK');
			}
			$censusReportsData =  self::redealWithCensusReportsWhenDataIsWrong($month,$cycle);
			$censusReportsData['date'] = '月统计';
			return $censusReportsData;
			// return $db->query($sql)->fetch();
		}
		return array();
	}

	//重建缓存数据 增加删除天
	public static function redealWithCensusReportsWhenDataIsWrong($month='',$DMtype='',$realIndex=''){
		if(empty($month)||empty($DMtype)) return;
		$whereType = '';
		$db = self::__instance(pigcms_report);
		if(strpos($DMtype, "M")!==false){
			$thisMonthFirstDay = date("Y-m-d",strtotime(date('Y-').$month .'-01'));
			$thisMonthEndDay = date('m')==$month ? date("Y-m-d",strtotime("+1 day")):date("Y-m-d",strtotime("$thisMonthFirstDay +1 month"));
			$whereType .= " and cycle like 'M%'";
		}else if(strpos($DMtype, "D")!==false){
			$Monthfirday=date("Y-m-d",strtotime(date('Y-').$month .'-01'));
	    	$Monthendday=date('m')==$month ? date('Y-m-d') : date("Y-m-d",strtotime("$Monthfirday +1 month -1 day"));
			$thisMonthFirstDay=date("Y-m-d",strtotime("$Monthendday -$realIndex day"));
			$thisMonthEndDay=date("Y-m-d",strtotime("$Monthendday -$realIndex day +1 day"));
			$whereType .= " and cycle like 'D%'";
		}
		$cashData = array('cycle'=>$DMtype);
		$censusArrayData = self::census_reportSql($thisMonthFirstDay,$thisMonthEndDay);
		$cashData = array_merge($cashData,$censusArrayData);
		$db->query("DELETE FROM census_report where  game = '".GAME_CASH_NAME."' and date ='$thisMonthFirstDay' $whereType ");
		$db->insert('census_report',$cashData);
		return $cashData;
	}

	//构建缓存数据
	public static function census_reportSql($thisMonthFirstDay='',$thisMonthEndDay=''){
		$db = self::__instance(pigcms_game);
		//创建房间数量
		$createdRoomCount = $db->query("SELECT  DATE_FORMAT(created,'%Y%m') months, count(id) as num FROM ninedt_battle_log where created BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months")->fetch();
		//耗钻情况
		$consumeCostCount = $db->query("SELECT DATE_FORMAT(created,'%Y%m') months, ABS(sum(cost0+cost1+cost2+cost3+cost4))as num FROM ninedt_battle_log where created BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months")->fetch();
		//注册人数
		$registerCount = $db->query("SELECT  DATE_FORMAT(m_RegisterTime,'%Y%m') months, count(m_lUid) as num FROM `ninedt_user` where m_RegisterTime BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' and m_sNickName != 'default user' GROUP BY months")->fetch();
		//活跃人数
		$activeCount = $db->query("select count(DISTINCT temp.userid ,DATE_FORMAT(temp.time,'%Y-%m-%d')) as count ,DATE_FORMAT(temp.time,'%Y-%m') as months  from (

									select uid0 as userid, created as time from ninedt_battle_log where uid0 !=0 

									UNION ALL

									select uid1 , created as time from ninedt_battle_log where uid1 !=0  

									UNION ALL

									select uid2 , created as time from ninedt_battle_log where uid2 !=0  

									UNION ALL

									select uid3 , created as time from ninedt_battle_log where uid3 !=0 
									
									UNION ALL

									select uid4 , created as time from ninedt_battle_log where uid4 !=0
 
			) temp where temp.time BETWEEN '$thisMonthFirstDay' and '$thisMonthEndDay' GROUP BY months")->fetch();

		//次留
		$s_retention = self::calcutorDayToOtherDayString($db,1,$thisMonthFirstDay,$thisMonthEndDay);
		//三留
		$t_retention = self::calcutorDayToOtherDayString($db,3,$thisMonthFirstDay,$thisMonthEndDay);
		//七留
		$se_retention = self::calcutorDayToOtherDayString($db,7,$thisMonthFirstDay,$thisMonthEndDay);

		//充值人数
		$rechargeCount = $db->query("select  count(distinct to_user,DATE_FORMAT(created,'%Y-%m-%d')) as count ,DATE_FORMAT(created,'%Y-%m') as months  from yxpay where status=2 AND created BETWEEN '$thisMonthFirstDay' and  '$thisMonthEndDay' GROUP BY months")->fetch();

		//充值金额 
		$rechargeMoney = $db->query("select ROUND(sum(amount)/100,2) as money ,DATE_FORMAT(created,'%Y-%m') as months from yxpay where status=2 AND created BETWEEN '$thisMonthFirstDay' and  '$thisMonthEndDay' GROUP BY months")->fetch();

		//新增充值人数
		$n_rechargeCount = $db->query("select count(distinct to_user) as count ,DATE_FORMAT(created,'%Y-%m') as months  from yxpay yx where  

						to_user in (select m_lUid from ninedt_user where  to_days(m_RegisterTime) = to_days(yx.created)) 

						and status=2  and  yx.created  BETWEEN '$thisMonthFirstDay' AND '$thisMonthEndDay' GROUP BY months ")->fetch();

		//新增充值金额
		$n_rechargeMoney = $db->query("select ROUND(sum(amount)/100,2) as money,DATE_FORMAT(created,'%Y-%m') as months from yxpay yx where  

						to_user in (select m_lUid from ninedt_user where  to_days(m_RegisterTime) = to_days(yx.created)) 

						and status=2  and  yx.created  BETWEEN '$thisMonthFirstDay' AND '$thisMonthEndDay' GROUP BY months ")->fetch();

		//付费率
		$rate = self::calcutorRate($rechargeCount['count'],$activeCount['count']);
		//新增付费率
		$n_rate = self::calcutorRate($n_rechargeCount['count'],$registerCount['num']);

		//钻石日消耗大于300
		$diamondThree = self::calcutorCostToNexString($db,'300','',$thisMonthFirstDay,$thisMonthEndDay);
		//钻石日消耗大于200
		$diamondTwo =self::calcutorCostToNexString($db,'200','300',$thisMonthFirstDay,$thisMonthEndDay);
		//钻石日消耗大于100
		$diamondOne =self::calcutorCostToNexString($db,'100','200',$thisMonthFirstDay,$thisMonthEndDay);
		//钻石日消耗大于50
		$diamondFive =self::calcutorCostToNexString($db,'50','100',$thisMonthFirstDay,$thisMonthEndDay);


		//新增钻石日消耗大于100
		$n_diamondOne =self::calcutorCostNewToNextString($db,'100','',false,$thisMonthFirstDay,$thisMonthEndDay);
		//新增用户钻石日消耗大于50
		$n_diamondFive =self::calcutorCostNewToNextString($db,'50','100',false,$thisMonthFirstDay,$thisMonthEndDay);
		//新增用户钻石日消耗等于0
		$n_diamondZero =self::calcutorCostNewToNextString($db,'0','',true,$thisMonthFirstDay,$thisMonthEndDay);

		return array(
			'date' => $thisMonthFirstDay,
			'game' => GAME_CASH_NAME,
			'open'=>$createdRoomCount['num']!=null?$createdRoomCount['num']:0,
			'gems'=>$consumeCostCount['num']!=null?$consumeCostCount['num']:0,
			'register'=>$registerCount['num']!=null?$registerCount['num']:0,
			'login'=> 0,
			'active'=>$activeCount['count']!=null?$activeCount['count']:0,
			's_retention'=>$s_retention['num']!=null?$s_retention['num']:0,
			't_retention'=>$t_retention['num']!=null?$t_retention['num']:0,
			'se_retention'=>$se_retention['num']!=null?$se_retention['num']:0,
			'rechargeCount' => $rechargeCount['count'] !=null?$rechargeCount['count']:0,
			'rechargeMoney' => $rechargeMoney['money'] !=null?$rechargeMoney['money']:0,
			'n_rechargeCount' => $n_rechargeCount['count'] !=null?$n_rechargeCount['count']:0,
			'n_rechargeMoney' => $n_rechargeMoney['money'] !=null?$n_rechargeMoney['money']:0,
			'rate' => $rate,
			'n_rate' => $n_rate,
			'diamondThree' => $diamondThree['num'] !=null?$diamondThree['num']:0,
			'diamondTwo' => $diamondTwo['num'] !=null?$diamondTwo['num']:0,
			'diamondOne' => $diamondOne['num'] !=null?$diamondOne['num']:0,
			'diamondFive' => $diamondFive['num'] !=null?$diamondFive['num']:0,
			'n_diamondOne' => $n_diamondOne['num'] !=null?$n_diamondOne['num']:0,
			'n_diamondFive' => $n_diamondFive['num'] !=null?$n_diamondFive['num']:0,
			'n_diamondZero' => $n_diamondZero['num'] !=null?$n_diamondZero['num']:0,
			'nowPepole' => 0
		);
	}

	//创建留存
	public static function calcutorDayToOtherDayString($db ='',$dayNumber='',$thisMonthFirstDay='',$thisMonthEndDay=''){
		if(empty($db)||empty($dayNumber)||empty($thisMonthFirstDay)||empty($thisMonthEndDay)){
			return;
		}
		
		$sql = "SELECT COUNT( DISTINCT userid,DATE_FORMAT(time,'%Y-%m-%d')) as num ,DATE_FORMAT(time,'%Y-%m') as months FROM (


							select  uid0 as userid,created as time from ninedt_battle_log where uid0 !=0

							UNION ALL

							select uid1 , created as time from ninedt_battle_log where uid1 !=0  

							UNION ALL

							select uid2 ,created as time from ninedt_battle_log where uid2 !=0  

							UNION ALL

							select uid3 ,created as time from ninedt_battle_log where uid3 !=0 
							
							UNION ALL

							select uid4 ,created as time from ninedt_battle_log where uid4 !=0


				) as t2 WHERE time between '".$thisMonthFirstDay."' and '".$thisMonthEndDay."' AND userid in (select m_lUid from 

				ninedt_user where  to_days(m_RegisterTime) = to_days(date_sub(time,interval $dayNumber day))) GROUP BY months";
				// STools::log($sql);
				// STools::log("\n");
				return $db->query($sql)->fetch();
	}

	//钻石日消耗
	public static function calcutorCostToNexString($db='',$beginString='',$endString='',$thisMonthFirstDay='',$thisMonthEndDay=''){

		if(empty($db)||empty($beginString))return 0;

		$where =" costall > " .$beginString;
		if($endString){
			$where.= " AND costall < ".$endString;
		}

		$sql="select count(userid) as num , DATE_FORMAT(days,'%Y-%m') as months from (

					select ABS(SUM(temp.cost)) as costall ,DATE_FORMAT(temp.time,'%Y-%m-%d') as days ,temp.userid  from (

					select uid0 as userid,cost0 as cost,created as time from ninedt_battle_log where uid0 !=0  

					UNION ALL

					select uid1 , cost1,created as time from ninedt_battle_log  where uid1 !=0 

					UNION ALL

					select uid2 ,cost2,created as time from ninedt_battle_log  where uid2 !=0 

					UNION ALL

					select uid3 ,cost3,created as time from ninedt_battle_log where uid3 !=0 

					UNION ALL

					select uid4 ,cost4,created as time from ninedt_battle_log where uid4 !=0 

					) temp  WHERE temp.time between '".$thisMonthFirstDay."' AND '".$thisMonthEndDay."' GROUP BY temp.userid,days

		) temp2 WHERE ".$where." GROUP BY months";
		return $db->query($sql)->fetch();
	}
	//新增钻石日消耗
	public static function calcutorCostNewToNextString($db='',$beginString='',$endString='',$type ='',$thisMonthFirstDay='',$thisMonthEndDay=''){
		if(empty($db)||is_null($beginString)) return 0;
		if($type){
			$where =" costall = ".$beginString;
		}else{
			$where =" costall > " .$beginString;
		}
		if($endString){
			$where.= " AND costall < ".$endString;
		}

		$sql="select count(userid) as num , DATE_FORMAT(days,'%Y-%m') as months from (

					select ABS(SUM(temp.cost)) as costall ,DATE_FORMAT(temp.time,'%Y-%m-%d') as days ,temp.userid  from (

					select uid0 as userid,cost0 as cost,created as time from ninedt_battle_log where uid0 !=0  

					UNION ALL

					select uid1 , cost1,created as time from ninedt_battle_log  where uid1 !=0 

					UNION ALL

					select uid2 ,cost2,created as time from ninedt_battle_log  where uid2 !=0 

					UNION ALL

					select uid3 ,cost3,created as time from ninedt_battle_log where uid3 !=0 

					UNION ALL

					select uid4 ,cost4,created as time from ninedt_battle_log where uid4 !=0 

					) temp  WHERE temp.time between '".$thisMonthFirstDay."' AND '".$thisMonthEndDay."'  and 

					temp.userid in (select m_lUid from ninedt_user where  to_days(m_RegisterTime) = to_days(temp.time)) GROUP BY temp.userid,days

		) temp2 WHERE ".$where." GROUP BY months";
		// exit($sql);
		return $db->query($sql)->fetch();
	}

	//计算付费率
	public static function calcutorRate($molecule ='',$Denominator=''){
		if(empty($Denominator)||empty($molecule)) return 0;

		if($molecule<=0||$Denominator<=0){
			return 0;
		}
		return round($molecule/$Denominator*100,2);
	}
	
}