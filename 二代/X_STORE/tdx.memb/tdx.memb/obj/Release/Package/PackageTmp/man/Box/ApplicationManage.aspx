<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationManage.aspx.cs" Inherits="tdx.memb.man.Box.ApplicationManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width=" 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width=" 50%;">原来的</th>
                    <th width=" 50%;">欲更换为</th>
                </tr>
                <asp:Repeater ID="Rp_changeGoods" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;"><%#Eval("原来的")%>
                            </td>
                            <td style="text-align: center;"><%#Eval("新的")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="BtnYes" runat="server" Text="同意申请" CssClass="btn" OnClick="BtnYes_Click"/>
                <asp:Button ID="BtnNo" runat="server" Text="拒绝申请" CssClass="btn" OnClick="BtnNo_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
