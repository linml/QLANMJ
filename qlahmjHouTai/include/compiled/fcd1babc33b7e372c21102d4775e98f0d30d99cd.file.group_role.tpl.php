<?php /* Smarty version Smarty-3.1.15, created on 2018-04-13 21:19:26
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\acepanel\group_role.tpl" */ ?>
<?php /*%%SmartyHeaderCode:44385ad0a04ee9af92-91325528%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'fcd1babc33b7e372c21102d4775e98f0d30d99cd' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\group_role.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '44385ad0a04ee9af92-91325528',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'group_option_list' => 0,
    'group_id' => 0,
    'role_list' => 0,
    'role' => 0,
    'group_role' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ad0a04eed1aa1_77102969',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ad0a04eed1aa1_77102969')) {function content_5ad0a04eed1aa1_77102969($_smarty_tpl) {?><?php if (!is_callable('smarty_function_html_options')) include 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\config/../../include/lib/Smarty/plugins\\function.html_options.php';
if (!is_callable('smarty_function_html_checkboxes')) include 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\config/../../include/lib/Smarty/plugins\\function.html_checkboxes.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<select name="group_id" onchange="javascript:location.replace('group_role.php?group_id='+this.options[this.selectedIndex].value)" style="margin:5px 0px 0px">
			<?php echo smarty_function_html_options(array('options'=>$_smarty_tpl->tpl_vars['group_option_list']->value,'selected'=>$_smarty_tpl->tpl_vars['group_id']->value),$_smarty_tpl);?>

		</select>
	</div>
</div>
<div class="row">
<div class="col-xs-12"></div>
</div>
<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
		<div id="accordion" class="accordion-style1 panel-group">
		<?php  $_smarty_tpl->tpl_vars['role'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['role']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['role_list']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['role']->key => $_smarty_tpl->tpl_vars['role']->value) {
$_smarty_tpl->tpl_vars['role']->_loop = true;
?>
			<?php if (count($_smarty_tpl->tpl_vars['role']->value['menu_info'])>0) {?>
			<div class="panel panel-default">
				<div class="panel-heading">
					<h4 class="panel-title">
						<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#page-stats_<?php echo $_smarty_tpl->tpl_vars['role']->value['module_id'];?>
">
							<i class="ace-icon fa fa-angle-down bigger-110" data-icon-hide="ace-icon fa fa-angle-down" data-icon-show="ace-icon fa fa-angle-right"></i>
							<?php echo $_smarty_tpl->tpl_vars['role']->value['module_name'];?>

						</a>
					</h4>
				</div>
				<div class="panel-collapse collapse in" id="page-stats_<?php echo $_smarty_tpl->tpl_vars['role']->value['module_id'];?>
">
					<div class="panel-body">
						<?php echo smarty_function_html_checkboxes(array('name'=>"menu_ids",'options'=>$_smarty_tpl->tpl_vars['role']->value['menu_info'],'checked'=>$_smarty_tpl->tpl_vars['group_role']->value,'separator'=>"&nbsp;&nbsp;",'labels'=>"1"),$_smarty_tpl);?>

					</div>
				</div>
			</div>
			<?php }?>
		<?php } ?>
		</div>
		<div>
			<button class="btn btn-info">更新</button>
		</div>
		</form>
	</div>
</div>

<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
