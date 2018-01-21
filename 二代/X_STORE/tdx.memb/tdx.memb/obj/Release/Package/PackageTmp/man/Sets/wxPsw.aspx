<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxPsw.aspx.cs" Inherits="tdx.memb.man.Sets.wxPsw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <!--中间开始-->
    <form id="form1" runat="server">
    <div class="wxmpadd_head">
        <h1>
            <strong>修改密码</strong></h1>
    </div>
    <div class="nei_content" id="nei_content">
        <!--center content-->
        <div class="errMsgBox">
            <div class="notice rb">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="wxmpadd_enter">
        <table>
            <tr>
                <td class="enter_title">
                    用户名
                </td>
                <td  class="enter_content">
                    <asp:Literal ID="lt_wname" runat="server"></asp:Literal>
                </td>
                <td>
                    <span class="rb">*</span>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    密 码
                </td>
                <td class="enter_content">
                    <input type="password" name="txtpsw" class="px" runat="server" id="txtpsw" maxlength="50" />
                </td>
                <td>
                    <span class="rb">*</span>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    重复密码
                </td>
                <td class="enter_content">
                    <input type="password" name="txtpsw2" value="" class="px" runat="server" id="txtpsw2" />
                </td>
                <td>
                    <span class="rb">*</span>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="3" align="center">
                    <input type="button" value="  保 存  " class="btnGreen" runat="server" id="Button1"
                        onserverclick="Button1_ServerClick" />
                </td>
            </tr>
        </table>
        </div>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
