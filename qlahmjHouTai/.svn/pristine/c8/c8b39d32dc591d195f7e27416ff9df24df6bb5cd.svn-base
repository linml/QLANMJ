<?php /* Smarty version Smarty-3.1.15, created on 2018-07-23 13:06:40
         compiled from "F:\project\qlahmj.admin\include\template\ace\sidebar.tpl" */ ?>
<?php /*%%SmartyHeaderCode:244285b555450174597-55367976%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '23c208f63b1e671c27544bf0a9bbb4f9e1a02df6' => 
    array (
      0 => 'F:\\project\\qlahmj.admin\\include\\template\\ace\\sidebar.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '244285b555450174597-55367976',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'content_header' => 0,
    'sidebar' => 0,
    'module' => 0,
    'current_module_id' => 0,
    'menu_list' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b5554502762d4_93430919',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b5554502762d4_93430919')) {function content_5b5554502762d4_93430919($_smarty_tpl) {?>		<div class="main-container" id="main-container">
			<script type="text/javascript">
				try{ace.settings.check('main-container' , 'fixed')}catch(e){}
			</script>
			<div id="sidebar" class="sidebar                  responsive">
				<script type="text/javascript">
					try{ace.settings.check('sidebar' , 'fixed')}catch(e){}
				</script>
				<ul class="nav nav-list">
					<li class="active">
						<a href="<?php echo @constant('ADMIN_URL');?>
<?php echo $_smarty_tpl->tpl_vars['content_header']->value['menu_url'];?>
">
							<i class="menu-icon fa fa-tachometer"></i>
							<span class="menu-text"> <?php echo $_smarty_tpl->tpl_vars['content_header']->value['menu_name'];?>
 </span>
						</a>
						<b class="arrow"></b>
					</li>
					<?php  $_smarty_tpl->tpl_vars['module'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['module']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['sidebar']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['module']->key => $_smarty_tpl->tpl_vars['module']->value) {
$_smarty_tpl->tpl_vars['module']->_loop = true;
?>
						<?php if (count($_smarty_tpl->tpl_vars['module']->value['menu_list'])>0) {?>
							<?php if ($_smarty_tpl->tpl_vars['module']->value['module_id']==$_smarty_tpl->tpl_vars['current_module_id']->value) {?>
								<li class="open">
							<?php } else { ?>
								<li class="">
							<?php }?>
							<a href="#sidebar_menu_<?php echo $_smarty_tpl->tpl_vars['module']->value['module_id'];?>
" class="dropdown-toggle">
								<i class="menu-icon fa <?php echo $_smarty_tpl->tpl_vars['module']->value['module_icon'];?>
"></i>
								<span class="menu-text">
									<?php echo $_smarty_tpl->tpl_vars['module']->value['module_name'];?>

								</span>
								<b class="arrow fa fa-angle-down"></b>
							</a>
							<b class="arrow"></b>
							<ul class="submenu" id="sidebar_menu_<?php echo $_smarty_tpl->tpl_vars['module']->value['module_id'];?>
">
								<?php  $_smarty_tpl->tpl_vars['menu_list'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['menu_list']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['module']->value['menu_list']; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['menu_list']->key => $_smarty_tpl->tpl_vars['menu_list']->value) {
$_smarty_tpl->tpl_vars['menu_list']->_loop = true;
?>
								<?php if ($_smarty_tpl->tpl_vars['menu_list']->value['menu_id']==$_smarty_tpl->tpl_vars['content_header']->value['menu_id']) {?>
								<li class="active">
								<?php } else { ?>
								<li class="">
								<?php }?>
									<?php if (strtolower(substr($_smarty_tpl->tpl_vars['menu_list']->value['menu_url'],0,7))=='http://') {?>
									<a href="<?php echo $_smarty_tpl->tpl_vars['menu_list']->value['menu_url'];?>
">
									<?php } else { ?>
									<a href="<?php echo @constant('ADMIN_URL');?>
<?php echo $_smarty_tpl->tpl_vars['menu_list']->value['menu_url'];?>
">
									<?php }?>
										<i class="menu-icon fa fa-caret-right"></i>
										<?php echo $_smarty_tpl->tpl_vars['menu_list']->value['menu_name'];?>

										<b class="arrow"></b>
									</a>
									<b class="arrow"></b>
								</li>
								<?php } ?>
							</ul>
						</li>
						<?php }?>
					<?php } ?>
				</ul><!-- /.nav-list -->
				<div class="sidebar-toggle sidebar-collapse" id="sidebar-collapse">
					<i class="ace-icon fa fa-angle-double-left" data-icon1="ace-icon fa fa-angle-double-left" data-icon2="ace-icon fa fa-angle-double-right"></i>
				</div>
				<script type="text/javascript">
					try{ace.settings.check('sidebar' , 'collapsed')}catch(e){}
				</script>
			</div>
			<div class="main-content">
				<div class="main-content-inner">
					<div class="breadcrumbs" id="breadcrumbs" data-show='pc'>
						<script type="text/javascript">
							try{ace.settings.check('breadcrumbs' , 'fixed')}catch(e){}
						</script>
						<ul class="breadcrumb">
							<li>
								<i class="ace-icon fa fa-home home-icon"></i>
								<a href="#"><?php echo $_smarty_tpl->tpl_vars['content_header']->value['menu_name'];?>
</a>
							</li>
						</ul><!-- /.breadcrumb -->
						<!--
						<div class="nav-search" id="nav-search">
							<form class="form-search">
								<span class="input-icon">
									<input type="text" placeholder="Search ..." class="nav-search-input" id="nav-search-input" autocomplete="off" />
									<i class="ace-icon fa fa-search nav-search-icon"></i>
								</span>
							</form>
						</div>--><!-- /.nav-search -->
					</div>
					<div class="page-content">
					<!-- 	<div class="page-header" data-show='pc'>
							<h1>
								<?php echo $_smarty_tpl->tpl_vars['content_header']->value['module_name'];?>

								<small>
									<i class="ace-icon fa fa-angle-double-right"></i>
									<?php echo $_smarty_tpl->tpl_vars['content_header']->value['menu_name'];?>

								</small>
							</h1>
						</div> -->
						<!-- /.page-header -->
						<div class="row">
							<div class="col-xs-12">
								<!-- PAGE CONTENT BEGINS --><?php }} ?>
