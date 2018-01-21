<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OederStatus.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.OrdersManage.OederStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GBK">
    <title>我的订单</title>
    <meta name="format-detection" content="telephone=no">
    <meta http-equiv="Content-Type" content="text/html; charset=GBK">
    <title>我的订单</title>
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="../../css/order/common.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/myjd.order2015.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/basePatch.css" />
    <link rel="stylesheet" type="text/css" href="../../css/order/slidebar.css" />
    <link href="../../css/order/saved_resource3.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/order/loadFa.js"></script>
    <script type="text/javascript" src="../../js/order/payOrderList.js"></script>

    <script type="text/javascript" src="../../js/order/im_icon_v5.js"></script>
    <script type="text/javascript" src="../../js/order/wl.js"></script>
    <%--    <script language="javascript" type="text/javascript">
        if (window.top !== window.self) { window.top.location = window.location; }
    </script>--%>
    <style type="text/css">
        #im, #im s {
            float: left;
            height: 21px;
            line-height: 21px;
            background: url(//misc.360buyimg.com/product/skin/2012/i/im.png) 0 -21px no-repeat;
            text-decoration: none;
            cursor: pointer;
        }

        #im {
            padding-left: 27px;
        }

            #im.im-offline {
                background-position: 0 0;
            }

            #im s {
                background-position: right -42px;
                padding-right: 6px;
            }
    </style>

