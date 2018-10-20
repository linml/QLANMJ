<?php /* Smarty version Smarty-3.1.15, created on 2018-09-12 11:55:50
         compiled from "F:\project\qlahmjHouTai\include\template\agent\diamondRecord.tpl" */ ?>
<?php /*%%SmartyHeaderCode:202535b987f55bc93b6-02988226%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '178cadab416285051f3bd2496485915d3cdbd9fb' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agent\\diamondRecord.tpl',
      1 => 1536720932,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '202535b987f55bc93b6-02988226',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b987f55c0f8c7_65660400',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
    'page_no' => 0,
    'method' => 0,
    'index' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b987f55c0f8c7_65660400')) {function content_5b987f55c0f8c7_65660400($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div role="" class="form-inline">
		<form class="form-group" method="POST" action="">
			<select name="type" id="type" value="">
				<option value="1">玩家ID</option>
				<option value="2">玩家昵称</option>
				<option value="3">代理ID</option>
				<option value="4">代理昵称</option>
			</select>
			<input id="contains" type="text" name="contains" placeholder="请输入" value="">
			<input type="text" id="startdate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['startdate'];?>
" name="startdate" placeholder="输入开始日期"> 
			<input type="text" id="enddate" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['enddate'];?>
" name="enddate" placeholder="输入结束日期" >
			<button id="searchBtn" class="btn btn-info">查询</button>
		</form>
	</div>
</div>
<div class="row" style="margin:10px 0">
	<div class="col-xs-12">
	<ul class="nav nav-pills" id="tabBtn">
		<li class="active" method="getRechargeDiamondRecod"><a href="diamondRecord.php?method=getRechargeDiamondRecod&index=1">充钻记录</a></li>
		<li class="" method="getAgentTransferRecord"><a href="diamondRecord.php?method=getAgentTransferRecord&index=2">代理划拨</a></li>
		<li class="" method="buyDiamondRecord"><a href="diamondRecord.php?method=buyDiamondRecord&index=3">进钻记录</a></li>
		<li class="" method="systemTransfer"><a href="diamondRecord.php?method=systemTransfer&index=4">系统划拨</a></li>
		<li class="" method="systemSendAndSold"><a href="diamondRecord.php?method=systemSendAndSold&index=5">售钻/赠送</a></li>
	</ul>
	</div>
</div>	

<div class="row">
	<div class="row">
		<div class="col-xs-12">
			<div class="table-header">钻石记录</div>
			<table id="simple-table"
				class="table table-striped table-bordered table-hover" id="tabContain">
				<thead id="title">
				</thead>
				<tbody id="contain">
				</tbody>
			</table>
			<!-- START 分页模板 -->
			<?php echo $_smarty_tpl->tpl_vars['page_html']->value;?>

			<!-- END -->
		</div>
	</div>

	<!--操作的确认层，相当于javascript:confirm函数-->
	<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>


	<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
	<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

	<script type="text/javascript">
	$("#fromuid").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");

	$("#touid").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");
	
	$(function() {
	var date=$( "#startdate" );
	date.datepicker({ dateFormat: "yy-mm-dd" });
	date.datepicker( "option", "firstDay", 1 );
	});
	$(function() {
		var date=$( "#enddate" );
		date.datepicker({ dateFormat: "yy-mm-dd" });
		date.datepicker( "option", "firstDay", 1 );
	});
	</script>

<script type="text/javascript">
	$(function(){
		var page_no = <?php echo $_smarty_tpl->tpl_vars['page_no']->value;?>

		var method = <?php echo $_smarty_tpl->tpl_vars['method']->value;?>

		var index = <?php echo $_smarty_tpl->tpl_vars['index']->value;?>

		if(index)
			$('#tabBtn li').eq(index-1).addClass('active').siblings().removeClass('active');
		callback(method)
		function callback(method){

			console.log(method)
			if(method == '' ) method = 'getRechargeDiamondRecod'			
			if(method == 'getRechargeDiamondRecod'){
				title = '<tr><td>流水号</td><td>时间</td><td>玩家ID/昵称</td><td>充值数量</td><td>当前钻石</td><td>充值人</td><td>状态</td></tr>';
			}else if(method == 'getAgentTransferRecord'){
				title = '<tr><td>流水号</td><td>时间</td><td>代理ID/昵称</td><td>充值数量</td><td>当前钻石</td><td>充值人</td><td>状态</td></tr>';
			}else if(method == 'buyDiamondRecord'){
				title = '<tr><td>流水号</td><td>时间</td><td>代理ID/昵称</td><td>级别</td><td>支付方式</td><td>进钻金额</td><td>钻石数量</td><td>状态</td></tr>';
			}else if(method == 'systemTransfer'){
				title = '<tr><td>流水号</td><td>时间</td><td>代理ID/昵称</td><td>方式</td><td>级别</td><td>进钻金额</td><td>钻石数量</td><td>状态</td><td>管理员</td></tr>';
			}else if(method == 'systemSendAndSold'){
				title = '<tr><td>流水号</td><td>时间</td><td>玩家ID/昵称</td><td>方式</td><td>进钻金额</td><td>钻石数量</td><td>状态</td><td>管理员</td></tr>';
			}else{
				return
			}
		
			$.ajax({
				url:'diamondRecord.php',
				dataType:"",
				type:'POST',
				data:{
					method:method,
					page_no:page_no,
					flag:2
				},
				success:function(data){
					data = jQuery.parseJSON(data)
					$('#title').html(title)
					contain = '';
						

						if(method == 'getRechargeDiamondRecod'){
							for(var i=0;i<data.length;i++){
								if(data[i].status == 0){
									status = '初始'
								}else if(data[i].status == 1){
									status = '成功'
								}else if(data[i].status){
									status = '失败'
								}else{
									status = '未知状态'
								}
								contain += '<tr><td>'+data[i].relationid+'</td><td>'+data[i].addtime+'</td><td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+ -Math.round(data[i].fundmoney)+'</td><td>'+data[i].agomoney+'</td><td>('+data[i].buserid+')'+data[i].bnickname+'</td><td>'+status+'</td></tr>';
							}
						}else if(method == 'getAgentTransferRecord'){
							for(var i=0;i<data.length;i++){
								if(data[i].status == 0){
									status = '初始'
								}else if(data[i].status == 1){
									status = '成功'
								}else if(data[i].status){
									status = '失败'
								}else{
									status = '未知状态'
								}
								contain += '<tr><td>'+data[i].relationid+'</td><td>'+data[i].addtime+'</td><td>('+data[i].Muserid+')'+data[i].Mnickname+'</td><td>'+Math.round(data[i].fundmoney)+'</td><td>'+data[i].agomoney+'</td><td>('+data[i].Auserid+')'+data[i].Anickname+'</td><td>'+status+'</td></tr>';
							}
						}else if(method == 'buyDiamondRecord'){
							for(var i=0;i<data.length;i++){
								if(data[i].status == 0){
									status = '初始'
								}else if(data[i].status == 1){
									status = '成功'
								}else if(data[i].status){
									status = '失败'
								}else{
									status = '未知状态'
								}

								if(data[i].paytype == 0){
									paytype = '线下'
								}else if(data[i].paytype == 1){
									paytype = '微信'
								}else if(data[i].paytype == 2){
									paytype = '支付宝'
								}else{
									paytype = '余额'
								}
								contain += '<tr><td>'+data[i].relationid+'</td><td>'+data[i].addtime+'</td><td>('+data[i].Muserid+')'+data[i].Mnickname+'</td><td>'+data[i].Mname+'</td><td>'+paytype+'</td><td>'+data[i].rmb+'</td><td>'+Math.round(data[i].diamond)+'</td><td>'+status+'</td></tr>';
							}
						}else if(method == 'systemTransfer'){
							for(var i=0;i<data.length;i++){
								if(data[i].status == 0){
									status = '初始'
								}else if(data[i].status == 1){
									status = '成功'
								}else if(data[i].status){
									status = '失败'
								}else{
									status = '未知状态'
								}

								if(data[i].transfertype == 2){
									transfertype = '<td>系统充钻</td>'
								}else if(data[i].transfertype == 4){
									transfertype = '<td style="color:red">系统赠送</td>'
								}else{
									transfertype = '<td>未知</td>'
								}

								contain += '<tr><td>'+data[i].id+'</td><td>'+data[i].addtime+'</td><td>('+data[i].Muserid+')'+data[i].Mnickname+'</td>'+transfertype+'<td>'+data[i].Mname+'</td><td>'+data[i].rmb+'</td><td>'+Math.round(data[i].fundmoney)+'</td><td>'+status+'</td><td>'+data[i].user_name+'</td></tr>';
							}
						}else if(method == 'systemSendAndSold'){
							for(var i=0;i<data.length;i++){
								if(data[i].status == 0){
									status = '初始'
								}else if(data[i].status == 1){
									status = '成功'
								}else if(data[i].status){
									status = '失败'
								}else{
									status = '未知状态'
								}
								contain += '<tr><td>'+data[i].id+'</td><td>'+data[i].addtime+'</td><td>('+data[i].userid+')'+data[i].nickname+'</td><td>'+data[i].transfertype+'</td><td>'+data[i].rmb+'</td><td>'+Math.round(data[i].fundmoney)+'</td><td>'+status+'</td><td>'+data[i].user_name+'</td></tr>';
							}
						}else{
							return
						}
					$('#contain').html(contain)
				},
				error:function(err){

				}
			})
		}
	})


</script><?php }} ?>
