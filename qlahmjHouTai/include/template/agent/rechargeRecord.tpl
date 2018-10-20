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
				<label class="col-sm-3 control-label no-padding-right">玩家ID</label>
				<div class="col-sm-9">
					<input type="text" id="touid" name="touid" value="<{$_REQUEST.touid}>" placeholder="输入玩家UID" > 
					<select name="topAgent" id="topAgent">
						<option value="">默认</option>
						<option value="1">官方</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">代理ID</label>
				<div class="col-sm-9">
					<input type="text" id="fromuid"  name="fromuid" value="<{$_REQUEST.fromuid}>" placeholder="输入代理UID" > 
					<select name="m_type" id="m_type">
						<option value="">默认</option>
						<option value="1">玩家充钻</option>
						<option value="-1">系统赠送</option>
					</select>
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
			<div class="table-header">开房记录</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>时间</th>
						<th>代理ID</th>
						<th>代理微信昵称</th>
						<th>玩家ID</th>
						<th>微信昵称</th>
						<th>充钻数量</th>
						<th>金额</th>
						<th>充值者</th>
						<th>类型</th>
						<th>状态</th>
					</tr>
				</thead>
				<tbody>
					<{foreach from=$records item=record}>
					<tr>
                        <td><{$record.created}></td>
                    	<{if $record.agentid=='官方' }>
							<td class="green"><{$record.agentid}></td>
						<{else}>
							<td><a href="rechargeRecord.php?fromuid=<{$record.agentid}>"><{$record.agentid}></a></td>
						<{/if}>

						<{if $record.agentName=='官方'}>
							<td class="green"><{$record.agentName}></td>
						<{else}>
							<td><{$record.agentName}></td>
						<{/if}>
                        <td>
                 			<a href="rechargeRecord.php?touid=<{$record.gameid}>"><{$record.gameid}></a>
                       	</td>
						<td><{$record.gameName}></td>
                        <td><{$record.amount}></td>
                        <td><{$record.total}></td>
                        <td><{$record.wxnick}></td>
                        <td>
                        	<{if $record.openid ==1}>
                        		玩家充钻
                        	<{else if $record.openid ==-1}>
                        		系统赠送
                        	<{/if}>

                        </td>


                        <td>
                        	<{if $record.status==2}>
                        		成功
                        	<{elseif $record.status==1}>
                        		失败
                        	<{/if}>
                        </td>
					</tr>
					<{/foreach}>
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
		$("#topAgent option[value='<{$_REQUEST.topAgent}>']").attr('selected',true);
		$("#m_type option[value='<{$_REQUEST.m_type}>']").attr('selected',true);
	});
	</script>