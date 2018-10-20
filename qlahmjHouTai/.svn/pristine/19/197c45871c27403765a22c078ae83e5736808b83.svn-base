<?php
require ('../include/init.inc.php');
$invite = $invited ='';

extract ( $_REQUEST, EXTR_IF_EXISTS );

$gems = PresentGems::getGems();

if (Common::isPost ()) {
		$level_data =array('own_gems'=>$invite,'other_gems'=>$invited);
		$result     = PresentGems::updateGems($level_data);
		
		$level_data =array('own_gems'=>$invite,'other_gems'=>$invited);
		if ($result>=0) {
			SysLog::addLog ( UserSession::getUserName(), '修改', '获赠钻石' ,'', json_encode($level_data) );
			Common::exitWithSuccess ( '提成设置完成','agent/presentgems.php' );
		} else {
			OSAdmin::alert("error");
		}
}
Template::assign ( 'gems', $gems[0]);
Template::display ( 'agent/presentgems.tpl' );