	<body class="no-skin">
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
					<a href="<{$smarty.const.ADMIN_URL}>/panel/index.php" class="navbar-brand">
						<small>
							<i class="fa fa-leaf"></i>
							<{$smarty.const.ADMIN_TITLE}>
						</small>
					</a>
				</div>
				<{if !$isMobile}>
				<div class="navbar-buttons navbar-header pull-right" role="navigation" data-show='pc'>
					<ul class="nav ace-nav">
						<li class="light-blue">
							<a data-toggle="dropdown" href="#" class="dropdown-toggle">
								<img class="nav-user-photo" src="<{$smarty.const.ADMIN_URL}>/assets/avatars/user.jpg" alt="<{$user_info.user_name}>'s Photo" />
								<span class="user-info">
									<small>欢迎,</small>
									<{$user_info.user_name}>
								</span>
								<i class="ace-icon fa fa-caret-down"></i>
							</a>
							<ul class="user-menu dropdown-menu-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
								<li>
									<a href="<{$smarty.const.ADMIN_URL}>/panel/setting.php">
										<i class="ace-icon fa fa-cog"></i>
										设置
									</a>
								</li>
								<li>
									<a href="<{$smarty.const.ADMIN_URL}>/panel/profile.php">
										<i class="ace-icon fa fa-user"></i>
										我的账号
									</a>
								</li>
								<li class="divider"></li>
								<li>
									<a href="<{$smarty.const.ADMIN_URL}>/panel/logout.php">
										<i class="ace-icon fa fa-power-off"></i>
										登出
									</a>
								</li>
							</ul>
						</li>
					</ul>
				</div>
				<{/if}>
			</div><!-- /.navbar-container -->
		</div>