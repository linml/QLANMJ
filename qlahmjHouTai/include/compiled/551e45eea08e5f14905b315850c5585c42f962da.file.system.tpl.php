<?php /* Smarty version Smarty-3.1.15, created on 2018-06-09 15:40:36
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\acepanel\system.tpl" */ ?>
<?php /*%%SmartyHeaderCode:276345b1b7664c357e9-87332792%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '551e45eea08e5f14905b315850c5585c42f962da' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\acepanel\\system.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '276345b1b7664c357e9-87332792',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'sys_info' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1b7664ca6c89_84638461',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1b7664ca6c89_84638461')) {function content_5b1b7664ca6c89_84638461($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- TPLSTART 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<div class="row">
	<div class="col-xs-12">  	
		<div class="table-header">系统信息</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<tbody>
				<tr>
					<tr><td>服务器时间</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['gmt_time'];?>
 (格林威治标准时间)</td></tr>
					<tr><td>服务器时间</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['bj_time'];?>
 (北京时间)</td></tr>
					<tr><td>服务器ip地址</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['server_ip'];?>
</td></tr>
					<tr><td>服务器解译引擎</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['software'];?>
</td></tr>
					<tr><td>web服务端口</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['port'];?>
</td></tr>
					<tr><td>Mysql 版本</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['mysql_version'];?>
</td></tr>
					<tr><td>服务器管理员</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['admin'];?>
</td></tr>
					<tr><td>服务端剩余空间</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['diskfree'];?>
</td></tr>
					<tr><td>系统当前用户名</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['current_user'];?>
</td></tr>
					<tr><td>系统时区</td><td><?php echo $_smarty_tpl->tpl_vars['sys_info']->value['timezone'];?>
</td></tr>
				</tr>
			</tbody>
		</table>
	</div>
</div>

<!-- TPLEND 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>