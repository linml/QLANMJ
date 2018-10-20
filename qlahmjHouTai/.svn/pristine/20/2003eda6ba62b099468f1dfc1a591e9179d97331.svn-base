<?php /* Smarty version Smarty-3.1.15, created on 2018-06-11 20:39:33
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\roseAgentRecord.tpl" */ ?>
<?php /*%%SmartyHeaderCode:288645b1b766ec669b7-03628120%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '8e50c9dec855e99fa6db542ef7f78bfe3b59caf8' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\roseAgentRecord.tpl',
      1 => 1528717170,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '288645b1b766ec669b7-03628120',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1b766ecfb0d7_00290184',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'rose_list' => 0,
    'roseh' => 0,
    'agents' => 0,
    'agent' => 0,
    'rose' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1b766ecfb0d7_00290184')) {function content_5b1b766ecfb0d7_00290184($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>

<div class="row">
	<div class="col-xs-12">
		<div class="table-header">总代报表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>日期</th>
					<?php  $_smarty_tpl->tpl_vars['roseh'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['roseh']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['rose_list']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['roseh']->key => $_smarty_tpl->tpl_vars['roseh']->value) {
$_smarty_tpl->tpl_vars['roseh']->_loop = true;
?>
						<td>(<?php echo $_smarty_tpl->tpl_vars['roseh']->value['user_game_id'];?>
)<?php echo $_smarty_tpl->tpl_vars['roseh']->value['nickName'];?>
</td>
					<?php } ?>		
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['agent'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['agent']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['agents']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['agent']->key => $_smarty_tpl->tpl_vars['agent']->value) {
$_smarty_tpl->tpl_vars['agent']->_loop = true;
?>
				<tr>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['nowDate'];?>
</td>
					<?php  $_smarty_tpl->tpl_vars['rose'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['rose']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['rose_list']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['rose']->key => $_smarty_tpl->tpl_vars['rose']->value) {
$_smarty_tpl->tpl_vars['rose']->_loop = true;
?>
						<td><?php echo $_smarty_tpl->tpl_vars['agent']->value[$_smarty_tpl->tpl_vars['rose']->value['st_id']];?>
</td>
					<?php } ?>
				</tr>
				<?php } ?>
			</tbody>
		</table>
		<!-- START 分页模板 -->
        <?php echo $_smarty_tpl->tpl_vars['page_html']->value;?>

		<!-- END -->
	</div>
</div>

<!--操作的确认层，相当于javascript:confirm函数-->
<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>


<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>



<?php }} ?>
