<?php /* Smarty version Smarty-3.1.15, created on 2018-08-24 10:18:33
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\FriendsCircle.tpl" */ ?>
<?php /*%%SmartyHeaderCode:179515b602057ce96a1-38388149%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'a82a0cfcc89f6b4a8262406c3ab151fcc5cb23e9' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\FriendsCircle.tpl',
      1 => 1534987035,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '179515b602057ce96a1-38388149',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b602057cf5226_86969894',
  'variables' => 
  array (
    'friendTitleInfo' => 0,
    'friendscirclesList' => 0,
    'friendscircle' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b602057cf5226_86969894')) {function content_5b602057cf5226_86969894($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg5.png);">
    <div class="N_Header_title">亲友圈</div>
    
</div>
<!-- <div class="btn_invite fixed top8 left0">开通代理</div> -->
<div class="N_Wrap bottm60" style="margin-top: 50px">
    <div class="N_WrapAuto">
        <div class="N_bg">
            <div class="N_agentTop clearfix mgTp1A" style="background:url(/assets/images/agentCenter/bg9.png) no-repeat center top/100% auto;">
                <div class="C_wh25 floatL pdT15 pdB15">
                  <p class="ft20 c_fff"><?php echo $_smarty_tpl->tpl_vars['friendTitleInfo']->value['frirendCount'];?>
</p>
                  <p class="c_fff ft14">我的亲友圈</p>
                </div>
                <div class="C_wh25 floatL pdT15 pdB15">
                  <p class="ft20 c_fff"><?php echo $_smarty_tpl->tpl_vars['friendTitleInfo']->value['frirendUserCount'];?>
</p>
                  <p class="c_fff ft14">累计成员数</p>
                </div>
                <div class="C_wh25 floatL pdT15 pdB15">
                  <p class="ft20 c_fff"><?php echo $_smarty_tpl->tpl_vars['friendTitleInfo']->value['totalcnt'];?>
</p>
                  <p class="c_fff ft14">累计桌数</p>
                </div>
                <div class="C_wh25 floatL pdT15 pdB15">
                  <p class="ft20 c_fff"><?php echo $_smarty_tpl->tpl_vars['friendTitleInfo']->value['totalamt'];?>
</p>
                  <p class="c_fff ft14">累计消耗</p>
                </div>
            </div>
            <div class="record_wrap clearfix  wp_94 mgTp3A">
                <ul>
                  <?php  $_smarty_tpl->tpl_vars['friendscircle'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['friendscircle']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['friendscirclesList']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['friendscircle']->key => $_smarty_tpl->tpl_vars['friendscircle']->value) {
$_smarty_tpl->tpl_vars['friendscircle']->_loop = true;
?>
                  <li class="relative C_wh_80 bgc_fff mgb10">
                      <img src="/assets/images/agentCenter/bg6c.png">
                       <div class="absolute N_IndexC3_tit">亲友圈ID:&nbsp;&nbsp;<i><?php echo $_smarty_tpl->tpl_vars['friendscircle']->value['friendid'];?>
</i></div>
                      <div class="wxavatar absolute left5 top20 gamebox">
                        <?php echo $_smarty_tpl->tpl_vars['friendscircle']->value['picpath'];?>

                      </div>
                      <div class="absolute f_return left4 top97">
                       <?php echo $_smarty_tpl->tpl_vars['friendscircle']->value['friendname'];?>

                      </div>
                      <div class="absolute left33 top31 wp_50 hp_60" style="padding-top: 2%">
                        <div class="floatL hp_50 ft20"><?php echo round($_smarty_tpl->tpl_vars['friendscircle']->value['totalcnt']);?>
</div>
                          <i class="floatL">
                            <img src="/assets/images/agentCenter/desk.svg" width="20" height="20">
                          </i>
                        <div class="f_return absolute left_10 top97">今日桌数</div>
                      </div>

                      <div class="absolute left60 top31 wp_50 hp_60" style="padding-top: 2%">
                        <div class="floatL hp_50 ft20"><?php echo round($_smarty_tpl->tpl_vars['friendscircle']->value['totalamt']);?>
</div>
                          <i class="floatL wp_50">
                            <img src="/assets/images/agentCenter/gems.svg" width="20" height="20">
                          </i>
                        <div class="f_return absolute left_10 top97">今日耗钻</div>
                      </div>
                      <div class="absolute left89 top15">
                        <a href="/agentCenter/friendscircleinfo.php?friendid=<?php echo $_smarty_tpl->tpl_vars['friendscircle']->value['friendid'];?>
">
                        <img src="/assets/images/agentCenter/singlearrow.svg" width="20" height="80" style="padding-top:30px">
                        </a>
                      </div>
                      <i class="absolute left70 top4">
                        <img src="/assets/images/agentCenter/group.svg" width="20" height="20">
                        <span class="f_return">成员:<?php echo $_smarty_tpl->tpl_vars['friendscircle']->value['countUser'];?>
人</span>
                      </i>
                  </li>
                  <?php } ?>
                </ul>
            </div>
        </div>
    </div>
</div>

<?php echo $_smarty_tpl->getSubTemplate ("simple_footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
<?php }} ?>
