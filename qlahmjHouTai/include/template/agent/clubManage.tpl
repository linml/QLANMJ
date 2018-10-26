<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<div id="search" class="">
		<form action="" method="POST" class="form-inline" role="form">		
			<div class="form-group">
					<select name="id" id='id' value="">
						<option value="fi.userid">代理ID</option>
						<option value="fi.friendid">亲友圈ID</option>
					</select>
			</div>
			<input type="text" id="contains" name="contains" value="" placeholder="请输入">
			<div class="form-group">
					<select name="order" id='order' value="">
						<option value="">默认排序</option>
						<option value="asc">按成员排序(升序)</option>
						<option value="desc">按成员排序(降序)</option>
					</select>
			</div>
			<button class="btn btn-info" type="submit" id="search_reuslt">检索</button>			
			<div style="clear:both;"></div>
		</form>
		</div>
	</div>
</div>
<div class="row">
	<div class="row">
	<div class="col-xs-12">
		<div class="table-header">俱乐部管理</div>
		<table id="simple-table"
			class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>创建时间</th>
					<th>代理ID/昵称</th>
					<th>亲友圈ID/名称</th>
					<th>玩法</th>
					<th>赛事</th>
					<th>成员</th>
					<th>管理</th>
				</tr>
			</thead>
			<tbody>
				<{foreach $clubdata as $val}>
				<tr>
                    <td><{$val.addtime}></td>
                    <td>(<{$val.userid}>)<{$val.nickname}></td>
                    <td>(<{$val.friendid}>)<{$val.friendname}></td>
                    <td><{$val.ruledesc}></td>
                    <!-- <td><a href=""><img src="/assets/images/agent/details.svg" width="20" height="20"></a></td> -->
                    <td>赛事</td>
                    <td><{$val.members}></td>
                    <td>
                    	<button title="有标识的是管理员" onclick="showClubMember(<{$val.friendid}>)">成员</button>
                    	<button title="玩家战绩" onclick="showClubData(<{$val.friendid}>)">数据</button>
                    	<button onclick="Disband(<{$val.friendid}>)"><i class="icon-trash bigger-120"> </i>解散</button>
                    </td>
                    
				</tr>
				<{/foreach}>
			</tbody>
		</table>
	</div>
	</div>
</div>

<div class="modal fade" id="showInfo" tabindex="-2" role="dialog"
	aria-labelledby="" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="clubHead">亲友圈成员列表</h4>
			</div>
			<div class="modal-body">
			<table id="simple-" class="table table-striped table-bordered table-hover">
				<thead id="title">
					
				</thead>
				<tbody id="contain">
					
				</tbody>
			</table>
			</div>
		<!-- /.modal-content -->
		</div>
	<!-- /.modal -->
	</div>
</div>
<!-- START 分页模板 -->
<{$page_html}>
<!-- END -->
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

$(document).ready(function(){
	var _REQUEST = <{$_REQUEST}>
	$('#id option[value="'+_REQUEST.id+'"]').attr('selected','selected')
	$('#order option[value="'+_REQUEST.order+'"]').attr('selected','selected')
	$('#contains').attr('value',_REQUEST.contains)
})
</script>
<script type="text/javascript">
	function showClubMember(friendid){
		$('#showInfo').modal('show')
		title = '<tr><th>管理员</th><th>玩家ID</th><th>加入时间</th></tr>'
		$('#title').html(title)
		$("#clubHead").text("亲友圈玩家列表")
		$.ajax({
			url:'clubManage.php',
			dataType:'',
			type:'POST',
			data:{
				method:'showClubMember',
				friendid:friendid
			},
			success:function(data){
				data = jQuery.parseJSON(data)
				result = '';
				for(var i=0;i<data.length;i++){
					if(data[i].isadmin == 1){
						result += '<tr><td><img src="/assets/images/agent/master.svg" width="20" height="20"></td>'
					}else{
						result += '<tr><td></td>'
					}
					result += '<td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+data[i].addtime+'</td></tr>'
				}
				$('#contain').html(result)
			},
			error:function(err){

			}

		})
	}

	function Disband(friendid){
		confirm("解除后无法恢复,如需恢复,请联系管理员!确定解除吗？")
		$.ajax({
			url:'clubManage.php',
			dataType:'',
			type:'POST',
			data:{
				method:'disband',
				friendid:friendid
			},
			success:function(data){
				console.log(data)
				if(data == '1'){
					alert("解散成功");
				}else{
					alert("解散失败");
				}
				window.location.reload()
			},
			error:function(err){

			}
		})
	}

	function showClubData(friendid){
		$('#showInfo').modal('show')
		title = '<tr><th>游戏</th><th>日期</th><th>耗钻</th><th>桌数</th></tr>'
		$('#title').html(title)
		$("#clubHead").text("亲友圈战绩")
		$.ajax({
			url:'clubManage.php',
			dataType:'',
			type:'GET',
			data:{
				method:'showClubData',
				friendid:friendid
			},
			success:function(data){
				data = jQuery.parseJSON(data)
				if(data){
					result = '';
					for(var i=0;i<data.length;i++){
						result += '<tr><td>'+data[i].gamename+'</td><td>'+data[i].dateid+'</td><td>'+data[i].roomamt+'</td><td>'+data[i].roomcnt+'</td></tr>'
					}		
				}else{
					result = '<tr><td>暂无</td><td>暂无</td><td>暂无</td><td>暂无</td></tr>'
				}
				
				$('#contain').html(result)
			},
			error:function(err){

			}

		})	
	}

</script>


