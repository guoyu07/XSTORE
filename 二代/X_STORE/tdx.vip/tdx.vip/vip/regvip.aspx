<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regvip.aspx.cs" Inherits="tdx.vip.regvip" %>

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
            $(".regToReg").click(function () {
                //$(".regReg").height($(".regIntroduction").height());
                $(".regReg").width($(".regIntroduction").width());
                $(".regReg").offset({ top: $(".regIntroduction").offset().top });
                $(".regIntroduction").hide();
                $(".regReg").css("left", "0");
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="regBody">
        <div class="regVipCardBody">
            <div class="regVipCard">
                <img  src="image/bgVIPCard.png" /><div class="regVIPCardLogo">
                    <img alt="LOGO" src="image/bgVIPCard.png" /></div>
                <span runat="server" id="peopleCount">已有：11111人领取会员卡</span></div>
        </div>
        <div class="regIntroduction">
            <div class="regToReg">
                立即领取会员卡
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
        <div class="regReg" id="regReg">
            <div class="regPerfectInfo">
                完善您的资料
            </div>
            <ul>
                <li><span>姓名：</span><input type="text" enableviewstate="false" id="M_name" runat="server" /></li>
                <li><span>手机：</span><input type="text" enableviewstate="false"  id="M_mobile" runat="server" /></li>
                <li><span>QQ：</span><input type="text" enableviewstate="false"  id="M_QQ" runat="server" /></li>
                <li><span>微信号：</span><input type="text" enableviewstate="false"  id="M_wx" runat="server" /></li>
                <li><span>&nbsp;</span><input type="button" value="提交" runat="server" onserverclick="btn_Submit" />
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
