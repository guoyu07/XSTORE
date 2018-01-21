<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntegralEdit.aspx.cs" Inherits="tdx.memb.man.vipmemb.IntegralEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/tdx_date.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>积分规则配置</strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    充值还是消费
                </td>
                <td class="enter_content">
                    <label >
                        充值</label>
                    <input name="pay" type="radio" runat="server" id="pay" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <label>
                        消费</label>
                    <input name="pay" runat="server" id="cost" type="radio" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    产生的费用
                </td>
                <td class="enter_content">
                    <input name="amount" placeholder="积分为大于零的数字"  id="amount" runat="server"
                        class="px" maxlength="50" type="text" />
                        <i>元</i>
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    赠送的积分
                </td>
                <td class="enter_content">
                    <input name="give_amount" placeholder="积分为大于零的数字"  id="give_amount"
                        runat="server" class="px" maxlength="50" type="text" />
                        <i>积分</i>
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否累加
                </td>
                <td class="enter_content">
                    <input type="checkbox" id="is_add" runat="server" name="is_add" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    等 级
                </td>
                <td class="enter_content">
                    <select name="rankid" runat="server" id="rankid" enableviewstate="false" onchange="getSelectedValue();"
                        class="select-field_sousuo">
                    </select>
                    <span id="Regpx" style="color: Red; visibility: hidden;">*必须为数字</span>
                </td>
                <td>
                    <asp:HiddenField ID="hf" Value="1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    开始时间
                </td>
                <td class="enter_content">
                    <input type="text" onfocus="HS_setDate(this)" class="px"  id="star_time"
                        runat="server" name="is_add" />
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    结束时间
                </td>
                <td class="enter_content">
                    <input type="text" class="px"  onfocus="HS_setDate(this)" id="end_time"
                        runat="server" name="is_add" />
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    描述
                </td>
                <td class="enter_content">
                    <textarea id="des" runat="server" placeholder="描述说明" class="px2" cols="20" rows="2"></textarea>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                        value=" 保 存 " class="btnSave" type="button" />
                </td>
            </tr>
        </table>
        <div class="enter_remind">
        </div>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
        function getSelectedValue() {
            var obj = document.getElementById("rankid");
            document.getElementById("hf").value = obj.value;
        }

        function btn_save_onclick() {
            if ($("#star_time").val() == null) {
                alert("开始时间不能为空!");
            } else if ($("#end_time").val() == null) {
                alert("结束时间不能为空!");
            }
        }

    </script>
</body>
</html>
