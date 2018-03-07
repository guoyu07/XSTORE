<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deal.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.deal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../css/mui.min.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css" />
    <link rel="stylesheet" href="../css/common.css" />
     <title>幸事多私享空间-业务处理</title>
    <style type="text/css">
        li {
            list-style: none;
        }

        #dealBox {
            width: 100%;
            background-color: #fff;
            position: fixed;
            top: 0;
            z-index: 99;
        }

            #dealBox .mui-segmented-control.mui-segmented-control-inverted .mui-control-item.mui-active {
                color: #FE8355;
                border-bottom: 2px solid #FF5C12;
                border-bottom-width: 50%;
            }

        .dealBoxControlContents {
            padding-top: 40px;
            width: 100%;
            margin-top: 10px;
        }

        .mui-table-view-cell {
            background-color: #fff;
        }

        .dealContent1Title {
            width: 100%;
            height: 40px;
            text-align: left;
            background-color: #fff;
            border-bottom: 1px solid #ddd;
            padding: 0 15px;
        }

        .ReplenishmentItem {
            margin-top: 10px;
            border-bottom: 1px solid #ddd;
        }

        .dealContent1Title span {
            line-height: 40px;
            font-size: 15px;
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

        #content2 .mui-table-view-cell input {
            width: 100%;
            border: none;
            background-color: #FF5C12;
            color: #fff;
            font-size: 14px;
            height: 40px;
        }

        .deliveryRecordContainer {
            width: 100%;
            margin-top: 15px;
        }

            .deliveryRecordContainer .deliveryRecordTitle {
                width: 100%;
                height: 40px;
                display: table;
                text-align: center;
                background-color: #fff;
                border-bottom: 1px solid #ddd;
            }

                .deliveryRecordContainer .deliveryRecordTitle span {
                    display: table-cell;
                    line-height: 40px;
                    font-size: 15px;
                }

        .fixedBox {
            position: fixed;
            bottom: 150px;
            width: 30px;
            z-index: 99;
            right: 5px;
            text-align: center;
            border: solid 1px #ccc;
            background: #fff;
        }

            .fixedBox div {
                width: 30px;
                height: 30px;
                line-height: 30px;
                border-bottom: solid 1px #ccc;
                text-align: center;
            }

                .fixedBox div:last-child {
                    border-bottom: none;
                }

                .fixedBox div a {
                    color: #ccc;
                    font-size: 14px;
                }

                .fixedBox div.clickOn {
                    background: #f60;
                }

                    .fixedBox div.clickOn a {
                        color: #fff;
                    }

        .ReplenishmentItem {
            display: none;
        }

            .ReplenishmentItem:first-child {
                display: block;
            }

        .imgWrap {
            width: 40px;
            height: 40px;
            margin-right: 10px;
        }

            .imgWrap img {
                width: 100%;
                height: 100%;
                display: block;
            }

        .info h3 {
            font: 14px/30px "microsoft yahei";
            color: #666;
        }

        .num {
            font: 14px/30px "microsoft yahei";
            color: #999;
        }

        .makeSure {
            margin-top: 10px;
            width: 100%;
            padding: 3%;
            background: #fff;
        }

            .makeSure a {
                width: 100%;
                font: 14px/40px "microsoft yahei";
                color: #fff;
                display: block;
                text-align: center;
                background: #f60;
            }

        .deliveryRecordContainer {
            display: none;
        }

            .deliveryRecordContainer:first-child {
                display: block;
            }

        .errorOperation ul li dl dd {
            width: 25%;
        }

            .errorOperation ul li dl dd a {
                width: 100%;
                display: block;
                text-align: center;
                font: 14px/30px "microsoft yahei";
                color: #000;
            }

        .forget ul li a button, .send button {
            color: #f60;
            border-color: #f60;
        }

        .mui-table-cell {
            position: relative;
        }

        .mui-btn-outlined.mui-btn-blue {
            position: absolute;
            bottom: 6px;
            right: 10px;
            border-color: #f60;
            color: #f60;
        }
        .mui-btn-blue.mui-active:enabled, .mui-btn-blue:enabled:active, .mui-btn-primary.mui-active:enabled, .mui-btn-primary:enabled:active, input[type=submit].mui-active:enabled, input[type=submit]:enabled:active {
            background-color: #f60;
            border-color: #f60;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <<div id="dealBox">
        <div id="dealBoxControl" class="mui-slider-indicator mui-segmented-control mui-segmented-control-inverted ">
            <a class="mui-control-item mui-active" href="#content1">待处理</a>
            <a class="mui-control-item" href="#content2">已处理</a>
        </div>
    </div>
    <div id="rdealBoxControlContents" class="dealBoxControlContents">
        <div id="content1" class="mui-control-content mui-active">
            <ul>
                <asp:Repeater runat="server" ID="pend_repeater">
                    <ItemTemplate>
                        <li class="mui-table-view-cell">
                            <div class="mui-table">
                                <div class="mui-table-cell mui-col-xs-10">
                                    <p class="mui-ellipsis AM_title"><span><%#Eval("品名") %></span> &nbsp;商品编码：<span><%#Eval("编号") %></span></p>
                                    <h5 class="numText">房间：<span><%#Eval("库位名") %></span> &nbsp;格号：<span class="danjia"><%#Eval("位置") %></span></h5>
                                    <p class="mui-h6 mui-ellipsis totle"><%#((DateTime)Eval("时间")).ToString("yyyy-MM-dd HH:mm") %></span> </p>
<%--                                    <input  runat="server" type="button"  id="confir1m" onserverclick="confirm_Click" class="mui-btn mui-btn-blue mui-btn-outlined" value="确认" data-id='<%#Eval("编号") %>' />--%>
                                    <button type="button" runat="server" id="confirm" onserverclick="confirm_Click" class="mui-btn mui-btn-blue mui-btn-outlined" data-id='<%#Eval("id")%>'>确认</button>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div id="content2" class="mui-control-content">
            <ul class="mui-table-view">
                <asp:Repeater runat="server" ID="deal_repeater">
                    <ItemTemplate>
                       <li class="mui-table-view-cell">
                            <div class="mui-table">
                                <div class="mui-table-cell mui-col-xs-10">
                                    <p class="mui-ellipsis AM_title"><span><%#Eval("品名") %></span> &nbsp;商品编码：<span><%#Eval("编号") %></span></p>
                                    <h5 class="numText">房间：<span><%#Eval("库位名") %></span> &nbsp;格号：<span class="danjia"><%#Eval("位置") %></span></h5>
                                    <p class="mui-h6 mui-ellipsis totle"><%#((DateTime)Eval("时间")).ToString("yyyy-MM-dd HH:mm") %></span> </p>
                           
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <script src="../js/plugins/mui.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/plugins/zepto.min.js"></script>
    <script>
        $(function () {
            $('#content1 .fixedBox div').on('click', function () {
                $(this).addClass('clickOn').siblings().removeClass('clickOn');
                var index = $(this).index();
                $('#content1 .ReplenishmentItem').eq(index).show().siblings().hide();
            })
            $('#content2 .fixedBox div').on('click', function () {
                $(this).addClass('clickOn').siblings().removeClass('clickOn');
                var index = $(this).index();
                $('#content2 .deliveryRecordContainer').eq(index).show().siblings().hide();
            })
        })
    </script>
    </form>
</body>
</html>
