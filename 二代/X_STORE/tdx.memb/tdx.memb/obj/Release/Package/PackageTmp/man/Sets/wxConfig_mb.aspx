<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxConfig_mb.aspx.cs" Inherits="tdx.memb.man.Sets.wxConfig_mb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <!--中间开始-->    
    <form id="form1" runat="server">
    <h1>
        <strong>模板选择</strong>
    </h1>
    <div class="nei_content">
    <asp:Literal ID="daohang_Image" runat="server"></asp:Literal>
        <!--center content-->
        <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <div class="tsxx">
         
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2" >
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>
        <div>
            <ul class="tab_nav">
                <li _target="div_firstPage"><a href="javascript:void(0)" class="tab_nav_item tab_nav_select">
                    首页模板</a></li>
                <li _target="div_liebiao"><a href="javascript:void(0)" class="tab_nav_item">列表页模板</a></li>
                <li _target="div_xiangqing"><a href="javascript:void(0)" class="tab_nav_item">详情页模板</a></li>
                <li _target="div_kuaijie"><a href="javascript:void(0)" class="tab_nav_item">快捷方式模板</a></li>
            </ul>
        </div>
        <div class="qiehuanQu">
            <div id="div_firstPage" class="div_Page" runat="server">
                <asp:Literal ID="lt_shouye" runat="server"></asp:Literal>
            </div>
            <div id="div_liebiao" class="div_Page" runat="server" style="display: none">
                <asp:Literal ID="lt_liebiao" runat="server"></asp:Literal>
            </div>
            <div id="div_xiangqing" class="div_Page" runat="server" style="display: none">
                <asp:Literal ID="lt_xiangqing" runat="server"></asp:Literal>
            </div>
            <div id="div_kuaijie" class="div_Page" runat="server" style="display: none">
                <asp:Literal ID="lt_kuaijie" runat="server"></asp:Literal>
            </div>
            
        </div>
        <div class="btn_container btn_center">
            <input type="button" value="保存" class="btnSave" runat="server" id="Button1"
                onserverclick="Button1_ServerClick" /> <br />
            <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>               
        </div>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
