<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="redeem.aspx.cs" Inherits="tdx.vip.redeem" %>
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
    <title>积分兑换</title>
    <link href="css/comm.css" rel="stylesheet" type="text/css" />
    <link href="css/redeem.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rbody">
        <div class="rOptions">
            <ul>
                <li class="select" state="0" id="ongoing"><a>正在：</a><asp:Literal ID="nowNum" runat="server"></asp:Literal></li>
                <li state="1" id="completed"><a>已换：</a><asp:Literal ID="readNum" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="rContent">
            <asp:Literal ID="JiFenGoods" runat="server"></asp:Literal>
        </div>
    </div>
    <vip:vipFooter id="vipFooter" runat="server"   EnableViewState="False" />
    <input type="text" id="iwid" value="0" runat="server" style="display: none" />
    <input type="text" id="iwwx" value="0" runat="server" style="display: none" />
    <input type="text" id="iwwv" value="0" runat="server" style="display: none" />
    </form>
    <script type="text/javascript">
        $(function () {
            //点击正在
            $("#ongoing").click(function () {
                var _this = $(this);
                //如果已经选中则不生效
                if (_this.attr("class") != "select") {
                    _this.addClass("select");
                    _this.siblings().removeClass("select");
                    $.post("redeemAjax.ashx", { wid: $("#iwid").val(), wwv: $("#iwwv").val(), type: _this.attr("state") }, function (data) {
                        $(".rContent").html(data);
                    });
                }
            });
            //点击已经进行
            $("#completed").click(function () {
                var _this = $(this);
                //如果是已经选中则不生效
                if (_this.attr("class") != "select") {
                    _this.addClass("select");
                    _this.siblings().removeClass("select");
                    $.post("redeemAjax.ashx", { wid: $("#iwid").val(), wwv: $("#iwwv").val(), type: _this.attr("state") }, function (data) {
                        $(".rContent").html(data);
                    });
                }
            });

            $(".gocart").click(function () {
                $.post("redeemGoCart.ashx", { wwx: $("#iwwx").val(), wwv: $("#iwwv").val(), gid: $(this).attr("idnum") }, function (data) {
                alert(data)
                    location.href = data;
                });
            });
        })
    </script>
</body>
</html>
