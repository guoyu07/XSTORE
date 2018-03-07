<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noPower.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.noPower" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <meta name="format-detection" content="telephone=yes" />
    <title>幸事多私享空间-未通电</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <style>
        html, body {
            width: 100%;
            height: 100%;
        }

        .imgWrap {
            width: 100%;
            padding: 10px 0;
            text-align: center;
        }

        p {
            width: 100%;
            font: 14px/30px "microsoft yahei";
            color: #000;
            text-align: center;
        }

            p a {
                font: 14px/30px "microsoft yahei";
                color: #ff6600;
                text-decoration: underline;
            }

        p bold {
            font-weight:bolder;
        }
        .des {
            width:100%;
            padding-left:20%;
            box-sizing:border-box;
        }
        .des h3 {
            font:700 16px/30px "microsoft yahei";
            color:#000;
            margin: 10px 0;
        }
        .des p {
                font:14px/24px "microsoft yahei";
                color:#333;
                text-align:left;
        }
        .buttonWrap {
            width:100%;
            text-align:center;
        }
         .buttonWrap input {
            appearance:none;
            -webkit-appearance:none;
            border: solid 1px #ff6600;
            border-radius:4px;
            width:100px;
            font:14px/40px "microsoft yahei";
            color:#ff6600;
            background:#fff;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="imgWrap" style="margin:100px 0px 15px;">
            
            <img style="width: 55%; height: 55%; display:none;" src="../img/no-power.png" alt="" />
        </div>
        <div class="des" style="margin:15px;">
             <h1 style="font-weight:800;margin-bottom:45px;">通讯正在努力连接中...</h1>
            <h3 style="display:none;">您可以使用“即买即用”模式</h3>
            <p >请检查：</p>
            <p>1.售货机电源是否连接良好</p>
            <p>2.房卡是否插上</p>
            <p style="margin-bottom:10px;">3.请尝试拔下插头，再上一次电</p>
            <p style="font-weight:800; text-align:left;">如刚上电，请等售货机提示灯停止</p>
            <p style="font-weight:800; text-align:left;">闪烁一分钟之后，再次扫码</p>
            <h3 style="display:none;">您也可以使用“前台送货”模式</h3>
        </div>
        <p class="buttonWrap" style="display:none;"><input type="button" runat="server" onserverclick="link_click" value="前台送货" /></p>
        <%--		<p>如还有问题，请联系客服电话：<a href="tel:400-880-2482">400-880-2482</a></p>--%>
        <div class="waiting" style="display: none;">
            <div class="waitWrapper">
                <img src="../img/loading.gif" alt="" />
            </div>
        </div>
    </form>
</body>
