<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photolist.aspx.cs" Inherits="tdx.appv.photolist" %>

<%@ Register Src="appv_head.ascx" TagPrefix="uc" TagName="appHeader" %>
<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %>
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
    <asp:Literal ID='lt_keywords' runat="server"></asp:Literal>
    <asp:Literal ID='lt_description' runat="server"></asp:Literal>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <asp:Literal ID='lt_theme' runat='server'></asp:Literal>
    <script language="javascript" src="/Appv/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/Appv/js/fsWeixin_apps.js" type="text/javascript"
        charset="utf-8"></script>
    <script language="javascript" src="/Appv/js/swipe.js" charset="utf-8"></script>
</head>
<body class="nei_body">
    <uc:appHeader ID="appHeader1" runat="server" EnableViewState="False"></uc:appHeader>
    <div class="d_body">
        <div class="d_content">
            <div class="Appcontent">
                <asp:Literal ID="h_title" runat="server"></asp:Literal>
                <p>
                    &nbsp;&nbsp;
                </p>
            </div>
            <div style="-webkit-transform: translate3d(0,0,0);">
                <div id="banner_box" class="box_swipe">
                    <ul>
                        <asp:Literal ID="lt_photolist" runat="server" EnableViewState="false"></asp:Literal>
                    </ul>
                    <ol>
                        <asp:Literal ID="lt_arrowpage" runat="server" EnableViewState="false"></asp:Literal>
                    </ol>
                </div>
            </div>
            <script>
                $(function () {
                    new Swipe(document.getElementById('banner_box'), {
                        speed: 500,
                        auto: 3000,
                        callback: function () {
                            var lis = $(this.element).next("ol").children();
                            lis.removeClass("on").eq(this.index).addClass("on");
                        }
                    });
                });
            </script>
        </div>
    </div>
    <uc:appFooter ID="appFooter1" runat="server" EnableViewState="False"></uc:appFooter>
</body>
</html>
