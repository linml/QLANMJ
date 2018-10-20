<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">选择时区</label>
				<div class="col-sm-9">
					<{html_options name=new_timezone id="DropDownTimezone" class="input-xlarge" options=$timezone_options selected=$timezone }>
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
</div>

<{include file="ace/footer.tpl" }>