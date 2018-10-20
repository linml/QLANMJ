<?php /* Smarty version Smarty-3.1.15, created on 2018-04-13 20:47:14
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\message.tpl" */ ?>
<?php /*%%SmartyHeaderCode:316575ad098c298fde2-40660828%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'eabaca8520b02bfa9e5b85fa9f08ddd948da6e6a' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\message.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '316575ad098c298fde2-40660828',
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
  'unifunc' => 'content_5ad098c29b6ef9_79394959',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ad098c29b6ef9_79394959')) {function content_5ad098c29b6ef9_79394959($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


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
