<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saleChartTuan.aspx.cs" Inherits="tdx.memb.man.tuan.OrdersManage.saleChartTuan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="build/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />

</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>团购商品销量报表</span>
            <i class="arrow"></i>
            <span>团购商品销量报表</span>
        </div>

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">开始时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_start" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">结束时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_end" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>
                        <li>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LBtn_Export" runat="server" OnClick="LBtn_Export_Click" ><span>导出订单销量</span></asp:LinkButton></li>
                                                <li>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LBtn_Export_Click1" ><span>导出订单销售额运费</span></asp:LinkButton></li>

                    </ul>
                </div>
            </div>




        </div>
        <!--/工具栏-->

        <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
        <div class="chart_1">
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
                        'echarts/chart/bar' // 使用柱状图就加载bar模块，按需加载
                    ],
                     function (ec) {
                         // 基于准备好的dom，初始化echarts图表
                         var myChart = ec.init(document.getElementById('main'));

                         var option = {
                             title: {
                                 text: '订单销量曲线图',
                                 subtext: '整体数据'
                             },
                             tooltip: {
                                 trigger: 'axis'
                             }, legend: {
                                 data: ['订单数/销售额']
                             },

                             legend: {
                                 data: ['订单数', '销售额']
                             },

                             calculable: true,
                             xAxis: [
                                 {
                                     type: 'category',
                                     data: [<%=strs%>]
                                }
                            ],
                            yAxis: [
                                //{
                                //    type: 'value'
                                //}

                            {
                                type: 'value',
                                name: '订单数',
                                min: 0,
                                max: 100,
                                interval: 10,
                                axisLabel: {
                                    formatter: '{value} 单'
                                }
                            },
                        {
                            type: 'value',
                            name: '销售额',
                            min: 0,
                            max: 10000,
                            interval: 1000,
                            axisLabel: {
                                formatter: '{value} 元'
                            }
                        }

                            ],
                            series: [
                                {
                                    name: '订单数',
                                    type: 'bar',
                                    data: [<%=str%>],
                                },

                         {
                             name: '销售额',
                             type: 'bar',
                             yAxisIndex: 1,
                             data: [<%=strsm%>],
                         }

                            ]
                        };

                         // 为echarts对象加载数据
                         myChart.setOption(option);
                     }
        );
            </script>



        </div>
             </ContentTemplate>
   </asp:UpdatePanel>


    </form>
</body>
</html>
