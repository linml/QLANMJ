<?php /* Smarty version Smarty-3.1.15, created on 2018-07-23 17:10:32
         compiled from "F:\project\qlahmjHouTai\include\template\ace\footer.tpl" */ ?>
<?php /*%%SmartyHeaderCode:247375b558d789ec0f4-35306317%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '5c97e17756fa480c3eb84ec38b95c72334aa0e96' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\ace\\footer.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '247375b558d789ec0f4-35306317',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b558d789f7c87_66625151',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b558d789f7c87_66625151')) {function content_5b558d789f7c87_66625151($_smarty_tpl) {?>								<!-- PAGE CONTENT ENDS -->
							</div><!-- /.col -->
						</div><!-- /.row -->
					</div><!-- /.page-content -->
				</div>
			</div><!-- /.main-content -->
			<div class="footer">
				<div class="footer-inner">
					<div class="footer-content">
						<span class="bigger-120">
							<!-- <span class="blue bolder">客服微信号：<?php echo @constant('WeChat');?>
</span> -->
							<span class="blue bolder"><?php echo @constant('ADMIN_TITLE');?>
</span>
						</span>
					</div>
				</div>
			</div>
			<a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
				<i class="ace-icon fa fa-angle-double-up icon-only bigger-110"></i>
			</a>
		</div><!-- /.main-container -->
	</body>
</html>
<script>
$().ready(function(){

	browserRedirect();
	function browserRedirect() {
	    var sUserAgent = navigator.userAgent.toLowerCase();
	    var bIsIpad = sUserAgent.match(/ipad/i) == "ipad";
	    var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
	    var bIsMidp = sUserAgent.match(/midp/i) == "midp";
	    var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
	    var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
	    var bIsAndroid = sUserAgent.match(/android/i) == "android";
	    var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
	    var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";
	    if (!(bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM)){
	        
	    } else {
	    	//移动端页面优化处理
	    	//所有data-show属性为pc的，全部隐藏
	    	$("[data-show='pc']").each(
	    		function(){
			    	$(this).remove();
				}
			);

	    }
	}
});
</script><?php }} ?>