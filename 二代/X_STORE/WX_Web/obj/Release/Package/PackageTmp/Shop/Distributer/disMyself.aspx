﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="disMyself.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.disMyself" %>

<%@ Register Src="~/Shop/ascx/psyFooter.ascx" TagPrefix="uc" TagName="psyFooter" %>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/distributer.css" />
    <link rel="stylesheet" href="../css/layer.css" />
    <script src='../js/plugins/zepto.min.js'></script>
    <script src="../js/modules/disMyself.js"></script>
    <link rel="stylesheet" href="../../style/footer.css" />
    <style>
        #form1 {
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form runat="server" id="form1">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="disMyself">
                <div class="clearfix personalInfo">
                    <img class="headPortrait l" src="<%=UserInfo["wx头像"].ObjToStr() %>">
                    <div class="positinInfo l clearfix">
                        <div class="market l">
                            <p class="name"><%=UserInfo["真实姓名"] %></p>
                            <p class="job">酒店服务员</p>
                            <p class="account"><%=UserInfo["手机号"] %></p>
                        </div>
                        <p class="area l over2"><%=HotelInfo["仓库名"] %></p>
                    </div>
                </div>
                <div class="interval"></div>
                <ul>
                    <li class="remind" style="display:none;">
                        <a href="../pages/remind.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-xiaoxi"></i>
                                <span>消息提醒</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <li class="deliveryTask">
                        <a href="../pages/deliveryTask.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-renwu"></i>
                                <span>投放任务</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <li class="deliveryNote">
                        <a href="../pages/deliveryNote.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-jilu"></i>
                                <span>投放记录</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                    <li class="deal" style="display:none;">
                        <a href="../pages/deal.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-yewu"></i>
                                <span>前台送货</span>
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
                                <span>用户注销</span>
                            </div>
                            <div class="r iconfont icon-gengduo"></div>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
 
        <div style="display: block;" class="footer_bar openwebview">
            <uc:psyFooter ID="psyFooter" runat="server" EnableViewState="False"></uc:psyFooter>
        </div>
        <script src="../js/plugins/zepto.min.js"></script>
        <script src="../js/plugins/layer.js"></script>
        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(2).addClass("on");
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
                                                window.location.href = "../pages/login.aspx";
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
