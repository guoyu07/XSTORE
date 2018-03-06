<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseInfoCenter.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.BaseInfoCenter" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-基本信息</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../../css/reset.css" />
    <link rel="stylesheet" href="../../css/common.css" />
    <link rel="stylesheet" href="../../fonts/iconfont.css">
    <link rel="stylesheet" href="../../css/comprehensive.css" />
    <script src="../../../js/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form2" runat="server">
        <div class="main" style="-webkit-overflow-scrolling: touch;">
            <div class="room item">
                <ul>
                    <li class="clearfix">
                        <a href='RoomInfoList.aspx?hotel_id=<%#Eval("id").ObjToInt(0) %>'>
                            <div class="l">
                                <p class="roomNumber"><span>房间</span></p>
                            </div>
                            <div class="r status">
                                进入
                            </div>
                        </a>
                    </li>
                    <li class="clearfix">
                        <a href='GoodsInfoList.aspx?hotel_id=<%#Eval("id").ObjToInt(0) %>'>
                            <div class="l">
                                <p class="roomNumber"><span>商品</span></p>
                            </div>
                            <div class="r status">
                                进入
                            </div>
                        </a>
                    </li>
                    <li class="clearfix" style="display:none;">
                        <a href='UserInfoList.aspx?hotel_id=<%#Eval("id").ObjToInt(0) %>'>
                            <div class="l">
                                <p class="roomNumber"><span>注册用户</span></p>
                            </div>
                            <div class="r status">
                                进入
                            </div>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
