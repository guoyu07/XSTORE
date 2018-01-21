<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomDetail.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.roomDetail" %>

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
    <link rel="stylesheet" href="../css/roomDetail.css" />
</head>
<body>
    <form id="form1" runat="server">
        <dl>
            <dt class="clearfix">
                <div class="identifier l">编号</div>
                <div class="goodsName l">商品</div>
                <div class="pic l">图片</div>
                <div class="isSure l">确认</div>
            </dt>
            <asp:Repeater ID="box_rp" runat="server" OnItemCommand="rpt_ItemCommand">
                <ItemTemplate>
                    <dd class="clearfix " id="no_goods" runat="server">
                        <div class="idf l" ><asp:label runat="server" ID="weizhi"><%#Eval("位置") %></asp:label></div>
                        <div class="gdn l over"><%#Eval("品名") %></div>
                        <div class="imgWrap l">
                            <img src="<%#Eval("图片路径") %>" alt="" />
                        </div>
                        <div class="btnWrap l">
                            <asp:button runat="server" CommandArgument='<%#Eval("位置")+"|"+Eval("默认商品id")+"|"+Eval("id")%>' ID="onbox" OnClick="Unnamed_Click" Text="开箱"  CommandName="onbox"   ></asp:button></div>
                    </dd>
                </ItemTemplate>
            </asp:Repeater>
        </dl>
        <div class="fnWrap">
            <button class="finish">完成</button>
        </div>
        <ul class="tips">
            <li class="pickUpSuccess">
                <div class="imgWrap">
                    <img src="../img/success.png" alt="" />
                </div>
                <p>补货成功</p>
                <div class="des">请随手关闭箱门。谢谢！</div>
                <div class="okBtn">
                    <span>OK</span>
                </div>
            </li>
        </ul>
        <script src="../js/plugins/zepto.min.js"></script>
        <script src="../js/roomDetail.js"></script>
    </form>
</body>
</html>
