<?php /* Smarty version Smarty-3.1.15, created on 2018-08-23 11:11:15
         compiled from "F:\project\qlahmjHouTai\include\template\simple_header.tpl" */ ?>
<?php /*%%SmartyHeaderCode:232655b558d37c798b3-17088304%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '6304fc77eb6d06d6c9bf0ab269bb708978eef571' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\simple_header.tpl',
      1 => 1534987035,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '232655b558d37c798b3-17088304',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b558d37ca09c7_42327939',
  'variables' => 
  array (
    'page_title' => 0,
    'user_info' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b558d37ca09c7_42327939')) {function content_5b558d37ca09c7_42327939($_smarty_tpl) {?><!DOCTYPE html>
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
