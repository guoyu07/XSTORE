<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="boxManage.aspx.cs" Inherits="tdx.memb.man.Box.boxManage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="boxMAe.ascx" TagPrefix="rows" TagName="boxMAe" %>
<!DOCTYPE html>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <script src="../../../Shop/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <telerik:RadAjaxPanel runat="server">
            <input type="hidden" runat="server" id="counter" />
            <input type="hidden" runat="server" id="json_memory" />

            <asp:Label runat="server" ID="eidtlbl" Style="display: none"></asp:Label>
            <telerik:RadListView runat="server" ID="product_rep" ItemPlaceholderID="holder" OnNeedDataSource="product_rep_NeedDataSource" OnItemDataBound="product_rep_ItemDataBound">
                <LayoutTemplate>
                    <table id="tabId" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr style="text-align: center;">
                            <td width=" 12%; text-align: center;">位置</td>
                            <td width=" 12%; text-align: center;">酒店集团</td>
                            <td width=" 12%; text-align: center;">酒店</td>
                            <td width=" 12%; text-align: center;">库位</td>
                            <td width=" 12%; text-align: center;">MAC</td>
                            <td width=" 12%; text-align: center;">默认商品</td>
                            <td width=" 12%; text-align: center;">实际商品</td>
                            <td width=" 12%; text-align: center;">操作</td>
                        </tr>
                        <asp:PlaceHolder ID="holder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr id="test">
                        <td style="text-align: center;;valign:middle">
                              <asp:Label Style="text-align: center;" runat="server" ID="wz"><%#Container.DataItemIndex+1 %></asp:Label>
                        </td>
                    <rows:boxMAe runat="server" ID="boxme" itemindex="<%#Container.DataItemIndex %>" />
                        </tr>
                </ItemTemplate>

            </telerik:RadListView>
        </telerik:RadAjaxPanel>
        <div class="page-footer">
            <div class="btn-list">
                <input type="button" class="btn" id="plus" runat="server" value="增加项" title="增加项" onserverclick="plus_ServerClick" />
                <asp:Button ID="Btnrk" runat="server" Text="提交保存" CssClass="btn" OnClick="Btnrk_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
    </form>
</body>
</html>
