<?php /* Smarty version Smarty-3.1.15, created on 2018-05-16 15:30:02
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\register.tpl" */ ?>
<?php /*%%SmartyHeaderCode:119645afbcfeaefc0f6-28101250%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'a6a34c7cf6f4838aa0bd658519ff49f19bcc4c3f' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\register.tpl',
      1 => 1514512626,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '119645afbcfeaefc0f6-28101250',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_POST' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5afbcfeaf2ed74_02032391',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5afbcfeaf2ed74_02032391')) {function content_5afbcfeaf2ed74_02032391($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<body class="simple_body"> 
  	<!--<![endif]-->
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
    <div class="dialog">
		<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>
	
        <div class="block">
            <p class="block-heading">注册</p>
            <div class="block-body">
                <form name="loginForm" method="post" action="">
                	<label>账号</label>
                    <input type="text" class="span12" name="user_name" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['user_name'];?>
" required="true" autofocus="true">
                    <label>密码</label>
                    <input type="password" class="span12" name="password" value = "<?php echo $_smarty_tpl->tpl_vars['_POST']->value['password'];?>
" required="true" >
                    <label>确认密码</label>
                    <input type="password" class="span12" name="confirmpassword" value = "<?php echo $_smarty_tpl->tpl_vars['_POST']->value['confirmpassword'];?>
" required="true" >
                    <label>玩家id</label>
                    <input type="text" class="span12" name="playerid" value = "<?php echo $_smarty_tpl->tpl_vars['_POST']->value['playerid'];?>
" required="true" >
                    
              
				    <label>姓名</label>
					<input type="text" class="span12"  name="real_name" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['real_name'];?>
" class="input-xlarge" required="true" >
				
				
				    <label>手机</label>
					<input type="text" class="span12"  name="mobile" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['mobile'];?>
" class="input-xlarge" required="true"  pattern="\d{11}">
				
				
				    <label>微信号</label>
					<input  class="span12"  name="email" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['email'];?>
"  class="input-xlarge" required="true" >
			
                    
                    
                    
                    
                    <label>验证码</label>
					<input type="text" name="verify_code" class="span4" placeholder="输入验证码" autocomplete="off" required="required">
					<a href="#"><img title="验证码" id="verify_code" src="<?php echo @constant('ADMIN_URL');?>
/panel/verify_code_cn.php" style="vertical-align:top"></a>
					<div class="clearfix">
					<a  href="login.php">登录</a><input type="submit" class="btn btn-primary pull-right" name="loginSubmit" value="注册"/></div>
                </form>
            </div>
        </div>
        <p class="pull-right" style=""><a href="http://osadmin.org" target="blank"></a></p>
    </div>
<script type="text/javascript">
$("#verify_code").click(function(){
	var d = new Date()
	var hour = d.getHours(); 
	var minute = d.getMinutes();
	var sec = d.getSeconds();
    $(this).attr("src","<?php echo @constant('ADMIN_URL');?>
/panel/verify_code_cn.php?"+hour+minute+sec);
});
</script>

<?php echo $_smarty_tpl->getSubTemplate ("footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
