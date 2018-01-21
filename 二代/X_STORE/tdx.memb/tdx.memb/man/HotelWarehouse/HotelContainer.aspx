<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelContainer.aspx.cs" Inherits="tdx.memb.man.HotelWarehouse.HotelContainer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
     <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <telerik:RadAjaxPanel runat="server">
            <div>
                <telerik:RadTreeView ID="rtv_status" runat="server" RenderMode="Lightweight"></telerik:RadTreeView>
            </div>
        </telerik:RadAjaxPanel>
        <div class="page-footer">
            <div class="btn-list">
                <%--<asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />--%>
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
    </form>
</body>
</html>
