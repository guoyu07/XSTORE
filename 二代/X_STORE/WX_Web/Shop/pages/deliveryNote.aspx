<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deliveryNote.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.deliveryNote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-投放记录</title>
    <link rel="icon" href="img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/deliveryNote.css" />
        <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../css/mui.min.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <style>
        .dealContent1Title {
            width: 100%;
            height: 40px;
            background-color: #fff;
            border-bottom: 1px solid #ddd;
            padding: 0 15px;
        }

            .dealContent1Title span {
                line-height: 40px;
                font-size: 15px;
            }

        .mui-content {
            background: #fefefe;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <header class="mui-bar mui-bar-nav mui-clearfix dealContent1Title">
            <span class="mui-pull-left">投放记录</span>
            <span class="mui-pull-right">总计：<%=total_num %></span>
        </header>
        <div class="mui-content">
            <ul>
                <asp:Repeater ID="rp_note" runat="server">
                    <ItemTemplate>
                         <li class="mui-table-view-cell">
		                <div class="mui-table">
		                    <div class="mui-table-cell mui-col-xs-10">
		                        <p class="mui-ellipsis AM_title"><span><%#Eval("品名") %></span> &nbsp;商品编码：<span><%#Eval("编码") %></span></p>
		                        <h5 class="numText">房间：<span><%#Eval("库位名") %></span> &nbsp;格号：<span class="danjia"><%#Eval("箱子位置") %></span></h5>
		                        <p class="mui-h6 mui-ellipsis totle"><%#((DateTime)Eval("时间")).ToString("yyyy-MM-dd HH:mm") %></span> </p>
		                    </div>
		                </div>
		            </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <%--<ul>
            <asp:Repeater ID="rp_note" runat="server">
                <ItemTemplate>
                    <li class="">
                        <a href="javascript:;" class="clearfix">
                            <div class="imgWrap l">
                                <img src="../img/muwu.jpg">
                            </div>
                            <div class="l info">
                                <p class="releaseTime over ">发布时间: <span><%#Eval("时间") %></span></p>
                                <p class="releasePlace over">投放地点: <span><%#Eval("酒店简称") %>&nbsp;-&nbsp;<%#Eval("仓库名") %>&nbsp;-&nbsp;<%#Eval("库位名") %></span></p>
                            </div>
                        </a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>

        </ul>--%>
    </form>
</body>
</html>
