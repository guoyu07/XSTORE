<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrogshopRoomManage.aspx.cs" Inherits="tdx.memb.man.Shop.GrogshopManage.GrogshopRoomManage" %>
 <%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>酒店房间管理</title>
     <script src="../../Shop/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
      <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>酒店房间管理</span>
            <i class="arrow"></i>
            <span>酒店房间管理</span>
        </div>
        <div class="toolbar-wrap">
                <ul class="icon-list">
                    <li class="rule-single-select">
                        <asp:DropDownList ID="ddlA_keyword"  runat="server" CssClass="btn">
                        <asp:ListItem Value="0">按关键字</asp:ListItem>
                        <asp:ListItem Value="1">酒店id</asp:ListItem>
                        <asp:ListItem Value="2">酒店名称</asp:ListItem>
                        <asp:ListItem Value="3">房间id</asp:ListItem>
                        <asp:ListItem Value="4">房间名称</asp:ListItem>
                        <asp:ListItem Value="5">按照MAC码</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li><asp:TextBox ID="txt_关键字" runat="server" CssClass="input" /></li>
                    <li class="rule-single-select">
                        <asp:DropDownList ID="ddlA_region"  runat="server" CssClass="btn">
                        <asp:ListItem Value="0">按地区</asp:ListItem><%--动态绑定地区--%>
                        </asp:DropDownList>
                    </li>
                     <li>&nbsp;&nbsp;<span style="font-size: 12px;">销量</span>&nbsp;<input type="text"  runat="server" id="txt_销量最小"/><span>--</span>&nbsp;<input type="text"  runat="server" id="txt_最大"/></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server"><span>搜索</span></asp:LinkButton></span></li>
                  </ul>
         </div>
            <div>
                     <asp:Repeater ID="rptList1" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="1" cellspacing="0" cellpadding="0" class="ltable" id="tavle1">
                            <thead>
                                <tr>
                                    <th>序号</th>
                                    <th>酒店名称</th>
                                    <th>房间名称</th>
                                    <th>总数</th>
                                    <th>业绩</th>
                                    <th>正常</th>
                                    <th>空箱</th>
                                    <th>开箱</th>
                                    <th>故障</th>
                                    <th>停用</th>
                                    <th>离线</th>
                                    <th>操作</th>
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
