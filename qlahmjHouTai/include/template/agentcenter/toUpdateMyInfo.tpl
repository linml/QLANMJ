<{include file = "simple_header.tpl"}>

<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg4.png);">
    <a href="/agentCenter/mine.php" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">完善资料</div>
</div>
<div class="N_Wrap " style="bottom:0;">
    <div class="N_WrapAuto mgTp1A">
        <div class="N_Pad">
            <form action="" method="POST">
            <div class="N_AddForm N_AddForm2">
                 <dl>
                    <dt>游戏ID</dt>
                    <dd class="textRight"><span id="gameID"><{$AgentInfo.userid}></span></dd>
                </dl>
                 <dl>
                    <dt>微信昵称</dt>
                    <dd class="textRight"><span id="WXNickName"><{$AgentInfo.wechatname}></span></dd>
                </dl>
                 <dl>
                    <dt>登录账号</dt>
                    <dd class="textRight"><span id="WXNickName"><{$AgentInfo.mobilenum}></span></dd>
                </dl>
                 <!-- <dl>
                    <dt>登录账号</dt>
                    <dd class="textRight"><input type="text" id="telMd" placeholder="<{$AgentInfo.mobilenum}>" class="textRight"></dd>
                </dl> -->
                 <dl>
                    <dt>代理姓名</dt>
                    <dd><input type="text" id="nickNameMd" placeholder="<{$AgentInfo.agentname}>" value="<{$AgentInfo.agentname}>" class="textRight" name="agentname" required></dd>
                </dl>
                 <dl>
                    <dt>微信账号</dt>
                    <dd><input type="text" id="weChatMd" placeholder="<{$AgentInfo.wechatnum}>" value="<{$AgentInfo.wechatnum}>" class="textRight" name="wechatnum" required></dd>
                </dl>
            </div>

            <div class="N_AddForm N_AddForm2">
                 <dl>
                    <dt>注册时间</dt>
                    <dd class="textRight"><span id="regersterTime"><{$AgentInfo.addtime}></span></dd>
                </dl>
            </div>
            <div class="NbcBtn wp_94 marginAuto"><button name="isPost" type="submit" id="updateMyInfo">保存</button> </div>
            </form>
        </div>
    </div>
</div>

