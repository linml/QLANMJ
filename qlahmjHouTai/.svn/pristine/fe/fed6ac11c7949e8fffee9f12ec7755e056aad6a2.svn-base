<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<div class="tabbable">
			<ul class="nav nav-tabs" id="myTab">
				<{if $change_password }>
				<li class="">
					<a data-toggle="tab" href="#home">资料</a>
				</li>
				<li class="active" >
					<a data-toggle="tab" href="#profile">密码</a>
				</li>
				<{else }>
				<li class="active">
					<a data-toggle="tab" href="#home">资料</a>
				</li>
				<li >
					<a data-toggle="tab" href="#profile">密码</a>
				</li>
				<{/if}>
			</ul>
			<div class="tab-content">
				<{if $change_password }>
				<div id="home" class="tab-pane fade">
				<{else }>
				<div id="home" class="tab-pane active in">
				<{/if}>
					<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">登录名</label>
							<div class="col-sm-9">
								<input type="text" name="user_name" value="<{$user_info.user_name}>" class="input-xlarge" readonly="true">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">姓名</label>
							<div class="col-sm-9">
								<input type="text" name="real_name" value="<{$user_info.real_name}>" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">手机</label>
							<div class="col-sm-9">
								<input type="text" name="mobile" value="<{$user_info.mobile}>" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">邮件</label>
							<div class="col-sm-9">
								<input type="text" name="email" value="<{$user_info.email}>" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">描述</label>
							<div class="col-sm-9">
								<textarea name="user_desc" value="Smith" rows="3" class="input-xlarge"><{$user_info.user_desc}></textarea>
							</div>
						</div>
						<div class="form-group">
							<div class="col-md-offset-3 col-md-9">
								<button class="btn btn-info" type="submit"><i class="icon-save"></i> 保存</button>
							</div>
						</div>
						<div style="clear:both;"></div>
					</form>
				</div>
				<{if $change_password }>
				<div id="profile" class="tab-pane active in">
				<{else }>
				<div id="profile" class="tab-pane fade">
				<{/if}>
					<form id="tab2" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
						<input type="hidden" name="change_password" value="yes" >
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">原密码</label>
							<div class="col-sm-9">
								<input type="password" name="old" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-3 control-label no-padding-right">新密码</label>
							<div class="col-sm-9">
								<input type="password" name="new" class="input-xlarge">
							</div>
						</div>
						<div class="form-group">
							<div class="col-md-offset-3 col-md-9">
								<button class="btn btn-info" type="submit">更新</button>
							</div>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
</div>

<{include file="ace/footer.tpl" }>