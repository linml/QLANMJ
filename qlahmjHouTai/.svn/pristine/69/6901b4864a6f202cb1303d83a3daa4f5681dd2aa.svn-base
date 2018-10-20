<?php /* Smarty version Smarty-3.1.15, created on 2018-08-06 16:39:46
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toOpenAgents.tpl" */ ?>
<?php /*%%SmartyHeaderCode:216185b601f5fd793b1-19680478%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '01d0685be102a70ad261ee659d347e6194486eb5' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toOpenAgents.tpl',
      1 => 1533541153,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '216185b601f5fd793b1-19680478',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b601f5fd810b8_33288080',
  'variables' => 
  array (
    'levleData' => 0,
    'levle' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b601f5fd810b8_33288080')) {function content_5b601f5fd810b8_33288080($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<div class="pdlr20">
<div class="openAgent">
    <div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg3.png);">
    <a href="javascript:history.back(-1)" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">开通代理</div>
    </div>
    <div class="w_710" style="margin-top: 22%">
        <div class="pdg_lr30 relative borderBox w_full h_100 lh_100  mgTp3 font28 c_28 bgfff">
            游戏ID
            <input type="number" placeholder="请输入代理的游戏ID" class="inputStyle absolute font28  h_full wp_75 c_28_8 top0 leftP23" id="UserGameId" min="0"/>
        </div>
        <p class="font24 mgTp3 c_999">验证结果：<span id="yz_name" class="c_28">等待验证</span><span class="c_4baf43" id="yzc_faild">(未注册)</span><span class="c_ff5d20" id="yzc_ok">(已注册)</span></p>
        <div class="mgTp3 bgfff">
            <div class="pdg_lr30 relative borderBox w_full h_100 lh_100 borderB_f0 font28 c_28">
                姓名
                <input type="text"  class="inputStyle absolute font28  h_full wp_75 c_28_8 top0 leftP23" id ='nickName' placeholder="请输入代理商昵称" />
            </div>
            <div class="pdg_lr30 relative borderBox w_full h_100 lh_100 borderB_f0 font28 c_28">
                手机号
                <input type="number"  required="true" min="0" placeholder="请输入正确的代理手机号" class="inputStyle absolute font28  h_full wp_75 c_28_8 top0 leftP23" id='UserTel' /><span id='tel_msg'></span>
            </div>


            <div class="pdg_lr30 relative borderBox w_full h_100 lh_100 borderB_f0 font28 c_28 hidden">
                微信昵称
                <input type="text" required="true" placeholder="请输入微信昵称" class="inputStyle absolute font28  h_full wp_75 c_28_8 top0 leftP23" id ='weChatName'/>
            </div>

            <div class="pdg_lr30 relative borderBox w_full h_100 lh_100 borderB_f0 font28 c_28">
                微信号
                <input type="text" required="true" placeholder="请输入微信号" class="inputStyle absolute font28  h_full wp_75 c_28_8 top0 leftP23" id ='WeChat'/>
            </div>

            <div class="pdg_lr30 relative borderBox w_full h_100 lh_100 borderB_f0 font28 c_28">
                级别
                <select class="inputStyle absolute font28 bg_arrowR h_full wp_75 c_28_8 top0 leftP23" id = "AgentSet">
                    <?php  $_smarty_tpl->tpl_vars['levle'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['levle']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['levleData']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['levle']->key => $_smarty_tpl->tpl_vars['levle']->value) {
$_smarty_tpl->tpl_vars['levle']->_loop = true;
?>
                        <option value="<?php echo $_smarty_tpl->tpl_vars['levle']->value['levelid'];?>
"><?php echo $_smarty_tpl->tpl_vars['levle']->value['name'];?>
 (享受<?php echo $_smarty_tpl->tpl_vars['levle']->value['discount'];?>
%返利)</option>
                    <?php } ?>
                </select>
            </div>
        </div>
        
        <div class="textCenter font32 mgTp3 c_fff w_full h_90 lh_90 br_8 bg_btn3" id="addAgent">开通代理</div>
        <p class="mgTp3 ft14 c_999">
            1、游戏ID请在游戏大厅里获取。<br/>
            2、代理商需熟悉游戏玩法，有较广的人脉，有一定的推广经验。<br/>
            3、建议开通后，制定开局要求，每天开局至少保持10局。<br/>
            4、开通后，代理的玩家充值后你可获得间接返利。<br/>
            5、返利详情可咨询客服，微信号：qllamj
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
</script><?php }} ?>
