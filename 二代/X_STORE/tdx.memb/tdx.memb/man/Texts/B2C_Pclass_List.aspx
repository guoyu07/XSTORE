<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Pclass_List.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_Pclass_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站系统</title>
    <link href="/memb/images4/nei.css" type="text/css" rel="stylesheet" />
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/content.css" rel="stylesheet" type="text/css" />
    <link href="../images4/dh_main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/common.js" type="text/javascript"></script>
    <script src="../scripts/resize.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
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
    <div id="tabstrip" class="tabstripcontainer">
        <ul>
            <li><a href="javascript:void(0);" class="selected"><span class="wrap"><span class="innerwrap">
                类别管理</span></span></a></li>
        </ul>
    </div>
    <div id="scrollable" class="content">
        <div class="donotpadtopandbottom">
            <div class="welcometext">
                <asp:Label ID="lb_date" runat="server"> </asp:Label></div>
            <div>
                <table class="fullwidthtable" cellpadding="4" cellspacing="0" border="0">
                    <tr>
                        <td class="settingsheader">
                            <input type="checkbox" class="btn" name="delAll" id="delAll" runat="server" onclick="this.value=checkAll(form1.delbox,this);" />全部&nbsp;
                            <input id="isdelBtn" type="button" runat="server" class="btn" value="删 除" onserverclick="isdelBtn_ServerClick" />
                            <input id="disnetBtn" type="button" runat="server" class="btn" value="启 用" onserverclick="disnetBtn_ServerClick" />
                            <asp:Button ID="delBtn" runat="server" Text="彻底删除" class="btn" ForeColor="Red" OnClick="delBtn_ServerClick"
                                OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" />
                        </td>
                        <td class="settingsheader" align="right" style="padding-right: 30px;">
                            <asp:Label ID="lb_cateadd" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <div class="tdh">
                                <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="footerpanel" class="footercontainer">
        <div class="pagercontainer">
            <span class="hyperpagerwrapper"><span class="hyperpager">
                <asp:Literal ID="lt_pagearrow" runat="server"> </asp:Literal>
            </span></span>
        </div>
    </div>
    <script type="text/javascript">
        ResizeEvent();
        window.onresize = function () { ResizeEvent(); }
    </script>
    </form>
</body>
</html>

