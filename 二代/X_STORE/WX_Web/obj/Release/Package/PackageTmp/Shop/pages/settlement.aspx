<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settlement.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.settlement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-财务结算</title>

    <link rel="icon" href="img/logo.png" type="image/x-icon" />
   
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css"/>
    <link rel="stylesheet" href="../css/settlement.css" />
    <script src="../js/mui.js"></script>
    <link href="../../css/mui.min.css" rel="stylesheet" />
    <link href="../../css/mui.picker.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="height:100%;">
        <div style="text-align: center; margin: auto; margin-top: 5px; ">  <h3 ><%=HotelInfo["仓库名"] %></h3></div>
      
        <table style="width:100%; margin-top:15px; border-bottom: 1px solid #ccc; border-top: 1px solid #cccccc;">
            <tr>
                <td align="center">
                    <div class="startDate " style="padding: 5px;">
                        <%--<span class="">开始时间： <span class="iconfont icon-arrow-right"></span></span>--%>
                        <label runat="server" id="start_date_label">-开始时间-</label>
                    </div>
                </td>
                <td align="center">
                    <div class="endDate " style="padding: 5px;">
        <%--                <span class="">结束时间： <span class="iconfont icon-arrow-right"></span></span>--%>
                        <label  runat="server" id="end_date_label">-结束时间-</label>
                    </div>
                </td>
            </tr>
        </table>
        <div class="main" style="-webkit-overflow-scrolling: touch;">
            <%--<div class="box box1">
                <div class="interval"></div>
                <dl class="total_money clearfix">
                    <dt class="l">合计</dt>
                    <dd class="r">金额: ¥ <span><%=A_price %></span></dd>
                    <dd class="r">数量: × <span><%=A_sum %></span></dd>
                </dl>
                <table border="1">
                    <tr class="topic">
                        <th>商品</th>
                        <th>编码</th>
                        <th>数量</th>
                        <th>金额</th>
                    </tr>
                    <asp:Repeater ID="yestlement" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("品名") %></td>
                                <td><%#Eval("编码") %></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                                <td>¥ <%#Eval("总价") %></td>
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
				    <th>商品</th>
				    <th>编码</th>

				    <th>数量</th>
				    <th>金额</th>
				  </tr>
                    <asp:Repeater ID="wait_rp" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("品名") %></td>
                                <td><%#Eval("编码")%></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                                <td>¥ <%#Eval("总价") %></td>
                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>

				</table>
			</div>--%>
            <div class="box">
                <div class="interval"></div>
                <dl class="total_money clearfix">
                    <dt class="l">合计</dt>
                    <dd class="r">金额: ¥ <span><%=B_price %></span></dd>
                    <dd class="r">数量: × <span><%=B_sum %></span></dd>
                </dl>
                <table border="1">
                    <tr class="topic">
                        <th>商品</th>
                        <th>编码</th>
    
                        <th>数量</th>
                        <th>金额</th>
                    </tr>
                    <asp:Repeater ID="notlement" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("品名") %></td>
                                <td><%#Eval("编码") %></td>
                                <td>× <span><%#Eval("总数") %></span></td>
                                <td>¥ <%#Eval("总价") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <%--<div class="settleBtn" style="z-index:11111;">
                    <h3>申 请 结 算</h3>
                    <label id="send_hotel" runat="server" style="display:none;"></label>
                </div>--%>
            </div>
        </div>
        <div>
            <input type="hidden" id="data_type_input" class="data_type_input" runat="server"/>
        </div>
    </form>
         <script src="../js/plugins/zepto.min.js" type="text/javascript" charset="utf-8"></script>
        <script src="../js/plugins/layer.js"></script>
    <script src="../../js/mui.picker.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('.topic li').on('click', function () {
                    $(this).addClass('clickOn').siblings().removeClass('clickOn');
                    var index = $(this).index();
                    $('.box').eq(index).show().siblings().hide();
                });
                var data_type = $(".data_type_input").val();

                $('.topic li').eq(data_type).click();

                $(".startDate").on('click', function () {
                    var dtpicker = new mui.DtPicker({
                        type: "date",//设置日历初始视图模式 
                        beginDate: new Date(1990, 01, 01),//设置开始日期 
                        endDate: new Date(),//设置结束日期 
                        labels: ['Year', 'Mon', 'Day'],//设置默认标签区域提示语 
                    });
                    dtpicker.show(function (e) {
                        $('.startDate label').text(e.value);
                    });
                });

                $(".endDate").on('click', function () {
                    var dtpicker = new mui.DtPicker({
                        type: "date",//设置日历初始视图模式 
                        beginDate: new Date(1990, 01, 01),//设置开始日期 
                        endDate: new Date(2100, 01, 01),//设置结束日期 
                        labels: ['Year', 'Mon', 'Day'],//设置默认标签区域提示语 
                    });
                    dtpicker.show(function (e) {
                        $('.endDate label').text(e.value);
                        window.location.href = "settlement.aspx?hotelid= "+<%=HotelId%>+"&start_time=" + $('.startDate label').text() + "&end_time=" + e.value + "&data_type=" + $(".clickOn").data("type");
                    });
                });

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
