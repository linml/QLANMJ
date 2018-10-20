<?php /* Smarty version Smarty-3.1.15, created on 2018-06-04 14:34:39
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\simple_header.tpl" */ ?>
<?php /*%%SmartyHeaderCode:12245b14cf6f8ccef3-83785866%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'eb2ac54fee344e29cf2b5e0c391dab94a4992818' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\simple_header.tpl',
      1 => 1526453982,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '12245b14cf6f8ccef3-83785866',
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
  'unifunc' => 'content_5b14cf6f90b707_99941749',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b14cf6f90b707_99941749')) {function content_5b14cf6f90b707_99941749($_smarty_tpl) {?><!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title><?php echo $_smarty_tpl->tpl_vars['page_title']->value;?>
 - <?php echo @constant('ADMIN_TITLE');?>
</title>
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
    <script src="<?php echo @constant('ADMIN_URL');?>
/assets/lib/jquery-1.8.1.min.js" ></script>
	<script src="<?php echo @constant('ADMIN_URL');?>
/assets/js/other.js" ></script>
    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
  </head><?php }} ?>
