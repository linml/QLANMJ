<!DOCTYPE html>
<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title><{$page_title}> - <{$smarty.const.ADMIN_TITLE}> - Powered by wx!</title>
		<meta name="description" content="overview &amp; stats" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/css/bootstrap.min.css" />
		 <!-- <link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/lib/bootstrap/css/bootstrap.css"> -->
		<link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/font-awesome/4.2.0/css/font-awesome.min.css" />

		<!-- page specific plugin styles -->
		<!-- text fonts -->
		<!-- <link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/fonts/fonts.googleapis.com.css" /> -->
		<!-- ace styles -->
		<link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/css/ace.min.css" class="ace-main-stylesheet" id="main-ace-style" />
		<!--[if lte IE 9]>
			<link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/css/ace-part2.min.css" class="ace-main-stylesheet" />
		<![endif]-->
		<!--[if lte IE 9]>
		  <link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/css/ace-ie.min.css" />
		<![endif]-->
		<!-- inline styles related to this page -->
		<!-- ace settings handler -->
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/ace-extra.min.js"></script>
		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->
		<!--[if lte IE 8]>
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/html5shiv.min.js"></script>
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/respond.min.js"></script>
		<![endif]-->
		<!-- basic scripts -->
		<!--[if !IE]> -->
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/jquery.2.1.1.min.js"></script>
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/jquery.cityselect.js"></script>	
		<!-- <![endif]-->
		<!--[if IE]>
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/jquery.1.11.1.min.js"></script>
		<![endif]-->
		<!--[if !IE]> -->
		<script type="text/javascript">
			window.jQuery || document.write("<script src='<{$smarty.const.ADMIN_URL}>/assets/js/jquery.min.js'>"+"<"+"/script>");
		</script>
		<!-- <![endif]-->
		<!--[if IE]>
		<script type="text/javascript">
		window.jQuery || document.write("<script src='<{$smarty.const.ADMIN_URL}>/assets/js/jquery1x.min.js'>"+"<"+"/script>");
		</script>
		<![endif]-->
		<script type="text/javascript">
			if('ontouchstart' in document.documentElement) document.write("<script src='<{$smarty.const.ADMIN_URL}>/assets/js/jquery.mobile.custom.min.js'>"+"<"+"/script>");
		</script>
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/bootstrap.min.js"></script>
		<!-- page specific plugin scripts -->
		<!--[if lte IE 8]>
		  <script src="<{$smarty.const.ADMIN_URL}>/assets/js/excanvas.min.js"></script>
		<![endif]-->
		<!-- ace scripts -->
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/ace-elements.min.js"></script>
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/ace.min.js"></script>
		<link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/css/jquery-ui.css" />
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/jquery-ui.min.js"></script>
		<link rel="stylesheet" href="<{$smarty.const.ADMIN_URL}>/assets/css/default/os.css" />
		<script src="<{$smarty.const.ADMIN_URL}>/assets/js/bootbox.min.js"></script>
		<script type="text/javascript">
			jQuery(function($){  
		    $.datepicker.regional['zh-CN'] = {  
		        closeText: '关闭',  
		        prevText: '<上月',  
		        nextText: '下月>',  
		        currentText: '今天',  
		        monthNames:['一月','二月','三月','四月','五月','六月',  
		        '七月','八月','九月','十月','十一月','十二月'],  
		        monthNamesShort:['一','二','三','四','五','六',  
		        '七','八','九','十','十一','十二'],  
		        dayNames:['星期日','星期一','星期二','星期三','星期四','星期五','星期六'],  
		        dayNamesShort:['周日','周一','周二','周三','周四','周五','周六'],  
		        dayNamesMin:['日','一','二','三','四','五','六'],  
		        weekHeader: '周',  
		        dateFormat: 'yy-mm-dd',  
		        firstDay: 1,  
		        isRTL: false,  
		        showMonthAfterYear: true,  
		        yearSuffix: '年'};  
		    $.datepicker.setDefaults($.datepicker.regional['zh-CN']);  
		});
		</script>
	</head>