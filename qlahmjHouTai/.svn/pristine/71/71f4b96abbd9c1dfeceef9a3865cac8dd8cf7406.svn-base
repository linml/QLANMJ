<?php /* Smarty version Smarty-3.1.15, created on 2018-06-12 15:12:19
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\acepanel\users.tpl" */ ?>
<?php /*%%SmartyHeaderCode:158115b1f64438adbc8-54111935%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '883e0160ea9049eeea7dab9fa4c43e276e22683c' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\users.tpl',
      1 => 1524995961,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '158115b1f64438adbc8-54111935',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_GET' => 0,
    'group_options' => 0,
    'user_infos' => 0,
    'user_info' => 0,
    'page_no' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1f644392ea69_93995298',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1f644392ea69_93995298')) {function content_5b1f644392ea69_93995298($_smarty_tpl) {?><?php if (!is_callable('smarty_function_html_options')) include 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\config/../../include/lib/Smarty/plugins\\function.html_options.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<a href="user_add.php" class="btn btn-primary"><i class="icon-plus"></i> 账号</a>
		<a data-toggle="collapse" data-target="#search"  href="#" title= "检索"><button class="btn btn-primary" style="margin-left:5px"><i class="icon-search"></i></button></a>
	</div>
	<div class="col-xs-12">
		<?php if ($_smarty_tpl->tpl_vars['_GET']->value['search']) {?>
		<div id="search" class="collapse in">
		<?php } else { ?>
		<div id="search" class="collapse out" >
		<?php }?>
		<form action="" method="GET" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">选择账号组</label>
				<div class="col-sm-9">
					<?php echo smarty_function_html_options(array('name'=>'user_group','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['group_options']->value,'selected'=>$_smarty_tpl->tpl_vars['_GET']->value['user_group']),$_smarty_tpl);?>

				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">查询所有用户请留空</label>
				<div class="col-sm-9">
					<input type="text" name="user_name" value="<?php echo $_smarty_tpl->tpl_vars['_GET']->value['user_name'];?>
" placeholder="输入登录名" > 
					<input type="hidden" name="search" value="1" > 
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-offset-3 col-md-9">
					<button class="btn btn-info" type="submit">检索</button>
				</div>
			</div>
			<div style="clear:both;"></div>
		</form>
		</div>
	</div>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="table-header">账号列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>#</th>
					<th>登录名</th>
					<th>姓名</th>
					<th>手机</th>
					<th class="hidden-480">邮箱</th>
					<th>登录时间</th>
					<th>登录IP</th>
					<th>Group#</th>
					<th class="hidden-480">描述</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['user_info'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['user_info']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['user_infos']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['user_info']->key => $_smarty_tpl->tpl_vars['user_info']->value) {
$_smarty_tpl->tpl_vars['user_info']->_loop = true;
?>
				<tr>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_id'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_name'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['real_name'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['mobile'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['email'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['login_time'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['login_ip'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['user_info']->value['group_name'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_desc'];?>
</td>
					<td>
						<a href="user_modify.php?user_id=<?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_id'];?>
" title= "修改" ><i class="icon-pencil"></i></a>
						&nbsp;
						<?php if ($_smarty_tpl->tpl_vars['user_info']->value['user_id']!=1) {?>
						<?php if ($_smarty_tpl->tpl_vars['user_info']->value['status']==1) {?>
						<a data-toggle="modal" href="#myModal"  title= "封停账号" ><i class="icon-pause" href="users.php?page_no=<?php echo $_smarty_tpl->tpl_vars['page_no']->value;?>
&method=pause&user_id=<?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_id'];?>
"></i></a>
						<?php }?>
						<?php if ($_smarty_tpl->tpl_vars['user_info']->value['status']==0) {?>
						<a data-toggle="modal" href="#myModal" title= "解封账号" ><i class="icon-play" href="users.php?page_no=<?php echo $_smarty_tpl->tpl_vars['page_no']->value;?>
&method=play&user_id=<?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_id'];?>
"></i></a>
						<?php }?>
						&nbsp;
						<a data-toggle="modal" href="#myModal" title= "删除" ><i class="icon-remove" href="users.php?page_no=<?php echo $_smarty_tpl->tpl_vars['page_no']->value;?>
&method=del&user_id=<?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_id'];?>
" ></i></a>
						<?php }?>
					</td>
				</tr>
				<?php } ?>
			</tbody>
		</table>
		<!--- START 分页模板 --->
        <?php echo $_smarty_tpl->tpl_vars['page_html']->value;?>

		<!--- END --->
	</div>
</div>

<!---操作的确认层，相当于javascript:confirm函数--->
<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>


<!--- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 --->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
