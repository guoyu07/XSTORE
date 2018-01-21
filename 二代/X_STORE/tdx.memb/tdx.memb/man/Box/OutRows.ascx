<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutRows.ascx.cs" Inherits="tdx.memb.box.OutRows" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    function del(obj) {
        $(obj).parent().parent().remove();
    }
</script>
<tr id="test">
    <td style="display: none;">
        <asp:Label Style="text-align: center;" runat="server" ID="lblsp_id"></asp:Label>
    </td>
    <%--商品--%>
    <td >
        <telerik:RadComboBox Width="95%" ID="rcb_sp" runat="server" MaxHeight="203" LocalizationPath="~/Language" 
            DataTextField="品名" DataValueField="商品id" Filter="Contains" MarkFirstMatch="true" 
            AppendDataBoundItems="true" ShowToggleImage="false" AllowCustomText="true" AutoPostBack="true" 
            OnSelectedIndexChanged="rcb_sp_SelectedIndexChanged">
            <ItemTemplate>
                <%# Eval("品名") %><span style="display: none;"><%# Eval("品名") %></span>
            </ItemTemplate>
        </telerik:RadComboBox>
    </td>
    <%--库存--%>
    <td align="center" valign="middle">
        <asp:Label ID="lblkc_num" runat="server" Text="请选择商品"></asp:Label>
    </td>
    <%--数量--%>
    <td align="center" valign="middle">
        <asp:TextBox ID="spnum" OnTextChanged="spnum_TextChanged" AutoPostBack="true" runat="server" Style="border: none; border-bottom: solid #808080 1px; text-align: right;"></asp:TextBox>
    </td>
    <%--单价--%>
    <td align="center" valign="middle">
        <asp:Label ID="txt_UnitPrice" runat="server"></asp:Label>
        <%--<asp:TextBox ID="sp_price" Text="" OnTextChanged="spnum_TextChanged" AutoPostBack="true" runat="server" Style="border: none; border-bottom: solid #808080 1px; text-align: right;"></asp:TextBox><span>&nbsp;元</span>--%>
    </td>
    <%--总额--%>
    <td align="center" valign="middle">
        <asp:Label ID="lb_rental" runat="server"></asp:Label>
       <%-- <asp:TextBox ID="totalprice" Text="" OnTextChanged="spnum_TextChanged"
             AutoPostBack="true" runat="server" Style="border: none; border-bottom: solid #808080 1px; text-align: right;"></asp:TextBox>--%>
        <span>&nbsp;元</span>
    </td>
    <%--备注--%>
    <td align="center" valign="middle">
        <input type="text" runat="server" id="txtremark" />
    </td>
    <td class="center" width=" 10%;vertical-align: middle;" align="center">
        <telerik:RadTextBox Width="40%" ID="editrow_textbox" runat="server" Style="display: none"></telerik:RadTextBox>
        <telerik:RadTextBox Width="40%" ID="count_textbox" runat="server" Style="display: none"></telerik:RadTextBox>
        <%--<asp:Button runat="server" OnClick="del_Click" ID="del" Text="删除" />--%>
        <a href="javascript:;" onclick="del(this)">删除</a>
        <%-- <asp:CheckBox runat="server" ID="split_cb"/>--%>
    </td>
</tr>
