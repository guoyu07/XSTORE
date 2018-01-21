<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodsList.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.goodsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/goodsList.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="topNav clearfix">
            <div class="l goodsTitle">商品</div>
            <div class="r destributerTitle">配送员</div>
        </div>
        <div class="interval"></div>
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
        <div class="interval"></div>
        <div class="goods">
            <table border="1">
                <tr class="topic">
                    <th>商品</th>
                    <th>单价</th>
                    <th>数量</th>
                    <th>金额</th>
                </tr>
                <asp:Repeater ID="goods_rp" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("品名") %></td>
                            <td>¥ <span><%#Eval("出价") %></span></td>
                            <td>× <span><%#Eval("数量") %></span></td>
                            <td>¥ <span><%#Eval("总出价额") %></span></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="total_money">
                合计： ¥ <span><%=total %></span>
            </div>
        </div>
        <div class="distributer">
            <dl>
                <dt class="clearfix">
                    <div class="l">姓名</div>
                    <div class="r">投递次数</div>
                </dt>
                <asp:Repeater ID="td_rp" runat="server">
                    <ItemTemplate>
                        <dd class="clearfix">
                            <div class="l"><%#Eval("用户名") %></div>
                            <div class="r"><%#Eval("次数") %></div>
                        </dd>
                    </ItemTemplate>
                </asp:Repeater>
            </dl>
        </div>
        <script src="../js/plugins/zepto.min.js"></script>
        <script src="../js/modules/goodsList.js"></script>
    </form>
</body>
</html>
