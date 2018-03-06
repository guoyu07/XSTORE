<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomDetail.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.roomDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link href="../css/distributer.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/roomGoods.css" />
</head>
<body>
    <form id="form2" runat="server">
        <div class="clearfix topTitle">
            <p class="roomNumber">酒店名称：<span><%=room_name %></span></p>
            <p class="distributer">MAC：<span><%=mac %></span></p>
<%--            <p class="distributer">配送员：<span><%=psy_name %></span></p>--%>
        </div>
        <div class="interval"></div>
         <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="mySpace" class="roomDetail">
                <ul class="clearfix" style="margin-bottom:40px;">
                    <asp:Repeater ID="box_rp" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="#">
                                    <div class="pic">
                                        <img src="<%#Eval("图片路径")%>" alt="" />
                                        <p class="goodsName over"><span style="font-weight:bolder"><%#Eval("编码")%>&nbsp;&nbsp;</span><%#Eval("实际商品品名")%></p>
                                    </div>
                                    <div class="price">¥ <span><%#Eval("本站价").ObjToDecimal(0)%></span></div>
                                </a>
                                <p style="display: none"><%#Eval("实际商品id")%></p>
                                <div class="model "  style='<%#link_ul(Eval("实际商品id").ObjToInt(0)) %>'>
                                    <p>暂无商品</p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            <table style=" width:100%;">
                    <tr>
                       
                        <td style=" width:100%;">
                            <div class="btnWrap">
                                <asp:LinkButton runat="server" ID="finishCheck" CssClass="makeSure" OnClick="finish_button_Click">配货完成</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>
                <%-- <table style=" width:100%;">
                    <tr>
                        <td style=" width:45%;">
                            <div class="btnWrap">
                                <asp:LinkButton runat="server" ID="markSure" CssClass="makeSure" OnClick="openBox_ServerClick">补货开箱</asp:LinkButton>

                            </div>
                        </td>
                        <td style=" width:45%;">
                            <div class="btnWrap">
                                <asp:LinkButton runat="server" ID="finishCheck" CssClass="makeSure" OnClick="finish_button_Click">配货完成</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>--%>
                
            </div>
        </div>
    </form>
    <%--<form id="form1" runat="server" style="display:none;">
       <section class="clearfix process">
	    	<dl class="publishProgress clearfix">
				<dd class="step01 l pass">
					<h3 class="icon iconfont icon-peisongzhong"></h3><h4>仓库取货</h4>
				</dd>
				<dt class="progressBar01 l pass">
					<div class="progressCenter"></div>
				</dt>
				<dd class="step02 l pass">
					<h3 class="icon iconfont icon-fangjian"></h3><h4>房间选择</h4>
				</dd>
				<dt class="progressBar02 l pass">
					<div class="progressCenter"></div>
				</dt>
				<dd class="step03 l clearfix pass">
					<h3 class="icon iconfont icon-e617"></h3><h4>精准补货</h4>
				</dd>
			</dl>
		</section>
        <div class="main" id="main" runat="server">
			<dl>
				<dt class="clearfix">
					<div class="lattice l">格子编号</div>
					<div class="identifier l">商品编号</div>
					<div class="goodsName l">商品</div>
					<div class="pic l">图片</div>
				</dt>
                 <asp:Repeater ID="box_rp" runat="server" >
                    <ItemTemplate>
                        <dd class="clearfix">
					        <div class="lid l"><%#Eval("位置") %></div>
					        <div class="idf l"><%#Eval("编号") %></div>
					        <div class="gdn l over"><%#Eval("品名") %></div>
					        <div class="imgWrap l">
						        <img src="<%#Eval("图片路径") %>" alt="" />
					        </div>
				        </dd>
                    </ItemTemplate>
                </asp:Repeater>
			</dl>
			<div class="fnWrap">
                <asp:Button runat="server" ID="finish_button" CssClass="finish" OnClick="finish_button_Click" Text="完成"/>
			</div>
		</div>
        <div id="empty" runat="server" >
            暂无配送任务
        </div>
        <%--<ul class="tips">
            <li class="pickUpSuccess">
                <div class="imgWrap">
                    <img src="../img/success.png" alt="" />
                </div>
                <p>补货成功</p>
                <div class="des">请随手关闭箱门。谢谢！</div>
                <div class="okBtn">
                    <span>OK</span>
                </div>
            </li>
        </ul>       <input id="weizhi_input" type="hidden" runat="server" />
        <input id="goods_input" type="hidden" runat="server" />
        <script src="../js/plugins/zepto.min.js"></script>
        <script src="../js/roomDetail.js"></script>
    </form>--%>
</body>
</html>
