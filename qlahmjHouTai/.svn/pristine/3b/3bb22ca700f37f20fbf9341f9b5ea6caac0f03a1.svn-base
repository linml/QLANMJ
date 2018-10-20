<?php /* Smarty version Smarty-3.1.15, created on 2018-06-05 10:52:31
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\agentAnalysis.tpl" */ ?>
<?php /*%%SmartyHeaderCode:94115b0b7f6f43a7d4-61658024%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '1629c236dea4d3bb9a59c17ef760cf884ffe466c' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\agentAnalysis.tpl',
      1 => 1528163403,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '94115b0b7f6f43a7d4-61658024',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b0b7f6f6614d9_27683608',
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
<?php if ($_valid && !is_callable('content_5b0b7f6f6614d9_27683608')) {function content_5b0b7f6f6614d9_27683608($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

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
					<input type="text" name="agentid" id="user_name" placeholder="输入代理商玩家UID" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agentid'];?>
"> 
					<select name="agent_type" id="topType">
						<option value="">级别</option>
						<option value="1">核心代理</option>
						<option value="2">铂金代理</option>
						<option value="3">金牌代理</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">代理商UID</label>
				<div class="col-sm-9">
					<input type="text" name="topAgent" id="topAgent" placeholder="输入代理商UID" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['topAgent'];?>
"> 
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
	<div class="col-xs-12">
		<div class="table-header">代理报表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					
					<th>代理商</th>
					<th>代理级别</th>	
					<th>进钻数</th>
					<th>进钻额</th>
					<th>充值额</th>
					<th>邀请返利</th>
					<th>直接返利</th>					
				<!--<th>铂金返利</th>
					<th>总代返利</th>
					<th>平台利润</th> -->

				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['agent'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['agent']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['agents']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['agent']->key => $_smarty_tpl->tpl_vars['agent']->value) {
$_smarty_tpl->tpl_vars['agent']->_loop = true;
?>
				<tr>
					
					<td>(<?php echo $_smarty_tpl->tpl_vars['agent']->value['user_game_id'];?>
)<?php echo $_smarty_tpl->tpl_vars['agent']->value['nickName'];?>
</td>
					<td>
						<?php if ($_smarty_tpl->tpl_vars['agent']->value['istop']==1) {?>
							<span class="red">核心</span>
						<?php } elseif ($_smarty_tpl->tpl_vars['agent']->value['istop']==2) {?>
							<span class="green">铂金</span>
						<?php } elseif ($_smarty_tpl->tpl_vars['agent']->value['istop']==3) {?>
							<span class="gray">金牌</span>
						<?php }?>
					</td>
					<td ><?php echo $_smarty_tpl->tpl_vars['agent']->value['cz_num'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['cz_money'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['cz_d_money'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['yqfx_num'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['zjfx_num'];?>
</td>
					<!-- <td><?php echo $_smarty_tpl->tpl_vars['agent']->value['bjfx_num'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['hxfx_num'];?>
</td>
					<td></td> -->
				</tr>
				<?php } ?>
			</tbody>
		</table>
		<!-- START 分页模板 -->
        <?php echo $_smarty_tpl->tpl_vars['page_html']->value;?>

		<!-- END -->
	</div>
</div>


<div class="modal fade" id="gcModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="myModalLabel">划拨钻石</h4>
			</div>
			<div class="modal-body">
			<table id="simple-table" class="table table-striped table-bordered table-hover">
				<tr>
					<td>代理ID:</td>
					<td id="m_agentId"></td>
				</tr> 
				<tr>
					<td>代理名称:</td>
					<td id='m_agentName'></td>
				</tr>
				<tr>
					<td>钻石:</td>
					<td id='m_gemsCount'></td>
				</tr>
				
			</table>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">充值数量:</label>
				<div class="col-sm-9">
					<input type="text" id="gems"  name="id" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['id'];?>
" placeholder="输入给与数量" > 
					<input type="hidden" name="search" value="1" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">充值金额:</label>
				<div class="col-sm-9">
					<input type="number" id="m_monye"  name="money" value="" placeholder="输入充值金额"  > 
				</div>
			</div>
			<div class="form-group">
				<div class="col-sm-9">
					<input type="radio" name="m_type" value="1" checked="checked">代理购钻
					<input type="radio" name="m_type" value="-1">系统赠送
				</div>
			</div>
			<div class="form-group">
				<div class="col-sm-9" style="height:10px;"> 
					<div id="uid" style="display: none" ></div>
				</div>
			</div>
			<div style="clear:both;"></div>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-default" data-dismiss="modal">关闭
				</button>
              <button type="button" id="sub" class="btn btn-primary">
					确认
				</button>
			</div>
		</div>
		<!-- /.modal-content -->
		</div>
	<!-- /.modal -->
</div>



<!--操作的确认层，相当于javascript:confirm函数-->
<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>


<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<script type="text/javascript">
	function reportsGems(agentid)
	{	
		$("#agentid").attr("value", agentid);
		$("#gcModal").modal('show');
		$.ajax({
			url: '/houtai/agent/agentReports.php',
			type: 'POST',
			dataType: '',
			data: {method: 'getAgentByAgentId',agentid:agentid},
			success:function(response){
				var tempData = jQuery.parseJSON(response);
				$("#m_agentId").text(tempData[0]['user_game_id']);
				$("#m_agentName").text(tempData[0]['nickName']);
				$("#m_gemsCount").text(tempData[0]['cardNum']);
				$("#uid").text(tempData[0]['id'])
			},
			error: function(){

			}
		});
	}

	$('#sub').click(function(){
		var gems = $('#gems').val();
		var userid = $('#uid').text();
		var name =$('#m_agentName').text();
		var money = $('#m_monye').val();
		var m_type = $("input[name='m_type']:checked").val();
		/*if(gems < 0){
			alert('钻石数量不能小于0!');
			$('#gems').val('');
			return;
		}*/

		if(m_type==1 && !money){
			alert('请输入金额');
			$('#m_monye').val('');
			return;
		}
		if(money < 0){
			alert('钻石数量不能小于0!');
			$('#m_monye').val('');
			return;
		}
		if(m_type==-1) money = 0;
		$.ajax({
			url: '/houtai/agent/agentReports.php',
			type: 'POST',
			dataType: '',
			data: {
				method: 'addGems',
				agentid: userid,
				agentName:name,
				gems:gems,
				money:money,
				m_type:m_type
			},
			success:function(data){
				// console.log(data);
				$("#gcModal").modal('hide');
				window.location.reload();
			},
			error: function(){

			}
		});
	});
	$(function(){
		//设置传入的select 的值设置默认选项
		$("#topType option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agent_type'];?>
']").attr('selected',true);
	});
	
	$("input[name='m_type']").change(function(){
		if($(this).val()==-1){
			$("#m_monye").attr("disabled",true);
			$("#m_monye").val('');
		}else{
			$("#m_monye").attr("disabled",false);
		}
	})
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
