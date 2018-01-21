<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipcardEdit.aspx.cs" Inherits="tdx.memb.man.vipmemb.VipcardEdit" %>

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
        <strong>会员卡信息</strong></h1>
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
                    会员卡是否开启
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="is_open" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    钱包是否开启
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="m_open" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    积分是否开启
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="j_open" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    名 称
                </td>
                <td class="enter_content">
                    <input name="name" style="height: 25px;" placeholder="会员卡名称" id="name" runat="server"
                        class="px" maxlength="50" type="text" />
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    LOGO
                </td>
                <td class="enter_content">
                    <input id="title_image" runat="server" class="px" maxlength="255" name="title_image"
                        style="height: 30px;" type="file" /><br />
                    <img id="image" runat="Server" alt="LOGO" src="~/images/left_menu_li_bg.jpg" style="width: 150px;" />&nbsp;
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    卡号前缀
                </td>
                <td class="enter_content">
                    <input type="text" id="pre_name" class="px" placeholder="比如NOVIP" runat="server"
                        name="pre_name" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    起始卡号
                </td>
                <td class="enter_content">
                    <input type="text" id="card_start" placeholder="起始卡号为大于0的数字" class="px" runat="server"
                        name="card_start" maxlength="9" />
                </td>
                <td class="rb">*<asp:HiddenField ID="hf" Value="0" runat="server" /></td>
            </tr>
            <tr id="tj" runat="server" style="display: none;">
                <td class="enter_title">
                    领取条件
                </td>
                <td class="enter_content" id="tiaojian" runat="server">
                    <select name="get_card_condition" runat="server" id="get_card_condition" enableviewstate="false"
                        class="select-field">
                    </select>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    未领取会员卡提示
                </td>
                <td class="enter_content">
                    <textarea id="no_getinfo" runat="server" class="px2" cols="20" rows="2" placeholder="未领取卡号时显示的文字" ></textarea>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    会员卡提示信息
                </td>
                <td class="enter_content">
                    <textarea id="card_info" runat="server" class="px2" cols="20" rows="2" placeholder="会员卡提示的信息"></textarea>
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
        <div class="enter_remind" style="height:180px;width:300px;background: url('/man/images4/0115_1.jpg') no-repeat;" >
        
        </div>
    </div>
    </form>
</body>
</html>

