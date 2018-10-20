<?php /* Smarty version Smarty-3.1.15, created on 2018-07-28 10:02:12
         compiled from "F:\project\qlahmjHouTai\include\template\agent\clubManage.tpl" */ ?>
<?php /*%%SmartyHeaderCode:56145b5bc0943438d3-62526472%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'd1768448c1bf1ee6ab3abeabb8e57705632127e1' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agent\\clubManage.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '56145b5bc0943438d3-62526472',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'clubdata' => 0,
    'club' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b5bc0943c08f5_96433503',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b5bc0943c08f5_96433503')) {function content_5b5bc0943c08f5_96433503($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>



		
	<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">会长ID</label>
				<div class="col-sm-9">
					<input type="text" id="fromuid" name="agent" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agent'];?>
" placeholder="输入玩家UID" > 
				</div>
				
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">房间号</label>
				<div class="col-sm-9">
					<input type="text" id="touid" name="clubId" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['clubId'];?>
" placeholder="请输入房间号" > 
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
						<th>俱乐部ID</th>
						<th>俱乐部名称</th>
						<th>会长ID</th>
						<th>会长</th>
						<th>俱乐部人数</th>
						<th>创建时间</th>
						<th>管理</th>
					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['club'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['club']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['clubdata']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['club']->key => $_smarty_tpl->tpl_vars['club']->value) {
$_smarty_tpl->tpl_vars['club']->_loop = true;
?>
					<tr>
                        <td>
                        	<a href="clubManage.php?clubId=<?php echo $_smarty_tpl->tpl_vars['club']->value['clubId'];?>
"><?php echo $_smarty_tpl->tpl_vars['club']->value['clubId'];?>
</a>	
                        </td>
                        <td><?php echo $_smarty_tpl->tpl_vars['club']->value['clubName'];?>
</td>
                        <td>
                        	<a href="clubManage.php?agent=<?php echo $_smarty_tpl->tpl_vars['club']->value['clubOwner'];?>
"><?php echo $_smarty_tpl->tpl_vars['club']->value['clubOwner'];?>
</a>	
                        </td>
                        <td><?php echo $_smarty_tpl->tpl_vars['club']->value['clubOwnerName'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['club']->value['clubCount'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['club']->value['time'];?>
</td>
                        <td>
                        	<a href="clubGameUser.php?clubId=<?php echo $_smarty_tpl->tpl_vars['club']->value['clubId'];?>
&agent=<?php echo $_smarty_tpl->tpl_vars['club']->value['clubOwner'];?>
&agentName=<?php echo $_smarty_tpl->tpl_vars['club']->value['clubOwnerName'];?>
" class="btn">详情</a>
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
	
	$(function() {
	var date=$( "#startdate" );
	date.datepicker({ dateFormat: "yy-mm-dd" });
	date.datepicker( "option", "firstDay", 1 );
	});
	$(function() {
		var date=$( "#enddate" );
		date.datepicker({ dateFormat: "yy-mm-dd" });
		date.datepicker( "option", "firstDay", 1 );
	});
	$(function(){
		//设置传入的select 的值设置默认选项
		$("#roomType option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['roomType'];?>
']").attr('selected',true);
	});
	</script><?php }} ?>
