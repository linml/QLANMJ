<{include file = "simple_header.tpl"}>
<!DOCTYPE html>
<html lang="en"><!--<![endif]--><!-- BEGIN HEAD --><head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <meta charset="utf-8">

    <title>七乐棋牌代理管理系统</title>

    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">

    <meta content="" name="description">

    <meta content="" name="author">

    <!-- BEGIN GLOBAL MANDATORY STYLES -->

    <link href="./pigcms_tpl/Merchants/Static//files/bootstrap.min.css" rel="stylesheet" type="text/css">

    <link href="./pigcms_tpl/Merchants/Static//files/bootstrap-responsive.min.css" rel="stylesheet" type="text/css">

    <link href="./pigcms_tpl/Merchants/Static//files/font-awesome.min.css" rel="stylesheet" type="text/css">

    <link href="./pigcms_tpl/Merchants/Static//files/style-metro.css" rel="stylesheet" type="text/css">

    <link href="./pigcms_tpl/Merchants/Static//files/style.css" rel="stylesheet" type="text/css">

    <link href="./pigcms_tpl/Merchants/Static//files/style-responsive.css" rel="stylesheet" type="text/css">

    <link href="./pigcms_tpl/Merchants/Static//files/default.css" rel="stylesheet" type="text/css" id="style_color">

    <link href="./pigcms_tpl/Merchants/Static//files/uniform.default.css" rel="stylesheet" type="text/css">

    <!-- END GLOBAL MANDATORY STYLES -->

    <!-- BEGIN PAGE LEVEL STYLES -->

    <link href="./pigcms_tpl/Merchants/Static//files/login.css" rel="stylesheet" type="text/css">

    <!-- END PAGE LEVEL STYLES -->

    <link rel="shortcut icon" href="./pigcms_tpl/Merchants/Static//files/favicon.ico">

</head>

<!-- END HEAD -->

<!-- BEGIN BODY -->

<body>

<!-- BEGIN LOGO -->

<!--<div class="logo">



</div>-->

<!-- END LOGO -->
<style>
	html{
		height:100%;
	}
	body{
		background:#ffffff !important;
		height:100%;
	}
</style>
<link href="./pigcms_tpl/Merchants/Static/all_files/style-common.css" rel="stylesheet" type="text/css">
<!-- BEGIN LOGIN -->

<div class="N_LoginWrap">
	<form class="form-vertical login-form" action="toLogin;JSESSIONID=9da86052-2d3c-43b5-b116-6008440a7549?t=111222#">
    	<div class="N_LoginMain">
        	<div class="N_LoginCell">
            	<div class="N_LoginLogo"><img src="./pigcms_tpl/Merchants/Static/NewImg/loginTitle.png"></div>
                <div class="N_LoginForm">
                	<dl class="clearfix">
                    	<dt class="N_Login_icon1"></dt>
                        <dd><input type="text" placeholder="请输入手机号/账号名" id="username" name="username" value=""></dd>
                    </dl>
                	<dl class="clearfix">
                    	<dt class="N_Login_icon2"></dt>
                        <dd><input type="password" placeholder="请输入密码" id="password" name="password"></dd>
                    </dl>
                    <div><input type="button" id="login" class="N_LoginSub" value="登录"></div>
                </div>
            </div>
        </div>
    </form>
    <!-- <a href="/dlIndex.php?m=Index&c=toaddagent&a=index" class="N_resLinks">注册代理</a> -->
</div>

<!-- END LOGIN -->

<!-- BEGIN COPYRIGHT -->



<!-- END COPYRIGHT -->

<!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->

<!-- BEGIN CORE PLUGINS -->

<script src="./pigcms_tpl/Merchants/Static//files/jquery-1.10.1.min.js" type="text/javascript"></script>

<script src="./pigcms_tpl/Merchants/Static//files/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>

<!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->

<script src="./pigcms_tpl/Merchants/Static//files/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>

<script src="./pigcms_tpl/Merchants/Static//files/bootstrap.min.js" type="text/javascript"></script>

<!--[if lt IE 9]>

<script src="/resources/js/excanvas.min.js"></script>

<script src="/resources/js/respond.min.js"></script>

<![endif]-->

<script src="./pigcms_tpl/Merchants/Static//files/jquery.slimscroll.min.js" type="text/javascript"></script>

<script src="./pigcms_tpl/Merchants/Static//files/jquery.blockui.min.js" type="text/javascript"></script>

<script src="./pigcms_tpl/Merchants/Static//files/jquery.cookie.min.js" type="text/javascript"></script>

<script src="./pigcms_tpl/Merchants/Static//files/jquery.uniform.min.js" type="text/javascript"></script>

<!-- END CORE PLUGINS -->

<!-- BEGIN PAGE LEVEL PLUGINS -->

<script src="./pigcms_tpl/Merchants/Static//files/jquery.validate.min.js" type="text/javascript"></script>

