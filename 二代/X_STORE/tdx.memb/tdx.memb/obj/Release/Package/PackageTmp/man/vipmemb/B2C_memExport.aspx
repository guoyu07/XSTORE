<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_memExport.aspx.cs" Inherits="tdx.memb.man.vipmemb.B2C_memExport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>导出会员资料</strong>： 设置要导出的字段</h1>
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
                    是否显示姓名
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_uname" /><span class="gray">勾选代表显示姓名</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示公司
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_utruename" /><span class="gray">勾选代表显示公司</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示电话号码
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_utel" /><span class="gray">勾选代表显示电话号码</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示手机号码
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_umobile" /><span class="gray">勾选代表显示手机号码</span><br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示Email
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_uemail" /><span class="gray">勾选代表显示Email</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示QQ
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_uqq" /><span class="gray">勾选代表显示QQ</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示地址
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_uaddr" /><span class="gray">勾选代表显示地址</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示传真
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_ufax" /><span class="gray">勾选代表显示传真</span><br />
                </td>
            </tr>
             <tr>
                <td class="enter_title">
                    是否显示微信ID
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_uwxID" /><span class="gray">勾选代表显示微信ID</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示性别
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_usex" /><span class="gray">勾选代表显示性别</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示注册日期
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_uregtime" /><span class="gray">勾选代表显示注册日期</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示生日
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_ubirthday" /><span class="gray">勾选代表显示生日</span><br />
                    <br />
                </td>
            </tr> 
            <tr>
                <td class="enter_title">
                    是否显示标签
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_utag" /><span class="gray">勾选代表显示标签</span><br />
                    <br />
                </td>
            </tr> 
            <tr>
                <td class="enter_title">
                    是否显示学历
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_uxueli" /><span class="gray">勾选代表显示学历</span><br />
                    <br />
                </td>
            </tr> 
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                        value=" 导 出 " class="btnSave" type="button" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                     <asp:Literal ID="lt_xiazai" runat="server" ></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
