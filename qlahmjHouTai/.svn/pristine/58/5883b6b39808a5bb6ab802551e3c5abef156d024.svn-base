<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">版本号</label>
				<div class="col-sm-9">
					<input type="text" name="versoin" value="<{$_POST.versoin}>" class="input-xlarge" required="true" autofocus="true" >
				</div>
			</div>
			<div class="form-group">
						<label class="col-sm-3 control-label no-padding-right">IOS强更新</label>
						<div class="col-sm-9">
							<label> <input name="ios" id="ios" value="1" 
							
							<{if $config.ios==0}>
					
					<{else}>
					checked="checked"
					<{/if}>
							
							
							
								class="ace ace-switch ace-switch-6" type="checkbox" />
								<span class="lbl"></span>
							</label>
						</div>
						<span class="help-inline col-xs-12 col-sm-7"> <span
							class="middle"></span>
						</span>
					</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">IOS下载URL</label>
				<div class="col-sm-9">
					<input type="text" name="ios_url" value="<{$_POST.ios_url}>" class="input-xlarge" >
				</div>
			</div>
			<div class="form-group">
						<label class="col-sm-3 control-label no-padding-right">android强更新</label>
						<div class="col-sm-9">
							<label> <input name="android" id="android" value="1" 
							
							<{if $config.android==0}>
					
					<{else}>
					checked="checked"
					<{/if}>
							
							
							
								class="ace ace-switch ace-switch-6" type="checkbox" />
								<span class="lbl"></span>
							</label>
						</div>
						<span class="help-inline col-xs-12 col-sm-7"> <span
							class="middle"></span>
						</span>
					</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">android下载URL</label>
				<div class="col-sm-9">
					<input type="text" name="android_url" 
					value="<{$_POST.android_url}>" 
					class="input-xlarge" 
					>
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
<script>
$('.icon').click(function(){
	var obj = $(this);
	$('#icon_preview').removeClass().addClass('menu-icon fa ' + $.trim(obj.text()));
	$('#icon_id').val($.trim(obj.text()));
	$('#modal-table').modal('toggle');
});
</script>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>