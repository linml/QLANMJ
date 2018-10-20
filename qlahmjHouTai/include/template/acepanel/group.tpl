<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<form id="tab" method="post" action="" class="form-horizontal" role="form">
	<div class="col-xs-12">
		<div class="table-header">账号组成员列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th><input type="checkbox" id="checkAll" >全选</th>
					<th>#</th>
					<th>登录名</th>
					<th>姓名</th>
					<th>手机</th>
					<th class="hidden-480">邮箱</th>
					<th class="hidden-480">登录时间</th>
					<th class="hidden-480">登录IP</th>
					<th class="hidden-480">Group#</th>
					<th class="hidden-480">描述</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$user_infos item=user_info}>
				<tr>
					<td><input type="checkbox" name="user_ids[]" value="<{$user_info.user_id}>" <{if $user_info.user_id == 1}>disabled<{/if}>></td>
					<td><{$user_info.user_id}></td>
					<td><{$user_info.user_name}></td>
					<td><{$user_info.real_name}></td>
					<td class="hidden-480"><{$user_info.mobile}></td>
					<td class="hidden-480"><{$user_info.email}></td>
					<td class="hidden-480"><{$user_info.login_time}></td>
					<td class="hidden-480"><{$user_info.login_ip}></td>
					<td class="hidden-480"><{$user_info.user_group}></td>
					<td class="hidden-480"><{$user_info.user_desc}></td>
				</tr>
				<{/foreach}>
			</tbody>
		</table>
	</div>
	<div class="col-xs-12">
		<div class="form-group">
			<label class="col-sm-3 control-label no-padding-right">选择账号组</label>
			<div class="col-sm-9">
				<{html_options name=user_group id="DropDownTimezone" class="input-xlarge" options=$groupOptions selected=0}>
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-3 col-md-9">
				<button class="btn btn-info" type="submit">修改账号组</button>
			</div>
		</div>
	</div>
	</form>
</div>
	
<!---操作的确认层，相当于javascript:confirm函数--->
<{$osadmin_action_confirm}>

<script type="text/javascript">
$("#checkAll").click(function(){
     if($(this).attr("checked")){
		$("input[name='user_ids[]']").attr("checked",$(this).attr("checked"));
	 }else{
		$("input[name='user_ids[]']").attr("checked",false);
	 }
});
</script>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>