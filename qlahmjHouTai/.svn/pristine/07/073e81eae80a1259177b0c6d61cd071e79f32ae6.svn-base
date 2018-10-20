<{include file = "simple_header.tpl"}>
<div class="pdlr10">
<div class="openAgent">
    <div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg3.png);">
    <a href="/agentCenter/home.php" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">开通代理</div>
    </div>
    <div class="w_710" style="margin-top: 22%">
        <div class="relative borderBox wp_full mgTp3  bgfff" style="height: 50px;line-height: 50px;text-indent: 1em">
            游戏ID
            <input type="number" placeholder="请输入代理的游戏ID" class="inputStyle absolute top0 leftP23" id="UserGameId" min="0" style="height: 100%">
        </div>
        <p class="font24 mgTp3 c_999">验证结果：<span id="yz_name" class="">等待验证</span><span class="c_4baf43" id="yzc_faild">(未注册)</span><span class="c_ff5d20" id="yzc_ok">(已注册)</span></p>
        <div class="mgTp3 bgfff">
            <div class="relative borderBox wp_full h70" style="line-height: 70px;border-bottom: 1px solid #ccc;text-indent: 1em">
                姓名
                <input type="text"  class="inputStyle absolute  hp_100 top0 leftP23" id ='nickName' placeholder="请输入代理商昵称" style="height: 100%">
            </div>
            <div class="relative borderBox wp_full h50" style="line-height: 50px;border-bottom: 1px solid #ccc;text-indent: 1em">
                手机号
                <input type="number"  required="true" min="0" placeholder="请输入正确的代理手机号" class="inputStyle absolute  hp_100 top0 leftP23" id='UserTel' style="height: 100%"><span id='tel_msg'></span>
            </div>


            <div class="relative borderBox wp_full hidden h50" style="line-height: 50px;border-bottom: 1px solid #ccc;text-indent: 1em">
                微信昵称
                <input type="text" required="true" placeholder="请输入微信昵称" class="inputStyle absolute  hp_100 top0 leftP23" id ='weChatName' style="height: 100%">
            </div>

            <div class="relative borderBox wp_full h50" style="line-height: 50px;border-bottom: 1px solid #ccc;text-indent: 1em">
                微信号
                <input type="text" required="true" placeholder="请输入微信号" class="inputStyle absolute  hp_100 top0 leftP23" id ='WeChat' style="height: 100%">
            </div>

            <div class="relative borderBox wp_full h50" style="line-height: 50px;border-bottom: 1px solid #ccc;text-indent: 1em">
                级别
                <select class="inputStyle absolute hp_100 top0" id = "AgentSet" style="height: 100%">
                    <{foreach from=$levleData item=levle}>
                        <option value="<{$levle.levelid}>"><{$levle.name}> (享受<{$levle.discount}>%返利)</option>
                    <{/foreach}>
                </select>
            </div>
        </div>
        
        <div class="textCenter font32 mgTp3 c_fff wp_full h_90 lh_90 br_8 bg_btn3" id="addAgent">开通代理</div>
        <p class="mgTp3 ft14 c_999">
            1、游戏ID可在登陆游戏后获取。<br/>
            2、开通代理后可享受级别利差的收入。<br/>
            3、详情返利请联络市场经理。<br/>
        </p>
    </div>
</div>
</div>


<script>
    $(function(){
        $("#yzc_faild").hide();
        $("#yzc_ok").hide();
        //1、失去焦点验证
        $("#UserGameId").blur(function(){
            var playerid = $(this).val();
            if(!playerid){
                $("#yz_name").text('参数为空！');
                $("#yzc_faild").hide();
                $("#yzc_ok").hide();
                return;
            }
            $.ajax({
                url: 'openagents.php',
                type: 'POST',
                dataType: '',
                data: {'method': 'valiPlayer','playerid':playerid},
                success:function(data){
                    data = $.parseJSON(data);
                    $("#yzc_faild").show();
                    $("#yzc_ok").show();
                    if(data.status==1) {
                        $("#yz_name").text('服务器验证参数为空！');
                        $("#yzc_faild").hide();
                        $("#yzc_ok").hide();
                    }else if(data.status==2){
                        $("#yz_name").text('未绑定该玩家');
                        $("#yzc_faild").hide();
                        $("#yzc_ok").hide();
                    }else if(data.status==3){
                        console.log(data.name);
                        $("#yz_name").text(data.name);
                        $("#weChatName").val(data.name);
                        $("#yzc_faild").show();
                        $("#yzc_ok").hide();
                    }else if(data.status==4){
                        $("#yz_name").text('此玩家已代理！');
                        $("#yzc_faild").hide();
                        $("#yzc_ok").show();
                    }
                },
                error:function(err){}
            })
        });
        //2、获取焦点隐藏提示
        $("#UserGameId").focus(function(){
            $("#yz_name").text('等待验证');
            $("#yzc_faild").hide();
            $("#yzc_ok").hide();
            $(this).val("");
        });

        $("#UserTel").focus(function(event) {
            $("#tel_msg").hide();
        });
        $("#UserTel").blur(function(event) {
            if($("#UserTel").val()!= ''){
                vailPhone();
            }
        });
        
        //验证手机号
        function vailPhone(){
          var phone = $("#UserTel").val();
          var flag = false;
          var message = "";
          var myreg = /^(((13[0-9]{1})|(14[0-9]{1})|(17[0]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\d{8})$/;       
          if(phone == ''){
            message = "手机号码不能为空！";
          }else if(phone.length !=11){
            message = "请输入有效的手机号码！";
          }else if(!myreg.test(phone)){
            message = "请输入有效的手机号码！";
          }else{
              flag = true;
          }
          if(!flag){
            //提示错误效果
            $("#tel_msg").show();
            $("#tel_msg").removeClass('c_4baf43').addClass('c_ff5d20');
            $("#tel_msg").html(message);
          }
          return flag;
        }

        //提交表单
        $('#addAgent').click(function(){
            var playerid = $('#UserGameId').val();
            var name = $('#nickName').val();
            var tel = $('#UserTel').val();
            var wechat = $('#WeChat').val();
            var wechatName = $('#weChatName').val();
            var levelid = $('#AgentSet').val();
            if(!playerid||!name||!tel||!wechat||!wechatName||!levelid){ alert('参数有误,请查清楚,重新提交！'); return;} 

            $.ajax({
                url: 'openagents.php',
                type: 'POST',
                dataType: '',
                data: {'method': 'addAgent','playerid':playerid,'nickName':name,'wechat':wechat,'wechatName':wechatName,'tel':tel,'leviled':levelid},
                success:function(data){
                    alert(data);
                    window.location.reload();
                },
                error:function(err) {
                   
                }
            });
        });
    });
</script>