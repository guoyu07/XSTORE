<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Wx_NewWeb.Shop.OperateManager.home" %>

<%@ Register Src="~/Shop/ascx/GeneralManagerFooter.ascx" TagPrefix="uc" TagName="GeneralManagerFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-区域管理系统</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/operateManager.css" />
    <link rel="stylesheet" href="../../style/footer.css" />
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
            <div id="home">
                <div class="clearfix personalInfo">
                    <img class="headPortrait l" src="<%=user_img %>" />
                    <div class="positinInfo l clearfix">
                        <div class="market l">
                            <p class="name" id="user_name_p" runat="server"></p>
                            <p class="job">集团经理</p>
                        </div>
                        <p class="area l over2"><span id="hotel_span" runat="server">无锡市dadoubi</span></p>
                    </div>
                </div>
                <ul>
                    <li class="hotel">
                        <a href="../pages/stockDetail.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-jiudian"></i>
                                <span>酒店</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <li class="stock">
                        <a href="../pages/stockList.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-kucun"></i>
                                <span>商品库存</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <li class="report">
                        <a href="../pages/operateReport.aspx?0" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-iconfontbaobiao"></i>
                                <span>报表</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <li class="achievement">
                        <a href="../pages/operateAchievement.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-baobiao"></i>
                                <span>业绩</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <li class="better">
                        <a href="../pages/Better.html" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-peisong"></i>
                                <span>改善点</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <div class="interval"></div>
                    <li class="changePsd">
                        <a href="../pages/changePsd.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-xiugaimima"></i>
                                <span>修改密码</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <li class="cancellation">
                        <a class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-zhuxiao"></i>
                                <span>注销</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                </ul>
            </div>



        </div>
        <div style="display: block;" class="footer_bar openwebview">
            <uc:GeneralManagerFooter ID="GeneralManagerFooter" runat="server" EnableViewState="False"></uc:GeneralManagerFooter>
        </div>

        <script src="../js/modules/home.js"></script>

        <script src='../js/plugins/zepto.min.js'></script>
        <script src='../js/plugins/vipspa.js'></script>
        <script src="../js/modules/home.js"></script>
        <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
        <script src="../../js/jquery-1.7.2.min.js"></script>

        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(0).addClass("on");

            })
        </script>
        <script>
            $(function () {
                $('.cancellation').on('click', function () {
                    layer.open({
                        content: '是否注销？',
                        btn: ['确定', '取消'],
                        yes: function (index) {
                            $.ajax({
                                url: '../ashx/Cancellation.ashx',
                                data: {},
                                type: 'get',
                                dataType: 'json',
                                success: function (result) {
                                    if (result.state == 1) {
                                        layer.open({
                                            content: result.info,
                                            shadeClose: false,
                                            btn: ['ok'],
                                            yes: function (index) {
                                                layer.close(index);
                                                window.location.href = "login.aspx";
                                            }
                                        })
                                    } else {
                                        layer.open({
                                            content: result.info,
                                            time: 2
                                        })
                                    }
                                }
                            })
                        }
                    })
                })
            })
        </script>
    </form>
</body>
</html>
