<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">  	
		<div class="alert alert-info">
			<button class="close" data-dismiss="alert">
				<i class="ace-icon fa fa-times"></i>
			</button>
			<i class="ace-icon fa fa-hand-o-right"></i>
			请保管好您的个人信息，一点发生密码泄露请紧急联系管理员。
		</div>
		<{if $tips!=""}>
			<div  class="alert alert-info">
				<{$tips}>
			</div>
		<{/if}>
		<div class="table-header">当前用户信息</div>
		<div></div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>用户名</th>
					<th>真实姓名</th>
					<th class="hidden-480">手机号</th>
					<th>Email</th>
					<th class="hidden-480">登录时间</th>
					<th>登录IP</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td><{$user_info.user_name}></td>
					<td><{$user_info.real_name}></td>
					<td class="hidden-480"><{$user_info.mobile}></td>
					<td><{$user_info.email}></td>
					<td class="hidden-480"><{$user_info.login_time}></td>
					<td><{$user_info.login_ip}></td>
				</tr>
			</tbody>
		</table>
	</div>
</div>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl"}>