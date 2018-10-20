<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<a href="user_add.php" class="btn btn-primary"><i class="icon-plus"></i> 账号</a>
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
					<th>#</th>
					<th>登录名</th>
					<th>姓名</th>
					<th>手机</th>
					<th class="hidden-480">邮箱</th>
					<th>登录时间</th>
					<th>登录IP</th>
					<th>Group#</th>
					<th class="hidden-480">描述</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$user_infos item=user_info}>
				<tr>
					<td><{$user_info.user_id}></td>
					<td><{$user_info.user_name}></td>
					<td><{$user_info.real_name}></td>
					<td><{$user_info.mobile}></td>
					<td class="hidden-480"><{$user_info.email}></td>
					<td><{$user_info.login_time}></td>
					<td><{$user_info.login_ip}></td>
					<td><{$user_info.group_name}></td>
					<td class="hidden-480"><{$user_info.user_desc}></td>
					<td>
						<a href="user_modify.php?user_id=<{$user_info.user_id}>" title= "修改" ><i class="icon-pencil"></i></a>
						&nbsp;
						<{if $user_info.user_id != 1}>
						<{if $user_info.status == 1}>
						<a data-toggle="modal" href="#myModal"  title= "封停账号" ><i class="icon-pause" href="users.php?page_no=<{$page_no}>&method=pause&user_id=<{$user_info.user_id}>"></i></a>
						<{/if }>
						<{if $user_info.status == 0}>
						<a data-toggle="modal" href="#myModal" title= "解封账号" ><i class="icon-play" href="users.php?page_no=<{$page_no}>&method=play&user_id=<{$user_info.user_id}>"></i></a>
						<{/if }>
						&nbsp;
						<a data-toggle="modal" href="#myModal" title= "删除" ><i class="icon-remove" href="users.php?page_no=<{$page_no}>&method=del&user_id=<{$user_info.user_id}>" ></i></a>
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

<!--- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 --->
<{include file="ace/footer.tpl" }>