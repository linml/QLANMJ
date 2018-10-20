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
				<label class="col-sm-3 control-label no-padding-right">玩家UID或者名称</label>
				<div class="col-sm-9">
					<input type="text" name="agentid" id="user_name" placeholder="输入玩家UID或者名称" value="<{$_REQUEST.agentid}>"> 
					<select name="agent_type" id="topType">
						<option value="">级别</option>
						<option value="1">钻石代理</option>
						<option value="2">铂金代理</option>
						<option value="3">金牌代理</option>
					</select>
					<select name="topAgent" id="topAgent">
						<option value="">默认</option>
						<option value="1">官方</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">开始日期</label>
				<div class="col-sm-9">
					<input type="text"  id="startdate"   name="startDate" value="<{$_REQUEST.startDate}>" placeholder="输入开始日期"   > 
					<select name="m_type" id="m_type">
						<option value="">默认</option>
						<option value="1">玩家充钻</option>
						<option value="-1">系统赠送</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">结束日期</label>
				<div class="col-sm-9">
					<input type="text"  id="enddate" name="endDate" value="<{$_REQUEST.endDate}>" placeholder="输入结束日期" > 
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
		<div class="table-header">划拨记录</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>代理ID</th>
					<th>微信昵称</th>	
					<th>级别</th>
					<th>获得钻石</th>
					<th>金额</th>
					<th>上级代理ID</th>
					<th>微信昵称</th>
					<th>类型</th>
					<th>充值者</th>
					<th>时间</th>	
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$agents item=agent}>
				<tr>
					
					<td>
						<a href="transferRecord.php?agentid=<{$agent.agentid}>" title='<{$agent.traded_info}>'><{$agent.agentid}></a>	
					</td>
					<td><{$agent.nickname}></td>
					<td>
						<{if $agent.istop == 1}>
							钻石
						<{else if $agent.istop ==2}>
							铂金
						<{else if $agent.istop ==3}>
							金牌
						<{/if}>
					</td>
					<td ><{$agent.traded_num}></td>
					<td ><{$agent.traded_money}></td>
					<{if $agent.agentTopid=='官方'}>
						<td class="green"><{$agent.agentTopid}></td>
					<{else}>
						<td><{$agent.agentTopid}></td>
					<{/if}>

					<{if $agent.rechargePerson=='官方'}>
						<td class="green"><{$agent.rechargePerson}></td>
					<{else}>
						<td><{$agent.rechargePerson}></td>
					<{/if}>

					<td>
						<{if $agent.type==1}>
							代理充钻
						<{else if $agent.type ==-1}>
							系统赠送
						<{/if}>
					</td>
					<td><{$agent.adminName}></td>
					<td><{$agent.addtime}></td>
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

<script>
	
	$(function(){
		//设置传入的select 的值设置默认选项
		$("#topType option[value='<{$_REQUEST.agent_type}>']").attr('selected',true);
		$("#topAgent option[value='<{$_REQUEST.topAgent}>']").attr('selected',true);
		$("#m_type option[value='<{$_REQUEST.m_type}>']").attr('selected',true);
	});
</script>

<script type="text/javascript">
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
