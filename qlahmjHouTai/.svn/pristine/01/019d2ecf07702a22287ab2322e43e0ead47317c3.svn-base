<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!--- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>
<style>
.ui-datepicker td>a, .ui-datepicker td>span {
	min-width: auto;
}
</style>
<div class="row">
	<div class="col-xs-12">
		<a data-toggle="collapse" data-target="#search"  href="#" title= "检索"><button class="btn btn-primary"><i class="icon-search"></i></button></a>
	</div>
	<div class="col-xs-12">
		<{if $_GET.search }>
		<div id="search" class="collapse in">
		<{else }>
		<div id="search" class="collapse out" >
		<{/if }>
		<form action="" method="GET" class="form-horizontal" role="form">
		<div class="form-group">
			<label class="col-sm-3 control-label no-padding-right">请选择操作记录类型</label>
			<div class="col-sm-9">
				<{html_options name=class_name id="DropDownTimezone"  options=$class_options selected=$_GET.class_name}> 
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-3 control-label no-padding-right"> 选择起始时间 </label>
			<div class="col-sm-9">
				<input type="text" id="start_date" name="start_date" value="<{$_GET.start_date}>" placeholder="起始时间" >
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-3 control-label no-padding-right">选择结束时间</label>	
			<div class="col-sm-9">
				<input type="text" id="end_date" name="end_date" value="<{$_GET.end_date}>" placeholder="结束时间" > 
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-3 control-label no-padding-right">用户名，查询所有用户请留空</label>
			<div class="col-sm-9">
				<input type="text" name="user_name" value="<{$_GET.user_name}>" placeholder="输入用户名" > 
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-3 col-md-9">
				<button class="btn btn-info" type="submit">检索</button>
			</div>
		</div>
		</form>
		</div>
	</div>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="table-header">操作记录</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>#</th>
					<th>操作员</th>
					<th>行为</th>
					<th>类型</th>
					<th class="hidden-480">对象</th>
					<th>操作结果</th>
					<th>操作时间</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=sys_log from=$sys_logs item=sys_log}>
				<tr>
					<td><{$sys_log.op_id}></td>
					<td><{$sys_log.user_name}></td>
					<td><{$sys_log.action}></td>
					<td><{$sys_log.class_name}></td>
					<td class="hidden-480"><{$sys_log.class_obj}></td>
					<td><{$sys_log.result}></td>
					<td><{$sys_log.op_time}></td>
				</tr>
				<{/foreach}>
			</tbody>
		</table>
		<!--- START 分页模板 --->
        <{$page_html}>
		<!--- END --->
	</div>
</div>

<script>
$(function() {
	var date=$( "#start_date" );
	date.datepicker({ dateFormat: "yy-mm-dd" });
	date.datepicker( "option", "firstDay", 1 );
});
$(function() {
	var date=$( "#end_date" );
	date.datepicker({ dateFormat: "yy-mm-dd" });
	date.datepicker( "option", "firstDay", 1 );
});
</script>
	
<!--- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 --->
<{include file="ace/footer.tpl" }>