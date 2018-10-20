<?php /* Smarty version Smarty-3.1.15, created on 2018-09-19 15:17:12
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\simple_header.tpl" */ ?>
<?php /*%%SmartyHeaderCode:136355ba1e9e89a9bc0-66492161%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '5b970ee9ebdcfd05dae735c66d8edca615f6621a' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\simple_header.tpl',
      1 => 1534987035,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '136355ba1e9e89a9bc0-66492161',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'page_title' => 0,
    'user_info' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ba1e9e89e06d3_48896392',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ba1e9e89e06d3_48896392')) {function content_5ba1e9e89e06d3_48896392($_smarty_tpl) {?><!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title><?php echo $_smarty_tpl->tpl_vars['page_title']->value;?>
 - <?php echo @constant('ADMIN_TITLE');?>
</title>
    <!-- <meta http-equiv="refresh" content="20">  -->
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="stylesheet" href="<?php echo @constant('ADMIN_URL');?>
/assets/lib/bootstrap/css/bootstrap.css">
    <link rel="stylesheet" href="<?php echo @constant('ADMIN_URL');?>
/assets/stylesheets_<?php if ($_smarty_tpl->tpl_vars['user_info']->value) {?><?php echo $_smarty_tpl->tpl_vars['user_info']->value['template'];?>
<?php } else { ?>default<?php }?>/theme.css">
    <link rel="stylesheet" href="<?php echo @constant('ADMIN_URL');?>
/assets/lib/font-awesome/css/font-awesome.css">
    <link rel="stylesheet" href="<?php echo @constant('ADMIN_URL');?>
/assets/css/style-common.css">
    <link rel="stylesheet" href="<?php echo @constant('ADMIN_URL');?>
/assets/lib/dropload/dropload.css">
    <!-- 进货css -->
    <link rel="stylesheet" type="text/css" href="<?php echo @constant('ADMIN_URL');?>
/assets/css/style/mobile-basic.css">
    <link rel="stylesheet" type="text/css" href="<?php echo @constant('ADMIN_URL');?>
/assets/css/style/css.css">
    <link rel="stylesheet" type="text/css" href="<?php echo @constant('ADMIN_URL');?>
/assets/css/style/Mdate.css">
    
    <link rel="stylesheet" type="text/css" href="<?php echo @constant('ADMIN_URL');?>
/assets/css/swiper.min.css">
    <script src="<?php echo @constant('ADMIN_URL');?>
/assets/lib/jquery-1.8.1.min.js" ></script>
    <script src="<?php echo @constant('ADMIN_URL');?>
/assets/js/swiper.min.js" ></script>
    <script src="<?php echo @constant('ADMIN_URL');?>
/assets/js/other.js" ></script>
    <script src="<?php echo @constant('ADMIN_URL');?>
/assets/js/echarts.js" ></script>
    <script src="<?php echo @constant('ADMIN_URL');?>
/assets/lib/Mdate/iScroll.js"></script>
    <script src="<?php echo @constant('ADMIN_URL');?>
/assets/lib/Mdate/Mdate.js"></script>
    <script src="<?php echo @constant('ADMIN_URL');?>
/assets/lib/dropload/dropload.js"></script>



    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
  </head><?php }} ?>
