<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deliveryTask.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.deliveryTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-配送任务</title>
    <link rel="icon" href="img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/deliveryNote.css" />
</head>
<body>
    <form id="form1" runat="server">
        <ul>
            <asp:Repeater ID="task_rp" runat="server">
                <ItemTemplate>
                    <li class="">
                        <a href="equipment.html" class="clearfix">
                            <div class="imgWrap l">
                                <img src="../img/muwu.jpg"></div>
                            <div class="l info">
                                <p class="releaseTime over">发布时间: <span><%#Eval("时间") %></span></p>
                                <p class="releasePlace over">投放地点: <span><%#Eval("酒店简称") %>&nbsp;-&nbsp;<%#Eval("仓库名") %>&nbsp;-&nbsp;<%#Eval("库位名") %></span></p>
                            </div>
                            <div class="r">未投放</div>
                        </a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>


        </ul>
    </form>
</body>
</html>
