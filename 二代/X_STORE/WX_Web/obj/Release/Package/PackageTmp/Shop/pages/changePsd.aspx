<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePsd.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.changePsd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>幸事多私享空间</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/changePsd.css" />

</head>

<body>
    <form id="form1" runat="server">
        <div class="oldPsd">
            <div class="wrap">
                <Label for="">手机号：</Label>
                <input name="tel" id="tel" placeholder="请输入手机号" runat="server" />
            </div>
        </div>
        <div class="oldPsd">
            <div class="wrap">
                <Label for="" >原密码：</Label>
                <input type="password" placeholder="请输入原密码" id="old_pswd" runat="server" />
            </div>
        </div>
        <div class="newPsd">
            <div class="wrap">
                <Label for="">新密码：</Label>
                <input runat="server" type="password" placeholder="请输入新密码" id="newPsd" />
            </div>
        </div>
        <div class="newPsdRepeat">
            <div class="wrap">
                <Label for="">新密码：</Label>
                <input runat="server" type="password" name="newPsdRepeat" id="newPsdRepeat" placeholder="请再次输入新密码" />
            </div>
        </div>
        <div class="btnWrap">
            <asp:Button class="changePsdBtn" ID="sub_pswd" Text="修改密码" OnClick="sub_pswd_Click" runat="server" />
        </div>
    </form>
</body>
</html>
