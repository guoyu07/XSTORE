﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCenter.aspx.cs" Inherits="XStore.WebSite.WebSite.Center.ManageCenter" %>

<%@ Register Src="~/WebSite/_Ascx/MangeCenterFooter.ascx" TagPrefix="uc" TagName="Footer" %>
<%@ Import Namespace="XStore.Entity" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no" />
    <title><%:Title %></title>
    <link rel="icon" href="/Content/Icon/logo.png" type="image/x-icon" />
    <link href="/Content/fonts/iconfont.css" rel="stylesheet" />
    <%: System.Web.Optimization.Styles.Render("~/bundles/CommonStyle","~/bundles/managecenter/css")%>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/CommonJs")%>
    <script type="text/javascript">
        $(function () {
            pushHistory();
            var bool = false;
            setTimeout(function () {
                bool = true;
            }, 1500);
            window.addEventListener("popstate", function (e) {
                if (bool) {
                    window.location.reload();
                }
                pushHistory();

            }, false);

        });
        function pushHistory() {
            var state = {
                title: "title",
                url: "#"
            };
            window.history.pushState(state, "title", "#");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div class="clearfix personalInfo">
                <img class="headPortrait l" src="<%=wxUserInfo.headpic.ObjToStr() %>" />
                <div class="positinInfo l clearfix">
                    <div class="market l">
                        <p class="name"><%=userInfo.realname%></p>
                        <p class="job">酒店经理</p>
                    </div>
                    <p class="area l over2"><%=hotelInfo.hotel_name %></p>
                </div>
                <div class="headBottom clearfix">
                    <p class="status l"><a class="<%=manageQuery.lightColor %>" style="color: #ffffff;"><%=manageQuery.salesLight %></a></p>
                    <div class="clearfix headBottoml">
                        <p class="account l"><%=userInfo.phone %></p>
                        <p class="assets l">信托资产:<%=manageQuery.trustAssets %></p>
                    </div>
                </div>
            </div>
            <div class="interval"></div>

            <div class="bodymenu">
                <ul>
                    <li class="comprehensive">
                        <a href="Manager/BaseInfoCenter.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-e617"></i>
                                <span>基础信息</span>
                            </div>
                            <div class="r"><b class="iconfont icon-gengduo"></b></div>
                        </a>
                    </li>
                    <li class="comprehensive">
                        <a href="employeeManager.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-e617"></i>
                                <span>人员管理</span>
                            </div>
                            <div class="r"><b class="iconfont icon-gengduo"></b></div>
                        </a>
                    </li>
                    <li class="achievement">
                        <a href="achievement.aspx?0&hotelid=<%=hotelInfo.id %>" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-yeji"></i>
                                <span>销售业绩</span>
                            </div>
                            <div class="r"><b class="iconfont icon-gengduo"></b></div>
                        </a>
                    </li>
                    <li class="settlement">
                        <a href="settlement.aspx?0&hotelid=<%=hotelInfo.id %>" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-jiesuan"></i>
                                <span>业绩查询</span>
                            </div>
                            <div class="r"><b class="iconfont icon-gengduo"></b></div>
                        </a>
                    </li>

                    <li class="deal">
                        <a href="../Distributer/roomSatus.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-yewu"></i>
                                <span>开箱检查</span>
                            </div>
                            <div class="r"><b class="iconfont icon-gengduo"></b></div>
                        </a>
                    </li>
                    <li class="deal">
                        <a href="../Distributer/roomSelect.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-yewu"></i>
                                <span>常规补货</span>
                            </div>
                            <div class="r"><b class="iconfont icon-gengduo"></b></div>
                        </a>
                    </li>
                    <li class="deal" runat="server" id="changeHotel">
                        <a href="../pages/areaManage.aspx" class="clearfix">
                            <div class="l">
                                <i class="iconfont icon-yewu"></i>
                                <span>酒店切换</span>
                            </div>
                            <div class="r"><b class="iconfont icon-gengduo"></b></div>
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
       
        <div class="footer_bar openwebview">
            <uc:Footer ID="UserFooter" runat="server" EnableViewState="False"></uc:Footer>
        </div>
    </form>
    <script>
        $(function () {
            $("#foot li").removeClass("clickOn");
            $("#foot li").eq(0).addClass("clickOn");
            $('.cancellation').on('click', function () {
                layer.open({
                    content: '是否注销？',
                    btn: ['确定', '取消'],
                    yes: function (index) {
                        $.ajax({
                            url: '<%=Constant.ApiDic%>' + 'UnBindAccount.ashx',
                            type: 'GET',
                            dataType: 'JSON',
                            success: function (response) {
                                if (response.success) {
                                    system_alert(response.message)
                                    window.location.href = '<%=Constant.JsLoginDic%>' + "Login.aspx";
                                    } else {
                                        system_alert(response.message);
                                    }
                                }
                        })
                    }
                })
            })
        })

    </script>
</body>
</html>
