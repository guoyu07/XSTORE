<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coupon.aspx.cs" Inherits="tdx.vip.coupon" %>

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
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <title></title>
    <link href="css/comm.css" rel="stylesheet" type="text/css" />
    <link href="css/coupon.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".cOptions ul li").click(function () {
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
    <div class="cbody">
        <div class="cOptions">
            <ul>
                <li class="select" tab="active"><a>可用</a></li>
                <li tab="unactive"><a>已用</a></li>
            </ul>
        </div>
        <div class="cContent">
            <div class="cAvailable">
                <div id="active">
                    <ul>
                        <asp:Literal ID="list_active" runat="server"></asp:Literal>
                    </ul>
                </div>
                <div id="unactive">
                    <ul>
                        <asp:Literal ID="list_unactive" runat="server"></asp:Literal>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <vip:vipFooter ID="vipFooter" runat="server" EnableViewState="False" />
    </form>
</body>
</html>
