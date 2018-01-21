<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="salesPie.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.OrdersManage.salesPie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                <!-- 为ECharts准备一个具备大小（宽高）的Dom -->
        <div id="main" style="height: 400px"></div>
        <!-- ECharts单文件引入 -->     
        <script src="build/dist/echarts.js"></script>
         <script type="text/javascript">
             // 路径配置
             require.config({
                 paths: {
                     echarts: 'build/dist'
                 }
             });

             // 使用
             require(
                 [
                     'echarts',
                     'echarts/chart/pie' // 使用柱状图就加载bar模块，按需加载
                 ],
                 function (ec) {
                     // 基于准备好的dom，初始化echarts图表
                     var myChart = ec.init(document.getElementById('main'));

                     option = {
                         title: {
                             text: '销售报表',
                             subtext: '2016年3月',
                             x: 'center'
                         },
                         tooltip: {
                             trigger: 'item',
                             formatter: "{a} <br/>{b} : {c} ({d}%)"
                         },
                         legend: {
                             orient: 'vertical',
                             x: 'left',
                             data: ['羽毛球', '网球', '乒乓球', '篮球', '击剑','瑜伽','钢管舞','拳击','其他']
                         },
                         toolbox: {
                             show: true,
                             feature: {
                                 mark: { show: true },
                                 dataView: { show: true, readOnly: false },
                                 magicType: {
                                     show: true,
                                     type: ['pie', 'funnel'],
                                     option: {
                                         funnel: {
                                             x: '25%',
                                             width: '50%',
                                             funnelAlign: 'left',
                                             max: 1548
                                         }
                                     }
                                 },
                                 restore: { show: true },
                                 saveAsImage: { show: true }
                             }
                         },
                         calculable: true,
                         series: [
                             {
                                 name: '访问来源',
                                 type: 'pie',
                                 radius: '55%',
                                 center: ['50%', '60%'],
                                 data: [
                                     { value: 335, name: '羽毛球' },
                                     { value: 310, name: '网球' },
                                     { value: 234, name: '乒乓球' },
                                     { value: 635, name: '篮球' },
                                     { value: 18, name: '击剑' },
                                     { value: 189, name: '瑜伽' },
                                     { value: 248, name: '钢管舞' },
                                     { value: 548, name: '拳击' },
                                     { value: 158, name: '其他' },
                                 ]
                             }
                         ]
                     };


                     // 为echarts对象加载数据
                     myChart.setOption(option);
                 }
        );
        </script>
    </div>
    </form>
</body>
</html>
