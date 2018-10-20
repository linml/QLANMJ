<?php /* Smarty version Smarty-3.1.15, created on 2018-10-10 12:17:43
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\simple_footer.tpl" */ ?>
<?php /*%%SmartyHeaderCode:42485bbd6f5746c499-61938035%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'f426338c2e3f2ffbd4ee21c228b928c198763319' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\simple_footer.tpl',
      1 => 1533975562,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '42485bbd6f5746c499-61938035',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5bbd6f574a2fa5_02725231',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5bbd6f574a2fa5_02725231')) {function content_5bbd6f574a2fa5_02725231($_smarty_tpl) {?>
<div class="N_Footer fixed-bottom">
    <ul>
        <li id="home"><a href="/agentCenter/home.php"><i class="HomeIcon"></i>首页</a></li>
        <li id="players"><a href="/agentCenter/players.php"><i class="GameIcon"></i>玩家</a></li>
        <li id="agents"><a href="/agentCenter/agents.php"><i class="AgencyIcon"></i>代理</a></li>
        <li id="friendscircle"><a href="/agentCenter/friendscircle.php"><i class="MoneyIcon"></i>亲友圈</a></li>
        <li id="mine"><a href="/agentCenter/mine.php"><i class="MyIcon"></i>我的</a></li>
    </ul>
</div>
<script type="text/javascript">
	$(function(){
     //获取location的地址
     let href = window.location.href;

     //获取所有li元素
     let lis = $('.N_Footer ul li')
     //遍历所有的li，拿id 跟当前的url对比，
     for(let i =0;i<lis.size();i++){

        let liObj = lis.eq(i);
        let liId = liObj.attr('id') || '';
        // console.log('id:'+liId,);
        if(href.indexOf(liId)>0){
          // console.log('xuanzhong:'+liId)
          liObj.addClass('on').siblings().removeClass();
          break;
        }
     }
  })
</script>
<!-- <script type="text/javascript">
    $(function(){
        var oHeight = $(document).height();
        $(window).resize(function(){
            if($(document).height()< oHeight){
                // $('.N_Footer').css('height','0');   
            }else{
                $('.N_Footer').css('position','fixed');
            }
        })
    })
</script>
 --><?php }} ?>
