﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFen_Change.aspx.cs" Inherits="tdx.memb.man.vipmemb.JiFen_Change" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>积分调节</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>    
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>积分操作:<asp:Literal ID="lt_biaoti" runat="server"></asp:Literal></strong></h1>
    <div class="nei_content" id="nei_content">

    <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <table class="enter_table">           
                <tr>
                    <td class="enter_title">
                        积分数
                    </td>
                    <td class="enter_content">
                        <input name="JiFen_Count" runat="server" placeholder="请输入大于0的整数" id="JiFen_Count" class="px"
                            maxlength="50" type="text" />
                    </td>
                    <td class="rb">
                    *
                    </td>
                </tr>
                <tr>
                <td class="enter_title"></td>
                    <td class="enter_content">
                        <input
                            name="btn_Add" runat="server" onserverclick="btn_Add_ServerClick" id="btn_Add"
                            value=" 增加 " class="btnGreen" type="button">
                        <input name="btn_Reduce" runat="server" onserverclick="btn_Reduce_ServerClick" id="btn_Reduce"
                            value=" 减少 " class="btnGreen" type="button" />
                    </td>
                    <td >
                        &nbsp;
                    </td>
                </tr>           
        </table>
    </div>
    <!--内容-->
    <!--内容结束-->
    </form>
</body>
</html>

