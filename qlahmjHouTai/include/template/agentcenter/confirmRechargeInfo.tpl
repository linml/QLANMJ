<{include file = "simple_header.tpl"}>
<div class="mt50">
<div class="N_Header" style="background-image:url( /assets/images/agentCenter/headerBg4.png );">
    <a href="../agentCenter/purchase.php" class="ReturnUp">返回首页</a>
    <!-- <div class="ReturnUp" id="inviteAgent">返回首页</div> -->
    <div class="N_Header_title">订单状态</div>
</div>

<div class="box pa10 tac">
  <!-- <p class="mt20"><img src="/assets/images/agentCenter/ico_success.png" style="width:65px;" alt="成功" /></p> -->
  <p class="fz18 cor_1 mt10 fwb">区确认充值金额：</p>
  <p class="fz18 cor_1 mt10 fwb"><{$money}>(元)</p>
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
          <{$jsApiParameters}>,
          function(res){
            WeixinJSBridge.log(res.err_msg);
              if(res.err_msg=="get_brand_wcpay_request:ok"){
                  var msg = "支付成功";
                  window.location.href = "success.php";
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
</script>