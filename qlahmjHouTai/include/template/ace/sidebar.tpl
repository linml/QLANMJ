		<div class="main-container" id="main-container">
			<script type="text/javascript">
				try{ace.settings.check('main-container' , 'fixed')}catch(e){}
			</script>
			<div id="sidebar" class="sidebar                  responsive">
				<script type="text/javascript">
					try{ace.settings.check('sidebar' , 'fixed')}catch(e){}
				</script>
				<ul class="nav nav-list">
					<li class="active">
						<a href="<{$smarty.const.ADMIN_URL}><{$content_header.menu_url}>">
							<i class="menu-icon fa fa-tachometer"></i>
							<span class="menu-text"> <{$content_header.menu_name}> </span>
						</a>
						<b class="arrow"></b>
					</li>
					<{foreach from=$sidebar item=module}>
						<{if count($module.menu_list)> 0}>
							<{if $module.module_id == $current_module_id }>
								<li class="open">
							<{else}>
								<li class="">
							<{/if}>
							<a href="#sidebar_menu_<{$module.module_id}>" class="dropdown-toggle">
								<i class="menu-icon fa <{$module.module_icon}>"></i>
								<span class="menu-text">
									<{$module.module_name}>
								</span>
								<b class="arrow fa fa-angle-down"></b>
							</a>
							<b class="arrow"></b>
							<ul class="submenu" id="sidebar_menu_<{$module.module_id}>">
								<{foreach from=$module.menu_list item=menu_list name=menu_url_list}>
								<{if $menu_list.menu_id == $content_header.menu_id }>
								<li class="active">
								<{else}>
								<li class="">
								<{/if}>
									<{if strtolower(substr($menu_list.menu_url,0,7))=='http://'}>
									<a href="<{$menu_list.menu_url}>">
									<{else}>
									<a href="<{$smarty.const.ADMIN_URL}><{$menu_list.menu_url}>">
									<{/if}>
										<i class="menu-icon fa fa-caret-right"></i>
										<{$menu_list.menu_name}>
										<b class="arrow"></b>
									</a>
									<b class="arrow"></b>
								</li>
								<{/foreach}>
							</ul>
						</li>
						<{/if}>
					<{/foreach}>
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
								<a href="#"><{$content_header.menu_name}></a>
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
								<{$content_header.module_name}>
								<small>
									<i class="ace-icon fa fa-angle-double-right"></i>
									<{$content_header.menu_name}>
								</small>
							</h1>
						</div> -->
						<!-- /.page-header -->
						<div class="row">
							<div class="col-xs-12">
								<!-- PAGE CONTENT BEGINS -->