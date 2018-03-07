<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomsPickUp.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.roomsPickUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-常规补货</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon">
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/roomsPickUp.css" />
</head>
<body>
    <form id="form1" runat="server">
       
        <div runat="server" id="list_div">
            <ul class="clearfix">
                <asp:Repeater ID="rooms_rp" runat="server">
                    <ItemTemplate>
                        <li class="offLine">
                            <a href="#">
                                <img src="../img/room.png" /><p class="roomNumber"><%#Eval("库位名") %></p>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
         <div  class="alarm_div">
             然后到如下任何一个房间启动补货。
            补货时，售货机需先上线【上电后，LED灯闪烁停止】，采用微信对售货机顶部二维码扫码，点击“立即进入ENTER”，需要补货的格子门将自动打开。为方便后续补货操作，您需要点击“确认”后，点击手机左上角的“X”，退到微信主页面。
        </div>
        <div class="noRoom" runat="server" style="text-align:center;padding-top:40%;" id="empty_div">
            <p>暂无配送任务</p>
            <a href="<%=redirect_url %>">返回</a>
        </div>
    </form>
</body>
</html>
