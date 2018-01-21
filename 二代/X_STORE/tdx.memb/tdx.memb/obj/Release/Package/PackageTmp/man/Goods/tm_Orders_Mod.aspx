<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tm_Orders_Mod.aspx.cs" Inherits="tdx.memb.man.Goods.tm_Orders_Mod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link href="../images4/nei.css" type="text/css" rel="stylesheet">
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <title>后台管理</title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <h1>
        <strong>团购订单处理</strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="errMsgBox">
            <div class="notice rb">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></div>
        </div>
        <div class="welcometext">
            <asp:Label ID="lblDate" runat="server"></asp:Label></div>
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
                    订单编号
                </td>
                <td style="width: 70%; height: 24px; z-index: 1000;">
                    <asp:Label ID="lblBillNo" runat="server"></asp:Label>
                </td>
                <td width="10%" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    订货人
                </td>
                <td style="width: 70%; height: 24px;">
                    <asp:Label ID="lblmem" runat="server"></asp:Label>
                </td>
                <td width="10%" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    收货人
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtConsignee" placeholder="收货人姓名" class="px" runat="server"
                        id="txtConsignee" />
                </td>
                <td width="10%" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    地址
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtDetailAddr" placeholder="收货地址" class="px" runat="server"
                        id="txtDetailAddr" />
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    邮编
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtZipcode" placeholder="邮政编码" class="px" runat="server"
                        id="txtZipcode" />
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    电话
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtTelephone" placeholder="电话" class="px" runat="server"
                        id="txtTelephone" />
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    手机
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtMobile" placeholder="手机" class="px" runat="server" id="txtMobile" />
                </td>
                <td width="10%" style="height: 24px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    订单金额
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtSname" placeholder="订单金额,必须为大于0的数字" class="px" runat="server"
                        id="txtAmtOld" />
                    <asp:RegularExpressionValidator ID="valeAmtOld" runat="server" Display="Dynamic"
                        ErrorMessage="*请输入数值,如:1、2、2.5..." ControlToValidate="txtAmtOld" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    运费
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtYF" placeholder="团购订单邮费,必须为大于0的数字" runat="server" id="txtYF"
                        class="px" />
                    <asp:RegularExpressionValidator ID="valeYF" runat="server" Display="Dynamic" ErrorMessage="*请输入数值,如:1、2、2.5..."
                        ControlToValidate="txtYF" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    总金额
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtAmt" placeholder="订单总金额,必须为大于0的数字" runat="server" id="txtAmt"
                        class="px" />
                    <asp:RegularExpressionValidator ID="valeAmt" runat="server" Display="Dynamic" ErrorMessage="*请输入数值,如:1、2、2.5..."
                        ControlToValidate="txtAmt" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    总积分
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtCent" placeholder="订单总积分,必须为大于0的数字" runat="server" id="txtCent"
                        class="px" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="*请输入数值,如:1、2、2.5..." ControlToValidate="txtCent" ValidationExpression="\d+(\.\d*)?"></asp:RegularExpressionValidator>
                </td>
                <td width="10%" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" style="height: 35px">
                    配送时间
                </td>
                <td style="width: 70%; height: 24px;">
                    <input type="text" name="txtSendDate" placeholder="订单配送时间" runat="server" id="txtSendDate"
                        class="px" />
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
                    <textarea id="txtRemarks" runat="server" placeholder="订单备注信息" cols="20" rows="5"
                        class="px2"></textarea>
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
