<?php /* Smarty version Smarty-3.1.15, created on 2018-07-28 14:56:20
         compiled from "F:\project\qlahmjHouTai\include\template\acepanel\module_modify.tpl" */ ?>
<?php /*%%SmartyHeaderCode:279195b5c0584e6af19-35963234%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '4890d1c7cd7ebad939fd87cc5f8ac06f84f137c2' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\acepanel\\module_modify.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '279195b5c0584e6af19-35963234',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'module' => 0,
    'module_online_optioins' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b5c0584ec4ca8_26816544',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b5c0584ec4ca8_26816544')) {function content_5b5c0584ec4ca8_26816544($_smarty_tpl) {?><?php if (!is_callable('smarty_function_html_options')) include 'F:\\project\\qlahmjHouTai\\include\\config/../../include/lib/Smarty/plugins\\function.html_options.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">模块名称</label>
				<div class="col-sm-9">
					<input type="text" name="module_name" value="<?php echo $_smarty_tpl->tpl_vars['module']->value['module_name'];?>
" class="input-xlarge" required="true" autofocus="true">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">模块链接</label>
				<div class="col-sm-9">
					<input type="text" name="module_url" value="<?php echo $_smarty_tpl->tpl_vars['module']->value['module_url'];?>
" class="input-xlarge" required="true">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">模块图标</label>
				<div class="col-sm-9">
					<i id="icon_preview" class="menu-icon fa <?php echo $_smarty_tpl->tpl_vars['module']->value['module_icon'];?>
"></i>
					<input type="text" readonly value="<?php echo $_smarty_tpl->tpl_vars['module']->value['module_icon'];?>
" name="module_icon" id="icon_id" style="width:180px" >
					<a id="icon_select" class="btn btn-xs btn-info" href="#modal-table" data-toggle="modal">更改图标</a>
					<!--- 选择图标层--->			
					<?php echo $_smarty_tpl->getSubTemplate ("acepanel/icon_select.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

					<!--- 选择图标层 结束--->
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">模块排序数字(数字越小越靠前)</label>
				<div class="col-sm-9">
					<input type="text" name="module_sort" value="<?php echo $_smarty_tpl->tpl_vars['module']->value['module_sort'];?>
" class="input-xlarge" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">是否有效</label>
				<div class="col-sm-9">
					<?php if ($_smarty_tpl->tpl_vars['module']->value['module_id']==1) {?>
					<?php echo smarty_function_html_options(array('name'=>'online','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['module_online_optioins']->value,'disabled'=>"true",'selected'=>$_smarty_tpl->tpl_vars['module']->value['online']),$_smarty_tpl);?>

					<?php } else { ?>
					<?php echo smarty_function_html_options(array('name'=>'online','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['module_online_optioins']->value,'selected'=>$_smarty_tpl->tpl_vars['module']->value['online']),$_smarty_tpl);?>

					<?php }?>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">描述</label>
				<div class="col-sm-9">
					<textarea name="module_desc" rows="3" class="input-xlarge"><?php echo $_smarty_tpl->tpl_vars['module']->value['module_desc'];?>
</textarea>
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
<script>
$('.icon').click(function(){
	var obj = $(this);
	$('#icon_preview').removeClass().addClass('menu-icon fa ' + $.trim(obj.text()));
	$('#icon_id').val($.trim(obj.text()));
	$('#modal-table').modal('toggle');
});
</script>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
