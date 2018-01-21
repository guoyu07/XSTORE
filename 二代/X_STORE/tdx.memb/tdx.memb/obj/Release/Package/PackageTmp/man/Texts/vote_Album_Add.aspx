<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vote_Album_Add.aspx.cs" Inherits="tdx.memb.man.Texts.vote_Album_Add" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加投票项信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" language="javascript" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>添加投票项信息</strong></h1>
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
                    投票名称
                </td>
                <td class="enter_content">
                    <input type="text" placeholder="投票名称不得为空" class="px" runat="server" id="_name" maxlength="200" /><br />
                    <span class="gray">投票名称不得为空,最长200个字符</span><br />
                    <br />
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    所属投票项目
                </td>
                <td class="enter_content">
                    <select id="bigpic_id" name="unit2" size="1" runat="server" class="select-field">
                    </select>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    投票封面图片
                </td>
                <td class="enter_content">
                    <input id="_pic" type="file" class="px" runat="server" maxlength="300" onchange="Preview()" /><br />
                    <span class="gray">最大宽高:360*200 像素:72 格式:jpg png gif</span><br />
                    <br />
                    <asp:Image ID="Image1" runat="server" Width="180" Height="100" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    投票信息描述
                </td>
                <td class="enter_content">
                    <fckeditorv2:FCKeditor ID="_desc" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
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
