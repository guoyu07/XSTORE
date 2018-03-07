<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qaBoxCheck.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.qaBoxCheck" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link href="../css/distributer.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/roomGoods.css" />
</head>
<body>
    <form id="form2" runat="server">
        <div class="clearfix topTitle" style="font-size:18px; font-weight:900;">
            <p class="distributer">MAC：<span><%=localboxmac %></span></p>
            <p class="distributer">版本号：<span><%=version %></span></p>
        </div>
        <div class="interval"></div>
         <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="mySpace" class="roomDetail">
                <ul class="clearfix" style="margin-bottom:5px;">
                    <asp:Repeater ID="box_rp" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="#" runat="server" onserverclick="position_click" num='<%#Eval("num") %>'> <%#Eval("num") %></a>
                               <asp:LinkButton runat="server" ></asp:LinkButton>
                                <%--<a href="#">
                                    <div class="pic">
                                        <img src="<%#Eval("图片路径")%>" alt="" />
                                        <p class="goodsName over"><span style="font-weight:bolder"><%#Eval("编码")%>&nbsp;&nbsp;</span><%#Eval("实际商品品名")%></p>
                                    </div>
                                    <div class="price">¥ <span><%#Eval("本站价").ObjToDecimal(0)%></span></div>
                                </a>
                                <p style="display: none"><%#Eval("实际商品id")%></p>
                                <div class="model "  style='<%#link_ul(Eval("实际商品id").ObjToInt(0)) %>'>
                                    <p>暂无商品</p>
                                </div>--%>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                 <div style="text-align:left; background-color:#ffffff; padding:15px; padding-top:30px; font-size:14px; ">
                               点击如下“全部开箱”，
                             <br />
                            您可打开从1到12个格子的全部格子门。
                            <br />
                                1）开门顺序是否正确？
                             <br />
                                2）全部格子门是否打开？
                             <br />
                                3）您可以多次点击“全部开箱”，反复验证

                           </div>
                  <div class="btnWrap " style="background-color:#ffffff;">
                        

                    <asp:LinkButton runat="server" ID="openAll" CssClass="makeSure" OnClick="openAll_Click">全部开箱</asp:LinkButton>
	            </div> 
            </div>
        </div>
    </form>
</body>

</html>
