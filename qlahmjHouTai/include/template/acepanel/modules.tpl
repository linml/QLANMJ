<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- TPLSTART 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<a href="module_add.php" class="btn btn-primary"><i class="icon-plus"></i> 模块</a>
	</div>
	<div class="col-xs-12">
	</div>
	<div class="col-xs-12">
		<div class="table-header">模块列表</div>
		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>#</th>
					<th>模块名</th>
					<th>模块链接</th>
					<th>排序</th>
					<th>是否在线</th>
					<th class="hidden-480">描述</th>
					<th class="hidden-480">图标</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=module from=$modules item=module}>
				<tr>
					<td><{$module.module_id}></td>
					<td><{$module.module_name}></td>
					<td><{$module.module_url}></td>
					<td><{$module.module_sort}></td>
					<td>
						<{if $module.online}>
							在线
						<{else}>
							已下线
						<{/if}>
					</td>
					<td class="hidden-480"><{$module.module_desc}></td>
					<td class="hidden-480"><{$module.module_icon}></td>
					<td>
					<a href="module.php?module_id=<{$module.module_id}>" title= "菜单链接列表" ><i class="icon-list-alt"></i></a>
					&nbsp;
					<a href="module_modify.php?module_id=<{$module.module_id}>" title= "修改" ><i class="icon-pencil"></i></a>
					&nbsp;
					<{if $module.module_id != 1 }>
					<a data-toggle="modal" href="#myModal"  title= "删除" ><i class="icon-remove" href="modules.php?method=del&module_id=<{$module.module_id}>"></i></a>
					<{/if}>
					</td>
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
	
<!-- TPLEND 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>