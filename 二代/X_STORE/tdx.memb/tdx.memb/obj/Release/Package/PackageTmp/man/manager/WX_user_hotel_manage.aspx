<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WX_user_hotel_manage.aspx.cs" Inherits="tdx.memb.man.manager.WX_user_hotel_manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../js/select2.js"></script>
    <link href="../../css/select2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <%-- <asp:ScriptManager runat="server"></asp:ScriptManager>
        <telerik:RadAjaxPanel runat="server">--%>
            <asp:HiddenField ID="hidd_number" runat="server" />
            <table width="100%" border="1" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="25%">选择</th>
                    <th width="25%">酒店</th>
                </tr>
                <asp:Repeater ID="rp_hotel" runat="server" OnItemDataBound="rp_hotel_ItemDataBound">
                    <ItemTemplate>
                        <tr runat="server">
                            <td style="text-align: center;" runat="server">
                                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" name="check_goods" />
                                <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                            </td>
                            <td style="text-align: center;"><%#Eval("仓库")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        <%--</telerik:RadAjaxPanel>--%>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="" LastPageText=""
            NextPageText="下一页" CssClass="pages" CurrentPageButtonClass="cpb" PrevPageText="上一页">
        </webdiyer:AspNetPager>
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="dj();" />

                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>

    </form>
</body>
</html>
