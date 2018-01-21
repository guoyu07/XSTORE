<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RankinfoEdit.aspx.cs" Inherits="tdx.memb.man.vipmemb.RankinfoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>配置会员等级信息</strong></h1>
    <div class="nei_content" id="nei_content">
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
                    名 称
                </td>
                <td class="enter_content">
                    <input name="name" style="height: 25px;" placeholder="等级名称" id="name" runat="server"
                        class="px" maxlength="50" type="text" />
                </td>
                <td class="rb">*
                </td>
            </tr>
            <tr id="jifen" runat="server">
                <td class="enter_title">
                    等级积分条件
                </td>
                <td class="enter_content">
                    <input name="score" placeholder="积分为大于0的整数" id="score" runat="server" class="px"
                        maxlength="50" type="text" /><br />
                        <span class="gray">达到该积分后激活</span><br />
                </td>
                <td class="rb">*</td>
            </tr>
            <tr id="over" runat="server">
                <td class="enter_title">
                    过期天数
                </td>
                <td class="enter_content">
                    <input name="overdays" id="overdays" runat="server" class="px" maxlength="50" type="text"
                        value="0" readonly="readonly" />
                    后过期
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    等级说明
                </td>
                <td class="enter_content">
                    <textarea id="des" runat="server" class="px2" cols="20" placeholder="等级说明信息" rows="2"></textarea>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                        value=" 保 存 " class="btnGreen" type="button" />
                </td>
            </tr>
        </table>
        <div class="enter_remind">
        </div>
    </div>
    </form>
</body>
</html>

