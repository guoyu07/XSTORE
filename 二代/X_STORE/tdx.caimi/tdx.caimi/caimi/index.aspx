﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="tdx.caimi.index" %>
<!DOCTYPE>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="HandheldFriendly" content="True">
<meta name="MobileOptimized" content="320">
<title><asp:Literal ID="lt_title" runat="server"></asp:Literal>猜谜活动</title>
<asp:Literal ID="lt_keywords" runat="server"></asp:Literal>
<asp:Literal ID="lt_description" runat="server"></asp:Literal>
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
<meta name="apple-mobile-web-app-status-bar-style" content="default" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="js/jquery-1.7.2.min.js"></script>
<script language="javascript" src="js/caimi.js"></script>
</head>
<body>
	<div class="wrap2">
        <div class="bg">
            <asp:Literal ID="lt_newsContent" runat="server" ></asp:Literal> 
        	<div class="quion_k" runat="Server" id="mainPage"> 
        	    <div class="quion clear">
            	    <label>题目：</label>
                    <input type="hidden" id="h_WWV" name="h_WWV" runat="server" />
                    <input type="hidden" id="h_WWX" name="h_WWX" runat="server" />
                    <input type="hidden" id="h_acID" name="h_acID" runat="server" />
                    <input type="hidden" id="h_tID" name="h_tID" runat="server" />
                    <input type="hidden" id="h_guid" name="h_guid" runat="server" />
            	    <textarea class="question" ID="lt_cm_title" name="lt_cm_title"></textarea>
                </div>
                <div class="quion clear">
            	    <label>答案：</label><input type="text" class="answer" id="lt_cm_answer" name="lt_cm_answer">
                </div>
                <div class="quion clear">
                    <div id="quion_timer"></div>
            	    <a href="####" onclick="anSwerMiYu();" class="button" id="lt_cm_button">下一题</a>
                </div>
            </div>
            <input type="button" id="btnRefresh" name="btnRefresh" value="  再玩一次  " onclick="location.reload();" runat="server" />
        </div>
    </div>
    <div class="wrap">
   	  <div class="action">
            <strong>关注“无锡太湖鼋头渚风景区”微信公众号，点击进入中秋微信活动专题，开始微信猜谜活动</strong>
            <br />
        	<strong>游戏说明：</strong>
            <div>只要您连续答对三道题，就有机会获得2014鼋头渚中秋赏月音乐烟花大会门票一张！</div>
			<strong>规则说明：</strong>
            <div>1）连续答对三道谜语，就有机会参加的转盘抽奖，赢取“2014鼋头渚中秋赏月水上音乐烟花大会”门票一张。
              <br>
              2）抽中门票奖品的朋友，请分享至朋友圈；并于2014年9月6日或8日下午四点半后至鼋头渚景区充山大门领取门票。<br>
              3）每人每天只有三次机会。</div>
        </div>
    </div>

 <div class="waiting">
    <img border="0" style="margin-top: 8px;" src="images/loading.gif" alt="" />
</div>
</body>
</html>
  
