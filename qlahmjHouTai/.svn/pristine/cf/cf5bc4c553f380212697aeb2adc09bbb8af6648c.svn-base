<?php /* Smarty version Smarty-3.1.15, created on 2018-06-09 11:38:27
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\myearnings.tpl" */ ?>
<?php /*%%SmartyHeaderCode:283545b1b3da36479a7-08402802%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '4e590a49b28dfcbd61a780ec47039af70ae2d378' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\myearnings.tpl',
      1 => 1526368332,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '283545b1b3da36479a7-08402802',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'earnings_infos' => 0,
    'earnings_info' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1b3da3726456_33637538',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1b3da3726456_33637538')) {function content_5b1b3da3726456_33637538($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
 <?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>

<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">代理商玩家UID</label>
				<div class="col-sm-9">
					<input type="text" name="agent" id="user_name" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agent'];?>
" placeholder="输入代理商玩家UID" > 
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">上级代理搜索</label>
				<div class="col-sm-9">
					<input type="text" name="topAgent" id="user_name" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['topAgent'];?>
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
					    <th>用户</th>
					    <th>充值</th>
					    <th>充值时间</th>
					    <th>直接玩家</th>
					    <th>直接返利</th>
					    <th>原返利玩家</th>
					    <th>原返利</th>
						<th>金牌代理</th>
						<th>返利</th>
						<th>铂金代理</th>
						<th >返利</th>
						<th>核心代理</th>
						<th>返利</th>
					</tr>
				</thead> 
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['earnings_info'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['earnings_info']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['earnings_infos']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['earnings_info']->key => $_smarty_tpl->tpl_vars['earnings_info']->value) {
$_smarty_tpl->tpl_vars['earnings_info']->_loop = true;
?>
					<tr>
						<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['game_uid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['nickname'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['traded_num'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['addtime'];?>
</td>
						<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['fx_4_userid']==0) {?>
							<td></td>
						<?php } else { ?>
							<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_4_userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx4Name'];?>
</td>
						<?php }?>

						<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['fx_4_num']==0) {?>
							<td></td>
						<?php } else { ?>
							<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_4_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_4_money'];?>
</td>
						<?php }?>

						<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['fx_5_userid']==0) {?>
							<td></td>
						<?php } else { ?>
							<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_5_userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx5Name'];?>
</td>
						<?php }?>

						<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['fx_5_userid']==0) {?>
							<td></td>
						<?php } else { ?>
							<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_5_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_5_money'];?>
</td>
						<?php }?>

						<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['fx1Top']==3) {?>
							<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx1Userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx1Name'];?>
</td>
							<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_1_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_1_money'];?>
</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['earnings_info']->value['fx1Top']==2) {?>
							<td></td>
							<td></td>
							<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx1Userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx1Name'];?>
</td>
							<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_1_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_1_money'];?>
</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['earnings_info']->value['fx1Top']==1) {?>
							<td></td>
							<td></td>
							<td></td>
							<td></td> 
							<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx1Userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx1Name'];?>
</td>
							<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_1_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_1_money'];?>
</td>
						<?php }?>
						<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['fx1Top']==3) {?>
							<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['fx2Top']==2) {?>
								<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx2Userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx2Name'];?>
</td>
								<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_2_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_2_money'];?>
</td>
							<?php } elseif ($_smarty_tpl->tpl_vars['earnings_info']->value['fx2Top']==1) {?>
								<td></td>
								<td></td>
								<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx2Userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx2Name'];?>
</td>
								<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_2_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_2_money'];?>
</td>
							<?php }?>

						<?php } elseif ($_smarty_tpl->tpl_vars['earnings_info']->value['fx2Top']) {?>
								<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx2Userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx2Name'];?>
</td>
								<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_2_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_2_money'];?>
</td>
						<?php }?>

						<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['fx3Top']==1) {?>
							<td>(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx3Userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx3Name'];?>
</td>
							<td>￥<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['fx_3_num'];?>
<br>余额:<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['rd_3_money'];?>
</td>
						<?php }?>

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

	</script><?php }} ?>
