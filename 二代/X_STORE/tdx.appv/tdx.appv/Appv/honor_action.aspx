﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="honor_action.aspx.cs" Inherits="tdx.appv.honor_action" %>

<%@ Register Src="appv_head.ascx" TagPrefix="uc" TagName="appHeader" %>
<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %>
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
    <asp:Literal ID="lt_keywords" runat="server"></asp:Literal>
    <asp:Literal ID="lt_description" runat="server"></asp:Literal>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <asp:Literal ID='lt_theme' runat='server'></asp:Literal>
    <script language="javascript" src="/Appv/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/Appv/js/fsWeixin_apps.js" type="text/javascript"
        charset="utf-8"></script>
    <script src="honoraction/honor.js" type="text/javascript"></script>
</head>
<body class="nei_body">
    <input type="hidden" id="h_WWV" runat="server" />
    <input type="hidden" id="h_acID" runat="server" />
    <input type="hidden" id="chjnum" runat="server" />
    <uc:appHeader ID="appHeader1" runat="server" EnableViewState="False"></uc:appHeader>
    <div class="Appcontent">
        <h1>
            <asp:Literal ID="lt_proTitle" runat="server" EnableViewState="false"></asp:Literal>
        </h1>
        <p>
            <asp:Literal ID="lt_newsContent" runat="server" EnableViewState="false"></asp:Literal>
            <link href="/appv/honoraction/images/activity-style.css" rel="stylesheet" type="text/css">
            <div id="mainpan" runat="Server" class="main">
                <script type="text/javascript">
                    //                    var loadingObj = new loading(document.getElementById('loading'), { radius: 20, circleLineWidth: 8 });
                    //                    loadingObj.show();   
                </script>
                <div id="outercont">
                    <div id="outer-cont">
                        <div id="outer">
                            <img src="/appv/honoraction/images/activity-lottery-1.png" width="310px"></div>
                    </div>
                    <div id="inner-cont">
                        <div id="inner">
                            <img src="/appv/honoraction/images/activity-lottery-2.png"></div>
                    </div>
                </div>
                <div class="content">
                    <div id="zjl" style="display: none" class="boxcontent boxwhite">
                        <div id="zjbox" class="box">
                            <div class="title-red">
                                <span>恭喜你中奖了 </span>
                            </div>
                            <div class="Detail">
                                <p>
                                    你中了： <span class="red" id="prizetype">一等奖</span>
                                </p>
                            </div>
                            <p>
                                兑奖SN码： <span class="red" id="sncode"></span>
                            </p>
                            <p class="red">
                            </p>
                            <p>
                                <input name="" class="px" id="name" value="" type="text" placeholder="请输入您的姓名">
                            </p>
                            <p>
                                <input name="" class="px" id="tel" value="" type="text" placeholder="请输入您的手机号">
                            </p>
                            <p>
                                <input name="" class="px" id="comp" value="" type="text" placeholder="请输入您的公司名称">
                            </p>
                            <p>
                                <input name="" class="px" id="addr" value="" type="text" placeholder="请输入您的地址">
                            </p>
                            <p>
                                <input name="" class="px" id="email" value="" type="text" placeholder="请输入您的email">
                            </p>
                            <p>
                                <input class="pxbtn" name="提 交" id="save-btn" type="button" value="用户提交">
                                <span id="servspan"></span>
                            </p>
                            <%--                                <p>
                                    <input name="" class="px" id="parssword" type="password" value="" placeholder="商家输入兑奖密码">
                                </p>
                                <p>
                                    <input class="pxbtn" name="提 交" id="save-btnn" type="button" value="商家提交">
                                </p>--%>
                        </div>
                    </div>
                    <div class="boxcontent boxwhite">
                        <div class="box">
                            <div class="title-green">
                                <span>奖项设置： </span>
                            </div>
                            <div class="Detail">
                                <p>
                                    <asp:Literal ID="lt_jp1" runat="server"></asp:Literal>
                                </p>
                                <p>
                                    <asp:Literal ID="lt_jp2" runat="server"></asp:Literal>
                                </p>
                                <p>
                                    <asp:Literal ID="lt_jp3" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="boxcontent boxwhite">
                        <div class="box">
                            <div class="title-green">
                                活动说明：
                            </div>
                            <div class="Detail">
                                <p class="red">
                                    <asp:Literal ID="lt_shuoming" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<div class="content">
                    <div class="boxcontent boxyellow" id="result" style="display: none">
                        <div class="box">
                            <div class="title-orange">
                                <span>恭喜你中奖了</span></div>
                            <div class="Detail">
                                <a class="ui-link" href="/" id="opendialog" style="display: none;" 
                                
                                -rel="dialog">
                                </a>
                                <p>
                                    你中了：<span class="red" id="prizetype">一等奖</span></p>
                                <p>
                                    你的兑奖SN码：<span class="red" id="sncode"></span></p>
                                <p class="red">
                                    本次兑奖码已经关联你的微信号，你可向公众号发送 兑奖 进行查询!</p>
                                <p>
                                    <input name="" class="px" id="tel" type="text" placeholder="输入您的手机号码">
                                </p>
                                <p>
                                    <input class="pxbtn" id="save-btn" name="提 交" type="button" value="提 交">
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="boxcontent boxyellow">
                        <div class="box">
                            <div class="title-green">
                                <span>奖项设置：</span></div>
                            <div class="Detail">
                                <p>
                                    一等奖： 。奖品数量：3
                                </p>
                                <p>
                                    二等奖： 。奖品数量：5
                                </p>
                                <p>
                                    三等奖： 。奖品数量：10
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="boxcontent boxyellow">
                        <div class="box">
                            <div class="title-green">
                                活动说明：</div>
                            <div class="Detail">
                                <p>
                                    本次活动每人可以转 3 次
                                </p>
                                <p>
                                    我们的中奖率高达33.3%！！
                                </p>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </p>
    </div>
    <uc:appFooter ID="appFooter1" runat="server" EnableViewState="False"></uc:appFooter>
</body>
</html>
