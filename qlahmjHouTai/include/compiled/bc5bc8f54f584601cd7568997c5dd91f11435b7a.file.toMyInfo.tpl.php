<?php /* Smarty version Smarty-3.1.15, created on 2018-07-26 19:13:03
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toMyInfo.tpl" */ ?>
<?php /*%%SmartyHeaderCode:26225b599eaf744d82-85002059%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'bc5bc8f54f584601cd7568997c5dd91f11435b7a' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toMyInfo.tpl',
      1 => 1532599303,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '26225b599eaf744d82-85002059',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b599eaf750903_86095148',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b599eaf750903_86095148')) {function content_5b599eaf750903_86095148($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg2.png);">
    <a href="/dlIndex.php?m=Index&c=index&a=home" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">个人中心</div>
</div>
<div class="N_Wrap">
    <div class="N_WrapAuto">
        <div class="N_CenterMain">

            <div class="N_IndexC1TopPad clearfix">
                <div class="N_IndexC1TopImg fl">
                    <a href="javascript:;"><img src="/assets/images/agentCenter/img1.png"></a>
                </div>
                <div class="N_IndexC1TopName fl">
                    <div>
                        <ul>
                            <li class="clearfix">
                                <div class="fl"><span class="text" id="nickName"></span></div>
                                <!-- <div class="fl gold_medal"><img src="./pigcms_tpl/Merchants/Static/NewImg/gold_medal.png"></div> -->
                            </li>
                            <li class="clearfix opacity6 ft12">
                                <div class="fl">ID：</div>
                                <div class="fl"><span class="text" id="gameId"></span></div>
                            </li>
                            <li class="clearfix opacity6 ft10">
                                <div class="fl">返利：</div>
                                <div class="fl"><span class="text" id="fx_userid"></span></div>
                            </li>
                        </ul>
                    </div>
                </div>
               
            </div>

<!-- 
            <div class="N_CenterHeader">
                <div class="N_CenterImg"><a href="javascript:;"><img src="./pigcms_tpl/Merchants/Static/NewImg/img1.png"></a></div>
                <div class="N_CenterName"><span class="text" id="nickName"></span></div>
                <div class="N_CenterId">ID：<span class="text" id="gameId"></span></div>
            </div> -->
            <div class="N_Pad">
                <div class="N_CenterContent">
                    <div class="N_CenterBox1 clearfix">
                         <ul>
                            <li class="N_IndexC1BottomBox1">
                                <a href="/dlIndex.php?m=Index&c=toUpdateMyInfo&a=index">
                                   完善资料
                                </a>
                            </li>
                            <li class="N_IndexC1BottomBox3">
                                <a href="/dlIndex.php?m=Index&c=toUpdatePassword&a=index">
                                   账户安全
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="N_IndexC2">
                        <ul>
                             <li>
                                <a href="/dlIndex.php?m=Index&c=toTixian&a=tixianrecord&tx_recorde_type=myinfo">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon8.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">提现记录</div>
                                        <div class="N_IndexC2_RightT2">提现T+1到账，无任何手续费</div>
                                    </div>
                                </a>
                            </li>

                            <li>
                                <a href="/dlIndex.php?m=Index&c=toRecommendedAward&a=toRWUsersDetail">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon9.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">玩家贡献明细</div>
                                        <div class="N_IndexC2_RightT2">查看绑定玩家的贡献明细</div>
                                    </div>
                                </a>
                            </li>
                           <li>
                                <a href="/dlIndex.php?m=Index&c=toRecommendedAward&a=toRWAgentsDetail">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon10.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">代理贡献明细</div>
                                        <div class="N_IndexC2_RightT2">查看下级代理的贡献明细</div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="/dlIndex.php?m=Index&c=toRecommendedAward&a=toRWDateOrMonthDetail&type=d&DMType=myinfo">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon11.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">返利统计</div>
                                        <div class="N_IndexC2_RightT2">根据每日、每月进行汇总查询</div>
                                    </div>
                                </a>
                            </li>
                            <li id='roseAgent'>
                                <a href="/dlIndex.php?m=Index&c=toMyAgent&a=toRoseAgentDetail">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon5.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">总代月总额统计</div>
                                        <div class="N_IndexC2_RightT2">查看总代每月的总收额</div>
                                    </div>
                                </a>
                            </li>

                           <!--  <li>
                                <a href="/dlIndex.php?m=Index&c=toTixian&a=tixianrecord">提现记录</a>
                                <a href="/dlIndex.php?m=Index&c=toRecommendedAward&a=toRWUsersDetail">玩家贡献明细</a>
                                <a href="/dlIndex.php?m=Index&c=toRecommendedAward&a=toRWAgentsDetail">代理贡献明细</a>
                                <a href="/dlIndex.php?m=Index&c=toRecommendedAward&a=toRWDateOrMonthDetail&type=d">返利统计</a>
                                
                            </li> -->
                        </ul>
                    </div>
                    <a href="dlIndex.php?m=Index&c=logout&a=index" class="N_Signout wp_94 marginAuto">退出登录</a>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="N_Footer clearfix">
    <ul>
        <li><a href="/dlIndex.php?m=Index&c=index&a=home"><i class="HomeIcon"></i>首页</a></li>
        <li><a href="/dlIndex.php?m=Index&c=toMyGameUser&a=index"><i class="GameIcon"></i>玩家</a></li>
        <li><a href="/dlIndex.php?m=Index&c=toMyAgent&a=index"><i class="AgencyIcon"></i>代理</a></li>
        <li><a href="/dlIndex.php?m=Index&c=toTixian&a=index"><i class="MoneyIcon"></i>提现</a></li>
        <li class="on"><a href="/dlIndex.php?m=Index&c=toMyInfo&a=index"><i class="MyIcon"></i>我的</a></li>
    </ul>
</div>
<div class="NshowBoxBg" style="display:none;"></div>
<div class="NshowBox animated zoomIn" style="display:none;">
    <div class="NshowBoxMain">
        <div class="NshowBoxList">
            <dl class="clearfix">
                <dt>游戏ID</dt>
                <dd><span id="Nid"></span></dd>
            </dl>
            <dl class="clearfix">
                <dt>微信昵称</dt>
                <dd><span id="Nname"></span></dd>
            </dl>
            <dl class="clearfix">
                <dt>微信号</dt>
                <dd><span id="NweChat"></span></dd>
            </dl>
            <dl class="clearfix">
                <dt>后台账号</dt>
                <dd><span id="Nnumber"></span></dd>
            </dl>
            <dl class="clearfix">
                <dt>注册时间</dt>
                <dd id="Ntime"></dd>
            </dl>
            <div class="NshowBoxBottom clearfix">
                <a href="/dlIndex.php?m=Index&c=toUpdateMyInfo&a=index" class="NshowBoxBtn1 fl">修改信息</a>
                <a href="/dlIndex.php?m=Index&c=toUpdatePassword&a=index" class="NshowBoxBtn2 fr">修改密码</a>
            </div>
        </div>
        <a href="javascript:;" class="NshowClose">关闭</a>
    </div>
</div><?php }} ?>
