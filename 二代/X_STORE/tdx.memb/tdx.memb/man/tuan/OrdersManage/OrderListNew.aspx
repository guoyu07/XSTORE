<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderListNew.aspx.cs" Inherits="tdx.memb.man.tuan.OrdersManage.OrderListNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="root61">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GBK">
    <title>我的订单</title>
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="../../css/order/common.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/myjd.order2015.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/basePatch.css" />
    <script src="../../Editor/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../js/order/loadFa.js"></script>
    <script type="text/javascript" src="../../js/order/payOrderList.js"></script>
    <link rel="stylesheet" type="text/css" href="../../css/order/slidebar.css" />
    <script type="text/javascript" src="../../js/order/im_icon_v5.js"></script>
    <script type="text/javascript" src="../../js/order/wl.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../../Shop/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function getmore(obj) {
            var txtpageindex = $("#pageindex").val();
            var txtordertype = $("#ordertype").val();
            var txttype = "TM";
            $.ajax({
                type: "POST", //用POST方式传输
                url: '../../../tools/GetMoreOrderHandler.ashx', //目标地址
                dataType: "json",//需要限定为json
                data: { pageindex: txtpageindex, ordertype: txtordertype, type: txttype },
                success: function (data) {
                    console.log(data.result);
                    if (data.message == "true") {
                        $("#pageindex").val(data.index);
                        $('table.orderinfo').append(data.result);
                        console.log($('table.orderinfo').html())
                    }
                    else {
                        alert(data.message);
                        $(obj).hide();
                    }
                },
                error: function () {
                    alert("异常！");
                }
            })
        }
        function multiprint() {
            var ckorders = $("input.multi:checked");//input类型的标签，带有multi类，并且选中
            debugger;
            console.log(ckorders.length);
            var orderinfo = "{";
            $("input.multi:checked").each(function (i) {
                if (0 == i) {
                    orderinfo += "'" + ($(this).val() + "'" + ":'TM'");
                } else {
                    orderinfo += (",'" + $(this).val() + "':'TM'");
                }
            });
            //for(var i=0;i<ckorders.length;i++)
            //{
            //    if (i == 0)
            //        orderinfo += (ckorders[i].val() + ":WP");
            //    else
            //        orderinfo += (',' + ckorders[i].val() + ":WP");//ckorders[i]不认识
            //}
            orderinfo += "}";
            debugger;
            console.log(orderinfo);
            document.cookie = "OrderInfo=" + orderinfo;//设置cookie值，在目标页面取得
            location.href = "../../PrintSheet/ShowPrintInfo.aspx?printType=Multi&OrderInfo=" + orderinfo + "";
        }
    </script>
    <style type="text/css">
        .pop-box {
            z-index: 9999; /*这个数值要足够大，才能够显示在最上层*/
            margin-bottom: 3px;
            display: none;
            position: absolute;
            background: #FFF;
            border: solid 1px #6e8bde;
        }

            .pop-box h4 {
                color: #FFF;
                cursor: default;
                height: 18px;
                font-size: 14px;
                font-weight: bold;
                text-align: left;
                padding-left: 8px;
                padding-top: 4px;
                padding-bottom: 2px;
                background: url("../images/header_bg.gif") repeat-x 0 0;
            }

        .pop-box-body {
            clear: both;
            margin: 4px;
            padding: 2px;
        }


        .mask {
            color: #C7EDCC;
            background-color: #C7EDCC;
            position: absolute;
            top: 0px;
            left: 0px;
            filter: Alpha(Opacity=60);
        }
    </style>

    <script type="text/javascript">
        function popupDiv(div_id, obj) {
            var div_obj = $("#" + div_id);
            $("#orderid").val($(obj).parent().find(".bianhao").val());
            $("#orderid1").val($(obj).parent().find(".bianhao").val());
            $("#yunfei").val($(obj).parent().find(".yunfei").val());
            $("#yingfu").val($(obj).parent().find(".yingfu").val());
            $("#txt运费").val($("#yunfei").val());
            $("#txt应付款").val($("#yingfu").val());
            $("#Text3").val($(obj).attr("gs"));
            $("#Text4").val($(obj).attr("dh"));
            console.log("#txt运费 is " + $("#txt运费").val());
            console.log("#txt应付款 is " + $("#txt应付款").val());
            console.log("#orderid is " + $("#orderid").val());
            debugger;

            var windowWidth = window.screen.width;//document.body.clientWidth;
            var windowHeight = window.screen.height;//document.body.clientHeight;
            var popupHeight = div_obj.height();
            var popupWidth = div_obj.width();
            div_obj.css({ "position": "fixed" })
                   .animate({
                       right: windowWidth / 2 - popupWidth / 2,
                       bottom: windowHeight / 2 - popupHeight / 2, opacity: "show"
                   }, "fast");

        }
        function hideDiv(div_id, obj) {
            $("#mask").remove();
            $("#" + div_id).animate({ right: 0, bottom: 0, opacity: "hide" }, "slow");
            var text = $(obj).val();
            if (text == "确定") {
                var orderNo = $(obj).next().val();
                var txtdanhao = $('#txt运单号').val();
                var txtgongsi = $('#txt货运公司').val();
                console.log("订单号：" + orderNo);
                console.log("运单号：" + txtdanhao);
                console.log("货运公司：" + txtgongsi);
                debugger;
                $.ajax({
                    type: "post",
                    datatype: "text",
                    url: "../../../tools/WuLiuHandler.ashx",
                    data: { ordernum: orderNo, danhao: txtdanhao, gongsi: txtgongsi, ordertype: "TM" },
                    async: false,
                    success: function (data) {
                        if (data = "true") {
                            alert("操作成功!");
                            location.reload();
                        }
                        else
                            alert("操作失败");
                    }
                });
            }

        }
        function hideDivYun(div_id, obj) {
            $("#" + div_id).animate({ right: 0, bottom: 0, opacity: "hide" }, "slow");
            var text = $(obj).val();
            if (text == "保存") {
                var orderNo = $("#orderid").val();
                var txtyunfei = $('#txt运费').val();
                var txtyingfunew = $("#txt应付款").val();
                var txtyingfuold = $("#yingfu").val();
                var txtquanxian = $('#txt权限').val();

                console.log("订单号：" + orderNo);
                console.log("运费：" + txtyunfei);

                debugger;
                $.ajax({
                    type: "post",
                    datatype: "text",
                    url: "../../../tools/YunFeiHandler.ashx",
                    data: { ordernum: orderNo, yunfei: txtyunfei, yingfuold: txtyingfuold, yingfunew: txtyingfunew, ordertype: "TM", quanxian: txtquanxian },
                    async: false,
                    success: function (data) {
                        debugger;
                        console.log(data);
                        if (data == "true") {
                            alert("操作成功!");
                            location.reload();
                        }
                        else
                            alert("操作失败");
                    }
                });
            }
        }


        function hideDiv1(div_id, obj) {
            $("#mask").remove();
            $("#" + div_id).animate({ right: 0, bottom: 0, opacity: "hide" }, "slow");

        }

        function hideDiv2(div_id, obj) {
            $("#mask").remove();
            $("#" + div_id).animate({ right: 0, bottom: 0, opacity: "hide" }, "slow");
            var text = $(obj).val();
            if (text == "确定") {
                var orderNo = $(obj).next().val();
                var txtdanhao = $('#Text4').val();
                var txtgongsi = $('#Text3').val();
                console.log("订单号：" + orderNo);
                console.log("运单号：" + txtdanhao);
                console.log("货运公司：" + txtgongsi);
                debugger;
                $.ajax({
                    type: "post",
                    datatype: "text",
                    url: "../../../tools/WuLiuHandler1.ashx",
                    data: { ordernum: orderNo, danhao: txtdanhao, gongsi: txtgongsi, ordertype: "TM" },
                    async: false,
                    success: function (data) {
                        if (data = "true") {
                            alert("操作成功!");
                            location.reload();
                        }
                        else
                            alert("操作失败");
                    }
                });
            }

        }

        //申请退款
        function tuikuan(orderno) {
            if (confirm('确认此笔订单进行退款吗？')) {
                $.ajax({
                    type: "post",
                    datatype: "text",
                    url: "tuikuan.ashx",
                    data: { orderno: orderno },
                    async: false,
                    success: function (data) {
                        alert(data);
                        location.reload();
                    }
                });
            }

        }

    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>订单管理</span>
            <i class="arrow"></i>
            <span>订单列表</span>
        </div>

        <asp:HiddenField ID="ordertype" runat="server" />
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">下单人</span>&nbsp;<asp:TextBox ID="txt_下单人" runat="server" CssClass="input" /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">订单号</span>&nbsp;<asp:TextBox ID="txt_订单号" runat="server" CssClass="input" /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">开始时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_start" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">结束时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_end" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>
                        <%--          <li><asp:LinkButton ID="btnPtint" runat="server" CssClass="btn" OnClick="btnPtint_Click">批量打印</asp:LinkButton></li>--%>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbtn_Export" runat="server" CssClass="btn" OnClick="lbtn_Export_Click"><span>订单信息导出</span></asp:LinkButton></li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbtn_ExpsortSum" runat="server" CssClass="btn" OnClick="lbtn_ExpsortSum_Click"><span>订单管理导出</span></asp:LinkButton></li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<a id="LinkButton3" class="btn" onclick="multiprint()"><span>订单批量打印</span></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="mod-main mod-comm lefta-box" id="order02" runat="server">
            <div class="mt">
                <ul class="extra-l">
                    <li class="fore1"><a href='<%=currenturl %>' class="txt" id="orderAll" onclick="changetab(this)">全部订单<span class="number">(<%=all %>)</span></a></li>
                    <li><a href='<%=currenturl+"?ordertype=未支付" %>' id="ordertoPay" onclick="changetab(this)" clstag="click|keycount|orderinfo|waitPay" class="txt">待付款<span class="number">(<%=topay %>)</span></a></li>
                    <li><a href='<%=currenturl+"?ordertype=已支付" %>' id="ordertoReceive" onclick="changetab(this)" clstag="click|keycount|orderinfo|waitReceive" class="txt">待发货<span class="number">(<%=tosend %>)</span></a></li>
                    <li><a href='<%=currenturl+"?ordertype=已发货" %>' id="orderto已发货" onclick="changetab(this)" clstag="click|keycount|orderinfo|waitReceive" class="txt">已发货<span class="number">(<%=hadsend %>)</span></a></li>
                    <li><a href='<%=currenturl+"?ordertype=已完成" %>' id="orderto已完成" onclick="changetab(this)" clstag="click|keycount|orderinfo|waitReceive" class="txt">已完成<span class="number">(<%=finish %></span>)</a></li>
                    <li><a href='<%=currenturl+"?ordertype=已取消" %>' id="ordertoCancel" onclick="changetab(this)" clstag="click|keycount|orderinfo|waitReceive" class="txt">已取消<span class="number">(<%=cancel %>)</span></a></li>

                    <li><a href='<%=currenturl+"?ordertype=退款中" %>' id="orderto待退款" onclick="changetab(this)" clstag="click|keycount|orderinfo|waitReceive" class="txt">待退款<span class="number">(<%=daituikuan %>)</span></a></li>
                    <li><a href='<%=currenturl+"?ordertype=退款成功" %>' id="orderto退款完成" onclick="changetab(this)" clstag="click|keycount|orderinfo|waitReceive" class="txt">退款成功<span class="number">(<%=tuikuanwancheng %>)</span></a></li>
                    <%--                    <li><a href='<%=currenturl+"?ordertype=退款失败" %>' id="orderto退款失败" onclick="changetab(this)" clstag="click|keycount|orderinfo|waitReceive" class="txt">退款失败<span class="number">(<%=tuikuanshibai %>)</span></a></li>--%>
                </ul>
            </div>
            <div class="mc">
                <table class="td-void order-tb orderinfo">
                    <thead>
                        <tr>
                            <th>选择</th>
                            <th>
                                <div class="ordertime-cont">
                                    <div class="time-txt">订单<b></b><span class="blank"></span></div>
                                    <div class="time-list">
                                        <ul>
                                            <li><a href="#" _val="1&amp;s=4096" clstag="click|keycount|orderlist|zuijinsangeyue" class="curr"><b></b>近三个月订单</a></li>
                                            <li><a href="#" _val="2&amp;s=4096" clstag="click|keycount|orderlist|jinniannei"><b></b>今年内订单</a></li>
                                            <li><a href="#" _val="2015&amp;s=4096" clstag="click|keycount|orderlist|2015"><b></b>2015年订单</a></li>
                                            <li><a href="#" _val="2014&amp;s=4096" clstag="click|keycount|orderlist|2014"><b></b>2014年订单</a></li>
                                            <li><a href="#" _val="2013&amp;s=4096" clstag="click|keycount|orderlist|2013"><b></b>2013年订单</a></li>
                                            <li><a href="#" _val="3&amp;s=4096" clstag="click|keycount|orderlist|before_2013"><b></b>2013年以前订单</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="order-detail-txt ac">订单详情</div>
                            </th>
                            <th>收货人</th>
                            <th>金额</th>
                            <th>
                                <div class="deal-state-cont" id="orderState">
                                    <div class="state-txt">状态<b></b><span class="blank"></span></div>
                                    <div class="state-list">
                                        <ul>
                                            <li value="4096"><a href="#" clstag="click|keycount|orderlist|quanbuzhuangtai" class="curr"><b></b>全部状态</a> </li>
                                            <li value="1"><a href="#" clstag="click|keycount|orderlist|dengdaifukuan"><b></b>等待付款</a> </li>
                                            <li value="128" clstag="click|keycount|orderlist|dengdaishouhuo"><a href="#"><b></b>等待收货</a> </li>
                                            <li value="1024"><a href="#" clstag="click|keycount|orderlist|yiwancheng"><b></b>已完成</a> </li>
                                            <li value="-1"><a href="#" clstag="click|keycount|orderlist|yiquxiao"><b></b>已取消</a> </li>
                                        </ul>
                                    </div>
                                </div>
                            </th>
                            <%--     <th>操作</th>--%>
                        </tr>
                    </thead>
                    <asp:Literal ID="orderinfo" runat="server"></asp:Literal>
                </table>
                <%--<input id="pageindex" type="hidden" value="2" />
                <div style="text-align: center;"><span onclick="getmore(this)">加载更多</span> </div>--%>
                <%-- 分页2015.6.25 --%>
                <div class="tdh">
                    <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
                    <div class="page">
                        <asp:Literal ID="lt_pagearrow" runat="server"></asp:Literal>
                    </div>
                </div>
                <%-- 分页2015.6.25 --%>
            </div>
        </div>
        <script type="text/javascript">
            var type = $("#ordertype").val();
            $("#orderAll").removeClass("curr");
            $("#ordertoPay").removeClass("curr");
            $("#ordertoReceive").removeClass("curr");
            $("#ordertoCancel").removeClass("curr");
            $("#orderto已发货").removeClass("curr");
            $("#orderto已完成").removeClass("curr");

            $("#orderto待退款").removeClass("curr");
            $("#orderto退款完成").removeClass("curr");
            //$("#orderto退款失败").removeClass("curr");

            if (type == "退款中") {
                $("#orderto待退款").addClass("curr");
                //$("#ordertoReceive").parent().parent().find("span").hide();
                //$("#ordertoReceive").parent().find("span").show();
            }

            if (type == "退款成功") {
                $("#orderto退款完成").addClass("curr");
                //$("#ordertoReceive").parent().parent().find("span").hide();
                //$("#ordertoReceive").parent().find("span").show();
            }

            //if (type == "退款失败") {
            //    $("#orderto退款失败").addClass("curr");
            //    //$("#ordertoReceive").parent().parent().find("span").hide();
            //    //$("#ordertoReceive").parent().find("span").show();
            //}

            if (type == "已支付") {
                $("#ordertoReceive").addClass("curr");
                //$("#ordertoReceive").parent().parent().find("span").hide();
                //$("#ordertoReceive").parent().find("span").show();
            }
            if (type == "未支付") {
                $("#ordertoPay").addClass("curr");
                //$("#ordertoPay").parent().parent().find("span").hide();
                //$("#ordertoPay").parent().find("span").show();
            }
            if (type == "已取消") {
                $("#ordertoCancel").addClass("curr");
                //$("#ordertoCancel").parent().parent().find("span").hide();
                //$("#ordertoCancel").parent().find("span").show();
            }
            if (type == "已发货") {
                $("#orderto已发货").addClass("curr");
                //$("#orderto已发货").parent().parent().find("span").hide();
                //$("#orderto已发货").parent().find("span").show();
            }
            if (type == "已完成") {
                $("#orderto已完成").addClass("curr");
                //$("#orderto已完成").parent().parent().find("span").hide();
                //$("#orderto已完成").parent().find("span").show();

            }
            if (type == "") {
                $("#orderAll").addClass("curr");
                //$("#orderAll").parent().parent().find("span").hide();
                //$("#orderAll").parent().find("span").show();
            }
        </script>
        <!--弹出层-->
        <div class="tab-content">
            <div id='pop-div' style="width: 450px;" class="pop-box">
                <h4>标题位置</h4>
                <div class="pop-box-body">
                    <dl>
                        <dt><span>快递：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="txt货运公司" /></dd>
                    </dl>
                    <dl>
                        <dt><span>运单号：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="txt运单号" /></dd>
                    </dl>
                    <dl>
                        <dt>
                            <input id="btnconfirm" runat="server" type="button" onclick="hideDiv('pop-div', this);" value="确定" />
                            <input id="orderid" type='hidden' value='' />
                            <input id="yunfei" type='hidden' value='' />
                            <input id="yingfu" type='hidden' value='' />
                        </dt>
                        <dd>
                            <input id="btnClose" type="button" onclick="hideDiv('pop-div', this);" value="取消" /></dd>
                    </dl>
                </div>
            </div>
        </div>
        <!--弹出层-->
        <div class="tab-content">
            <div id='popyunfei' style="width: 450px;" class="pop-box">
                <h4>标题位置</h4>
                <div class="pop-box-body">
                    <dl>
                        <dt><span>操作权限号：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="txt权限" /></dd>
                    </dl>
                    <dl>
                        <dt><span>运费：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="txt运费" /></dd>
                    </dl>
                    <dl>
                        <dt><span>应付款：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="txt应付款" /></dd>
                    </dl>
                    <dl>
                        <dt>
                            <input id="btnOK" type="button" onclick="hideDivYun('popyunfei', this);" value="保存" /></dt>
                        <dd>
                            <input id="btnCancel" type="button" onclick="hideDiv('popyunfei', this);" value="取消" /></dd>
                    </dl>
                </div>
            </div>
        </div>

        <!--弹出层 物流信息查看-->
        <div class="tab-content">
            <div id='pop-wuliu' style="width: 450px;" class="pop-box">
                <h4>标题位置</h4>
                <div class="pop-box-body">
                    <dl>
                        <dt><span>快递：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="Text1" /></dd>
                    </dl>
                    <dl>
                        <dt><span>运单号：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="Text2" /></dd>
                    </dl>
                    <dl>
                        <dd>
                            <input id="btnClose" type="button" onclick="hideDiv1('pop-wuliu', this);" value="确定" /></dd>
                    </dl>
                </div>
            </div>
        </div>

        <!--弹出层 物流信息修改-->
        <div class="tab-content" style="position: relative">
            <div id='pop-div1' style="width: 450px;" class="pop-box">
                <h4>标题位置</h4>
                <div class="pop-box-body">
                    <dl>
                        <dt><span>快递：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="Text3" /></dd>
                    </dl>
                    <dl>
                        <dt><span>运单号：</span></dt>
                        <dd>
                            <input type="text" runat="server" id="Text4" /></dd>
                    </dl>

                    <dl>
                        <dt>
                            <input id="btnconfirm1" runat="server" type="button" onclick="hideDiv2('pop-div1', this);" value="确定" />
                            <input id="orderid1" type='hidden' value='' />
                            <input id="yunfei1" type='hidden' value='' />
                            <input id="yingfu1" type='hidden' value='' />
                        </dt>
                        <dd>
                            <input id="btnClose1" type="button" onclick="hideDiv2('pop-div1', this);" value="取消" /></dd>
                    </dl>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
