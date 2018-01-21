<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kwSalesVolume.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.OrdersManage.kwSalesVolume" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>库位销量汇总</title>
    <link rel="stylesheet" type="text/css" href="../../css/order/common.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/myjd.order2015.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/basePatch.css" />
    <script src="../../Editor/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../js/order/loadFa.js"></script>
    <script type="text/javascript" src="../../js/order/payOrderList.js"></script>
    <link rel="stylesheet" type="text/css" href="../../css/order/slidebar.css" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/order/im_icon_v5.js"></script>
    <script type="text/javascript" src="../../js/order/wl.js"></script>
    <script src="../../Shop/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="ordertype" runat="server" />
        <div class="location">
        </div>
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">库位名</span>&nbsp;<asp:TextBox ID="txt_kw_name" runat="server" CssClass="input" /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">开始时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_start" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">结束时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_end" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>
                        <li>
                            <asp:LinkButton ID="LBtn_Export" runat="server" OnClick="LBtn_Export_Click" CssClass="add"><i></i><span>导出</span></asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
            <table style="width:100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th style="width:10%">库位名</th>
                    <th style="width:10%">酒店名</th>
                    <th style="width:10%">销售总量</th>
                    <th style="width:10%">销售总额</th>
                </tr>
                <asp:Repeater ID="rp_order" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <asp:HiddenField ID="hidId" Value='<%#Eval("库位id")%>' runat="server" />
                                <%#Eval("库位名") %>
                            </td>
                            <td style="text-align: center;">
                                <%#Eval("酒店名") %>
                            </td>
                            <td style="text-align: center;"><%#Eval("总量") %></td>
                            <td style="text-align: center;"><%#Eval("总额")%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%#rp_order.Items.Count == 0 ? "<tr><td align='center' colspan='6'>暂无记录</td></tr>" : ""%>
                    </FooterTemplate>
                </asp:Repeater>
            </table>

            <%-- 分页2017-4-24 --%>
            <div class="tdh">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator" 
                    NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>
            <%--  分页2017-4-24 --%>
        </div>
    </form>
</body>
</html>
