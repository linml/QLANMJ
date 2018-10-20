<?php /* Smarty version Smarty-3.1.15, created on 2018-05-05 15:05:15
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\agent\transferRecord.tpl" */ ?>
<?php /*%%SmartyHeaderCode:131045ad0b734bbdae8-70365480%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '36d4a36da4cbbe5c70fdbb97cb9f4be99b8e6655' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\transferRecord.tpl',
      1 => 1525500310,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '131045ad0b734bbdae8-70365480',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ad0b734bf8464_35779022',
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
<?php if ($_valid && !is_callable('content_5ad0b734bf8464_35779022')) {function content_5ad0b734bf8464_35779022($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

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
"><?php echo $_smarty_tpl->tpl_vars['agent']->value['agentid'];?>
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
	});
</script>
<?php }} ?>
