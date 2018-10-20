<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!--- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>
<style>
.ui-datepicker td>a, .ui-datepicker td>span {
	min-width: auto;
}
</style>
<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">开始日期</label>
				<div class="col-sm-9">
					<input type="text" id="st"  name="st" value="<{$_REQUEST.st}>" placeholder="输入开始日期"   required="true"   > 
					
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">结束日期</label>
				<div class="col-sm-9">
					<input type="text" id="et"  name="et" value="<{$_REQUEST.et}>" placeholder="输入结束日期"  required="true" > 
					<input type="hidden" name="search" value="1" >
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
		<table id="simple-table" class="table table-striped table-bordered table-hover">
  			<thead>
  				<tr>
					<th style="font-size: 16px;">充值总额：<{$summary_data['totalpayment']/100}>元</th>
					<th style="font-size: 16px;">充值总人数：<{$summary_data['usercount']}></th>
					<th style="font-size: 16px;">平均付费用户收入：<{$summary_data['arppu']/100}>元</th>
				</tr>
				<tr>
					<th style="font-size: 16px;">代理提成总额：<{$summary_data['totalagentprofit']/100}>元，占比<{$summary_data['agentproportion']}>%</th>
					<th style="font-size: 16px;">订单总数：<{$summary_data['ordercount']}></th>
					<th style="font-size: 16px;">平均每单收入：<{$summary_data['payperorder']/100}>元</th>
				</tr>
  			</thead>
  		</table>
		<div class="table-header">充值统计列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					
					<th>统计日期</th>
					<th>充值总额（元）</th>
					<th>充值人数</th>
					<th>充值次数</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$agents item=agent}>
				<tr>
					
					<td><{$agent.dt}></td>
					<td><{$agent.payment/100.00}></td>
					<td><{$agent.usercount}></td>	
					<td><{$agent.ordercount}></td>				
				</tr>
				<{/foreach}>
			</tbody>
		</table>
		<!--- START 分页模板 --->
        <{$page_html}>
		<!--- END --->
	</div>
</div>

<!---操作的确认层，相当于javascript:confirm函数--->
<{$osadmin_action_confirm}>

<!--- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 --->
<{include file="ace/footer.tpl" }>

<script>
$(function() {
	var date=$( "#st" );
	date.datepicker({ dateFormat: "yy-mm-dd" });
	date.datepicker( "option", "firstDay", 1 );
});
$(function() {
	var date=$( "#et" );
	date.datepicker({ dateFormat: "yy-mm-dd" });
	date.datepicker( "option", "firstDay", 1 );
});
</script>