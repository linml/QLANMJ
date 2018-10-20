<?php

define ('ACCESS',1);
define ('IS_DEV',false);
//autoload 使用常量
define ( 'ADMIN_BASE',       dirname ( __FILE__ ) . '/../../include' );
define ( 'ADMIN_BASE_LIB',   ADMIN_BASE . '/lib/' );                   
define ( 'ADMIN_BASE_CLASS', ADMIN_BASE . '/class/' );                 
define ( 'ADMIN_BASE_QRCOD', dirname ( __FILE__ ) . '/../../assets' ); 

//Smarty模板使用常量
define ( 'TEMPLATE_DIR',        ADMIN_BASE . '/template/' );
define ( 'TEMPLATE_COMPILED',   ADMIN_BASE . '/compiled/' );
define ( 'TEMPLATE_PLUGINS',    ADMIN_BASE_LIB . 'Smarty/plugins/' );
define ( 'TEMPLATE_SYSPLUGINS', ADMIN_BASE_LIB . 'Smarty/sysplugins/' );
define ( 'TEMPLATE_CONFIGS',    ADMIN_BASE . '/config/' );
define ( 'TEMPLATE_CACHE',      ADMIN_BASE . '/cache/' );


//获取当前域名或主机地址
$currentHost = $_SERVER['HTTP_HOST'];

//游戏服务地址
//用于与大厅服通信 获取当前牌桌与在线玩家等信息
define('GAME_SERVER_HOST', 'http://192.168.1.211:9001');
//)I6y@#$%^sacsCXv
define('GAME_SERVER_TOKEN',')I6yVOQ,W.i=2CXv');

//服务公众号
define ('WeChat',"zqqp888");

//城市信息
define('CITY_NAME','安徽');

//游戏信息
define('GAME_NAME','合肥麻将');

//OSAdmin数据库设置
define ('pigcms_admin' ,"admin");

define ('pigcms_game' ,"game");

define ('pigcms_report' ,"report");

define ('pigcms_redis' ,"redis");
// http://zhiquqipai.admintest.magicred.net
//根据域名来连接数据，错误等信息
// if($currentHost == 'manage.qileah.cn')
if($currentHost == '192.168.1.16:91')
{
	error_reporting(E_ALL ^ E_NOTICE);

	/*$DATABASE_LIST[pigcms_admin] = array (
	"server"=>   "127.0.0.1",
	"port"=>     '3301',
	"username"=> 'root', 
	"password"=> '123456',
	"db_name"=>  'entertainment_76' );*/

	$DATABASE_LIST[pigcms_admin] = array (
	// "server"=>   "192.168.1.14",
	"server"=>   "106.14.180.115",
	"port"=>     '3301',
	"username"=> 'root', 
	"password"=> '0PZ0K9nq3N5XcLy',
	"db_name"=>  'entertainment_76' );


	/*$DATABASE_LIST[pigcms_game] = array (
	"server"=>   "127.0.0.1",
	"port"=>     '3306',
	"username"=> 'root', 
	"password"=> '0000',	
	"db_name"=>  't1mj' );

	$DATABASE_LIST[pigcms_report] = array (
	"server"=>   "127.0.0.1",
	"port"=>     '3306',
	"username"=> 'root', 
	"password"=> '0000',	
	"db_name"=>  'report' );

	$DATABASE_LIST[pigcms_redis] = array (
	"host"=>   "127.0.0.1",
	"port"=>    '6379',
	"password"=> 'Water123Water123'
	);*/

	//admin后台 本地
	// define('ADMIN_URL',  'http://manage.qileah.cn');
	define('ADMIN_URL',  'http://192.168.1.16:91');
	define('ADMIN_NAME', '管理员');
}else{
	echo "host error $currentHost";
	exit();
}

//OSAdmin常量
define ( 'ADMIN_TITLE' ,GAME_NAME.'管理后台');
define ( 'COMPANY_NAME' ,GAME_NAME);

//COOKIE加密密钥，建议修改
define( 'OSA_ENCRYPT_KEY','vuwisvinj$@!EDCdcazx1234');

//prefix不要更改，除非修改osadmin.sql文件中的所有表名
/*define ( 'OSA_TABLE_PREFIX' ,'pigcms_');
define ( 'T_TABLE_PREFIX' ,'t_');*/
// define ( 'OSA_T_TABLE_PREFIX' ,'osa_t_');

//配置cookie session 区分标识
define ( 'ADMIN' ,'admin');
define ( 'AGENT' ,'agent');

//页面设置
define ( 'DEBUG' ,false);

define ( 'PAGE_SIZE', 10);
//配置分组权限
define('GROUP_CONFIGURE',3);
//页面缓存刷新时间 毫秒 
define ( 'CASH_TIME', 900);

define ( 'DAY_TEMP', 'D');
define ( 'DAY_HISTORY', 'DOK');
define ( 'MONTH_TEMP', 'M');
define ( 'MONTH_HISTORY', 'MOK');
define ( 'GAME_CASH_NAME', 'hfmj');
//配置修改代理
define ( 'AGENT_C_RELATIONSHIP', 'http://101.132.117.161:5500/');
// $http = AGENT_C_RELATIONSHIP."setBindAgent?uid=".$gUserid."&agent=".$agentId;


//systemLog 中使用

/*$OSADMIN_COMMAND_FOR_LOG=array(    
    'SUCCESS'=>'成功',
    'ERROR'=>'失败',
    'ADD'=>'增加',
    'DELETE'=>'删除',
    'MODIFY'=>'修改',
    'LOGIN'=>'登录',
    'LOGOUT'=>'退出',
    'PAUSE'=>'封停',
    'PLAY'=>'解封',
);

$OSADMIN_CLASS_FOR_LOG=array(
    'ALL' => '全部',
    'User'=>'用户',
    'UserGroup'=>'账号组',
    'Module'=>'菜单模块',
    'MenuUrl'=>'功能',
    'GroupRole'=>'权限',
);*/

$CLUB_RALATIONSHIP = array(

	'clubId' =>'m_clubId' ,
	'clubName' =>'m_clubName' ,
	'clubOwner' =>'m_ownerId' ,
	'clubOwnerName' =>'m_ownerName' ,
	'time' =>'m_time' 
);

$CLUB_INFOR_FOR_CLUBID = array(
	'uid' =>'uid' ,
	'name' =>'name' ,
	'headUrl' =>'headUrl' ,
	'time' =>'time' 
);

?>