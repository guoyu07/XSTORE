<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="tdx.appv.index" %>
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
<script language="javascript" src="/Appv/js/jquery-1.7.2.min.js" charset="utf-8"></script> 
<script language="javascript" src="/Appv/js/swipe.js" type="text/javascript" charset="utf-8"></script>
<script language="javascript" src="/Appv/js/fsWeixin_apps.js" type="text/javascript" charset="utf-8"></script>
    <link href="images/wsite/black/wsite.css" rel="stylesheet" type="text/css" />
</head>

<body class="body"> 
<div class="i_body">
    <uc:appHeader id="appHeader1" runat="server"   EnableViewState="False"></uc:appHeader>  
    <!--广告轮播图片-->
    	<div class="i_wel">
         欢迎来到<asp:Literal ID="lt_nichen" runat="server"></asp:Literal>微信网站 
    </div> 
    <div class="i_ads">
        <div style="-webkit-transform:translate3d(0,0,0);">
		    <div id="banner_box" class="box_swipe">
			    <ul>
				    <asp:Literal ID="lt_photolist" runat="server" EnableViewState ="false" ></asp:Literal> 
			     </ul>
			     <ol>
			        <asp:Literal ID="lt_arrowpage" runat="server" EnableViewState ="false" ></asp:Literal> 
			     </ol> 
		    </div>
	    </div>
		    <script type="text/javascript">
		    $(function(){
			    new Swipe(document.getElementById('banner_box'), {
				    speed:500,
				    auto:3000,
				    callback: function(){
					    var lis = $(this.element).next("ol").children();
					    lis.removeClass("on").eq(this.index).addClass("on");
				    }
			    });
		    });
	    </script>
	</div>
	<!--广告轮播图片结束-->
    <div class="i_hotLine"> <asp:Literal ID="tel" runat="server" EnableViewState ="false" ></asp:Literal> </div>
	<div class="i_content">
        <div id="i_content_left" style="display:none;"></div>
	    <ul>
	        <asp:Literal ID="lt_GoodCate" runat="server" EnableViewState ="false" ></asp:Literal>
	    </ul>
        <div id="i_content_right" style="display:none;"></div>
	</div>        
<uc:appFooter id="appFooter1" runat="server"   EnableViewState="False"></uc:appFooter>
</div>
</body>
</html>
