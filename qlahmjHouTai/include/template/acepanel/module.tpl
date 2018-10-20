<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
<form id="tab" method="post" action="" class="form-horizontal" role="form">
	<div class="col-xs-12">
		<div class="table-header">菜单模块链接列表</div>
		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th><input type="checkbox" id="checkAll" >全选</th>
					<th>#</th>
					<th>名称</th>
					<th>URL</th>
					<th>#Module</th>
					<th>菜单</th>
					<th>类型</th>
					<th>是否在线</th>
					<th class="hidden-480">描述</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=menu from=$menus item=menu}>
				<tr>
					<td>
					<{if $menu.menu_id <=100 }>
					<input type="checkbox" name="menu_ids[]" value="<{$menu.menu_id}>" disabled>
					<{else }>
					<input type="checkbox" name="menu_ids[]" value="<{$menu.menu_id}>" >
					<{/if }>
					</td>
					<td><{$menu.menu_id}></td>
					<td><{$menu.menu_name}></td>
					<td><{$menu.menu_url}></td>
					<td><{$menu.module_id}></td>
					<td>
					<{if $menu.is_show}>
						是
					<{else}>
						否
					<{/if}>
					</td>
					<td>
					<{if $menu.online}>
						在线
					<{else}>
						已下线
					<{/if}>
					</td>
					<td>
					<{if $menu.menu_type==1}>
						管理后台
					<{else if $menu.menu_type==2}>
						代理后台
					<{/if}>
					</td>

					<td class="hidden-480"><{$menu.menu_desc}></td>
				</tr>
				<{/foreach}>
			</tbody>
		</table>
	</div>
	<{if $module_id > 1 }>
	<div class="col-xs-12">
		<div class="form-group">
			<label class="col-sm-3 control-label no-padding-right">选择菜单模块</label>
			<div class="col-sm-9">
				<{html_options name=module id="DropDownTimezone" class="input-xlarge" options=$module_options_list selected=0 }>
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-3 col-md-9">
				<button class="btn btn-info" type="submit">修改菜单模块</button>
			</div>
		</div>
	</div>
	<{/if }>
</form>
</div>

<script type="text/javascript">
$("#checkAll").click(function(){
     if($(this).attr("checked")){
		$("input[name='menu_ids[]']").attr("checked",$(this).attr("checked"));
	 }else{
		$("input[name='menu_ids[]']").attr("checked",false);
	 }
});
</script>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>