<?php /* Smarty version Smarty-3.1.15, created on 2018-04-24 17:42:07
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\agent\clubGameUser.tpl" */ ?>
<?php /*%%SmartyHeaderCode:250245ad9b14783b8d1-32522010%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '151aa6bd17efde38883eeebf5b3eab698ff20e08' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\clubGameUser.tpl',
      1 => 1524551728,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '250245ad9b14783b8d1-32522010',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ad9b14785acd1_45762402',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'clubGameUserArray' => 0,
    'clubUser' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ad9b14785acd1_45762402')) {function content_5ad9b14785acd1_45762402($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


	<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">玩家ID</label>
				<div class="col-sm-9">
					<input type="text" id="fromuid" name="gameId" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['gameId'];?>
" placeholder="输入玩家UID" >
					<input type="test" class="hidden" name="clubId" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['clubId'];?>
"> 
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
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">俱乐部管理</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>头像</th>
						<th>玩家ID</th>
						<th>玩家名称</th>
						<th>时间</th>
					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['clubUser'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['clubUser']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['clubGameUserArray']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['clubUser']->key => $_smarty_tpl->tpl_vars['clubUser']->value) {
$_smarty_tpl->tpl_vars['clubUser']->_loop = true;
?>
					<tr>
                        <td><img src="<?php echo $_smarty_tpl->tpl_vars['clubUser']->value['headUrl'];?>
" style='width: 40px;height: 40px;'></td>
                        <td><?php echo $_smarty_tpl->tpl_vars['clubUser']->value['uid'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['clubUser']->value['name'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['clubUser']->value['time'];?>
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

	<script type="text/javascript">
	$("#fromuid").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");

	$("#touid").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");

	
	</script><?php }} ?>
