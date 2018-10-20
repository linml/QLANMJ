<!doctype html>
<html>
<head>
	<style>
		#wxtips{width:100%; height:auto; display:none;}
	</style>
	<script src="<{$smarty.const.ADMIN_URL}>/include/js/STools.js"></script>
</head>
<body>
	<div id="weixin_tip">
		<img id="wxtips" src="<{$smarty.const.ADMIN_URL}>/assets/sharedownload/images/tips.png" />
	</div>

	<script>
		if(checkBrowserType(BrowserType.WECHAT)){
			document.getElementById("wxtips").style.display="block";
		}else{
			if(checkBrowserType(BrowserType.ANDROID)) {
				window.location.href="sunstar://BBopenWithNodeJs/?roomId=<{$roomId}>";
				setTimeout(function(){ 
					window.location.href="<{$DOWNLOAD_ANDROID}>" 
				},2000);
			}else if(checkBrowserType(BrowserType.IOS)) {
				window.location.href="wx05881aa97d29c34e://?roomId=<{$roomId}>";
				setTimeout(function(){ 
					window.location.href="<{$DOWNLOAD_IOS}>" 
				},2000);
			}
		}
	</script>
</body>
</html>
