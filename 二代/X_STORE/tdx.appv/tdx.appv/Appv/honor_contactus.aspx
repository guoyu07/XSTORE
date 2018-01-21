<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="honor_contactus.aspx.cs" Inherits="tdx.appv.honor_contactus" %>
<%@ Register Src="appv_head.ascx" TagPrefix="uc" TagName="appHeader" %> 
<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %> 
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
<asp:Literal ID='lt_keywords' runat='server'></asp:Literal> 
<asp:Literal ID='lt_description' runat='server'></asp:Literal> 
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
<meta name="apple-mobile-web-app-status-bar-style" content="default" />
<meta name="apple-mobile-web-app-capable" content="yes" /> 
<asp:Literal ID='lt_theme' runat='server'></asp:Literal> 
<asp:Literal ID='lt_theme1' runat='server'></asp:Literal> 
<script language="javascript" src="/Appv/js/jquery-1.7.2.min.js" charset="utf-8"></script> 
<script language="javascript" src="/Appv/js/fsWeixin_apps.js" type="text/javascript" charset="utf-8"></script>
</head>

<body class="nei_body"> 
    <form id="form1" runat="server" >
    <uc:appHeader id="appHeader1" runat="server"   EnableViewState="False"></uc:appHeader>
    <div class="Appcontent">
        <h1><asp:Literal ID="lt_proTitle" runat="server" EnableViewState="false"></asp:Literal> </h1> 
       <!--
        <p>
            <span class="honorTitle">活动时间：</span>2014年6月2日至2014年7月31日
         </p>
         <p>
           <span class="honorTitle"> 奖项设置：</span><br />
                每周送出3张面值为100元京东商城购物卡一张，总计24张
                <img src="images/jp.jpg" border="0" />
         </p>
         <p>
           <span class="honorTitle"> 活动详情：</span><br />
                扫描二维码并关注伊萨中国官方微信平台<br />
                接收并打开伊萨中国官方微信平台所推送的信息<br />
                填写个人基本信息（中奖后邮寄奖品使用），按平台信息齐全者发放<br />
                点击参与抽奖（刮刮卡）<br />
                伊萨将从每周成功参与活动的粉丝中抽出3名获奖者，奖品为面值为100元京东商城购物卡一张<br />
         </p>
         <p>
            <span class="honorTitle">活动注意事项：</span><br />
                一个手机号码/微信账号仅能参与一次有奖活动<br />
                填写的个人信息须真实有效，以免影响奖品派发<br />
                伊萨对此次活动拥有最终解释权<br />
         </p>
         -->
        <p><asp:Literal ID="Literal2" runat="server" EnableViewState="false"></asp:Literal> </p>
        <p>
            <span>姓  名: </span><br />  <input type="text" class="px" name="uname" id="uname" runat="server" />
        </p>
        <p>
            <span>公  司: </span><br />  <input type="text" class="px" name="ucompany" id="ucompany" runat="server" />
        </p>
        <p>
            <span>手  机: </span><br />  <input type="text" class="px" name="utel" id="utel" runat="server" />
        </p>
        <p>
            <span>邮  箱: </span><br />  <input type="text" class="px" name="umail" id="umail" runat="server" />
        </p>
        <p>
            <span>地  址: </span><br />  <input type="text" class="px" name="uaddr" id="uaddr" runat="server" />
        </p>
        <p class="errMsg">
            <asp:Literal ID="lt_result" runat="server" ></asp:Literal>
        </p>
        <p>
            <asp:Button ID="submitBtn" runat="server"  Text = " 参与抽奖 " 
                onclick="submitBtn_Click"/>
        </p>
    </div>  
<uc:appFooter id="appFooter1" runat="server"   EnableViewState="False"></uc:appFooter>
</form>
</body>
</html>
