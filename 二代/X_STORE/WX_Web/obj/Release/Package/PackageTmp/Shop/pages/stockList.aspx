<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stockList.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.stockList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link rel="stylesheet" type="text/css" href="../css/mui.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/common.css" />
    <link rel="stylesheet" type="text/css" href="../css/hotelList.css" />
    <title>幸事多私享空间</title>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
            <h1 class="mui-title">库存商品名称</h1>
        </header>
        <div class="mui-content">
            <div class="topInputContaienr">
              <%--  <input type="text" id="sousuo" value="" placeholder="请输入物品名称" runat="server" />--%>
               <asp:TextBox ID="chaxun" placeholder="请输入物品名称" runat="server" OnTextChanged="search_TextChanged" ></asp:TextBox>
            </div>
            <div class="HL_listItem">
                <ul class="mui-table-view">

                    <asp:Repeater ID="totalstock_rp" runat="server">
                        <ItemTemplate>
                            <li class="mui-table-view-cell mui-media">
                              <%--  <a href="stockList.aspx">--%>
                                    <img class="mui-media-object mui-pull-left" src=" <%#Eval("图片路径") %>">
                                    <div class="mui-media-body HL_text">
                                        <%#Eval("品名") %>
		    	                <p class="mui-ellipsis"><span class="yuan">¥ <b><%#Eval("本站价") %></b></span><span class="kucun">库存：<b><%#Eval("库存") %></b></span></p>
                                    </div>
                              <%--  </a>--%>
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
