<?php /* Smarty version Smarty-3.1.15, created on 2018-06-04 15:12:10
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\acepanel\menus.tpl" */ ?>
<?php /*%%SmartyHeaderCode:306685b14d83a6435f6-69521739%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'd2e1888705f17774cb7e0d6f730ab09f9be20db8' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\menus.tpl',
      1 => 1523840401,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '306685b14d83a6435f6-69521739',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_GET' => 0,
    'module_options_list' => 0,
    'menus' => 0,
    'menu' => 0,
    'page_no' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b14d83a6dbb93_25063958',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b14d83a6dbb93_25063958')) {function content_5b14d83a6dbb93_25063958($_smarty_tpl) {?><?php if (!is_callable('smarty_function_html_options')) include 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\config/../../include/lib/Smarty/plugins\\function.html_options.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>

<div class="row">
	<div class="col-xs-12">
		<a href="menu_add.php"  class="btn btn-primary"><i class="icon-plus"></i> 功能</a>
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
				<label class="col-sm-3 control-label no-padding-right">选择菜单模块</label>
				<div class="col-sm-9">
					<?php echo smarty_function_html_options(array('name'=>'module_id','id'=>"DropDownTimezone",'class'=>"input-xlarge",'options'=>$_smarty_tpl->tpl_vars['module_options_list']->value,'selected'=>$_smarty_tpl->tpl_vars['_GET']->value['module_id']),$_smarty_tpl);?>

				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">查询所有请留空</label>
				<div class="col-sm-9">
					<input type="text" name="menu_name" value="<?php echo $_smarty_tpl->tpl_vars['_GET']->value['menu_name'];?>
" placeholder="输入菜单名称" > 
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
		<div class="table-header">功能列表</div>
		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>名称</th>
					<th>URL</th>
					<th>所属模块</th>
					<th>菜单</th>
					<th>所属菜单</th>
					<th>是否在线</th>
					<th class="hidden-480">描述</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['menu'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['menu']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['menus']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['menu']->key => $_smarty_tpl->tpl_vars['menu']->value) {
$_smarty_tpl->tpl_vars['menu']->_loop = true;
?>
				<tr>
					<td><?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_name'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_url'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['module_options_list']->value[$_smarty_tpl->tpl_vars['menu']->value['module_id']];?>
</td>
					<td>
					<?php if ($_smarty_tpl->tpl_vars['menu']->value['is_show']) {?>
						是
					<?php } else { ?>
						否
					<?php }?>
					</td>
					<td><?php if ($_smarty_tpl->tpl_vars['menu']->value['father_menu']>0) {?><?php echo $_smarty_tpl->tpl_vars['menu']->value['father_menu_name'];?>
<?php }?></td>
					<td>
					<?php if ($_smarty_tpl->tpl_vars['menu']->value['online']) {?>
						在线
					<?php } else { ?>
						已下线
					<?php }?>
					</td>
					<td class="hidden-480"><?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_desc'];?>
</td>
					<td>
						<a href="menu_modify.php?menu_id=<?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_id'];?>
" title= "修改" ><i class="icon-pencil"></i></a>
						<?php if ($_smarty_tpl->tpl_vars['menu']->value['menu_id']>100) {?>
						&nbsp;
						<a data-toggle="modal" href="#myModal" title= "删除" ><i class="icon-remove" href="menus.php?page_no=<?php echo $_smarty_tpl->tpl_vars['page_no']->value;?>
&method=del&menu_id=<?php echo $_smarty_tpl->tpl_vars['menu']->value['menu_id'];?>
" ></i></a>
						<?php }?>
					</td>
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
