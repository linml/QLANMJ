<?php /* Smarty version Smarty-3.1.15, created on 2018-08-23 17:48:42
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\confirmRechargeInfo.tpl" */ ?>
<?php /*%%SmartyHeaderCode:59165b72985fc75019-08803424%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '100c770eff6248b3ae1c48cb2df8524dff30bbb0' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\confirmRechargeInfo.tpl',
      1 => 1535010837,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '59165b72985fc75019-08803424',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b72985fc80ba5_75912067',
  'variables' => 
  array (
    'money' => 0,
    'jsApiParameters' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b72985fc80ba5_75912067')) {function content_5b72985fc80ba5_75912067($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<div class="mt50">
<div class="N_Header" style="background-image:url( /assets/images/agentCenter/headerBg4.png );">
    <a href="../agentcenter/purchase.php" class="ReturnUp">返回首页</a>
    <!-- <div class="ReturnUp" id="inviteAgent">返回首页</div> -->
    <div class="N_Header_title">订单状态</div>
</div>

<div class="box pa10 tac">
  <!-- <p class="mt20"><img src="/assets/images/agentCenter/ico_success.png" style="width:65px;" alt="成功" /></p> -->
  <p class="fz18 cor_1 mt10 fwb">区确认充值金额：</p>
  <p class="fz18 cor_1 mt10 fwb"><?php echo $_smarty_tpl->tpl_vars['money']->value;?>
(元)</p>
  <div class="lh18 cor_2 fz12 mt20"> 
    <p>系统已发货至代理后台，请查收，如有延迟到账，</p>
    <p>请耐心等候或联系客服人员</p>
  </div>
  <span  class="btn_3 item" onclick="callpay()">微信支付</span>
</div>
</div>

<script type="text/javascript">
      //调用微信JS api 支付
      function jsApiCall()
      {
        WeixinJSBridge.invoke(
          'getBrandWCPayRequest',
          <?php echo $_smarty_tpl->tpl_vars['jsApiParameters']->value;?>
,
          function(res){
            WeixinJSBridge.log(res.err_msg);
              if(res.err_msg=="get_brand_wcpay_request:ok"){
                  var msg = "支付成功";
                  // window.location.href = "success.php";
              }else{
                  if(res.err_msg == "get_brand_wcpay_request:cancel"){
                      var err_msg = "您取消了支付";
                  }else if(res.err_msg == "get_brand_wcpay_request:fail"){
                      var err_msg = "支付失败<br/>错误信息："+res.err_desc;
                  }else{
                      var err_msg = res.err_msg +"<br/>"+res.err_desc;
                  }
                  window.location.href="error.php";
              }
          });
      }

      function callpay()
      {
        if (typeof WeixinJSBridge == "undefined"){
            if( document.addEventListener ){
                document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
            }else if (document.attachEvent){
                document.attachEvent('WeixinJSBridgeReady', jsApiCall); 
                document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
            }
        }else{
            jsApiCall();
        }
      }
</script><?php }} ?>
