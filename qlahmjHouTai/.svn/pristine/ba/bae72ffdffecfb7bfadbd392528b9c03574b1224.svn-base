<?php /* Smarty version Smarty-3.1.15, created on 2018-04-24 21:26:46
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\acepanel\profile.tpl" */ ?>
<?php /*%%SmartyHeaderCode:276825adf228667ed60-11445054%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '3bbf8550c681704240cf7534dd4d5cfbd03e2080' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\profile.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '276825adf228667ed60-11445054',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'change_password' => 0,
    'user_info' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5adf22866adb70_81578564',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5adf22866adb70_81578564')) {function content_5adf22866adb70_81578564($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<div class="tabbable">
			<ul class="nav nav-tabs" id="myTab">
				<?php if ($_smarty_tpl->tpl_vars['change_password']->value) {?>
				<li class="">
					<a data-toggle="tab" href="#home">资料</a>
				</li>
				<li class="active" >
					<a data-toggle="tab" href="#profile">密码</a>
				</li>
				<?php } else { ?>
				<li class="active">
					<a data-toggle="tab" href="#home">资料</a>
				</li>
				<li >
					<a data-toggle="tab" href="#profile">密码</a>
				</li>
				<?php }?>
			</ul>
			<div class="tab-content">
				<?php if ($_smarty_tpl->tpl_vars['change_password']->value) {?>
				<div id="home" class="tab-pane fade">
				<?php } else { ?>
				<div id="home" class="tab-pane active in">
				<?php }?>
					<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">登录名</label>
							<div class="col-sm-9">
								<input type="text" name="user_name" value="<?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_name'];?>
" class="input-xlarge" readonly="true">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">姓名</label>
							<div class="col-sm-9">
								<input type="text" name="real_name" value="<?php echo $_smarty_tpl->tpl_vars['user_info']->value['real_name'];?>
" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">手机</label>
							<div class="col-sm-9">
								<input type="text" name="mobile" value="<?php echo $_smarty_tpl->tpl_vars['user_info']->value['mobile'];?>
" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">邮件</label>
							<div class="col-sm-9">
								<input type="text" name="email" value="<?php echo $_smarty_tpl->tpl_vars['user_info']->value['email'];?>
" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">描述</label>
							<div class="col-sm-9">
								<textarea name="user_desc" value="Smith" rows="3" class="input-xlarge"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_desc'];?>
</textarea>
							</div>
						</div>
						<div class="form-group">
							<div class="col-md-offset-3 col-md-9">
								<button class="btn btn-info" type="submit"><i class="icon-save"></i> 保存</button>
							</div>
						</div>
						<div style="clear:both;"></div>
					</form>
				</div>
				<?php if ($_smarty_tpl->tpl_vars['change_password']->value) {?>
				<div id="profile" class="tab-pane active in">
				<?php } else { ?>
				<div id="profile" class="tab-pane fade">
				<?php }?>
					<form id="tab2" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
						<input type="hidden" name="change_password" value="yes" >
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">原密码</label>
							<div class="col-sm-9">
								<input type="password" name="old" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">新密码</label>
							<div class="col-sm-9">
								<input type="password" name="new" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<div class="col-md-offset-3 col-md-9">
								<button class="btn btn-info" type="submit">更新</button>
							</div>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
</div>

<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
