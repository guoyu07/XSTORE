<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check_C2C_Log.aspx.cs" Inherits="tdx.memb.man.vipmemb.Check_C2C_Log" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看日志</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>    
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>日志列表:<asp:Literal ID="lt_biaoti" runat="server"></asp:Literal></strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="tdh">
            <asp:Literal ID="ylList1" runat="server" EnableViewState="false">
            </asp:Literal>
        </div>
    </div>
    <!--内容-->
    <!--内容结束-->
    </form>
</body>
</html>
