<?php /* Smarty version Smarty-3.1.15, created on 2018-09-27 19:05:17
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\acepanel\modules.tpl" */ ?>
<?php /*%%SmartyHeaderCode:226485bacab5d7a2ff5-29553434%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'd232f9f748ebfac6c5d82f8fd8762a1c0046c908' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\acepanel\\modules.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '226485bacab5d7a2ff5-29553434',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'modules' => 0,
    'module' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5bacab5d89d034_23359431',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5bacab5d89d034_23359431')) {function content_5bacab5d89d034_23359431($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- TPLSTART 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<a href="module_add.php" class="btn btn-primary"><i class="icon-plus"></i> 模块</a>
	</div>
	<div class="col-xs-12">
	</div>
	<div class="col-xs-12">
		<div class="table-header">模块列表</div>
		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>#</th>
					<th>模块名</th>
					<th>模块链接</th>
					<th>排序</th>
					<th>是否在线</th>
					<th class="hidden-480">描述</th>
					<th class="hidden-480">图标</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['module'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['module']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['modules']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['module']->key => $_smarty_tpl->tpl_vars['module']->value) {
$_smarty_tpl->tpl_vars['module']->_loop = true;
?>
				<tr>
					<td><?php echo $_smarty_tpl->tpl_vars['module']->value['module_id'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['module']->value['module_name'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['module']->value['module_url'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['module']->value['module_sort'];?>
</td>
					<td>
						<?php if ($_smarty_tpl->tpl_vars['module']->value['online']) {?>
							在线
						<?php } else { ?>
							已下线
						<?php }?>
					</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['module']->value['module_desc'];?>
</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['module']->value['module_icon'];?>
</td>
					<td>
					<a href="module.php?module_id=<?php echo $_smarty_tpl->tpl_vars['module']->value['module_id'];?>
" title= "菜单链接列表" ><i class="icon-list-alt"></i></a>
					&nbsp;
					<a href="module_modify.php?module_id=<?php echo $_smarty_tpl->tpl_vars['module']->value['module_id'];?>
" title= "修改" ><i class="icon-pencil"></i></a>
					&nbsp;
					<?php if ($_smarty_tpl->tpl_vars['module']->value['module_id']!=1) {?>
					<a data-toggle="modal" href="#myModal"  title= "删除" ><i class="icon-remove" href="modules.php?method=del&module_id=<?php echo $_smarty_tpl->tpl_vars['module']->value['module_id'];?>
"></i></a>
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

	
<!-- TPLEND 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
