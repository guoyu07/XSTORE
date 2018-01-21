<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_OrderD_Mod.aspx.cs" Inherits="tdx.memb.man.Goods.B2C_OrderD_Mod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link href="../images4/nei.css" type="text/css" rel="stylesheet">
    <title>后台管理</title>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CountAmt() {
            var price = document.getElementById("txtPrice"); //价格
            var qnt = document.getElementById("txtQnt"); //数量
            var amt = document.getElementById("txtAmt"); //金额

            amt.value = parseFloat(price.value) * parseFloat(qnt.value);
        }
        function CountCent() {
            var price = document.getElementById("txtCent"); //价格
            var qnt = document.getElementById("txtQnt"); //数量 
            var amt = document.getElementById("txtAllCent"); //金额

            amt.value = parseFloat(price.value) * parseFloat(qnt.value);
        }
        function CountAmtAndCent() {
            CountAmt();
            CountCent();
        }
    </script>
</head>
<body onload="CountAmt()">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <h1>
        <strong>订单处理</strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="errMsgBox">
            <div class="notice rb">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></div>
        </div>
        <input type="hidden" name="class_parent" value="0" id="class_parent" runat="server" />
        <input type="hidden" name="class_level" value="0" id="class_level" runat="server" />
        <input type="hidden" name="class_shopid" value="0" id="class_shopid" runat="server" />
        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="30" colspan="3" align="center">
                    处理订单信息应用&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    商品
                </td>
                <td style="width: 70%; height: 24px;">
                    <asp:Label ID="lblGoodsName" runat="server" Text=""></asp:Label>
                </td>
                <td width="10%" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    数量
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtQnt" placeholder="商品数量,必须为大于0的数字" class="px" runat="server"
                        id="txtQnt" onkeyup="CountAmtAndCent()" />
                    <asp:RegularExpressionValidator ID="valeQnt" runat="server" Display="Dynamic" ErrorMessage="*请输入数值,如:1、2、2.5..."
                        ControlToValidate="txtQnt" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    价格
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtPrice" placeholder="商品单价,必须为大于0的数字" class="px" runat="server"
                        id="txtPrice" onkeyup="CountAmt()" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="*请输入数值,如:1、2、2.5..." ControlToValidate="txtPrice" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    金额
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtAmt" placeholder="商品金额,必须为大于0的数字" class="px" runat="server"
                        id="txtAmt" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                        ErrorMessage="*请输入数值,如:1、2、2.5..." ControlToValidate="txtAmt" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    积分
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtCent" placeholder="赠送积分数,必须为大于0的数字" class="px" runat="server"
                        id="txtCent" onkeyup="CountCent()" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                        ErrorMessage="*请输入数值,如:1、2、2.5..." ControlToValidate="txtCent" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    总积分
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtAllAmt" placeholder="总赠送积分数,必须为大于0的数字" class="px" runat="server"
                        id="txtAllAmt" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                        ErrorMessage="*请输入数值,如:1、2、2.5..." ControlToValidate="txtAllAmt" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    备注
                </td>
                <td style="width: 70%; height: 24px;">
                    <textarea id="txtRemarks" placeholder="订单信息备注" runat="server" cols="20" rows="5" class="px2"></textarea>                 
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="height: 40px">
                    <input type="button" value="保 存" class="btnGreen" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
