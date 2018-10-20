<!doctype html>
<html>
<head>
<meta http-equiv="x-ua-compatible" content="IE=edge">
<meta name="renderer" content="webkit">
<meta charset="UTF-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="viewport"
	content="minimal-ui,width=device-width,initial-scale=1,maximum-scale=1,minimum-scale=1,user-scalable=no">
<meta name="apple-mobile-web-app-capable" content="yes">
<meta name="apple-mobile-web-app-status-bar-style" content="white">
<meta name="format-detection" content="telephone=no">
<link rel="stylesheet" href="/assets/sharedownload/assets/stylesheets/091c12ae.download.css">
<script type="text/javascript" charset="utf-8">
	startTime = new Date();
</script>
<style type="text/css">
<!--
.STYLE1 {
	font-size: 24px
}
-->
</style>
<script src="<{$smarty.const.ADMIN_URL}>/assets/js/jquery.2.1.1.min.js"></script>
<style type="text/css">
	*{margin:0; padding:0;}
	a{text-decoration: none;}
	.img{width: 100%; height: auto;}
	.weixin-tip{display: none; position: fixed; left:0; top:0; bottom:0; background: white ; filter:alpha(opacity=80);  height: 100%; width: 100%; z-index: 100;}
	.weixin-tip p{text-align: center; margin-top: 10%; padding:0 5%;}
	</style>
</head>
<body class="">

	<div class="masklayer" id="MaskLayer" style="display: none"></div>
	<span class="pattern left"><img
		src="/assets/sharedownload/images/download_pattern_left.png"></span>
	<span class="pattern right"><img
		src="/assets/sharedownload/images/download_pattern_right.png"></span>
	<div class="out-container">
		<div class="main">
			<header itemscope itemtype="http://schema.org/SoftwareApplication">
				<span style="display: none;" itemprop="description"></span> <span
					style="display: none;" itemprop="url"></span> <span
					style="display: none;" itemprop="operatingSystem"></span> <span
					style="display: none;" itemprop="name"></span>
				<div class="table-container">
					<div class="cell-container">
						<div class="app-brief">
							<div class="icon-container wrapper">
								<i class="icon-icon_path bg-path"></i>
								<!--              <span class="icon" >
-->
								<img width="230" height="230"
									src="/assets/sharedownload/images/logo.png">
								<!--              </span>
-->
								<!--<span class="qrcode">
                <canvas width="200" height="200" style="display: none;"></canvas>
				<img alt="Scan me!" src="二维码地址" style="display: block;">				
              </span>-->
							</div>
							<p class="release-type wrapper">&nbsp;</p>
							<h1 class="name wrapper">
								<span class="icon-warp"> <!--               <i class="icon-android"></i>
--> &nbsp;<{$DOWNLOAD_NAME}>
								</span>
							</h1>
							<!--<p class="scan-tips">
			扫描二维码下载<br>或用手机浏览器输入这个网址:&nbsp;&nbsp;
			<span class="text-black">https://fir.im/ph98</span>
			</p>-->
							<!--            <div class="release-info">
			  <p><span itemprop="softwareVersion">1.0 (Build 1)
                - 28.03 MB</span></p>
			  <p>更新于: <span itemprop="datePublished">2017-05-09 08:16</span></p>
            </div>
-->
							<div id="actions" class="actions type-android">
								<button onclick="toHref('<{$DOWNLOAD_AD}>')">安卓下载</button>
							</div>
							<div id="actions" class="actions type-android">
								<button  onclick="toHref('<{$DOWNLOAD_IOS}>')">苹果下载</button>
							</div>
						</div>
						<!-- NOTE: 统计APP -->
						<div class="popularize-section section" id="popularize-container">
							<div class="label">推荐应用</div>
							<div class="popularize-list" id="popularize-list"></div>
						</div>
					</div>
				</div>
			</header>
			<!-- Release list -->
			<!--<div class="releases-section section type">
      <h2>历史版本</h2>
      <div class="release-view last">
        <div class="qrcode">
          <i class="icon-qrcode"></i>
          <div class="popup">
            <div class="inner release-qrcode" data-release="58f6f0c4ca87a82f78000554" title=""><canvas width="180" height="180" style="display: none;"></canvas><img alt="Scan me!" src="图片地址" style="display: block;"></div>
          </div>
        </div>
        <div class="download-btn" onClick="FIR.install('58f6f0c4ca87a82f78000554')">
          <i></i>
        </div>
        <div class="version-info">
          <p class="version"><b>1.0 (Build 1)</b></p>
          <div class="extra-info">
            <p class=""><i class="icon-calendar"></i>
              <span>文件大小: 21.02 MB</span></p>
            <p class=""> <i class="icon-apple"></i>
              <span>更新于: 2017-04-19 13:08</span></p>
          </div>
          <div class="changelog"><pre class="wrapper"></pre></div>
        </div>
      </div>
    </div>-->
			<!--<div class="footer">此应用在正在使用 fir.im 免费内测服务，
	  <a href="http://account.fir.im/users/sign_up?utm_source=fir&amp;utm_medium=link&amp;utm_campaign=short_footer&amp;utm_content=slogan">马上注册</a>
	  <a class="one-key-report" href="javascript:;">举报!</a></div>-->
		</div>
	</div>
	<!--<div class="app_bottom_fixed">
      <a  href="#">
        <img src="https://pro-icon-qn.fir.im/dayuan9">
      </a>
</div>-->

	
	
	<div class="weixin-tip">
		
			<img class="img" src="/assets/sharedownload/images/tips.png" alt="微信打开"/>
	
	</div>
	<script type="text/javascript">
        $(window).on("load",function(){
        	
	        var winHeight = $(window).height();
			
			
			
			if(isWeixin){
				$(".weixin-tip").css("height",winHeight);
	            $(".weixin-tip").show();
			}
			
			$(".weixin-tip").click(function(){
				$(".weixin-tip").hide();
				 
				 });
        });
        function is_weixin() {
		    var ua = navigator.userAgent.toLowerCase();
		    if (ua.match(/MicroMessenger/i) == "micromessenger") {
		        return true;
		    } else {
		        return false;
		    }
		}
        var isWeixin = is_weixin();
        function toHref(url) {
        	if (isWeixin) {
        		 $(".weixin-tip").show();
        		
        		
        	} else {
        		window.location.href = url
        	}
        }
	</script>

</body>
</html>
