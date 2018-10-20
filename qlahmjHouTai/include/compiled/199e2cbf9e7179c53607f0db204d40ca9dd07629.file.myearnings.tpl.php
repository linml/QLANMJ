<?php /* Smarty version Smarty-3.1.15, created on 2018-09-08 10:34:45
         compiled from "F:\project\qlahmjHouTai\include\template\agent\myearnings.tpl" */ ?>
<?php /*%%SmartyHeaderCode:111345b932735b4fbe3-10078708%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '199e2cbf9e7179c53607f0db204d40ca9dd07629' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agent\\myearnings.tpl',
      1 => 1536109678,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '111345b932735b4fbe3-10078708',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'RebateList' => 0,
    'val' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b932735c13118_68755656',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b932735c13118_68755656')) {function content_5b932735c13118_68755656($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
 <?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>

<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="POST" class="form-horizontal" role="form">
			
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">代理商ID</label>
				<div class="col-sm-9">
					<input type="text" name="agentid" id="agentid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agentid'];?>
" placeholder="输入代理ID" > 
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">上级代理搜索</label>
				<div class="col-sm-9">
					<input type="text" name="dirAgent" id="dirAgent" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['dirAgent'];?>
" placeholder="输入上级代理ID或名称" > 
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
" placeholder="输入结束日期" > 
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
			<div class="table-header">返利明细</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
					    <th>代理ID/昵称</th>
					    <th>级别</th>
					    <th>佣金类型</th>
					    <th>收/支</th>
					    <th>返佣金额</th>
					    <th>余额</th>
					    <th>时间</th>
						<th>充值摘要</th>
					</tr>
				</thead> 
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['val'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['val']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['RebateList']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['val']->key => $_smarty_tpl->tpl_vars['val']->value) {
$_smarty_tpl->tpl_vars['val']->_loop = true;
?>
					<tr>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['agentid'];?>
/<?php echo $_smarty_tpl->tpl_vars['val']->value['agentname'];?>
</td>
						<?php if ($_smarty_tpl->tpl_vars['val']->value['levelid']==1) {?>
						<td>核心</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['levelid']==2) {?>
						<td>铂金</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['levelid']==3) {?>
						<td>金牌</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['levelid']==4) {?>
						<td>普通</td>
						<?php } else { ?>
						<td></td>
						<?php }?>	

						<?php if ($_smarty_tpl->tpl_vars['val']->value['returnlevel']==1) {?>
						<td>玩家返佣</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['returnlevel']==2) {?>
						<td>一层返佣</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['returnlevel']==3) {?>
						<td>二层返佣</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['returnlevel']==4) {?>
						<td>三层返佣</td>
						<?php } else { ?>
						<td></td>
						<?php }?>
						<?php if ($_smarty_tpl->tpl_vars['val']->value['fundtype']==83||$_smarty_tpl->tpl_vars['val']->value['fundtype']==85) {?>
						<td>支</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['fundtype']==86) {?>
						<td>收</td>
						<?php } else { ?>
						<td></td>
						<?php }?>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['fundmoney'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['agomoney'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['addtime'];?>
</td>
						<td>充值订单(<?php echo $_smarty_tpl->tpl_vars['val']->value['relationid'];?>
)</td>
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

		$(document).ready(function(){
			// $('#startdate')
		})
	</script><?php }} ?>
