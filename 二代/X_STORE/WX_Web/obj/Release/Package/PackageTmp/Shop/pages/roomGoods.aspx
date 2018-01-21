<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomGoods.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.roomGoods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/roomGoods.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="clearfix topTitle">
            <p class="roomNumber"><%=room_name %></p>
            <p class="distributer">配送员：<span><%=psy_name %></span></p>
        </div>
        <div class="interval"></div>
        <ul class="clearfix">
            <asp:Repeater ID="box_rp" runat="server">
                <ItemTemplate>
                     <li class="<%#list_li(Eval("实际商品id").ObjToInt(0),Eval("位置").ObjToInt(0),Eval("id").ObjToInt(0)) %>">
                        <a href="../pages/operation.aspx?boxid=<%#Eval("id") %>&room_id=<%=room_id %>">
                            <div class="pic">
                                <img src="<%#Eval("图片路径") %>" alt="" />
                                <p class="goodsName"><%#Eval("品名") %></p>
                            </div>
                        </a>
                        <div class="price">¥ <span><%#Eval("本站价").ObjToDecimal(0) %></span></div>
                        <div class="buy" id="is_ok" runat="server">正常</div>
                        <div class="empty" id="is_empty" runat="server">空箱</div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
  
        </ul>
    </form>
</body>
</html>
