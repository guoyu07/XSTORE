<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="tdx.vip.log" %>
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
    <link href="css/comm.css" rel="stylesheet" type="text/css" />
    <link href="css/log.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>   
    <script type="text/javascript">
        $(function () {
            $(".lOptions ul li").click(function () {
                var _this = $(this);
                if (_this.attr("class") != "select") {
                    _this.addClass("select");
                    _this.siblings().removeClass("select");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="lbody">
        <div class="lOptions">
            <ul>
                <li class="select" id="li_jine" runat="server"><asp:Literal ID="lt_jine" runat="server"></asp:Literal></li>
                <li id="li_jifen" runat="server"><asp:Literal ID="lt_jifen" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="lLogList">
        <asp:Literal ID="lt_log" runat="server"></asp:Literal>
        </div>
    </div>
    </div>
    <vip:vipFooter id="vipFooter" runat="server"   EnableViewState="False" />
    </form>
</body>
</html>
