﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enter.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.enter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>幸事多私享空间</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <style>
        html, body {
            width: 100%;
            height: 100%;
        }

        body {
            position: relative;
        }

        .bottom {
            position: absolute;
            bottom: 0;
            left: 0;
        }

            .bottom img {
                display: block;
            }

        .top, .bottom {
            width: 100%;
        }

        .main {
            width: 100%;
            position: absolute;
            left: 0;
            top: 40%;
            z-index: 10;
        }
        /*@media only screen and (min-width: 320px) and (max-width: 374px){
				.main{
					top:20%;
				}
			}
			@media only screen and (min-width: 375px) and (max-width: 413px){
				.main{
					top:-40px;
				}
			}
			@media only screen and (min-width: 414px){
				.main{
					top:-20px;
				}
			}*/
        .btnWrap {
            width: 100%;
            text-align: center;
            padding: 6px 0;
        }

            .btnWrap .btn {
                display: inline;
                font: 18px/24px "microsoft yahei";
                color: #000;
                padding: 0 4px;
                border: solid 1px #000;
                border-radius: 2px;
            }

        input {
            width: 30px;
            height: 30px;
            background: url(../img/guide/no-active.png) no-repeat;
            background-size: 100% 100%;
            margin-right: 10px;
            border: none;
            outline: none;
        }

            input:checked {
                background: url(../img/guide/active.png) no-repeat;
                background-size: 100% 100%;
            }

        label {
            display: inline-block;
            font: 18px/30px "microsoft yahei";
        }

        p {
            width: 100%;
            text-align: center;
        }

            p a {
                font: 14px/20px "microsoft yahei";
                color: #ff6600;
            }

        .tips {
            display: none;
            width: 94%;
            height: 70%;
            position: fixed;
            top: 0;
            left: 0;
            z-index: 99;
            padding: 30% 3%;
            background: rgba(0,0,0,0.3);
            text-align: center;
        }

        .enterFail {
            display: inline-block;
            width: 200px;
            height: 200px;
            background: #fff;
            padding: 10px 0;
        }

        html body .tips .enterFail .imgWrap {
            width: 100%;
            text-align: center;
        }

        html body .tips .enterFail p {
            word-break: normal;
            width: 100%;
            text-align: center;
            font: 600 20px/40px "microsoft yahei";
            color: #000;
        }

        html body .tips .enterFail .des {
            width: 100%;
            text-align: center;
            font: 14px/30px "microsoft yahei";
            color: #666;
            margin-bottom: 10px;
        }

        html body .tips .enterFail .okBtn {
            width: 100%;
            text-align: center;
        }

            html body .tips .enterFail .okBtn span {
                display: inline-block;
                padding: 0 40px;
                background: #6fa0f6;
                border-radius: 2px;
                font: 14px/40px "microsoft yahei";
                color: #fff;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
            <img src="../img/guide/top.png" alt="" />
        </div>
        <div class="main">
            <div class="btnWrap">
                <input type="checkbox" /><label for="">确认已满18周岁</label>
            </div>
            <div class="btnWrap">
                <div class="btn">立即开启 ENTER</div>
            </div>
            <div class="imgWrap">
                <img src="../img/guide/btns.png" alt="" />
            </div>
            <p><a href="javascript:;">常见问题</a></p>
        </div>
        <div class="bottom">
            <img src="../img/guide/bottom.png" alt="" />
        </div>
        <div class="tips">
            <div class="enterFail">
                <div class="imgWrap">
                    <img src="../img/fail.png" alt="" />
                </div>
                <p>系统提示</p>
                <div class="des">请确认您已满18周岁</div>
                <div class="okBtn">
                    <span>OK</span>
                </div>
            </div>
        </div>
        <div class="waiting">
            <div class="waitWrapper">
                <img src="img/loading.gif" alt="" />
            </div>
        </div>
        <script src="../js/plugins/zepto.min.js"></script>
        <script>
            $('.okBtn').on('click', function () {
                $('.tips').hide();
            });
            $('.tips').on('click', function () {
                $('.tips').hide();
            });
            $('.enterFail').on('click', function (event) {
                event.stopPropagation();
            });
            $('.btn').on('click', function () {
                if ($('input').prop('checked')) {
                    window.location.href = '../Buyer/mySpace.aspx'
                } else {
                    $('.tips').show();
                }
            });
        </script>

    </form>

    <%--    		<script>
    		    $('.okBtn').on('click', function () {
    		        $('.tips').hide();
    		    })
    		    $('.btn').on('click', function () {
    		        if ($('#enter').prop('checked')) {
    		            window.location.href = '../Buyer/mySpace.aspx'
    		        } else {
    		            $('.tips').show();
    		        }
    		    })
		</script>--%>
</body>

</html>
