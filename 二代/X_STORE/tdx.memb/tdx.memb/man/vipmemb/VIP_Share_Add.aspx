<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VIP_Share_Add.aspx.cs" Inherits="tdx.memb.man.vipmemb.VIP_Share_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员分享添加</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" language="javascript" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/tdx_date.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>添加分享</strong></h1>
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
                    标题
                </td>
                <td class="enter_content">
                    <input type="text" placeholder="标题不得为空" class="px" runat="server" id="name" maxlength="200" /><br />
                    <span class="gray">产品名称,不得为空,最长200个字符</span><br />
                    <br />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否可分享
                </td>
                <td class="enter_content">
                    <select id="unit2" name="unit2" size="1" runat="server" class="select-field">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                    <span class="gray">默认为否,分享关闭之后72小时之内积分仍有效</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    分享后获得积分
                </td>
                <td class="enter_content">
                    <input type="text" runat="server" id="ischead" onkeyup="value=value.replace(/[^\d]/g,'')"/>
                    <span class="gray">只能输入数字,分享后可获得积分,积分设定后不可修改</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    开始日期
                </td>
                <td class="enter_content">
                    <input type="text" runat="server" id="t_bdate" readonly  onfocus="HS_setDate(this)" placeholder="请输入起始时间，缺省从当天开始"/>
                    <span class="gray">选择本分享开始启动的日期</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    停止日期
                </td>
                <td class="enter_content">
                    <input type="text" runat="server" id="t_edate" readonly onfocus="HS_setDate(this)" placeholder="请输入截止时间，缺省截止到下月本日"/>
                    <span class="gray">选择本分享停止执行的日期</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    代表图片
                </td>
                <td class="enter_content">
                    <input id="gif" type="file" class="px" runat="server" maxlength="300" onchange="Preview()" /><br />
                    <span class="gray">最大宽高:360*200 像素:72 格式:jpg png gif</span><br />
                    <br />
                    <asp:Image ID="Image1" runat="server" Width="180" Height="100" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    分享内容
                </td>
                <td class="enter_content">
                    <fckeditorv2:FCKeditor ID="_msg" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
                        Height="350px">
                    </fckeditorv2:FCKeditor>
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

