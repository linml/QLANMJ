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
					<input type="text" id="fromuid" name="gameId" value="<{$_REQUEST.gameId}>" placeholder="输入玩家UID" >
					<input type="test" class="hidden" name="clubId" value="<{$_REQUEST.clubId}>"> 
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
			<div class="table-header">俱乐部管理</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<th>头像</th>
						<th>玩家ID</th>
						<th>玩家名称</th>
						<th>时间</th>
					</tr>
				</thead>
				<tbody>
					<{foreach from=$clubGameUserArray item=clubUser}>
					<tr>
                        <td><img src="<{$clubUser['headUrl']}>" style='width: 40px;height: 40px;'></td>
                        <td><{$clubUser['uid']}></td>
                        <td><{$clubUser['name']}></td>
                        <td><{$clubUser['time']}></td>
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

	
	</script>