<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div role="" class="form-inline">
	<form class="form-group" method="POST" action="">
	<label>玩家ID:</label>
	<input id="ownerid" type="text" name="ownerid" placeholder="请输入" value="<{$_REQUEST.ownerid}>">
	<label>房间号:</label>
	<input id="tableid" type="text" name="tableid" placeholder="请输入" value="<{$_REQUEST.tableid}>">
	<label>游戏</label>
	<select id="game" name="game" value="">
		<option value="" selected>游戏名</option>
		<{foreach $gameInfo as $val}>
		<option value="<{$val.gameid}>"><{$val.gamename}></option>
		<{/foreach}>
	</select>
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
				<span>开房记录</span>
				<span title="点我下载文档,只能下载你当前看到的！比方说,你查了2页数据，最后下载出来只有第一页！懂我的打个铁！"><a href="openRecord.php?method=download&startdate=<{$_REQUEST.startdate}>&enddate=<{$_REQUEST.enddate}>&ownerid=<{$_REQUEST.ownerid}>&tableid=<{$_REQUEST.tableid}>&game=<{$_REQUEST.game}>" class="white">下载文档</a></span>
			</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>游戏</th>
						<th>方式</th>
						<th>房间号</th>
						<th>付费方式</th>
						<th>扣费</th>
						<th>玩法</th>
						<th>玩家</th>
						<th>战绩</th>
						<th>创建时间</th>
					</tr>
				</thead>
				<tbody>
					<{foreach $gameRoomList as $val}>
					<tr>
                        <td><{$val.gamename}></td>
                        <{if $val.groupid == NULL}>
                        <td>组局</td>
                        <{else}>
                        <td>亲友圈</td>
                        <{/if}>
                        <td title="点我显示详情" style="cursor: pointer;" onclick="showDetail(<{$val.setid}>)"><{$val.tableid}></td>
                     
                        <{if $val.RoomCostType == 1}>
                        <td>AA</td>
                        <{else if $val.RoomCostType == 2 }>
                        <td>房主</td>
                        <{else if $val.RoomCostType == 3 }>
                        <td>圈主</td>
                        <{else}>
                        <td>暂无</td>
                        <{/if}>
                        <td><{$val.RoomCost}></td>
                        <td><{$val.mark}></td>
                        <td>(<{$val.ownerid}>)<{$val.nickname}></td>
                        <td><{$val.moneynum}></td>
                        <td><{$val.addtime}></td>
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
	<script type="text/javascript">
	$("#ownerid").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");

	$("#tableid").keyup(function() {
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

	$(document).ready(function(){
		var myDate = new Date();
		//获取当前年
		var year=myDate.getFullYear();
		//获取当前月
		var month=myDate.getMonth()+1;
		//获取当前日
		var day=myDate.getDate();
		if(month<10) month = '0'+month;
		if(day<10) day = '0'+day;
		TodayTime = year +'-'+ month + '-'+ day
		
		var _REQUEST = <{$_REQUEST}>
 		if(_REQUEST == null) return		
		$('#ownerid').val(_REQUEST.ownerid)
		$('#tableid').val(_REQUEST.tableid)
		$('#game').find('option[value="'+_REQUEST.game+'"]').attr('selected','selected')
		$('#startdate').val(_REQUEST.startdate)
		$('#enddate').val(_REQUEST.enddate)
	})
	</script>



<script type="text/javascript">
	function showDetail(setid){
		$("#RoomDetail").modal('show');
		$.ajax({
			url:'openRecord.php',
			type:'POST',
			dataType:"",
			data:{
				method:'showDetail',
				setid:setid
			},
			success:function(data){
				data = jQuery.parseJSON(data)
				result = '';
				for(var i=0;i<data.length;i++){
					result += '<tr><td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+data[i].moneynum+'</td></tr>'
				}
				$('#gamerList').html(result)
			},
			error:function(err){

			}
		})
	}
</script>
