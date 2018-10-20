<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">名称</label>
				<div class="col-sm-9">
					<input type="text" name="menu_name" value="<{$_POST.menu_name}>" class="input-xlarge" required="true" autofocus="true">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">链接 <span class="label label-important">不可重复，以/开头的相对路径或者http网址</span></label>
				<div class="col-sm-9">
					<input type="text" name="menu_url" value="<{$_POST.menu_url}>" class="input-xlarge" placeholder="/panel/"  required="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">所属模块</label>
				<div class="col-sm-9">
					<{html_options name=module_id id="DropDownTimezone" class="input-xlarge" options=$module_options_list selected=0}>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">是否左侧菜单栏显示</label>
				<div class="col-sm-9">
					<select name="is_show" class="input-xlarge" >
						<option value="1" selected >是</option>
						<option value="0">否</option>
					</select>
				</div>
			</div>

			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">功能类型</label>
				<div class="col-sm-9">
					<select name="menu_type" class="input-xlarge" >
						<option value="1" selected >管理后台</option>
						<option value="2">代理后台</option>
					</select>
				</div>
			</div>

			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">所属菜单</label>
				<div class="col-sm-9">
					<{html_options name=father_menu id="DropDownTimezone" class="input-xlarge" options=$father_menu_options_list selected=0}>
				</div>
			</div>
			<input type="hidden" name="shortcut_allowed" value="1">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">描述</label>
				<div class="col-sm-9">
					<textarea name="menu_desc" rows="3" class="input-xlarge"><{$_POST.module_desc}></textarea>
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