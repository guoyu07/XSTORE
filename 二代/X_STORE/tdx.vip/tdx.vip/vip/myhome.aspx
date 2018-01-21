<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myhome.aspx.cs" Inherits="tdx.vip.myhome" %>

<%@ Register Src="vipFooter.ascx" TagPrefix="vip" TagName="vipFooter" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"
        name="viewport">
    <meta content="default" name="apple-mobile-web-app-status-bar-style">
    <meta content="yes" name="apple-mobile-web-app-capable">
    <link href="css/comm.css" rel="stylesheet" type="text/css" />
    <link href="css/myhome.css" rel="stylesheet" type="text/css" />
    <link href="css/regvip.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var _contentHeight = new Array();
            $(".regListContent").each(function (i) {
                _contentHeight[i] = $(this).height();
                if (i > 0) {
                    $(this).height(0);
                }
                else {
                    $(this).height(_contentHeight[i]);
                }
            });
            $(".regListTitle").click(function () {
                var _title = $(this);
                $(".regListContent").each(function (i) {
                    var _content = $(this);
                    if (_content.prev()[0] == _title[0]) {
                        if (_content.height() == 0) {
                            _content.height(_contentHeight[i]);
                        }
                        else {
                            _content.height(0);
                        }
                    }
                    else {
                        _content.height(0);
                    }
                });
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mhBody">
        <div class="mhVipCardBody">
            <div class="mhVipCard">
                <img src="image/bgVIPCard.png" runat="server" id="img1" /><div class="mhVIPCardLogo">
                    <img alt="LOGO" src="" runat="server" id="imgHead" /></div>
                <h1>
                    <asp:Literal ID="cardRanfo" runat="server"></asp:Literal></h1>
                <span class="mhVIPName">
                    <asp:Literal ID="cardSh" runat="server"></asp:Literal></span><span class="mhVIPNum"><asp:Literal
                        ID="bianhao" runat="server"></asp:Literal></span></div>
        </div>
        <div class="mhNum">
            <ul>
                <li>
                    <asp:Literal ID="moneyHave" runat="server"></asp:Literal></li>
                <li>
                    <asp:Literal ID="jifenHave" runat="server"></asp:Literal></li>
                <li><a><span>充值</span></a></li>
            </ul>
        </div>
        <div class="myInfo">
            <div class="myInfoItem">
                <span></span>
                <asp:Literal ID="My_Order" runat="server"></asp:Literal>
            </div>
            <div class="myInfoItem">
                <span></span>
                <asp:Literal ID="My_bill" runat="server"></asp:Literal>
            </div>
            <div class="myInfoItem">
                <span></span>
                <asp:Literal ID="My_convert" runat="server"></asp:Literal>
            </div>
            <div class="myInfoItem">
                <span></span>
                <asp:Literal ID="My_cheap" runat="server"></asp:Literal>
            </div>
            <div class="regListTitle">
                <a>会员卡说明 </a>
            </div>
            <div class="regListContent">
                <asp:Literal ID="cardDes" runat="server"></asp:Literal>
            </div>
            <div class="regListTitle">
                <a>会员卡特权 </a>
            </div>
            <div class="regListContent">
                <asp:Literal ID="cardSpecial" runat="server"></asp:Literal>
            </div>
            <div class="regListTitle">
                <a>会员优惠 </a>
            </div>
            <div class="regListContent">
                <asp:Literal ID="cardCheap" runat="server"></asp:Literal>
            </div>
            <div class="regListTitle">
                <a>积分规则（钱包规则） </a>
            </div>
            <div class="regListContent">
                <asp:Literal ID="cardRule" runat="server"></asp:Literal>
            </div>
            <div class="regListTitle">
                <a>积分兑换 </a>
            </div>
            <div class="regListContent">
                <asp:Literal ID="cardCreditsConvert" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="footer">
        <ul>
            <li><a>
                <img /><span></span></a></li>
            <li><a>
                <img /><span></span></a></li>
            <li><a>
                <img /><span></span></a></li>
            <li><a>
                <img /><span></span></a></li>
        </ul>
    </div>
    <vip:vipFooter ID="vipFooter" runat="server" EnableViewState="False" />
    </form>
</body>
</html>
