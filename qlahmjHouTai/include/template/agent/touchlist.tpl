<{include file ="ace/header.tpl"}> <{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!--- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
			<form action="" method="GET" class="form-horizontal" role="form">

				<div class="form-group">
					<label class="col-sm-3 control-label no-padding-right">代理商玩家UID</label>
					<div class="col-sm-9">
						<input type="text" name="agent_uid"  id="agent_uid"
							value="<{$_REQUEST.agent_uid}>" placeholder="输入代理商玩家UID">
						<input type="hidden" name="search" value="1">
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-offset-3 col-md-9">
						<button class="btn btn-info" type="submit">检索</button>
					</div>
				</div>
				<div style="clear: both;"></div>
			</form>
		</div>
	</div>
</div>


<div class="row">
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">提现记录</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>伯乐UID</th>
						<th>开始时间</th>
						<th>结束时间</th>
						<th>伯乐业绩</th>
						<th>代理商UIDSS</th>
						<th>代理商收益</th>
						<th>伯乐提成比例</th>
						<th>伯乐提成金额（元）</th>
						<th>计算时间</th>
						<th>状态</th>
						<th>备注</th>
						<th>操作</th>

					</tr>
				</thead>
				<tbody>
					<{foreach name=earnings from=$earnings_infos item=earnings_info}>
					<tr>
						<td><{$earnings_info.touch_uid}></td>
						<td><{$earnings_info.begindate}></td>
						<td><{$earnings_info.enddate}></td>
						<td><{$earnings_info.touch_earnings/100.00}></td>
						<td><{$earnings_info.agent_uid}></td>
						<td><{$earnings_info.agent_earnings/100.00}></td>

						<td><{$earnings_info.touch}></td>

						<td>提成金额：
							<{number_format($earnings_info.agent_earnings*$earnings_info.touch/10000.00,
							2, '.', '')}> 
							<br /> 姓名: <{$earnings_info.name}>
							<br /> 银行卡号: <{$earnings_info.card_number}>
							<br /> 身份证号: <{$earnings_info.id_number}>
							<br /> 手机号: <{$earnings_info.phone_number}>
							<br />
						</td>

						<td><{$earnings_info.create_time}></td>



						<!-- 体现状态：0，未提现，1审核通过，2，拒绝体现，3,已提现，4申请提现 -->
						<{if $earnings_info.status==0}>
						<td>未提现</td> <{else if $earnings_info.status==1}>
						<td>审核通过</td> <{else if $earnings_info.status==2}>
						<td>申请拒绝</td> <{else if $earnings_info.status==3}>
						<td>已提现</td> <{else if $earnings_info.status==4}>
						<td>申请提现</td> <{/if}>
						<td><{$earnings_info.note}></td>

						<td><{if $earnings_info.status==0}> <{else if
							$earnings_info.status==1}> <{else if $earnings_info.status==2}>

							<{else if $earnings_info.status==3}> <{else if
							$earnings_info.status==4}> <a
							href="touchlist.php?method=check&id=<{$earnings_info.id}>"
							title="通过"><i class="icon-check"></i>通过</a> <a
							href="javascript:void(0);"
							onclick="drawreject(<{$earnings_info.id}>)" title="拒绝"><i
								class="icon-remove"></i>拒绝</a> <{else}> <{/if}>
						</td>
					</tr>
					<{/foreach}>
				</tbody>
			</table>
			<!--- START 分页模板 --->
			<{$page_html}>
			<!--- END --->
		</div>
	</div>

	<div class="modal fade" id="wmyModal" tabindex="-1" role="dialog"
		aria-labelledby="myModalLabel" aria-hidden="true">
		<input type="hidden" id="out_trade_no" name="out_trade_no" value="" />
		<div class="modal-dialog" style="width: 330px;">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal"
						aria-hidden="true">&times;</button>
					<h4 class="modal-title" id="myModalLabel">拒绝体现</h4>
				</div>
				<div class="modal-body">
					<h4 class="modal-title" id="myModalLabel">拒绝原因</h4>


					<input type="text" id="reason" name="reason" />
				</div>
				<div class="modal-footer">
					<button type="button" class="btn btn-default" data-dismiss="modal">关闭
					</button>
					<button type="button" id="sub" class="btn btn-primary">确认
					</button>
				</div>
			</div>
			<!-- /.modal-content -->
		</div>
		<!-- /.modal -->
	</div>

	<!---操作的确认层，相当于javascript:confirm函数--->
	<{$osadmin_action_confirm}>

	<!--- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 --->
	<{include file="ace/footer.tpl" }>
	<script type="text/javascript">
	function drawreject(drawid)
	{
		$("#out_trade_no").attr("value", drawid);
		$("#wmyModal").modal(
		'show');
		

	}
	
	function reject()
	{
		var out_trade_no = $("#out_trade_no").attr("value");
		var reason = $("#reason").val();
		var param = {
				method : 'reject',
				id:out_trade_no,
				note:reason
			};
		$.post('touchlist.php',
				param,
				function(res) {
					if (typeof (res) === 'string') {
						res = JSON
								.parse(res);
					}
					
					if(res.status==1)
						{
						$("#wmyModal").modal(
						'hide');
						alert("拒绝成功");
						location.href="touchlist.php";
						}
							
	});
	}
	
	$(document).ready(function(){
		$('#sub').on("click",function () {
			
			var reason = $("#reason").val();
			
			if(reason.trim()=="")
				{
				alert("拒绝原因不能为空");
				return;
				}
			
			
			reject();
		}				);
	});
	
	
	
	
	</script>
	<script type="text/javascript">
	$("#agent_uid").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");
	
	</script>