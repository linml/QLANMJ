<{include file = "simple_header.tpl"}>

<body class="simple_body"> 
  	<!--<![endif]-->
    <div class="navbar">
        <div class="navbar-inner">
            <ul class="nav pull-right"></ul>
            <a class="brand" href="#"><span class="first"></span> <span class="second">代理商申请</span></a>
        </div>
    </div>
<div>
<div class="container-fluid">	    
    <div class="row-fluid">	
    <div class="dialog" style="width:100%;max-width:400px;">
		<{$osadmin_action_alert}>	
        <div class="block">
            <p class="block-heading">补充联系方式</p>
            <div class="block-body">
                <form name="loginForm" method="post" action="">
                	
<!--                     <label>玩家id</label>
                    <input type="text" class="span12" name="playerid" value = "<{$_POST.playerid}>" required="true" > -->
                    
              
				    <label>姓名</label>
					<input maxlength="10" type="text" class="span12"  name="real_name" value="<{$_POST.real_name}>" class="input-xlarge" required="true" >
				
				
				    <label>手机</label>
					<input maxlength="15" type="text" class="span12"  name="mobile" value="<{$_POST.mobile}>" class="input-xlarge" required="true"  pattern="\d{11}">
					<div class="clearfix">
					<input type="submit" class="btn btn-primary pull-right" name="loginSubmit" value="提交"/></div>
                </form>
            </div>
        </div>
        <p class="pull-right" style=""><a href="http://osadmin.org" target="blank"></a></p>
    </div>
<script type="text/javascript">
$("#verify_code").click(function(){
	var d = new Date()
	var hour = d.getHours(); 
	var minute = d.getMinutes();
	var sec = d.getSeconds();
    $(this).attr("src","<{$smarty.const.ADMIN_URL}>/panel/verify_code_cn.php?"+hour+minute+sec);
});
</script>

<{include file = "footer.tpl"}>