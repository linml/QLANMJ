<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>
<div class="row">
	<div class="col-xs-12">
		<div class="table-header">总代报表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>日期</th>
					<{foreach name=roseh from=$rose_list item=roseh}>
						<td>(<{$roseh.user_game_id}>)<{$roseh.nickName}></td>
					<{/foreach}>		
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$agents item=agent}>
				<tr>
					<td><{$agent.nowDate}></td>
					<{foreach name=roseL from=$rose_list item=rose}>
						<td><{$agent[$rose.st_id]}></td>
					<{/foreach}>
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


