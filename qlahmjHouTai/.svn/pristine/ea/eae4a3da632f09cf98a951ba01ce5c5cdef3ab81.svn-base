<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>
<div class="row">
	<div class="col-xs-12">
		<div class="table-header">游戏列表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>游戏名称</th>
					<th>游戏简介</th>
					<th>主目录</th>
					<th>游戏标签</th>
					<th>状态</th>
					<th>操作</th>
				</tr>
			</thead>
			<tbody>
				<{foreach $gamelist as $val}>
				<tr>
					<td><{$val.gamename}></td>
					<td>fixme</td>
					<td>fixme</td>
					<td>fixme</td>
					<{if $val.gamestatus == '0'}>
					<td>下架</td>
					<{else if $val.gamestatus == '1'}>
					<td>运营中</td>
					<{else}>
					<td>未知状态</td>
					<{/if}>
					<td>
						<button onclick="set(<{$val.gameid}>)">设置</button>
					</td>
				</tr>
				<{/foreach}>
			</tbody>
		</table>
		<!-- START 分页模板 -->
        <{$page_html}>
		<!-- END -->
	</div>
</div>


<div class="modal fade" id="gameInfo" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true" id="tabClose">&times;</button>
				<h4 class="modal-title" id="myModalLabel">设置</h4>
			</div>
			<div class="modal-body" id="tabContain">
			<form>
				
			</form>
			<div class="form-group">
			<div class="col-sm-9" style="height:10px;"></div>
			</div>
			<div style="clear:both;"></div>
			</div>
			</div>
		<!-- /.modal-content -->
		</div>
	<!-- /.modal -->
</div>


<!--操作的确认层，相当于javascript:confirm函数-->
<{$osadmin_action_confirm}>
<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>
<script type="text/javascript">
	function set(gameid){
		$('#gameInfo').modal('show')
	}
</script>