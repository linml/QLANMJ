<?php /* Smarty version Smarty-3.1.15, created on 2018-09-04 18:15:31
         compiled from "F:\project\qlahmjHouTai\include\template\agent\agent.tpl" */ ?>
<?php /*%%SmartyHeaderCode:269875b568da76b18e4-23184295%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '042dcb6cf2e73ae8639883df1097e11b39122939' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agent\\agent.tpl',
      1 => 1535859796,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '269875b568da76b18e4-23184295',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b568da7a5b1c0_63671121',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'level' => 0,
    'val' => 0,
    'admin' => 0,
    'agentsList' => 0,
    'agent' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b568da7a5b1c0_63671121')) {function content_5b568da7a5b1c0_63671121($_smarty_tpl) {?><?php if (!is_callable('smarty_modifier_truncate')) include 'F:\\project\\qlahmjHouTai\\include\\config/../../include/lib/Smarty/plugins\\modifier.truncate.php';
?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>

<div class="row">
	<div role="" class="form-inline">
		<form class="form-group" method="POST" action="">
			<select name="s_type" id="s_type" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['s_type'];?>
">
				<option value="ai.agentid">代理ID</option>
				<option value="ai.agentname">代理昵称</option>
				<option value="ai.parentid">上级代理ID</option>
			</select>

			<input id="contains" type="text" name="contains" placeholder="请输入" value="">
			<!-- <select name="s_grade" id="s_grade" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['s_grade'];?>
"> -->
			<select name="s_grade" id="s_grade" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['s_grade'];?>
">
				<option value="" selected>代理等级</option>
				<?php  $_smarty_tpl->tpl_vars['val'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['val']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['level']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['val']->key => $_smarty_tpl->tpl_vars['val']->value) {
$_smarty_tpl->tpl_vars['val']->_loop = true;
?>
				<option value="<?php echo $_smarty_tpl->tpl_vars['val']->value['levelid'];?>
"><?php echo $_smarty_tpl->tpl_vars['val']->value['name'];?>
</option>
				<?php } ?>
			</select>
			<select id="s_ischeck" name="s_ischeck" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['s_ischeck'];?>
">
				<option value="" selected>是否审核</option>
				<option value="1">未审核</option>
				<option value="2">已审核</option>
			</select>
			<select id="s_admin" name="s_admin" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['s_admin'];?>
">
				<option value="">管理员ID</option>
				<?php  $_smarty_tpl->tpl_vars['val'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['val']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['admin']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['val']->key => $_smarty_tpl->tpl_vars['val']->value) {
$_smarty_tpl->tpl_vars['val']->_loop = true;
?>
				<option value="<?php echo $_smarty_tpl->tpl_vars['val']->value['user_id'];?>
"><?php echo $_smarty_tpl->tpl_vars['val']->value['user_name'];?>
</option>
				<?php } ?>
			</select>
			<button id="searchBtn" class="btn btn-info">查询</button>
		</div>
	</form>
	<button class="btn btn-info" style="position: fixed;left: 92%;top:9%" onclick="ShowOpenAgent()">开通代理</button>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="table-header">账号列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>代理ID/昵称</th>
					<th>上级</th>	
					<th>级别</th>
					<th>贡献总额</th>
					<th>返利总额</th>
					<th>已提现</th>
					<th>余额</th>
					<th>下级数目</th>
					<th>绑定玩家</th>
					<th>钻石库存</th>
					<th>状态</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['agent'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['agent']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['agentsList']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['agent']->key => $_smarty_tpl->tpl_vars['agent']->value) {
$_smarty_tpl->tpl_vars['agent']->_loop = true;
?>
				<tr>	
					<td>(<?php echo $_smarty_tpl->tpl_vars['agent']->value['agentid'];?>
)<?php echo $_smarty_tpl->tpl_vars['agent']->value['agentname'];?>
</td>	
					<td ><?php echo $_smarty_tpl->tpl_vars['agent']->value['parentid'];?>
</td>
					<td><?php echo smarty_modifier_truncate($_smarty_tpl->tpl_vars['agent']->value['name'],2,'');?>
</td>
					<td><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agent']->value['sumpaynum'])===null||$tmp==='' ? 0 : $tmp);?>
</td>
					<td><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agent']->value['sumreturnrmb'])===null||$tmp==='' ? 0 : $tmp);?>
</td>
					<td><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agent']->value['drawmoney'])===null||$tmp==='' ? 0 : $tmp);?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['rmb'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['loweragents'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['binduser'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['diamond'];?>
</td>
					<?php if ($_smarty_tpl->tpl_vars['agent']->value['status']==1) {?>
					<td>正常</td>
					<?php } elseif ($_smarty_tpl->tpl_vars['agent']->value['status']==0) {?>
					<td>锁定</td>
					<?php }?>
						<td>
							<button class="btn btn-danger" onclick="sendmoneyInfo('<?php echo $_smarty_tpl->tpl_vars['agent']->value['agentid'];?>
')">划拨</button>
							<button class="btn btn-info" onclick ="showagentInfo('<?php echo $_smarty_tpl->tpl_vars['agent']->value['agentid'];?>
')" >详情</button>
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

<div class="modal fade" id="SendMoneyModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="myModalLabel">划拨钻石</h4>
			</div>
			<div class="modal-body">
			<table id="simple-" class="table table-striped table-bordered table-hover">
				<tr>
					<td>代理ID:</td>
					<td id="h_agentid"></td>
				</tr> 
				<tr>
					<td>代理名称:</td>
					<td id='h_agentname'></td>
				</tr>
				<tr>
					<td>钻石:</td>
					<td id='h_diamond'></td>
				</tr>
				
			</table>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">充值数量:</label>
				<div class="col-sm-9">
					<input type="number" id="diamondNum"  name="id" value="" placeholder="输入给与数量" > 
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">充值金额:</label>
				<div class="col-sm-9">
					<input type="number" id="m_money"  name="money" value="" placeholder="输入充值金额"  > 
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">备注:</label>
				<div class="col-sm-9">
					<input type="text" id="remark"  name="" value="" placeholder="备注不要超过15个字"  maxlength="15"> 
				</div>
			</div>
			<div class="form-group">
				<div class="col-sm-9" id="SelectInput">
					<input type="radio" name="m_type" value="1" checked="checked">代理购钻
					<input type="radio" name="m_type" value="-1">系统赠送
				</div>
			</div>
			<div style="clear:both;"></div>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-default" data-dismiss="modal">关闭
				</button>
              <button type="button" class="btn btn-primary" onclick="SendDiamond()">
					确认
				</button>
			</div>
		</div>
		<!-- /.modal-content -->
		</div>
	<!-- /.modal -->
</div>

<div class="modal fade" id="agentInfoModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true" id="tabClose">&times;</button>
				<h4 class="modal-title" id="myModalLabel">详情</h4>
			</div>
			<div class="modal-body" id="tabContain">
			<table id="simple-table1" class="table table-striped table-bordered table-hover">
				<tr>
					<td>微信头像:</td>
					<td id="">
						<img src="" id ="a_avatar" width="50" height="50">
					</td>
				</tr>
				<tr>
					<td>游戏ID:</td>
					<td id='a_guId'></td>
				</tr>
				<tr>
					<td>登录账号:</td>
					<td id='a_account'></td>
				</tr>
				<tr>
					<td>代理昵称:</td>
					<td id='a_nickname'></td>
				</tr>
				<tr>
					<td>姓名:</td>
					<td id='a_realname'></td>
				</tr>
				<tr>
					<td>微信号:</td>
					<td id='a_wechatnum'></td>
				</tr>
				<tr>
					<td>代理级别:</td>
					<td id='a_grade'>
						<select name="a_grade" onchange="changeLevel()">
							<option value="1">核心</option>
							<option value="2">白金</option>
							<option value="3">金牌</option>
							<option value="4">普通</option>
						</select>
					</td>
				</tr>
				<tr>
					<td>注册时间:</td>
					<td id='a_addtime'></td>
				</tr>
				<tr>
					<td>直接上级:</td>
					<td id='a_diragent'></td>
					<input id="rememberDir" value="" type="hidden">
				</tr>
				<tr>
					<td>参与对局:</td>
					<td id='a_gaming'></td>
				</tr>
				<tr>
					<td>账户状态:</td>
					<td id='a_status' onchange="resetStatus()">
					<input type="radio" name="c_type" value="2">正常
					<input type="radio" name="c_type" value="1">冻结
					<input type="hidden" name="oldStatus" value="">
					</td>
				</tr>
				<tr>
					<td>账户重置:</td>
					<td >
						<input type="hidden" value="" id="a_reset">
						<button class="btn btn-info" onclick="reSetPassword()">重置密码</button>
					</td>
				</tr>
			</table>
		<!-- 	<div class="modal-footer">
              <button type="button" id="sub" class="btn btn-primary" onclick="resetStatus()">
					确认
				</button>
			</div> -->
			<div class="form-group">
			<div class="col-sm-9" style="height:10px;"></div>
			</div>
			<div style="clear:both;"></div>
			</div>
			</div>
		<!-- /.modal-content -->
		</div>
	<!-- /.modal -->
</div>
<input type="" name="">
<div class="modal fade" id="openAgentModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true" id="tabClose">&times;</button>
				<h4 class="modal-title" id="myModalLabel">详情</h4>
			</div>

			<div class="modal-body" id="tabContain">
			<div class="form-horizontal" >
  				<div class="form-group">
    				<label for="name" class="col-sm-3 control-label">游戏ID</label>
    				<div class="col-sm-7">
    				<input required type="text" class="form-control" id="o_userid" placeholder="请输入ID">			
    				</div>

    				<div col-sm-2>
    					<button class="btn btn-default" id="o_search" onclick="checkExist()">检索</button>
    				</div>
 				</div>

 				<div class="form-group">
    				<label for="name" class="col-sm-3 control-label">微信昵称</label>
    				<div class="col-sm-7">
    				<input required type="text" class="form-control" id="o_nickname" disabled>
    				</div>
 				</div>

 				<div class="form-group">
    				<label for="name" class="col-sm-3 control-label">手机号</label>
    				<div class="col-sm-7">
    				<input required type="text" class="form-control" id="o_mobilenum" placeholder="" maxlength="11">				
    				</div>
 				</div>

 				<div class="form-group">
    				<label for="name" class="col-sm-3 control-label">姓名</label>
    				<div class="col-sm-7">
    				<input required type="text" class="form-control" id="o_name" placeholder="">    					
    				</div>
 				</div>
 				<div class="form-group">
    				<label for="name" class="col-sm-3 control-label">微信号</label>
    				<div class="col-sm-7">
    				<input required type="text" class="form-control" id="o_wechanum" placeholder="">    					
    				</div>
 				</div>
 				<div class="form-group">
    				<label for="name" class="col-sm-3 control-label">绑定代理</label>
    				<div class="col-sm-7">
    					<select id="o_dirAgent">
    						<option>查询绑定的玩家ID和昵称</option>
    						<option>不绑定该玩家</option>
    					</select> 					
    				</div>
 				</div>
 				<div class="form-group">
    				<label for="name" class="col-sm-3 control-label">开通级别</label>
    				<div class="col-sm-7">
    				<select id="o_level">
    					<option value="1">核心</option>
    					<option value="2">铂金</option>
    					<option value="3">金牌</option>
    					<option value="4">普通</option>
    				</select>
 				</div>
 				<div class="form-group">
 					<div class="col-md-offset-5">
 					<button class="btn btn-info" onclick="openAgent()">确定</button>
 					</div>
 				</div>
			</div>
			<div class="form-group">
			<div class="col-sm-9" style="height:10px;"></div>
			</div>
			<div style="clear:both;"></div>
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
	function showagentInfo(agentid)
	{	
		$("#agentInfoModal").modal('show');
		$.ajax({
			url: 'agent.php',
			data: {
					method:'getAgentInfo',
					agentid:agentid,
				},
			type: "POST",
			dataType: '',
			success:function(data){
				var data = jQuery.parseJSON(data)
				$('#a_avatar').attr('src',data.picfile)
				$('#a_guId').text(data.userid)
				$('#a_account').text(data.mobilenum)
				$('#a_nickname').text(data.agentname)
				$('#a_realname').text(data.realname)
				$('#a_wechatnum').text(data.wechatnum)

				$('#a_grade').find('option[value="'+data.levelid+'"]').attr('selected','selected')

				$('#a_addtime').text(data.addtime)
				$('#a_diragent').html('<input type="text" name="parentid" value="'+data.parentid+'" style="border:0 none;background-color:transparent;" disabled><button id="changeDirAgent" style="margin-left:15%">修改上级</button>')
				$('#a_gaming').text(data.roomcnt)
				$('#a_status input[name=c_type][value="'+(parseInt(data.status)+1)+'"]').attr('checked',true)
				$('#a_status input[name=oldStatus]').attr("value",(parseInt(data.status)+1))

				$('#a_reset').attr("value",data.agentid)
				$('#rememberDir').attr('value',data.parentid)
			},
			error:function() {

			}
		});
	}
	function reSetPassword(){
		var agentid = $('#a_reset').val()
		$.ajax({
			url:"agent.php",
			data:{
				method:"resetPassword",
				agentid:agentid
			},
			type:'POST',
			dataType:'',
			success:function(data){
				alert("初始密码为123456！");
				return;
			},
			error:function(){

			}
		});
	}
	function resetStatus(){
		var status = $('#a_status input:radio:checked').val()
		var oldStatus = $('#a_status input[name=oldStatus]').val()
		var	agentid = $('#a_reset').val()
		if(status == oldStatus) return ;
		$.ajax({
			url:'agent.php',
			data:{
				method:"resetStatus",
				agentid:agentid,
				status:status
			},
			type:'POST',
			dataType:'',
			success:function(data){
				alert('修改成功')
				$("#agentInfoModal").modal('hide');
				window.location.reload();
				return;
			},
			error:function(){

			}
		})
	}
	function ShowOpenAgent(){

		$("#openAgentModal").modal('show')
	}
	function checkExist(){
		var o_userid = $('#o_userid').val();
		if(o_userid == ""){
			alert('ID不为空')
			return
		}
		if(isNaN(o_userid)){
			alert('玩家ID不合法')
			return
		}
			$.ajax({
				url:'agent.php',
				type:'POST',
				dataType:'',
				data:{
					method:'checkIDExist',
					o_userid:o_userid
				},
				success:function(data){
					data = jQuery.parseJSON(data)
					if(data.status == 1){
						alert('服务器验证参数为空')
						return
					}else if(data.status == 2){
						alert('未绑定该玩家或玩家不存在')
						return
					}else if(data.status == 3){
						$('#o_nickname').val(data.nickname)
						if(typeof(data.agentid) == "undefined" || typeof(data.agentname) == "undefined" ){
							$('#o_dirAgent').html('<option id="" value="">选择绑定代理</option><option value="0" selected>不绑定代理</option>')
						}else{
							$('#o_dirAgent').html('<option value="'+data.agentid+'">'+'('+data.agentid+')'+data.agentname+'</option><option value="0">不绑定该代理</option>')
						}				
					}else if(data.status == 4){
						alert("该玩家已经是代理")
						return
					}
				},
				error:function(err){

				}
			})	
	}
	function openAgent(){
		var o_userid = $('#o_userid').val()
		var o_nickname = $('#o_nickname').val()
		var o_mobilenum = $('#o_mobilenum').val()
		var o_name = $('#o_name').val()
		var o_wechanum = $('#o_wechanum').val()
		var o_dirAgent = $('#o_dirAgent option:selected').val()
		var o_level = $('#o_level option:selected').val()
		if(o_mobilenum == '' || o_name == '' || o_wechanum == '' || o_userid == '' || o_nickname == '' || o_dirAgent == '' || o_level == '')  return;
			$.ajax({
				url:'agent.php',
				type:'POST',
				dataType:'',
				data:{
					method:'openAgent',
					o_userid:o_userid,
					o_nickname:o_nickname,
					o_mobilenum:o_mobilenum,
					o_name:o_name,
					o_wechanum:o_wechanum,
					o_dirAgent:o_dirAgent,
					o_level:o_level
				},
				success:function(data){
					alert(data)
					$("#agentInfoModal").modal('hide')
					window.location.reload()
					return
				},
				error:function(err){
					alert(err);
				}
			})
	}
	function sendmoneyInfo(agentid){
		$('#SendMoneyModal').modal('show')
		if(agentid == null) return
		$.ajax({
			url:'agent.php',
			dataType:'',
			type:'POST',
			data:{
				method:'ShowAgentAccout',
				agentid:agentid
			},
			success:function(data){
				data = jQuery.parseJSON(data)
				$('#h_agentid').text(data.agentid)
				$('#h_agentname').text(data.agentname)
				$('#h_diamond').text(data.diamond)
			},
			error:function(err){

			}
		})	
	}
	function SendDiamond(){
		h_agentid = $('#h_agentid').text()
		diamond = $('#diamondNum').val()
		m_money = $('#m_money').val()
		m_type = $('#SelectInput input:radio:checked').val()
		remark = $('#remark').val()
		if(diamond == '') return
		$.ajax({
			url:'agent.php',
			dataType:'',
			type:'POST',
			data:{
				method:'SendDiamond',
				agentid:h_agentid,
				diamond:diamond,
				money:m_money,
				type:m_type,
				remark:remark
			},
			success:function(data){
				data = jQuery.parseJSON(data)
				$('#SendMoneyModal').modal('hide');
				window.location.reload()
				return;
			},
			error:function(err){

			}
		})
	}
	function changeLevel(){
		var	agentid = $('#a_reset').val()
		var level = $('#a_grade option:selected').val()
		$.ajax({
			url:'agent.php',
			dataType:'',
			type:'POST',
			data:{
				method:'changeLevel',
				agentid:agentid,
				level:level
			},
			success:function(data){
				if(data = 1 ){
					alert('修改成功')
					window.location.reload()
				}else{
					alert('修改失败')
					window.location.reload()
				}
			},
			error:function(err){

			}
		})
	}

</script>
<script type="text/javascript">
	$(function(){
		$('#o_mobilenum').blur(function(){
			var o_mobilenum = $('#o_mobilenum').val()
				if(!(/^1[3|4|5|8][0-9]\d{8}$/.test(o_mobilenum))){
				alert('不是完整的手机号码或者')
				return false
			}
		})

		$('#contains').blur(function(){
			var contains = $('#contains').val()
			var s_type   = $('#s_type option:selected').val()
			var reg = /^[0-9]+.?[0-9]*$/;
			if(s_type != 'ai.agentname' && !reg.test(contains)){
				$('#contains').val('')
				alert('请输入ID')
				return 
			}
		})


		$("#SelectInput input[name='m_type']").change(function(){
		if($(this).val()==-1){
			$("#m_money").attr("disabled",true);
			$("#m_money").val('');
		}else{
			$("#m_money").attr("disabled",false);
		}
		})
		$('#o_dirAgent').change(function(){
			var tps = $('#o_dirAgent option:selected').val()
			if(tps == '0') return	
			agentid = prompt("请输入要绑定的上级代理ID")
			if(agentid == null) return
			if(!isNaN(agentid)){
				$.ajax({
					url:'agent.php',
					dataType:'',
					type:'POST',
					data:{
						method:'getAgentInfo',
						agentid:agentid
					},
					success:function(data){
						data = jQuery.parseJSON(data)
						$('#o_dirAgent').html('<option value="'+data.agentid+'">'+'('+data.agentid+')'+data.agentname+'</option><option value="0">不绑定该代理</option>')
					},
					error:function(err){

					}
				})
			}
		})

		$(document).on('click','#changeDirAgent',function(){
			var userid = $('#a_guId').text()
			if(userid == ''){
				alert('请检查玩家ID')
				return
			}
			// var toagentid = prompt('请输入要绑定的上级代理ID')
			// if(toagentid == null) return
			$('#a_diragent').find('input').attr("disabled",false)
		})

		$(document).on('blur','#a_diragent input',function(){
			var userid = $('#a_guId').text()
			var agentid = $('#rememberDir').val()
			if(userid == ''){
				alert('请检查玩家ID')
				return
			}
			toagentid = $('#a_diragent input').val()
			$.ajax({
				url:'agent.php',
				dataType:'',
				type:'POST',
				data:{
					method:'changeDirAgent',
					userid:userid,
					agentid:toagentid
				},
				success:function(data){
					if(data == 1){
						alert('修改成功!')
						window.location.reload()
						return
					}else if(data == 2){
						alert('玩家不存在')
						$('#a_diragent input').val(agentid)
						return
					}else{
						alert('修改失败!')
						return
					}
				},
				error:function(err){

				}
			})
		})
	})

	$(document).ready(function(){
 			var _REQUEST = <?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value;?>

 			if(_REQUEST == null) return
			$('#contains').attr("value",_REQUEST.contains) 
			$('#s_type').find('option[value="'+_REQUEST.s_type+'"]').attr('selected','selected')
			$('#s_grade').find('option[value="'+_REQUEST.s_grade+'"]').attr('selected','selected')
			$('#s_ischeck').find('option[value="'+_REQUEST.s_ischeck+'"]').attr('selected','selected')
			$('#s_admin').find('option[value="'+_REQUEST.s_admin+'"]').attr('selected','selected')
	})
</script>
<?php }} ?>
