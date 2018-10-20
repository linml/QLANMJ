<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<div class="table-header">当前在线房间数：<{$count}>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button class="btn btn-info " onclick="location.reload();">点击刷新</button>
			<!-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="btn btn-info " href="onlineusers.php?gameType=<{$gameType}>"><{$typeName}></a> -->
		</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
			<tr>
					
					<th  class="text-center" rowspan ="2">房号</th>
					<th  class="text-center" rowspan ="2">创建时间</th>
					<th class="text-center" colspan="2">玩家 1</th>
					
					<th class="text-center" colspan="2">玩家 2</th>
					
					<th class="text-center" colspan="2">玩家 3</th>
					
					<th class="text-center" colspan="2">玩家 4</th>
					
					
				</tr>
				<tr>
					
					
					
					<th class="text-center">UID</th>
					<th class="text-center">昵称</th>
					<th class="text-center">UID</th>
					<th class="text-center">昵称</th>
					<th class="text-center">UID</th>
					<th class="text-center">昵称</th>
					<th class="text-center">UID</th>
					<th class="text-center">昵称</th>
					
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$agents item=agent}>
				<tr>
					
					<td><{$agent.id}></td>
					<td><{$agent.create_time}></td>
					<{if $agent.user_id0 != 0}>
				    	<td><{$agent.user_id0}></td>
				    <{else}>
				    	<td></td>
				    <{/if}>
					<td><{base64_decode($agent.user_name0)}></td>
					<{if $agent.user_id1 != 0}>
				    <td><{$agent.user_id1}></td>
				    <{else}>
				    <td></td>
				    <{/if}>
					<td><{base64_decode($agent.user_name1)}></td>
					<{if $agent.user_id2 != 0}>
				    <td><{$agent.user_id2}></td>
				    <{else}>
				    <td></td>
				    <{/if}>
					<td><{base64_decode($agent.user_name2)}></td>
					<{if $agent.user_id3 != 0}>
				    <td><{$agent.user_id3}></td>
				    <{else}>
				    <td></td>
				    <{/if}>
					<td><{base64_decode($agent.user_name3)}></td>
				
					
				
					
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