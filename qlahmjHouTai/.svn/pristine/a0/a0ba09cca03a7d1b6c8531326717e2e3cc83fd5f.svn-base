<?php /* Smarty version Smarty-3.1.15, created on 2018-07-15 16:30:19
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\rechargeRecord.tpl" */ ?>
<?php /*%%SmartyHeaderCode:244675b1b7182578cd3-94497469%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '6f2c0b7f16063e9e7d63548814db22710ad1290c' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\rechargeRecord.tpl',
      1 => 1531639817,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '244675b1b7182578cd3-94497469',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1b71826056f1_93451648',
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
<?php if ($_valid && !is_callable('content_5b1b71826056f1_93451648')) {function content_5b1b71826056f1_93451648($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

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
					<input type="text" id="touid" name="touid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['touid'];?>
" placeholder="输入玩家UID" > 
					<select name="topAgent" id="topAgent">
						<option value="">默认</option>
						<option value="1">官方</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">代理ID</label>
				<div class="col-sm-9">
					<input type="text" id="fromuid"  name="fromuid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['fromuid'];?>
" placeholder="输入代理UID" > 
					<select name="m_type" id="m_type">
						<option value="">默认</option>
						<option value="1">玩家充钻</option>
						<option value="-1">系统赠送</option>
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
			<div class="table-header">开房记录</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>时间</th>
						<th>代理ID</th>
						<th>代理微信昵称</th>
						<th>玩家ID</th>
						<th>微信昵称</th>
						<th>充钻数量</th>
						<th>金额</th>
						<th>充值者</th>
						<th>类型</th>
						<th>状态</th>
					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['record'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['record']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['records']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['record']->key => $_smarty_tpl->tpl_vars['record']->value) {
$_smarty_tpl->tpl_vars['record']->_loop = true;
?>
					<tr>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['created'];?>
</td>
                    	<?php if ($_smarty_tpl->tpl_vars['record']->value['agentid']=='官方') {?>
							<td class="green"><?php echo $_smarty_tpl->tpl_vars['record']->value['agentid'];?>
</td>
						<?php } else { ?>
							<td><a href="rechargeRecord.php?fromuid=<?php echo $_smarty_tpl->tpl_vars['record']->value['agentid'];?>
"><?php echo $_smarty_tpl->tpl_vars['record']->value['agentid'];?>
</a></td>
						<?php }?>

						<?php if ($_smarty_tpl->tpl_vars['record']->value['agentName']=='官方') {?>
							<td class="green"><?php echo $_smarty_tpl->tpl_vars['record']->value['agentName'];?>
</td>
						<?php } else { ?>
							<td><?php echo $_smarty_tpl->tpl_vars['record']->value['agentName'];?>
</td>
						<?php }?>
                        <td>
                 			<a href="rechargeRecord.php?touid=<?php echo $_smarty_tpl->tpl_vars['record']->value['gameid'];?>
"><?php echo $_smarty_tpl->tpl_vars['record']->value['gameid'];?>
</a>
                       	</td>
						<td><?php echo $_smarty_tpl->tpl_vars['record']->value['gameName'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['amount'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['total'];?>
</td>
                        <td><?php echo $_smarty_tpl->tpl_vars['record']->value['wxnick'];?>
</td>
                        <td>
                        	<?php if ($_smarty_tpl->tpl_vars['record']->value['openid']==1) {?>
                        		玩家充钻
                        	<?php } elseif ($_smarty_tpl->tpl_vars['record']->value['openid']==-1) {?>
                        		系统赠送
                        	<?php }?>

                        </td>


                        <td>
                        	<?php if ($_smarty_tpl->tpl_vars['record']->value['status']==2) {?>
                        		成功
                        	<?php } elseif ($_smarty_tpl->tpl_vars['record']->value['status']==1) {?>
                        		失败
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
		$("#topAgent option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['topAgent'];?>
']").attr('selected',true);
		$("#m_type option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['m_type'];?>
']").attr('selected',true);
	});
	</script><?php }} ?>
