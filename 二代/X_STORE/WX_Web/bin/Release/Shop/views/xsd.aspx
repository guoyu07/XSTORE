<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xsd.aspx.cs" Inherits="Wx_NewWeb.Shop.views.xsd" %>

<%@ Register Src="~/Shop/ascx/UserFooter.ascx" TagPrefix="uc" TagName="UserFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/buyerIndex.css" />
    <link rel="stylesheet" href="../../style/footer.css" />
    <script src="../js/plugins/zepto.min.js"></script>

    <script src="../js/plugins/vipspa.js"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
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
            微商城
        </div>

        <div style="display: block;" class="footer_bar openwebview">
            <uc:UserFooter ID="UserFooter" runat="server" EnableViewState="False"></uc:UserFooter>
        </div>


        <script src="../js/modules/xsd.js"></script>
        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(0).addClass("on");

            })
        </script>

    </form>
</body>
</html>
