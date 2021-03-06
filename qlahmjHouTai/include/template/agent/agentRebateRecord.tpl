<{include file ="ace/header.tpl"}> 
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div role="" class="form-inline">
	<form class="form-group" method="POST" action="">
	<select name="type" id="type" value="">
		<option value="1">代理ID</option>
		<option value="2">代理昵称</option>
		<option value="3">上级代理ID</option>
	</select>
	<input id="contains" type="text" name="contains" placeholder="请输入" value="">
	
	<input type="text" id="startdate" value="<{$_REQUEST1.startdate}>" name="startdate" placeholder="输入开始日期"> 
	<input type="text" id="enddate" value="<{$_REQUEST1.enddate}>" name="enddate" placeholder="输入结束日期" >
	<select id="user_id" name="user_id">
		<option value="">管理员</option>
		<{foreach $admin as $val}>
		<option value="<{$val.user_id}>"><{$val.real_name}></option>
		<{/foreach}>
	</select>
	<button id="searchBtn" class="btn btn-info" type="submit">查询</button>
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
						<th>充值数量</th>
						<th>操作</th>
						<th>管理员</th>
					</tr>
				</thead>
				<tbody>
					<{foreach $rebateList as $val}>
					<tr>
						<td>(<{$val.userid}>)<{$val.nickname}></td>
						<td>(<{$val.upuserid}>)<{$val.upnickname}></td>
						<td><{$val.name}></td>
						<td><{$val.sumpaynum}></td>
						<td><{$val.onerebate}></td>
						<td><{$val.tworebate}></td>
						<td><{$val.threerebate}></td>
						<td><{$val.sumfundmoney|round}></td>
						<td>
							<button onclick="showDetail(<{$val.agentid}>)">收入报表</button>
						</td>
						<td><{$val.adminname}></td>
					</tr>
					<{/foreach}>
				</tbody>
			</table>
			<!-- START 分页模板 -->
			<{$page_html}>
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
	<{$osadmin_action_confirm}>

	<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
	<{include file="ace/footer.tpl" }>
<script type="text/javascript">

	$(document).ready(function(){
			var _REQUEST = <{$_REQUEST}>
			if(_REQUEST == null) return
		$('#contains').attr("value",_REQUEST.contains) 
		$('#type').find('option[value="'+_REQUEST.type+'"]').attr('selected','selected')
		$('#user_id').find('option[value="'+_REQUEST.user_id+'"]').attr('selected','selected')

		var myDate = new Date();
		//获取当前年
		var year=myDate.getFullYear();
		//获取当前月
		var month=myDate.getMonth()+1;
		//获取当前日
		var date=myDate.getDate(); 
		if(month<10) month = '0' + month
		if(date<10) date = '0' + date
		if($('#startdate').val() == '' || $('#enddate').val() == ''){
			$('#startdate').attr("value",year+'-'+month+'-'+'01')
			$('#enddate').attr("value",year+'-'+month+'-'+date)
		}
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
		// var	_REQUEST = <{$_REQUEST}>
		// startdate = _REQUEST.startdate
		// enddate = _REQUEST.enddate
		startdate = $('#startdate').val()
		enddate = $('#enddate').val()
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
					result += '<tr><td>'+data[i].addtime+'</td><td>'+data[i].sumpaynum+'</td><td>'+data[i].onerebate+'</td><td>'+data[i].tworebate+'</td><td>'+data[i].threerebate+'</td><td>'+Math.round(data[i].sumfundmoney)+'</td></tr>';
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
					result += '<tr><td>'+data[i].addtime+'</td><td>'+data[i].sumpaynum+'</td><td>'+data[i].onerebate+'</td><td>'+data[i].tworebate+'</td><td>'+data[i].threerebate+'</td><td>'+Math.round(data[i].sumfundmoney)+'</td></tr>';
				}
				$('#monthData ').html(result)
			},
			error:function(err){
				
			}
		})
	}

</script>