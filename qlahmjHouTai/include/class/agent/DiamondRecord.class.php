<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class DiamondRecord extends Base {

	private static $log_funds_admin = 'log_funds_admin';
	private static $log_funds_agent = 'log_funds_agent';
	private static $log_funds_user  = 'log_funds_user';
	private static $order_transfer  = 'order_transfer';
	private static $agent_transfer  = 'agent_transfer';
	private static $agent_info      = 'agent_info';
	private static $user_info       = 'user_info';
	private static $order_pay       = 'order_pay';
	private static $pigcms_user     = 'pigcms_user';

	/**
	 * [getWhere 处理筛选条件]
	 * @Author   李龙
	 * @DateTime 2018-09-09T17:27:58+0800
	 * @param    [type]                   $method    [方法]
	 * @param    [type]                   $type      [筛选类型]
	 * @param    [type]                   $contains  [筛选内容]
	 * @param    [type]                   $startdate [开始时间]
	 * @param    [type]                   $enddate   [结束时间]
	 * @return   [type]                              [返回条件字符串]
	 */
	public static function getWhere($method,$type,$contains,$startdate,$enddate){

		switch ($method) {
			case 'getRechargeDiamondRecod':
				$type = self::getWhereAux($type,$contains,$method);
				if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
				if($startdate&&$enddate) $time = " and lfa.addtime between '$startdate' and '$enddate' ";else $time = "";
				break;
			case 'getAgentTransferRecord':
				$type = self::getWhereAux($type,$contains,$method);
				if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
				if($startdate&&$enddate) $time = " and lfa.addtime between '$startdate' and '$enddate' ";else $time = "";
				break;
			case 'buyDiamondRecord':
				$type = self::getWhereAux($type,$contains,$method);			
				if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
				if($startdate&&$enddate) $time = " and lfa.addtime between '$startdate' and '$enddate' ";else $time = "";
				break;
			case 'systemTransfer':
				$type = self::getWhereAux($type,$contains,$method);
				if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
				if($startdate&&$enddate) $time = " and ot.addtime between '$startdate' and '$enddate' ";else $time = "";
				break;
			case 'systemSendAndSold':
				$type = self::getWhereAux($type,$contains,$method);	
				if($startdate==$enddate&&!empty($startdate)&&!empty($enddate)) $startdate = $startdate." 00:00:00";$enddate = $enddate." 23:59:59";
				if($startdate&&$enddate) $time = " and ot.addtime between '$startdate' and '$enddate' ";else $time = "";
				break;
			default:
				break;
		}
		$where = $type.$time;
		return $where;
	}

	/**
	 * [getWhereAux 辅助组织条件]
	 * @Author   李龙
	 * @DateTime 2018-09-09T17:28:52+0800
	 * @param    [type]                   $type     [筛选类型]
	 * @param    [type]                   $contains [筛选内容]
	 * @return   [type]                             [description]
	 */
	public static function getWhereAux($type,$contains,$method){
		if(empty($type)) $type = "";
		if(empty($contains)) $type = "";
		switch ($type) {
			case '1':
				switch ($method) {
					case 'getRechargeDiamondRecod':
						$type = " and lfu.userid = ".$contains;
						break;
					case 'getAgentTransferRecord':
						$ret =  parent::getAUInfo('userid',$contains,'M');
						$type = " and at.auid ".$ret['agentid'];
						break;
					case 'buyDiamondRecord':
						$type = "";
						break;
					case 'systemTransfer':
						$type = "";
						break;
					case 'systemSendAndSold':
						$type = " and ot.toauid = ".$contains;
						break;
					default:
						# code...
						break;
				}
				break;
			case '2':
				switch ($method) {
					case 'getRechargeDiamondRecod':
						$type = " and ui.nickname like '%$contains%'";
						break;
					case 'getAgentTransferRecord':
						$type = " and ui.nickname like '%$contains%'";
						break;
					case 'buyDiamondRecord':
						$type = "";
						break;
					case 'systemTransfer':
						$type = "";
						break;
					case 'systemSendAndSold':
						$type = "";
						break;
					default:
						# code...
						break;
				}
				break;
			case '3':
				switch ($method) {
					case 'getRechargeDiamondRecod':
						$ret = parent::getAUInfo('userid',$contains);
						$type = " and lfa.agentid = ".$ret['Magentid'];
						break;
					case 'getAgentTransferRecord':
						$ret = parent::getAUInfo('userid',$contains);					
						$type = " and lfa.agentid = ".$ret['Magentid'];
						break;
					case 'buyDiamondRecord':
						$ret = parent::getAUInfo('userid',$contains);					
						$type = " and lfa.agentid = ".$ret['Magentid'];
						break;
					case 'systemTransfer':
						$type = " and ui.userid = ".$contains;
						break;
					case 'systemSendAndSold':
						$type = "";
						break;
					default:
						# code...
						break;
				}
				break;
			case '4':
				switch ($method) {
					case 'getRechargeDiamondRecod':
						
						$type = " and b.nickname like '%$contains%'";
						break;
					case 'getAgentTransferRecord':
						$type = " and c.nickname like '%$contains%'";
						break;
					case 'buyDiamondRecord':
						$type = " and ui.nickname like '%$contains%'";					
						break;
					case 'systemTransfer':
						$type = " and ui.nickname like '%$contains%'";
						break;
					case 'systemSendAndSold':
						$type = "";
						break;
					default:
						# code...
						break;
				}
				break;
			default:
				# code...
				break;
		}
		return $type;
	}


	/**
	 * [getRechargeDiamondRecod 获取充钻记录--代理为玩家充钻]
	 * @Author   李龙
	 * @DateTime 2018-09-07T14:18:15+0800
	 * @param    [type]                   $start     [开始页码]
	 * @param    string                   $page_size [每页显示条目]
	 * @param    [type]                   $where     [筛选条件]
	 * @return   [type]                              [description]
	 */
	public static function  getRechargeDiamondRecod($start,$page_size='',$where){
		if(empty($page_size)) return;else $limit =" limit $start,$page_size";
		$db = self::__instance();
		$sql = 'SELECT
					lfu.relationid,
					lfu.addtime,
					lfu.userid,
					ui.nickname,
					lfu.fundmoney,
					lfu.agomoney,
					lfa.agentid,
					b.userid AS buserid,
					b.nickname AS bnickname,
					at.status
				FROM
					log_funds_user lfu
				LEFT JOIN log_funds_agent lfa ON lfu.relationid = lfa.relationid
				LEFT JOIN agent_transfer at ON lfu.relationid = at.id
				LEFT JOIN user_info ui ON lfu.userid = ui.userid
				LEFT JOIN agent_info ai ON lfa.agentid = ai.agentid
				LEFT JOIN user_info b ON ai.userid = b.userid
				where lfu.fundtype = "22"
				and lfa.fundtype = "81"
				and lfa.accounttype = "VD"
				and lfu.accounttype = "VD" '.$where.' order by lfu.addtime desc '.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getAgentTransferRecord 获取代理划拨记录---代理划拨给代理]
	 * @Author   李龙
	 * @DateTime 2018-09-07T14:20:37+0800
	 * @param    [type]                   $srart     [description]
	 * @param    string                   $page_size [description]
	 * @param    [type]                   $where     [description]
	 * @return   [type]                              [description]
	 */
	public static function getAgentTransferRecord($start,$page_size='',$where){
		if(empty($page_size)) return;else $limit =" limit $start,$page_size ";
		$db = self::__instance();
			$sql = 'SELECT
						lfa.relationid,
						lfa.addtime,
						at.agentid,
						at.auid,
						ui.userid,
						ui.nickname,
						lfa.fundmoney,
						lfa.agomoney,
						lfa.agentid,
						c.userid as cuserid,
						c.nickname as cnickname,
						at.status
					FROM
						log_funds_agent lfa
					LEFT JOIN agent_transfer AT ON lfa.relationid = at.id
					AND lfa.agentid = at.auid
					LEFT JOIN agent_info ai on at.agentid = ai.agentid
					LEFT join user_info ui on ai.userid = ui.userid
					LEFT join agent_info b on lfa.agentid = b.agentid
					left join user_info c on b.userid = c.userid
					WHERE
						lfa.accounttype = "VD"
					AND lfa.fundtype = "82"
					AND at.cashtype = "H" '.$where.' order by lfa.addtime desc '.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [buyDiamondRecord 进钻记录---代理充钻（余额，微信）]
	 * @Author   李龙
	 * @DateTime 2018-09-07T16:03:59+0800
	 * @param    [type]                   $srart     [description]
	 * @param    string                   $page_size [description]
	 * @param    [type]                   $where     [description]
	 * @return   [type]                              [description]
	 */
	public static function buyDiamondRecord($start,$page_size='',$where){
		if(empty($page_size)) return;else $limit =" limit $start,$page_size ";	
		$db = self::__instance();
			$sql = 'SELECT
						lfa.relationid,
						lfa.addtime,
						lfa.agentid,
						ui.userid,
						ui.nickname,
						al.name,
						lfa.fundmoney,
						lfa.fundtype
					FROM
						log_funds_agent lfa
					LEFT JOIN agent_info ai ON lfa.agentid = ai.agentid
					LEFT JOIN user_info ui ON ai.userid = ui.userid
					LEFT JOIN agent_level al ON ai.levelid = al.levelid
					WHERE
						1 = 1
					AND lfa.accounttype = "VD" 
					AND (
						lfa.fundtype = "80"
						OR lfa.fundtype = "83"
					)'.$where.' order by lfa.addtime desc '.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		foreach ($result as $key => $value) {
			if($result[$key]['fundtype'] == '80'){
				$result[$key] = array_merge($result[$key],self::buyDiamondRecordAuxOrderPay($result[$key]['relationid']));
			}else if($result[$key]['fundtype'] == '83'){
				$result[$key] = array_merge($result[$key],self::buyDiamondRecordAuxAgentTransfer($result[$key]['relationid']));
				$result[$key] = array_merge($result[$key],array('paytype'=>'余额'));
			}
		}
		if($result) return $result;else return array();
	}

	/**
	 * [buyDiamondRecordAuxOrderPay 代理充值---微信充钻]
	 * @Author   李龙
	 * @DateTime 2018-09-07T15:59:46+0800
	 * @param    [type]                   $relationid [description]
	 * @return   [type]                               [description]
	 */
	public static function buyDiamondRecordAuxOrderPay($relationid){
		if(empty($relationid)) return ;
		$db = self::__instance();
		$sql = 'SELECT
					op.rmb,
					op.status,
					op.paytype
				FROM
					'.self::$order_pay.' op
				LEFT JOIN '.self::$log_funds_agent.' lfa
				ON lfa.relationid = op.id
				WHERE
					op.id = "'.$relationid.'"';
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}


	/**
	 * [buyDiamondRecordAuxAgentTransfer 代理充值----余额充钻]
	 * @Author   李龙
	 * @DateTime 2018-09-07T16:00:07+0800
	 * @param    [type]                   $relationid [description]
	 * @return   [type]                               [description]
	 */
	public static function buyDiamondRecordAuxAgentTransfer($relationid){
		if(empty($relationid)) return ;
		$db = self::__instance();
		$sql = 'SELECT
					at.rmb,
					at.status
				FROM
					'.self::$agent_transfer.' at				
				WHERE
					at.id = "'.$relationid.'"';
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	
	/**
	 * [systemTransfer 管理给代理充或赠钻]
	 * @Author   李龙
	 * @DateTime 2018-09-07T18:04:59+0800
	 * @param    [type]                   $srart     [description]
	 * @param    string                   $page_size [description]
	 * @param    [type]                   $where     [description]
	 * @return   [type]                              [description]
	 */
	public static function systemTransfer($start,$page_size='',$where){
		if(empty($page_size)) return;else $limit =" limit $start,$page_size";		
		$db = self::__instance();
		$sql = 'SELECT
					ot.id,
					ot.addtime,
					ot.auid,
					ot.toauid,
					ot.transfertype,
					ot.rmb,
					pu.user_name,
					ui.userid,
					ui.nickname,
					al.name,
					pu.real_name as adminrealname,
					lfa.fundmoney
				FROM
					'.self::$order_transfer.' ot
				INNER JOIN '.self::$log_funds_agent.' lfa ON ot.id = lfa.relationid
				LEFT JOIN '.self::$pigcms_user.' pu ON pu.user_id = ot.auid
				LEFT JOIN agent_info ai ON ot.toauid = ai.agentid
				LEFT JOIN user_info ui ON ai.userid = ui.userid 
				LEFT JOIN agent_level al ON al.levelid = ai.levelid 
				WHERE
					ot.accounttype = "VD" 
				AND (
					ot.transfertype = "2"
					OR ot.transfertype = "4"
				) '.$where.' order by ot.addtime desc '.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}


	/**
	 * [systemSendAndSold 管理给玩家充或者赠钻]
	 * @Author   李龙
	 * @DateTime 2018-09-07T18:37:26+0800
	 * @param    [type]                   $srart     [description]
	 * @param    string                   $page_size [description]
	 * @param    [type]                   $where     [description]
	 * @return   [type]                              [description]
	 */
	public static function systemSendAndSold($start,$page_size='',$where){
		if(empty($page_size)) return;else $limit =" limit $start,$page_size";
		$db = self::__instance();
		$sql = 'SELECT
					ot.id,
					ot.addtime,
					ot.auid,
					ot.toauid,
					ot.transfertype,
					ot.rmb,
					ui.userid,
					ui.nickname,
					pu.user_name,
					pu.real_name as adminrealname,
					lfu.fundmoney
				FROM
					'.self::$order_transfer.' ot
				INNER JOIN '.self::$log_funds_user.' lfu ON ot.id = lfu.relationid
				LEFT JOIN '.self::$user_info.' ui ON ui.userid = ot.toauid
				LEFT JOIN '.self::$pigcms_user.' pu ON pu.user_id = ot.auid
				WHERE
					ot.accounttype = "VD" 
				AND (
					ot.transfertype = "1"
					OR ot.transfertype = "3"
				) '.$where.' order by ot.addtime desc '.$limit;
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getRowCount 获取条目数]
	 * @Author   李龙
	 * @DateTime 2018-09-09T17:29:51+0800
	 * @param    [type]                   $method [方法]
	 * @param    [type]                   $where  [筛选条件]
	 * @return   [type]                           [返回条目数]
	 */
	public static function getRowCount($method,$where=''){
		$db = self::__instance();
		$sql = '';
		if(empty($method)) $method = 'getRechargeDiamondRecod';
		switch ($method) {
			case 'getRechargeDiamondRecod':
				$sql = 'SELECT
						count(lfu.id)
						FROM
							log_funds_user lfu
						LEFT JOIN log_funds_agent lfa ON lfu.relationid = lfa.relationid
						LEFT JOIN agent_transfer at ON lfu.relationid = at.id
						LEFT JOIN user_info ui ON lfu.userid = ui.userid
						LEFT JOIN agent_info ai ON lfa.agentid = ai.agentid
						LEFT JOIN user_info b ON ai.userid = b.userid
						where lfu.fundtype = "22"
						and lfa.fundtype = "81"
						and lfa.accounttype = "VD"
						and lfu.accounttype = "VD" '.$where;
				break;
			case 'getAgentTransferRecord':
				$sql = 'SELECT
						count(lfa.id)
					FROM
						log_funds_agent lfa
					LEFT JOIN agent_transfer AT ON lfa.relationid = at.id
					AND lfa.agentid = at.auid
					LEFT JOIN agent_info ai on at.agentid = ai.agentid
					LEFT join user_info ui on ai.userid = ui.userid
					LEFT join agent_info b on lfa.agentid = b.agentid
					left join user_info c on b.userid = c.userid
					WHERE
						lfa.accounttype = "VD"
					AND lfa.fundtype = "82"
					AND at.cashtype = "H" '.$where;
				break;
			case 'buyDiamondRecord':
				$sql = 'SELECT
						count(lfa.id)
						FROM
							log_funds_agent lfa
						LEFT JOIN agent_info ai ON lfa.agentid = ai.agentid
						LEFT JOIN user_info ui ON ai.userid = ui.userid
						LEFT JOIN agent_level al ON ai.levelid = al.levelid
						WHERE
							1 = 1
						AND lfa.accounttype = "VD" 
						AND (
							lfa.fundtype = "80"
							OR lfa.fundtype = "83"
						) '.$where;
				break;
			case 'systemTransfer':
				$sql = 'SELECT
					count(ot.id)
						FROM
							'.self::$order_transfer.' ot
						INNER JOIN '.self::$log_funds_agent.' lfa ON ot.id = lfa.relationid
						LEFT JOIN '.self::$pigcms_user.' pu ON pu.user_id = ot.auid
						LEFT JOIN agent_info ai ON ot.toauid = ai.agentid
						LEFT JOIN user_info ui ON ai.userid = ui.userid 
						LEFT JOIN agent_level al ON al.levelid = ai.levelid 
						WHERE
							ot.accounttype = "VD" 
						AND (
							ot.transfertype = "2"
							OR ot.transfertype = "4"
						) '.$where;
				break;
			case 'systemSendAndSold':
				$sql = 'SELECT
					count(ot.id)
						FROM
							'.self::$order_transfer.' ot
						INNER JOIN '.self::$log_funds_user.' lfu ON ot.id = lfu.relationid
						LEFT JOIN '.self::$user_info.' ui ON ui.userid = ot.toauid
						LEFT JOIN '.self::$pigcms_user.' pu ON pu.user_id = ot.auid
						WHERE
							ot.accounttype = "VD" 
						AND (
							ot.transfertype = "1"
							OR ot.transfertype = "3"
						) '.$where;
				break;
			default:
				break;
		}
		return 0 + $db->query($sql)->fetchColumn();
	}
}