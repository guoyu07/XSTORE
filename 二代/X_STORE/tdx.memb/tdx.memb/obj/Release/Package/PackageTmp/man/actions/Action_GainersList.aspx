<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Action_GainersList.aspx.cs" Inherits="tdx.memb.man.actions.Action_GainersList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>获奖者列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>获奖列表</strong></h1>
    <div class="nei_content">
        <!--center content-->
         <div class="tdh">
        <asp:Literal ID="lb_prolist" runat="server"></asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
