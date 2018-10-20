<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>
<div class="row">
	<div class="col-xs-12">
		<a href="menu_add.php"  class="btn btn-primary"><i class="icon-plus"></i> 功能</a>
		<a data-toggle="collapse" data-target="#search"  href="#" title= "检索"><button class="btn btn-primary" style="margin-left:5px"><i class="icon-search"></i></button></a>
	</div>
	<div class="col-xs-12">
		<{if $_GET.search }>
		<div id="search" class="collapse in">
		<{else }>
		<div id="search" class="collapse out" >
		<{/if }>
		<form action="" method="GET" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">选择菜单模块</label>
				<div class="col-sm-9">
					<{html_options name=module_id id="DropDownTimezone" class="input-xlarge" options=$module_options_list selected=$_GET.module_id}>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">查询所有请留空</label>
				<div class="col-sm-9">
					<input type="text" name="menu_name" value="<{$_GET.menu_name}>" placeholder="输入菜单名称" > 
					<input type="hidden" name="search" value="1" >
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
		<div class="table-header">功能列表</div>
		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>名称</th>
					<th>URL</th>
					<th>所属模块</th>
					<th>菜单</th>
					<th>所属菜单</th>
					<th>是否在线</th>
					<th>类型</th>
					<th class="hidden-480">描述</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=menu from=$menus item=menu}>
				<tr>
					<td><{$menu.menu_name}></td>
					<td><{$menu.menu_url}></td>
					<td><{$module_options_list[$menu.module_id]}></td>
					<td>
					<{if $menu.is_show}>
						是
					<{else}>
						否
					<{/if}>
					</td>
					<td><{if $menu.father_menu>0}><{$menu.father_menu_name}><{/if}></td>
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
					<{else}>
						功能有误
					<{/if}>
					</td>
					<td class="hidden-480"><{$menu.menu_desc}></td>
					<td>
						<a href="menu_modify.php?menu_id=<{$menu.menu_id}>" title= "修改" ><i class="icon-pencil"></i></a>
						<{if $menu.menu_id > 100}>
						&nbsp;
						<a data-toggle="modal" href="#myModal" title= "删除" ><i class="icon-remove" href="menus.php?page_no=<{$page_no}>&method=del&menu_id=<{$menu.menu_id}>" ></i></a>
						<{/if }>
					</td>
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