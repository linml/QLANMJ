<{include file ="ace/header.tpl"}> 
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div role="" class="form-inline">
	<form class="form-group" method="POST" action="">
	<select name="s_type" id="s_type" value="">
		<option value="1">玩家ID</option>
		<option value="2">玩家昵称</option>
		<option value="3">代理ID</option>
		<option value="4">代理昵称</option>
	</select>
	<input id="contains" type="text" name="contains" placeholder="请输入" value="">
	<select id="s_status" name="s_status" value="">
		<option value="" selected>状态</option>
		<option value="1">成功</option>
		<option value="2">失败</option>
		<option value="0">待支付</option>
	</select>
	<!-- <label class=" control-label no-padding-right">时间</label> -->
	<input type="text" id="startdate" value="<{$_REQUEST.startdate}>" name="startdate" placeholder="输入开始日期"> 
	<input type="text" id="enddate" value="<{$_REQUEST.enddate}>" name="enddate" placeholder="输入结束日期" >
	<button id="searchBtn" class="btn btn-info">查询</button>
	</div>
	</form>
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
						<th>玩家ID/昵称</th>
						<th>渠道</th>
						<th>充值金额</th>
						<th>充值状态</th>
						<th>代理ID/昵称</th>
						<th>订单号</th>
					</tr>
				</thead>
				<tbody>
					<{foreach $orderRecordList as $val}>
					<tr>
						<td><{$val.addtime}></td>
                        <td>(<{$val.userid}>)<{$val.nickname}></td>
                        <{if $val.paytype == 0}>
						<td>线下支付</td>
                        <{else if $val.paytype == 1}>
                        <td>微信</td>
                        <{else if $val.paytype == 2}>
                        <td>支付宝</td>
                        <{/if}>
						<td><{$val.rmb}></td>
						<td>
							<{if $val.status == 1}>
								<span class="green">成功</span>
							<{else if $val.status == 0}>
								<span class="">待支付</span>
							<{else if $val.status == 2}>
								<span class="red">失败</span>
							<{/if}>
						</td>
						<{if $val.agentid == 0}>
						<td>官方</td>
						<{else}>
						<td>(<{$val.buserid}>)<{$val.bnickname}></td>
						<{/if}>
						<td><{$val.id}></td>
					</tr>
					<{/foreach}>
				</tbody>
			</table>
			<!-- START 分页模板 -->
			<{$page_html}>
			<!-- END -->
		</div>
	</div>

	<!--操作的确认层，相当于javascript:confirm函数-->
	<{$osadmin_action_confirm}>

	<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
	<{include file="ace/footer.tpl" }>
	<script type="text/javascript">
		$(document).ready(function(){
 			var _REQUEST = <{$_REQUEST}>
 			// console.log(_REQUEST)
 			if(_REQUEST == null) return
			$('#contains').attr("value",_REQUEST.contains) 
			$('#s_type').find('option[value="'+_REQUEST.s_type+'"]').attr('selected','selected')
			$('#s_status').find('option[value="'+_REQUEST.s_status+'"]').attr('selected','selected')
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
			var s_type   = $('#s_type option:selected').val()
			var reg = /^[0-9]+.?[0-9]*$/;
			if(s_type != '2' && s_type != '4' && contains != '' && !reg.test(contains)){
				$('#contains').val('')
				alert('请输入有效ID')
				return 
			}
		})
		})
		
	</script>