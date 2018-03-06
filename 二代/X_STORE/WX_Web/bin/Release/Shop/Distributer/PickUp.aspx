<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PickUp.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.PickUp" %>

<%@ Register Src="~/Shop/ascx/psyFooter.ascx" TagPrefix="uc" TagName="psyFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-常规补货</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/distributer.css" />
    <script src='../js/plugins/zepto.min.js'></script>
    <script src='../js/plugins/vipspa.js'></script>
    <script src="../js/plugins/vipspa-dev.js"></script>
    <script src="../js/modules/pickUp.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <link rel="stylesheet" href="../../style/footer.css" />
    <style>
        #form1 {
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="pickUp" runat="server" >
	            <section class="clearfix process">
    	            <dl class="publishProgress clearfix">
                        <dd class="step01 l pass">
				            <h3 class="icon iconfont icon-fangjian"></h3><h4>房间选择</h4>
			            </dd>
			            <dt class="progressBar01 l pass">
				            <div class="progressCenter"></div>
			            </dt>
			            <dd class="step02 l pass">
				            <h3 class="icon iconfont icon-peisongzhong"></h3><h4>仓库取货</h4>
			            </dd>
			            <%--<dt class="progressBar02 l">
				            <div class="progressCenter"></div>
			            </dt>
			            <dd class="step03 l clearfix">
				            <h3 class="icon iconfont icon-e617"></h3><h4>精准补货</h4>
			            </dd>--%>
		            </dl>
	            </section>
	            <div class="interval"></div>
	            <ul>
                    <asp:Repeater ID="Rp_pickup" runat="server">
                        <ItemTemplate>
                             <li class="clearfix">
			                    <div class="imgWrap l">
				                    <img src="<%#Eval("图片路径") %>" alt="" />
			                    </div>
			                    <div class="info l">
				                    <h3><span><%#Eval("编码") %></span> &nbsp;<span><%#Eval("品名") %></span></h3>
			                    </div>
			                    <div class="num r iconfont icon-cha"> <span><%#Eval("数量") %></span></div>
		                    </li>
                        </ItemTemplate>
                    </asp:Repeater>
		           
	            </ul>
                <div  class="alarm_div">
                 请到仓库取货。

                </div>
	            <div class="btnWrap">
                    <a class="makeSure" href="#" runat="server" ID="markSure"  OnServerClick="markSure_OnServerClick">确认</a>
		         <%--   <a class="makeSure"href="../pages/roomsPickUp.aspx?kwid=<%=totalId.ObjToStr() %>">确认</a>--%>
	            </div>
            </div>
            <div class="noTask" runat="server" style="text-align:center; padding-top:40%;" id="noTask">
		        暂无配送任务
	        </div>
            </div>

        <div style="display: block;" runat="server" id="foot_div" class="footer_bar openwebview">
            <uc:psyFooter ID="psyFooter" runat="server" EnableViewState="False"></uc:psyFooter>
        </div>

        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(1).addClass("on");
            })
        </script>
    </form>
</body>
</html>
