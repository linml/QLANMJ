<?php /* Smarty version Smarty-3.1.15, created on 2018-08-14 10:09:03
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toInvitePlayers.tpl" */ ?>
<?php /*%%SmartyHeaderCode:139625b601eb07666b5-46451345%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'a85fa309ccf879f42618efb7ad15f8b936b035cf' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toInvitePlayers.tpl',
      1 => 1534151281,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '139625b601eb07666b5-46451345',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b601eb076e3b2_83546958',
  'variables' => 
  array (
    'shareImages' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b601eb076e3b2_83546958')) {function content_5b601eb076e3b2_83546958($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header" style="background-image:url( /assets/images/agentCenter/headerBg4.png );">
    <a href="home.php" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">邀请玩家</div>
</div>

<img src="<?php echo $_smarty_tpl->tpl_vars['shareImages']->value;?>
"  id ="invitePlayer" alt="">

<script>
	$(function(){
		$("#invitePlayer").toggle(function(){
			$('.N_Header').slideUp();
		},function(){
			$('.N_Header').slideDown();
		});		
	});	
</script>
<?php }} ?>
