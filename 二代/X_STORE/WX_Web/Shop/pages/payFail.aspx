﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payFail.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.payFail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>幸事多私享空间-支付成功</title>
    <script type="text/javascript">
        
    </script>
    <style type="text/css">

         * {
             margin: 0;
             padding: 0;
             font-size: 16px;
         }

        .clearfix:after {
            content: "";
            display: block;
            height: 0;
            clear: both;
        }

        .clearfix {
            zoom: 1;
        }

        .top {
            width: 100%;
            background-color: #ff6600;
        }

        .tips {
            color: #fff;
            font-size: 16px;
            float: left;
            width: 60%;
        }

        .tips-logo {
            width: 40%;
            float: left;
            height: auto;
        }

        .middle {
            width: 100%;
            background-color: #fff;
        }

        .middle h3 {
            color: orange;
            margin-left: 25px;
        }

        .middle img {
            width: 95%;
            margin-left: 2.5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top clearfix">
            <div class="tips">
                <p style="margin-top: 15px; margin-left: 15%;">啊哦，信号好像迷路了。</p>
            </div>
            <div class="tips-logo">
                <img style="margin-left: 40%; margin-top: 15px;" src="../images/fail-emoij.png" alt="">
            </div>
        </div>
        <div style="width: 100%; color: orange; margin-top: 15px;">
            <p style="margin-left: 25px; margin-bottom: 15px;">商品名：<asp:Label runat="server" ID="goodsName"></asp:Label> &nbsp&nbsp&nbsp售价：<asp:Label runat="server" ID="goodsSale"></asp:Label></p>
        </div>
        <div class="middle">
            <h3 style="margin: 20px;">别着急，您可以<span style="color: red;">拔插电源</span>来帮助信号回家</h3>
            <img src="../images/lc1.jpg" alt="">
            <img src="../images/lc2.jpg" alt="">
            <img src="../images/lc3.jpg" alt="">
        </div>
        <div class="bottom" style="color: orange; text-align: center; width: 80%; border: 1px solid #ff6600; margin: 20px auto;">
            <h3>重新插拔之后还没开箱？</h3>
            <p>点击<a href="tel:400-880-2482">此处</a>拨打客服电话</p>
        </div>
    </form>
</body>
</html>
