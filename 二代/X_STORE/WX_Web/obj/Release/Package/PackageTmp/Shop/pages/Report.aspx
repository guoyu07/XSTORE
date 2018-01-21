<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-报表中心</title>
    <link rel="icon" href="img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../css/mui.min.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/goodsList.css" />
    <link rel="stylesheet" type="text/css" href="../css/hotelList.css" />
    <style type="text/css">
        #reportBox {
            width: 100%;
            background-color: #fff;
            position: fixed;
            top: 0;
            left: 0;
            z-index: 99;
        }

            #reportBox .mui-segmented-control.mui-segmented-control-inverted .mui-control-item.mui-active {
                color: #FE8355;
                border-bottom: 2px solid #FF5C12;
                border-bottom-width: 50%;
            }

        .ReportInputContaienr .line {
            top: 0;
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
                }

        .ReportInputContaienr {
            height: 50px;
        }

            .ReportInputContaienr .selectBeginTime input, .ReportInputContaienr .selectEndTime input {
                width: auto;
                padding: 0;
                margin: 0;
                border: none;
                text-align: center;
            }

            .ReportInputContaienr div p {
                padding: 0;
                margin: 0;
                border: none;
                font-size: 12px;
                width: 100%;
                text-align: center;
            }

        .reportBoxControlContents {
            width: 100%;
            margin-top: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="reportBox">
            <div id="reportBoxControl" class="mui-slider-indicator mui-segmented-control mui-segmented-control-inverted ">
                <a class="mui-control-item mui-active" id="Product" href="#content1">商品</a>
<%--                <a class="mui-control-item" id="Sale" href="#content2">销售</a>--%>
                <a class="mui-control-item" id="deliveryPerson" href="#content3">补货</a>
            </div>
        </div>
        <div id="reportBoxControlContents" class="reportBoxControlContents">
            <div id="content1" class="mui-control-content mui-active">

                <div class="ReportInputContaienr">
                    <div class="selectBeginTime">
                        <p>选择开始时间</p>
                        <input placeholder="选择开始时间" type="date"/>
                    </div>
                    <div class="line">
                        <span>&mdash;</span>
                    </div>
                    <div class="selectEndTime">
                        <p>选择结束时间</p>
                        <input placeholder="选择结束时间" type="date"/>
                    </div>
<input type="button" id="" value="搜索" class="search"/>
                </div>
                <table border="1" class="Am_table" style="margin-bottom: 50px;">
                    <tr class="topic">
                        <th>商品</th>
                        <th>单价</th>
                        <th>数量</th>
                        <th>金额</th>
                    </tr>
                    <asp:Repeater ID="A_rp" runat="server">
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
                    <p>总计：<span>¥<%=total_price %></span></p>
                </div>
            </div>
<%--            <div id="content2" class="mui-control-content">
                <div class="ReportInputContaienr">
                    <div class="selectBeginTime">
                        <p>选择开始时间</p>
                        <input placeholder="选择开始时间" type="date">
                    </div>
                    <div class="line">
                        <span>&mdash;</span>
                    </div>
                    <div class="selectEndTime">
                        <p>选择结束时间</p>
                        <input placeholder="选择结束时间" type="date">
                    </div>
                    <input type="button" id="" value="搜索" class="search" />
                </div>
                <div class="HL_listItem">
                    <ul class="mui-table-view">

                        <asp:Repeater ID="B_rp" runat="server">
                            <ItemTemplate>
                                <li class="mui-table-view-cell mui-media">
                                    <a href="javascript:;" class="mui-navigate-right">
                                        <img class="mui-media-object mui-pull-left" src="../img/muwu.jpg">
                                        <div class="mui-media-body HL_text over">
                                            <%#Eval("仓库名") %>
			    	                <p class="mui-ellipsis"><span class="name">酒店经理：<%#Eval("真实姓名") %></span><span class="Sales">销售额：&yen;<%#Eval("总价") %></span></p>
                                        </div>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>


                    </ul>
                </div>
            </div>--%>
            <div id="content3" class="mui-control-content">
                <table border="" cellspacing="" cellpadding="" class="Am_table">
                    <tr>
                        <th>姓名</th>
                        <th>投递次数</th>
                    </tr>

                    <asp:Repeater ID="C_rp" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("真实姓名") %></td>
                                <td><%#Eval("投放") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </table>
            </div>
        </div>
        <script src="../js/plugins/mui.min.js" type="text/javascript" charset="utf-8"></script>
    </form>
</body>
</html>
