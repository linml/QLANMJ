<?php /* Smarty version Smarty-3.1.15, created on 2018-06-20 15:32:13
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\agent.tpl" */ ?>
<?php /*%%SmartyHeaderCode:177865b179adeabe240-82770273%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'c49a6a6e04180f0c94c0354d6f7bbe1e508c5e69' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\agent.tpl',
      1 => 1529459960,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '177865b179adeabe240-82770273',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b179adeb5a664_42862629',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'group_judge' => 0,
    'user_name' => 0,
    'agents' => 0,
    'agent' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b179adeb5a664_42862629')) {function content_5b179adeb5a664_42862629($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

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
					<select name="agent_type" id="topType">
						<option value="">级别</option>
						<option value="1">核心代理</option>
						<option value="2">铂金代理</option>
						<option value="3">金牌代理</option>	 
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">上级代理UID</label>
				<div class="col-sm-9">
					<input type="text" name="t1agent" id="user_name" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['t1agent'];?>
" placeholder="输入上级代理UID" > 
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
		<div class="table-header">账号列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>

					<th>代理ID</th>
					<th>登录账号</th>	
					<th>微信昵称</th>
					<th>代理级别</th>
					<!-- <th>手机号</th> -->
					<?php if ($_smarty_tpl->tpl_vars['group_judge']->value) {?>
						<?php if ($_smarty_tpl->tpl_vars['user_name']->value=="leon1983") {?>
							<th>微信号</th>
						<?php }?>
					<?php }?>
					
					<th>直属上级</th>					
					<th>间接上级</th>
					<?php if ($_smarty_tpl->tpl_vars['group_judge']->value) {?>
						<th>状态</th>
					<?php }?>
					<th >注册时间</th>
					<?php if ($_smarty_tpl->tpl_vars['group_judge']->value) {?>
						<th>操作</th>
					<?php }?>

				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['agent'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['agent']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['agents']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['agent']->key => $_smarty_tpl->tpl_vars['agent']->value) {
$_smarty_tpl->tpl_vars['agent']->_loop = true;
?>
				<tr>
					
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['user_game_id'];?>
</td>
					<td >
						<?php if ($_smarty_tpl->tpl_vars['user_name']->value!='leon1983') {?>
							<?php echo mb_substr($_smarty_tpl->tpl_vars['agent']->value['login'],0,4,'utf-8');?>
***<?php echo mb_substr($_smarty_tpl->tpl_vars['agent']->value['login'],8,11,'utf-8');?>

						<?php } else { ?>
							<?php echo $_smarty_tpl->tpl_vars['agent']->value['login'];?>

						<?php }?>

					</td>
					<td ><?php echo $_smarty_tpl->tpl_vars['agent']->value['gName'];?>
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
					<!-- <td><?php echo $_smarty_tpl->tpl_vars['agent']->value['tel'];?>
</td> -->
					<?php if ($_smarty_tpl->tpl_vars['group_judge']->value) {?>
						<?php if ($_smarty_tpl->tpl_vars['user_name']->value=='leon1983') {?>
							<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['weChat'];?>
</td>
						<?php }?>
					<?php }?>

					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['directName'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['indirectName'];?>
</td>
					<?php if ($_smarty_tpl->tpl_vars['group_judge']->value) {?>
						<td>
							<?php if ($_smarty_tpl->tpl_vars['agent']->value['status']==0) {?>
								<spen class="red">禁锢</spen>&nbsp;&nbsp;
								<a  class="green" href="agent.php?method=openAgent&agent=<?php echo $_smarty_tpl->tpl_vars['agent']->value['user_game_id'];?>
"  title= "打开" ><i class="icon-play"></i>打开</a>
							<?php } elseif ($_smarty_tpl->tpl_vars['agent']->value['status']==1) {?>
								<spen class="green">自由</spen>&nbsp;&nbsp;
								<a href="agent.php?method=closeAgent&agent=<?php echo $_smarty_tpl->tpl_vars['agent']->value['user_game_id'];?>
" class=" red" title= "关闭" ><i class="icon-pause red" ></i>关闭</a>
							<?php }?>
						</td>
					<?php }?>
					<td><?php echo $_smarty_tpl->tpl_vars['agent']->value['addtime'];?>
</td>
					<?php if ($_smarty_tpl->tpl_vars['group_judge']->value) {?>
						<td>
							<button id="edit" onclick="switchagent(<?php echo $_smarty_tpl->tpl_vars['agent']->value['user_game_id'];?>
)">修改</button>
							<button id="reSetPassword" onclick ="reSetPassword(<?php echo $_smarty_tpl->tpl_vars['agent']->value['user_game_id'];?>
)" >重置密码</button>
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


<div class="modal fade" id="wmyModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<input type="hidden" id="agentid" name="agentid" value="" />
	<div class="modal-dialog" style="width: 600px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="myModalLabel">资料修改</h4>
			</div>
			<div class="modal-body">
				<div class="form-group">
					<div >
						<div><span>代理ID:</span><span id="m_agentid"></span></div>
						<div><span>微信昵称:</span><span id="m_wechatName"></span></div>
						<div><span>手机号:</span><span id="m_tel"></span></div>
					</div>
					<div>
						<div><span>登录账号:</span><span id="m_login"></span></div>
						<div><span>微信账号:</span><span id="m_wechat"></span></div>
						<div><span>代理级别:</span>
							<select name="m_agenttype" id="m_type" >
								<option value="1">核心</option>
								<option value="2">铂金</option>
								<option value="3">金牌</option>
							</select>
						</div>
					</div>
				</div>
				<div>
					<label>返利模式:</label>
					<input type="radio" name="rose_type" value="1" checked ='true'> 默认
					<input type="radio" name="rose_type" value="2"> 设置
					<div id='m_rosePoint'>
						<input type="number"  min="0"  name="flowpoint" placeholder="请输入返利点！">
					</div>
				</div>
				<div class="form-group">
					<div><label>直属上级</label><span id="directAgent"></span> <button id="btn_directAgent"> 解除关系</button><span id='dir_msg'></span></div>
					<div><label>间接上级</label><span id="indirectAgent"></span> <button id="btn_indirectAgent"> 解除关系</button><span id='indir_msg'></span></div>
				</div>

				<div class="form-group">
					<div><span>注册时间:</span><span id="register"></span></div>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="modal-footer">
              	<button type="button" id="deleteAgent" class="btn btn-primary">删除代理</button>
				<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
              	<button type="button" id="sub" class="btn btn-primary">确认</button>
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
	function switchagent(agentid)
	{	
		$("#agentid").attr("value", agentid);
		$('#dir_msg').text('');
		$('#indir_msg').text('');
		$("#wmyModal").modal('show');
		$.ajax({
			url: '/houtai/agent/agent.php',
			data: {
					method:'getAgentInfor',
					agentid:agentid,
				},
			type: "POST",
			dataType: '',
			success:function(data){
				var tempData = jQuery.parseJSON(data);
				$("#m_agentid").text(tempData['user_game_id']);
				$("#m_wechatName").text(tempData['gName']);
				$("#m_tel").text(tempData['tel']);
				$("#m_login").text(tempData['login']);
				$("#m_wechat").text(tempData['weChat']);
				$("#m_type option[value='"+tempData['istop']+"']").attr('selected', true);;
				$("#directAgent").text("("+tempData['directUserid']+")"+tempData['directName']);
				$("#directAgent").attr('name',tempData['directUserid'])
				$("#indirectAgent").text("("+tempData['indirectUserid']+")"+tempData['indirectName']);
				$("#indirectAgent").attr('name',tempData['indirectUserid'])
				$("#register").text(tempData['addtime']);

			},
			error:function() {

			}
		});
	}
	
	function reject()
	{
		var dir_msg = $('#dir_msg').text();
		var indir_msg = $('#indir_msg').text();
		var m_type = $('#m_type').val();
		var rose_type = $("input[name='rose_type']:checked").val();
		var directAgent = $('#directAgent').attr('name');
		var indirectAgent =  $('#indirectAgent').attr('name');
		var gameUserid = $('#m_agentid').text();
		var userid ='';
		var agentid ='';

		if(dir_msg && !indir_msg){
			if(!directAgent){
				alert('直接代理参数获取失败！');
				return;
			}
			if(directAgent&&indirectAgent){
				userid = gameUserid;
				agentid = indirectAgent;
			}else{
				userid = gameUserid;
				agentid = 1;
			}
		}else if(!dir_msg && indir_msg){
			if(!directAgent||!indirectAgent){
				alert('直接或间接代理参数有误！');
				return;
			}
			if(directAgent&&indirectAgent){
				userid = directAgent;
				agentid = 1;
			}
		}
		var param = {
				method : 'changeAgentRelationShip',
				agent : agentid,
				agent_type:m_type,
				userid:userid,
				gUserid:gameUserid,
				rose_type:rose_type
			};
		if(rose_type==2){
			var flowpoint = $("input[name='flowpoint']").val();
			if(flowpoint){
				param['flowpoint'] =flowpoint;
			}else{
				alert("返利点不能设置为空！");
				return;
			}
		}
		$.post('agent.php',
				param,
				function(res) {
					if (typeof (res) === 'string') {
						res = JSON.parse(res);
					}
					window.location.reload();
					alert(res['result']);
					// console.log(res);
		});
	}
	
	$(document).ready(function(){
		$('#sub').on("click",function () {
			reject();
		});

		//设置传入的select 的值设置默认选项
		$("#topType option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agent_type'];?>
']").attr('selected',true);
		//设置默认不显示
		$('#m_rosePoint').hide();
	});

	function reSetPassword(agentid){
		$.ajax({
			url:"/houtai/agent/agent.php",
			data:{
				method:"resetPassword",
				agentid:agentid
			},
			type:'POST',
			dataType:'',
			success:function(data){
				alert("您的初始密码为123456！");

			},
			error:function(){

			}
		});
	}

	$('#deleteAgent').click(function(){
		var result = confirm('确认删除当前代理！');
		if(result){
			var agentid = $('#m_agentid').text();
			$.ajax({
				url:'agent.php',
				data:{
					method:'deleteAgent',
					agent:agentid
				},
				type:'POST',
				dataType:'',
				success:function(res){
					alert(res);
					window.location.reload();
				},
				error:function(){

				}
			});
		}
	});

	//直接代理
	$('#btn_directAgent').click(function(){
		var top1 = $('#directAgent').attr('name');
		var indircter = $('#indir_msg').text();
		if(top1!=null&&!indircter){
			$('#dir_msg').text('ok');
		}else  if(top1){
			alert('一次操作只能选择解除关系！');
		}
	});

	//间接代理
	$('#btn_indirectAgent').click(function(){
		var top2 = $('#indirectAgent').attr('name');
		var dircter = $('#dir_msg').text();
		if(top2!=null&&!dircter){
			$('#indir_msg').text('ok');
		}else if(top2){
			alert('一次操作只能选择解除关系！');
		}	
	});
	
	$("input[name='rose_type']").change(function(){
		if($(this).val()==1){
			$('#m_rosePoint').slideUp();
		}else if($(this).val()==2){
			$('#m_rosePoint').slideDown();
		}	
	});
	
	
</script>
<?php }} ?>
