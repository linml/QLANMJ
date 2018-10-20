<?php /* Smarty version Smarty-3.1.15, created on 2018-07-15 16:51:21
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\transferRecord.tpl" */ ?>
<?php /*%%SmartyHeaderCode:259995b21d4457d0648-17456440%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '19376eadd33c910ed94db534c109c091f55bd40e' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\transferRecord.tpl',
      1 => 1531641023,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '259995b21d4457d0648-17456440',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b21d445845966_30260354',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'agents' => 0,
    'agent' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b21d445845966_30260354')) {function content_5b21d445845966_30260354($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>

<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">玩家UID或者名称</label>
				<div class="col-sm-9">
					<input type="text" name="agentid" id="user_name" placeholder="输入玩家UID或者名称" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agentid'];?>
"> 
					<select name="agent_type" id="topType">
						<option value="">级别</option>
						<option value="1">钻石代理</option>
						<option value="2">铂金代理</option>
						<option value="3">金牌代理</option>
					</select>
					<select name="topAgent" id="topAgent">
						<option value="">默认</option>
						<option value="1">官方</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">开始日期</label>
				<div class="col-sm-9">
					<input type="text"  id="startdate"   name="startDate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['startDate'];?>
" placeholder="输入开始日期"   > 
					<select name="m_type" id="m_type">
						<option value="">默认</option>
						<option value="1">玩家充钻</option>
						<option value="-1">系统赠送</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">结束日期</label>
				<div class="col-sm-9">
					<input type="text"  id="enddate" name="endDate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['endDate'];?>
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
	<div class="col-xs-12">
		<div class="table-header">划拨记录</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>代理ID</th>
					<th>微信昵称</th>	
					<th>级别</th>
					<th>获得钻石</th>
					<th>金额</th>
					<th>上级代理ID</th>
					<th>微信昵称</th>
					<th>类型</th>
					<th>充值者</th>
					<th>时间</th>	
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['agent'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['agent']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['agents']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['agent']->key => $_smarty_tpl->tpl_vars['agent']->value) {
$_smarty_tpl->tpl_vars['agent']->_loop = true;
?>
				<tr>
					
					<td>
						<a href="transferRecord.php?agentid=<?php echo $_smarty_tpl->tpl_vars['agent']->value['agentid'];?>
" title='<?php echo $_smarty_tpl->tpl_vars['agent']->value['traded_info'];?>
'><?php echo $_smarty_tpl->tpl_vars['agent']->value['agentid'];?>
</a>	
					</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['nickname'];?>
</td>
					<td>
						<?php if ($_smarty_tpl->tpl_vars['agent']->value['istop']==1) {?>
							钻石
						<?php } elseif ($_smarty_tpl->tpl_vars['agent']->value['istop']==2) {?>
							铂金
						<?php } elseif ($_smarty_tpl->tpl_vars['agent']->value['istop']==3) {?>
							金牌
						<?php }?>
					</td>
					<td ><?php echo $_smarty_tpl->tpl_vars['agent']->value['traded_num'];?>
</td>
					<td ><?php echo $_smarty_tpl->tpl_vars['agent']->value['traded_money'];?>
</td>
					<?php if ($_smarty_tpl->tpl_vars['agent']->value['agentTopid']=='官方') {?>
						<td class="green"><?php echo $_smarty_tpl->tpl_vars['agent']->value['agentTopid'];?>
</td>
					<?php } else { ?>
						<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['agentTopid'];?>
</td>
					<?php }?>

					<?php if ($_smarty_tpl->tpl_vars['agent']->value['rechargePerson']=='官方') {?>
						<td class="green"><?php echo $_smarty_tpl->tpl_vars['agent']->value['rechargePerson'];?>
</td>
					<?php } else { ?>
						<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['rechargePerson'];?>
</td>
					<?php }?>

					<td>
						<?php if ($_smarty_tpl->tpl_vars['agent']->value['type']==1) {?>
							代理充钻
						<?php } elseif ($_smarty_tpl->tpl_vars['agent']->value['type']==-1) {?>
							系统赠送
						<?php }?>
					</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['adminName'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['addtime'];?>
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


<script>
	
	$(function(){
		//设置传入的select 的值设置默认选项
		$("#topType option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agent_type'];?>
']").attr('selected',true);
		$("#topAgent option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['topAgent'];?>
']").attr('selected',true);
		$("#m_type option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['m_type'];?>
']").attr('selected',true);
	});
</script>

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
</script>
<?php }} ?>
