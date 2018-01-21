<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="privilege.aspx.cs" Inherits="tdx.vip.privilege" %>
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
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="js/jquery.promptu-menu.js" type="text/javascript"></script>
    <link href="css/comm.css" rel="stylesheet" type="text/css" />
    <link href="css/privilege.css" rel="stylesheet" type="text/css" />
    <link href="css/promptumenu.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var _width = $("#pToday").width();
            var _height = $("#pToday").height();
            $("#pToday ul").promptumenu({ width: _width, height: _height, rows: 1, columns: 1, direction: 'horizontal', pages: true });
            $(".pOptions ul li").click(function () {
                var _this = $(this);
                if (_this.attr("class") != "select") {
                    _this.addClass("select");
                    _this.siblings().removeClass("select");
                }
                $("#" + _this.attr("tab")).siblings().hide();
                $("#" + _this.attr("tab")).fadeIn();
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="pbody">
        <div class="pOptions">
            <ul>
                <li class="select" tab=""><a>今日</a></li>
                <li><a>历史</a></li>
            </ul>
        </div>
        <div class="pContent">
            <div id="pToday">
                <ul>
                    <li><a>
                        <img src="image/jipai.jpg" /><span><i>会员特价：9999.99</i></span></a>
                        <input type="button" value="我要订购" /></li>
                </ul>
            </div>
            <div id="pHistory">
            </div>
        </div>
    </div>
    <vip:vipFooter id="vipFooter" runat="server"   EnableViewState="False" />
    </form>
</body>
</html>
