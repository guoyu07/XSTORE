<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Group_franEdit.aspx.cs" Inherits="tdx.memb.man.vipmemb.Group_franEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <style type="text/css">
        .rb
        {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>会员卡分组</strong></h1>
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
                    分组名称
                </td>
                <td class="enter_content">
                    <input name="name" id="name" placeholder="分组名称" runat="server" class="px" maxlength="50"
                        type="text" /><br />
                        <span class="gray">建议15个字以内</span>                     
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                        value=" 保 存 " class="btnSave" type="button" />
                </td>
            </tr>
        </table>
        <div class="enter_remind">
        </div>
    </div>
    </form>
</body>
</html>
