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
					<td><{$val.GameDesc}></td>
					<{if $val.gamecity == 'LIUAN'}>
					<td>六安</td>
					<{else if $val.gamecity == 'HEFEI'}>
					<td>合肥</td>
					<{else if $val.gamecity == 'FUYANG'}>
					<td>阜阳</td>
					<{else}>
					<td>未知城市</td>
					<{/if }>
					<{if $val.gametype == '1'}>
					<td>电玩游戏</td>
					<{else if $val.gametype == '2'}>
					<td>扑克牌类游戏</td>
					<{else if $val.gametype == '3'}>
					<td>麻将类游戏</td>
					<{else}>
					<td>未知游戏类型</td>
					<{/if}>
					<{if $val.gamestatus == '0'}>
					<td>运营中</td>
					<{else if $val.gamestatus == '1'}>
					<td>维护中</td>
					<{else if $val.gamestatus == '2'}>
					<td>下架</td>
					<{else}>
					<td>未知状态</td>
					<{/if}>
					<td>
						<button onclick="set('<{$val.gameid}>','<{$val.gamename}>','<{$val.GameDesc}>','<{$val.gamecity}>','<{$val.gametype}>','<{$val.gamestatus}>')">设置</button>
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
			<table id="simple-table1" class="table table-striped table-bordered table-hover">
				<tr>
					<td>游戏名称:</td>
					<td id='gamename'></td>
					<input id="gameid" type="hidden" name="">
				</tr>
				<tr>
					<td>存放目录:</td>
					<td id='gamecity'>
						<select name="gamecity" onchange="chgamecity()">
							<option value="LIUAN">六安</option>
							<option value="HEFEI">合肥</option>
							<option value="FUYANG">阜阳</option>
						</select>
					</td>
				</tr>
				<tr>
					<td>游戏标签:</td>
					<td id='gametype'>
						<select name="gametype" onchange="chgametype()">
							<option value="0">敬请期待</option>
							<option value="1">电玩游戏</option>
							<option value="2">扑克牌类游戏</option>
							<option value="3">麻将类游戏</option>
						</select>
					</td>
				</tr>
				<tr>
					<td>游戏状态:</td>
					<td id='gamestatus' onchange="chgamestatus()">
					<input type="radio" name="gamestatus" value="0">运营中
					<input type="radio" name="gamestatus" value="1">维护
					<input type="radio" name="gamestatus" value="2">下架
					</td>
				</tr>
				
				<tr>
					<td>游戏简介:</td>
					<td>
						<textarea id="GameDesc" style="width: 200px;height: 100px" required="" onchange="chGameDesc()">
							
						</textarea>
					</td>
				</tr>
			</table>
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
	function set(gameid,gamename,GameDesc,gamecity,gametype,gamestatus){
		$('#gameInfo').modal('show')
		$('#gamename').text(gamename)
		$('#gamecity').find('option[value='+gamecity+']').attr("selected","selected")
		$('#gametype').find('option[value='+gametype+']').attr("selected","selected")
		$('#GameDesc').val(GameDesc)
		$('#gameid').val(gameid)
		$('#gamestatus').find('input[value='+gamestatus+']').prop("checked","checked")

	}

	function chgamecity(){
		gameid = $('#gameid').val()
		gamecity = $('#gamecity').find('option:selected').val()
		console.log(gamecity)
		$.ajax({
			url:'gamelist.php',
			dataType:'',
			type:'POST',
			data:{
				method:'chgamecity',
				gameid:gameid,
				gamecity:gamecity
			},
			success:function(data){
				console.log(data)
				if(data == 1){
					alert("更新成功！")
					window.location.reload()
				}else{
					alert("更新失败或未做更改！")
					window.location.reload()
				}
			},
			error:function(err){

			}
		})
	}

	function chgametype(){
		gameid = $('#gameid').val()
		gametype = $('#gametype').find('option:selected').val()
		$.ajax({
			url:'gamelist.php',
			dataType:'',
			type:'POST',
			data:{
				method:'chgametype',
				gameid:gameid,
				gametype:gametype
			},
			success:function(data){
				if(data == 1){
					alert("更新成功！")
					window.location.reload()
				}else{
					alert("更新失败或未做更改！")
					window.location.reload()
				}
			},
			error:function(err){

			}
		})
	}

	function chgamestatus(){
		gameid = $('#gameid').val()
		gamestatus = $('#gamestatus').find('input:checked').val()
		console.log(gamestatus)
		$.ajax({
			url:'gamelist.php',
			dataType:'',
			type:'POST',
			data:{
				method:'chgamestatus',
				gameid:gameid,
				gamestatus:gamestatus
			},
			success:function(data){
				console.log(data)
				if(data == 1){
					alert("更新成功！")
					window.location.reload()
				}else{
					alert("更新失败或未做更改！")
					window.location.reload()
				}
			},
			error:function(err){

			}
		})
	}

	function chGameDesc(){
		gameid = $('#gameid').val()
		GameDesc  = $('#GameDesc').val()
		$.ajax({
			url:'gamelist.php',
			dataType:'',
			type:'POST',
			data:{
				method:'chGameDesc',
				gameid:gameid,
				GameDesc:GameDesc
			},
			success:function(data){
				if(data == 1){
					alert("更新成功！")
					window.location.reload()
				}else{
					alert("更新失败或未做更改！")
					window.location.reload()
				}
			},
			error:function(err){

			}
		})
	}
</script>