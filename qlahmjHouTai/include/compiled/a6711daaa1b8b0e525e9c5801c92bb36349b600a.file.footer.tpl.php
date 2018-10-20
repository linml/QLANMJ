<?php /* Smarty version Smarty-3.1.15, created on 2018-05-28 13:02:55
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\ace\footer.tpl" */ ?>
<?php /*%%SmartyHeaderCode:189755b0b7f6fa8fad7-23832617%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'a6711daaa1b8b0e525e9c5801c92bb36349b600a' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\ace\\footer.tpl',
      1 => 1525226600,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '189755b0b7f6fa8fad7-23832617',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b0b7f6fa9b653_80271962',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b0b7f6fa9b653_80271962')) {function content_5b0b7f6fa9b653_80271962($_smarty_tpl) {?>								<!-- PAGE CONTENT ENDS -->
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
