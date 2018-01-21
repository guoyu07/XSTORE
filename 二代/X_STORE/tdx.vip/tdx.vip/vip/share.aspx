<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="share.aspx.cs" Inherits="tdx.vip.share" %>
<%@ Register Src="vipFooter.ascx" TagPrefix="vip" TagName="vipFooter" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"
        name="viewport">
    <meta content="default" name="apple-mobile-web-app-status-bar-style">
    <meta content="yes" name="apple-mobile-web-app-capable">
    <meta content="telephone=no" name="format-detection" />
    <title></title>
    <link href="css/share.css" rel="stylesheet" type="text/css" />
    <link href="css/comm.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".sOptions ul li").click(function () {
                var _this = $(this);
                if (_this.attr("class") != "select") {
                    _this.addClass("select");
                    _this.siblings().removeClass("select");
                }
                $("#" + _this.attr("tab")).siblings().hide();
                $("#" + _this.attr("tab")).fadeIn();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="sbody">
        <div class="sOptions">
            <ul id="tabs">
                <li class="select" tab="now"><a>正在</a></li>
                <li tab="history"><a>历史</a></li>
            </ul>
        </div>
        <div class="sContent">
            <div id="now">
                <ul>
                    <asp:Literal ID="vip_share_now" runat="server"></asp:Literal>
                </ul>
            </div>
            <div id="history" style="display: none;">
                <ul>
                    <asp:Literal ID="vip_share_history" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
    <vip:vipFooter id="vipFooter" runat="server"   EnableViewState="False" />
    </form>
</body>
</html>
