<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weixinUserEdit.aspx.cs" Inherits="tdx.memb.man.weixinmoni.weixinUserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        <strong>微信用户信息</strong></h1>
    <div class="nei_content" id="nei_content">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
            <tbody>
                <tr>
                    <td align="center" height="40" width="20%">
                        微信昵称
                    </td>
                    <td width="60%">
                        <input name="name" readonly="readonly" style="height: 25px;" id="weixin_nichen" placeholder="微信昵称"
                            runat="server" class="px" maxlength="50" type="text" />
                    </td>
                    <td width="30%">
                    </td>
                </tr>
                <tr>
                    <td align="center" height="40" width="20%">
                        微信号
                    </td>
                    <td width="60%">
                        <input name="name" style="height: 25px;" id="weixin_id" placeholder="微信号" runat="server"
                            class="px" maxlength="50" type="text" />
                    </td>
                    <td width="30%">
                    </td>
                </tr>
                <tr>
                    <td align="center" height="40" width="20%">
                        备注
                    </td>
                    <td width="60%">
                        <input name="name" readonly="readonly" style="height: 25px;" id="remark_Name" placeholder="备注信息" runat="server"
                            class="px" maxlength="50" type="text" />
                    </td>
                    <td width="30%">
                    </td>
                </tr>
                <tr>
                    <td align="center" height="40" width="20%">
                        对应分组
                    </td>
                    <td width="60%">
                        <input name="name" readonly="readonly" style="height: 25px;" id="gropName" placeholder="分组名称" runat="server"
                            class="px" maxlength="50" type="text" />
                    </td>
                    <td width="30%">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" height="30">
                        <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                            value=" 保 存 " class="btnGreen" type="button" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>

