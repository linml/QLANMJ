<?php 
require ('../include/init.inc.php');

$gagentid = $diamondCount='';
extract ( $_REQUEST, EXTR_IF_EXISTS );


if(Common::isPost()){
	if(!empty($gagentid)||!empty($diamondCount)){
		//调用充值方法
		$result = AgentCenter::allotDiamondsToTheAgent($gagentid,$diamondCount);
		if(-1==$result) exit("<script>alert('".iconv("UTF-8","GB2312//IGNORE",'对不起,划拨失败,请重试！')."');window.location.href='sendmoney.php?gagentid=$gagentid';</script>");else 
		if(0==$result) exit("<script>alert('".iconv("UTF-8","GB2312//IGNORE",'代理不存在或代理非下级！')."');window.location.href='sendmoney.php?gagentid=$gagentid';</script>");else
		if(1==$result) exit("<script>alert('".iconv("UTF-8","GB2312//IGNORE",'恭喜您,划拨成功！')."');window.location.href='agents.php';</script>"); else
		exit(); 
	}
}

// 获取当前库存
$agentid = UserSession::getAgentId();
$AgentsInfo = AgentCenter::getAgentInfoByAgentId($agentid);

Template::assign ('gagentid', $gagentid);
Template::assign ('diamond', $AgentsInfo['diamond']);
Template::display ( 'agentcenter/toSendMoney.tpl' );