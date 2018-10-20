<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- TPLSTART 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<a href="strongupdate_add.php" class="btn btn-primary"><i class="icon-plus"></i> 版本</a>
	</div>
	<div class="col-xs-12">
	</div>
	<div class="col-xs-12">
		<div class="table-header">版本列表</div>
		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<!-- <th>#</th> -->
					<th>强更新版本</th>
					<th >IOS 强更</th>
					<th>IOS ULR</th>
					<th>Android 强更</th>
					<th>Android URL</th>
					<th>创建时间</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=module from=$modules item=module}>
				<tr>
					<!-- <td><{$module.id}></td> -->
					<td><{$module.versoin}></td>
					
					
					<td>
						<{if $module.ios==1}>
					是
					<{else }>
					否
					<{/if}>
					</td>
					
					<td><{$module.ios_url}></td>
					
					
					<td>
						<{if $module.android==1}>
					是
					<{else }>
					否
					<{/if}>
					</td>
					
					<td><{$module.android_url}></td>
					<td><{$module.create_time}></td>
					<td>
				
					<a data-toggle="modal" href="#myModal"  title= "删除" ><i class="icon-remove" href="strongupdate.php?method=del&module_id=<{$module.id}>"></i></a>
				
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