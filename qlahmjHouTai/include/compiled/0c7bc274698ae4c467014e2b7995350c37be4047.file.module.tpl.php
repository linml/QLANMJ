<?php /* Smarty version Smarty-3.1.15, created on 2018-07-28 15:20:03
         compiled from "F:\project\qlahmjHouTai\include\template\acepanel\module.tpl" */ ?>
<?php /*%%SmartyHeaderCode:104515b5c08e49bd4a0-41337433%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '0c7bc274698ae4c467014e2b7995350c37be4047' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\acepanel\\module.tpl',
      1 => 1532758725,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '104515b5c08e49bd4a0-41337433',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b5c08e4a17231_26575128',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'menus' => 0,
    'menu' => 0,
    'module_id' => 0,
    'module_options_list' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b5c08e4a17231_26575128')) {function content_5b5c08e4a17231_26575128($_smarty_tpl) {?><?php if (!is_callable('smarty_function_html_options')) include 'F:\\project\\qlahmjHouTai\\include\\config/../../include/lib/Smarty/plugins\\function.html_options.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
<form id="tab" method="post" action="" class="form-horizontal" role="form">
	<div class="col-xs-12">
		<div class="table-header">菜单模块链接列表</div>
		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th><input type="checkbox" id="checkAll" >全选</th>
					<th>#</th>
					<th>名称</th>
					<th>URL</th>
					<th>#Module</th>
					<th>菜单</th>
					<th>类型</th>
					<th>是否在线</th>
					<th class="hidden-480">描述</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['menu'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['menu']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['menus']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['menu']->key => $_smarty_tpl->tpl_vars['menu']->value) {
$_smarty_tpl->tpl_vars['menu']->_loop = true;
?>
				<tr>
					<td>
					<?php if ($_smarty_tpl->tpl_vars['menu']->value['menu_id']<=100) {?>
					<input type="checkbox" name="menu_ids[]" value="<?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_id'];?>
" disabled>
					<?php } else { ?>
					<input type="checkbox" name="menu_ids[]" value="<?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_id'];?>
" >
					<?php }?>
					</td>
					<td><?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_id'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_name'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_url'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['menu']->value['module_id'];?>
</td>
					<td>
					<?php if ($_smarty_tpl->tpl_vars['menu']->value['is_show']) {?>
						是
					<?php } else { ?>
						否
					<?php }?>
					</td>
					<td>
					<?php if ($_smarty_tpl->tpl_vars['menu']->value['online']) {?>
						在线
					<?php } else { ?>
						已下线
					<?php }?>
					</td>
					<td>
					<?php if ($_smarty_tpl->tpl_vars['menu']->value['menu_type']==1) {?>
						管理后台
					<?php } elseif ($_smarty_tpl->tpl_vars['menu']->value['menu_type']==2) {?>
						代理后台
					<?php }?>
					</td>

					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_desc'];?>
</td>
				</tr>
				<?php } ?>
			</tbody>
		</table>
	</div>
	<?php if ($_smarty_tpl->tpl_vars['module_id']->value>1) {?>
	<div class="col-xs-12">
		<div class="form-group">
			<label class="col-sm-3 control-label no-padding-right">选择菜单模块</label>
			<div class="col-sm-9">
				<?php echo smarty_function_html_options(array('name'=>'module','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['module_options_list']->value,'selected'=>0),$_smarty_tpl);?>

			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-3 col-md-9">
				<button class="btn btn-info" type="submit">修改菜单模块</button>
			</div>
		</div>
	</div>
	<?php }?>
</form>
</div>

<script type="text/javascript">
$("#checkAll").click(function(){
     if($(this).attr("checked")){
		$("input[name='menu_ids[]']").attr("checked",$(this).attr("checked"));
	 }else{
		$("input[name='menu_ids[]']").attr("checked",false);
	 }
});
</script>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
