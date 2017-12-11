<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IERM.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery.min.js"></script>
    <style type="text/css">
        .login {
            /*background: #1f2d3d;*/
            background-image: url(/img/background.jpg);
            background-size: 100% 100%;
            -moz-background-size: 100% 100%;
            -webkit-background-size: 100% 100%;
            position: fixed;
            left: 0;
            top: 0;
            right: 0;
            bottom: 0;
        }

            .login .card-box {
                box-shadow: 0 0 8px 0 rgba(0,0,0,.06),0 1px 0 0 rgba(0,0,0,.02);
                border-radius: 5px;
                -moz-border-radius: 5px;
                background-clip: padding-box;
                margin-bottom: 20px;
                background-color: #f9fafc;
                border: 2px solid #8492a6;
            }

            .login .title {
                margin: 0 auto 40px;
                text-align: center;
                color: #505458;
                font-weight: 400;
                font-size: 16px;
            }

            .login .loginform {
                width: 350px;
                padding: 35px 35px 15px;
            }

        .el-form-item {
            margin-bottom: 22px;
        }

        .el-form-item__content {
            line-height: 36px;
            position: relative;
            font-size: 14px;
            margin-left: 120px;
        }

        .el-form-item.is-error .el-input__inner {
            border-color: #ff4949;
        }

        .el-input, .el-input__inner {
            width: 100%;
            display: inline-block;
        }

        .el-form--label-left .el-form-item__label {
            text-align: left;
        }

        .el-input__inner {
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            background-color: #fff;
            background-image: none;
            border-radius: 4px;
            border: 1px solid #bfcbd9;
            box-sizing: border-box;
            color: #1f2d3d;
            font-size: inherit;
            height: 36px;
            line-height: 1;
            outline: 0;
            padding: 3px 10px;
            transition: border-color .2s cubic-bezier(.645,.045,.355,1);
        }

        .el-input, .el-input__inner {
            width: 100%;
            display: inline-block;
        }

            .el-input__inner:-ms-input-placeholder {
                color: #97a8be;
                font-size: 14px;
            }

            .el-input__inner:hover {
                border-color: #8391a5;
            }

            .el-input__inner:focus {
                outline: 0;
                border-color: #20a0ff;
            }

        .el-button--primary {
            display: inline-block;
            line-height: 1;
            white-space: nowrap;
            cursor: pointer;
            border: 1px solid #c4c4c4;
            color: #1f2d3d;
            margin: 0px 10px;
            padding: 10px 15px;
            border-radius: 4px;
            font-size: 14px;
            box-sizing: border-box;
            background-color: #20a0ff;
            -webkit-appearance: none;
            -moz-user-select: none;
            -webkit-user-select: none;
            -ms-user-select: none;
        }

            .el-button--primary:focus, .el-button--primary:hover {
                background: #4db3ff;
                border-color: #4db3ff;
                color: #fff;
            }

        .el-form-item__error {
            color: #ff4949;
            font-size: 12px;
            line-height: 1;
            padding-top: 4px;
            position: absolute;
            top: 100%;
            left: 0;
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidcode" runat="server" />
        <div class="login">
            <div class="el-form card-box loginform el-form--label-left" element-loading-text="正在登录..." style="position: absolute; left: 40%; top: 30%">
                <div class="title">
                    <div class="loginname">智能充电桩后台管理系统</div>
                </div>
                <div class="el-form-item">
                    <div class="el-form-item__content  " style="margin-left: 0px;">
                        <div class="el-input">
                            <asp:TextBox ID="txtusername" placeholder="账号" class="el-input__inner" runat="server" />
                            <div class="el-form-item__error">请输入用户名</div>
                        </div>

                    </div>
                </div>
                <div class="el-form-item ">
                    <div class="el-form-item__content" style="margin-left: 0px;">
                        <div class="el-input">
                            <asp:TextBox ID="txtpassword" placeholder="密码" TextMode="password" validateevent="true" class="el-input__inner" runat="server" />
                            <div class="el-form-item__error">请输入密码</div>

                        </div>
                    </div>
                </div>
                <div class="el-form-item ">
                    <div class="el-form-item__content" style="margin-left: 0px;">
                        <div class="el-input" style="float: left; width: 150px">
                            <asp:TextBox ID="txtcode" placeholder="验证码" class="el-input__inner" runat="server" />
                            <div id="divcode" class="el-form-item__error" runat="server">请输入验证码</div>
                        </div>
                        <div class="el-input" style="margin-left: 30px; width: 80px;">
                            <img src="Handler/ValidCode.ashx" id="imagecode" title="看不清，换一换！" alt="看不清，换一换！" onclick="refreshImg()" />
                        </div>
                    </div>
                </div>
                <div class="el-form-item" style="text-align: center">
                    <asp:Button ID="btnLogin" class="el-button--primary" Width="276px" Style="margin: 0px;" Text="登录" runat="server" />
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">

        //显示异常
        jQuery.fn.ShowError = function (msg) {
            $(this).parent().parent().parent().addClass("is-error");
            $(this).parent().children(".el-form-item__error").show();
            if (msg != undefined) {
                $(this).parent().children(".el-form-item__error").html(msg);
            }
        }
        //隐藏异常
        jQuery.fn.HideError = function (msg) {
            $(this).parent().parent().parent().removeClass("is-error");
            $(this).parent().children(".el-form-item__error").hide();
        }

        //验证码刷新
        function refreshImg() {
            var Image1 = document.getElementById("imagecode");
            if (Image1 != null) {
                Image1.src = Image1.src + "?r=" + Math.random();
            }
        }

        $(function () {
            //登录按钮
            $('#btnLogin').click(function () {
                //验证输入
                if ($('#txtusername').val().length == 0) {
                    $("#txtusername").ShowError("登录名不能为空！");
                    return false;
                } else {
                    $("#txtusername").HideError();
                }
                //密码
                if ($('#txtpassword').val().length == 0) {
                    $("#txtpassword").ShowError("密码不能为空！");
                    return false;
                } else {
                    $("#txtpassword").HideError();
                }
                //密码
                if ($('#txtcode').val().length == 0) {
                    $("#txtcode").ShowError("验证码不能为空！");
                    return false;
                } else {
                    $("#txtcode").HideError();
                }
                //验证登录
                $.post("Handler/Login.ashx", $("#form1").serialize(), function (data) {
                    if (data.IsSucceed) {
                        window.location.href = data.RedirectUrl;
                    } else {
                        $("#txtcode").ShowError(data.Msg);
                        return false;
                    }
                }, "json");
            });

            //IsRemember();
        });

    </script>
</body>
</html>
