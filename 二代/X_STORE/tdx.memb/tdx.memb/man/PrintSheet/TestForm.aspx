<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm.aspx.cs" Inherits="tdx.memb.man.PrintSheet.TestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../js/jquery-1.10.2.min.js"></script>
    <script>
        function dopost()
        {
            var txtOrderInfo = '{"OrderInfo":[' +
            '{"orderNO":"S2016042200001","orderType":"WP" },' +
            '{"orderNO":"S2016042200001","orderType":"WP" },' +
            '{"orderNO":"S2016042200001","orderType":"WP" }]}';//json数组对象

            var sss = '{ "S2016042200001": "WP", "S2016042200002": "WP", "S2016042200003": "WP", "S2016042200004": "WP", "S20160422000034": "WP", "S2016042200005": "WP", "S20160422000061": "WP" }';

            document.cookie = "OrderInfo=" + sss;//设置cookie值，在目标页面取得
            location.href = "ShowPrintInfo.aspx?printType=Multi";
            debugger;
            //$.ajax({//虽然可以传参数，但是页面没跳转
            //    type: "POST", //用POST方式传输
            //    url: 'ShowPrintInfo.aspx?printType=Multi', //目标地址
            //    dataType: "json",//需要限定为json
            //    data: { OrderInfo: txtOrderInfo,printType:"Multi"},
            //    success: function (data) {
            //        if (data.message == "true") {
            //            $("#pageindex").val(data.index);
            //            $('table.orderinfo').append(data.result);
            //        }
            //        else {
            //            alert(data.message);
            //            $(this).html("没有更多数据");
            //        }
            //    },
            //    error: function () {
            //        alert("异常！");
            //    }
            //})
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button"  onclick="dopost()" value="Post传到ASPX页面"/>
    </div>
    </form>
</body>
</html>
