<?php /* Smarty version Smarty-3.1.15, created on 2018-10-10 18:17:29
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\agent\gameplayer.tpl" */ ?>
<?php /*%%SmartyHeaderCode:175735bbdc3a9686021-64448608%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'da6d679eba4caffc76c6d279aa9d3c3c581c68bc' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\agent\\gameplayer.tpl',
      1 => 1538269512,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '175735bbdc3a9686021-64448608',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'List' => 0,
    'val' => 0,
    'page_html' => 0,
    '_REQUEST' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5bbdc3a98a5015_28590550',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5bbdc3a98a5015_28590550')) {function content_5bbdc3a98a5015_28590550($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row" style="margin: 1% 0">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="POST" class="form-inline" role="form">		
			<div class="form-group">
					<select name="s_type" id='s_type'>
						<option value="2">玩家ID</option>
						<option value="1">玩家昵称</option>
						<option value="3">代理ID</option>
						<option value="4">代理昵称</option>
					</select>
				</div>
					<input type="text" id="contains"  name="contains" value="" placeholder="请输入"> 
					<button class="btn btn-info" type="submit" id="search_reuslt">检索</button>	
			</div>
			<div style="clear:both;"></div>
		</form>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-xs-12">
		<div class="table-header">玩家列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>玩家ID/昵称</th>
					<th>认证</th>					
					<th>钻石</th>
					<th>金币</th>
					<th>七豆</th>
					<th>红包</th>
					<th>VIP</th>
					<th>魅力值</th>
					<th>消费</th>
					<th>状态</th>
					<th>注册时间</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['val'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['val']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['List']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['val']->key => $_smarty_tpl->tpl_vars['val']->value) {
$_smarty_tpl->tpl_vars['val']->_loop = true;
?>	
				<tr>
					<td>
						(<?php echo $_smarty_tpl->tpl_vars['val']->value['userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['val']->value['nickname'];?>
<br>	
						<span style="color: #666;font-size: 12px">(<?php echo $_smarty_tpl->tpl_vars['val']->value['buserid'];?>
)<?php echo $_smarty_tpl->tpl_vars['val']->value['bnickname'];?>
</span>		
					</td>

					<?php if ($_smarty_tpl->tpl_vars['val']->value['isname']==1) {?>
					<td>已认证</td>
					<?php } else { ?>
					<td>未认证</td>
					<?php }?>

					<td><?php echo round($_smarty_tpl->tpl_vars['val']->value['diamond']);?>
</td>
					<td><?php echo round($_smarty_tpl->tpl_vars['val']->value['gold']);?>
</td>
					<td><?php echo round($_smarty_tpl->tpl_vars['val']->value['qidou']);?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['val']->value['grift'];?>
</td>
					<td>vip<?php echo $_smarty_tpl->tpl_vars['val']->value['viplevel'];?>
</td>
					<td>fixme</td>
					<td>fixme</td>
					<?php if ($_smarty_tpl->tpl_vars['val']->value['status']==1) {?>
					<td>正常</td>
					<?php } elseif ($_smarty_tpl->tpl_vars['val']->value['status']==0) {?>
					<td>冻结</td>
					<?php } else { ?>
					<td></td>
					<?php }?>
					<td><?php echo $_smarty_tpl->tpl_vars['val']->value['addtime'];?>
</td>
					<td>
							<button onclick="showGiveCardWindow('<?php echo $_smarty_tpl->tpl_vars['val']->value['userid'];?>
')" >充钻</button>
							<button onclick="changeAgencyRelationship('<?php echo $_smarty_tpl->tpl_vars['val']->value['userid'];?>
','<?php echo $_smarty_tpl->tpl_vars['val']->value['nickname'];?>
','<?php echo $_smarty_tpl->tpl_vars['val']->value['buserid'];?>
','<?php echo $_smarty_tpl->tpl_vars['val']->value['bnickname'];?>
')" >绑定</button>
							<button onclick="showUserInfo('<?php echo $_smarty_tpl->tpl_vars['val']->value['userid'];?>
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
<div class="modal fade" id="gcModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="myModalLabel">玩家充值</h4>
			</div>
			<div class="modal-body">
			<table id="simple-table" class="table table-striped table-bordered table-hover">
				<tr>
					<td>玩家ID:</td>
					<td id="m_gameId"></td>
				</tr> 
				<tr>
					<td>玩家名称:</td>
					<td id='m_gameName'></td>
				</tr>
				<tr>
					<td>钻石:</td>
					<td id='m_gemsCount'></td>
				</tr>
				
			</table>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">充值数量:</label>
				<div class="col-sm-9">
					<input type="number" id="gems"  name="id" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['id'];?>
" placeholder="输入给与数量" > 
					<input type="hidden" name="search" value="1" >
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
					<input type="radio" name="m_type" value="1" checked="checked">玩家购钻
					<input type="radio" name="m_type" value="-1">系统赠送
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
<div class="modal fade" id="cgAgentModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="myModalLabel">修改代理关系</h4>
			</div>
			<div class="modal-body">
			<table id="simple-table" class="table table-striped table-bordered table-hover">
				<tr>
					<td>玩家ID:</td>
					<td id="m_guId"></td>
				</tr> 
				<tr>
					<td>玩家名称:</td>
					<td id='m_gName'></td>
				</tr>
				<tr>
					<td>代理ID:</td>
					<td id='m_agentUserid'></td>
				</tr>
				<tr>
					<td>代理名称:</td>
					<td id='m_agentName'></td>
				</tr>
				
			</table>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">代理ID:</label>
				<div class="col-sm-9">
					<input type="number" id="agentId"  name="agentId" value="" placeholder="输入要绑定代理的ID" > <span id='i_agentName'></span>
					<input type="hidden" name="search" value="1" >
				</div>
			</div>
			<div class="form-group">
			<div class="col-sm-9" style="height:10px;"></div>
			</div>
			<div style="clear:both;"></div>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-default" data-dismiss="modal">关闭
				</button>
              <button type="button" id="sub2" class="btn btn-primary">
					确认
				</button>
			</div>
		</div>
		<!-- /.modal-content -->
		</div>
	<!-- /.modal -->
</div>
<div class="modal fade" id="showInfoModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true" id="tabClose">&times;</button>
				<h4 class="modal-title" id="myModalLabel">详情</h4>
			</div>
			<ul class="nav nav-pills" id="tabBtn">
				<li class="active"><a href="#">个人信息</a></li>
				<li class=""><a href="#">认证信息</a></li>
				<li class=""><a href="#">收货信息</a></li>
			</ul>
			<div class="modal-body" id="tabContain">
			<table id="simple-table1" class="table table-striped table-bordered table-hover">
				<tr>
					<td>微信头像:</td>
					<td id="">
						<img src="" id ="c_avatar" width="50" height="50">
					</td>
				</tr>
				<tr>
					<td>游戏ID:</td>
					<td id='c_guId'></td>
				</tr>
				<tr>
					<td>游戏昵称:</td>
					<td id='c_nickname'></td>
				</tr>
				<tr>
					<td>注册时间:</td>
					<td id='c_addtime'></td>
				</tr>
				<tr>
					<td>推广人:</td>
					<td id='c_agentName'></td>
				</tr>
				<tr>
					<td>最后游戏时间:</td>
					<td id='c_lasttime'></td>
				</tr>
				<tr>
					<td>参与对局:</td>
					<td id='c_gaming'></td>
				</tr>
				<tr>
					<td>状态:</td>
					<td id='c_status'>
					<input type="radio" name="c_type" value="1">正常
					<input type="radio" name="c_type" value="0">冻结
					<input type="hidden" name="oldStatus" value="">
					</td>
				</tr>
			</table>
			<table id="simple-table2" class="table table-striped table-bordered table-hover">
				<tr>
					<td>姓名:</td>
					<td id="c_realname"></td>
				</tr>
				<tr>
					<td>身份证号:</td>
					<td id="c_idcard"></td>
				</tr>
			</table>
			<table id="simple-table3" class="table table-striped table-bordered table-hover">
				<tr>
					<td>姓名:</td>
					<td id='c_guId'></td>
				</tr>
				<tr>
					<td>手机号:</td>
					<td id='c_guId'></td>
				</tr>
				<tr>
					<td>省份:</td>
					<td id='c_guId'></td>
				</tr>
				<tr>
					<td>地址:</td>
					<td id='c_guId'></td>
				</tr>
			</table>
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
	function showGiveCardWindow(userId){
		$("#gcModal").modal('show');
		$.ajax({
			url: 'gameplayer.php',
			data: {
					method:'getGameMessage',
					userid:userId,
				},
			type: "POST",
			dataType: '',
			success:function(data){
				var tempData = jQuery.parseJSON(data);
				$("#m_gameId").text(tempData['userid']);
				$("#m_gameName").text(tempData['nickname']);
				$("#m_gemsCount").text(tempData['diamond']);
			},
			error:function() {

			}
		});
	}

	function changeAgencyRelationship(userid,gameName,Muserid,bnickname){
		$("#cgAgentModal").modal('show');
		$("#i_agentName").text('');
		$('#agentId').val('');
		$('#m_guId').text(userid);
		$('#m_gName').text(gameName);
		$('#m_agentUserid').text(Muserid);
		$('#m_agentName').text(bnickname);
	}

	function showUserInfo(userid){
		$("#showInfoModal").modal('show')
		$.ajax({
			url:'gameplayer.php',
			dataType:'',
			data:{
				'method':'showInfo',
				'userid':userid
			},
			type:'POST',
			success:function(data){
				data = jQuery.parseJSON(data)
				$('#c_avatar').attr("src",data.picfile)
				$('#c_guId').text(data.userid)
				$('#c_nickname').text(data.nickname)
				$('#c_addtime').text(data.addtime)
				$('#c_agentName').text(data.refereeid+'/'+data.refereename)
				$('#c_lasttime').text(data.logintime)
				$('#c_gaming').text(data.roomcnt)
				$('input[name=c_type][value="'+data.status+'"]').attr("checked","true")
				$('#c_realname').text(data.realname)
				$('#c_idcard').text(data.idcard)
				$('input[name=oldStatus]').attr("value",data.status)
			},
			error:function(err){

			}
		})
	}

	$('#sub').click(function(){
		var gems = $('#gems').val();
		var userid = $('#m_gameId').text();
		var money = $('#m_money').val();
		var remark = $('#remark').val();
		var m_type = $("input[name='m_type']:checked").val();

		if(m_type==1 && !money){
			alert('请输入金额');
			$('#m_money').val('');
			return;
		}
		if(m_type==-1) money = 0;
		$.ajax({
			url: 'gameplayer.php',
			type: 'POST',
			dataType: '',
			data: {
				method: 'SendDiamond',
				userid: userid,
				type:m_type,
				diamond:gems,
				remark:remark,
				money:money,
			},
			success:function(data){
				// console.log(data)
				data = jQuery.parseJSON(data)
				alert(data)
				$("#gcModal").modal('hide');
				window.location.reload();
				return
			},
			error: function(){
				alert('异常错误!')
			}
		});
	});

	$('#sub2').click(function(){
		var agentid = $('#agentId').val();
		var userid = $('#m_guId').text();
		if(!agentId){
			alert('请输入有效代理ID！');
			$('#agentId').val('');
			return;
		}
		if(agentid == 0){
			agentid = 1
		}
		if(agentid == userid){
			alert("禁止自己绑定自己！");
			return;
		}
		$.ajax({
			url: 'gameplayer.php',
			type: 'POST',
			dataType: '',
			data: {
				method: 'changeParentAgent',
				userid: userid,
				agentid:agentid
			},
			success:function(data){
				data = jQuery.parseJSON(data);
				// console.log(data)
				$("#cgAgentModal").modal('hide');
								alert(data);
				window.location.reload();
			},
			error: function(){

			}
		});
	});
	
	$('#c_status').change(function(){
		var status = parseInt($('#c_status input:radio:checked').val())+1
		var userid = $('#c_guId').text()
		var oldStatus = parseInt($('#c_status input:hidden').val())+1
		if(status != oldStatus){
			$.ajax({
				url:'gameplayer.php',
				dataType:"",
				type:'POST',
				data:{
					method:'updateUserStatus',
					userid:userid,
					status:status
				},
				success:function(data){
					data = jQuery.parseJSON(data)
					// console.log(data)
					alert(data)
					window.location.reload();
					return ;					
				},
				error:function(err){
					alert('更新失败,请重试!')
					return;
				}
			})
		}else{
			return ;
		}
	})
	
	$(function(){
	$('#tabContain').find('table').hide()
	$('#tabContain').find('table:first').show()
    $('#tabBtn li').on('click',function(){
    	var index = $(this).index()
    	$('#tabContain').find('table').hide().eq(index).show()
    	$(this).addClass('active').siblings().removeClass('active');
    })

    $('#contains').blur(function(){
			var contains = $('#contains').val()
			var s_type   = $('#s_type option:selected').val()
			var reg = /^[0-9]+.?[0-9]*$/;
			if(s_type != '1' && s_type != '4' && contains != '' && !reg.test(contains)){
				$('#contains').val('')
				alert('请输入有效ID')
				return 
			}
		})
  });

	$("#SelectInput input[name='m_type']").change(function(){
		if($(this).val()==-1){
			$("#m_money").attr("disabled",true);
			$("#m_money").val('');
		}else{
			$("#m_money").attr("disabled",false);
		}
	})

	$(document).ready(function(){
		var _REQUEST = <?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value;?>

 		if(_REQUEST == null) return
		$('#contains').attr("value",_REQUEST.contains) 
		$('#s_type').find('option[value="'+_REQUEST.s_type+'"]').attr('selected','selected')	
	})
	</script>
<?php }} ?>
