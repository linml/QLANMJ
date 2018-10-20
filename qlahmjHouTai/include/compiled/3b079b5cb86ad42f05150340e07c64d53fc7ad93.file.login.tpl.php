<?php /* Smarty version Smarty-3.1.15, created on 2018-06-04 14:34:39
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\login.tpl" */ ?>
<?php /*%%SmartyHeaderCode:85555b14cf6f844355-68271556%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '3b079b5cb86ad42f05150340e07c64d53fc7ad93' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\login.tpl',
      1 => 1523445845,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '85555b14cf6f844355-68271556',
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
  'unifunc' => 'content_5b14cf6f8bd4f3_52197625',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b14cf6f8bd4f3_52197625')) {function content_5b14cf6f8bd4f3_52197625($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<body class="simple_body"> 
  	<!--<![endif]-->
    <div class="navbar">
        <div class="navbar-inner">
            <ul class="nav pull-right"></ul>
            <a class="brand" href="<?php echo @constant('ADMIN_URL');?>
/index.php"><span class="first"></span> <span class="second"><?php echo @constant('GAME_NAME');?>
 - <?php echo @constant('ADMIN_TITLE');?>
</span></a>
        </div>
    </div>
<div>
<div class="container-fluid">	    
    <div class="row-fluid">	
    <div class="dialog" style="width:100%;max-width:400px;">
		<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>
	
        <div class="block">
            <p class="block-heading">登入</p>
            <div class="block-body">
                <form name="loginForm" method="post" action="">
                	<label>账号</label>
                    <input type="text" class="span12" name="user_name" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['user_name'];?>
" required="true" autofocus="true">
                    <label>密码</label>
                    <input type="password" class="span12" name="password" value = "<?php echo $_smarty_tpl->tpl_vars['_POST']->value['password'];?>
" required="true" >
                    <label>验证码</label>
					<input type="text" name="verify_code" class="span4" placeholder="输入验证码" autocomplete="off" required="required">
					<a href="#"><img title="验证码" id="verify_code" src="" style="vertical-align:top"></a>
					<div class="clearfix"><input type="checkbox" name="remember" value="remember-me"> 记住我 
					<span class="label label-info">一个月内不用再次登入</span>
					<!-- <a  href="register.php">注册</a> -->
                    <input type="submit" class="btn btn-primary pull-right" name="loginSubmit" value="登入"/></div>
                </form>
            </div>
        </div>
        <p class="pull-right" style=""><a href="http://osadmin.org" target="blank"></a></p>
    </div>
<script type="text/javascript">
    resetVerifyCode();
    $("#verify_code").click(function(){
    	resetVerifyCode();
    });
    function resetVerifyCode(){
        var d = new Date()
        var hour = d.getHours(); 
        var minute = d.getMinutes();
        var sec = d.getSeconds();
        var url = "<?php echo @constant('ADMIN_URL');?>
/panel/verify_code_base64.php?"+hour+minute+sec;
        $.ajax({
                type: "GET",
                url: url,
                data: { },
                //dataType: "json",
                success: function (result) {   
                    var data = 'data:image/png;base64,' + result;              
                    var image = document.getElementById('verify_code');
                    image.src = data;
                },
                error: function(XMLHttpRequest, textcode, errorThrown) {
                 alert('获取验证码失败：' + XMLHttpRequest.responseText );
                }
            });
    }
</script>

<?php echo $_smarty_tpl->getSubTemplate ("footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
