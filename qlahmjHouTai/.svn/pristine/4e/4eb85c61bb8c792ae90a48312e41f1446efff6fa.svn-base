<?php /* Smarty version Smarty-3.1.15, created on 2018-04-24 21:15:32
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\acepanel\group.tpl" */ ?>
<?php /*%%SmartyHeaderCode:262775adf1fe44de990-34036835%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '2b145ac8be4be53a6fa9e1ea8ca985c49fddb176' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\group.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '262775adf1fe44de990-34036835',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'user_infos' => 0,
    'user_info' => 0,
    'groupOptions' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5adf1fe4530a31_64531519',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5adf1fe4530a31_64531519')) {function content_5adf1fe4530a31_64531519($_smarty_tpl) {?><?php if (!is_callable('smarty_function_html_options')) include 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\config/../../include/lib/Smarty/plugins\\function.html_options.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<form id="tab" method="post" action="" class="form-horizontal" role="form">
	<div class="col-xs-12">
		<div class="table-header">账号组成员列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th><input type="checkbox" id="checkAll" >全选</th>
					<th>#</th>
					<th>登录名</th>
					<th>姓名</th>
					<th>手机</th>
					<th class="hidden-480">邮箱</th>
					<th class="hidden-480">登录时间</th>
					<th class="hidden-480">登录IP</th>
					<th class="hidden-480">Group#</th>
					<th class="hidden-480">描述</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['user_info'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['user_info']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['user_infos']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['user_info']->key => $_smarty_tpl->tpl_vars['user_info']->value) {
$_smarty_tpl->tpl_vars['user_info']->_loop = true;
?>
				<tr>
					<td><input type="checkbox" name="user_ids[]" value="<?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_id'];?>
" <?php if ($_smarty_tpl->tpl_vars['user_info']->value['user_id']==1) {?>disabled<?php }?>></td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_id'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_name'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['real_name'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['mobile'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['email'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['login_time'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['login_ip'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_group'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_desc'];?>
</td>
				</tr>
				<?php } ?>
			</tbody>
		</table>
	</div>
	<div class="col-xs-12">
		<div class="form-group">
			<label class="col-sm-3 control-label no-padding-right">选择账号组</label>
			<div class="col-sm-9">
				<?php echo smarty_function_html_options(array('name'=>'user_group','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['groupOptions']->value,'selected'=>0),$_smarty_tpl);?>

			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-3 col-md-9">
				<button class="btn btn-info" type="submit">修改账号组</button>
			</div>
		</div>
	</div>
	</form>
</div>
	
<!---操作的确认层，相当于javascript:confirm函数--->
<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>


<script type="text/javascript">
$("#checkAll").click(function(){
     if($(this).attr("checked")){
		$("input[name='user_ids[]']").attr("checked",$(this).attr("checked"));
	 }else{
		$("input[name='user_ids[]']").attr("checked",false);
	 }
});
</script>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
