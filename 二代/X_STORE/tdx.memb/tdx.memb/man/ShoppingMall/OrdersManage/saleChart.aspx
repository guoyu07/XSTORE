<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saleChart.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.OrdersManage.saleChart" %>
 <%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单管理</title>
    <script src="../../Shop/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>订单支付日志管理</span>
            <i class="arrow"></i>
            <span>订单支付日志管理</span>
        </div>
        <div>
             <asp:Repeater ID="rptList1" runat="server">
            <HeaderTemplate>
                <table width="100%" border="1" cellspacing="0" cellpadding="0" class="ltable" id="tavle1">
                    <thead>
                        <tr>
                            <th>序号</th>
                            <th>订单编号</th>
                            <th>支付金额</th>
                            <th>用户</th>
                            <th>支付时间</th>
                            <th>IP地址</th>
                        </tr>
             </HeaderTemplate>
             <ItemTemplate>
                  <tr id="tr1" >
                    <td id="序号" align="center" height="60px"><%# Container.ItemIndex+1%></td>
                    <td id="订单编号" align="center"><%#Eval("订单编号")%></td>
                    <td id="支付金额" align="center"><%#Eval("支付金额")%></td>
                    <td id="用户" align="center"><%#Eval("支付方式")%></div></td>
                    <td id="支付时间" align="center"><%#Eval("支付时间")%></div></td>
                    <td id="IP地址" align="center">IP地址</div></td>
                  </tr>
               </ItemTemplate>
         <FooterTemplate>
         <%#rptList1.Items.Count == 0 ? "<tr><td align='center' colspan='6'>暂无记录</td></tr>" : ""%>
        </table>
        </FooterTemplate>
        </asp:Repeater>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="" LastPageText=""
                    NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CssClass="pages" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
      </div>
    </form>
</body>
</html>
