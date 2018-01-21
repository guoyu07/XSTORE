<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="achievement.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.achievement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link rel="stylesheet" type="text/css" href="../css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../css/mui.min.css" />
    <title>幸事多私享空间-业绩列表</title>
    <style type="text/css">
        #AchievementBox {
            width: 100%;
            background-color: #fff;
            position: fixed;
            top: 0;
            left: 0;
            z-index: 99;
        }

            #AchievementBox .mui-segmented-control.mui-segmented-control-inverted .mui-control-item.mui-active {
                color: #FE8355;
                border-bottom: 2px solid #FF5C12;
                border-bottom-width: 50%;
            }

        .sliderAchievementControlContents {
            width: 100%;
            margin-top: 50px;
        }

        .AM_title {
            font-size: 15px;
            color: #000000;
        }

        .numText {
            font-size: 14px;
            color: #666;
        }

        .danjia {
            margin-left: 10px;
            font-size: 14px;
            color: #666;
        }

        .totle {
            font-size: 14px;
            color: #666;
        }

            .totle .yuan {
                font-size: 14px;
                color: #FF0000;
            }

        .bootomBar {
            position: fixed;
            bottom: 0;
            width: 100%;
            height: 50px;
            padding: 0 15px;
            text-align: right;
            background-color: #fff;
        }

            .bootomBar p {
                color: #000000;
                font-size: 15px;
                line-height: 50px;
                margin: 0;
                text-align: right;
            }

                .bootomBar p span {
                    color: #FF5053;
                    font-size: 14px;
                }

        .Am_table > tbody > tr:active {
            background-color: #f5f5f5;
        }

        .Am_table {
            width: 100%;
            background-color: #fff;
        }

            .Am_table tbody tr th {
                padding: 10px 8px;
                border-bottom: 1px solid #ddd;
                text-align: center;
                font-size: 15px;
            }

            .Am_table tbody tr td {
                padding: 10px 8px;
                border-bottom: 1px solid #ddd;
                text-align: center;
                font-size: 14px;
            }

                .Am_table tbody tr td:last-child {
                    color: #ff5001;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="AchievementBox">
            <div id="sliderAchievementControl" class="mui-slider-indicator mui-segmented-control mui-segmented-control-inverted ">
                <a class="mui-control-item mui-active" id="today" href="#content1">24小时</a>
                <a class="mui-control-item" id="Week" href="#content2">7天</a>
                <a class="mui-control-item" id="waitDeliver" href="#content3">本月</a>
                <a class="mui-control-item" id="Month" href="#content4">本年</a>
                <a class="mui-control-item" id="All" href="#content5">全部</a>
            </div>
        </div>
        <div id="sliderAchievementControlContents" class="sliderAchievementControlContents">
            <div id="content1" class="mui-control-content mui-active">
                <table border="" cellspacing="" cellpadding="" class="Am_table">
                    <tr>
                        <th>商品</th>
                        <th>单价</th>
                        <th>数量</th>
                        <th>金额</th>
                    </tr>
                    <asp:Repeater runat="server" ID="Today">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("品名") %></td>
                                <td>¥ <span><%#Eval("本站价") %></span></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                                <td>¥ <span><%#Eval("总价") %></span></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </table>
                <div class="bootomBar">
                    <p>总计：<span>¥<%=Atoatal %></span></p>
                </div>
            </div>
            <div id="content2" class="mui-control-content">
                <table border="" cellspacing="" cellpadding="" class="Am_table">
                    <tr>
                        <th>商品</th>
                        <th>单价</th>
                        <th>数量</th>
                        <th>金额</th>
                    </tr>
                    <asp:Repeater ID="AWeek" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("品名") %></td>
                                <td>¥ <span><%#Eval("本站价") %></span></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                                <td>¥ <span><%#Eval("总价") %></span></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </table>
                <div class="bootomBar">
                    <p>总计：<span>¥<%=Btoatal %></span></p>
                </div>
            </div>
            <div id="content3" class="mui-control-content">
                <table border="" cellspacing="" cellpadding="" class="Am_table">
                    <tr>
                        <th>商品</th>
                        <th>单价</th>
                        <th>数量</th>
                        <th>金额</th>
                    </tr>
                    <asp:Repeater runat="server" ID="Amounth">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("品名") %></td>
                                <td>¥ <span><%#Eval("本站价") %></span></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                                <td>¥ <span><%#Eval("总价") %></span></td>
                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>

                </table>
                <div class="bootomBar">
                    <p>总计：<span>¥<%=Ctoatal %></span></p>
                </div>
            </div>
            <div id="content4" class="mui-control-content">
                <table border="" cellspacing="" cellpadding="" class="Am_table">
                    <tr>
                        <th>商品</th>
                        <th>单价</th>
                        <th>数量</th>
                        <th>金额</th>
                    </tr>
                    <asp:Repeater ID="Ayear" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("品名") %></td>
                                <td>¥ <span><%#Eval("本站价") %></span></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                                <td>¥ <span><%#Eval("总价") %></span></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </table>
                <div class="bootomBar">
                    <p>总计：<span>¥<%=Dtoatal %></span></p>
                </div>
            </div>
            <div id="content5" class="mui-control-content">
                <table border="" cellspacing="" cellpadding="" class="Am_table">
                    <tr>
                        <th>商品</th>
                        <th>单价</th>
                        <th>数量</th>
                        <th>金额</th>
                    </tr>
                    <asp:Repeater runat="server" ID="AllGoods">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("品名") %></td>
                                <td>¥ <span><%#Eval("本站价") %></span></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                                <td>¥ <span><%#Eval("总价") %></span></td>
                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>

                </table>
                <div class="bootomBar">
                    <p>总计：<span>¥<%=Etoatal %></span></p>
                </div>
            </div>
        </div>


        <script src="../js/plugins/mui.min.js" type="text/javascript" charset="utf-8"></script>
    </form>
</body>
</html>
