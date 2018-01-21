<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nrows.ascx.cs" Inherits="tdx.memb.box.Nrows" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    function del(obj) {
        $(obj).parent().parent().remove();
    }
</script>
<tr id="test" style="align-content:center;">         
                <td style="display:none;" align="center" valign="middle">
 <%--                  <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />--%>
                  <%--  <asp:HiddenField ID="hidId"  runat="server" />--%>
                    <asp:Label Style="text-align: center;" runat="server" ID="lblsp_id"></asp:Label>
                </td>
                <td align="center" valign="middle">
                 <telerik:RadComboBox Width="95%" ID="rcb_sp" runat="server" MaxHeight="203" LocalizationPath="~/Language" 
                     DataTextField="品名" DataValueField="商品id" Filter="Contains" MarkFirstMatch="true" AppendDataBoundItems="true" 
                     ShowToggleImage="false" AllowCustomText="true" AutoPostBack="true" 
                     OnSelectedIndexChanged="rcb_sp_SelectedIndexChanged" >
                                <ItemTemplate>
                                    <%# Eval("品名") %><span style="display: none;"><%# Eval("品名") %></span>
                                </ItemTemplate>
                </telerik:RadComboBox>
                </td>
                <td align="center" valign="middle">
                    <asp:Label ID="lblkc_num" runat="server" Text="请选择商品"></asp:Label>
                </td>
                    <%--入库数量--%>
                <td align="center" valign="middle">
                    <asp:textbox id="spnum" runat="server" OnTextChanged="spnum_TextChanged" 
                        AutoPostBack="True"  style="border:none; border-bottom:solid #808080 1px;text-align:right;">
                    </asp:textbox>
                </td>
                    <%--单价--%>
                <td align="center" valign="middle">
              <%--      <asp:Label ID="Label1" runat="server"></asp:Label>--%>
                    <asp:TextBox ID="sp_price" runat="server" OnTextChanged="spnum_TextChanged" AutoPostBack="true" 
                        style="border:none; border-bottom:solid #808080 1px;text-align:right;"></asp:TextBox>
                </td>
                    <%--入库总额--%>
                <td align="center" valign="middle">
                    <%--<asp:Label ID="lb_rental" runat="server"></asp:Label>--%>
                    <asp:TextBox ID="totalprice" runat="server"></asp:TextBox>
                </td>
                <%--备注--%>
                <td align="center" valign="middle">
                    <input type="text" runat="server" id="txtremark" />
                    
                </td>
                <td class="center" width="10%;vertical-align: middle;" align="center" >
                    <telerik:RadTextBox Width="40%" ID="editrow_textbox" runat="server"  style="display:none"></telerik:RadTextBox>
            <telerik:RadTextBox Width="40%" ID="count_textbox" runat="server" style="display:none" ></telerik:RadTextBox>
                    <%--<asp:Button runat="server" OnClick="del_Click(this)"  ID="del" Text="删除" />--%>
                   <a href="javascript:;" onclick="del(this)">删除</a>
        </td>
    </tr>    