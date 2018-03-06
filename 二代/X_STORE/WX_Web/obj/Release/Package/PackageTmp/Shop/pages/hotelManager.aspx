<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotelManager.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.hotelManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/hotelManager.css" />
    <link rel="stylesheet" href="../css/layer.css" />
    <script src="../../js/jquery-1.10.2.js"></script>
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
        <div class="clearfix personalInfo">
            <img class="headPortrait l" src="<%=UserInfo["wx头像"] %>" />
            <div class="positinInfo l clearfix">
                <div class="market l">
                    <p class="name"><%=UserInfo["真实姓名"] %></p>
                    <p class="job">酒店经理</p>
                </div>
                <p class="area l over2"><%=HotelInfo["仓库名"] %></p>
            </div>
            <div class="headBottom clearfix">
                <p class="status l"><a class="<%=state %>" style="color:#ffffff;"><%=state_num %></a></p>
                <div class="clearfix headBottoml">
                    <p class="account l"><%=UserInfo["手机号"] %></p>
                    <p class="assets l">信托资产:<%=TotalMoney %></p>
                </div>
            </div>
        </div>
        <div class="interval"></div>

        <ul>
            <li class="remind" style="display:none;">
                <a href="remind.aspx" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-xiaoxi"></i>
                        <span>消息提醒</span>
                    </div>
                    <div class="r iconfont icon-gengduo"></div>
                </a>
            </li>
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
            <li class="achievement" style="display:none;">
                <a href="achievement.aspx?0&hotelid=<%=HotelInfo["id"].ObjToInt(0) %>" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-yeji"></i>
                        <span>销售业绩</span>
                    </div>
                    <div class="r"><b class="iconfont icon-gengduo"></b></div>
                </a>
            </li>
            <li class="settlement" >
                <a href="settlement.aspx?0&hotelid=<%=HotelInfo["id"].ObjToInt(0) %>" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-jiesuan"></i>
                        <span>业绩查询</span>
                    </div>
                    <div class="r"><b class="iconfont icon-gengduo"></b></div>
                </a>
            </li>
            <li class="better" style="display:none;">
                <a href="better.html?user_id=<%=UserId %>" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-gaishan"></i>
                        <span>业绩改善</span>
                    </div>
                    <div class="r"><b class="iconfont icon-gengduo"></b></div>
                </a>
            </li>
            
            <li class="deal" >
				<a href="../Distributer/roomSatus.aspx" class="clearfix">
					<div class="l">
						<i class="iconfont icon-yewu"></i>
						<span>开箱检查</span>
					</div>
					<div class="r"><b class="iconfont icon-gengduo"></b></div>
				</a>
			</li>
            <li class="deal" style="display:none;">
				<a href="../distributer.html#disMyself" class="clearfix">
					<div class="l">
						<i class="iconfont icon-yewu"></i>
						<span>服务入口</span>
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
    </form>
    <script src="../js/plugins/zepto.min.js"></script>
    <script src="../js/plugins/layer.js"></script>
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
</body>
</html>
