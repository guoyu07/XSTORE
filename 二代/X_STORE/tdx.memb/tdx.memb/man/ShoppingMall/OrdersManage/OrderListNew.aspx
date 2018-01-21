<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderListNew.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.OrdersManage.OrderListNew" %>
<%@ Register TagPrefix="Feli" Namespace="FeliControls" Assembly="tdx.memb" %>
<!-- saved from url=(0038)http://order.jd.com/center/list.action -->
<html xmlns="http://www.w3.org/1999/xhtml" class="root61">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GBK" />
    <title>订单管理</title>
    <meta name="format-detection" content="telephone=no" />
    <link rel="stylesheet" type="text/css" href="../../css/order/common.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/myjd.order2015.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/basePatch.css" />

    <script type="text/jscript" src="../../Editor/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../js/order/loadFa.js"></script>
    <script type="text/javascript" src="../../js/order/payOrderList.js"></script>
    <link rel="stylesheet" type="text/css" href="../../css/order/slidebar.css" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/order/im_icon_v5.js"></script>
    <script type="text/javascript" src="../../js/order/wl.js"></script>
    <script type="text/javascript" src="../../Shop/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
        <link href="../../css/pagerStyle.css" rel="stylesheet" />
    <style type="text/css">
        li {
            display: inline;
        }

        .nopay {
            color: #808080;
        }
        .noopen {
           color: #800000;
        }
        .successpay {
            color: #8DB23A;
        }

        .failopen {
            color: #FE3535;
        }

        .failpay {
            color: #FFCC00;
        }

        .refundpay {
            color: #FFE596;
        }

        .refundsuccess {
            color: #52BBFB;
        }

        .nooneknow {
            color: #2D2D30;
        }

        .icon-list li {
            font-family: 微软雅黑;
            color: #666;
            margin-right: 15px;
            font-size: 12px;
        }

        .icon-list li input {
            margin: 5px;
            border: 1px solid #dddddd;
            height: 25px;
        }

        .timeclick {
            width: 100px;
        }

        .total-list li {
            margin: 5px;
            float: left;
        }

        .font-total {
            font-size: 18px;
            color: #50BDFF;
            font-weight: bolder;
        }
       

    </style>
    <script type="text/javascript">
        function tuikuan(sender) {
            var obj = $(sender);
            var orderno = obj.attr("order-list");
            if (confirm('确认此笔订单进行退款吗？')) {
                $.ajax({
                    type: "post",
                    datatype: "text",
                    url: "tuikuan.ashx",
                    data: { orderno: orderno },
                    async: false,
                    success: function (data) {
                        alert(data);
                        location.reload();

                    }
                });
                window.location.href = '../../Box/InStockAdd.aspx?bh=' + orderno;
            }
        }
        function ChangeState_ClientClick() {
            if (confirm("是否将订单改为已退款？")) {
                return true;
            }
            else {
                return false;
            }
        }

        function OpenBox_ClientClick() {
            if (confirm("是否进行开箱操作？")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="location">
        </div>
        <!--/导航栏-->
         <!--导航栏-->
        <div class="location">
             <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
              <a class="home"><i></i><span>首页</span></a>
              <i class="arrow"></i>
              <span>订单列表</span>
        </div>
        <!--工具栏-->
        <div class="toolbar-wap">
            <div class="toolbar">
                <div class="clear line10"></div>
    
                <div class="l-list" >
                    <ul class="icon-list">
                        <li>关键词:<asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        </li>
                        <li>起始日期:<input type="text" class="Wdate timeclick" runat="server" id="txtBeginTime" onclick="WdatePicker()" />
                            结束日期:<input type="text" class="timeclick Wdate" runat="server" id="txtEndTime" onclick=" WdatePicker()" />
                        </li>
                        <li>
                            <div class="menu-list">
                                <div class="rule-single-select">
                                    <asp:DropDownList ID="orderStateDll" runat="server" CssClass="select" style="margin-top: 5px;">
                                        <asp:ListItem Value="0">订单状态</asp:ListItem>
                                        <asp:ListItem Value="1">待付款</asp:ListItem>
                                         <asp:ListItem Value="2">待开箱</asp:ListItem>
                                        <asp:ListItem Value="3">已开箱</asp:ListItem>
                                        <asp:ListItem Value="5">开箱失败</asp:ListItem>
                                         <asp:ListItem Value="6">待处理</asp:ListItem>
                                        <asp:ListItem Value="7">退款完成</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </li>
                        
                    </ul>
                </div>
                <div class="r-list">
                    <ul class="icon-list">
                        <li>
                            <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        
        <div class="toolbar-wap">
            <div class="toolbar-wap">
                <div class="toolbar">
                    <div class="l-list">
                        <ul class="icon-list total-list">
                            <li>总金额：<span class="font-total"><%=  dic["总金额"] %></span> 元</li>
                            <li>总销量：<span class="font-total"><%=  dic["销量"]  %></span> 件</li>
                            <li>
                                <asp:LinkButton ID="btnExport" runat="server"  OnClick="btnExport_OnClick"  Style=" border-left: solid 1px #e1e1e1;"><i></i><span>订单导出</span></asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable" id="tavle1">
                <asp:Repeater ID="rptList1" runat="server">
                    <HeaderTemplate>
                        <thead>
                            <tr>
                                <th align="center" style="width: 60px;">选择</th>
                                <th align="left" style="width: 80px;">订单编号</th>
                                <th align="center" style="width: 80px;">支付方式</th>
                                <th align="left" style="width: 200px;">酒店</th>
                                <th align="left" style="width: 100px;">房间</th>
                                <th align="left" style="width: 200px;">商品信息</th>
                                <th align="center" style="width: 50px;">金额</th>
                                <th align="center" style="width: 150px;">下单时间</th>
  <%--                              <th align="center">支付时间</th>--%>
<%--                                <th align="center">结算状态</th>--%>
                                <th align="center" >订单状态</th>
                                <th align="center" >操作</th>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr id="tr1">
                            <td align="center">
                                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hideID" Value='<%#Eval("订单编号")%>' runat="server" />
                            </td>
                            <td align="left"><%#Eval("订单编号")%></td>
                            <td align="center"><%#Eval("支付方式")%></td>
                            <td align="left"><%#Eval("酒店名称")%></td>
                            <td align="left"><%#Eval("房间名称")%></td>
                            <td align="left"><span title="<%#Eval("商品信息")%>"><%#Eval("商品信息").ObjToStr().Length > 16?Eval("商品信息").ObjToStr().Substring(0,16)+"...":Eval("商品信息").ObjToStr()%></span></td>
                            <td align="right"><%#Eval("总金额")%></td>
                            <td align="center"><%#Eval("下单时间")%></td>
<%--                            <td align="center"><%#Eval("支付时间")%></td>--%>
<%--                            <td align="center"><%#Getzt(Eval("结算状态").ObjToStr()) %></td>--%>
                            <td align="center"><%#FormatOrderState(Eval("订单状态").ObjToStr())%></td>
                            <td align="center">
                               
                                <asp:LinkButton runat="server" ID="OpenBox" Visible='<%#(Eval("订单状态").ObjToInt(0)==5||Eval("订单状态").ObjToInt(0)==2)?true:false %>' OrderNo='<%#Eval("订单编号")%>' OnClick="OpenBox_Click" OnClientClick="return OpenBox_ClientClick()">开箱</asp:LinkButton>
                                 <asp:LinkButton runat="server" ID="ChangeState" Visible='<%#(Eval("订单状态").ObjToInt(0)==6)?true:false %>' OrderNo='<%#Eval("订单编号")%>' OnClick="ChangeState_Click" OnClientClick="return ChangeState_ClientClick()">处理</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>

                    <FooterTemplate>
                        <%#rptList1.Items.Count == 0 ? "<tr><td align='center' colspan='6'>暂无记录</td></tr>" : ""%>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
             <div class="page-footer">
                <div class="btn-list">
                    <Feli:Pager ID="fpgHistoryList" CssClass="pager" runat="server" OnPageIndexChanged="fpgHistoryList_PageIndexChanged" />
                </div>
            </div>
        </div>
        <!--列表展示.结束-->

    </form>
</body>

</html>
