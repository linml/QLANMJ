<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- TPLSTART 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<a href="group_add.php" class="btn btn-primary"><i class="icon-plus"></i> 账号组</a>
	</div>
	<div class="col-xs-12">
	</div>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="table-header">账号组列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>#</th>
					<th>账号组名</th>
					<th>描述</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=group from=$groups item=group}>
				<tr>
					<td><{$group.group_id}></td>
					<td><{$group.group_name}></td>
					<td><{$group.group_desc}></td>
					<td>
					<a href="group.php?group_id=<{$group.group_id}>" title= "成员列表" ><i class="icon-list-alt"></i></a>
					&nbsp;
					<a href="group_modify.php?group_id=<{$group.group_id}>" title= "修改" ><i class="icon-pencil"></i></a>
					&nbsp;
					<{if $group.group_id != 1 && $group.group_id != 3 }>
					<a data-toggle="modal" href="#myModal"  title= "删除" ><i class="icon-remove" href="groups.php?method=del&group_id=<{$group.group_id}>#myModal" data-toggle="modal" ></i></a>
					<{/if }>
					</td>
				</tr>
				<{/foreach}>
			</tbody>
		</table>
	</div>
</div>

<!---操作的确认层，相当于javascript:confirm函数--->
<{$osadmin_action_confirm}>
	
<!-- TPLEND 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>