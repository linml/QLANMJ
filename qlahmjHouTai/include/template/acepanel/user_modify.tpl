<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">登录名 <span class="label label-info">不可修改</span></label>
				<div class="col-sm-9">
					<input type="text" name="user_name" value="<{$user.user_name}>" class="input-xlarge" readonly="true">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">密码 <span class="label label-important" >如不修改请留空</span></label>
				<div class="col-sm-9">
					<input type="password" name="password" value="" class="input-xlarge">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">姓名</label>
				<div class="col-sm-9">
					<input type="text" name="real_name" value="<{$user.real_name}>" class="input-xlarge" required="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">手机</label>
				<div class="col-sm-9">
					<input type="text" name="mobile" value="<{$user.mobile}>" class="input-xlarge" required pattern="\d{11}">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">微信号</label>
				<div class="col-sm-9">
					<input  name="email" value="<{$user.email}>"  class="input-xlarge" required="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">描述</label>
				<div class="col-sm-9">
					<textarea name="user_desc" rows="3" class="input-xlarge"><{$user.user_desc}></textarea>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">账号组</label>
				<div class="col-sm-9">
					<{if $user.user_id == 1}>
					<{html_options name=user_group id="DropDownTimezone" class="input-xlarge" options=$group_options disabled="true" selected=$user.user_group}>
					<{else }>
					<{html_options name=user_group id="DropDownTimezone" class="input-xlarge" options=$group_options  selected=$user.user_group}>
					<{/if }>
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-offset-3 col-md-9">
					<button class="btn btn-info" type="submit">提交</button>
				</div>
			</div>
			<div style="clear:both;"></div>
		</form>
	</div>
</div>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>