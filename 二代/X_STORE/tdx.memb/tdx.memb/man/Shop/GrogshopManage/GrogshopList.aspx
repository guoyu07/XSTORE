<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrogshopList.aspx.cs" Inherits="tdx.memb.man.Shop.GoodsManage.GropshopList" EnableEventValidation="false" ViewStateEncryptionMode="Never" EnableViewStateMac="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
                li{ display:inline;}
    </style>

    <style type="text/css">
        .hide {
            display: none;
        }
    </style>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>酒店管理</span>
            <i class="arrow"></i>
            <span>酒店管理</span>
        </div>
        <!--/导航栏-->
        <div class="toolbar-wrap">
                            <ul class="icon-list">
                                <li>&nbsp;&nbsp;<span style="font-size: 12px;">酒店名</span>&nbsp;<asp:TextBox ID="txt_酒店名" runat="server" CssClass="input" /></li>
                                 <li class="rule-single-select">
                                        <asp:DropDownList ID="ddlA_is_self"  runat="server" CssClass="btn">
                                        <asp:ListItem Value="0">地区</asp:ListItem>
                                        <asp:ListItem Value="1">待付款</asp:ListItem>
                                        <asp:ListItem Value="2">待开箱</asp:ListItem>
                                        <asp:ListItem Value="3">已开箱</asp:ListItem>
                                        <asp:ListItem Value="4">支付失败</asp:ListItem>
                                        <asp:ListItem Value="5">开箱失败</asp:ListItem>
                                        <asp:ListItem Value="6">已退款</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server"><span>搜索</span></asp:LinkButton></span></li>
                            </ul>
         </div>
        <div class="mod-main mod-comm lefta-box" id="order02" runat="server">
             <asp:Repeater ID="rptList1" runat="server">
            <%-- 列表 --%>
               <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                            <tr>
                                <th align="center"></th>
                                <th align="center">序号</th>
                                <th align="center">酒店名称</th>
                                <th align="center">地区</th>
                                <th align="center" >电话</th>
                                <th align="center" >总数</th>
                                <th align="center" >业绩</th>
                                <th align="center" >区域管理</th>
                                <th align="center" >酒店经理</th>
                                <th align="center" >操作</th>
                            </tr>
                    </HeaderTemplate>

                     <ItemTemplate>
                              <tr id="tr1">
                                <td align="center">
                                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                                    <asp:HiddenField ID="hideID" Value='' runat="server" />
                                </td>
                                <td id="序号" align="center"><%# Container.ItemIndex+1%></td>
                                <td id="酒店名称" align="center"><%#Eval("酒店名称")%></td>
                                <td id="地区" align="center"><%#Eval("地区")%></td>
                                <td id="电话" align="center"><%#Eval("电话")%></td>
                                <td id="总数" align="center"><%#Eval("总数")%></td>
                                <td id="业绩" align="center"><%#Eval("业绩")%></td>
                                <td id="区域经理" align="center"><%#Eval("区域经理")%></td>
                                <td id="酒店经理" align="center"><%#Eval("酒店经理")%></td>
                                 <td id="操作" align="center">
                                     <asp:Button ID="修改" runat="server" Text="修改"></asp:Button>
                                     <asp:Button ID="房间" runat="server" Text="房间"></asp:Button>
                                     <asp:Button ID="删除" runat="server" Text="删除"></asp:Button>
                                 </td>
                              </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            <%#rptList1.Items.Count == 0 ? "<tr><td align='center' colspan='6'>暂无记录</td></tr>" : ""%>
                     </FooterTemplate>
                    </asp:Repeater>
                     <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="" LastPageText=""
                        NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CssClass="pages" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                      </webdiyer:AspNetPager>
                
            <!--/列表-->
          </div>
    </form>
</body>
</html>
