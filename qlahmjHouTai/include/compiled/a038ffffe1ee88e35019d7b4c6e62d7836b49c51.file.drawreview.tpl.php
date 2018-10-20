<?php /* Smarty version Smarty-3.1.15, created on 2018-08-29 16:49:34
         compiled from "F:\project\qlahmjHouTai\include\template\agent\drawreview.tpl" */ ?>
<?php /*%%SmartyHeaderCode:140235b55b2babb3544-94528719%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'a038ffffe1ee88e35019d7b4c6e62d7836b49c51' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agent\\drawreview.tpl',
      1 => 1535527339,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '140235b55b2babb3544-94528719',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b55b2bae9d772_61017076',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'pendAndProc' => 0,
    'drawInfoList' => 0,
    'val' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b55b2bae9d772_61017076')) {function content_5b55b2bae9d772_61017076($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
 
<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
		<div id="search" class="collapse in">
		<form action="" method="GET" role="form">
					<span>时间：</span>
					<input type="text"  id="startdate"   name="startDate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['startDate'];?>
" placeholder="输入开始日期">
					<input type="text"  id="enddate" name="endDate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['endDate'];?>
" placeholder="输入结束日期" >
					<button class="btn btn-info" type="submit">查询</button>
			<div style="clear:both;"></div>
		</form>
		</div>

</div>
<div class="row" style="margin:10px 0">
	<div style="float: left;font-weight: 700;">待处理体现:<?php echo (($tmp = @$_smarty_tpl->tpl_vars['pendAndProc']->value['processed'])===null||$tmp==='' ? 0 : $tmp);?>
元</div>
	<div style="float: left;margin-left:50px;font-weight: 700;">已处理体现:<?php echo (($tmp = @$_smarty_tpl->tpl_vars['pendAndProc']->value['pending'])===null||$tmp==='' ? 0 : $tmp);?>
元</div>
</div>


<div class="row">
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">提现审批</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>流水号</th>
						<th>时间</th>
						<th>代理ID/昵称</th>					
						<th>提现金额</th>	
						<th>OP_ID</th>
						<th>状态</th>
						<th>处理时间</th>
					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['val'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['val']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['drawInfoList']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['val']->key => $_smarty_tpl->tpl_vars['val']->value) {
$_smarty_tpl->tpl_vars['val']->_loop = true;
?>
					<tr>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['id'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['addtime'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['agentid'];?>
/<?php echo $_smarty_tpl->tpl_vars['val']->value['nickname'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['rmb'];?>
</td>
						<td>fixme</td>
						<?php if ($_smarty_tpl->tpl_vars['val']->value['status']==1) {?>
						<td style="text-align: center;">成功</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['status']==2) {?>
						<td style="text-align: center;">失败</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['status']==0) {?>
						<td>
							<div style="margin: 0 auto">
							<button type="button" id="" onclick="DealTrue('<?php echo $_smarty_tpl->tpl_vars['val']->value['id'];?>
',1)" style="border:0 none;background-color: transparent;float: left;"><img src="/assets/images/agent/success.svg" width="" height="20"></button>
							<button type="button" id="" onclick="DealFalse('<?php echo $_smarty_tpl->tpl_vars['val']->value['id'];?>
')" style="border:0 none;background-color: transparent;float: right;";><img src="/assets/images/agent/fail.svg" width="" height="20"></button>
							</div>
						</td>
						<?php }?>
					    <td><?php echo $_smarty_tpl->tpl_vars['val']->value['dealtime'];?>
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
		
		function DealFalse(id){

			if(!id){alert('非法参数！');return ;}
			if(confirm("请确定是否拒绝提现")){
				$.ajax({
					url:'drawreview.php',
					dataType:"",
					type:'POST',
					data:{
						method:'dealFalseDrawMoney',
						id:id,
					},
					success:function(data){
						if(data){
							if(data==0){
								alert("未有此订单！");
							}else if(data==1){
								alert('提现拒绝成功！');
							}else if(data ==-1){
								alert('提现拒绝失败！');
							}else{
								alert('错误');
							}
						}else{
							alert('未知错误！');
						}
						window.location.reload()
					},
					error:function(err){
						alert(err)
						return ;
					}
				});
			}
		}
		function DealTrue(id){
			if(!id){alert('非法参数！');return ;}
			if(confirm("请确定是否允许提现")){
				window.location.href="../pay/wxCash.php?order_no=" + id;
			}
		}
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
	</script><?php }} ?>
