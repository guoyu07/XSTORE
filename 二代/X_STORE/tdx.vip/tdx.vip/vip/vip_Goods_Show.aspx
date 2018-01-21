<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vip_Goods_Show.aspx.cs"
    Inherits="tdx.vip.vip_Goods_Show" %>
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
            $("#pHistory ul").promptumenu({ width: _width, height: _height, rows: 1, columns: 1, direction: 'horizontal', pages: true });
            /*左右切换*/
            $(".pOptions ul li").click(function () {
                var _this = $(this);
                if (_this.attr("class") != "select") {
                    _this.addClass("select");
                    _this.siblings().removeClass("select");
                }
                $("#" + _this.attr("tab")).siblings().hide();
                $("#" + _this.attr("tab")).fadeIn();
            });
        });

        function getmsg(_id, _wwx) {
            $.ajax({
                async: true,
                cache: false,
                global: true,
                timeout: 120000,
                contentType: 'application/x-www-form-urlencoded',
                type: 'POST',
                url: "getmsg.ashx",
                dataType: 'text',
                data: { "guid": _id, "qnt": 1, "wwx": _wwx },
                success: function (data) {
                    if (data != "") {
                        $("#control_count").html(data);
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="pbody">
        <div class="pOptions">
            <ul id="tabs">
                <li class="licolor" tab="pToday"><a>今日</a></li>
                <li tab="pHistory"><a>历史</a></li>
            </ul>
        </div>
        <div class="pContent">
            <div id="pToday" class="selected">
                <ul>
                    <asp:Literal ID="vip_goods" runat="server"></asp:Literal>
                </ul>
                <div id="control_count" style="margin-top: 250px;">
                </div>
            </div>
            <div id="pHistory" class="displayed">
                <ul>
                    <asp:Literal ID="vip_goods_del" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
    <vip:vipFooter id="vipFooter" runat="server"   EnableViewState="False" />
    </form>
</body>
</html>
