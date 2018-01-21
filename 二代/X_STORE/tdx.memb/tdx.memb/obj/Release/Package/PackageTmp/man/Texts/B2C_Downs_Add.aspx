<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Downs_Add.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_Downs_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/master/images/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <!--中间开始-->
    <asp:Literal ID="daohang_Image" runat="server"></asp:Literal>

    <form id="form1" runat="server">
    <h1>
        <strong>下载处理</strong></h1>
    <div class="nei_content" id="nei_content">
        <!--center content-->
        <div class="errMsgBox">
            <div class="notice rb">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></div>
        </div>
        <input type="hidden" name="wtab" id="wtab" value="" runat="server" />
        <input type="hidden" name="wrow" id="wrow" value="" runat="server" />
        <input type="hidden" name="t_title" value="" runat="server" id="t_title" />
        <input type="hidden" name="t_wdate" value="" runat="server" id="t_wdate" />
        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="2">
            <tr>
                <td width="20%" align="center" height="40">
                    类&nbsp;别
                </td>
                <td>
                    <select id="cid" name="cid" runat="server" class="select-field"> 
                    </select>
                </td>
                <td width="30%">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    名&nbsp;称
                </td>
                <td>
                    <input type="text" name="t_author" value="" runat="server" id="t_author" class="px"
                        maxlength="255" placeHolder="下载名称"/>
                </td>
                <td width="30%">
                </td>
            </tr>
             <tr>
                <td width="20%" align="center" height="40">
                    图&nbsp;片
                </td>
                <td>
                    <input type="file" name="t_source_gif" runat="server" id="t_source_gif" class="px"
                        maxlength="255" />&nbsp;<span>120*120</span>
                </td>
                <td width="30%">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    附件地址
                </td>
                <td>
                    <input type="text" name="t_source_file2" runat="server" id="t_source_file2" class="px" maxlength="255" />
                    <br />
                    <span class="gray">输入附件地址或从下面上传</span>
                </td>
                <td width="30%">
                </td> 
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    附&nbsp;件
                </td>
                <td>
                    <input type="file" name="t_source_file" runat="server" id="t_source_file" class="px"
                        maxlength="255" />&nbsp;
                </td>
                <td width="30%">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    简&nbsp;介
                </td>
                <td colspan="2">
                    <textarea name="t_wdes" cols="40" rows="6" runat="server" id="t_wdes" class="px2"></textarea>
                    <br />
                    简介信息
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    排&nbsp;序
                </td>
                <td>
                    <input type="text" name="t_w_sort" value="" runat="server" id="t_w_sort" class="px"
                        maxlength="255" placeHolder="排序规则，必须为数字，越小越靠前.默认为99"/>&nbsp;
                </td>
                <td width="30%">
                </td>
            </tr>
            <tr>
                <td height="30" colspan="3" align="center">
                    <input type="button" value=" 保 存 " class="btnGreen" runat="server" id="Button1" onserverclick="Button1_ServerClick" />
                </td>
            </tr>
            <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
        </table>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
