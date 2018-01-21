<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Adclass_Add.aspx.cs" Inherits="tdx.memb.man.Ads.B2C_Adclass_Add" %>

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
    <form id="form1" runat="server">
    <h1>
        <strong>广告类别处理</strong></h1>
    <div class="nei_content" id="nei_content">
        <!--center content-->
        <div class="errMsgBox">
            <div class="notice rb">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></div>
        </div>
        <input type="hidden" name="class_parent" value="0" id="class_parent" runat="server" />
        <input type="hidden" name="class_level" value="0" id="class_level" runat="server" />
        <input type="hidden" name="txturl" id="txturl" value="" runat="server" />
        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="2">
            <tr>
                <td width="20%" align="center" height="40">
                    名称
                </td>
                <td width="60%">
                    <input type="text" name="txtmc" value="" class="px" runat="server" id="txtmc" maxlength="200" placeHolder="类别名称" /><asp:RequiredFieldValidator
                        ID="Reqmc" runat="server" ControlToValidate="txtmc" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    代表广告
                </td>
                <td width="60%">
                    <input id="txtgif" type="file" class="px" runat="server" maxlength="300" onchange="Preview()" /><br />
                    <asp:Image ID="Image1" runat="server" Width="100" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    排序
                </td>
                <td width="60%">
                    <input type="text" value="99" name="txtpx" class="px" runat="server" id="txtpx"  placeHolder="排序规则,必须为数字，越小越靠前.默认为99"/><asp:RegularExpressionValidator
                        ID="Regpx" runat="server" ControlToValidate="txtpx" ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
                <td>
                </td>
            </tr> 
            <tr>
                <td width="20%" align="center" height="40">
                    宽 度
                </td>
                <td width="60%">
                    <input type="text" value="99" name="txtWidth" class="px" runat="server" id="txtWidth"  placeHolder="广告位置的宽度，必须为数字."/><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtWidth" ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    高 度
                </td>
                <td width="60%">
                    <input type="text" value="99" name="txtHeight" class="px" runat="server" id="txtHeight"  placeHolder="广告位置的高度，必须为数字."/><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtHeight" ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    价 格
                </td>
                <td width="60%">
                    <input type="text" value="99" name="txtAmt" class="px" runat="server" id="txtAmt"  placeHolder="广告位置的价格，必须为数字."/><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmt" ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40">
                    描述
                </td>
                <td colspan="2">
                    <textarea id="txtms" cols="20" rows="2" name="txtms" runat="server" class="px2" onchange="if(this.value.length> 150){alert( '最多150字！ ');return   false;}"></textarea>
                    <br />
                    描述信息，最多150字
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="height: 30px">
                    <input type="button" value=" 保 存 " class="btnGreen" runat="server" id="btnSave" onserverclick="btnSave_ServerClick"
                        width=" 70px" />
                </td>
            </tr>
        </table>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
