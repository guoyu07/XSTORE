<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotelList.aspx.cs" Inherits="Wx_NewWeb.Shop.OperateManager.hotelList" %>

<%@ Register Src="~/Shop/ascx/GeneralManagerFooter.ascx" TagPrefix="uc" TagName="GeneralManagerFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-区域管理系统</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/operateManager.css" />
    <link rel="stylesheet" href="../../style/footer.css" />
    <style>
        #form1 {
            width: 100%;
            height: 100%;
        }
          ul li a .over  {
                width: calc(100% - 92px);
                width: -webkit-calc(100% - 92px);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="hotelList">
                <header>
                    <asp:Label ID="area_lbl" runat="server"></asp:Label>
                </header>

                <div class="topInputContaienr">
<%--                    <input type="text" id="" runat="server" onchange="" style="outline:none;" value="" placeholder="请输入酒店名称" />--%>
                    <asp:TextBox ID="hotel_search" runat="server" OnTextChanged="hotel_search_TextChanged" placeholder="请输入酒店名称" ></asp:TextBox>
                    
                </div>
                <div class="HL_listItem">
                    <ul>
                        <asp:Repeater ID="hotel_list" runat="server">
                            <ItemTemplate>
                                <li class="">
                                    <a href="javascript:;" class="clearfix" style="color:black;">
                                        <div class="imgWrap l">
                                            <img src="<%#Eval("Logo") %>">
                                        </div>
                                        <div class="l over">
                                            <%#Eval("仓库名") %>
    	               
                                    <p class=""><span class="room"><%#Eval("rooms") %>个房间</span><span class="deliveryPerson"><%#Eval("members") %>个配送员</span></p>
                                        </div>
                                        <div class="r iconfont icon-gengduo"></div>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>

        </div>
        <div style="display: block;" class="footer_bar openwebview">
            <uc:GeneralManagerFooter ID="GeneralManagerFooter" runat="server" EnableViewState="False"></uc:GeneralManagerFooter>
        </div>

        <script src='../js/plugins/zepto.min.js'></script>
        <script src='../js/plugins/vipspa.js'></script>
        <script src="../js/modules/hotelList.js"></script>

        <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
        <script src="../../js/jquery-1.7.2.min.js"></script>

        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(1).addClass("on");

            })
        </script>
    </form>
</body>
</html>
