<?php /* Smarty version Smarty-3.1.15, created on 2018-08-24 10:19:15
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toPlayersInfo.tpl" */ ?>
<?php /*%%SmartyHeaderCode:52415b601fa3a9a620-20833168%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'b16d54fd11d9876aeded4b657a677dd68ee99976' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toPlayersInfo.tpl',
      1 => 1534765949,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '52415b601fa3a9a620-20833168',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b601fa3aa61a9_11465778',
  'variables' => 
  array (
    'palyerInfo' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b601fa3aa61a9_11465778')) {function content_5b601fa3aa61a9_11465778($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg4.png);">
    <a href="javascript:history.go(-1);" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">玩家资料</div>
</div>
<div class="N_Wrap " style="bottom:0;">
    <div class="N_WrapAuto mgTp1A">
        <div class="N_Pad">
            <form action="javascript:;">
            <div class="N_AddForm N_AddForm2">
                <dl>
                    <dt>微信头像</dt>
                    <dd class="textRight borderR5"><img class="borderR5"  src="<?php echo (($tmp = @$_smarty_tpl->tpl_vars['palyerInfo']->value['picfile'])===null||$tmp==='' ? '/assets/avatars/tark.png' : $tmp);?>
" id="WXavatar"/></dd>
                </dl>
                <dl>
                    <dt>微信昵称</dt>
                    <dd class="textRight"><span id="WXNickName"><?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['nickname'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>游戏ID</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['userid'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>剩余钻石</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['diamond'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>游戏次数</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['playnum'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>游戏数据</dt>
                    <dd class="textRight"><span id="gameID">暂不提供</span></dd>
                </dl>
                <dl>
                    <dt>所在亲友圈</dt>
                    <dd class="textRight"><span id="gameID">暂不提供</span></dd>
                </dl> 
                
                <dl style="display:none">
                    <dt>代理姓名</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['nickname'];?>
</span></dd>
                </dl>
                 <dl style="display:none">
                    <dt>微信账号</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['nickname'];?>
</span></dd>
                </dl>
            </div>

            <div class="N_AddForm N_AddForm2">
                 <dl>
                    <dt>注册时间</dt>
                    <dd class="textRight"><span id="regersterTime"><?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['addtime'];?>
</span></dd>
                </dl>
                 <dl>
                    <dt>最后登录游戏时间</dt>
                    <dd class="textRight"><span id="lastLoginTime"><?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['logintime'];?>
</span></dd>
                </dl>
            </div>
            <div class="NbcBtn wp_94 marginAuto"><button type="button" id="updateMyInfo">解除绑定</button> </div>
            </form>
        </div>
    </div>
</div>

<script >
    $(function(){
        $('#updateMyInfo').click(function(){
            if(confirm("确定要解除上下级关系！")){
                $.ajax({
                    url: 'playersinfo.php',
                    type: 'POST',
                    dataType: '',
                    data: {method: 'unbindRelationship',userid:'<?php echo $_smarty_tpl->tpl_vars['palyerInfo']->value['userid'];?>
'},
                    success:function(data){
                        if(1==data){
                            alert('解除上下级成功！');
                            window.location.href="players.php";
                        }else if(-1==data|| 0 ==data){
                            alert('关系解除失败！')
                            window.location.href="players.php";
                        }
                    },
                    error:function(err){
                        console.log('error')
                    }
                });
                
            }
        });     
    });
</script><?php }} ?>