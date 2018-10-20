<?php /* Smarty version Smarty-3.1.15, created on 2018-07-26 16:34:17
         compiled from "F:\project\qlahmjHouTai\include\template\agent\agentBinding.tpl" */ ?>
<?php /*%%SmartyHeaderCode:127995b59797991a2f5-93009887%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'b739b8f16d20c1378be0cc7e16b9befcae3d1c7a' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agent\\agentBinding.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '127995b59797991a2f5-93009887',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b5979799c2295_29548381',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b5979799c2295_29548381')) {function content_5b5979799c2295_29548381($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<div id="tab" autocomplete="off" class="form-horizontal" role="form">
		    <div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">玩家ID:</label>
				<div class="col-sm-9">
					<input type="number" name="gameUserid" id='gameUserid'>
					<span id='game_msg'></span>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">代理ID:</label>
				<div class="col-sm-9">
					<input type="number" name="agentid" id='agentid'>
					<span id='agent_msg'></span>
				</div>
			</div>

			<div class="form-group">
				<div class="col-md-offset-3 col-md-9">
					<button class="btn btn-info" type="submit" id='checkOther' >绑定</button>
				</div>
			</div>
			<div style="clear:both;"></div>
		</div>
	</div>
</div>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<script type="text/javascript">
	$('#gameUserid').focus(function(event) {
		$('#game_msg').text('');
		$('#gameUserid').val('');
		$('#game_msg').attr('name','no');
		// $('#checkOther').text('绑定');
	});
	$('#gameUserid').blur(function(){
	 	var gameUserid = $('#gameUserid').val();
	 	if(!gameUserid) return;
	 	if(gameUserid ==0){
	 		$('#game_msg').text('玩家不存在,请检查玩家ID是否正确！');
	 		return;
	 	}
	 	$.ajax({
	 		url:'/houtai/agent/agentBinding.php',
	 		data:{
	 			method:'getGameInfor',
	 			gameUserid:gameUserid
	 		},
	 		type:'POST',
	 		dataType:'',
	 		success:function(res){
	 			res = jQuery.parseJSON(res);
	 			if(res['result']){
	 				$('#game_msg').text(res['result']);
	 				return;
	 			}
	 			$('#game_msg').text('('+res['m_lUid']+')'+res['m_sNickName']);
	 			$('#game_msg').attr('name','ok');
	 		},
	 		error:function(){
	 		}
	 	});
	});
	$('#agentid').focus(function(event) {
		$('#agent_msg').text('');
		$('#agentid').val('');
		$('#checkOther').text('绑定');
		$('#agent_msg').attr('name','no');
	});
	$('#agentid').blur(function(){
	 	var agentid = $('#agentid').val();
	 	if(!agentid) return;
	 	if(agentid ==0){
	 		$('#agent_msg').text('解除绑定上级！');
	 		$('#checkOther').text('解除');
	 		return;
	 	}
	 	$.ajax({
	 		url:'/houtai/agent/agentBinding.php',
	 		data:{
	 			method:'getAgentInfor',
	 			agentid:agentid
	 		},
	 		type:'POST',
	 		dataType:'',
	 		success:function(res){
	 			res = jQuery.parseJSON(res);
	 			if(res['result']){
	 				$('#agent_msg').text(res['result']);
	 				return;
	 			}
	 			$('#agent_msg').text('('+res['user_game_id']+')'+res['nickName']);
	 			$('#agent_msg').attr('name','ok');
	 		},
	 		error:function(){

	 		}
	 	});
	});

	$('#checkOther').click(function(event){
		var gameUserid = $('#gameUserid').val();
		var agentid = $('#agentid').val();
		var game_msg = $('#game_msg').attr('name');
		var agent_msg = $('#agent_msg').attr('name');
		
		if(game_msg=='ok'&& agent_msg=='ok'||game_msg=='ok'&&agentid==0){
			$.ajax({
				url: '/houtai/agent/agentBinding.php',
				type: 'POST',
				dataType: '',
				data: {
					method:'changeAgentRelationShip',
					gameUserid:gameUserid,
					agentid:agentid
				},
				success:function(res){
					res = jQuery.parseJSON(res);
					window.location.reload();
					alert(res['result']);
				},
				error:function(){
				}
			});
		}else{
			alert('请检查信息是否有误！');
			return false;
		}
	});

</script>


<?php }} ?>
