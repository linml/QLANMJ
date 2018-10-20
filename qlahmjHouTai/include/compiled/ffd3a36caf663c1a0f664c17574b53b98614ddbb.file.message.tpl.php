<?php /* Smarty version Smarty-3.1.15, created on 2018-06-09 15:40:34
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\message.tpl" */ ?>
<?php /*%%SmartyHeaderCode:253415b1b7662176e44-63208388%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'ffd3a36caf663c1a0f664c17574b53b98614ddbb' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\message.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '253415b1b7662176e44-63208388',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'type' => 0,
    'message_detail' => 0,
    'forward_url' => 0,
    'forward_title' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1b76621ccd53_08153785',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1b76621ccd53_08153785')) {function content_5b1b76621ccd53_08153785($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<body class="simple_body">
	<div class="navbar">
    	<div class="navbar-inner">
     		<ul class="nav pull-right"></ul>
          	<a class="brand" href="<?php echo @constant('ADMIN_URL');?>
/index.php"><span class="first"></span> <span class="second"><?php echo @constant('COMPANY_NAME');?>
</span></a>
        </div>
    </div>
<div>
<div class="container-fluid">	
	<div class="row-fluid">
		<div class="http-error">
			<?php if ($_smarty_tpl->tpl_vars['type']->value=="success") {?>
			<h1>成功!</h1>
			<?php } elseif ($_smarty_tpl->tpl_vars['type']->value=="error") {?>
			<h1>失败!</h1>
			<?php } else { ?>
			<h1>嗯!</h1>
			<?php }?>
			<p class="info"><?php echo $_smarty_tpl->tpl_vars['message_detail']->value;?>
</p>
			<h2>返回 <a href="<?php echo @constant('ADMIN_URL');?>
<?php echo $_smarty_tpl->tpl_vars['forward_url']->value;?>
"><?php echo $_smarty_tpl->tpl_vars['forward_title']->value;?>
</a></h2>
		</div>
	<div>	

<?php echo $_smarty_tpl->getSubTemplate ("footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
