<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutockManage.aspx.cs" Inherits="tdx.memb.man.Box.OutockManage" %>

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
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="9%">出库号</th>
                <th width="9%">品名</th>
                <th width="9%">规格</th>
                <th width="9%">市场价</th>
                <th width="9%">出价</th>
                <th width="9%">出库数量</th>
                <th width="9%">库存数量</th>
            </tr>
            <asp:Repeater ID="Rp_Outocklist" runat="server">
                        <ItemTemplate>
                            <tr>
                                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                 <td style="text-align: center;"><%#Eval("单据编号")%></td>
                                 <td style="text-align: center;"><%#Eval("品名")%></td>
                                <td style="text-align: center;"><%#Eval("规格")%></td>
                                <td style="text-align: center;"><%#Eval("市场价")%></td>
                                <td style="text-align: center;"><%#Eval("出价")%></td>
                                <td style="text-align: center;"><%#Eval("数量")%></td>
                               <td style="text-align: center;"> <%#Eval("库存数")%></td>
                                </tr>
                            </ItemTemplate>
                </asp:Repeater>
        </table>
    </form>
</body>
</html>
