<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_menu2_Add.aspx.cs" Inherits="tdx.memb.man.Sets.B2C_menu2_Add" %>

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
        <strong>添加公众号菜单：</strong><asp:Literal ID="lt_mp" runat="server" EnableViewState="false"></asp:Literal></h1>
    <div class="nei_content">
    <asp:Literal ID="daohang_Image" runat="server"></asp:Literal>
        <!--center content-->
        <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <a class="tsxx_2" href="####">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></a>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>
        <input type="hidden" name="class_level" value="1" id="class_level" runat="server" />
        <input type="hidden" name="class_parent" value="0" id="class_parent" runat="server" />
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    上级菜单
                </td>
                <td class="enter_content">
                    <asp:Literal ID="parentname" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    菜单名称
                </td>
                <td class="enter_content">
                    <input type="text" name="txtmc" placeholder="菜单名称" class="px" runat="server" id="txtmc"
                        imgurl="../images4/zidingyi_caidan.jpg" maxlength="200" />
                    <asp:RequiredFieldValidator ID="Reqmc" runat="server" ControlToValidate="txtmc" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    图标
                </td>
                <td class="enter_content">
                    <input id="txtgif" type="file" class="px" runat="server" maxlength="300" imgurl="" /><br />
                    <span class="gray">图片最佳尺寸720*400。图片在点击菜单后返回，如右图<</span><br />
                    <asp:Image ID="Image1" runat="server" Width="180" Height="100" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    跳转链接
                </td>
                <td class="enter_content">
                    <asp:Literal ID="lt_funcSelectBox" runat="server" ></asp:Literal> 
                    <br />
                    <textarea id="txturl" cols="30" rows="2" name="txturl" runat="server" class="px2"></textarea><br />
                    <span class="gray">可以通过下拉框选择或输入您要的链接</span><br />
                    <br />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    排序
                </td>
                <td class="enter_content">
                    <input type="text" name="txtpx" placeholder="99" class="px" runat="server" id="txtpx"
                        value="1" />
                    <asp:RegularExpressionValidator ID="Regpx" runat="server" ControlToValidate="txtpx"
                        ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    描述
                </td>
                <td class="enter_content">
                    <textarea id="txtms" placeholder="描述信息" cols="30" rows="2" name="txtms" runat="server"
                        imgurl="../images4/sjys.jpg" class="px2"></textarea>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input type="button" value=" 保 存 " class="btnSave" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" />
                </td>
            </tr>
            <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
        </table>
        <div class="enter_remind" id="div_right">
        </div>
        <!--center content end-->
    </div>
    <div class="enter_remind  phone_remind">
        <img src="../images4/oneMenu_phone.jpg" />
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
