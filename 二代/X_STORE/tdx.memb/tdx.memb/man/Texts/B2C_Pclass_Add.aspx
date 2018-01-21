<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Pclass_Add.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_Pclass_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站系统</title>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/content.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/common.js" type="text/javascript"></script>
    <script src="../scripts/resize.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function Preview() {
            var img1 = document.getElementById("Image1");
            var fileup = document.getElementById("txtgif");
            img1.src = fileup.value;
        }
    </script>
    <style type="text/css">
        #txtpx
        {
            height: 19px;
            width: 218px;
        }
        #txturl
        {
            width: 219px;
        }
        #txtparent
        {
            width: 144px;
        }
    </style>
</head>
<body>
    <script type="text/javascript">
        function ResizeEvent() {
            var documentObj = GetDocumentObj();
            var pageSize = documentObj.clientHeight;
            pageSize = AdjustForSize(pageSize, 'headerpanel');
            pageSize = AdjustForSize(pageSize, 'buttonrow');
            pageSize = AdjustForSize(pageSize, 'tiptext');
            pageSize = AdjustForSize(pageSize, 'tabstrip');
            pageSize = AdjustForSize(pageSize, 'footerpanel');
            SetHeight('scrollable', pageSize);
            SetWidth('scrollable', documentObj.clientWidth);
        }
    </script>
    <div id="nei_content" class="nei_content">
        <div id="tabstrip" class="tabstripcontainer">
            <ul>
                <li><a href="javascript:void(0);" class="selected"><span class="wrap"><span class="innerwrap">
                    添加类别</span></span></a></li>
            </ul>
        </div>
        <div id="scrollable" class="content">
            <div class="donotpadtopandbottom">
                <form id="form1" runat="server">
                <div class="welcometext">
                    <asp:Label ID="lb_date" runat="server"> </asp:Label></div>
                <input type="hidden" name="class_parent" value="0" id="class_parent" runat="server" />
                <input type="hidden" name="class_level" value="0" id="class_level" runat="server" />
                <div>
                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="2">
                        <tr bgcolor="#427faf">
                            <td height="30" colspan="3" align="center">
                                处理类别应用&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" align="center" class="tablehead" style="height: 24px">
                                父类名称
                            </td>
                            <td style="width: 70%; height: 24px;">
                                <input type="text" name="txtparent" placeholder="父类名称" class="wida" runat="server"
                                    id="txtparent" maxlength="200" readonly="readonly" />
                            </td>
                            <td width="30%" style="height: 24px">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" align="center" class="tablehead" style="height: 24px">
                                名称
                            </td>
                            <td style="width: 70%; height: 24px;">
                                <input type="text" name="txtmc" placeholder="名称,必填" class="wida" runat="server" id="txtmc"
                                    maxlength="200" /><asp:RequiredFieldValidator ID="Reqmc" runat="server" ControlToValidate="txtmc"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td width="30%" style="height: 24px">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" align="center" class="tablehead" style="height: 24px">
                                代表图片
                            </td>
                            <td style="width: 70%; height: 24px;">
                                <input id="txtgif" type="file" class="wida" runat="server" maxlength="300" onchange="Preview()" /><br />
                                <asp:Image ID="Image1" runat="server" Width="100" />
                            </td>
                            <td width="30%" style="height: 24px">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" align="center" class="tablehead" style="height: 24px">
                                链接地址
                            </td>
                            <td style="width: 70%; height: 24px;">
                                <input type="text" name="txturl" placeholder="链接地址" class="wida" runat="server" id="txturl"
                                    maxlength="2000" />
                            </td>
                            <td width="30%" style="height: 24px">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" align="center" class="tablehead" style="height: 24px">
                                排序
                            </td>
                            <td style="width: 70%; height: 24px;">
                                <input type="text" name="txtpx" placeholder="排序规则，必须为数字，默认为99" class="wida" runat="server"
                                    id="txtpx" /><asp:RegularExpressionValidator ID="Regpx" runat="server" ControlToValidate="txtpx"
                                        ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            </td>
                            <td width="30%" style="height: 24px">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" align="center" class="tablehead" style="height: 24px">
                                描述
                            </td>
                            <td style="width: 70%; height: 24px;">
                                <textarea id="txtms" placeholder="描述信息，最多150字" cols="20" rows="2" name="txtms" runat="server"
                                    style="width: 300px; height: 100px;" onchange="if(this.value.length> 150){alert( '最多150字！ ');return   false;}"></textarea>
                            </td>
                            <td width="30%" style="height: 24px">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td colspan="3" align="center" style="height: 30px">
                                <input type="button" value="保 存" class="input" runat="server" id="btnSave" onserverclick="btnSave_ServerClick"
                                    style="width: 70px" />
                            </td>
                        </tr>
                    </table>
                </div>
                </form>
            </div>
        </div>
        <div id="footerpanel" class="footercontainer">
            <div class="pagercontainer">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        ResizeEvent();
        window.onresize = function () { ResizeEvent(); }

    </script>
</body>
</html>
