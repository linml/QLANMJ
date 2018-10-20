<{include file ="ace/header.tpl"}> 


<script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script>
      
		
		wx.config({
			debug: false,
			appId: '<{$signPackage.appId}>',
			timestamp: <{$signPackage.timestamp}>,
			nonceStr: '<{$signPackage.nonceStr}>',
			signature: '<{$signPackage.signature}>',
			jsApiList:[
			  // 所有要调用的 API 都要加到这个列表中
			    "onMenuShareAppMessage"

			]
		  });

       
        wx.ready(function () {
            // 在这里调用 API
            wx.onMenuShareAppMessage({
                title: '帮我集钻石', // 分享标题
                desc: '长按识别二维码，帮我集钻石！', // 分享描述
                link: 'http://wx.adks.cn/share/showqrcode.php?openida=<{$openida}>', // 分享链接
                imgUrl: 'http://wx.adks.cn/assets/icon.png', // 分享图标
                type: 'link', // 分享类型,music、video或link，不填默认为link
                dataUrl: '', // 如果type是music或video，则要提供数据链接，默认为空
                success: function () {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function () {
                    // 用户取消分享后执行的回调函数
                }
            });
        });
    </script>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->
<a href="/share/tuiguang.php">我也集钻石</a>
<br/>
<span>长按识别二维码，帮我集钻石</span>
<br/>
<img class="nav-user-photo" src="/assets/qrcode/<{$openida}>.png" alt="ad1's Photo">
