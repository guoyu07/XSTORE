<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settlement.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.settlement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-结算业务</title>
    <link rel="icon" href="img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css"/>
    <link rel="stylesheet" href="../css/settlement.css" />
    
</head>
<body>
    <form id="form1" runat="server" style="height:100%;">
        <ul class="clearfix topic">
            <li class="clickOn">结算</li>
            <li>待结算</li>
            <li>未结算</li>
        </ul>
        <div class="main" style="-webkit-overflow-scrolling: touch;">
            <div class="box box1">
                <div class="interval"></div>
                <dl class="total_money clearfix">
                    <dt class="l">合计</dt>
                    <dd class="r">金额: ¥ <span><%=A_price %></span></dd>
                    <dd class="r">数量: × <span><%=A_sum %></span></dd>
                </dl>
                <table border="1">
                    <tr class="topic">
                        <th>房间</th>
                        <th>产品</th>
                        <th>规格</th>
                        <th>单价</th>
                        <th>数量</th>
                    </tr>
                    <asp:Repeater ID="yestlement" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("库位名") %></td>
                                <td><%#Eval("品名") %></td>
                                <td><%#Eval("规格") %></td>
                                <td>¥ <span><%#Eval("本站价") %></span></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </table>
            </div>
            	<div class="box box2">
				<div class="interval"></div>
				<dl class="total_money clearfix">
					<dt class="l">合计</dt>
                    <dd class="r">金额: ¥ <span><%=wait_price %></span></dd>
                    <dd class="r">数量: × <span><%=wait_sum %></span></dd>
				</dl>
				<table border="1">
				  <tr class="topic">
				    <th>房间</th>
				    <th>产品</th>
				    <th>规格</th>
				    <th>单价</th>
				    <th>数量</th>
				  </tr>
                    <asp:Repeater ID="wait_rp" runat="server">
                        <ItemTemplate>
                                <tr>
                                                   <tr>
                                <td><%#Eval("库位名") %></td>
                                <td><%#Eval("品名") %></td>
                                <td><%#Eval("规格") %></td>
                                <td>¥ <span><%#Eval("本站价") %></span></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>

				</table>
			</div>
            <div class="box box3">
                <div class="interval"></div>
                <dl class="total_money clearfix">
                    <dt class="l">合计</dt>
                    <dd class="r">金额: ¥ <span><%=B_price %></span></dd>
                    <dd class="r">数量: × <span><%=B_sum %></span></dd>
                </dl>
                <table border="1">
                    <tr class="topic">
                        <th>房间</th>
                        <th>产品</th>
                        <th>规格</th>
                        <th>单价</th>
                        <th>数量</th>
                    </tr>
                    <asp:Repeater ID="notlement" runat="server">
                        <ItemTemplate>
                            <tr>
                                                   <tr>
                                <td><%#Eval("库位名") %></td>
                                <td><%#Eval("品名") %></td>
                                <td><%#Eval("规格") %></td>
                                <td>¥ <span><%#Eval("本站价") %></span></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                            </tr>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="settleBtn" style="z-index:11111;">
                    <h3>申 请 结 算</h3>
                    <label id="send_hotel" runat="server" style="display:none;"></label>
                </div>
            </div>
        </div>
   
    </form>
         <script src="../js/plugins/zepto.min.js" type="text/javascript" charset="utf-8"></script>
        <script src="../js/plugins/layer.js"></script>
        <script type="text/javascript">
            $(function () {
                $('.topic li').on('click', function () {
                    $(this).addClass('clickOn').siblings().removeClass('clickOn');
                    var index = $(this).index();
                    $('.box').eq(index).show().siblings().hide();
                })
                $('.settleBtn').on('click', function () {
                    var num = $('#send_hotel').text();
                    $.ajax({
                        url: '../ashx/hotelSend.ashx',
                        data: {
                            hotelId: num
                        },
                        dataType: 'json',
                        success: function (result) {
                            if (result.state == 1) {
                                layer.open({
                                    content: '申请成功',
                                    time: 2,
                                    skin: 'msg'

                                })
                                setTimeout(function () {
                                    window.location.reload();
                                }, 1500)
                            } else {
                                layer.open({
                                    content: '申请失败，请联系客服！',
                                    time: 2,
                                    skin: 'msg'
                                })
                            }
                        }
                    })
                })
            })
		</script>

</body>
</html>
