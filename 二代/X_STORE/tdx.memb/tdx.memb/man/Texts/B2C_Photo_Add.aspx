<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Photo_Add.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_Photo_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站系统</title>
    <link rel="stylesheet" type="text/css" href="../css/global.css" />
    <link rel="stylesheet" type="text/css" href="../css/content.css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/common.js" type="text/javascript"></script>
    <script src="../scripts/resize.js" type="text/javascript"></script>
    <script src="../canlender/NewTime.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
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
                    图片设置</span></span></a></li>
            </ul>
        </div>
        <div id="scrollable" class="content">
            <div class="donotpadtopandbottom">
                <form id="form1" runat="server">
                <input type="hidden" name="wtab" id="wtab" value="" runat="server" />
                <input type="hidden" name="wrow" id="wrow" value="" runat="server" />
                <div class="welcometext">
                    <asp:Label ID="lb_date" runat="server"> </asp:Label></div>
                <div>
                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="2">
                        <tr bgcolor="#427faf">
                            <td colspan="3" align="center" style="height: 29px">
                                处理图片资料&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" height="24" align="center" class="tablehead">
                                类&nbsp; 别
                            </td>
                            <td style="width: 70%">
                                <select id="cid" name="cid" runat="server" class="wida">
                                    <option></option>
                                </select>
                            </td>
                            <td width="30%">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" height="24" align="center" class="tablehead">
                                图片号
                            </td>
                            <td style="width: 70%">
                                <input type="text" name="t_title" placeholder="图片号" runat="server" id="t_title" class="wida"
                                    maxlength="255" />
                            </td>
                            <td width="30%">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" height="24" align="center" class="tablehead">
                                图片名称
                            </td>
                            <td style="width: 70%">
                                <input type="text" name="t_author" placeholder="图片名称" class="wida" runat="server"
                                    id="t_author" maxlength="50" />
                            </td>
                            <td width="30%">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" height="24" align="center" class="tablehead">
                                上传方式
                            </td>
                            <td style="width: 70%">
                                <input type="radio" name="RD1" value="0" onclick="setTbody(1);" />上传
                                <input type="radio" name="RD1" value="1" checked onclick="setTbody(2);" />路径
                            </td>
                            <td width="30%">
                            </td>
                        </tr>
                        <tbody id="RD2">
                            <tr bgcolor="#def0ff">
                                <td width="20%" height="24" align="center" class="tablehead">
                                    上传
                                </td>
                                <td style="width: 70%">
                                    <input type="file" name="t_source_file" runat="server" id="t_source_file" class="wida"
                                        maxlength="255" />&nbsp;
                                </td>
                                <td width="30%">
                                </td>
                            </tr>
                        </tbody>
                        <tbody id="RD3">
                            <tr bgcolor="#def0ff">
                                <td width="20%" height="24" align="center" class="tablehead">
                                    路径
                                </td>
                                <td style="width: 70%">
                                    <input type="text" name="t_source_url" placeholder="图片路径" runat="server" id="t_source_url"
                                        class="wida" maxlength="255" />&nbsp;
                                </td>
                                <td width="30%">
                                </td>
                            </tr>
                        </tbody>
                        <tr bgcolor="#def0ff">
                            <td width="20%" height="24" align="center" class="tablehead" onclick="setday(this)"
                                readonly>
                                简介
                            </td>
                            <td style="width: 70%">
                                <textarea name="t_wdes" cols="40" rows="6" runat="server" placeholder="简介信息" id="t_wdes"
                                    class="wida"></textarea>
                            </td>
                            <td width="30%">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" height="24" align="center" class="tablehead">
                                排序
                            </td>
                            <td style="width: 70%">
                                <input type="text" name="t_w_sort" placeholder="排序规则，必须为数字，默认为99" runat="server" id="t_w_sort"
                                    class="wida" maxlength="255" />&nbsp;
                            </td>
                            <td width="30%">
                            </td>
                        </tr>
                        <tr bgcolor="#def0ff">
                            <td width="20%" height="24" align="center" class="tablehead">
                                建档日期
                            </td>
                            <td style="width: 70%">
                                <input type="text" placeholder="建档日期" name="t_wdate" value="" runat="server" id="t_wdate" class="wida"
                                    maxlength="255" onclick="setday(this)" readonly="readonly" />&nbsp;
                            </td>
                            <td width="30%">
                            </td>
                        </tr>
                        <tr>
                            <td height="30" colspan="2" align="center">
                                <input type="button" value="保 存" class="input" runat="server" id="Button1" style="width: 50px;"
                                    onserverclick="Button1_ServerClick" />
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
    <script src="../scripts/common.js" type="text/javascript"></script>
    <script src="../scripts/resize.js" type="text/javascript"></script>
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
    <script src="../scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        ResizeEvent();
        window.onresize = function () { ResizeEvent(); }

        $(function () {
            $("#RD3").css("display", "block");
            $("#RD2").css("display", "none");
        });
        function setTbody(_i) {
            switch (_i) {
                case 1:
                    $("#RD2").css("display", "block");
                    $("#RD3").css("display", "none");
                    break;
                case 2:
                    $("#RD2").css("display", "none");
                    $("#RD3").css("display", "block");
                    break;
                default:
                    $("#RD2").css("display", "block");
                    $("#RD3").css("display", "none");
                    break;
            }
        }
    </script>
</body>
</html>
