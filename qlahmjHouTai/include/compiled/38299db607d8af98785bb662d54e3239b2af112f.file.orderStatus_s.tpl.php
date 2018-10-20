<?php /* Smarty version Smarty-3.1.15, created on 2018-08-14 17:34:17
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\orderStatus_s.tpl" */ ?>
<?php /*%%SmartyHeaderCode:36535b72940907c6c6-61771908%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '38299db607d8af98785bb662d54e3239b2af112f' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\orderStatus_s.tpl',
      1 => 1534235603,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '36535b72940907c6c6-61771908',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b729409088245_47648219',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b729409088245_47648219')) {function content_5b729409088245_47648219($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<div class="mt50">
<div class="N_Header" style="background-image:url( /assets/images/agentCenter/headerBg4.png );">
    <!-- <a href="/dlIndex.php?m=Index&c=index&a=home" class="ReturnUp">返回首页</a> -->
    <div class="ReturnUp" id="inviteAgent">返回首页</div>
    <div class="N_Header_title">订单状态</div>
</div>

<div class="box pa10 tac">
  <p class="mt20"><img src="/assets/images/agentCenter/ico_success.png" style="width:65px;" alt="成功" /></p>
  <p class="fz18 cor_1 mt10 fwb">支付成功</p>
  <div class="lh18 cor_2 fz12 mt20"> 
    <p>系统已发货至代理后台，请查收，如有延迟到账，</p>
    <p>请耐心等候或联系客服人员</p>
  </div>
  <p class="mt30"><a href="#" title="" class="btn_4">返回代理首页</a></p>

</div>
</div><?php }} ?>
