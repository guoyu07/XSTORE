<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAccount.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.GetAccount" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-获取账号</title>
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
            font-family:'Microsoft YaHei'
        }
        .get_div {
            text-align:center;
            margin:40px;
            border:1px solid #999;
            color:#999;
            padding:10px;
            background-color:#eee;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div class="get_div">
                如果您是酒店经理，请与平台联系，<a  href="tel:400-880-2482">400-880-2482</a>，获取属于您的账户和密码
	        </div>
            <div class="get_div">
                如果您是酒店服务员，请与酒店经理联系，酒店经理应该已有属于您的账户和密码
            </div>
            <div class="get_div">
                您登录到系统之后，系统会提示您填充您的个人信息，更改密码，变成属于您自己的密码，防止他人盗用。
            </div>
        </div>     
    </form>
</body>
</html>

