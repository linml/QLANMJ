<?php
require ('../include/init.inc.php');
$method = $playerid = $real_name = $mobile = $agentid = $wechat = $r_type = $isTop= '';
extract ( $_POST, EXTR_IF_EXISTS );

if($method =='getAgentTopInfor'&&!empty($playerid)){
	$agent = Agent::getAgentIsTopInfor($playerid);
	exit('{"agentid":"'.$agent['user_game_id'].'","nickname":"'.$agent['nickName'].'"}');
}

if($method=='getGameInfor'&&!empty($playerid)){
	$bingAgentData = GamePlayer::getGameUserByUserid($playerid);
	if($bingAgentData) 
		exit(json_encode($bingAgentData));
	exit('{"result":"玩家不存在,请检查玩家ID是否正确！"}');
}

if($method=='getAgentInfor'&&!empty($agentid)){
	$bingAgentData = Agent::getAgentByOsaUserId($agentid);
	if($bingAgentData) 
		exit(json_encode($bingAgentData));
	exit('{"result":"代理不存在,请检查代理ID是否正确！"}');
}

if (Common::isPost ()) {
	if($isTop==1&&$r_type==1)
		$agentid = 1;
	if($playerid=="" || $real_name=="" || $mobile =="" || $wechat == '' || $agentid=='' ||$isTop == '' || $r_type ==''){
		OSAdmin::alert("error",ErrorMessage::NEED_PARAM);
	}
	$exist_player = GamePlayer::getGameUserByUserid($playerid);
	$player_is_agent = Agent::getAgentByOsaUserId($playerid);
	$player_tel = Agent::getAgentByTelphone($mobile);
	$player_weChat = Agent::getAgentByWechat($wechat);
	if($r_type==1&&$isTop!=1)
		$exist_agent = Agent::getAgentByOsaUserId($agentid);
	if($player_is_agent){
		OSAdmin::alert("error",ErrorMessage::PALYER_IS_AGENT);
	}else if(!$exist_player){
		OSAdmin::alert("error",ErrorMessage::TUSER_NOT_EXIST);
	}else if(!$exist_agent&&$r_type==1&&$isTop!=1){
		OSAdmin::alert("error",ErrorMessage::AGENT_NOT_EXIST);
	}else if($exist_agent&&$isTop!=1&&$r_type==1&&$exist_agent['istop'] > ($isTop -1)){
		OSAdmin::alert("error",ErrorMessage::FAIL_ISTOP_BEHIN);
	}else if($player_tel){
		OSAdmin::alert("error",ErrorMessage::PALYER_TEL_IS_EXIST);
	}else if($player_weChat){
		OSAdmin::alert("error",ErrorMessage::PALYER_WACHAT_IS_EXIST);
	}else{
		$s_id_topAgent = $exist_agent['id'];
		if($isTop==1){
			$jb_tb='总代';
			$isTop = 0;
			$flow = 0;
			$s_id_topAgent = 0;
		}
		if($isTop==2){
			$jb_tb = '一级';
			$isTop = 1;
			$flow = 65;
		}
		if($isTop==3){
			$jb_tb = '二级';
			$isTop = 2;
			$flow = 55;
		}
		if($isTop==4){
			$jb_tb = '三级';
			$isTop = 3;
			$flow = 45;
		}
		$input_agent_data = array ('user_game_id' => $playerid,'nickName'=>$real_name,'weChat'=>$wechat,'tel'=>$mobile,'pwd'=>'123456','status'=>1,'cardNum'=>0,'istop'=>$isTop,'s_id_dj'=>$jb_tb, 'flowpoint'=>$flow);
		if($r_type==1){
			$input_agent_data = array_merge($input_agent_data,array('s_id'=> $s_id_topAgent));
		}else if($r_type==2){
			$agentTop = Agent::getAgentIsTopInfor($playerid,$isTop);
			$playerCode = Agent::getGameTopCode($playerid);
			$tp_agentTop = 0;
			$tp_agent = 0;
			if($agentTop){
				if($agentTop=='e'){
					exit('玩家自己绑定了自己！');
				}else if($agentTop=='n') {
					exit('玩家ID或者设置等级为空！');
				}else {
					$tp_agentTop= $agentTop['id'];
					$tp_agent = $agentTop['user_game_id'];
				}
			}
			$input_agent_data = array_merge($input_agent_data,array('openid' => $playerCode,'s_id'=>$tp_agentTop));
		}

		$id = Agent::insertToAgentsMessage($input_agent_data);
		if($id){
			if($r_type==2){
				if($tp_agent!=null){
					var_dump($playerid);
					var_dump("\n");
					var_dump($tp_agent);
					// $msg =  Agent::changeAgentRelationShip($playerid,$tp_agent);
					OSAdmin::alert("success",$msg);
				}
			}else{
				OSAdmin::alert("success",ErrorMessage::SUCCESS);
			}
		}
	}
}


Template::assign ( '_POST',$_POST );
Template::assign ( 'page_title','注册' );
Template::Display ( 'agent/registerAgent.tpl' );