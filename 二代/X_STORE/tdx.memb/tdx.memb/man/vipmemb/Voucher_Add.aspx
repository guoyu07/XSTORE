<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Voucher_Add.aspx.cs" Inherits="tdx.memb.man.vipmemb.Voucher_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>代金卷添加</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" language="javascript" type="text/javascript"></script>
    <script src="../../js/tdx_date.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>添加代金卷</strong></h1>
    <div class="nei_content" id="nei_content">
        <asp:Literal ID="ltHead" runat="server"></asp:Literal>
        <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    发行量
                </td>
                <td class="enter_content">
                    <input type="text" placeholder="发行量不得为空，且必须为数字" class="px" runat="server" onkeyup="value=value.replace(/[^\d]/g,'')"
                        id="num" maxlength="200" /><br />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    使用金额条件
                </td>
                <td class="enter_content">
                    <input type="text" placeholder="使用金额条件不得为空，且必须为数字" class="px" runat="server" onkeyup="value=value.replace(/[^\d]/g,'')"
                        id="amount" /><br />
                         <span class="gray">保存后不可更改</span><br />
                    <br />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    抵扣金额
                </td>
                <td class="enter_content">
                    <input type="text" placeholder="抵扣金额不得为空，且必须为数字" class="px" runat="server" onkeyup="value=value.replace(/[^\d]/g,'')"
                        id="deduction" /><br />
                        <span class="gray">保存后不可更改</span><br />
                    <br />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    开始时间
                </td>
                <td class="enter_content">
                    <input type="text" runat="server" cssclass="edLine" readonly="readonly" onfocus="HS_setDate(this)" placeholder="请输入起始时间，缺省从当月1号开始
                        id="start_time" /><br />
                        <span class="gray">保存后不可更改</span><br />
                    <br />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    结束时间
                </td>
                <td class="enter_content">
                    <input type="text" runat="server" cssclass="edLine" readonly="readonly" onfocus="HS_setDate(this)" placeholder="请输入截止时间，缺省截止到当天"
                        id="end_time" /><br />
                        <span class="gray">保存后不可更改</span><br />
                    <br />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否可激活
                </td>
                <td class="enter_content">
                    <select id="isactive" name="unit2" size="1" runat="server" class="select-field">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                    <span class="gray">默认为否</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input type="button" value=" 保 存 " class="btnSave" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" />
                </td>
            </tr>
            <asp:Literal ID="ltFoot" runat="server"></asp:Literal>
        </table>
        <div class="enter_remind">
        </div>
    </div>
    </form>
</body>
</html>
