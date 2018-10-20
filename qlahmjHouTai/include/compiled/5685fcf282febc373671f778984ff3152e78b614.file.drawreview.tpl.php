<?php /* Smarty version Smarty-3.1.15, created on 2018-06-09 15:20:43
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\drawreview.tpl" */ ?>
<?php /*%%SmartyHeaderCode:170635b1b71bb2ddd06-30272279%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '5685fcf282febc373671f778984ff3152e78b614' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\drawreview.tpl',
      1 => 1525925270,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '170635b1b71bb2ddd06-30272279',
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
  'unifunc' => 'content_5b1b71bb3d7d36_11367872',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1b71bb3d7d36_11367872')) {function content_5b1b71bb3d7d36_11367872($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
 
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
					<input type="text" id="agent_uid" name="agent_uid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agent_uid'];?>
" placeholder="输入代理商玩家UID" > 
					<select name="type" id="type">
						<option value="">--筛选状态--</option>
						<option value="1">待处理</option>
						<option value="2">提现成功</option>
						<option value="3">已拒绝</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">开始日期</label>
				<div class="col-sm-9">
					<input type="text"  id="startdate"   name="startDate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['startDate'];?>
" placeholder="输入开始日期"   > 
					
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
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">提现审批</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>时间</th>
						<th>游戏ID</th>
						<th>微信昵称</th>					
						<th>级别</th>	
						<th>提现现金</th>
						<th>邀请人</th>
						<th>微信昵称</th>
						<th >状态</th>
						<th class="hidden-480">操作</th>

					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['earnings_info'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['earnings_info']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['earnings_infos']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['earnings_info']->key => $_smarty_tpl->tpl_vars['earnings_info']->value) {
$_smarty_tpl->tpl_vars['earnings_info']->_loop = true;
?>
					<tr>
						<!-- <td><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['id'];?>
</td> -->
						<td><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['addtime'];?>
</td>
						<td>
							<a href="drawreview.php?agent_uid=<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['agentid'];?>
"><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['agentid'];?>
</a>
						</td>
						<td><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['agentName'];?>
</td>
						<td>
							<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['istop']==1) {?>
								核心
							<?php } elseif ($_smarty_tpl->tpl_vars['earnings_info']->value['istop']==2) {?>
									铂金
							<?php } elseif ($_smarty_tpl->tpl_vars['earnings_info']->value['istop']==3) {?>
									金牌
							<?php }?>
						</td>
						<td><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['money'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['topId'];?>
</td>	
					    <td><?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['topName'];?>
</td>	
						<?php if ($_smarty_tpl->tpl_vars['earnings_info']->value['ispay']==0) {?>
								<td class="blue">待处理</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['earnings_info']->value['ispay']==1) {?>
								<td class="green">提现成功</td>
						<?php } elseif ($_smarty_tpl->tpl_vars['earnings_info']->value['ispay']==2) {?>
								<td class="red">已拒绝</td>
						<?php }?>

						<td>
							<button onclick="drawreject(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['cashId'];?>
,1,'<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['agentName'];?>
',<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['money'];?>
,'')"><i class="icon-check"></i>同意</button>
						    <button onclick="drawreject(<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['cashId'];?>
,2,'',<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['money'];?>
,<?php echo $_smarty_tpl->tpl_vars['earnings_info']->value['agentid'];?>
)" ><i class="icon-remove"></i>拒绝</button>
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
	
	<div class="modal fade" id="wmyModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<input type="hidden" id="out_trade_no" name="out_trade_no" value="" />
	<input type="hidden" id="m_type" name="type" value="" />
	<input type="hidden" id="m_money" name="m_money" value="" />
	<input type="hidden" id="m_agentid" name="m_agentid" value="" />
	<div class="modal-dialog" style="width: 330px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="myModalLabel">拒绝提现</h4>
			</div>
			<div class="modal-body">
				<h4 class="modal-title" id="myModalLabel2">拒绝原因</h4>				
				<input type="text" id="reason" name="reason" />
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
              	<button type="button" id="sub" class="btn btn-primary">确认</button>
			</div>
		</div>
		<!-- /.modal-content -->
	</div>
</div>

	<!--操作的确认层，相当于javascript:confirm函数-->
	<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>


	<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
	<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

	<script type="text/javascript">

		function drawreject(drawid,type,agentName,money,agentid){
			$("#out_trade_no").attr("value", drawid);
			$('#m_type').val(type);
			$('#m_money').val(money);
			$('#m_agentid').val(agentid);
			$("#reason").show();
			$("#myModalLabel").text("拒绝原因");
			$("#myModalLabel2").text("拒绝原因");
			if(type == 1){
				$("#reason").hide();
				$("#myModalLabel").text("同意提现");
				$("#myModalLabel2").text("请确认( "+agentName+" ) 提现 ("+money+" 元)");
			}
			$("#wmyModal").modal('show');
		}
		
		function reject()
		{
			var out_trade_no = $("#out_trade_no").attr("value");
			var type = $("#m_type").val();
			var reason = $("#reason").val();
			var money = $('#m_money').val();
			var agentid =$('#m_agentid').val();
			var param = {
					id:out_trade_no,
				};

			if(type ==2){
				param['method'] = 'reject';
				param['msg'] = reason;
				param['money'] = money;
				param['agentid'] = agentid;
			}else if(type ==1){
				param['method'] = 'tixianIsOk';
			}
			console.log(param);	
			$.post('drawreview.php',
					param, 	
					function(res) {
						if (res && typeof (res) === 'string') {
							res = JSON.parse(res);
						}
						if(res.result=='tx_already'){
							alert('已被审核操作,不能重复操作！');
						}
						if(res.result =='ok'){
							window.location.reload();
						}					
			});
		}
		
		$(document).ready(function(){
			$('#sub').on("click",function () {
				var type = $("#m_type").val();
				var reason = $("#reason").val();
				
				if(type==2 && reason.trim()=="")
				{
					alert("拒绝原因不能为空");
					return;
				}
				reject();
			});

			//设置传入的select 的值设置默认选项
			$("#type option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['type'];?>
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
	</script><?php }} ?>
