<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>
<div class="row">
	<div class="col-xs-12">
	<ul class="nav nav-pills" id="tabBtn">
		<li class="active" method="getRechargeDiamondRecod"><a href="diamondRecord.php?method=getRechargeDiamondRecod&index=1">充钻记录</a></li>
		<li class="" method="getAgentTransferRecord"><a href="diamondRecord.php?method=getAgentTransferRecord&index=2">代理划拨</a></li>
		<li class="" method="buyDiamondRecord"><a href="diamondRecord.php?method=buyDiamondRecord&index=3">进钻记录</a></li>
		<li class="" method="systemTransfer"><a href="diamondRecord.php?method=systemTransfer&index=4">系统划拨</a></li>
		<li class="" method="systemSendAndSold"><a href="diamondRecord.php?method=systemSendAndSold&index=5">售钻/赠送</a></li>
	</ul>
	</div>
</div>	

<div class="row">
	<div role="" class="form-inline">
		<form class="form-group" method="POST" action="">
			<select name="type" id="type" value="">
			</select>
			<input id="contains" type="text" name="contains" placeholder="请输入" value="">
			<input type="text" id="startdate" value="<{$_REQUEST.startdate}>" name="startdate" placeholder="输入开始日期"> 
			<input type="text" id="enddate" value="<{$_REQUEST.enddate}>" name="enddate" placeholder="输入结束日期" >
			<!-- <input id="hideFlag" type="hidden" name="flag" value="2"> -->
			<input id="hideMethod" type="hidden" name="method" value="">
			<input type="hidden" name="index" value="<{$index}>">
			<button id="searchBtn" class="btn btn-info">查询</button>
		</form>
	</div>
</div>

<div class="row">
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">钻石记录</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover" id="tabContain">
				<thead id="title">
				</thead>
				<tbody id="contain">
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
	$("#fromuid").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");

	$("#touid").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");
	
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

