<?php /* Smarty version Smarty-3.1.15, created on 2018-08-14 10:23:38
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toAgentsInfo.tpl" */ ?>
<?php /*%%SmartyHeaderCode:163615b6106e0827e59-61993327%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'e524f8aed56852b2e828f10af56afd4fa0061d00' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toAgentsInfo.tpl',
      1 => 1534155070,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '163615b6106e0827e59-61993327',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b6106e08627e5_73419127',
  'variables' => 
  array (
    'agentsInfo' => 0,
    '_REQUEST' => 0,
    'agentid' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b6106e08627e5_73419127')) {function content_5b6106e08627e5_73419127($_smarty_tpl) {?><?php if (!is_callable('smarty_modifier_truncate')) include 'F:\\project\\qlahmjHouTai\\include\\config/../../include/lib/Smarty/plugins\\modifier.truncate.php';
?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg4.png);">
    <a href="javascript:history.go(-1);" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">代理资料</div>
</div>
<div class="N_Wrap " style="bottom:0;">
    <div class="N_WrapAuto mgTp1A">
        <div class="N_Pad">
            <div class="N_AddForm N_AddForm2">
                <dl>
                    <dt>微信头像</dt>
                    <dd class="textRight"><img class="borderR5"  src="<?php echo $_smarty_tpl->tpl_vars['agentsInfo']->value['picfile'];?>
" id="WXavatar"/></dd>
                </dl>
                <dl>
                    <dt>微信昵称</dt>
                    <dd class="textRight"><span id="WXNickName"><?php echo $_smarty_tpl->tpl_vars['agentsInfo']->value['wechatname'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>游戏ID</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['agentsInfo']->value['userid'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>代理等级</dt>
                    <dd class="textRight"><span id="gameID">
                        <?php echo smarty_modifier_truncate($_smarty_tpl->tpl_vars['agentsInfo']->value['name'],"2",'');?>

                    </span></dd>
                </dl>
                <dl>
                    <dt>绑定玩家</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['agentsInfo']->value['binduser'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>成员信息</dt>
                    <dd class="textRight"><span id="gameID">暂不提供</span></dd>
                </dl>
                <dl>
                    <dt>亲友圈</dt>
                    <dd class="textRight"><span id="gameID">暂不提供</span></dd>
                </dl>
            </div>
            <div class="N_AddForm N_AddForm2">
                 <dl>
                    <dt>注册时间</dt>
                    <dd class="textRight"><span id="regersterTime"></span></dd>
                </dl>
                 <dl>
                    <dt>最后登录游戏时间</dt>
                    <dd class="textRight"><span id="lastLoginTime"></span></dd>
                </dl>
            </div>
            <a href="/agentCenter/agentsinfo.php?agentid=<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agentid'];?>
" id="delAgent" class="NbcBtn wp_94 marginAuto"><button type="button" id="updateMyInfo">解除上下级关系</button> </a>
        </div>
    </div>
</div>
<script >
    $(function(){
        $('#updateMyInfo').click(function(){
            if(confirm("确定要解除上下级关系！")){
                $.ajax({
                    url: 'agentsinfo.php',
                    type: 'POST',
                    dataType: '',
                    data: {method: 'unbindRelationship',agentid:<?php echo $_smarty_tpl->tpl_vars['agentid']->value;?>
},
                    success:function(data){
                        if(1==data){
                            alert('解除上下级成功！');
                            window.location.href="agents.php";
                        }else if(-1==data|| 0 ==data){
                            alert('关系解除失败！')
                            window.location.href="agents.php";
                        }
                    },
                    error:function(err){

                    }
                });
                
            }
        });     
    });
</script>
<?php }} ?>