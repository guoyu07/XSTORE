<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saleReport.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.saleReport" %>

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
            <h1 class="mui-title">无锡市</h1>
        </header>
        <div class="mui-content">
            <div class="ReportInputContaienr">
                <div class="selectBeginTime">
                    <span>选择开始时间</span>
                </div>
                <div class="line">
                    <span>&mdash;</span>
                </div>
                <div class="selectEndTime">
                    <span>选择结束时间</span>
                </div>
                <input type="button" id="" value="搜索" class="search" />
            </div>
            <div class="HL_listItem">
                <ul class="mui-table-view">
                    <asp:Repeater ID="sale_rp" runat="server">
                        <ItemTemplate>
                            <li class="mui-table-view-cell mui-media">
                                <a href="javascript:;" class="mui-navigate-right">
                                    <img class="mui-media-object mui-pull-left" src="../img/muwu.jpg">
                                    <div class="mui-media-body HL_text over">
                                        <%#Eval("酒店全称") %>
		    	                <p class="mui-ellipsis"><span class="name">酒店经理：<%=manger %></span><span class="Sales">销售额：&yen;<%#Eval("出价总额") %></span></p>
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