<script type="text/javascript">
	$(function(){
		var page_no = <{$page_no}>
		var method = <{$method}>
		var _REQUEST = <{$_REQUEST}>
		$('#hideMethod').val(method)
		var index = <{$index}>
		var type = _REQUEST.type
		var contains = _REQUEST.contains
		var startdate = _REQUEST.startdate
		var enddate = _REQUEST.enddate
		if(index)
			$('#tabBtn li').eq(index-1).addClass('active').siblings().removeClass('active');
		callback(method)
		function callback(method){
			if(method == '' ) method = 'getRechargeDiamondRecod'			
			if(method == 'getRechargeDiamondRecod'){
				title = '<tr><td>流水号</td><td>时间</td><td>玩家ID/昵称</td><td>充值数量</td><td>当前钻石</td><td>充值人</td><td>状态</td></tr>';
				options = '<option id="u1" value="1">玩家ID</option><option id="u2" value="2">玩家昵称</option><option id="u3" value="3">代理ID</option><option id="u4" value="4">代理昵称</option>';
			}else if(method == 'getAgentTransferRecord'){
				title = '<tr><td>流水号</td><td>时间</td><td>代理ID/昵称</td><td>充值数量</td><td>当前钻石</td><td>充值人</td><td>状态</td></tr>';
				options = '<option id="u1" value="1">玩家ID</option><option id="u2" value="2">玩家昵称</option><option id="u3" value="3">代理ID</option><option id="u4" value="4">代理昵称</option>';
			}else if(method == 'buyDiamondRecord'){
				title = '<tr><td>流水号</td><td>时间</td><td>代理ID/昵称</td><td>级别</td><td>支付方式</td><td>进钻金额</td><td>钻石数量</td><td>状态</td></tr>';
				options = '<option id="u3" value="3">代理ID</option><option id="u4" value="4">代理昵称</option>';
			}else if(method == 'systemTransfer'){
				title = '<tr><td>流水号</td><td>时间</td><td>代理ID/昵称</td><td>方式</td><td>级别</td><td>进钻金额</td><td>钻石数量</td><td>管理员</td></tr>';
				options = '<option id="u3" value="3">代理ID</option><option id="u4" value="4">代理昵称</option>';
			}else if(method == 'systemSendAndSold'){
				title = '<tr><td>流水号</td><td>时间</td><td>玩家ID/昵称</td><td>方式</td><td>进钻金额</td><td>钻石数量</td><td>管理员</td></tr>';
				options = '<option id="u1" value="1">玩家ID</option><option id="u2" value="2">玩家昵称</option>';
			}else{
				return
			}
			$.ajax({
				url:'diamondRecord.php',
				dataType:"",
				type:'POST',
				data:{
					method:method,
					page_no:page_no,
					flag:2,
					type:type,
					contains:contains,
					startdate:startdate,
					enddate:enddate,
					index:index
				},
				success:function(data){
					data = jQuery.parseJSON(data)
					$('#title').html(title)
					$('#type').html(options)
					contain = '';
						if(method == 'getRechargeDiamondRecod'){
							for(var i=0;i<data.length;i++){
								if(data[i].status == 0){
									status = '初始'
								}else if(data[i].status == 1){
									status = '成功'
								}else if(data[i].status == 2){
									status = '失败'
								}else{
									status = '未知状态'
								}
								nowMoney = parseInt(data[i].agomoney)+parseInt(data[i].fundmoney)
								contain += '<tr><td>'+data[i].relationid+'</td><td>'+data[i].addtime+'</td><td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+Math.round(data[i].fundmoney)+'</td><td>'+nowMoney+'</td><td>('+data[i].buserid+')'+data[i].bnickname+'</td><td>'+status+'</td></tr>';
							}
						}else if(method == 'getAgentTransferRecord'){
							for(var i=0;i<data.length;i++){
								if(data[i].status == 0){
									status = '初始'
								}else if(data[i].status == 1){
									status = '成功'
								}else if(data[i].status == 2){
									status = '失败'
								}else{
									status = '未知状态'
								}
								nowMoney = parseInt(data[i].agomoney)+parseInt(data[i].fundmoney)
								contain += '<tr><td>'+data[i].relationid+'</td><td>'+data[i].addtime+'</td><td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+Math.round(data[i].fundmoney)+'</td><td>'+nowMoney+'</td><td>('+data[i].cuserid+')'+data[i].cnickname+'</td><td>'+status+'</td></tr>';
							}
						}else if(method == 'buyDiamondRecord'){
							for(var i=0;i<data.length;i++){
								if(data[i].status == 0){
									status = '初始'
								}else if(data[i].status == 1){
									status = '成功'
								}else if(data[i].status == 2){
									status = '失败'
								}else{
									status = '未知状态'
								}

								if(data[i].paytype == 0){
									paytype = '线下'
								}else if(data[i].paytype == 1){
									paytype = '微信'
								}else if(data[i].paytype == 2){
									paytype = '支付宝'
								}else{
									paytype = '余额'
								}

								contain += '<tr><td>'+data[i].relationid+'</td><td>'+data[i].addtime+'</td><td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+data[i].name+'</td><td>'+paytype+'</td><td>'+data[i].rmb+'</td><td>'+Math.round(data[i].fundmoney)+'</td><td>'+status+'</td></tr>';
							}
						}else if(method == 'systemTransfer'){
							for(var i=0;i<data.length;i++){
								if(data[i].transfertype == '2'){
									transfertype = '系统售钻'
								}else if(data[i].transfertype == '4'){
									transfertype = '系统赠送'
								}else{
									transfertype = ''
								}
								contain += '<tr><td>'+data[i].id+'</td><td>'+data[i].addtime+'</td><td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+transfertype+'</td><td>'+data[i].name+'</td><td>'+data[i].rmb+'</td><td>'+Math.round(data[i].fundmoney)+'</td><td>'+data[i].adminrealname+'</td></tr>';
							}
						}else if(method == 'systemSendAndSold'){
							for(var i=0;i<data.length;i++){
								if(data[i].transfertype == '1'){
									transfertype = '系统售钻'
								}else if(data[i].transfertype == '3'){
									transfertype = '系统赠送'
								}else{
									transfertype = ''
								}
								contain += '<tr><td>'+data[i].id+'</td><td>'+data[i].addtime+'</td><td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+transfertype+'</td><td>'+data[i].rmb+'</td><td>'+Math.round(data[i].fundmoney)+'</td><td>'+data[i].adminrealname+'</td></tr>';
							}
						}else{
							return
						}
					$('#contain').html(contain)
				},
				error:function(err){

				}
			})
		}
		
	})


</script>

<script type="text/javascript">
	var _REQUEST = <{$_REQUEST}>
	$('#type').find('option[value="'+_REQUEST.type+'"]').attr('selected','selected')
	$('#contains').val(_REQUEST.contains)
	$('#startdate').val(_REQUEST.startdate)
	$('#enddate').val(_REQUEST.enddate)
</script>
