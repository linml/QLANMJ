<?php /* Smarty version Smarty-3.1.15, created on 2018-09-05 16:29:54
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\toUpdatePassword.tpl" */ ?>
<?php /*%%SmartyHeaderCode:229615b602159e5b949-63150357%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'cf2919ad6fb50c4eca65be65d94b7b7894b34739' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\toUpdatePassword.tpl',
      1 => 1536110470,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '229615b602159e5b949-63150357',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b602159e9dfd4_95441596',
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b602159e9dfd4_95441596')) {function content_5b602159e9dfd4_95441596($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg4.png);">
    <a href="/agentCenter/Mine.php" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">账户安全</div>
</div>
<div class="N_Wrap" style="bottom:0;">
    <div class="N_WrapAuto wp_94 mgTp3A">
        <div class="N_Pad">
            <form action="" id="passwordfrm" method="POST">
            <div class="N_AddForm N_AddForm2">
                <dl>
                    <dt>当前密码</dt>
                    <dd><input type="password" name="prepsw" id="prepsw" placeholder="请输入当前密码" required></dd>
                </dl>
                <dl>
                    <dt>设置密码</dt>
                    <dd><input type="password" name="newpsw" id="newpsw" placeholder="6-18位字符" onblur="valiPassword()" required minlength="6" maxlength="18"></dd>
                </dl>
                <dl>
                    <dt>确认密码</dt>
                    <dd><input name="confirmpsw" type="password" id="confirmpsw" placeholder="6-18位字符" onblur ="validate()" required minlength="6" maxlength="18"></dd>
                </dl>
            </div>
            <div class="NbcBtn"><button type="submit" id="updatePsw">确认修改</button> </div>
            </form>
        </div>
    </div>
</div>
<script type="text/javascript">
          function validate() {
              var pwd1 = document.getElementById("newpsw").value;
              var pwd2 = document.getElementById("confirmpsw").value;
    // <!-- 对比两次输入的密码 -->
              if(pwd1 == pwd2) {   
                  document.getElementById("updatePsw").disabled = false;
              }
              else {
                  alert("两次输入密码不相同")
                document.getElementById("updatePsw").disabled = true;
              }
          }

          function valiPassword(){
            var newpsw = document.getElementById("newpsw").value;
            var prepsw = document.getElementById("prepsw").value;
            if(newpsw == prepsw) {
              $("#confirmpsw").val('');
              $("#newpsw").val('');
              $("#newpsw").focus();
              alert('当前密码和修改密码相同,请更换密码！');
              document.getElementById("updatePsw").disabled = false;
            }
          }
</script><?php }} ?>