</head>
<body myjd="_MYJD_ordercenter">
    <div class="w ld" id="toppanel"></div>
    <div id="o-header-2013">
        <div id="header-2013" style="display: none;"></div>
    </div>

    <span id="isYuShouOrder" style="display: none;">false</span>
    <span id="yuShouOrderItemJson" style="display: none;"></span>
    <span id="idCardUpload" style="display: none;">false</span>

    <div class="w">
        <!--变量-->
        <span id="pay-button-order" style="display: none">{"orderId":15294420605,"amount":205.80,"payType":4,"orderType":22,"siteId":2,"idPickSite":0,"orderState":1,"shipmentType":70,"passKey":"27DE7A2D"}</span>
        <!--状态、提示-->
        <style type="text/css">
            .icon-box {
                position: relative;
            }

                .icon-box .warn-icon {
                    background-position: -96px 0;
                }

                .icon-box .m-icon {
                    background: url("//misc.360buyimg.com/myjd/skin/2014/i/icon48.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
                    display: inline-block;
                    height: 48px;
                    left: 0;
                    position: absolute;
                    top: 0;
                    width: 48px;
                }

                .icon-box .item-fore {
                    margin-left: 58px;
                }

            .tip-box .item-fore {
                overflow: hidden;
            }

            .tip-box h3 {
                font-family: "microsoft yahei";
                font-size: 16px;
                line-height: 30px;
            }

            .tip-box .ftx04, .tip-box .ftx-04 {
                color: #FF8A15;
            }

            .tip-box .ftx03, .tip-box .ftx-03 {
                color: #999999;
            }

            .tip-box .op-btns {
                margin-top: 20px;
            }

            .tip-box .btn-9:link, .tip-box .btn-9:visited, .tip-box .btn-10:link, .tip-box .btn-10:visited, .tip-box .btn-11:link, .tip-box .btn-11:visited, .tip-box .btn-12:link, .tip-box .btn-12:visited {
                color: #323333;
                text-decoration: none;
            }

            .tip-box a {
                color: #005EA7;
            }

            .tip-box .btn-9, .tip-box .btn-10, .tip-box .btn-11, .tip-box .btn-12 {
                background-color: #F7F7F7;
                background-image: linear-gradient(to top, #F7F7F7 0px, #F3F2F2 100%);
                border: 1px solid #DDDDDD;
                border-radius: 2px;
                color: #323333;
                display: inline-block;
                height: 18px;
                line-height: 18px;
                padding: 2px 14px 3px;
            }

            .tip-box a {
                color: #005EA7;
            }

            .tip-box .ml10 {
                margin-left: 10px;
            }
        </style>

        <script>
            $ORDER_CONFIG = {};
            $ORDER_CONFIG['toolbarOdoSwitch'] = '1';
        </script>

        <div class="m" id="orderstate">
            <div class="mt">
                <strong>订单号：<%=订单编号%>&nbsp;&nbsp;&nbsp;&nbsp;状态：<span class="ftx14"><%=状态 %></span>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal runat="server" ID="支付时间" />
                </strong>
            </div>
        </div>


        <!--跟踪、付款信息、gis-->
        <div class="m" id="ordertrack">
            <ul class="tab">
                <li clstag="click|keycount|orderinfo|btn_payinfo" class="curr">
                    <h2>付款信息</h2>
                </li>
            </ul>
            <div class="clr"></div>
            <div class="mc tabcon" style="display: none;">
                <!--订单跟踪-->
                <input type="hidden" value="2016-04-13 10:00:46" id="datesubmit-15294420605">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tbody id="tbody_track">
                        <tr>
                            <th width="15%"><strong>处理时间</strong></th>
                            <th width="50%"><strong>处理信息</strong></th>
                            <th width="35%"><strong>操作人</strong></th>
                        </tr>

                    </tbody>
                    <tbody>
                        <tr>
                            <td>2016-04-13 10:00:46</td>
                            <td>您提交了订单，请等待第三方卖家系统确认</td>
                            <td>客户</td>
                        </tr>
                    </tbody>
                </table>

                <div class="extra">
                    <span id="jdshfs">送货方式：普通快递 </span>
                </div>
            </div>


            <div class="mc tabcon hide" style="display: block;">
                <!--付款信息-->
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tbody>
                        <tr>
                            <td width="30%" id="daiFuName">付款方式：在线支付</td>
                            <td width="30%" id="daiFuPeople"></td>
                        </tr>

                        <tr>
                            <!--
订单编号, 总金额, 状态, 收货地址, 手机号, 收货人
                            -->
                            <td>商品金额：￥<%=总金额 %></td>
                            <td>运费金额：￥<%=运费 %></td>
                            <!--添加优惠券-->
                            <td>优惠券：￥<%=优惠券 %></td>
                        </tr>
                        <tr>
                            <td>优惠总金额：￥<%=优惠总金额 %></td>
                            <td>余额：￥<%=余额 %></td>
                        </tr>
                        <tr>
                            <td>应支付金额：￥<%=应付款 %></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
                <div class="tb-ul"></div>
            </div>
            <div class="mc tabcon hide">
                <iframe id="gisFrame" src="" frameborder="0" height="710px" scrolling="no" width="100%"></iframe>
                <div id="gis"><strong>备注：</strong>受天气、gps信号、运营商等各类因素影响，您看到的包裹位置和实际位置有时可能会有一些差别。请您谅解！</div>
            </div>

            <div class="mc tabcon hide" style="display: none;">
                <!--订单跟踪-->
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tbody id="tbody_bigtrack">
                        <tr>
                            <th width="26%"><strong>处理时间</strong></th>
                            <th width="72%"><strong>处理信息</strong></th>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>
        <!--留言-->
        <!--订单信息-->
        <div class="m" id="orderinfo">
            <div class="mt">
                <strong>订单信息</strong>
            </div>
            <div class="mc">
                <!-- 节能补贴信息 -->

                <!--顾客信息-->
                <dl class="fore">
                    <dt>收货人信息</dt>
                    <dd>
                        <ul>
                            <li>收 货 人：<%=收货人 %></li>
                            <li>地　　址：<%=收货地址 %></li>
                            <li>手机号码：<%=手机号 %></li>

                        </ul>
                    </dd>
                </dl>
                <!-- 礼品购订单展示送礼人信息 -->

                <!--配送、支付方式-->
                <dl>
                    <dt>支付及配送方式</dt>
                    <dd>
                        <ul>

                            <li>支付方式：在线支付</li>


                            <li>运　　费：￥<%=运费 %></li>





                        </ul>
                    </dd>
                </dl>

                <!-- 礼品购订单展示寄语信息 -->



                <!--备注-->

                <!--商品-->
                <dl>
                    <dt>
                        <span class="i-mt">商品清单</span>

                        <div id="fquan" class="fquan">
                            <div id="eventName" onmouseover="showCoupon()" onmouseout="hideCoupon()">
                            </div>

                            <div class="prompt p-fquan" id="couponListShow">
                                <div class="pc" id="couponList">
                                </div>
                            </div>
                        </div>

                        <div class="clr"></div>

                    </dt>

                    <dd class="p-list">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <th width="10%">条形码 </th>
                                    <th width="12%">商品图片 </th>
                                    <th width="42%">商品名称(规格) </th>
                                    <th width="10%">本站价 </th>

                                    <th width="7%">商品数量 </th>

                                    <th width="11%">库存状态
                                    </th>
                                </tr>
                                <asp:Literal ID="orderdetail" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </dd>
                </dl>
                <!--条形码-->
                <!-- 商家运费险  -->
                <input type="hidden" id="venderIdListStr" value="27819,27819">

                <div id="yunFeiXian">
                </div>
            </div>
            <!--金额-->
            <div class="total">
                <ul>
                    <li><span>总商品金额：</span>￥<%=总金额 %></li>
                    <li><span>- 优惠总金额：</span>￥<%=优惠总金额 %></li>
                    <li><span>- 余额：</span>￥<%=余额 %></li>
                    <li><span>+ 运费：</span>￥<%=运费 %></li>
                </ul>
                <span class="clr">ad</span> <span style="color: #EDEDED;"></span>
                <div class="extra">
                    应付总额：<span class="ftx04"><b>￥<%=应付款 %></b></span>
                </div>
            </div>
            <!--进度条预计功能使用-->
            <input type="hidden" id="orderStatus" value="1">
            <input type="hidden" id="orderType" value="22">
            <input type="hidden" id="orderStoreId" value="0">
            <input type="hidden" id="pickDate" value="1460476800475">
        </div>
    </div>
</body>
</html>
