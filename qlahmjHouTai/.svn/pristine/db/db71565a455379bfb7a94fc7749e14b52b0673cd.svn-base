<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row" style="margin: 1% 0">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="POST" class="form-inline" role="form">		
			<div class="form-group">
					<select name="type" id='type'>
						<option value="1">玩家ID</option>
						<option value="2">玩家昵称</option>
					</select>
				</div>
					<input type="text" id="contains"  name="contains" value="<{$_REQUEST1.contains}>" placeholder="请输入">
					<input type="text" name="starttime" id="starttime" value="<{$_REQUEST1.starttime}>">
					<input type="text" name="endtime" id="endtime" value="<{$_REQUEST1.endtime}>">
					<select name="gameid" id="gameid">
						<option value="">总局数</option>
						<{foreach $gameInfo as $val}>
						<option value="<{$val.gameid}>"><{$val.gamename}></option>
						<{/foreach}>
					</select>
					<button class="btn btn-info" type="submit" id="search_reuslt">检索</button>	
			</div>
			<div style="clear:both;"></div>
		</form>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-xs-12">
		<div class="table-header">今日排行榜</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>玩家ID/昵称</th>
					<th>总局数</th>								
				</tr>
			</thead>
			<tbody>
				<{foreach $board as $val}>
				<tr>
					<td>(<{$val.userid}>)<{$val.nickname}></td>
					<td><{$val.count}></td>
				</tr>
				<{/foreach}>
			</tbody>
		</table>
		<!-- START 分页模板 -->
        <{$page_html}>
		<!-- END -->
	</div>
</div>
<!--操作的确认层，相当于javascript:confirm函数-->
<{$osadmin_action_confirm}>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>
<script src="<{$smarty.const.ADMIN_URL}>/assets/lib/laydate/laydate.js"></script>
<script type="text/javascript">
    laydate.render({
      elem: '#starttime'
    });

    laydate.render({
      elem: '#endtime'
    }); 
</script>
<script type="text/javascript">
	$(document).ready(function(){
		var _REQUEST = <{$_REQUEST}>
    	if(_REQUEST == null) return
    	$('#type').find('option[value="'+_REQUEST.type+'"]').attr('selected','selected')
    	$('#gameid').find('option[value="'+_REQUEST.gameid+'"]').attr('selected','selected')
    	
	})
</script>