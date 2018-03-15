<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareDetail.aspx.cs" Inherits="XStore.WebSite.WebSite.Information.ShareDetail" %>


<%@ Import Namespace="XStore.Entity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no"/>
    <title><%:Title %></title>
    <link rel="icon" href="/Content/Icon/logo.png" type="image/x-icon" />
    <link href="/Content/fonts/iconfont.css" rel="stylesheet" />
    <%: System.Web.Optimization.Styles.Render("~/bundles/CommonStyle","~/bundles/comprehensive/css")%>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/CommonJs")%>
    <style>
        .bigfont {
            font-weight:500;
            font-size:18px;
        }
        .addfont {
            font-weight:500;
            font-size:20px;
            color:green
        }
        .timefont {
           color:#ccc;
        }
        .subtractfont {
          font-weight:500;
            font-size:20px;
            color:red
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="main"  style="-webkit-overflow-scrolling:touch;">
		    <div class="room item">
		        <ul>
                     <asp:Repeater ID="detail_rp" runat="server">
                        <ItemTemplate>
                            <li class="clearfix">
		    		            <div class="l">
			    			            <p class="bigfont"><span><%# Eval("cause") %></span></p>
                                    <p class="timefont"><%# Eval("date") %></p>
			    		        </div>
                                <div class="r">
			    			            <p class='<%#Eval("type").ObjToInt(0)==1?"subtractfont":"addfont" %>'><span><%#Eval("income") %></span></p>
			    		        </div>
		    	            </li>
                        </ItemTemplate>
                    </asp:Repeater>
		        </ul>
	       </div>
        </div>
    </form>
</body>
</html>