<?php /* Smarty version Smarty-3.1.15, created on 2018-09-19 21:01:47
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\ace\index.tpl" */ ?>
<?php /*%%SmartyHeaderCode:267105ba23aab14f1b3-02479857%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '2e1648a94b13aea685161b1a25116d6e19613bf0' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\ace\\index.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '267105ba23aab14f1b3-02479857',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'tips' => 0,
    'user_info' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ba23aab199551_48545939',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ba23aab199551_48545939')) {function content_5ba23aab199551_48545939($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">  	
		<div class="alert alert-info">
			<button class="close" data-dismiss="alert">
				<i class="ace-icon fa fa-times"></i>
			</button>
			<i class="ace-icon fa fa-hand-o-right"></i>
			请保管好您的个人信息，一点发生密码泄露请紧急联系管理员。
		</div>
		<?php if ($_smarty_tpl->tpl_vars['tips']->value!='') {?>
			<div  class="alert alert-info">
				<?php echo $_smarty_tpl->tpl_vars['tips']->value;?>

			</div>
		<?php }?>
		<div class="table-header">当前用户信息</div>
		<div></div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>用户名</th>
					<th>真实姓名</th>
					<th class="hidden-480">手机号</th>
					<th>Email</th>
					<th class="hidden-480">登录时间</th>
					<th>登录IP</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_name'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['real_name'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['mobile'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['email'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['login_time'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['login_ip'];?>
</td>
				</tr>
			</tbody>
		</table>
	</div>
</div>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
