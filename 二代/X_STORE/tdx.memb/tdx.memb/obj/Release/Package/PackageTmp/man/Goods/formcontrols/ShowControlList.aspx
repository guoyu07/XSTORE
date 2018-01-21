<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowControlList.aspx.cs" Inherits="tdx.memb.man.formcontrols.ShowControlList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>信息列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>
            <asp:Literal ID="xmmingcheng" runat="server"></asp:Literal>结果查看</strong></h1>

    <div id="nei_content" class="nei_content">
        <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <!--提示-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <asp:HiddenField ID="objIK" runat="server" />
        <div class="nei_seach">
            <select name="select_sousuo" runat="server" id="select_sousuo" class="select-field_sousuo">
                <option value="全部">- 全部</option>
                <option value="微信ID">- 微信ID</option>
            </select>
            <input type="text" id="sousuo_txt" runat="server" class="sousuo_px" placeholder="请选择相应条件，填写对应内容进行查询">
            <input id="Button1" type="button" value="搜索" runat="server" onserverclick="btn_save_ServerClick"
                class="btnGray">
            <input id="Button2" type="button" value="导出EXCEL" runat="server" onserverclick="btn_downexcel"
                class="btnSave">
            <asp:Literal ID="xiazai" runat="server"></asp:Literal></div>
        <div class="btn_container">
            <asp:Literal ID="tianjia" runat="server">
                      
            </asp:Literal></div>
        <div class="tdh">
            <asp:Literal ID="zdList" runat="server" EnableViewState="false">

            </asp:Literal></div>
    </div>
    <!--内容-->
    <!--内容结束-->
    </form>
</body>
</html>

