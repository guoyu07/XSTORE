<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deal.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.deal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../css/mui.min.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <title>幸事多私享空间-业务处理</title>
    <style type="text/css">
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
            list-style: none;
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
        }

            .fixedBox div {
                width: 30px;
                height: 30px;
                line-height: 30px;
                font-size: 14px;
                border-radius: 15px;
                color: #fff;
                background-color: #FF5001;
                text-align: center;
                margin-bottom: 15px;
            }

                .fixedBox div a {
                    color: #fff;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="dealBox">
            <div id="dealBoxControl" class="mui-slider-indicator mui-segmented-control mui-segmented-control-inverted ">
                <a class="mui-control-item mui-active" href="#content1">常规补货</a>
                <a class="mui-control-item" href="#content2">异常处理</a>
            </div>
        </div>

        <%--        <div class="fixedBox">
            <div><a href="#shouldReplenishment">应</a></div>
            <div><a href="#realityReplenishment">实</a></div>
            <div><a href="#noReplenishment">未</a></div>


        </div>--%>

        <div id="rdealBoxControlContents" class="dealBoxControlContents">
            <div id="content1" class="mui-control-content mui-active">
                <div class="fixedBox">
                    <div class="clickOn"><a>应</a></div>
                    <div><a>实</a></div>
                    <div><a>取</a></div>
                </div>
                <div class="box">
                    <div class="ReplenishmentItem shouldReplenishment" id="shouldReplenishment">
                        <div class="dealContent1Title">
                            <span>应补货</span>
                            <span class="mui-pull-right">总计：<%=totalA %>件</span>
                        </div>
                        <asp:Repeater ID="A_rp" runat="server">
                            <ItemTemplate>
                                <li class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-10">
                                            <p class="mui-ellipsis AM_title"><%#Eval("品名") %></p>
                                            <h5 class="numText">数量：x1 <span class="danjia">箱号：<%#Eval("位置") %></span><span class="danjia">房间：<%#Eval("库位名") %></span></h5>
                                            <p class="mui-h6 mui-ellipsis totle"><%#Eval("时间") %></span> </p>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="ReplenishmentItem Replenishmented" id="realityReplenishment">
                        <div class="dealContent1Title">
                            <span>实际补货</span>
                            <span class="mui-pull-right">总计：<%=totalB %>件</span>
                        </div>
                        <asp:Repeater ID="B_rp" runat="server">
                            <ItemTemplate>
                                <li class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-10">
                                            <p class="mui-ellipsis AM_title"><%#Eval("品名") %></p>
                                            <h5 class="numText">数量：x1 <span class="danjia">箱号：<%#Eval("位置") %></span><span class="danjia">房间：<%#Eval("库位名") %></span></h5>
                                            <p class="mui-h6 mui-ellipsis totle"><%#Eval("时间") %></span> </p>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>

                    <div class="ReplenishmentItem Replenishmented" id="noReplenishment">
                        <div class="dealContent1Title">
                            <span>未补货</span>
                            <span class="mui-pull-right">总计：<%=totalC %>件</span>
                        </div>
                        <asp:Repeater runat="server" ID="C_rp">
                            <ItemTemplate>
                                <li class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-10">
                                            <p class="mui-ellipsis AM_title"><%#Eval("品名") %></p>
                                            <h5 class="numText">数量：x1 <span class="danjia">箱号：<%#Eval("位置") %></span><span class="danjia">房间：<%#Eval("库位名") %></span></h5>
                                            <p class="mui-h6 mui-ellipsis totle"><%#Eval("时间") %></span> </p>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
        </div>
                    <div id="content2" class="mui-control-content">
                        <ul class="mui-table-view">
                            <li class="mui-table-view-cell">
                                <input type="button" value="补错开箱" />
                            </li>
                            <li class="mui-table-view-cell">
                                <input type="button" value="忘补开箱" />
                            </li>
                            <li class="mui-table-view-cell">
                                <input type="button" value="前台送货" />
                            </li>
                        </ul>

                        <div class="deliveryRecordContainer">
                            <div class="deliveryRecordTitle">
                                <span>送货记录</span>
                            </div>
                            <asp:Repeater ID="pagesB_rp" runat="server">
                                <ItemTemplate>
                                    <li class="mui-table-view-cell">
                                        <div class="mui-table">
                                            <div class="mui-table-cell mui-col-xs-10">
                                                <p class="mui-ellipsis AM_title"><%#Eval("品名") %></p>
                                                <h5 class="numText">数量：x1 <span class="danjia">箱号：<%#Eval("位置") %></span><span class="danjia">房间：<%#Eval("库位名") %></span></h5>
                                                <p class="mui-h6 mui-ellipsis totle"><%#Eval("时间") %></span> </p>
                                            </div>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
        </div>
                <script src="../js/plugins/mui.min.js" type="text/javascript" charset="utf-8"></script>
        <script src="../js/plugins/zepto.min.js"></script>
		<script>
			$(function(){
				$('.fixedBox div').on('click',function(){
					$(this).addClass('clickOn').siblings().removeClass('clickOn');
					var index=$(this).index();
					$('.ReplenishmentItem').eq(index).show().siblings().hide();
				})
			})
		</script>
    </form>
</body>
</html>
