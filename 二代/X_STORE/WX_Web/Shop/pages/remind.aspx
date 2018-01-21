<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="remind.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.remind" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
		<title>幸事多私享空间-消息提醒</title>
		<link rel="icon" href="../img/logo.png" type="image/x-icon"/>
		<link rel="stylesheet" href="../css/reset.css" />
		<link rel="stylesheet" href="../css/common.css" />
		<link rel="stylesheet" href="../fonts/iconfont.css">
		<link rel="stylesheet" href="../css/remind.css" />
</head>
<body>
    <form id="form1" runat="server">
		<ul class="clearfix topic">
			<li class="clickOn">前台送货<label><%=QianTai %></label></li>
			<li>房间补货<label><%=FangJian %></label></li>
			<li>酒店收货<label><%=JiuDian %></label></li>
			<li>平台广播<label><%=PingTai %></label></li>
		</ul>
		<div class="interval"></div>
		<div class="main" style="-webkit-overflow-scrolling:touch;">
			<dl class="sale">
				<dt>送货到房</dt>
                <asp:Repeater runat="server" ID="sale_repter">
                    <ItemTemplate>
                        <dd>
					        <a href="javascript:void(0);">
						        <h3>时间：<strong><%#((DateTime)Eval("时间")).ToString("yyyy-MM-dd HH:mm") %></strong></h3>
						        <p>内容：消费者在成功付款之后未能打开货箱，已经发起“送货到房”申请，请送<span><%#Eval("编号") %></span>号<span><%#Eval("品名") %></span>商品，到<span><%#Eval("库位名") %></span>房间；送货时请敲门，确认属实后，在门外，将商品交付给消费者，谢谢。点击本消息，将进入确认页面，确认送货之后，将视同你已完成“送货到房”事宜。服务员收到信息后，需要跟进送货到房间的具体行动。</p>
					        </a>
				        </dd>
                    </ItemTemplate>
                </asp:Repeater>
				<%--<dd>
					<a href="deal.html">
						<h3>时间：<strong>2017-11-11 13:13:13</strong></h3>
						<p>内容：消费者在成功付款之后未能打开货箱，已经发起“送货到房”申请，请送<span>XX</span>号<span>XXX</span>商品，到<span>XXX</span>房间；送货时请敲门，确认属实后，在门外，将商品交付给消费者，谢谢。点击本消息，将进入确认页面，确认送货之后，将视同你已完成“送货到房”事宜。服务员收到信息后，需要跟进送货到房间的具体行动。</p>
					
					</a>
				</dd>
				<dd>
					<a href="deal.html">
						<h3>时间：<strong>2017-11-11 13:13:13</strong></h3>
						<p>内容：消费者在成功付款之后未能打开货箱，已经发起“送货到房”申请，请送<span>XX</span>号<span>XXX</span>商品，到<span>XXX</span>房间；送货时请敲门，确认属实后，在门外，将商品交付给消费者，谢谢。点击本消息，将进入确认页面，确认送货之后，将视同你已完成“送货到房”事宜。服务员收到信息后，需要跟进送货到房间的具体行动。</p>
					</a>
				</dd>--%>
			</dl>
			<dl class="addGoods">
				<dt>日补货提醒</dt>
                <asp:Repeater runat="server" ID="add_goods_repter">
                    <ItemTemplate>
                        <dd>
					        <a href="#">
						        <h3>时间：<strong><%#Eval("date") %></strong></h3>
						        <p>内容：今日有<span><%#GetRoomNum(Eval("date").ObjToStr()) %></span>个房间 <span><%#Eval("productNum") %></span>个商品需要补货！</p>
					        </a>
				        </dd>
                    </ItemTemplate>
                </asp:Repeater>
				
				<%--<dd>
					<h3>时间：<strong>2017-11-11 13:13:13</strong></h3>
					<p>内容：今日有<span>几</span>个房间 <span>几</span>个商品需要补货！</p>
				</dd>
				<dd>
					<h3>时间：<strong>2017-11-11 13:13:13</strong></h3>
					<p>内容：今日有<span>几</span>个房间 <span>几</span>个商品需要补货！</p>
				</dd>
				<dd>
					<h3>时间：<strong>2017-11-11 13:13:13</strong></h3>
					<p>内容：今日有<span>几</span>个房间 <span>几</span>个商品需要补货！</p>
				</dd>--%>
			</dl>
			<dl class="getGoods">
				<dt>收货提醒</dt>
                <asp:Repeater runat="server" ID="get_goods_repter">
                    <ItemTemplate>
                        <dd>
					        <h3>时间：<strong><%#((DateTime)Eval("创建时间")).ToString("yyyy-MM-dd HH:mm") %></strong></h3>
					        <p>内容：<%#Eval("消息内容") %></p>
				        </dd>
                    </ItemTemplate>
                </asp:Repeater>
				<%--<dd>
					<h3>时间：<strong>2017-11-11 13:13:13</strong></h3>
					<p>内容：总部通过<span>XXX</span>【快递公司】向<span>XXX</span>酒店发送了<span>XX</span>号商品<span>XX</span>件,运单号<span>XXXXXXXXX</span>,请查收!</p>
				</dd>
				<dd>
					<h3>时间：<strong>2017-11-11 13:13:13</strong></h3>
					<p>内容：总部通过<span>XXX</span>【快递公司】向<span>XXX</span>酒店发送了<span>XX</span>号商品<span>XX</span>件,运单号<span>XXXXXXXXX</span>,请查收!</p>
				</dd>--%>
			</dl>
			<dl class="broadcast">
				<dt>平台重要信息通知</dt>
                <asp:Repeater runat="server" ID="broadcast_repter">
                    <ItemTemplate>
                       <dd>
					        <h3>时间：<strong><%#((DateTime)Eval("createtime")).ToString("yyyy-MM-dd HH:mm") %></strong></h3>
					        <p>内容：<%#Eval("message") %></p>
				        </dd>
                    </ItemTemplate>
                </asp:Repeater>
			</dl>
		</div>
		<script src="../js/plugins/zepto.min.js"></script>
		<script>
		    $(function () {
		        $('.topic li').on('click', function () {
		            $(this).addClass('clickOn').siblings().removeClass('clickOn');
		            var index = $(this).index();
		            $('dl').eq(index).show().siblings().hide();
		        })
		    })
		</script>
    </form>
</body>
</html>
