<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelGoodsEdit.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GrogshopManage.HotelGoodsEdit" ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/select2.js"></script>
    <link href="../../css/select2.css" rel="stylesheet" />
    <script type="text/javascript">
        function dj() {
            $("input [type=check]").each(function () {
                if ($(this).attr("checked") == "true") {
                    alert($(this).parent().find("input").val());
                }
            })
        }
        window.onload = function () {
            var numbers = $("#hidd_number").val();
            var number = numbers.split(',');
            for (var i = 0; i < number.length - 1; i++) {

            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <telerik:RadAjaxPanel runat="server">
            <asp:HiddenField ID="hidd_number" runat="server" />
            <div style="width: 100%;">
                <asp:Label runat="server" Style="text-align: center; color: red; font-size: 18px; width: 100%">
                    *仅勾选的商品能被保存，此处选中的商品才能入库至酒店*</asp:Label>
            </div>
            <table style="width:100%" border="1" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th style="width:15%">选择</th>
                    <th style="width:20%">品名</th>
                    <th style="width:20%">规格</th>
                    <th style="width:15%">单位</th>
                    <th style="width:10%">折扣</th>
                    <th style="width:10%">最小库存</th>
                    <th style="width:10%">最大库存</th>
                </tr>
                <asp:Repeater ID="rp_hotel_goods" runat="server" OnItemDataBound="rp_hotel_goods_ItemDataBound">
                    <ItemTemplate>
                        <tr runat="server">
                            <td style="text-align: center;" runat="server">
                                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" name="check_goods" />
                                <%--<input type="checkbox" class="checkall" runat="server" name ="check_goods"/>--%>
                                <asp:HiddenField ID="hidId" Value='<%#Eval("goods_id")%>' runat="server" />
                            </td>
                            <td style="text-align: center;"><%#Eval("品名")%></td>
                            <td style="text-align: center;"><%#Eval("规格")%></td>
                            <td style="text-align: center;"><%#Eval("单位")%></td>
                            <td style="text-align: center;" runat="server">
                                <asp:TextBox runat="server" AutoPostBack="true" ID="zhekou">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: center;" runat="server">
                                <asp:TextBox runat="server" AutoPostBack="true" ID="min_repertory">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: center;" runat="server">
                                <asp:TextBox runat="server" AutoPostBack="true" ID="max_repertory">
                                </asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </telerik:RadAjaxPanel>
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="dj();" />

                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>

    </form>
</body>
</html>
