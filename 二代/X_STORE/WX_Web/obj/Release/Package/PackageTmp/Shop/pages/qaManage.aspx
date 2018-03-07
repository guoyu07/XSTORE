<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qaManage.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.qaManage" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-测试员</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link href="../css/distributer.css" rel="stylesheet" />
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
            font-family: 'Microsoft YaHei';
        }

        .get_div {
            text-align: center;
            margin: 40px;
            border: 1px solid #999;
            border-radius: 3px;
            color: #999;
            padding: 10px;
            background-color: #eee;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div class="get_div">
                测试员，您好！
您可以对所有未配置酒店、房间的售货机执行开箱操作。
请点击本页面顶部的“X”号，关闭此登录界面。然后，微信扫描，智能售货机上二维码。
            </div>
            <div class="roomDetail">
                <div class="btnWrap " style="background-color: #ffffff;">
                    <a href="#" class="makeSure cancellation" >注销账号</a>

                </div>
            </div>
        </div>

    </form>
    <script src="../js/plugins/zepto.min.js"></script>
    <script src="../js/plugins/layer.js"></script>
    <script>
        $(function () {
            $('.cancellation').on('click', function () {
                layer.open({
                    content: '是否注销？',
                    btn: ['确定', '取消'],
                    yes: function (index) {
                        $.ajax({
                            url: '../ashx/Cancellation.ashx',
                            data: {},
                            type: 'get',
                            dataType: 'json',
                            success: function (result) {
                                if (result.state == 1) {
                                    layer.open({
                                        content: result.info,
                                        shadeClose: false,
                                        btn: ['ok'],
                                        yes: function (index) {
                                            layer.close(index);
                                            window.location.href = "login.aspx";
                                        }
                                    })
                                } else {
                                    layer.open({
                                        content: result.info,
                                        time: 2
                                    })
                                }
                            }
                        })
                    }
                })
            })
        })
    </script>
</body>
</html>
