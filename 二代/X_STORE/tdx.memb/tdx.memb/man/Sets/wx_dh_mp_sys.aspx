<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_dh_mp_sys.aspx.cs" Inherits="tdx.memb.man.Sets.wx_dh_mp_sys" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../../js/area.js" type="text/javascript"></script>
    <style type="text/css">
        #s1
        {
            width: 72px;
        }
        #s2
        {
            width: 85px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>信息配置</strong></h1>
    <div class=" nei_content">
        <asp:Literal ID="ltHead" runat="server"></asp:Literal>
        <div class="nei_content" id="nei_content">
            <div class="errMsgBox">
                <div class="notice rb">
                    <asp:Literal ID="lt_result" runat="server"></asp:Literal>
                </div>
            </div>
            <h2>
                微信公众号信息</h2>
            <input type="hidden" name="hangye" id="hangye" runat="server" value="" />
            <input type="hidden" name="province" id="province" runat="server" value="" />
            <input type="hidden" name="city" id="city" runat="server" value="" />
            <input type="hidden" name="town" id="town" runat="server" value="" />
            <input type="hidden" name="hf" id="hf" runat="server" value="" />
            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        微信号
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtName" placeholder="输入用户对应微信号" class="px" runat="server"
                            id="txtName" maxlength="255" />
                    </td>
                    <td>
                        <span class="rb">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        昵 称
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtNichen" placeholder="用户昵称" class="px" runat="server"
                            id="txtNichen" maxlength="255" />
                    </td>
                    <td>
                        <span class="rb">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        原始号
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtGUID" placeholder="用户的原始号" class="px" runat="server"
                            id="txtGUID" maxlength="50" />
                    </td>
                    <td>
                        <span class="rb">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        开发者ID
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtDID" placeholder="请输入开发ID" class="px" runat="server"
                            id="txtDID" maxlength="255" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        开发者密码
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtDpsw" placeholder="请输入开发者密码" class="px" runat="server"
                            id="txtDpsw" maxlength="255" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        二维码
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="file" name="txtGif" class="px" runat="server" id="txtGif" maxlength="255" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        类 型
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="radio" id="RD_Cid1" value="0" name="RD_Cid" runat="server" checked />订阅号
                        <input type="radio" id="RD_Cid2" value="1" name="RD_Cid" runat="server" />服务号
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <h2>
                基本信息</h2>
            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        网站名称
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtNichen" placeholder="请输入网站的名称" class="px" runat="server"
                            id="Text1" maxlength="255" />
                    </td>
                    <td>
                        <span class="rb">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        公 司
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtCompany" placeholder="请输入公司的名称" class="px" runat="server"
                            id="txtCompany" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        电 话
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtTel" placeholder="联系电话" class="px" runat="server" id="txtTel" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        手 机
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtMobile" placeholder="手机号码" class="px" runat="server"
                            id="txtMobile" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        Email
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtMail" placeholder="邮箱" class="px" runat="server" id="txtMail" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        URL
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtUrl" placeholder="链接" class="px" runat="server" id="txtUrl" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        QQ
                    </td>
                    <td width="60%" class="enter_content">
                        <input type="text" name="txtQq" placeholder="QQ号码" class="px" runat="server" id="txtQq" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        地区
                    </td>
                    <td width="60%" class="enter_content">
                        <select id="Select1" name="Select1" runat="server">
                        </select><select id="Select2" name="Select2" runat="server"></select><select id="Select3"
                            name="Select3" runat="server"></select><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        行业
                    </td>
                    <td width="60%" class="enter_content">
                        <select id="hy" name="hy" runat="server">
                        </select>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td height="30" colspan="3" align="center">
                        <input type="button" value=" 保 存 " class="btnGreen" runat="server" id="Button1" onserverclick="Button1_ServerClick" />
                    </td>
                </tr>
                <asp:Literal ID="ltFoot" runat="server"></asp:Literal>
            </table>
        </div>
        <script language="javascript">
            addressInit('Select1', 'Select2', 'Select3');
        </script>
        <asp:Literal ID="sc" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
