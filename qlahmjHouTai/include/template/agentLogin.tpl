<{include file = "simple_header.tpl"}>


<style>
    html{
        height:100%;
    }
    body{
        background:#ffffff !important;
        height:100%;
    }
</style>

<!-- <{$osadmin_action_alert}> -->
<div class="N_LoginWrap">
    <form class="form-vertical login-form" action="" method="POST">
        <div class="N_LoginMain">
            <div class="N_LoginCell">
                <div class="N_LoginLogo"><img src="../../assets/images/agentCenter/loginTitle.png"></div>
                <div class="N_LoginForm">
                    <dl class="clearfix">
                        <dt class="N_Login_icon1"></dt>
                        <dd><input type="text" placeholder="请输入手机号/账号名" id="username" name="user_name" value="<{$_POST.user_name}>"></dd>
                    </dl>
                    <dl class="clearfix">
                        <dt class="N_Login_icon2"></dt>
                        <dd><input type="password" placeholder="请输入密码" id="password" name="password" value="<{$_POST.password}>"></dd>
                    </dl>
                    <div><input type="submit" id="login" class="N_LoginSub" value="登录"></div>
                </div>
            </div>
        </div>
    </form>
</div>
<!-- <script type="text/javascript">
    $(function(){
        // var oHeight = $(document).height()
        // $(window).resize(function(){
        //     if($(document).height()<oHeight){
        //         $('.N_Footer').css('position','absolute');
        //     }else{
        //         $('.N_Footer').css('position','fixed');
        //     }
        // })
        
        var bindAndroidScroll = function(that){
            if(myApp.device.android || (myApp.device.ios && myApp.device.osVersion.split(setTimeout(function(){
                that.scrollIntoViewNeed()
            }
        },500)
    })

        $('#inputId').;on(click,function(e){
            bindAndroidScroll(this)
        })
</script> -->