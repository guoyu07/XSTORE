<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bind.aspx.cs" Inherits="XStore.WebSite.WebSite.Login.Bind" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title><%=Title %></title>
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../../Scripts/Plugins/layer.js"></script>

    <link rel="icon" href="../../Content/Icon/logo.png" type="image/x-icon" />

    <link rel="stylesheet" href="../../Content/Login/reset.css" />
    <link rel="stylesheet" href="../../Content/Login/common.css" />
    <link rel="stylesheet" href="../../Content/Login/Bind.css" />

    <link rel="stylesheet" href="../../Content/layer.css" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="name">
            <div class="wrap">
                <label>姓名：</label><input type="text" id="name_input" runat="server" placeholder="请输入姓名" />
            </div>
        </div>
        <div class="tel">
            <div class="wrap">
                <label>手机号：</label><input type="text" id="phone_input" runat="server" placeholder="请输入手机号" />
            </div>
        </div>
        <div class="checkCode">
            <div class="wrap clearfix">
                <div class="l">
                    <label>验证码：</label><input type="text" runat="server" placeholder="请输入验证码" /></div>
                <div class="btn r" data-code=""><a class="getCode">获取验证码</a><a class="cutDown"><span>60</span>秒</a></div>
            </div>
        </div>
        <div class="account">
            <div class="wrap">
                <label for="">账号：</label><input type="text" id="account_input" runat="server" placeholder="请输入账号" /></div>
        </div>
        <div class="newPsd">
            <div class="wrap">
                <label for="">新密码：</label><input type="password" runat="server" placeholder="请输入新密码" /></div>
        </div>
        <div class="newPsdRepeat">
            <div class="wrap">
                <label for="">新密码：</label><input type="password" runat="server" placeholder="请再次输入新密码" /></div>
        </div>
        <div class="btnWrap">
            <input type="button" class="changePsdBtn" value="修改信息" />
        </div>

        <script>
            function system_alert(message) {
                layer.open({
                    title: ['系统提示', 'background-color:#F60; color:#fff;'],
                    content: message,
                    btn: 'OK'
                });
            }
            $(function () {
                var telreg = /^(((13[0-9]{1})|(14[0-9]{1})|(15[0-9]{1})|(17[0-9]{1})|(18[0-9]{1}))+\d{8})$/;
                var unreg = /^[a-zA-Z0-9_]{6,16}$/;
                var yzm;
                $('.getCode').on('click', function () {
                    var phone = $(".tel input").val();
                    var url = "../ashx/SendMessage.ashx";
                    $.post(url, { phone: phone }, function (response) {
                        if (response.state === 0) {
                            yzm = response.code;
                            alert(response.info);
                        }
                        else {
                            alert(response.info);
                        }

                    }, "json");
                    $(this).hide().siblings().show();
                    cut_down();
                });
                function cut_down() {
                    var time = 60;
                    var timer = setInterval(function () {
                        if (time > 1) {
                            time--;
                            $('.cutDown span').html(time);
                        } else {
                            clearInterval(timer);
                            $('.cutDown').hide().siblings().show();
                        }
                    }, 1000);
                };
                $('.newPsd input').on('blur', function () {
                    if ($(this).val().trim().length < 6) {
                        layer.open({
                            content: '密码至少6位',
                            skin: 'msg',
                            time: 2
                        })
                    }
                });
                $('.newPsdRepeat input').on('blur', function () {
                    if ($(this).val().trim().length < 6) {
                        layer.open({
                            content: '密码至少6位',
                            skin: 'msg',
                            time: 2
                        });

                    } else if ($(this).val().trim() != $('.newPsd input').val().trim()) {
                        layer.open({
                            content: '两次密码不一致',
                            skin: 'msg',
                            time: 2
                        });
                    } else {
                    }
                });
                $('.changePsdBtn').on('click', function () {
                    if ($('.name input').val().trim() == '') {
                        layer.open({
                            content: '姓名不能为空',
                            skin: 'msg',
                            time: 2
                        });
                    } else if ($('.tel input').val().trim() == '') {
                        layer.open({
                            content: '手机号不能为空',
                            skin: 'msg',
                            time: 2
                        });
                    } else if (!telreg.test($('.tel input').val().trim())) {
                        layer.open({
                            content: '手机号不正确',
                            skin: 'msg',
                            time: 2
                        });
                    } else if ($('.checkCode input').val().trim() == "") {
                        layer.open({
                            content: '请输入验证码',
                            skin: 'msg',
                            time: 2
                        });
                    } else if ($('.checkCode input').val().trim() != yzm) {
                        layer.open({
                            content: '请输入正确的验证码',
                            skin: 'msg',
                            time: 2
                        });
                    } else if ($('.account input').val().trim() == "") {
                        layer.open({
                            content: '请输入账号',
                            skin: 'msg',
                            time: 2
                        });
                    } else if (!unreg.test($('.account input').val().trim())) {
                        layer.open({
                            content: '账号为6位至16位的字母数字组合',
                            skin: 'msg',
                            time: 2
                        });
                    } else if ($('.newPsd input').val().trim() == '') {
                        layer.open({
                            content: '请输入密码',
                            skin: 'msg',
                            time: 2
                        });
                    } else if ($('.newPsd input').val().trim().length < 6) {
                        layer.open({
                            content: '密码至少6位',
                            skin: 'msg',
                            time: 2
                        });
                    } else if ($('.newPsdRepeat input').val().trim() != $('.newPsd input').val().trim()) {
                        layer.open({
                            content: '两次密码不相同',
                            skin: 'msg',
                            time: 2
                        });
                    } else {
                        var name = $('.name input').val();
                        var phone = $('.tel input').val();
                        var account = $('.account input').val();
                        var password = $('.newPsd input').val();
                        var url = "../ashx/ModifyPassword.ashx";
                        $.post(url, { name: name, phone: phone, account: account, password: password }, function (response) {
                            if (response.state === 0) {
                                system_alert(修改成功)
                            }
                            else {
                                alert(response.info);
                            }

                        }, "json");
                    }
                });
            })
        </script>

    </form>
</body>
</html>
