<?php /* Smarty version Smarty-3.1.15, created on 2018-06-12 15:13:00
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\acepanel\user_modify.tpl" */ ?>
<?php /*%%SmartyHeaderCode:261765b1f646cc5c8b3-35467923%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '3d0d146162d8c0c22821711799bb00778f606e58' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\user_modify.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '261765b1f646cc5c8b3-35467923',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'user' => 0,
    'group_options' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1f646cca2dc2_01238099',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1f646cca2dc2_01238099')) {function content_5b1f646cca2dc2_01238099($_smarty_tpl) {?><?php if (!is_callable('smarty_function_html_options')) include 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\config/../../include/lib/Smarty/plugins\\function.html_options.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">登录名 <span class="label label-info">不可修改</span></label>
				<div class="col-sm-9">
					<input type="text" name="user_name" value="<?php echo $_smarty_tpl->tpl_vars['user']->value['user_name'];?>
" class="input-xlarge" readonly="true">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">密码 <span class="label label-important" >如不修改请留空</span></label>
				<div class="col-sm-9">
					<input type="password" name="password" value="" class="input-xlarge">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">姓名</label>
				<div class="col-sm-9">
					<input type="text" name="real_name" value="<?php echo $_smarty_tpl->tpl_vars['user']->value['real_name'];?>
" class="input-xlarge" required="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">手机</label>
				<div class="col-sm-9">
					<input type="text" name="mobile" value="<?php echo $_smarty_tpl->tpl_vars['user']->value['mobile'];?>
" class="input-xlarge" required pattern="\d{11}">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">微信号</label>
				<div class="col-sm-9">
					<input  name="email" value="<?php echo $_smarty_tpl->tpl_vars['user']->value['email'];?>
"  class="input-xlarge" required="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">描述</label>
				<div class="col-sm-9">
					<textarea name="user_desc" rows="3" class="input-xlarge"><?php echo $_smarty_tpl->tpl_vars['user']->value['user_desc'];?>
</textarea>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">账号组</label>
				<div class="col-sm-9">
					<?php if ($_smarty_tpl->tpl_vars['user']->value['user_id']==1) {?>
					<?php echo smarty_function_html_options(array('name'=>'user_group','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['group_options']->value,'disabled'=>"true",'selected'=>$_smarty_tpl->tpl_vars['user']->value['user_group']),$_smarty_tpl);?>

					<?php } else { ?>
					<?php echo smarty_function_html_options(array('name'=>'user_group','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['group_options']->value,'selected'=>$_smarty_tpl->tpl_vars['user']->value['user_group']),$_smarty_tpl);?>

					<?php }?>
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-offset-3 col-md-9">
					<button class="btn btn-info" type="submit">提交</button>
				</div>
			</div>
			<div style="clear:both;"></div>
		</form>
	</div>
</div>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
