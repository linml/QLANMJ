<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>
<div class="row">
	<div class="col-xs-12">
	<ul class="nav nav-pills" id="tabBtn">
		<li class="active" method="day"><a href="jushuRecord.php?method=day&index=1">局数日报</a></li>
		<li class="" method="month"><a href="jushuRecord.php?method=month&index=2">局数月报</a></li>
	</ul>
	</div>
</div>

<div class="row">
	<div role="" class="form-inline">
		<form class="form-group" method="POST" action="" id="dataForm">
			<input type="text" name="monthtime" id="monthTime">
			<select id="yearTime" name="yeartime">
				<option value="2018"> &nbsp; &nbsp; 2018 年 &nbsp;&nbsp;  </option>
				<option value="2019"> &nbsp; &nbsp; 2019 年 &nbsp;&nbsp;  </option>
				<option value="2020"> &nbsp; &nbsp; 2020 年 &nbsp;&nbsp;  </option>
				<option value="2021"> &nbsp; &nbsp; 2021 年 &nbsp;&nbsp;  </option>
			</select>
			<select id="type" name="type">
				<option value="">全部</option>
				<option value="1">组局</option>
				<option value="2">亲友圈</option>
			</select>
			<input id="hideMethod" type="hidden" name="method" value="">
			<input id="index" type="hidden" name="index" value=<{$index}>>
			<button id="searchBtn" class="btn btn-info">查询</button>
		</form>
	</div>
</div>

<div class="row">
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">局数报表</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover" id="tabContain">
				<thead id="title">
					<tr>
						<td>日期</td>
						<td>房间数<br>总耗钻</td>
						<td>快乐比鸡<br>耗钻</td>
						<td>霍邱麻将<br>耗钻</td>
						<td>临泉麻将<br>耗钻</td>
					</tr>
				</thead>
				<tbody id="contain">
				</tbody>
			</table>
			<!-- START 分页模板 -->
			<!-- <{$page_html}> -->
			<!-- END -->
		</div>
	</div>

	<!--操作的确认层，相当于javascript:confirm函数-->
	<{$osadmin_action_confirm}>

	<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
	<{include file="ace/footer.tpl" }>
	<script type="text/javascript">
	$(function() {
	var date=$( "#monthTime" );
	date.datepicker({ dateFormat: "yy-mm" });
	// date.datepicker( "option", "firstDay", 1 );
	monthtime = $('#monthTime').val()
		

	});
	</script>

<script type="text/javascript">
	$(function(){
		var page_no = <{$page_no}>
		var method = <{$method}>
		var _REQUEST = <{$_REQUEST}>
		$('#hideMethod').val(method)
		var index = <{$index}>
		// index = $('#index').val()
		console.log(index)
		var yeartime = <{$yeartime}>
		var monthtime = <{$monthtime}>
		var type = _REQUEST.type
		$('#type').find('option[value="'+_REQUEST.type+'"]').attr('selected','selected')
		$('#monthTime').val(monthtime)
		$('#yearTime').find('option[value="'+yeartime+'"]').attr('selected','selected')
		if(index)
			$('#tabBtn li').eq(index-1).addClass('active').siblings().removeClass('active');
		callback(method)
		function callback(method){
			if(method == '' ) method = 'day'			
			if(method == 'day'){
				time = $('#monthTime').val()
				$('#yearTime').hide()
			}else if(method == 'month'){
				time = $('#yearTime option:selected').val()
				$('#monthTime').css('display','none')
				$('#yearTime').show()
			}else{
				return
			}
			$.ajax({
				url:'jushuRecord.php',
				dataType:"",
				type:'POST',
				data:{
					method:method,
					page_no:page_no,
					flag:2,
					type:type,
					time:time,
					index:index
				},
				success:function(data){
					data = jQuery.parseJSON(data)
					contain = '';
						if(method == 'day'){
							for(var i=0;i<data.length;i++){
								contain += '<tr><td>'+data[i].addtime+'</td><td><span style="color:red">'+data[i].counttable+'</span><br>'+data[i].sumroomcost+'</td><td><span style="color:red">'+data[i].counttableBJ+'</span><br>'+data[i].sumroomcostBJ+'</td><td><span style="color:red">'+data[i].counttableHQ+'</span><br>'+data[i].sumroomcostHQ+'</td><td><span style="color:red">'+data[i].counttableLQ+'</span><br>'+data[i].sumroomcostLQ+'</td></tr>'
							}
						}else if(method == 'month'){
							for(var i=0;i<data.length;i++){	
								contain += '<tr><td>'+data[i].addtime+'</td><td><span style="color:red">'+data[i].counttable+'</span><br>'+data[i].sumroomcost+'</td><td><span style="color:red">'+data[i].counttableBJ+'</span><br>'+data[i].sumroomcostBJ+'</td><td><span style="color:red">'+data[i].counttableHQ+'</span><br>'+data[i].sumroomcostHQ+'</td><td><span style="color:red">'+data[i].counttableLQ+'</span><br>'+data[i].sumroomcostLQ+'</td></tr>';
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
	// console.log(_REQUEST.time.substring(0,4))
	$('#type').find('option[value="'+_REQUEST.type+'"]').attr('selected','selected')
	// $('#yearTime').find('option[value="'+_REQUEST.time.substring(0,4)+'"]').attr('selected','selected')
	// $('#time').val(_REQUEST.time)
</script>
