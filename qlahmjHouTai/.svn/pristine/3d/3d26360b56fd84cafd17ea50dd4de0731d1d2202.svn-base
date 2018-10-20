<?php /* Smarty version Smarty-3.1.15, created on 2018-07-27 11:31:38
         compiled from "F:\project\qlahmjHouTai\include\template\agent\jushuRecord.tpl" */ ?>
<?php /*%%SmartyHeaderCode:166165b5a840a480854-65023520%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '9016808308cc993b01e7a2335943e6247162deae' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agent\\jushuRecord.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '166165b5a840a480854-65023520',
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
  'unifunc' => 'content_5b5a840a4c6d64_10745452',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b5a840a4c6d64_10745452')) {function content_5b5a840a4c6d64_10745452($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>



		
	<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			
<!-- 			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">发钻用户UID</label>
				<div class="col-sm-9">
					<input type="text" id="fromuid" name="fromuid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['fromuid'];?>
" placeholder="输入玩家UID" > 
				</div>
			</div> -->
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">组局方式</label>
				<div class="col-sm-9">
					<select name="roomType" id="roomType">
						<option value="">全部</option>
						<option value="0">组局</option>
						<option value="1">俱乐部</option>
					</select>
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
			<div class="table-header">局数报表</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>日期</th>
						<th>房间总数<br>总耗钻</th>
						<th>霍邱麻将<br>耗钻</th>
						<th>六安麻将<br>耗钻</th>
						<th>红中麻将<br>耗钻</th>
						<th>快乐比鸡<br>耗钻</th>
					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['record'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['record']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['records']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['record']->key => $_smarty_tpl->tpl_vars['record']->value) {
$_smarty_tpl->tpl_vars['record']->_loop = true;
?>
					<tr>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['time'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['countAll'];?>
<br><?php echo $_smarty_tpl->tpl_vars['record']->value['costAll'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['hqmjCount'];?>
<br><?php echo $_smarty_tpl->tpl_vars['record']->value['hqmjCost'];?>
</td>
                       	<td><?php echo $_smarty_tpl->tpl_vars['record']->value['lamjCount'];?>
<br><?php echo $_smarty_tpl->tpl_vars['record']->value['lamjCost'];?>
</td>
                       	<td><?php echo $_smarty_tpl->tpl_vars['record']->value['lahzCount'];?>
<br><?php echo $_smarty_tpl->tpl_vars['record']->value['lahzCost'];?>
</td>
                       	<td><?php echo $_smarty_tpl->tpl_vars['record']->value['bjCount'];?>
<br><?php echo $_smarty_tpl->tpl_vars['record']->value['bjCost'];?>
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
		$("#roomType option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['roomType'];?>
']").attr('selected',true);
	});
	</script><?php }} ?>
