<?php /* Smarty version Smarty-3.1.15, created on 2018-07-31 16:21:06
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\tuiguangdetail.tpl" */ ?>
<?php /*%%SmartyHeaderCode:309065b6005c7bb50c8-83669880%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'b9b822b22479601c3fca693b8ff0b47c59cdbdb8' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\tuiguangdetail.tpl',
      1 => 1533021661,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '309065b6005c7bb50c8-83669880',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b6005c7bc8944_87860342',
  'variables' => 
  array (
    'qrcodeName' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b6005c7bc8944_87860342')) {function content_5b6005c7bc8944_87860342($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header" style="background-image:url( /assets/images/agentCenter/headerBg4.png );">
    <a href="/dlIndex.php?m=Index&c=index&a=home" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">邀请玩家</div>
</div>
<div class="relative invite_game" id="select">
    <img src="/assets/images/agentCenter/invite_la_club.png" class="wp_full" id="selectbanner" >
    <img src="/assets/images/agentCenter/img1.png" class="invite_gHead_club absolute">
    <div class="absolute invite_ID_club " style="font-size:0.4rem"><span><<?php ?>?echo $eid?<?php ?>></span></div>
    <img src="/assets/qrcode/<?php echo $_smarty_tpl->tpl_vars['qrcodeName']->value;?>
.png" class="invite_qCode_club absolute">
</div>

<div class="pop">
    <div class="popMain">
        <div class="popTop"></div>
        <div class="popMiddle">
            <p>请用系统截图工具截图并分享</p>
        </div>
        <div class="popBottom">
            <span class="confirm">确认</span>
        </div>
    </div>
</div>
<?php }} ?>
