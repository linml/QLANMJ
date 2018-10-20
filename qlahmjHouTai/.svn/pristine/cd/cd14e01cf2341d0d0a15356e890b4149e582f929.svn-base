<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<div class="table-header">商城配置</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<!-- <th>代理商账户</th> -->
					<th>商品ID</th>
					<th>名称</th>	
					<th>价格(元)</th>
					<th>钻石(个)</th>
					<th>优惠</th>
					<th>状态</th>
					<th>操作</th>					
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$shops item=shop}>
					<tr>
						
						<!-- <td><{$agent.user_name}></td> -->
						<td><{$shop.id}></td>
						<td ><{$shop.name}></td>
						<td ><{$shop.price/100.0}></td>
						<td><{$shop.gems}></td>
						<td>
							<{if $shop.discount == 1}>
								<spen class ='green'>优惠</spen>
							<{else if $shop.discount ==0}>
								<spen class='red'>未优惠</spen>
							<{else}>
								<spen></spen>
							<{/if}>
						</td>
						<td>
							<{if $shop.state == 1}>
								<spen class ='green'>已激活</spen>
							<{else if $shop.state ==0}>
								<spen class='red'>未激活</spen>
							<{else}>
								<spen></spen>
							<{/if}>
						</td>
						<td>
							<a style="" href="javascript:void(0);"onclick="switchagent(<{$shop.id}>,'<{$shop.name}>',<{$shop.price}>,<{$shop.gems}>,<{$shop.discount}>,<{$shop.state}>)" title= "修改" ><i class="icon-pencil"></i>修改</a>
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


<div class="modal fade" id="wmyModal" tabindex="-1" role="dialog"
	aria-labelledby="myModalLabel" aria-hidden="true">
	<input type="hidden" id="shop_id" name="shop_id" value="" />
	<div class="modal-dialog" style="width: 430px;">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true">&times;</button>
				<h4 class="modal-title" id="myModalLabel">修改商城信息</h4>
			</div>
			<div class="modal-body">
				<div class="form-group">
					<label>名称: <input id= 'shop_name' class="input-xlarge" name="shop_name" type="text" value="" placeholder="请输入商品名称"/></label>
					<br/>
					<label>价格: <input id= 'shop_price' class="input-xlarge" name="shop_price" type="number" value="" max ='500' min='0' placeholder="请输入商品价格"/> </label> 
					<br/>
					<label>钻石: <input id= 'shop_gems' class="input-xlarge" name="shop_gems" type="number" value="" max ='500' min='0' placeholder="请输入钻石数量"/></label> 
					<br/>
					<!-- <label>优惠: <input id= 'shop_discount' class="input-xlarge" name="shop_discount" type="number" value="" max ='1' min='0' placeholder="请输入是否优惠"/> </label> -->
					<label>优惠:
						<select name="shop_discount" id ="shop_discount">
							<option value="0">未优惠</option>
							<option value="1">优惠</option>
						</select>
					</label>

					<br/>
					<label>状态: 
						<select name="shop_state" id ="shop_state">
							<option value="0">未激活</option>
							<option value="1">已激活</option>
						</select>
					 </label>
				</div>
				<div class="form-group">
					<label class="col-sm-12 control-label no-padding-right">修改需谨慎,正确填写商城信息！</label>	
				</div>
				<div class="form-group">
					<div class="col-sm-9" style="height:10px;"></div>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
              	<button type="button" id="sub" class="btn btn-primary">修改</button>
			</div>
		</div>
		<!-- /.modal-content -->
	</div>
	<!-- /.modal -->
</div>

<{include file="ace/footer.tpl" }>

<script type="text/javascript">
	function switchagent(id,name,price,gems,discount,state)
	{	console.log("id:",id,"name:",name,"price:",price,"gems:",gems,"discount:",discount,"state:",state);
		$("#shop_id").attr("value", id);
		$("#shop_name").attr("value", name);
		$("#shop_price").attr("value", price/100.0);
		$("#shop_gems").attr("value", gems);
		$("#shop_discount option:eq("+discount+")").attr("selected", true);
		$("#shop_state option:eq("+state+")").attr("selected", true);
		$("#wmyModal").modal('show');
	}
	
	function reject()
	{
		var shop_id = $("#shop_id").val();	
		var shop_name =$("#shop_name").val();
		var shop_price = $("#shop_price").val();
		var shop_gems =$("#shop_gems").val();
		var shop_discount = $("#shop_discount").val();	
		var shop_state =$("#shop_state").val();
		console.log("id:",shop_id,"name:",shop_name,"price:",shop_price,"gems:",shop_gems,"discount:",shop_discount,"state:",shop_state);
		var param = {
				method : 'shop_edit',
				shop_id : shop_id,
				shop_name:shop_name,
				shop_price:shop_price*100.0,
				shop_gems:shop_gems,
				shop_discount:shop_discount,
				shop_state:shop_state
			};
		
		$.post('shop.php',
				param,
				function(res) {
					if (typeof (res) === 'string') {
						res = JSON.parse(res);
					}
					
					if(res.status==1)
					{
						$("#wmyModal").modal('hide');
						alert("修改成功");
						window.location.href="/panel/shop.php";
					}
							
		});
	}
	
	$(document).ready(function(){
		$('#sub').on("click",function () {
			reject();
		});

	});
	
</script>
<script type="text/javascript">
	$("#user_name").keyup(function() {
		var tmptxt = $(this).val();
		if (tmptxt != '0')
			$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).bind("paste", function() {
		var tmptxt = $(this).val();
		$(this).val(tmptxt.replace(/\D|^0/g, ''));
	}).css("ime-mode", "disabled");
	
</script>