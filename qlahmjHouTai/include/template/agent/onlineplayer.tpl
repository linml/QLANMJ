<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<div class="table-header">当前在线人数：<{$count}>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button class="btn btn-info " onclick="location.reload();">点击刷新</button>
			<!-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="btn btn-info " href="onlineplayer.php?gameType=<{$gameType}>"><{$typeName}></a> -->
		</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
			
				<tr>
					
					
					<th>UID</th>					
					<th>昵称</th>
					<th class="hidden-480">性别</th>
					<th>钻石</th>
					<th>注册时间</th>
					<th class="hidden-480">所在房间</th>
					<th class="hidden-480">房间创建时间</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$agents item=agent}>
				<tr>
					
					<td><{$agent.userid}></td>
					
					<td><{base64_decode($agent.name)}></td>
					<td class="hidden-480">
					<{if $agent.sex==1}>
						男
					<{elseif $agent.sex==2}>
					女
					<{else}>
					未知
					<{/if}>
					</td>
					<td><{$agent.gems}></td>
					<td><{$agent.create_time}></td>
					<td class="hidden-480"><{$agent.roomid}></td>
					<td class="hidden-480"><{$agent.roomtime}></td>
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

<!--- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 --->
<{include file="ace/footer.tpl" }>