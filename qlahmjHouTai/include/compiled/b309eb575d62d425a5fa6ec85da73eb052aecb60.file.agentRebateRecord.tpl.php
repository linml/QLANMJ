<?php /* Smarty version Smarty-3.1.15, created on 2018-10-10 18:17:45
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\agent\agentRebateRecord.tpl" */ ?>
<?php /*%%SmartyHeaderCode:279265bbdc3b97dd727-54526229%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'b309eb575d62d425a5fa6ec85da73eb052aecb60' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\agent\\agentRebateRecord.tpl',
      1 => 1538269512,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '279265bbdc3b97dd727-54526229',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'rebateList' => 0,
    'val' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5bbdc3b98568b1_89548784',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5bbdc3b98568b1_89548784')) {function content_5bbdc3b98568b1_89548784($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
 
<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div role="" class="form-inline">
	<form class="form-group" method="POST" action="">
	<select name="type" id="type" value="">
		<option value="1">代理ID</option>
		<option value="2">代理昵称</option>
		<option value="3">上级代理ID</option>
	</select>
	<input id="contains" type="text" name="contains" placeholder="请输入" value="">
	
	<input type="text" id="startdate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['startdate'];?>
" name="startdate" placeholder="输入开始日期"> 
	<input type="text" id="enddate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['enddate'];?>
" name="enddate" placeholder="输入结束日期" >
	<button id="searchBtn" class="btn btn-info">查询</button>
	</div>
	</form>
</div>
<div class="row">
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">代理报表</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>代理ID/昵称</th>
						<th>上级</th>
						<th>级别</th>
						<th>充值贡献</th>
						<th>玩家返佣</th>
						<th>一级返佣</th>
						<th>二级返佣</th>
						<th>三级返佣</th>
						<th>充值数量</th>
						<th>操作</th>
					</tr>
				</thead>
				<tbody>
					<?php  $_smarty_tpl->tpl_vars['val'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['val']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['rebateList']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['val']->key => $_smarty_tpl->tpl_vars['val']->value) {
$_smarty_tpl->tpl_vars['val']->_loop = true;
?>
					<tr>
						<td>(<?php echo $_smarty_tpl->tpl_vars['val']->value['userid'];?>
)<?php echo $_smarty_tpl->tpl_vars['val']->value['nickname'];?>
</td>
						<td>(<?php echo $_smarty_tpl->tpl_vars['val']->value['upuserid'];?>
)<?php echo $_smarty_tpl->tpl_vars['val']->value['upnickname'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['name'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['sumpaynum'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['onerebate'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['tworebate'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['threerebate'];?>
</td>
						<td><?php echo $_smarty_tpl->tpl_vars['val']->value['fourrebate'];?>
</td>
						<td><?php echo round($_smarty_tpl->tpl_vars['val']->value['sumfundmoney']);?>
</td>
						<td>
							<button onclick="showDetail(<?php echo $_smarty_tpl->tpl_vars['val']->value['agentid'];?>
)">收入报表</button>
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

<div class="modal fade" id="showInfoModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 700px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true" id="tabClose">&times;</button>
				<h4 class="modal-title" id="myModalLabel">详情</h4>
				<input type="hidden" name="" id="cacheUserid">
			</div>
			<ul class="nav nav-pills" id="tabBtn">
				<li class="active" onclick="DayData()"><a href="#">日收入</a></li>
				<li class="" onclick="MonthData()"><a href="#">月收入</a></li>
			</ul>
			
			<div class="modal-body" id="tabContain">
			<table id="simple-table1" class="table table-striped table-bordered table-hover">
				<thead>
					<td>日期</td>
					<td>充值贡献</td>
					<td>玩家返佣</td>
					<td>一级返佣</td>
					<td>二级返佣</td>
					<td>三级返佣</td>
					<td>充钻数量</td>
				</thead>
				<tbody id="dayData">
				
				</tbody>
			</table>
			<table id="simple-table2" class="table table-striped table-bordered table-hover">
				<thead>
					<td>月份</td>
					<td>充值贡献</td>
					<td>玩家返佣</td>
					<td>一级返佣</td>
					<td>二级返佣</td>
					<td>三级返佣</td>
					<td>充钻数量</td>
				</thead>
				<tbody id="monthData">
					
				</tbody>
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
		$(document).ready(function(){
 			var _REQUEST = <?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value;?>

 			if(_REQUEST == null) return
			$('#contains').attr("value",_REQUEST.contains) 
			$('#type').find('option[value="'+_REQUEST.type+'"]').attr('selected','selected')
			$('#startdate').attr("value",_REQUEST.startdate)
			$('#enddate').attr("value",_REQUEST.enddate)
		})

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
			$('#contains').blur(function(){
			var contains = $('#contains').val()
			var type   = $('#type option:selected').val()
			var reg = /^[0-9]+.?[0-9]*$/;
			if(type != '2' && contains != '' && !reg.test(contains)){
				$('#contains').val('')
				alert('请输入ID')
				return 
			}
		})
		})
		
	</script>
<script type="text/javascript">
	$(function(){
		$('#tabContain').find('table').hide()
		$('#tabContain').find('table:first').show()
	    $('#tabBtn li').on('click',function(){
	    	var index = $(this).index()
	    	$('#tabContain').find('table').hide().eq(index).show()
	    	$(this).addClass('active').siblings().removeClass('active');
	    })
	})
	function showDetail(agentid){
		$('#showInfoModal').modal('show')
		$('#cacheUserid').val(agentid)
		DayData()
	}

	function DayData(){
		var agentid = $('#cacheUserid').val()
		var	_REQUEST = <?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value;?>

		startdate = _REQUEST.startdate
		enddate = _REQUEST.enddate
		$.ajax({
			url:'agentRebate.php',
			dataType:'',
			type:'POST',
			data:{
				agentid:agentid,
				startdate:startdate,
				enddate:enddate,
				method:'day'
			},
			success:function(data){
				data = jQuery.parseJSON(data)
				if(data == null) return false;
				result = '';
				for(var i=0;i<data.length;i++){
					result += '<tr><td>'+data[i].addtime+'</td><td>'+data[i].sumpaynum+'</td><td>'+data[i].onerebate+'</td><td>'+data[i].tworebate+'</td><td>'+data[i].threerebate+'</td><td>'+data[i].fourrebate+'</td><td>'+Math.round(data[i].sumfundmoney)+'</td></tr>';
				}
				$('#dayData').html(result)
			},
			error:function(err){

			}
		})
	}

	function MonthData(){
		var agentid = $('#cacheUserid').val()
		$.ajax({
			url:'agentRebate.php',
			dataType:'',
			type:'POST',
			data:{
				agentid:agentid,
				method:'month'
			},
			success:function(data){
				data = jQuery.parseJSON(data)
				if(data == null) return false;
				result = '';
				for(var i = 0;i < data.length;i++){
					result += '<tr><td>'+data[i].addtime+'</td><td>'+data[i].sumpaynum+'</td><td>'+data[i].onerebate+'</td><td>'+data[i].tworebate+'</td><td>'+data[i].threerebate+'</td><td>'+data[i].fourrebate+'</td><td>'+Math.round(data[i].sumfundmoney)+'</td></tr>';
				}
				$('#monthData ').html(result)
			},
			error:function(err){
				
			}
		})
	}

</script><?php }} ?>
