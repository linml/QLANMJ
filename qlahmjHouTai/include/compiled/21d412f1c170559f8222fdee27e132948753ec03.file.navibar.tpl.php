<?php /* Smarty version Smarty-3.1.15, created on 2018-09-19 21:01:47
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\ace\navibar.tpl" */ ?>
<?php /*%%SmartyHeaderCode:76205ba23aab202ce7-90541426%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '21d412f1c170559f8222fdee27e132948753ec03' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\ace\\navibar.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '76205ba23aab202ce7-90541426',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'isMobile' => 0,
    'user_info' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ba23aab21e267_28202268',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ba23aab21e267_28202268')) {function content_5ba23aab21e267_28202268($_smarty_tpl) {?>	<body class="no-skin">
		<div id="navbar" class="navbar navbar-default">
			<script type="text/javascript">
				try{ace.settings.check('navbar' , 'fixed')}catch(e){}
			</script>
			<div class="navbar-container" id="navbar-container">
				<button type="button" class="navbar-toggle menu-toggler pull-left" id="menu-toggler" data-target="#sidebar">
					<span class="sr-only">Toggle sidebar</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
				<div class="navbar-header pull-left">
					<a href="<?php echo @constant('ADMIN_URL');?>
/panel/index.php" class="navbar-brand">
						<small>
							<i class="fa fa-leaf"></i>
							<?php echo @constant('ADMIN_TITLE');?>

						</small>
					</a>
				</div>
				<?php if (!$_smarty_tpl->tpl_vars['isMobile']->value) {?>
				<div class="navbar-buttons navbar-header pull-right" role="navigation" data-show='pc'>
					<ul class="nav ace-nav">
						<li class="light-blue">
							<a data-toggle="dropdown" href="#" class="dropdown-toggle">
								<img class="nav-user-photo" src="<?php echo @constant('ADMIN_URL');?>
/assets/avatars/user.jpg" alt="<?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_name'];?>
's Photo" />
								<span class="user-info">
									<small>欢迎,</small>
									<?php echo $_smarty_tpl->tpl_vars['user_info']->value['user_name'];?>

								</span>
								<i class="ace-icon fa fa-caret-down"></i>
							</a>
							<ul class="user-menu dropdown-menu-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
								<li>
									<a href="<?php echo @constant('ADMIN_URL');?>
/panel/setting.php">
										<i class="ace-icon fa fa-cog"></i>
										设置
									</a>
								</li>
								<li>
									<a href="<?php echo @constant('ADMIN_URL');?>
/panel/profile.php">
										<i class="ace-icon fa fa-user"></i>
										我的账号
									</a>
								</li>
								<li class="divider"></li>
								<li>
									<a href="<?php echo @constant('ADMIN_URL');?>
/panel/logout.php">
										<i class="ace-icon fa fa-power-off"></i>
										登出
									</a>
								</li>
							</ul>
						</li>
					</ul>
				</div>
				<?php }?>
			</div><!-- /.navbar-container -->
		</div><?php }} ?>
