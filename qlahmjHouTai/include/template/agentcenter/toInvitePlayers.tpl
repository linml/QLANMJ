<{include file = "simple_header.tpl"}>

<div class="N_Header" style="background-image:url( /assets/images/agentCenter/headerBg4.png );">
    <a href="/agentCenter/home.php" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">邀请玩家</div>
</div>

<img src="<{$shareImages}>"  id ="invitePlayer" alt="">

<script>
	$(function(){
		$("#invitePlayer").toggle(function(){
			$('.N_Header').slideUp();
		},function(){
			$('.N_Header').slideDown();
		});		
	});	
</script>
