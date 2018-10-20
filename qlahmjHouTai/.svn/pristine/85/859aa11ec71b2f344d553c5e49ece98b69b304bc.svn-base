<{include file = "simple_header.tpl"}>
<link rel="stylesheet" type="text/css" href="<{$smarty.const.ADMIN_URL}>/assets/css/home.css">
	<div onclick="downLoad()" class="absolute download">
		<img src="/assets/img/download.png" />
	</div>
<script src="<{$smarty.const.ADMIN_URL}>/assets/js/ymq_flexible.js" ></script>
	<script>
		var swiper = new Swiper('.swiper-container', {
			slidesPerView: 1.1875,
			centeredSlides: false,
			spaceBetween: 10
		});
		function downLoad(){
			var u = navigator.userAgent;
			var isAndroid = u.indexOf('Android') > -1 || u.indexOf('Adr') > -1; //android终端
			var isiOS = !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/); //ios终端
			if(isiOS) {
				window.location.href = "https://fir.im/qlahmjios";//"http://fir.im/lcap";   //ios链接
			} else {
				window.location.href = "https://fir.im/ahmjandroid"   //安卓链接
			}
		}
	</script>
</html>
