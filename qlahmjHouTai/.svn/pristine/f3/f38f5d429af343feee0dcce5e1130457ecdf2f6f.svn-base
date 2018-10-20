<?php /* Smarty version Smarty-3.1.15, created on 2018-06-09 15:39:59
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\acepanel\menu_add.tpl" */ ?>
<?php /*%%SmartyHeaderCode:276345b1b763fa9adc2-39034262%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'c28d80cbaa70c976ca5ca1740b7ecd07f09a79a7' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\menu_add.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '276345b1b763fa9adc2-39034262',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_POST' => 0,
    'module_options_list' => 0,
    'father_menu_options_list' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1b763fb2f4e7_93309311',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1b763fb2f4e7_93309311')) {function content_5b1b763fb2f4e7_93309311($_smarty_tpl) {?><?php if (!is_callable('smarty_function_html_options')) include 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\config/../../include/lib/Smarty/plugins\\function.html_options.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">名称</label>
				<div class="col-sm-9">
					<input type="text" name="menu_name" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['menu_name'];?>
" class="input-xlarge" required="true" autofocus="true">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">链接 <span class="label label-important">不可重复，以/开头的相对路径或者http网址</span></label>
				<div class="col-sm-9">
					<input type="text" name="menu_url" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['menu_url'];?>
" class="input-xlarge" placeholder="/panel/"  required="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">所属模块</label>
				<div class="col-sm-9">
					<?php echo smarty_function_html_options(array('name'=>'module_id','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['module_options_list']->value,'selected'=>0),$_smarty_tpl);?>

				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">是否左侧菜单栏显示</label>
				<div class="col-sm-9">
					<select name="is_show" class="input-xlarge" >
						<option value="1" selected >是</option>
						<option value="0">否</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">所属菜单</label>
				<div class="col-sm-9">
					<?php echo smarty_function_html_options(array('name'=>'father_menu','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['father_menu_options_list']->value,'selected'=>0),$_smarty_tpl);?>

				</div>
			</div>
			<input type="hidden" name="shortcut_allowed" value="1">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">描述</label>
				<div class="col-sm-9">
					<textarea name="menu_desc" rows="3" class="input-xlarge"><?php echo $_smarty_tpl->tpl_vars['_POST']->value['module_desc'];?>
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

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
