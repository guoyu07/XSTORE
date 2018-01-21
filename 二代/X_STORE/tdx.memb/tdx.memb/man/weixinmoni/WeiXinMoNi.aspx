<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiXinMoNi.aspx.cs" Inherits="tdx.memb.man.weixinmoni.WeiXinMoNi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="/memb/images4/nei.css" type="text/css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        #TextArea1
        {
            height: 503px;
            width: 673px;
        }
        #html
        {
            height: 289px;
            width: 652px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>发送图文:</strong>模拟登陆</h1>
    <div class="nei_content" id="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/memb/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/memb/images4/xx.png">
        </div>
        <div style="color: Red">
            <h2>
                本工具使用简介：<br />
                1.先输入用于登陆微信公众平台的公众号账户和密码进行登陆<br />
                2.根据登陆后的分组可以选择刷新分组同步账户信息到本系统。<br />
                3.可以点击刷新图文列表进行图文信息的展示（展示公众平台的素材资源）<br />
                4.可根据刷新出来的图文列表按录入微信号单人发送和对已获取微信号列表进行批量发送
            </h2>
        </div>
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    账户名:
                </td>
                <td class="enter_content">
                    <asp:TextBox ID="zhanghao" class="px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    密码:
                </td>
                <td class="enter_content">
                    <asp:TextBox ID="mima" class="px" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <asp:Button ID="Button1" runat="server" class="btnSave" OnClick="login" Text="登陆" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    分组:
                </td>
                <td class="enter_content">
                    <asp:DropDownList ID="fenzu" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Literal ID="anniu" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    <asp:Literal ID="mingzi" runat="server"></asp:Literal>
                </td>
                <td class="enter_content">
                    <input type="text" class="px" id="weixinname" placeholder="请输入微信号" />
                </td>
                <td>
                    <input type="button" class="btnSave" id="wxfsanniu" onclick="sendfun();" value="发送" />
                    <input type="button" class="btnSave" id="Button2" onclick="Qsendfun();" value="批量发送" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    </div>
    <br />
    <div id="neirong">
    </div>
    </form>
</body>
</html>

