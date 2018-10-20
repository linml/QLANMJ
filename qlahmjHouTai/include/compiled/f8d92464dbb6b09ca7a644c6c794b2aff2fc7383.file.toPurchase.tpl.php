<?php /* Smarty version Smarty-3.1.15, created on 2018-08-23 18:19:43
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toPurchase.tpl" */ ?>
<?php /*%%SmartyHeaderCode:246365b616ce5949cb6-48520789%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'f8d92464dbb6b09ca7a644c6c794b2aff2fc7383' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toPurchase.tpl',
      1 => 1535015020,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '246365b616ce5949cb6-48520789',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b616ce5997ec2_37980822',
  'variables' => 
  array (
    'levelData' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b616ce5997ec2_37980822')) {function content_5b616ce5997ec2_37980822($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<div class="mt60">
<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg2.png);">
    <a href="javascript:history.back(-1)" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">我要进货</div>
</div>
<div class="box pa10">
  <!-- 金额 -->
  <div class="bg1 ov">
    <table class="table_2">
      <tr>
        <td>3000钻</td>
        <td class="current">5000钻</td>
        <td>10000钻</td>
      </tr>
      <tr>
        <td>15000钻</td>
        <td>20000钻</td>
        <td>30000钻</td>
      </tr>
    </table>
  </div><!-- #金额 -->

  <div class="bg1 mt10"> 
    <ul class="fz14 list_1">
      <li class="flex_box">
        <span>我的代理级别：</span>
        <span class="item tar fwb cor_1"><?php echo $_smarty_tpl->tpl_vars['levelData']->value['name'];?>
</span>
      </li>
      <li class="flex_box">
        <span>专享进钻折扣：</span>
        <span class="item tar fwb cor_1"><?php echo (1-$_smarty_tpl->tpl_vars['levelData']->value['discount'])*10;?>
折</span>
      </li>
      <li class="flex_box">
        <span>支付金额：</span>
        <span class="item tar fwb cor_5" id="discountMoney"><?php echo floor(500*(1-$_smarty_tpl->tpl_vars['levelData']->value['discount']));?>
元</span>
      </li>
    </ul>
  </div><!-- #bg1 -->

  <p class="flex_box mt20">
    <a href="/agentCenter/gemsrecord.php" title="" class="btn_2 item mr10">进钻记录</a>
    <span class="btn_3 item" id="toWxpay">微信支付</span>
  </p>
<br>
  <ul class="lh22 cor_2 fz14 mt10">
    <li>1、支付成功后，系统将发货至你的代理库存(不是游戏ID哦)。</li>
    <li>2、进货后的钻石可销售给绑定的玩家。</li>
    <li>3、请严格按照商城售钻比例进行销售，详情请参考充钻页面。</li>
  </ul>
</div>
</div>

<script type="text/javascript">
  $(function(){
      $('.table_2 td').click(function(){
          $('.table_2 td').removeClass('current');
          $(this).addClass('current');
          $.ajax({
            url: 'purchase.php',
            type: 'POST',
            dataType: '',
            data: {method: 'getDicountDiamond','diamond':parseInt($(this).text().substring(-1)),'discount':<?php echo $_smarty_tpl->tpl_vars['levelData']->value['discount'];?>
},
            success:function(data){
              $('#discountMoney').text(data+"元");
            },
            error:function(err) {
            
            }
          });  
      })

      $("#toWxpay").click(function(event) {
          window.location.href = "../pay/paymentConfirmation.php?money="+parseInt($('#discountMoney').text().substring(-1));
      });

      
  })
</script>
<?php }} ?>
