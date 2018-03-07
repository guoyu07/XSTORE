<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta charset="UTF-8">
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="Expires" content="0" />
		<meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
		<title>幸事多私享空间</title>
     <script src="../js/jquery-1.7.2.min.js"></script>
		<link rel="icon" href="../img/logo.png" type="image/x-icon"/>
		<link rel="stylesheet" href="../css/reset.css" />
		<link rel="stylesheet" href="../css/common.css" />
		<link rel="stylesheet" href="../css/login.css" />
     <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
        <script type="text/javascript">//2015年7月13日 20:55:03 微信分享JSSDK
        $(function () {
            var appid = 'wx4b52212c5d5983ad';
            wx.config({
                debug: false,// 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: 'wx4b52212c5d5983ad', // 必填，公众号的唯一标识  wx4b52212c5d5983ad
                timestamp: 1421142450,
                nonceStr: '9hKgyCLgGZOgQmEI',// 必填，生成签名的随机串
                signature: '<%=jsdkSignature%>',// 必填，签名，见附录1
                jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage']
            });
            wx.ready(function () {
                //1 判断当前版本是否支持指定 JS 接口，支持批量判断
                wx.checkJsApi({
                    jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage'],
                });
            });
        });
            //function show_password() {
            //    if ($("#pswd").attr("type")=="password") {
            //        $("#pswd").attr("");
            //    }
            //    $("#pswd").attr('type','text');
            //}
    </script>
</head>
<body>
    <form id="form1" runat="server">
		<div class="imgWrap">
			<img src="../img/logo.png" alt="" />
		</div>
		<div class="account">
			<input id="username" runat="server" type="text" placeholder="请输入用户名"/>
		</div>

		<div class="password">
            <span><input id="pswd" runat="server" type="password" placeholder="请输入密码"/></span>
			<span> <img style="display:none;" src="../img/_对勾.png" onclick="show_password();"/></span>
           
  		</div>
		<div class="btnWrap">
            <asp:Button id="login_btn" runat="server" OnClick="login_btn_Click" Text="登录" CssClass="loginBtn"  style="border:none;"/>
<%--			<div class="loginBtn" onclick="" id="login_div">登录</div>--%>
		</div>
    </form>
</body>
</html>
