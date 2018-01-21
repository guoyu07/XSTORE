<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VIPCardCount.aspx.cs" Inherits="tdx.memb.man.vipmemb.VIPCardCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/jscharts.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <!--内容-->
    <h1>
        <strong>会员卡统计</strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>

        <div class="tdh">
            <asp:Literal ID="ylList" runat="server" EnableViewState="false"></asp:Literal>
        </div>
            <asp:HiddenField ID="_hf" Value="10-20,20-50,30-15,40-30" runat="server" />
    <div id="graph">
    </div>
    </div>

    <!--内容结束-->
    </form>
    <script type="text/javascript">
        //对应的先X轴，再Y轴
        var arr1 = new Array();
        var arr2 = new Array();
        var data = $("#_hf").val();
        data = data.split("-");
        //分割出一维数组
        for (var j = 0; j < data.length; j++) {
            arr2[j] = data[j];
        }
        //分割成二维数组
        for (var i = 0; i < arr2.length; i++) {
            arr1[i] = arr2[i].split(",");
        }
        //将二维字符串数组转换为整形数组
        for (var i = 0; i < arr1.length; i++) {
            arr1[i] = arr1[i].map(function (dt) {
                return +dt;
            });
        }
        //var myData = new Array([10, 20], [15, 10], [20, 30], [25, 10], [30, 5], [40, 10]);
        var myChart = new JSChart('graph', 'line');
        myChart.setTitle('会员卡统计');
        myChart.setDataArray(arr1);
        myChart.draw();
    </script>
</body>
</html>

