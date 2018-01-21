<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_tclass_Add.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_tclass_Add" %>

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
    <asp:Literal ID="ltHead" runat="server"></asp:Literal>
    <!--中间开始-->
    <form id="form1" runat="server">
    <h1>
        <strong>图文类别编辑</strong></h1>
        
    <div class="nei_content" id="nei_content">

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
                  <asp:Literal ID="lt_result" runat="server"></asp:Literal> </span>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>
             
        <input type="hidden" name="class_parent" value="0" id="class_parent" runat="server" />
        <input type="hidden" name="class_level" value="0" id="class_level" runat="server" />
        <input type="hidden" name="txturl" id="txturl" value="" runat="server" />
     
            <table class="enter_table">
            <tr>
                <td class="enter_title">
                    类别名称
                </td>
                <td class="enter_content">
                    <input type="text" name="txtmc" placeholder="请输入类别名称" class="px" runat="server" id="txtmc"
                        maxlength="200" /><br />
                        <span class="gray">请输入类别名称，最长200文字</span><br />
                   <%-- <asp:RequiredFieldValidator ID="Reqmc" runat="server" ControlToValidate="txtmc" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    代表图片
                </td>
                <td class="enter_content">
                    <input id="txtgif" type="file" class="px" runat="server" maxlength="300" /><br />
                    <span class="gray">最大宽高:200*200 像素:72 格式:jpg png gif</span><br />
                    <asp:Image ID="Image1" runat="server" Width="100" Height="100" />
                </td>               
            </tr>
            <tr>
                <td class="enter_title">
                    排序
                </td>
                <td class="enter_content">
                    <input type="text" name="txtpx" placeholder="排序规则，必须为数字，默认为99" class="px" runat="server"
                        id="txtpx" /><br />
                     <span class="gray">排序规则，必须为数字，默认为99。越小越靠前</span><br />
                    <asp:RegularExpressionValidator ID="Regpx" runat="server" ControlToValidate="txtpx"
                        ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="enter_title">
                    描述
                </td>
                <td class="enter_content" >
                    <textarea id="txtms" placeholder="描述信息，最多为150字" cols="30" rows="2" name="txtms" runat="server"
                        class="px2" ></textarea><br />
                        <span class="gray">描述信息，最多为150字</span><br />
                </td>
                <td></td>
            </tr>
            <tr>
            <td class="enter_title">
               
                </td>
                <td class="enter_content" >
                    <input type="button" value=" 保 存 " class="btnGreen" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" />
                </td>
            </tr>
            <asp:Literal ID="ltFoot" runat="server"></asp:Literal>
        </table>
 
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>

