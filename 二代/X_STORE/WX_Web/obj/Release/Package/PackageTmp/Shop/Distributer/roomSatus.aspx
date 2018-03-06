<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomSatus.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.roomSatus" %>

<%@ Register Src="~/Shop/ascx/psyFooter.ascx" TagPrefix="uc" TagName="psyFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/distributer.css" />
    <link rel="stylesheet" href="../css/layer.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多私享空间-开箱检查</title>
    <script src='../js/plugins/zepto.min.js'></script>
    <script src='../js/plugins/vipspa.js'></script>
    <script src="../js/plugins/vipspa-dev.js"></script>
    <script src="../js/modules/roomStatus.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
<%--<script type="text/javascript" src="../js/plugins/jweixin-1.0.0.js"></script>--%>
    <style>
        #form1 {
            width: 100%;
            height: 100%;
        }
     
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="roomStatus">
                <div class="clearfix topTitle">
                    <img src="../img/delivery.png" alt="" class="l" />
                    <div class="disInfo l">
                        <h3 class="over">
                            <asp:Label runat="server"><%=hotel_name %></asp:Label></h3>
                        <p>
                            <asp:Label runat="server"><%=hotel_address %></asp:Label></p>
                    </div>
                </div>
                <div class="interval"></div>
                <ul class="clearfix">
                    <asp:Repeater runat="server" ID="roomsatus_rp">
                        <ItemTemplate>
                            <li class="<%# GetRoomStatus(Eval("id").ObjToInt(0),Eval("箱子MAC").ObjToStr())["class"]%>">
                                <a href="<%# GetRoomStatus(Eval("id").ObjToInt(0),Eval("箱子MAC").ObjToStr())["href"]%>">
                                    <img src="../img/room.png" />
                                    <p class="roomNumber"><%#Eval("库位名") %></p>
                                    <p class="label offLine">离</p>
                                    <%# GetRoomStatus(Eval("id").ObjToInt(0),Eval("箱子MAC").ObjToStr())["icon"]%>

                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div style="display: none;" class="footer_bar openwebview">
            <uc:psyFooter ID="dismyself" runat="server" EnableViewState="False"></uc:psyFooter>
        </div>
        <script>
            var appId = '<%=appId %>';
            var timestamp = '<%=timestamp %>';
            var nonceStr = '<%=noncestr %>';
            var signature = '<%=signature %>';
            wx.config({
                debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: appId, // 必填，公众号的唯一标识
                timestamp: timestamp, // 必填，生成签名的时间戳
                nonceStr: nonceStr, // 必填，生成签名的随机串
                signature: signature,// 必填，签名，见附录1
                jsApiList: ['scanQRCode'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
            });
            wx.ready(function () {
                wx.scanQRCode({
                    needResult: 1,
                    desc: 'scanQRCode desc',
                    success: function (res) {
                        alert(JSON.stringify(res));
                    }
                });
                // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
            });

            wx.error(function (res) {
                //alert("");
            });
            
            $(function () {
                $("a[name='con']").eq(0).addClass("on");
                vipspa.start({
                    view: '#view',//匹配的路由信息 在那个元素显示
                    router: { //路由配置
                        //状态:{templateUrl:'模板地址',controller:'js操作路径' }
                        "roomStatus": {
                            templateUrl: 'views/roomStatus.html',
                            controller: 'js/modules/roomStatus.js'
                        },
                        "pickUp": {
                            templateUrl: 'views/pickUp.html',
                            controller: 'js/modules/pickUp.js'
                        },
                        "disMyself": {
                            templateUrl: 'views/disMyself.html',
                            controller: 'js/modules/disMyself.js'
                        }
                    }
                });
                var hashValue = window.location.hash.substring(1);
                if (hashValue == "undefined") {
                    window.location.hash = 'roomStatus';
                };
            });


    </script>


    </form>
</body>
</html>
