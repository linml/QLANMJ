<{include file = "simple_header.tpl"}>

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
                    <dd class="textRight"><img class="borderR5"  src="<{$agentsInfo.picfile|default:'/assets/avatars/tark.png'}>" id="WXavatar"/></dd>
                </dl>
                <dl>
                    <dt>微信昵称</dt>
                    <dd class="textRight"><span id="WXNickName"><{$agentsInfo.wechatname}></span></dd>
                </dl>
                <dl>
                    <dt>游戏ID</dt>
                    <dd class="textRight"><span id="gameID"><{$agentsInfo.userid}></span></dd>
                </dl>
                <dl>
                    <dt>代理等级</dt>
                    <dd class="textRight"><span id="gameID">
                        <{$agentsInfo.name|truncate:"2":""}>
                    </span></dd>
                </dl>
                <dl>
                    <dt>绑定玩家</dt>
                    <dd class="textRight"><span id="gameID"><{$agentsInfo.binduser}></span></dd>
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
            <a href="/agentCenter/agentsinfo.php?agentid=<{$_REQUEST['agentid']}>" id="delAgent" class="NbcBtn wp_94 marginAuto"><button type="button" id="updateMyInfo">解除上下级关系</button> </a>
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
                    data: {method: 'unbindRelationship',agentid:'<{$agentid}>'},
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