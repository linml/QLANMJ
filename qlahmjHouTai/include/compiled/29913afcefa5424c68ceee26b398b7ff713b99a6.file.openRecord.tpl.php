<?php /* Smarty version Smarty-3.1.15, created on 2018-06-21 10:53:47
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\openRecord.tpl" */ ?>
<?php /*%%SmartyHeaderCode:262965b29f4f2068c98-78556458%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '29913afcefa5424c68ceee26b398b7ff713b99a6' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\openRecord.tpl',
      1 => 1529480361,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '262965b29f4f2068c98-78556458',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b29f4f212c1b1_91804839',
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
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b29f4f212c1b1_91804839')) {function content_5b29f4f212c1b1_91804839($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

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
					<input type="text" id="fromuid" name="fromuid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['fromuid'];?>
" placeholder="输入玩家UID" > 
					<select name="roomType" id='roomType'>
						<option value="">---麻将类型---</option>
						<option value="LAMJ">六安麻将</option>
						<option value="LABJ">六安比鸡</option>
						<option value="LAHZ">六安红中</option>
						<option value="LAHQ">六安比鸡</option>
						<option value="BJ">比鸡</option>
					</select>
				</div>
				
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">房间号</label>
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
" placeholder="输入结束日期"> 
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
			<div class="table-header">
				<span>开房记录</span>
				<span><a href="openRecord.php?method=download&fromuid=<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['fromuid'];?>
&touid=<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['touid'];?>
&startdate=<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['startdate'];?>
&enddate=<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['enddate'];?>
&room_type = <?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['roomType'];?>
" class="white">下载文档</a></span>
			</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>创建时间</th>
						<th>方式</th>
						<th>房间号</th>
						<th>游戏</th>
						<th>局数</th>
						<th>付费</th>
						<th>耗钻</th>
						<th>房主ID</th>
						<th>微信昵称</th>
						<th>分数</th>
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
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['type'];?>
</td>
                        <td><a href="openRecord.php?touid=<?php echo $_smarty_tpl->tpl_vars['record']->value['room'];?>
"><?php echo $_smarty_tpl->tpl_vars['record']->value['room'];?>
</a></td>
			<!--
				<td>
					<?php if ($_smarty_tpl->tpl_vars['record']->value['room_type']=='BJ') {?>
						快乐比鸡
					<?php } elseif ($_smarty_tpl->tpl_vars['record']->value['room_type']=='HFHZ') {?>
						合肥红中
					<?php } elseif ($_smarty_tpl->tpl_vars['record']->value['room_type']=='HFSR') {?>
						合肥三人
					<?php } elseif ($_smarty_tpl->tpl_vars['record']->value['room_type']=='HFMJ') {?>
						合肥麻将
					<?php } else { ?>
						<?php echo $_smarty_tpl->tpl_vars['record']->value['room_type'];?>

					<?php }?>
				</td>
			-->
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['room_type'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['jushu'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['payway'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['cost'];?>
</td>
                        <td><a href="openRecord.php?fromuid=<?php echo $_smarty_tpl->tpl_vars['record']->value['userid'];?>
"><?php echo $_smarty_tpl->tpl_vars['record']->value['userid'];?>
</a></td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['name'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['score'];?>
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
