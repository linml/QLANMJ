<?php /* Smarty version Smarty-3.1.15, created on 2018-09-13 11:59:00
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toSendMoney.tpl" */ ?>
<?php /*%%SmartyHeaderCode:257105b6106e3968165-96152947%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'f72cec25889af470561ae53ccae5d1e6baab0762' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toSendMoney.tpl',
      1 => 1536212458,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '257105b6106e3968165-96152947',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b6106e39ae671_93876214',
  'variables' => 
  array (
    'gagentid' => 0,
    'diamond' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b6106e39ae671_93876214')) {function content_5b6106e39ae671_93876214($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<div class="pdlr20">
<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg.png);">
    <a href="/agentCenter/agents.php" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">代理充值</div>
</div>

<div class="send_wrap" style="margin: 20% auto">

    <div class="">
        <form action="" class="form-horizontal" method="POST">
            <div class="send_item1 boxShadowA relative borderBox">
                <div>代理ID</div>
                <div class="select_item controls absolute" style="top:10px">
                    <span class="c_ff5d20 ft25"><?php echo $_smarty_tpl->tpl_vars['gagentid']->value;?>
</span>
                    <input type="hidden" name="gagentid" value="<?php echo $_smarty_tpl->tpl_vars['gagentid']->value;?>
"/>
                </div>
            </div>
    
            <div class="row-fluid">
                <div class="send_item1 boxShadowA relative borderBox">
                    <div>钻石数量：</div>
                    <div class="controls select_item controls absolute" style="height: 100%">
                        <input id="diamondnum" type="text" class="m-wrap inputStyle" name="diamondCount" id="chargecount" required="true" placeholder="请输入充值的数量" min="0" style="height: 100%">
                    </div>
                </div>

                <div class="lH_2">
                    <div>当前库存：<span id="agentCount" class="c_ff5d20"><?php echo $_smarty_tpl->tpl_vars['diamond']->value;?>
</span>颗</div>
                </div>
            </div>
            <div>
                <button id="save" class="send_btn_save bg_btn1 inputStyle">立即充值</button>
            </div>
            <p class="c_999 send_hint">提示：充值成功后，代理商库存将增加，我的库存会减少。</p>
        </form>
    </div>

    <!-- END PAGE -->

</div>
</div>
<script type="text/javascript">
    $('#diamondnum').on('keyup',function(){
        var  diamondnum = $('#diamondnum').val()
        var reg = /^\+?[1-9][0-9]*$/;
        console.log(reg.test(diamondnum))
        if(!reg.test(diamondnum)){
            $('#diamondnum').attr('value','')
            return
        }
    })
        

</script>

<?php }} ?>
