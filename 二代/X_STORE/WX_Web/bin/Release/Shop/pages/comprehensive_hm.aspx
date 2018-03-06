<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="comprehensive_hm.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.comprehensive_hm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-基础信息</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
		<link rel="stylesheet" href="../css/reset.css" />
		<link rel="stylesheet" href="../css/common.css" />
		<link rel="stylesheet" href="../fonts/iconfont.css">
		<link rel="stylesheet" href="../css/comprehensive.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="topNav clearfix">
		    <li class="l clickOn">房间</li>
		    <li class="l">商品</li>
		    <li class="l">注册用户</li>
	    </ul>
        <input hidden value="0" id="hiddenButton" />
        <div class="main"  style="-webkit-overflow-scrolling:touch;">
		    <div class="room item">
		        <ul>
                     <asp:Repeater ID="psy_rp" runat="server">
                        <ItemTemplate>
                             <li class="clearfix">
		    		            <a href="">
			    		            <div class="l">
			    			            <p class="roomNumber"><span><%#Eval("库位名") %></span>室</p>
			    		            </div>
                                    <div class="l" style="margin-left:20px;">
                                         <p class="roomNumber"><span>离线:<%#Eval("离线时长")==null?"--":Eval("离线时长").ObjToStr() %> </span>小时</p>
                                    </div>
                                    <div class="l" style="margin-left:20px;">
                                         <p class="roomNumber"><span>上次补货:<%# string.IsNullOrEmpty(Eval("补货时间").ObjToStr())?"--":((DateTime)Eval("补货时间")).ToString("yyyy-MM-dd") %> </span></p>

                                    </div>
			    		            <div class="r status">
                                        <%#GetOnline(Eval("id").ObjToInt(0)) %>
			    		            </div>
		    		            </a>
		    	            </li>
                        </ItemTemplate>
                    </asp:Repeater>
		        </ul>
                <div class="clearfix fixBottom">
		    	    <p class="r">活跃房间数量合计： <span runat="server" id="room_count"></span></p>
		        </div>
	       </div>
             <div class="goods item">
			<ul>
                <asp:Repeater ID="goods_rp" runat="server">
                    <ItemTemplate>
                        <li class="clearfix">
					        <img src='<%#Eval("图片路径") %>' alt="" class="l" />
					        <div class="l rPart">
						        <p class="gInfo">名称：<span><%#Eval("品名") %></span>&nbsp;&nbsp;编码：<span><%#Eval("编码") %></span></p>
						        <p class="gSale">单价：&yen;<span><%#Eval("本站价") %></span>
                                   <%-- &nbsp;&nbsp;销量：×<span><%#Eval("销量") %></span></p>
						        <p class="gStore">房间库存：×<span><%#Eval("房间库存") %></span>--%>
                                       &nbsp;&nbsp;前台库存：×<span><%#Eval("前台库存") %></span></p>
					        </div>
				        </li>
                        <%--<tr>
                            <td>
                                <img src="<%#Eval("图片路径") %>" alt="" /></td>
                            <td><%#Eval("品名") %></td>
                            <td>¥ <span><%#Eval("本站价") %></span></td>
                            <td>× <span><%#Eval("库存数") %></span></td>
                            <td>× <span><%#Eval("出库数") %></span></td>
                        </tr>--%>
                    </ItemTemplate>
                </asp:Repeater>
				
			</ul>
			<div class="clearfix fixBottom">
		    	<p class="r">在售商品数量合计： <span runat="server" id="goods_count"></span></p>
		   </div>
	    </div>
	    <div class="user item">
            <asp:Repeater ID="hm_user_item_rp" runat="server">
                <HeaderTemplate>
                    <table border="1">
			          <tr class="topic">
			  	        <th>账号</th>
			  	        <th>姓名</th>
			            <th>职务</th>
			            <th>手机</th>
			          </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
			  	        <td><%#Eval("用户名") %></td>
			            <td><%#Eval("真实姓名") %></td>
			            <td><%#Eval("角色类型") %></td>
			            <td><%#Eval("手机号") %></td>
			        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        </div>
       
        <%--<div class="main" style="-webkit-overflow-scrolling: touch;">
            <div class="room item">
                <div class="topInputContaienr">
                    <asp:TextBox runat="server" ID="search_rooms" placeholder="请输入房间号" Text="" OnTextChanged="search_rooms_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <ul>
                    <asp:Repeater ID="psy_rp" runat="server">
                        <ItemTemplate>
                            <li class="clearfix">
                                <a href="">
                                    <div class="l">
                                        <p class="roomNumber"><span><%#Eval("库位名") %></span>室</p>
                                        <p>前台：<span><%#Eval("用户名") %></span></p>
                                    </div>
                                    <div class="r">
                                        <p class="num"><%#Eval("数量") %></p>
                                
                                    </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <%--  <div class="distributer item">
            <div class="topInputContaienr" style="display:none;">
                <input type="text" id="" value="" placeholder="请输入姓名"/>
            </div>
            <ul>
                <asp:Repeater ID="qhjd_rp" runat="server">
                    <ItemTemplate>
                        <li class="clearfix">
                            <a href="disRoomList.aspx?ckid=<%#Eval("id") %>">
                                <div class="l iconfont icon-peisongzhong"></div>
                                <div class="l disInfo">
                                    <p class="replenishment"><%#Eval("仓库名") %>补货</p>
                                    <p class="roomSum"><span><%#Eval("总数") %></span>个房间</p>
                                </div>
                                <div class="r num"><%#Eval("数量") %></div>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
            <div class="goods item" style="-webkit-overflow-scrolling: touch;">
                <div class="topInputContaienr">
                    <input id="search_goods" type="text" placeholder="请输入商品名称"></input>
                </div>
                <div class="goods">
                    <table border="1">
                        <thead>
                            <tr class="topic">
                                <th>图片</th>
                                <th>商品</th>
                                <th>单价</th>
                                <th>库存</th>
                                <th>销量</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="goods_rp" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <img src="<%#Eval("图片路径") %>" alt="" /></td>
                                    <td><%#Eval("品名") %></td>
                                    <td>¥ <span><%#Eval("本站价") %></span></td>
                                    <td>× <span><%#Eval("库存数") %></span></td>
                                    <td>× <span><%#Eval("出库数") %></span></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
            <div class="user item">
                <ul>
                   
                                    <asp:Repeater ID="hm_user_item_rp" runat="server">
                                        <ItemTemplate>
                                            <li class="clearfix">
					<h1 class="l">酒店<%#Eval("角色类型") %></h1>
					<h2 class="r"><%#Eval("真实姓名") %></h2>
		    	</li>

                                        </ItemTemplate>
                                    </asp:Repeater>

                </ul>
            </div>

        </div>--%>
        <script src="../js/jquery-1.7.2.min.js"></script>
        <script src="../js/comprehensive_hm.js"></script>
    </form>
</body>
</html>
