﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="objControlResultList.aspx.cs" Inherits="tdx.memb.man.formcontrols.objControlResultList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>表单项目结果查看</strong></h1>
    <div id="nei_content" class="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2"></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <div class="tdh">
            <asp:Literal ID="bdList" runat="server" EnableViewState="false">

            </asp:Literal>
        </div>
    </div>
    <!--内容-->
    <!--内容结束-->
    </form>
</body>
</html>

