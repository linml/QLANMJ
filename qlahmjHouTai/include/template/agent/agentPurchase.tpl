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
					<input type="text" name="agentid" id="user_name" placeholder="输入玩家UID或者名称" > 
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
		<div class="table-header">代理报表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>

					<th>代理ID</th>
					<th>登录账号</th>
					<th>微信昵称</th>	
					<th>代理级别</th>
					<th>进货折扣</th>
					<th>钻石数量</th>
					<th>时间</th>
	
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$agents item=agent}>
				<tr>
					
					<td><{$agent.user_game_id}></td>
					<td ><{$agent.tel}></td>
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
					<td ><{$agent.flowpoint}></td>
					<td><{$agent.traded_num}></td>
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
