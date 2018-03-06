<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="areaManage.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.areaManage" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-区域经理</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
	<link rel="stylesheet" href="../css/reset.css" />
	<link rel="stylesheet" href="../css/common.css" />
	<link rel="stylesheet" href="../fonts/iconfont.css">
	<link rel="stylesheet" href="../css/comprehensive.css"/>
    <script src="../../js/jquery-1.10.2.js"></script>
 <script type="text/javascript">
     //window.addEventListener("popstate", function (e) {
     //    window.location.href = "areaManage.aspx";
     //    //pushHistory();
     //}, false);
     //$(function () {
     //    pushHistory();
     //    var bool = false;
     //    setTimeout(function () {
     //        bool = true;
     //    }, 1500);
     //    window.addEventListener("popstate", function (e) {
     //        if (bool) {
     //            window.location.href = "areaManage.aspx";
     //        }
     //        pushHistory();

     //    }, false);
         
     //});
     //function pushHistory() {
     //    var state = {
     //        title: "title",
     //        url: "#"
     //    };
     //    window.history.pushState(state, "title", "#");
     //}
    </script>
</head>
<body>
    <form id="form2" runat="server">
        <div class="main"  style="-webkit-overflow-scrolling:touch;">
		    <div class="room item">
		        <ul>
                     <asp:Repeater ID="hotel_rp" runat="server">
                        <ItemTemplate>
                             <li class="clearfix">
		    		          <a href='hotelManager.aspx?hotel_id=<%#Eval("id").ObjToInt(0) %>'>
			    		            <div class="l">
			    			            <p class="roomNumber"><span><%#Eval("仓库名") %></span></p>
			    		            </div>
			    		            <div class="r status">
                                        进入
			    		            </div>
		    		            </a>
		    	            </li>
                        </ItemTemplate>
                    </asp:Repeater>
		        </ul>
	       </div>
        </div>
       
        <script src="../js/jquery-1.7.2.min.js"></script>
        <script src="../js/comprehensive_hm.js"></script>
    </form>
</body>
</html>
