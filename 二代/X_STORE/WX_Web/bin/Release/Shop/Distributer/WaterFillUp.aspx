<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaterFillUp.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.WaterFillUp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>幸事多私享空间-房间补水</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/payCenter.css" />
    <%--    <script src="../js/vconsole.min.js"></script>--%>
    <script src="../../js/jquery-1.11.0.min.js"></script>
    <script src="../js/weui.js"></script>
    <style type="text/css">
        .submitBtn {
            display: block;
        }
    </style>

</head>
<body>
    <form id="form" runat="server">
        <div class="total_money pd3 clearfix" style="margin-top:10px;">
            <div class="l"  style=" font-size:xx-large;">酒店名称：
                <br />
                <asp:Label ID="hotel_label" style=" font-size:xx-large;" runat="server"></asp:Label></div>
        </div>
        <div class="total_money pd3 clearfix" style="margin-top:40px; font-size:xx-large;">
            <div class="l"  style=" font-size:xx-large;">房间号：<br /> <asp:Label ID="room_label"  style=" font-size:xx-large;" runat="server"></asp:Label></div>
        </div>
        <div class="submit pd3" style="margin-top:100px;">
            <a class="submitBtn" id="water_fillup" style="height: 84px; font-weight:600; font-size: 50px;line-height: 72px;" runat="server" onserverclick="water_fillup_ServerClick" >完成配货</a>
        </div>

    </form>
    <script src="../js/payCenter.js"></script>
</body>
</html>
