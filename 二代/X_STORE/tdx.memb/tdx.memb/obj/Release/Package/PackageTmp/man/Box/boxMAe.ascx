<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="boxMAe.ascx.cs" Inherits="tdx.memb.man.Box.boxMAe" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    function del(obj) {
        var msg = "您真的确定要删除吗？\n\n请确认！";
        if (confirm(msg) == true) {
            $(obj).parent().parent().remove();
        } else {
            return false;
        }
    }
    </script>
<input type="hidden" runat="server" id="items" />

 <%--
<tr id="test">
   <td style="text-align: center;;valign:middle">
          <asp:Label Style="text-align: center;" runat="server" ID="wz"><%=getnumber() %></asp:Label>
    </td>--%>
    
    <td style="text-align: center;vertical-align:middle;">
        <asp:Label Style="text-align: center;" runat="server" ID="hotel_name"></asp:Label>
    </td >
    <td style="text-align: center;vertical-align:middle;">
        <asp:Label Style="text-align: center;" runat="server" ID="ck"></asp:Label>
    </td >
    <td style="text-align: center;vertical-align:middle;">
        <asp:Label Style="text-align: center;" runat="server" ID="kw"></asp:Label>
    </td >
    <td style="text-align: center;vertical-align:middle;">
        <asp:Label Style="text-align: center;" runat="server" ID="mac"></asp:Label>
    </td >
    <td >
        <telerik:RadComboBox Width="95%" ID="rcb_mr" runat="server" MaxHeight="203" LocalizationPath="~/Language" DataTextField="品名" DataValueField="id" Filter="Contains" MarkFirstMatch="true" AppendDataBoundItems="true" ShowToggleImage="false" AllowCustomText="true" AutoPostBack="true">
            <ItemTemplate>
                <span style=" "><%# Eval("品名") %></span>
            </ItemTemplate>
        </telerik:RadComboBox>
    </td>
    <td >
        <telerik:RadComboBox Width="95%" ID="rcb_sj" runat="server" MaxHeight="203" LocalizationPath="~/Language" DataTextField="品名" DataValueField="id" Filter="Contains" MarkFirstMatch="true" AppendDataBoundItems="true" ShowToggleImage="false" AllowCustomText="true" AutoPostBack="true">
            <ItemTemplate>
                <span style=" "><%# Eval("品名") %></span>
            </ItemTemplate>
        </telerik:RadComboBox>
    </td>
    <asp:HiddenField runat="server" ID="number"></asp:HiddenField>
    <td class="center" width=" 10%;vertical-align: middle;text-align:center;">
        <telerik:RadTextBox Width="40%" ID="editrow_textbox" runat="server" Style="display: none"></telerik:RadTextBox>
        <telerik:RadTextBox Width="40%" ID="count_textbox" runat="server" Style="display: none"></telerik:RadTextBox>
        <%--<asp:Button runat="server" OnClick="del_Click" ID="del" Text="删除" />--%>
        <a href="javascript:;" onclick="del(this)" OnClientClick="return ExePostBack('btnDelete','确认删除？');">删除</a>
    </td>
<%--</tr>--%>