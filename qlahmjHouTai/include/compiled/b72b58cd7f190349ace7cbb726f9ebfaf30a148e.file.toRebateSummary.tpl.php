<?php /* Smarty version Smarty-3.1.15, created on 2018-08-13 17:56:53
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toRebateSummary.tpl" */ ?>
<?php /*%%SmartyHeaderCode:95315b602121b70a66-43704064%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'b72b58cd7f190349ace7cbb726f9ebfaf30a148e' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toRebateSummary.tpl',
      1 => 1534150611,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '95315b602121b70a66-43704064',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b602121bb30f5_10769006',
  'variables' => 
  array (
    'result' => 0,
    '_REQUEST' => 0,
    'val' => 0,
    'page_html' => 0,
    'type' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b602121bb30f5_10769006')) {function content_5b602121bb30f5_10769006($_smarty_tpl) {?><?php if (!is_callable('smarty_modifier_date_format')) include 'F:\\project\\qlahmjHouTai\\include\\config/../../include/lib/Smarty/plugins\\modifier.date_format.php';
?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg4.png);">
    <a href="/agentCenter/Mine.php" class="ReturnUp" id="data_month_back" name="">返回首页</a>
    <div class="N_Header_title" id ="header_titil">返佣汇总</div>
</div>
<div class="N_Wrap" style="bottom:0;">
    <div class="N_WrapAuto">
        <div class="N_Pad">
            <div class="N_RecordTop wp_94 mgTp3A">
                <div class="clearfix">
                <form action="" class="form-search cf">
                    <div class="clearfix">
                        <a href="/agentCenter/rebatesummary.php?type=1" class="RecordSumBox bgc_929292" style="width: 50%">日收入</a>
                        <a href="/agentCenter/rebatesummary.php?type=2" class="RecordSumBox" style="width: 50%">月收入</a>        
                    </div>
                </form>     
                </div>
            </div>
            <div class="record_wrap N_RecordBottom N_RecordBottom2 clearfix wp_94 mgTp3A">
                 <ul class="wp_full record_tit clearfix textCenter">
                    <li class="borderB wp_full h40">
                        <span class="wp_50 borderBox fl textCenter">日期</span>
                        <span class="wp_50 borderBox fl textCenter">佣金金额</span>
                    </li>
                    <?php  $_smarty_tpl->tpl_vars['val'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['val']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['result']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['val']->key => $_smarty_tpl->tpl_vars['val']->value) {
$_smarty_tpl->tpl_vars['val']->_loop = true;
?>
                    <li class="borderB wp_full h40">
                        <?php if ($_smarty_tpl->tpl_vars['_REQUEST']->value['type']==2) {?>
                        <span class="wp_50 borderBox fl textCenter" style="line-height: 14px"><?php echo smarty_modifier_date_format($_smarty_tpl->tpl_vars['val']->value['dateid'],'%Y-%m');?>
</span>
                        <?php } else { ?>
                        <span class="wp_50 borderBox fl textCenter" style="line-height: 14px"><?php echo $_smarty_tpl->tpl_vars['val']->value['dateid'];?>
</span>
                        <?php }?>
                        <span class="wp_50 borderBox fl textCenter"><?php echo $_smarty_tpl->tpl_vars['val']->value['rebate'];?>
</span>
                    </li>
                    <?php } ?>
                </ul>
                <?php echo $_smarty_tpl->tpl_vars['page_html']->value;?>

            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
   $(function(){
    $('.RecordSumBox').eq(<?php echo $_smarty_tpl->tpl_vars['type']->value;?>
).addClass('bgc_929292').siblings().removeClass('bgc_929292');
   })
</script>

<?php }} ?>