<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<select name="group_id" onchange="javascript:location.replace('group_role.php?group_id='+this.options[this.selectedIndex].value)" style="margin:5px 0px 0px">
			<{html_options options=$group_option_list selected=$group_id}>
		</select>
	</div>
</div>
<div class="row">
<div class="col-xs-12"></div>
</div>
<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
		<div id="accordion" class="accordion-style1 panel-group">
		<{foreach from=$role_list item=role}>
			<{if count($role.menu_info) >0 }>
			<div class="panel panel-default">
				<div class="panel-heading">
					<h4 class="panel-title">
						<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#page-stats_<{$role.module_id}>">
							<i class="ace-icon fa fa-angle-down bigger-110" data-icon-hide="ace-icon fa fa-angle-down" data-icon-show="ace-icon fa fa-angle-right"></i>
							<{$role.module_name}>
						</a>
					</h4>
				</div>
				<div class="panel-collapse collapse in" id="page-stats_<{$role.module_id}>">
					<div class="panel-body">
						<{html_checkboxes name="menu_ids"  options=$role.menu_info checked=$group_role separator="&nbsp;&nbsp;" labels="1"}>
					</div>
				</div>
			</div>
			<{/if }>
		<{/foreach}>
		</div>
		<div>
			<button class="btn btn-info">更新</button>
		</div>
		</form>
	</div>
</div>

<{include file="ace/footer.tpl" }>