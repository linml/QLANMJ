<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div role="" class="form-inline">
	<form class="form-group" method="POST" action="">
	<select name="type" id="type" value="">
		<option value="1">玩家ID</option>
		<option value="2">玩家昵称</option>
		<option value="3">代理ID</option>
		<option value="4">代理昵称</option>
	</select>
	<input id="contain" type="text" name="contain" placeholder="请输入" value="<{$_REQUEST.contain}>">
	<label>福利类型:</label>
	<select id="welfareType" name="welfareType" value="">
		<option value="" selected>福利类型</option>
		<{foreach $welfare as $val}>
		<option value="<{$val.activityid}>"><{$val.activityname}></option>
		<{/foreach}>
	</select>
	<label>查询时间:</label>
	<input type="text" id="startdate" value="<{$_REQUEST.startdate}>" name="startdate" placeholder="输入开始日期"> 
	<input type="text" id="enddate" value="<{$_REQUEST.enddate}>" name="enddate" placeholder="输入结束日期" >
	<button id="searchBtn" class="btn btn-info">查询</button>
	</div>
	</form>
</div>

<div class="row">
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">
				<span>福利记录</span>
			</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>时间</th>
						<th>玩家ID/昵称</th>
						<th>福利类型</th>
						<th>奖励方式</th>
					</tr>
				</thead>
				<tbody>
					<{foreach $welfareData as $val}>
					<tr>
						<td><{$val.addtime}></td>
						<td>(<{$val.userid}>)<{$val.nickname}></td>
						<td><{$val.activityname}></td>
						<td><{$val.activitymark}></td>
					</tr>
					<{/foreach}>
				</tbody>
			</table>
			<!-- START 分页模板 -->
			<{$page_html}>
			<!-- END -->
		</div>
	</div>
<div class="modal fade" id="RoomDetail" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="myModalLabel">玩家战绩</h4>
			</div>
			<div class="modal-body">
			<table id="simple-" class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>玩家</th>
						<th>战绩</th>
					</tr>
				</thead>
				<tbody id="gamerList">
					
				</tbody>
			</table>
		</div>
		<!-- /.modal-content -->
		</div>
	<!-- /.modal -->
</div>
	<!--操作的确认层，相当于javascript:confirm函数-->
	<{$osadmin_action_confirm}>

	<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
	<{include file="ace/footer.tpl" }>
<script src="<{$smarty.const.ADMIN_URL}>/assets/lib/laydate/laydate.js"></script>
<script type="text/javascript">
	//年月选择器
    laydate.render({
      elem: '#startdate'
      ,type: 'date'
    });
    //年月选择器
    laydate.render({
      elem: '#enddate'
      ,type: 'date'
    });

    $(function(){
    	var _REQUEST1 = <{$_REQUEST1}>
    	$('#type').find('option[value='+_REQUEST1.type+']').attr('selected','selected')
    	$('#welfareType').find('option[value='+_REQUEST1.welfareType+']').attr('selected','selected')
    })
</script>