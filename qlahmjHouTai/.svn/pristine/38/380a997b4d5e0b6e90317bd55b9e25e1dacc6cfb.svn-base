<?php /* Smarty version Smarty-3.1.15, created on 2018-04-27 20:44:42
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\agent\topupearnings.tpl" */ ?>
<?php /*%%SmartyHeaderCode:27855ad0a02d681134-36801398%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '418ad37eacf62f4f23384746930ee49eae6c282a' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\topupearnings.tpl',
      1 => 1524829459,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '27855ad0a02d681134-36801398',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ad0a02d6c7641_31798054',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'topuprerecord_infos' => 0,
    'topuprerecord_info' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ad0a02d6c7641_31798054')) {function content_5ad0a02d6c7641_31798054($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
 
<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>



		
	<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="POST" class="form-horizontal" role="form">
			
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">玩家UID</label>
				<div class="col-sm-9">
					<input type="text" id="id" name="agentid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agentid'];?>
" placeholder="输入玩家UID或名称" > 
					<select name="agent_type" id='agentType'>
						<option value="">--筛选状态--</option>
						<option value="1">未支付</option>
						<option value="2">未发货</option>
						<option value="3">已发货</option>
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
			<div class="table-header">充值订单</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
			
						<th>时间</th>
						<th>游戏ID</th>
						<th>微信昵称</th>
						<th>渠道</th>
						<th>充值金额</th>
						<th>充值状态</th>
						<th>邀请人ID</th>
						<th>微信昵称</th>
						<th>订单号</th>

					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['topuprerecord_info'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['topuprerecord_info']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['topuprerecord_infos']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['topuprerecord_info']->key => $_smarty_tpl->tpl_vars['topuprerecord_info']->value) {
$_smarty_tpl->tpl_vars['topuprerecord_info']->_loop = true;
?>
					<tr>
						<td><?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['created'];?>
</td>
                        <td>
                        	<a href="topupearnings.php?agentid=<?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['to_user'];?>
" ><?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['to_user'];?>
</a>
                        </td>
						<td><?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['gameName'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['channel'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['amount'];?>
</td>
						<td>
							
							<?php if ($_smarty_tpl->tpl_vars['topuprerecord_info']->value['status']==2) {?>
								<span class="green">成功</span>
							<?php } elseif ($_smarty_tpl->tpl_vars['topuprerecord_info']->value['status']==1) {?>
								<span class="">待支付</span>
							<?php } elseif ($_smarty_tpl->tpl_vars['topuprerecord_info']->value['status']==0) {?>
								<span class="red">失败</span>
							<?php }?>

						</td>
						<td><?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['agentid'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['agentName'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['topuprerecord_info']->value['order_no'];?>
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
			$("#agentType option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agent_type'];?>
']").attr('selected',true);
		});
	</script><?php }} ?>
