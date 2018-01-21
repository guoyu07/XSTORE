<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS.aspx.cs" Inherits="Tuan.JS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#bg").hide();
            $("#dbtc").hide();
            $("#dbtc2").hide();
            $("#btn_tanchu").click(function () {
                $("#bg").show();
                $("#dbtc2").fadeIn();
            });

            $("#close").click(function () {
                $("#bg").hide();
                $("#dbtc2").hide();
                $("#dbtc").hide();
            });
        });

    </script>
    <script>
        function xinzeng(a) {
            alert(a);
            $("#dbtc2").hide();
            $("#dbtc").fadeIn();

        }

    </script>
    <script>
        function baocun() {
            alert("保存成功");
            $("#dbtc2").fadeIn();
            $("#dbtc").hide();

        }
    </script>
    <script type="text/javascript">
        addressInit('cmbProvince', 'cmbCity', 'cmbArea', '江苏', '无锡市', '崇安区');

    </script>
    <script src="js/jsAddress.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 500px; height: 700px;">
            <input id="btn_tanchu" type="button" value="弹出" />
            <a href="javascript:;" id="close">
                <div id="bg" style="background-color: #000000; opacity: 0.7; width: 500px; height: 700px;"></div>
            </a>
            <div id="dbtc" style="width: 500px; height: 350px; position: fixed; top: 350px; z-index: 99; border: 1px solid #ff0000;">
                <div id="xinzeng">
                    <ul class="cont conts clear">
                        <li class="clear">
                            <label>* 姓名：</label><input type="text" id="name" runat="server" class="name" /></li>
                        <li class="clear">
                            <label>* 手机：</label><input type="text" id="tel" runat="server" class="tel" /></li>
                        <li class="clear">
                            <label>* 省份：</label><select id="cmbProvince"></select></li>
                        <li class="clear">
                            <label>* 城市：</label><select id="cmbCity"></select></li>
                        <li id="seachdistrict_div" class="clear">
                            <label>* 区镇：</label><select id="cmbArea"></select></li>
                        <li class="clear">
                            <label>* 地址：</label><input type="text" id="address" runat="server" class="add" /></li>
                        <li class="clear">
                            <label>邮编：</label><input type="text" id="ub" runat="server" class="ub" /></li>
                        <li class="clear">
                            <input type="button" id="btn_shiyong" value="保存" onclick="baocun()" />
                        </li>
                    </ul>
                </div>
            </div>
            <div id="dbtc2" style="width: 500px; height: 350px; position: fixed; top: 350px; z-index: 99; border: 1px solid #ff0000;">
                <div id="liebiao">
                    <ul class="cont conts clear">
                        <li class="clear">
                            <label>* 姓名：</label>777  
                            <input id="xg" onclick="xinzeng('修改')" type="button" value="修改" /></li>
                        <li class="clear">
                            <label>* 手机：</label>666</li>
                        <li class="clear">
                            <label>* 省份：</label>555</li>
                        <li class="clear">
                            <label>* 城市：</label>444</li>
                        <li class="clear">
                            <label>* 区镇：</label>333</li>
                        <li class="clear">
                            <label>* 地址：222</label></li>
                        <li class="clear">
                            <label>邮编：</label>111</li>
                        <li class="clear">
                            <input type="button" id="btnadd" value="新增" onclick="xinzeng('新增')" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
