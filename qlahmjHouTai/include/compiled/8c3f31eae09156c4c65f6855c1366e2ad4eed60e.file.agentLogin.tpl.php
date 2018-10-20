<?php /* Smarty version Smarty-3.1.15, created on 2018-07-23 16:30:27
         compiled from "F:\project\qlahmj.admin\include\template\agentLogin.tpl" */ ?>
<?php /*%%SmartyHeaderCode:127465b557f6c5130e3-02277167%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '8c3f31eae09156c4c65f6855c1366e2ad4eed60e' => 
    array (
      0 => 'F:\\project\\qlahmj.admin\\include\\template\\agentLogin.tpl',
      1 => 1532331025,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '127465b557f6c5130e3-02277167',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b557f6c570cf2_68613452',
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b557f6c570cf2_68613452')) {function content_5b557f6c570cf2_68613452($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<style>
    html{
        height:100%;
    }
    body{
        background:#ffffff !important;
        height:100%;
    }
</style>
<div class="N_LoginWrap">
    <form class="form-vertical login-form" action="toLogin;JSESSIONID=9da86052-2d3c-43b5-b116-6008440a7549?t=111222#">
        <div class="N_LoginMain">
            <div class="N_LoginCell">
                <div class="N_LoginLogo"><img src="../../assets/images/agentCenter/loginTitle.png"></div>
                <div class="N_LoginForm">
                    <dl class="clearfix">
                        <dt class="N_Login_icon1"></dt>
                        <dd><input type="text" placeholder="请输入手机号/账号名" id="username" name="username" value=""></dd>
                    </dl>
                    <dl class="clearfix">
                        <dt class="N_Login_icon2"></dt>
                        <dd><input type="password" placeholder="请输入密码" id="password" name="password"></dd>
                    </dl>
                    <div><input type="button" id="login" class="N_LoginSub" value="登录"></div>
                </div>
            </div>
        </div>
    </form>
    <!-- <a href="/dlIndex.php?m=Index&c=toaddagent&a=index" class="N_resLinks">注册代理</a> -->
</div>

<!-- <?php echo $_smarty_tpl->getSubTemplate ("footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
 --><?php }} ?>
