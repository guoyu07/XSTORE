<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_PassWord.aspx.cs" Inherits="tdx.memb.man.vipmemb.Edit_PassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>密码修改</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>密码修改:<asp:Literal ID="lt_biaoti" runat="server"></asp:Literal></strong></h1>
    <div class="nei_content" id="nei_content">
    <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>

        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    新密码
                </td>
                <td class="enter_content">
                    <input name="M_psw" runat="server" id="M_psw" class="px" maxlength="50" type="password" />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    确认新密码
                </td>
                <td class="enter_content">
                    <input name="confirm_M_psw" runat="server" id="confirm_M_psw" class="px" maxlength="50"
                        type="password" />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input name="btn_save" runat="server" onserverclick="btn_psw_ServerClick" id="btn_save"
                        value=" 保 存 " class="btnGreen" type="button" />
                </td>
            </tr>
        </table>
    </div>
    <!--内容-->
    <!--内容结束-->
    </form>
</body>
</html>
