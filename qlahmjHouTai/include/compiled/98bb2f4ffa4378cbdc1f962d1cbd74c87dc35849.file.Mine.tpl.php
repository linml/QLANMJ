<?php /* Smarty version Smarty-3.1.15, created on 2018-09-13 12:01:56
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\Mine.tpl" */ ?>
<?php /*%%SmartyHeaderCode:201775b60206bc84680-66345316%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '98bb2f4ffa4378cbdc1f962d1cbd74c87dc35849' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\Mine.tpl',
      1 => 1536212458,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '201775b60206bc84680-66345316',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b60206bc9fc10_98935062',
  'variables' => 
  array (
    'result' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b60206bc9fc10_98935062')) {function content_5b60206bc9fc10_98935062($_smarty_tpl) {?><?php if (!is_callable('smarty_modifier_truncate')) include 'F:\\project\\qlahmjHouTai\\include\\config/../../include/lib/Smarty/plugins\\modifier.truncate.php';
?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg2.png);">
    <div class="N_Header_title">个人中心</div>
</div>
<div class="N_Wrap mt50">
    <div class="N_WrapAuto">
        <div class="N_CenterMain">

            <div class="N_IndexC1TopPad clearfix relative">
                <div class="N_IndexC1TopImg fl">
                    <a href="javascript:;"><img src="<?php echo (($tmp = @$_smarty_tpl->tpl_vars['result']->value['picfile'])===null||$tmp==='' ? '/assets/avatars/tark.png' : $tmp);?>
"></a>
                </div>
                <div class="N_IndexC1TopName fl">
                    <div>
                        <ul>
                            <li class="clearfix">
                                <div class="fl"><span class="text" id="nickName"></span></div>
                            </li>
                            <li class="clearfix opacity6 ft12">
                                <div class="fl"> <?php echo $_smarty_tpl->tpl_vars['result']->value['wechatname'];?>
 </div>
                                <div class="fl"><span class="text" id="gameId"></span></div>
                            </li>
                            <li class="clearfix opacity6 ft10">
                                <div class="fl">ID：<?php echo $_smarty_tpl->tpl_vars['result']->value['userid'];?>
</div>
                                <div class="fl"><span class="text" id="fx_userid"></span></div>
                            </li>
                            <li class="clearfix absolute left74 top55">
                                <div class="ft25">
                                   <?php echo smarty_modifier_truncate($_smarty_tpl->tpl_vars['result']->value['name'],2,'');?>

                                </div>
                                <div>代理等级</div>
                            </li>
                        </ul>
                    </div>
                </div>    
            </div>
            <div class="N_Pad" style="margin-top: 35px">
                <div class="N_CenterContent">
                    <div class="N_IndexC2">
                        <ul>
                             <li style="line-height: 26px;padding-right: 20px;">
                                <a href="/agentCenter/drawmoney.php">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon8.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">余额提现</div>  
                                    </div>
                                </a>
                            </li>

                            <li style="line-height: 26px;padding-right: 20px;">
                                <a href="/agentCenter/rebaterecord.php">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon9.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">佣金记录</div>
                            
                                    </div>
                                </a>
                            </li>
                           <li style="line-height: 26px;padding-right: 20px;">
                                <a href="/agentCenter/drawmoneyrecord.php">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon1.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">提现记录</div>
                                      
                                    </div>
                                </a>
                            </li>
                            <li style="line-height: 26px;padding-right: 20px;">
                                <a href="/agentCenter/gemsrecord.php">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon7.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">钻石记录</div>
                                    
                                    </div>
                                </a>
                            </li>
                            <li id='roseAgent' style="line-height: 26px;padding-right: 20px;">
                                <a href="/agentCenter/rebatesummary.php">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/rebateSummary.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">佣金汇总</div>
                                    </div>
                                </a>
                            </li>
                            <li id='roseAgent' style="line-height: 26px;padding-right: 20px;">
                                <a href="/agentCenter/updatemyinfo.php">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon11.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">完善资料</div>
                                       
                                    </div>
                                </a>
                            </li>
                            <li id='roseAgent' style="line-height: 26px;padding-right: 20px;">
                                <a href="/agentCenter/updatepassword.php">
                                    <div class="N_IndexC2_Icon"><img src="/assets/images/agentCenter/icon12.png"></div>
                                    <div class="N_IndexC2_Right">
                                        <div class="N_IndexC2_RightT1">账户安全</div>
                                    </div>

                                </a>
                            </li>
                        </ul>
                    </div>
                    <p class="mt20" style="padding:0 25%;margin-bottom: 10%;border: 0 none">
    <a href="javascript:void(0);" class="btn_6" id="logout" onclick="logout(<?php echo $_smarty_tpl->tpl_vars['result']->value['userid'];?>
)">退出当前账号</a>
</p>
                </div>
            </div>
        </div>
</div>
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
</div>

<?php echo $_smarty_tpl->getSubTemplate ("simple_footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<script type="text/javascript">
    function logout(userid){
        if(userid != null){
            $.ajax({
                uril:'mine.php',
                dataType:'',
                type:'POST',
                data:{
                    'method':'logout',
                    userid:userid
                },
                success:function(data){
                    window.location.reload()
                    return
                },
                error:function(err){

                }
            })
        }
    }
</script><?php }} ?>
