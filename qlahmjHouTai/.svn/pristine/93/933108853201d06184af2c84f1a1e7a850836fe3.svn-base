<?php /* Smarty version Smarty-3.1.15, created on 2018-04-13 21:19:27
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\acepanel\groups.tpl" */ ?>
<?php /*%%SmartyHeaderCode:178795ad0a04fc87ea2-23824718%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '624eb3e274160ef6afbddfa16f5fc43a66b64c10' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\groups.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '178795ad0a04fc87ea2-23824718',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'groups' => 0,
    'group' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ad0a04fcbab33_25353461',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ad0a04fcbab33_25353461')) {function content_5ad0a04fcbab33_25353461($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- TPLSTART 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<a href="group_add.php" class="btn btn-primary"><i class="icon-plus"></i> 账号组</a>
	</div>
	<div class="col-xs-12">
	</div>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="table-header">账号组列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>#</th>
					<th>账号组名</th>
					<th>描述</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['group'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['group']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['groups']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['group']->key => $_smarty_tpl->tpl_vars['group']->value) {
$_smarty_tpl->tpl_vars['group']->_loop = true;
?>
				<tr>
					<td><?php echo $_smarty_tpl->tpl_vars['group']->value['group_id'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['group']->value['group_name'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['group']->value['group_desc'];?>
</td>
					<td>
					<a href="group.php?group_id=<?php echo $_smarty_tpl->tpl_vars['group']->value['group_id'];?>
" title= "成员列表" ><i class="icon-list-alt"></i></a>
					&nbsp;
					<a href="group_modify.php?group_id=<?php echo $_smarty_tpl->tpl_vars['group']->value['group_id'];?>
" title= "修改" ><i class="icon-pencil"></i></a>
					&nbsp;
					<?php if ($_smarty_tpl->tpl_vars['group']->value['group_id']!=1&&$_smarty_tpl->tpl_vars['group']->value['group_id']!=3) {?>
					<a data-toggle="modal" href="#myModal"  title= "删除" ><i class="icon-remove" href="groups.php?method=del&group_id=<?php echo $_smarty_tpl->tpl_vars['group']->value['group_id'];?>
#myModal" data-toggle="modal" ></i></a>
					<?php }?>
					</td>
				</tr>
				<?php } ?>
			</tbody>
		</table>
	</div>
</div>

<!---操作的确认层，相当于javascript:confirm函数--->
<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>

	
<!-- TPLEND 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
