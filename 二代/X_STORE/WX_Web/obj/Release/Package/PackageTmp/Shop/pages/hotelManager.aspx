<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotelManager.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.hotelManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
		<title>幸事多私享空间-酒店管理系统</title>
		<link rel="icon" href="../img/logo.png" type="image/x-icon"/>
		<link rel="stylesheet" href="../css/reset.css" />
		<link rel="stylesheet" href="../css/common.css" />
		<link rel="stylesheet" href="../fonts/iconfont.css">
    	<link rel="stylesheet" href="../css/hotelManager.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="clearfix personalInfo">
            <img class="headPortrait l" src="../img/qrcode.jpg" />

            <div class="positinInfo l clearfix">
                <div class="market l">
                    <p class="name"><%=hotel_manager %></p>
                    <p class="job">酒店经理</p>
                </div>
                <p class="area l over2"><%=hotel_name %></p>
            </div>
        </div>
        		<div class="interval"></div>

        <ul>
            <li class="comprehensive">
                <a href="comprehensive.aspx?0" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-e617"></i>
                        <span>基础信息</span>
                    </div>
                    <div class="r"><b class="iconfont icon-gengduo"></b></div>
                </a>
            </li>

            			<li class="remind">
				<a href="remind.html" class="clearfix">
					<div class="l">
						<i class="iconfont icon-xiaoxi"></i>
						<span>提醒</span>
					</div>
					<div class="r iconfont icon-gengduo"></div>
				</a>
			</li>

            <li class="achievement">
                <a href="achievement.aspx?0&hotelid=<%=hotel_id %>" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-yeji"></i>
                        <span>销售业绩</span>
                    </div>
                    <div class="r"><b class="iconfont icon-gengduo"></b></div>
                </a>
            </li>
            <li class="settlement">
                <a href="settlement.aspx?0&hotelid=<%=hotel_id %>" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-jiesuan"></i>
                        <span>财务结算</span>
                    </div>
                    <div class="r"><b class="iconfont icon-gengduo"></b></div>
                </a>
            </li>
            <li class="better">
                <a href="better.html?user_id=<%=userId %>" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-gaishan"></i>
                        <span>业绩改善</span>
                    </div>
                    <div class="r"><b class="iconfont icon-gengduo"></b></div>
                </a>
            </li>
<%--            <li class="report">
                <a href="report.aspx?0&hotelid=<%=hotel_id %>" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-baobiao"></i>
                        <span>报表</span>
                    </div>
                    <div class="r"><b class="iconfont icon-gengduo"></b></div>
                </a>
            </li>--%>
            <li class="deal">
                <a href="deal.aspx?0&hotelid=<%=hotel_id %>" class="clearfix">
                    <div class="l">
                        <i class="iconfont icon-yewu"></i>
                        <span>业务处理</span>
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
                        <span>注销</span>
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
            $('.cancellation').on('click',function(){
                layer.open({
                    content:'是否注销？',
                    btn:['确定','取消'],
                    yes:function(index){
                        $.ajax({
                            url: '../ashx/Cancellation.ashx',
                            data: {},
                            type: 'get',
                            dataType:'json',
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
