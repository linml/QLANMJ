<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<a href="noticeset.php" class="btn btn-primary"><i class="icon-plus"></i>公告</a>
			</div>
	<div class="col-xs-12">
		<{if $_GET.search }>
		<div id="search" class="collapse in">
		<{else }>
		<div id="search" class="collapse out" >
		<{/if }>
		<form action="" method="GET" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">选择账号组</label>
				<div class="col-sm-9">
					<{html_options name=user_group id="DropDownTimezone" class="input-xlarge" options=$group_options selected=$_GET.user_group}>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">查询所有用户请留空</label>
				<div class="col-sm-9">
					<input type="text" name="user_name" value="<{$_GET.user_name}>" placeholder="输入登录名" > 
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
		<div class="table-header">账号列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<!-- <th>#</th> -->
					<th>标题</th>
					<th class="hidden-480">内容</th>
					<th>创建时间</th>
					<th class="hidden-480">修改时间</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$user_infos item=user_info}>
				<tr>
					<!-- <td><{$user_info.id}></td> -->
					<td><{$user_info.title}></td>
					<td class="hidden-480"><{$user_info.content}></td>
					<td><{$user_info.create_time}></td>
					<td class="hidden-480"><{$user_info.update_time}></td>
					<td>
						<a href="noticeset.php?id=<{$user_info.id}>" title= "修改" ><i class="icon-pencil"></i></a>
						
						&nbsp;
						<a data-toggle="modal" href="#myModal" title= "删除" ><i class="icon-remove" href="noticelist.php?page_no=<{$page_no}>&method=del&id=<{$user_info.id}>" ></i></a>
						
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

<!--- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 --->
<{include file="ace/footer.tpl" }>