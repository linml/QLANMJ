<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">模块名称</label>
				<div class="col-sm-9">
					<input type="text" name="module_name" value="<{$_POST.module_name}>" class="input-xlarge" required="true" autofocus="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">模块链接</label>
				<div class="col-sm-9">
					<input type="text" name="module_url" value="<{if $_POST.module_url=="" }>/index.php<{else}><{$_POST.module_url}><{/if}>" class="input-xlarge" required="true">
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">模块图标</label>
				<div class="col-sm-9">
					<i id="icon_preview" class="menu-icon fa fa-desktop"></i>
					<input type="text" readonly value="fa-desktop" name="module_icon" id="icon_id" style="width:180px" >
					<a id="icon_select" class="btn btn-xs btn-info" href="#modal-table" data-toggle="modal">更改图标</a>
					<!--- 选择图标层--->			
					<{include file="acepanel/icon_select.tpl" }>
					<!--- 选择图标层 结束--->
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">模块排序数字(数字越小越靠前)</label>
				<div class="col-sm-9">
					<input type="text" name="module_sort" value="<{$_POST.module_sort}>" class="input-xlarge" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">描述</label>
				<div class="col-sm-9">
					<textarea name="module_desc" rows="3" class="input-xlarge"><{$_POST.module_desc}></textarea>
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