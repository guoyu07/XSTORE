<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_memEdit.aspx.cs" Inherits="tdx.memb.man.vipmemb.B2C_memEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员信息管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />   
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/tdx_date.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>会员信息编辑</strong></h1>
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
            <span class="tsxx_2" href="####">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>

        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    会员名
                </td>
                <td class="enter_content">
                    <input name="M_name" placeholder="请输入会员的用户名,如:张三" runat="server" id="M_name" class="px"
                        maxlength="50" type="text">                    
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    性 别
                </td>
                <td class="enter_content">
                    <select name="M_sex" runat="server" id="M_sex" class="select-field_sousuo">
                        <option value="男">- 男</option>
                        <option value="女">- 女</option>
                    </select>                    
                </td>
               <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    标 签
                </td>
                <td class="enter_content">
                    <input name="M_tags" id="M_tags" placeholder="请输入会员的标签,用于描述" runat="server" class="px"
                        maxlength="255" type="text">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    学 历
                </td>
                <td class="enter_content">
                    <select name="M_xueli" runat="server" id="M_xueli" class="select-field_sousuo">
                        <option value="初中">- 初中</option>
                        <option value="高中">- 高中</option>
                        <option value="大专">- 大专</option>
                        <option value="本科">- 本科</option>
                        <option value="研究生">- 研究生</option>
                        <option value="博士">- 博士</option>
                    </select>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    地 址
                </td>
                <td class="enter_content">
                    <input name="M_addr" id="M_addr" placeholder="请输入会员的住址" runat="server" class="px"
                        maxlength="255" type="text">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    电 话
                </td>
                <td class="enter_content">
                    <input name="M_tel" id="M_tel" placeholder="请输入会员的固定电话" runat="server" class="px" maxlength="20"
                        type="text">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    传 真
                </td>
                <td class="enter_content">
                    <input name="M_fax" id="M_fax" placeholder="请输入会员的传真号" runat="server" class="px" maxlength="20"
                        type="text">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    手 机
                </td>
                <td class="enter_content">
                    <input name="M_mobile" id="M_mobile" placeholder="请输入会员的手机号" runat="server" class="px"
                        maxlength="20" type="text">                   
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    生 日
                </td>
                <td class="enter_content">
                    <input name="M_BirthDay" id="M_BirthDay" onfocus="HS_setDate(this)" readonly="readonly"
                        runat="server" class="px"  type="text">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    邮 箱
                </td>
                <td class="enter_content">
                    <input name="M_email" id="M_email" placeholder="请输入会员的邮箱" runat="server" class="px" type="text" maxlength="20">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    QQ
                </td>
                <td class="enter_content">
                    <input name="M_QQ" id="M_QQ" runat="server" placeholder="QQ号" class="px" type="text" maxlength="20">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    会员头像
                </td>
                <td class="enter_content">
                    <input runat="server" name="M_photo" id="M_photo" class="px" maxlength="255" type="file"><br />
                    <img runat="Server" width="100" id="m_ph" src="" />
                </td>
            </tr>
            <tr id="DPID" runat="server" style="display: none">
                <td class="enter_title">
                    BPID
                </td>
                <td class="enter_content">
                    <input name="M_DPID" id="M_DPID" runat="server" placeholder="请输入会员的唯一单号" class="px" type="text" maxlength="50">
                </td>
            </tr>
            <tr id="CarNo" runat="server" style="display: none">
                <td class="enter_title">
                    车架号
                </td>
                <td class="enter_content">
                    <input name="M_CarNo" id="M_CarNo" runat="server" placeholder="请输入会员的车架号" class="px" type="text" maxlength="50">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                        value=" 保 存 " class="btnGreen" type="button">
                </td>
            </tr>
        </table>

        <div class="enter_remind">
        </div>
    </div>
    <!--内容-->
    <!--内容结束-->
    </form>
</body>
</html>
