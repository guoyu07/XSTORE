<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelGoodsInventory.aspx.cs" Inherits="tdx.memb.man.HotelWarehouse.HotelGoodsInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
             <table  style="width:100%" border="1" class="ltable">
                <tr>
                    <th  style="width:50%">品名</th>
                    <th  style="width:50%">库存数</th>
                </tr>
                <asp:Repeater ID="Rp_hotelGoodsInventory" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <%#Eval("品名") %>
                                <asp:HiddenField ID="hidId" Value='<%#Eval("商品id")%>' runat="server" />
                            </td>
                            <td style="text-align: center;"><%#Eval("库存数")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
    </form>
</body>
</html>
