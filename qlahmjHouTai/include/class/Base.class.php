<?php
if(!defined('ACCESS')) {exit('Access denied.');}
class Base {
	
/*	protected static $table_prefix = OSA_TABLE_PREFIX;
	protected static $table_prefix_t = T_TABLE_PREFIX;
	protected static $table_prefix_osa_t = OSA_T_TABLE_PREFIX;*/
	protected static $db_container = array();
	protected static $db_Redis =array();
	
	public static function __instance($database=pigcms_admin){
		if( @self::$db_container[$database]  == null ){
			self::$db_container[$database] = new Medoo( $database );
			return self::$db_container[$database];
		}
		return self::$db_container[$database];
	}

	public static function curl_init($url){
		
		$ch = curl_init();
        //设置选项，包括URL
        curl_setopt($ch, CURLOPT_URL, $url);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
    	curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, false);
        //执行并获取HTML文档内容
        $output = curl_exec($ch);
        //释放curl句柄
        curl_close($ch);
        return $output;
	}

	public static function curl_post($url,$post_data){
		if(empty($url)||empty($post_data)) return;
		//初始化
   		$curl = curl_init();
      	//设置抓取的url
      	curl_setopt($curl, CURLOPT_URL, $url);
      	//设置头文件的信息作为数据流输出
      	// curl_setopt($curl, CURLOPT_HEADER, 1);
      	//设置获取的信息以文件流的形式返回，而不是直接输出。
      	curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
      	//设置post方式提交
     	curl_setopt($curl, CURLOPT_POST, 1);
     	//设置post数据
     	curl_setopt($curl, CURLOPT_POSTFIELDS, $post_data);
     	//执行命令
     	$data = curl_exec($curl);
     	//关闭URL请求
     	curl_close($curl);
     	// 显示获得的数据
     	return $data;
	}

	public static function __ConnectRedis($database=pigcms_redis){
		if(@self::$db_Redis[$database]==null){
			global $DATABASE_LIST;
			$redis = new Redis();
			$redis->connect($DATABASE_LIST[$database]['host'], $DATABASE_LIST[$database]['port']);  
			$redis->auth($DATABASE_LIST[$database]['password']);
			self::$db_Redis[$database] = $redis;
			return self::$db_Redis[$database];
		}
		return self::$db_Redis[$database];
	}
	/** 
	 * 创建(导出)Excel数据表格 
	 * @param  array   $list 要导出的数组格式的数据 
	 * @param  string  $filename 导出的Excel表格数据表的文件名 
	 * @param  array   $header Excel表格的表头 
	 * @param  array   $index $list数组中与Excel表格表头$header中每个项目对应的字段的名字(key值) 
	 * 比如: $header = array('编号','姓名','性别','年龄'); 
	 *       $index = array('id','username','sex','age'); 
	 *       $list = array(array('id'=>1,'username'=>'YQJ','sex'=>'男','age'=>24)); 
	 * @return [array] [数组] 
	*/  
	public static function createtable($list,$filename,$header=array(),$index = array()){    
	    header("Content-type:application/vnd.ms-excel");    
	    header("Content-Disposition:filename=".$filename.".xls");    
	    $teble_header = implode("\t",$header);  
	    $strexport = $teble_header."\r";  
	    foreach ($list as $row){    
	        foreach($index as $val){  
	            $strexport.=$row[$val]."\t";     
	        }  
	        $strexport.="\r";
	    }    
	    $strexport=iconv('UTF-8',"GB2312//IGNORE",$strexport);    
	    exit($strexport);       
	}


	public static function checkaDataCharset($string){
		$encode = mb_detect_encoding($string, array("ASCII","UTF-8","GB2312","GBK","BIG5")); 
		return $encode;
	}   

	/**
	 * [getAUInfo 通过ID获取代理ID代理昵称,玩家ID玩家昵称]
	 * @Author   李龙
	 * @DateTime 2018-09-07T14:06:28+0800
	 * @param    [type]                   $type   [判断ID是代理ID还是玩家ID]
	 * @param    [type]                   $auid   [ID]
	 * @param    [type]                   $prefix [前缀,用于区分]
	 * @return   [type]                           [description]
	 */
	public static function getAUInfo($type,$auid,$prefix='M'){
		$db = self::__instance();
		if(empty($type)||empty($auid)) return;
		if($type == 'agentid'){
			$type = "  ai.agentid ";
		}else if($type == 'userid'){
			$type = " ui.userid ";
		}else{
			return;
		}
		$where ="  where $type = '$auid'";
		$sql = 'SELECT
					ui.userid as '.$prefix.'userid,
					ui.nickname as '.$prefix.'nickname,
					ai.agentid as '.$prefix.'agentid,
					ai.agentname as '.$prefix.'agentname,
					left(al.name,2) as '.$prefix.'name
				FROM
					agent_info ai
				LEFT JOIN user_info ui ON ui.userid = ai.userid
				LEFT JOIN agent_level al ON ai.levelid = al.levelid '.$where;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result)return $result;else return array();
	}

}