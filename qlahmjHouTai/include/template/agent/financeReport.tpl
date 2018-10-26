<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->
<{$osadmin_action_alert}>
<div class="dvcontent">
			<div>
				<!--tab start-->
				<div class="tabs">
					<div class="hd">
						<div>
							<li class="on btn btn-info">财务月报</li>
							<li class="btn btn-info">财务年报</li>
						</div>
					</div>
					<div class="bd">
						<div style="display: block;">
								<div style="padding-top: 10px">
								<form action="" method="POST">
								<input type="text" name="month" id="month" value="<{$_REQUEST.month}>">
								<button type="submit" >查询</button>
								</form>
								</div>
								<!--分页显示角色信息 start-->
								<div id="dv1">
									<table class="table" id="tbRecord">
										<thead>
											<tr>
												<th>日期</th>
												<th>充值金额</th>
												<th>玩家返佣</th>
												<th>一层返佣</th>
												<th>二层返佣</th>
												<th>代理提现</th>
												<th>进钻金额</th>
												<th>售钻金额</th>
											</tr>
										</thead>
										<tbody>
											<{foreach $dayData as $val}>
											<tr>
												<td><{$val.addtime}></td>
												<td><{$val.sumcharge|string_format:'%.2f'}></td>
												<td><{$val.onerebate|string_format:'%.2f'}></td>
												<td><{$val.tworebate|string_format:'%.2f'}></td>
												<td><{$val.threerebate|string_format:'%.2f'}></td>
												<td><{$val.sumrmb|string_format:'%.2f'}></td>
												<td><{($val.sumatrmb+$val.sumoprmb)|string_format:'%.2f'}></td>
												<td><{$val.sumselldiamond|string_format:'%.2f'}></td>
											</tr>
											<{/foreach}>
										</tbody>
									</table>
								</div>
								<!-- <{$page_html_day}> -->
								<!--分页显示角色信息 end-->	
						</div>
						<div class="theme-popbod dform" style="display: none;">
								<div style="padding-top: 10px">
								<input type="text" name="year" id="year" value="<{$_REQUEST.year}>">
								<button onclick="searchYear()">查询</button>
								</div>
								<!--分页显示角色信息 start-->
								<div id="dv1">
									<table class="table" id="tbRecord">
										<thead>
											<tr>
												<th>日期</th>
												<th>充值金额</th>
												<th>玩家返佣</th>
												<th>一层返佣</th>
												<th>二层返佣</th>
												<th>代理提现</th>
												<th>进钻金额</th>
												<th>售钻金额</th>
											</tr>
										</thead>
										<tbody id="yearDT">
											<{foreach $monthData as $val}>
											<tr>
												<td><{$val.addtime}></td>
												<td><{$val.sumcharge|string_format:'%.2f'}></td>
												<td><{$val.onerebate|string_format:'%.2f'}></td>
												<td><{$val.tworebate|string_format:'%.2f'}></td>
												<td><{$val.threerebate|string_format:'%.2f'}></td>
												<td><{$val.sumrmb|string_format:'%.2f'}></td>
												<td><{($val.sumatrmb+$val.sumoprmb)|string_format:'%.2f'}></td>
												<td><{$val.sumselldiamond|string_format:'%.2f'}></td>
											</tr>
											<{/foreach}>
										</tbody>
									</table>
								</div>
								<!-- <{$page_html_month}> -->
								<!--分页显示角色信息 end-->
						</div>
						</div>
					</div>
					<!--tab end-->

				</div>
<script src="<{$smarty.const.ADMIN_URL}>/assets/js/jquery.SuperSlide.source.js"></script>
<script>
$(function() {
	$(".tabs").slide({ trigger: "click" });
	});
</script>
</div>
<script src="<{$smarty.const.ADMIN_URL}>/assets/lib/laydate/laydate.js"></script>
<script type="text/javascript">
	//年月选择器
    laydate.render({
      elem: '#month'
      ,type: 'month'
    });
    //年月选择器
    laydate.render({
      elem: '#year'
      ,type: 'year'
    });
</script>
<script type="text/javascript">

	function searchYear(){
		var year = $('#year').val()
		$.ajax({
		url:'financeReport.php',
		dataType:'',
		type:'POST',
		data:{
			method:'yearsearch',
			year:year
		},
		success:function(data){
			data = jQuery.parseJSON(data)
			htm = '';
			for(var i=0;i<data.length;i++){
				if(data[i].sumcharge == null) sumcharge = '0.00';
				if(data[i].onerebate == null) onerebate = '0.00';
				if(data[i].tworebate == null) tworebate = '0.00';
				if(data[i].threerebate == null) threerebate = '0.00';
				if(data[i].sumrmb == null) sumrmb = '0.00';
				if(data[i].sumindiamond == null) sumindiamond = '0.00';
				if(data[i].sumselldiamond == null) sumselldiamond = '0.00';
				htm += '<tr><td>'+data[i].addtime+'</td><td>'+sumcharge+'</td><td>'+onerebate+'</td><td>'+tworebate+'</td><td>'+threerebate+'</td><td>'+sumrmb+'</td><td>'+sumindiamond+'</td><td>'+sumselldiamond+'</td></tr>' 
			}
			$('#yearDT').html(htm)
		},
		error:function(err){

		}
		})
	}
	
</script>

	<!--操作的确认层，相当于javascript:confirm函数-->
	<{$osadmin_action_confirm}>

	<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
	<{include file="ace/footer.tpl" }>