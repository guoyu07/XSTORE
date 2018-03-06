<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stockDetail.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.stockDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link rel="stylesheet" type="text/css" href="../css/mui.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/common.css" />
    <link rel="stylesheet" type="text/css" href="../css/hotelList.css" />
    <title>幸事多私享空间</title>
    <style>
        a .mui-ellipsis .yuan {
            color: #8f8f94;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
            <h1 class="mui-title" id="hotel_area_h1" runat="server"></h1>
        </header>
        <div class="mui-content">
            <div class="topInputContaienr">
<%--                <input type="text" id="" value="" placeholder="请输入酒店名称" />--%>
                               <asp:TextBox ID="chaxun" placeholder="请输入酒店名称" runat="server" OnTextChanged="chaxun_TextChanged"></asp:TextBox>
            </div>
            <div class="HL_listItem">
                <ul class="mui-table-view">
                    <asp:Repeater ID="stockDetail_rp" runat="server">
                        <ItemTemplate>
                            <li class="mui-table-view-cell mui-media">
                                <a href="stockList.aspx?ztk_id=<%#Eval("库位id")%>">
                                    <img class="mui-media-object mui-pull-left" src="../img/muwu.jpg">
                                    <div class="mui-media-body HL_text">
                                        <%#Eval("仓库") %>
                                        <p class="mui-ellipsis"><span class="yuan">酒店经理：<b><%#Eval("真实姓名")%></b></span><span class="kucun">库存：<b><%#Eval("库存") %></b></span></p>
                                    </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                   
                </ul>
            </div>
        </div>
        <script src="../js/plugins/mui.min.js" type="text/javascript" charset="utf-8"></script>
    </form>
</body>
</html>
