<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomSelect.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.roomSelect" %>


<%@ Register Src="~/Shop/ascx/psyFooter.ascx" TagPrefix="uc" TagName="psyFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/roomSelect.css" />


    <link rel="stylesheet" href="../css/distributer.css" />
    <link rel="stylesheet" href="../css/layer.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多私享空间-常规补货</title>
    <script src='../js/plugins/zepto.min.js'></script>
    <script src='../js/plugins/vipspa.js'></script>
    <script src="../js/plugins/vipspa-dev.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
<%--<script type="text/javascript" src="../js/plugins/jweixin-1.0.0.js"></script>--%>
    <style>
        #form1 {
            width: 100%;
            height: 100%;
        }
    </style>
    <script type="text/javascript">
        
        function select_click(sender) {
            var obj = $(sender);
  
            var cls = obj.find(".label").find("img");
 
          
            if (obj.attr("class") == "active") {
   
                obj.removeClass("active");
                cls.attr("src", "../img/_对勾.png");
            }
            else {

                obj.addClass("active");
                cls.attr("src", "../img/对勾.png");

            }
        }
        function makeSureClick() {
            var totalId="";
            $(".active").each(function () {
                var self = $(this);
                totalId += self.attr("data-id") + ",";
            });
            if (totalId == "") {
                alert("请先选择房间");
                return;
            }
            var url = "PickUp.aspx?totalId=" + totalId;
            console.log(url);
            window.location.href = url;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
        <div id="roomSelectDiv" runat="server">
        <section class="clearfix process">
            <dl class="publishProgress clearfix">
               
                <dd class="step01 l pass">
                    <h3 class="icon iconfont icon-fangjian"></h3>
                    <h4>房间选择</h4>
                </dd>
                <dt class="progressBar01 l">
                    <div class="progressCenter"></div>
                </dt>
                <dd class="step02 l">
                    <h3 class="icon iconfont icon-peisongzhong"></h3>
                    <h4>仓库取货</h4>
                </dd>
<%--                <dt class="progressBar02 l">
                    <div class="progressCenter"></div>
                </dt>
                <dd class="step03 l clearfix">
                    <h3 class="icon iconfont icon-e617"></h3>
                    <h4>精准补货</h4>
                </dd>--%>
            </dl>
        </section>
        <div >
            <ul class="clearfix">
                <asp:Repeater ID="rooms_rp" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="#" data-id='<%#Eval("id")%>' onclick="select_click(this);">
                                <img class="roomclass" src="../img/room.png" />
                                <p class="roomNumber"><%#Eval("库位名") %></p>
                                <p class="label" ><img  class="" src="../img/_对勾.png"/></p>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="alarm_div">
           请从如上需要补货的房间中，选择可补货的房间。确认之后，您将看到需要从仓库取走的商品。
        </div>
        <div class="btnWrap" style="margin-top: 10px;">
		    <a class="makeSure"href="#" onclick="makeSureClick();">确认</a>
	    </div>
        </div>
        <div class="noRoom" runat="server" style="text-align:center;padding-top:40%;" id="empty_div">
            <p>暂无配送房间</p>
            <a href="<%=redirect_url %>">返回</a>
        </div>
            </div>
    </form>
</body>
</html>
