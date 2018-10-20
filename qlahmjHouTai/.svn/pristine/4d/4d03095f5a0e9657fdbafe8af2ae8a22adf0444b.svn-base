<?php /* Smarty version Smarty-3.1.15, created on 2018-07-28 10:02:33
         compiled from "F:\project\qlahmjHouTai\include\template\agent\registerAgent.tpl" */ ?>
<?php /*%%SmartyHeaderCode:209175b5bc0a9015670-65922674%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '3c5006afc3e9b9b7df050c504d51e27abf07c96e' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agent\\registerAgent.tpl',
      1 => 1532333314,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '209175b5bc0a9015670-65922674',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    '_REQUEST' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b5bc0a905fa07_07854175',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b5bc0a905fa07_07854175')) {function content_5b5bc0a905fa07_07854175($_smarty_tpl) {?>
<?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
    <div class="col-xs-12">
        <div id="search" class="collapse in">
        <form action="" method="POST" class="form-horizontal" role="form">
            
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">玩家ID</label>
                <div class="col-sm-9">
                    <input type="text" name="playerid" id="playerid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['playerid'];?>
" required="true" maxlength='10' placeholder="请输入玩家ID！"> 
                    <span id='game_msg'></span>
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">代理ID</label>
                <div class="col-sm-9">
                    <input type="text" name="agentid" id="agentid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['agentid'];?>
" maxlength='10' placeholder="请输入代理ID！">
                    <span id='agent_msg'></span> 
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">姓名</label>
                <div class="col-sm-9">
                    <input type="text" name="real_name" id="real_name" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['real_name'];?>
" required="true" placeholder="请输入姓名！" > 
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">手机</label>
                <div class="col-sm-9">
                    <input type="text" name="mobile" id="mobile" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['mobile'];?>
" required="true" maxlength='11' placeholder="请输入手机号！"> 
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">微信号</label>
                <div class="col-sm-9">
                    <input type="text" name="wechat" id="wechat" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['wechat'];?>
" required="true" placeholder="请输入微信号！" > 
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">等级</label>
                <div class="col-sm-9">
                    <select id = "AgentTopSet" name="isTop">
                        <option value="0">请选择代理等级</option>
                        <option value="1">总代(享受总额获利)</option>
                        <option value="2">核心 (享受65%返利)</option>
                        <option value="3">铂金 (享受55%返利)</option>
                        <option value="4">金牌 (享受45%返利)</option>
                    </select>
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">类型</label>
                <div class="col-sm-9">
                    <input type="radio" name="r_type" class="r_type" value="1" checked='true' > 开通
                    <input type="radio" name="r_type" class="r_type" value="2"> 升级
                </div>
            </div>

           <!--  <div class="form-group">
               <label class="col-sm-3 control-label no-padding-right">验证码</label>
               <div class="col-sm-9">
                   <input type="text" name="verify_code" id="code" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['user_name'];?>
" autocomplete="off" required="true" placeholder="输入验证码"> 
                   <a href="#"><img title="验证码" id="verify_code" src="<?php echo @constant('ADMIN_URL');?>
/panel/verify_code_cn.php" style="vertical-align:top"></a>
               </div>
           </div> -->
            
            <div class="form-group">
                <div class="col-md-offset-3 col-md-9">
                    <button class="btn btn-info" type="submit">开通</button>
                </div>
            </div>
            <div style="clear:both;"></div>
        </form>
        </div>
    </div>
</div>

<script type="text/javascript">
    $(function(){
        $("#verify_code").click(function(){
            var d = new Date()
            var hour = d.getHours(); 
            var minute = d.getMinutes();
            var sec = d.getSeconds();
            $(this).attr("src","<?php echo @constant('ADMIN_URL');?>
/panel/verify_code_cn.php?"+hour+minute+sec);
        });

        $(".r_type").change(function(){
            if($(this).val()==1){
                $('#agentid').attr('disabled', false);
                // $('#AgentTopSet').attr('disabled', false);
                $("button").text('开通');
            }else if($(this).val()==2){
                $('#agentid').attr('disabled', true);
                // $('#AgentTopSet').attr('disabled', true);
                $("button").text('升级');
            }
        });

        $('#AgentTopSet').change(function(){
            if($(this).val()==1){
                $('#agent_msg').text('');
                $('#agentid').val('');
                $('#agentid').attr('disabled', true);
            }else{
                $('#agentid').attr('disabled', false);
            }
        });

        $('#playerid').keyup(function(){
            var reg=/^[1-9]\d*$|^0$/;
            if(reg.test($(this).val())!=true){
                $(this).val("");
            }
        });

        $('#agentid').keyup(function(){
            var reg=/^[1-9]\d*$|^0$/;
            if(reg.test($(this).val())!=true){
                $(this).val("");
            }
        });

        $('#mobile').keyup(function(){
            var reg=/^[1-9]\d*$|^0$/;
            if(reg.test($(this).val())!=true){
                $(this).val("");
            }
            if($(this).val().length ==11){
                if(!(/^[1][3,4,5,7,8][0-9]{9}$/.test($(this).val()))){ 
                    alert("手机号码有误！请重新"); 
                    $(this).val("");
                } 
            }
        });

        $('#mobile').blur(function(){
            if(!$(this).val()) return;
            if(!(/^[1][3,4,5,7,8][0-9]{9}$/.test($(this).val()))){ 
                alert("手机号码有误！请重新"); 
                $(this).val("");
            } 
        });

        $("button").click(function(event) {
            playerid = $("#playerid").val();
            agentid = $("#agentid").val();
            if(playerid&&agentid){
                if(playerid == agentid){
                    alert('玩家和代理不同相同！');
                    event.preventDefault();
                }  
            }
        });
        //输入玩家ID 获取上级代理
        /*$("#playerid").blur(function(event) {
            if(!$('#playerid').val()) return;
            $.ajax({
                url: '/houtai/agent/registerAgent.php',
                type: 'POST',
                dataType: '',
                data: {method: 'getAgentTopInfor',playerid:$('#playerid').val()},
                success:function(data){
                    data = jQuery.parseJSON(data);
                    console.log(data['agentid']);
                },
                error:function(){}
            });
        });*/
        
        $('#playerid').focus(function(event) {
            $('#game_msg').text('');
            $('#playerid').val('');
        });

        $('#playerid').blur(function(){
            var playerid = $('#playerid').val();
            if(!playerid) return;
            $.ajax({
                url:'/houtai/agent/registerAgent.php',
                data:{
                    method:'getGameInfor',
                    playerid:playerid
                },
                type:'POST',
                dataType:'',
                success:function(res){
                    res = jQuery.parseJSON(res);
                    if(res['result']){
                        $('#game_msg').text(res['result']);
                        return;
                    }
                    $('#game_msg').text('('+res['m_lUid']+')'+res['m_sNickName']);
                    $('#real_name').val(res['m_sNickName']);
                },
                error:function(){
                }
            });
        });

        $('#agentid').focus(function(event) {
            $('#agent_msg').text('');
            $('#agentid').val('');
        });

        $('#agentid').blur(function(){
            var agentid = $('#agentid').val();
            if(!agentid) return;
            $.ajax({
                url:'/houtai/agent/registerAgent.php',
                data:{
                    method:'getAgentInfor',
                    agentid:agentid
                },
                type:'POST',
                dataType:'',
                success:function(res){
                    res = jQuery.parseJSON(res);
                    if(res['result']){
                        $('#agent_msg').text(res['result']);
                        return;
                    }
                    $('#agent_msg').text('('+res['user_game_id']+')'+res['nickName']);
                },
                error:function(){

                }
            });
        });

    });


</script>

<!-- <?php echo $_smarty_tpl->getSubTemplate ("footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>
 --><?php }} ?>
