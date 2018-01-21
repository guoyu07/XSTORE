<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InStockEdit.aspx.cs" Inherits="tdx.memb.box.InStockEdit" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/man/Box/Nrows.ascx" TagPrefix="rows" TagName="newrows" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>
<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改入库</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <script src="../../../Shop/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
    <%--    <script>
    
    if (!isNaN($("#spnum").val())) {
        // alert("是数字");
        var r = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
        //正浮点数
        if(r.test($("#spnum").val()))
        {
            alert("不是能是负数");
        }
    } else {
        alert("不是数字");
    }

</script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>入出库管理</span>
            <i class="arrow"></i>
            <span>入库信息</span>
            <i class="arrow"></i>
            <span>入库管理</span>
        </div>
        <!---->
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;
                            <span style="font-size: 16px;">入库号：</span>&nbsp;
                            <asp:Label ID="Instocknum" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <span style="font-size: 16px;">当前时间：</span>
                            <asp:Label ID="instockdatetime" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <span style="font-size: 16px;">入库人：</span>&nbsp;
                            <asp:DropDownList ID="instockuser_ddl" runat="server"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <span style="font-size: 16px;">供应商</span>&nbsp;
                            <asp:DropDownList ID="gongyinshang_ddl" runat="server"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <span style="font-size: 16px;">入库类型</span>&nbsp;
                            <asp:DropDownList ID="rklx_ddl" runat="server"></asp:DropDownList>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 16px;">选择省</span>
                            <asp:DropDownList CssClass="input" ID="ddl_shen" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_shen_SelectedIndexChanged"></asp:DropDownList>
                        </li>
                        <li>&nbsp;&nbsp;<span style="font-size: 16px;">选择酒店名称</span>
                            <asp:DropDownList CssClass="input" ID="ddl_hotel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_hotel_SelectedIndexChanged"></asp:DropDownList>
                        </li>
                        <li>&nbsp;&nbsp;<span style="font-size: 16px;">选择仓库号</span>
                            <asp:DropDownList CssClass="input" ID="ddl_warehouse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_warehouse_SelectedIndexChanged"></asp:DropDownList>
                        </li>
                        <li>&nbsp;&nbsp;<span style="font-size: 16px;">选择库位</span>
                            <asp:DropDownList CssClass="input" ID="ddl_kw" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_kw_SelectedIndexChanged"></asp:DropDownList>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <telerik:RadAjaxPanel runat="server">
            <asp:Label runat="server" ID="eidtlbl" Style="display: none"></asp:Label>
            <telerik:RadListView runat="server" ID="product_rep" ItemPlaceholderID="holder" OnNeedDataSource="product_rep_NeedDataSource" OnItemDataBound="product_rep_ItemDataBound">
                <LayoutTemplate>
                    <table id="tabId" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr style="text-align: center;">
                            <td width=" 80px; text-align: center; display: none">商品id</td>
                            <td width="10%">商品</td>
                            <td width=" 80px">库存数量</td>
                            <td width=" 80px">入库数量</td>
                            <td width=" 80px">单价</td>
                            <td width=" 80px">入库总额</td>
                            <td width=" 80px">备注</td>
                            <td width=" 80px">操作</td>
                        </tr>
                        <asp:PlaceHolder ID="holder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <rows:newrows runat="server" ID="rows" itemindex="<%#Container.DataItemIndex %>" />
                </ItemTemplate>
            </telerik:RadListView>
        </telerik:RadAjaxPanel>
        <asp:HiddenField ID="AddorEdit" Value="1" runat="server" />
        <input type="hidden" runat="server" id="counter" />
        <input type="hidden" runat="server" id="json_memory" />
        <div class="page-footer">
            <div class="btn-list">
                <%--<input type="button" class="btn btn-success" id="plus" runat="server" value="+增加项" title="增加项" width=" 100%;" onserverclick="plus_ServerClick" />--%>
                <input type="button" class="btn" id="Button1" runat="server" value="增加项" title="增加项" onserverclick="plus_ServerClick" />
                <asp:Button ID="Btnrk" runat="server" Text="提交保存" CssClass="btn" OnClick="Btnrk_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>

    </form>
</body>
</html>
