<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="objedit.aspx.cs" validateRequest="false" Inherits="tdx.memb.man.formcontrols.objedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js" charset="utf-8"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>表单项目管理</strong></h1>
    <div id="nei_content" class="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <asp:HiddenField ID="wid" runat="server" />
        <asp:HiddenField ID="isE" runat="server" />
        <table class="enter_table">
            <tbody>
                <tr>
                    <td class="enter_title">
                        表单项目名称
                    </td>
                    <td class="enter_content">
                        <input name="title" id="name" runat="Server" placeholder="请输入表单项目名称" class="px" type="text" />
                    </td>
                       <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        表单项目描述
                    </td>
                    <td class="enter_content">
                        <textarea name="t_sort" id="miaoshu" runat="Server" placeholder="请输入项目描述" rows="8"
                            cols="40" class="px2"></textarea>
                    </td>
                       <td class="rb">
                        *
                    </td>
                </tr>
                 <tr>
                    <td class="enter_title">
                        表单外链接地址
                    </td>
                    <td class="enter_content">
                        <textarea name="t_urls" id="t_urls" runat="Server" placeholder="请输入外链地址" rows="8"
                            cols="40" class="px2"></textarea>
                    </td>
                       <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                    </td>
                    <td class="enter_content">
                        <input name="btn_save" runat="server" id="btn_save" value=" 保 存 " class="btnSave"
                            onserverclick="save" type="button" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
