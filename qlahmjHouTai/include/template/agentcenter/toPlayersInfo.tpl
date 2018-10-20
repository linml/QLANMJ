<{include file = "simple_header.tpl"}>

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
                    <dd class="textRight borderR5"><img class="borderR5"  src="<{$palyerInfo.picfile|default:'/assets/avatars/tark.png'}>" id="WXavatar"/></dd>
                </dl>
                <dl>
                    <dt>微信昵称</dt>
                    <dd class="textRight"><span id="WXNickName"><{$palyerInfo.nickname}></span></dd>
                </dl>
                <dl>
                    <dt>游戏ID</dt>
                    <dd class="textRight"><span id="gameID"><{$palyerInfo.userid}></span></dd>
                </dl>
                <dl>
                    <dt>剩余钻石</dt>
                    <dd class="textRight"><span id="gameID"><{$palyerInfo.diamond}></span></dd>
                </dl>
                <dl>
                    <dt>游戏次数</dt>
                    <dd class="textRight"><span id="gameID"><{$palyerInfo.playnum}></span></dd>
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
                    <dd class="textRight"><span id="gameID"><{$palyerInfo.nickname}></span></dd>
                </dl>
                 <dl style="display:none">
                    <dt>微信账号</dt>
                    <dd class="textRight"><span id="gameID"><{$palyerInfo.nickname}></span></dd>
                </dl>
            </div>

            <div class="N_AddForm N_AddForm2">
                 <dl>
                    <dt>注册时间</dt>
                    <dd class="textRight"><span id="regersterTime"><{$palyerInfo.addtime}></span></dd>
                </dl>
                 <dl>
                    <dt>最后登录游戏时间</dt>
                    <dd class="textRight"><span id="lastLoginTime"><{$palyerInfo.logintime}></span></dd>
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
                    data: {method: 'unbindRelationship',userid:'<{$palyerInfo.userid}>'},
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
</script>