<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gongyingshangjiesuan.aspx.cs" Inherits="tdx.memb.man.jiesuan.gongyingshangjiesuan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="build/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="location">
        </div>
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">供应商</span>
                            <asp:DropDownList CssClass="input" ID="ddl_gys" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_gys_SelectedIndexChanged"></asp:DropDownList>
                        </li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">开始时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_start" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">结束时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_end" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="sousuo_click" Text="搜索" OnClick="sousuo_Click" /></li>
                        <li>
                            <asp:LinkButton ID="LBtn_Export" runat="server" OnClick="LBtn_Export_Click" CssClass="add"><i></i><span>导出</span></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
            <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th style="width: 20%">选择</th>
                    <th style="width: 16%">供应商名称</th>
                    <th style="width: 16%">结算金额</th>
                    <th style="width: 16%">结算日期</th>
                    <th style="width: 30%">经办人</th>
                </tr>
                <asp:Repeater ID="Rp_gys" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                <asp:HiddenField ID="hidId" Value='<%#Eval("供应商id")%>' runat="server" />
                                <%-- <asp:Label Style="text-align: center;" runat="server"><%#Eval("供应商id")%></asp:Label>--%>
                            </td>
                            <td style="text-align: center;"><%#Eval("公司名称")%></td>
                            <td style="text-align: center;"><%#Eval("total")%></td>
                            <td style="text-align: center;"><%#Eval("操作日期")%></td>
                            <td style="text-align: center;"><%#Eval("[user_name]")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="tdh">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator"
                    NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
