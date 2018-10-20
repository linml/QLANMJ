<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

	<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">玩家ID:</label>
				<div class="col-sm-9">
					<input type="text" id="fromuid" name="fromuid" value="<{$_REQUEST.fromuid}>" placeholder="请输入ID" >
					<select name="gameType" id="gameType">
						<option value="">--游戏类型--</option>
						<option value="BJ">比鸡</option>
						<option value="HQMJ">霍邱麻将</option>
						<option value="LABJ">六安比鸡</option>
						<option value="LAHZ">六安红中</option>
						<option value="LAMJ">六安麻将</option>
					</select> 
				</div>

				
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">房间号:</label>
				<div class="col-sm-9">
					<input type="text" id="touid" name="touid" value="<{$_REQUEST.touid}>" placeholder="请输入房间号" > 
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">开始日期</label>
				<div class="col-sm-9">
					<input type="text"  id="startdate"   name="startdate" value="<{$_REQUEST.startdate}>" placeholder="输入开始日期"   > 
					
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">结束日期</label>
				<div class="col-sm-9">
					<input type="text"  id="enddate" name="enddate" value="<{$_REQUEST.enddate}>" placeholder="输入结束日期"  > 
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
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">转钻列表</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>用户ID</th>
						<th>微信昵称</th>
						<th>房间号</th>
						<th>付费方式</th>
						<th>游戏类型</th>
						<th>局数</th>
						<th>耗钻</th>
						<th>时间</th>
					</tr>
				</thead>
				<tbody>
					<{foreach from=$records item=record}>
					<tr>
                        <td>
                        	<a href="sellgemslist.php?fromuid=<{$record.userid}>"><{$record.userid}></a>	
                        </td>
                        <td><{$record.name}></td>
                        <td><a href="sellgemslist.php?touid=<{$record.room}>"><{$record.room}></a></td>
                        <td><{$record.payway}></td>
                        <td><{$record.type}></td>
                        <td><{$record.jushu}></td>
                        <td><{$record.cost}></td>
                        <td><{$record.time}></td>
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
	$(function(){
		//设置传入的select 的值设置默认选项		
		$("#gameType option[value='<{$_REQUEST.gameType}>']").attr('selected',true);
	});
	</script>