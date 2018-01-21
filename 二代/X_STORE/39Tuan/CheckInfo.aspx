<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckInfo.aspx.cs" Inherits="_39Tuan.CheckInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <title>这个真心不错！忍不住买了一份，无私的推荐给小伙伴们</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="thanku">
           <asp:Literal ID="textshare" runat="server" Text="感谢您购买，赶快分享到朋友圈，邀请好友购买!"></asp:Literal>
    </div>
        <div id="mcover" style="display:none"><img src="/images/icon_guide.png"></div>
     
    	<%--<div class="price fl"><strong>¥ <%=bzprice %></strong><em>¥ <%=scprice %></em></div>--%>
       

	<div class="wrap padd_10 clear">
        <div class="buy_bt2 fr"><input type="button" class="botton" onclick="document.getElementById('mcover').style.display = 'block';" value="分享" />   <%-- OnClick="Button1_Click"--%> 
            <%--<asp:Button ID="Button1"  runat="server" Text="提交订单" OnClientClick="jsApiCall()"  />--%>
        </div>
    </div>

    </form>
</body>
</html>
