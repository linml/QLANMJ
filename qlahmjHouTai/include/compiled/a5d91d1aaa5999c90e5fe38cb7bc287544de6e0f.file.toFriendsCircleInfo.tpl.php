<?php /* Smarty version Smarty-3.1.15, created on 2018-08-08 16:47:47
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toFriendsCircleInfo.tpl" */ ?>
<?php /*%%SmartyHeaderCode:66485b60205c4fb2a2-84053594%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'a5d91d1aaa5999c90e5fe38cb7bc287544de6e0f' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toFriendsCircleInfo.tpl',
      1 => 1533714423,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '66485b60205c4fb2a2-84053594',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b60205c506e20_56181634',
  'variables' => 
  array (
    'friendInfo' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b60205c506e20_56181634')) {function content_5b60205c506e20_56181634($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg4.png);">
    <a href="javascript:history.go(-1);" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">亲友圈资料</div>
</div>
<div class="N_Wrap " style="bottom:0;">
    <div class="N_WrapAuto mgTp3A">
        <div class="N_Pad">
            <form action="javascript:;">
            <div class="N_AddForm N_AddForm2 pdlr20">
                <dl>
                    <dt>亲友圈ID</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['friendInfo']->value['friendid'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>亲友圈名称</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['friendInfo']->value['friendname'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>圈主</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['friendInfo']->value['nickname'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>亲友圈成员</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['friendInfo']->value['counts'];?>
人</span>
                        <a href="" style="display: inline-block;line-height: 20px">
                            <img src="/assets/images/agentCenter/doublearrow.svg" width="20" height="20">
                        </a>
                    </dd>
                </dl>
                <dl>
                    <dt>游戏玩法</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['friendInfo']->value['gamename'];?>
</span></dd>
                </dl>
                <dl>
                    <dt>创建时间</dt>
                    <dd class="textRight"><span id="gameID"><?php echo $_smarty_tpl->tpl_vars['friendInfo']->value['addtime'];?>
</span></dd>
                </dl>  
            </div>

            <div class="N_AddForm N_AddForm2 pdlr20">
                 <dl>
                    <dt>历史数据统计</dt>
                    <dd class="textRight"><span id="regersterTime"></span>
                        <a href="" style="display: inline-block;line-height: 20px">
                            <img src="/assets/images/agentCenter/doublearrow.svg" width="20" height="20">
                        </a>
                    </dd>
                </dl>
                 <dl>
                    <dt>历史损耗统计</dt>
                    <dd class="textRight"><span id="lastLoginTime"></span>
                        <a href="" style="display: inline-block;line-height: 20px">
                            <img src="/assets/images/agentCenter/doublearrow.svg" width="20" height="20">
                        </a>
                    </dd>
                </dl>
            </div>
            </form>
        </div>
    </div>
</div>
<?php }} ?>
