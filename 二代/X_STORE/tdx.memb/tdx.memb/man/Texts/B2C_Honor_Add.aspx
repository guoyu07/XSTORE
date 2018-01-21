<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Honor_Add.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_Honor_Add" %>

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
    <h1>
        <strong>图片上传</strong></h1>
    <div class="nei_content" id="nei_content">
    <asp:Literal ID="daohang_Image" runat="server"></asp:Literal>
    <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>

        <!--center content-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal>
            </span>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>
        <input type="hidden" name="wtab" id="wtab" value="" runat="server" />
        <input type="hidden" name="wrow" id="wrow" value="" runat="server" />
        <input type="hidden" name="t_title" value="" runat="server" id="t_title" />
        <input type="hidden" name="t_wdate" value="" runat="server" id="t_wdate" />
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    相册类别
                </td>
                <td class="enter_content">
                    <select id="cid" name="cid" runat="server" class="select-field">
                        <option></option>
                    </select>
                   <asp:Literal ID="addWant" runat="server"></asp:Literal>
                    <br />
                      <span class="gray">请选择相册类别</span><br />
                        <br />
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    图片名称
                </td>
                <td class="enter_content">
                    <input type="text" name="t_author" placeholder="请输入图片名称" runat="server" id="t_author"
                        class="px" maxlength="200" /><br />
                         <span class="gray">请输入图片名称，最长不超过200个字符！</span><br />
                        <br />
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    图片上传
                </td>
                <td class="enter_content">
                    <input type="file" name="t_source_file" runat="server" id="t_source_file" class="px"
                        maxlength="255" /><br />
                        <span class="gray">最大宽高:360*200 像素:72 格式:jpg png gif</span><br />
                        <br />
                        <asp:Image ID="Image1" runat="server" Width="180" Height="100" />
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    简介
                </td>
                <td class="enter_content" colspan="2">
                    <textarea name="t_wdes" cols="40" placeholder="简介描述，不要超过150字"  rows="6" runat="server" id="t_wdes" class="px2"></textarea>
                    <br />
                     <span class="gray">简介描述，不要超过150字</span><br />
                        <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    排序
                </td>
                <td class="enter_content">
                    <input type="text" name="t_w_sort" placeholder="排序规则，必须为数字，默认为99" runat="server"
                        id="t_w_sort" class="px" maxlength="255" /><br />
                          <span class="gray">排序规则，必须为数字，默认为99</span><br />
                        <br />
                </td>
                <td width="30%">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input type="button" value=" 保 存 " class="btnGreen" runat="server" id="Button1" onserverclick="Button1_ServerClick" />
                </td>
            </tr>
            <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
        </table>
        <!--center content end-->
    </form>
    <!--中间结束-->
</body>
</html>