<!-- END PAGE LEVEL PLUGINS -->

<!-- BEGIN PAGE LEVEL SCRIPTS -->

<script src="./pigcms_tpl/Merchants/Static//files/app.js" type="text/javascript"></script>
<script src="./pigcms_tpl/Merchants/Static//files/login.js" type="text/javascript"></script>
<script src="./pigcms_tpl/Merchants/Static//files/bootbox.js" type="text/javascript"></script>

<!-- END PAGE LEVEL SCRIPTS -->

<script>
    jQuery(document).ready(function() {
        var n = 0;
        App.init();
        //$("#password").val('');

        $("#login").on("click", function(e) {
            var username = $("#username").val();
            var psw = $("#password").val();
            var verifycode = $("#chkcode").val();
            if(username == '' || psw == '' || verifycode == '') {
                n++;
                bootbox.alert({
                    buttons: {
                        ok: {
                            label: '确认',
                            className: 'btn-myStyle'
                        }
                    },
                    message: '账号、密码和验证码不能为空!',
                    callback: function() {
                        changeCode();
                        n = 0;
                    }
                });
                return false;
            }
            /*if(!$('#Ready').prop('checked')) {
             n++;
             bootbox.alert({
             buttons: {
             ok: {
             label: '确认',
             className: 'btn-myStyle'
             }
             },
             message: '如果你已阅读合作协议，请勾选同意!',
             callback: function() {
             n = 0;
             }
             });
             return false;
             }*/
            var param = {};
            param.username = username;
            param.password = psw;
            param.verifycode = verifycode;
            var url = "dlIndex.php?m=Index&c=dllogin&a=login";
            var callback = function(data) {
                if(data.result == 'AccountErr') {
                    var oImgs = new Array(
                        '774017971',
                        '1228599948'
                    );
                    var n = oImgs.length;
                    var currIndex = Math.floor(Math.random() * n);
                    bootbox.alert({
                        buttons: {
                            ok: {
                                label: '确认',
                                className: 'btn-myStyle'
                            }
                        },
                        message: '账号或者密码输入有误,重新输入！',
                        callback: function() {
                            //window.location.href = "dlIndex.php?m=Index&c=dllogin&a=index";
                        }
                    });
                    return false;
                } else if(data.result == 'chkErr') {
                    bootbox.alert({
                        buttons: {
                            ok: {
                                label: '确认',
                                className: 'btn-myStyle'
                            }
                        },
                        message: '验证码错误!',
                        callback: function() {
                            $("#chkcode").val('');
                            changeCode();
                        }
                    });
                    return false;
                } else if(data.result == 'disableErr') {
                    bootbox.alert({
                        buttons: {
                            ok: {
                                label: '确认',
                                className: 'btn-myStyle'
                            }
                        },
                        message: '账号未启用,请联系管理员!',
                        callback: function() {}
                    });
                    return false;
                }else if(data.result == 'noAgreeErr')
                {
                    bootbox.alert({
                        buttons: {
                            ok: {
                                label: '确认',
                                className: 'btn-myStyle'
                            }
                        },
                        message: '账号未通过审核,请联系管理员!',
                        callback: function() {}
                    });
                    return false;

                }else if(data.result == 'bannedErr')
                {
                    bootbox.alert({
                        buttons: {
                            ok: {
                                label: '确认',
                                className: 'btn-myStyle'
                            }
                        },
                        message: '您的账户已经系统锁定，请联系官方客服处理!',
                        callback: function() {}
                    });
                    return false;

                }else if(data.result == 'AgreeErr') {

                    bootbox.alert({
                        buttons: {
                            ok: {
                                label: '确认',
                                className: 'btn-myStyle'
                            }
                        },
                        message: '账号未启用,请联系管理员!',
                        callback: function() {}
                    });
                    return false;
                }
                else if(data.result == 'py') {
                    //window.location.href = "/agent/toGameRecharge";
                } else {
                    if(data.isUpdate == 'N') {
                        //window.location.href = "/login/toForceUpdatePassword";
                    } else {
                        window.location.href = "dlIndex.php?m=Index&c=index&a=home";
                    }
                }

            }
            $.post(url, param, callback, 'json');

        });

        document.onkeydown = function(e) {
            var ev = document.all ? window.event : e;
            if(ev.keyCode == 13 && n < 1) {

            }
        };

        function changeCode() {
            $("#codeImg").attr("src", "captcha.php?t=" + Math.random());
        }
        changeCode();
        $("#codeImg").bind("click", changeCode);

        $("#change").bind("click", changeCode);
        /*$("#toCoorper").on("click", function() {
         window.open("/login/toAgreement");
         });*/
    });
</script>

<!-- END JAVASCRIPTS -->



<!-- END BODY -->

</body></html>
<{include file = "footer.tpl"}>