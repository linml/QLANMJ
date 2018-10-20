<?php /* Smarty version Smarty-3.1.15, created on 2018-09-05 10:12:42
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toGemsRecharge.tpl" */ ?>
<?php /*%%SmartyHeaderCode:197765b601f8ab9e707-74680549%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '368ec2ab440240280884d78b42a5ec589dd17266' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toGemsRecharge.tpl',
      1 => 1535859797,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '197765b601f8ab9e707-74680549',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b601f8abe0d96_56880449',
  'variables' => 
  array (
    'userid' => 0,
    'MyAccountDiamond' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b601f8abe0d96_56880449')) {function content_5b601f8abe0d96_56880449($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<div class="pdlr20">
<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg5.png);">
    <a href="javascript:history.back(-1)" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">钻石充值</div>
    <!--<a href="/dlIndex.php?m=Index&c=toMyGameUser&a=topidusers" class="N_czMore">玩家贡献明细</a>-->
</div>

<div class="box" style="margin-top: 20%;">
  <!-- 金额 -->
  <div class="bg1 fz16 pa15 bs1">
    <span>充值账户：</span><span class="c_ff5d20 ft25" id='userid'><?php echo $_smarty_tpl->tpl_vars['userid']->value;?>
</span>
  </div><!-- #金额 -->

  <div class="mt20">
    <p class="tle_1"><span>请选择充值钻石数</span></p>
    <input type="hidden" name="moneyType" value="" id="moneyType">
    <ul class="recharge mt20 flex_box">
      <li class="item mr15 current">
        <p class="mt20 ico_out box_pack"><i class="ico_zuan1"></i></p>
        <p class="cor_1 fz14">100钻</p>
        <!-- <p class="mt15">¥10</p> -->
      </li>
      <li class="item mr15">
        <i class="ico_tag1">加送10钻</i>
        <p class="mt20 ico_out box_pack"><i class="ico_zuan2"></i></p>
        <p class="cor_1 fz14">200钻</p>
        <!-- <p class="mt15">¥20</p> -->
      </li>
      <li class="item">
        <i class="ico_tag1">加送60钻</i>
        <p class="mt20 ico_out box_pack"><i class="ico_zuan3"></i></p>
        <p class="cor_1 fz14">500钻</p>
        <!-- <p class="mt15">¥50</p> -->
      </li>
    </ul>
    <ul class="recharge mt20 flex_box">
      <li class="item mr15">
        <i class="ico_tag1">加送150钻</i>
        <p class="mt20 ico_out box_pack"><i class="ico_zuan4"></i></p>
        <p class="cor_1 fz14">1280钻</p>
        <!-- <p class="mt15">¥128</p> -->
      </li>
      <li class="item mr15">
        <i class="ico_tag1">加送300钻</i>
        <p class="mt20 ico_out box_pack"><i class="ico_zuan5"></i></p>
        <p class="cor_1 fz14">2490钻</p>
        <!-- <p class="mt15">¥249</p> -->
      </li>
      <li class="item">
        <i class="ico_tag1">加送600钻</i>
        <p class="mt20 ico_out box_pack"><i class="ico_zuan6"></i></p>
        <p class="cor_1 fz14">4980钻</p>
        <!-- <p class="mt15">¥498</p> -->
      </li>
    </ul>
  </div>

  <p class="mt20">当前库存:<?php echo (($tmp = @$_smarty_tpl->tpl_vars['MyAccountDiamond']->value)===null||$tmp==='' ? 0 : $tmp);?>
颗</p>

  <p class="mt20">
    <a href="javascript:void(0);" class="btn_5" id="payment">代理充值</a>
  </p>

  <ul class="lh18 cor_2 fz12 mt20 tac">
    <li>本页面为七乐互娱为您服务，请您放心使用，</li>
    <li>如有延迟到账，请耐心等待。</li>
  </ul>

</div>
</div>
<script type="text/javascript" src="<?php echo @constant('ADMIN_URL');?>
/assets/js/zepto.min.js"></script>
<script type="text/javascript">
$(function(){
    $('#moneyType').val($(".recharge li.current").children("p:last-child").text().substring(1));
    $('.recharge li').click(function(){
        $('.recharge li').removeClass('current');
        $(this).addClass('current');
        // $('#payment').text('确认支付'+ $(this).children("p:last-child").text());
        $('#moneyType').val($(this).children("p:last-child").text().substring(1));
    });
    $('#payment').click(function(){
         var userid = $('#userid').text();
         var moneyType = $('#moneyType').val();
         if(<?php echo $_smarty_tpl->tpl_vars['userid']->value;?>
!=userid) alert('页面数据被修改！');
         $.ajax({
           url: 'gemsrecharge.php',
           type: 'POST',
           dataType: '',
           data: {'method': 'playerRecharge','userid':userid,'money':moneyType},
           success:function(data){
                if(data==1){
                    alert('充值成功！');
                    window.location.href="players.php";
                }else if(data ==-1){
                    alert('充值异常！');
                }else if(data==0){
                    alert('玩家不存在或玩家非代理下级！');
                }
           },
           error:function(error) {}
         });
    });
});
</script>
<?php }} ?>
