<?php /* Smarty version Smarty-3.1.15, created on 2018-10-10 12:17:43
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\agentLogin.tpl" */ ?>
<?php /*%%SmartyHeaderCode:265725bbd6f57606771-35992587%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '5476328880ca0d490d33cfdd0271c3e41def193d' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\agentLogin.tpl',
      1 => 1536109910,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '265725bbd6f57606771-35992587',
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
  'unifunc' => 'content_5bbd6f57650b00_78961900',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5bbd6f57650b00_78961900')) {function content_5bbd6f57650b00_78961900($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>



<style>
    html{
        height:100%;
    }
    body{
        background:#ffffff !important;
        height:100%;
    }
</style>

<!-- <?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>
 -->
<div class="N_LoginWrap">
    <form class="form-vertical login-form" action="" method="POST">
        <div class="N_LoginMain">
            <div class="N_LoginCell">
                <div class="N_LoginLogo"><img src="../../assets/images/agentCenter/loginTitle.png"></div>
                <div class="N_LoginForm">
                    <dl class="clearfix">
                        <dt class="N_Login_icon1"></dt>
                        <dd><input type="text" placeholder="请输入手机号/账号名" id="username" name="user_name" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['user_name'];?>
"></dd>
                    </dl>
                    <dl class="clearfix">
                        <dt class="N_Login_icon2"></dt>
                        <dd><input type="password" placeholder="请输入密码" id="password" name="password" value="<?php echo $_smarty_tpl->tpl_vars['_POST']->value['password'];?>
"></dd>
                    </dl>
                    <div><input type="submit" id="login" class="N_LoginSub" value="登录"></div>
                </div>
            </div>
        </div>
    </form>
</div>
<!-- <script type="text/javascript">
    $(function(){
        // var oHeight = $(document).height()
        // $(window).resize(function(){
        //     if($(document).height()<oHeight){
        //         $('.N_Footer').css('position','absolute');
        //     }else{
        //         $('.N_Footer').css('position','fixed');
        //     }
        // })
        
        var bindAndroidScroll = function(that){
            if(myApp.device.android || (myApp.device.ios && myApp.device.osVersion.split(setTimeout(function(){
                that.scrollIntoViewNeed()
            }
        },500)
    })

        $('#inputId').;on(click,function(e){
            bindAndroidScroll(this)
        })
</script> --><?php }} ?>
