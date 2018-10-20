<?php /* Smarty version Smarty-3.1.15, created on 2018-07-23 13:06:46
         compiled from "F:\project\qlahmj.admin\include\template\agent\sellgemslist.tpl" */ ?>
<?php /*%%SmartyHeaderCode:154845b55545652af61-08286317%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'd0ce5ff518846b73bbf3b95c24375b8521a78688' => 
    array (
      0 => 'F:\\project\\qlahmj.admin\\include\\template\\agent\\sellgemslist.tpl',
      1 => 1524829852,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '154845b55545652af61-08286317',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'records' => 0,
    'record' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b5554565ea610_07663950',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b5554565ea610_07663950')) {function content_5b5554565ea610_07663950($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


	<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">玩家ID:</label>
				<div class="col-sm-9">
					<input type="text" id="fromuid" name="fromuid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['fromuid'];?>
" placeholder="请输入ID" >
					<select name="gameType" id="gameType">
						<option value="">--游戏类型--</option>
						<option value="BJ">比鸡</option>
						<option value="HQMJ">霍邱麻将</option>
						<option value="LABJ">六安比鸡</option>
						<option value="LAHZ">六安红中</option>
						<option value="LAMJ">六安麻将</option>
					</select> 
				</div>

				
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">房间号:</label>
				<div class="col-sm-9">
					<input type="text" id="touid" name="touid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['touid'];?>
" placeholder="请输入房间号" > 
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">开始日期</label>
				<div class="col-sm-9">
					<input type="text"  id="startdate"   name="startdate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['startdate'];?>
" placeholder="输入开始日期"   > 
					
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">结束日期</label>
				<div class="col-sm-9">
					<input type="text"  id="enddate" name="enddate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['enddate'];?>
" placeholder="输入结束日期"  > 
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
			<div class="table-header">转钻列表</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>用户ID</th>
						<th>微信昵称</th>
						<th>房间号</th>
						<th>付费方式</th>
						<th>游戏类型</th>
						<th>局数</th>
						<th>耗钻</th>
						<th>时间</th>
					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['record'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['record']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['records']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['record']->key => $_smarty_tpl->tpl_vars['record']->value) {
$_smarty_tpl->tpl_vars['record']->_loop = true;
?>
					<tr>
                        <td>
                        	<a href="sellgemslist.php?fromuid=<?php echo $_smarty_tpl->tpl_vars['record']->value['userid'];?>
"><?php echo $_smarty_tpl->tpl_vars['record']->value['userid'];?>
</a>	
                        </td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['name'];?>
</td>
                        <td><a href="sellgemslist.php?touid=<?php echo $_smarty_tpl->tpl_vars['record']->value['room'];?>
"><?php echo $_smarty_tpl->tpl_vars['record']->value['room'];?>
</a></td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['payway'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['type'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['jushu'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['cost'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['time'];?>
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
		$("#gameType option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['gameType'];?>
']").attr('selected',true);
	});
	</script><?php }} ?>
