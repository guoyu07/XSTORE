<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Photo_List.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_Photo_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PICC - 文档信息表</title>
    <link href="/memb/images4/nei.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/global.css" />
    <link rel="stylesheet" type="text/css" href="../css/content.css" />
    <link href="../images4/dh_main.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/common.js" type="text/javascript"></script>
    <script src="../scripts/resize.js" type="text/javascript"></script>
    <script src="../canlender/NewTime.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 868px;
        }
    </style>
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
                图片列表</span></span></a></li>
        </ul>
    </div>
    <div id="scrollable" class="content">
        <div class="donotpadtopandbottom">
            <div class="welcometext">
                <asp:Label ID="lb_date" runat="server"> </asp:Label></div>
            <div class="fullwidthtable">
                <table cellpadding="4" cellspacing="0" style="border: 1px solid #efefef; margin-left: 30px;
                    margin-bottom: 10px; width: 830px;">
                    <tr>
                        <td class="style1">
                            关键词：<input type="text" placeholder="请输入关键字搜索" name="ss_keyword" id="ss_keyword" runat="server"
                                style="width: 256px" />
                            <select name="ss_cid" id="ss_cid" size="1" runat="server" style="width: 180px">
                                <option value="">---选择类别---</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="style1">
                            建 &nbsp; 档：<input type="text" value="" name="ss_Bdate" id="ss_Bdate" runat="server"
                                style="width: 120px" onclick="setday(this)" readonly />~<input type="text" value=""
                                    name="ss_Edate" id="ss_Edate" runat="server" style="width: 120px" onclick="setday(this)"
                                    readonly />&nbsp;
                            <input type="checkbox" name="ss_isActive" id="ss_isActive" style="clear: both; width: 20px;"
                                value="1" runat="server" />启停
                            <input type="checkbox" name="ss_isDel" id="ss_isDel" style="clear: both; width: 20px;"
                                value="1" runat="server" />回收站&nbsp;
                            <input type="button" id="ss_btn" runat="server" style="clear: both; width: 50px;"
                                value="搜 索" onserverclick="ss_btn_ServerClick" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table class="fullwidthtable" cellpadding="4" cellspacing="0" border="0">
                    <tr>
                        <td class="settingsheader" width="90%">
                            <input type="checkbox" name="delAll" id="delAll" style="clear: both; width: 20px;"
                                runat="server" onclick="this.value=checkAll(form1.delbox,this);" />全部
                            <asp:Button ID="Button6" runat="server" Text="删 除" Style="clear: both; width: 50px;"
                                CssClass="input" OnClick="Button6_Click" />
                            <asp:Button ID="Button1" runat="server" Style="clear: both; width: 50px;" Text="启 停"
                                CssClass="input" OnClick="Button1_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="delBtn" runat="server" Style="clear: both; width: 70px;" ForeColor="Red"
                                Text="彻底删除" CssClass="input" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')"
                                OnClick="delBtn_Click" />
                        </td>
                        <td class="settingsheader" align="right" style="padding-right: 10px;">
                            <asp:Literal ID="lb_proadd" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td coslpan="2" align="center" colspan="2">
                            <div class="tdh">
                                <asp:Literal ID="lb_prolist" runat="server"></asp:Literal>
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
                <!--
        <span class="pagerarrow"><img src="images/pager/endArrow_L_disabled.gif" align="absmiddle" /></span>
        <span class="pagerarrow"><img src="images/pager/doubleArrow_L_disabled.gif" align="absmiddle" /></span>
        <span class="pagerarrow"><img src="images/pager/singleArrow_L_disabled.gif" align="absmiddle" /></span>
        <span class="hppagecurrent">1</span>
        <span class="hppage"><a href="#">2</a></span>
        <span class="hppage"><a href="#">3</a></span>
        <span class="hppage">of 3</span>
        <span class="pagerarrow"><a href="#"><img src="images/pager/singleArrow_R.gif" align="absmiddle" /></a></span>
        <span class="pagerarrow"><img src="images/pager/doubleArrow_R_disabled.gif" align="absmiddle"  /></span>
        <span class="pagerarrow"><a href="#"><img src="images/pager/endArrow_R.gif" align="absmiddle" /></a></span>
        -->
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
