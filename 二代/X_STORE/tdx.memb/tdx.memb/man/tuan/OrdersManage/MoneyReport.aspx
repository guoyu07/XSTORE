<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoneyReport.aspx.cs" Inherits="tdx.memb.man.Tuan.OrdersManage.MoneyReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="../skin/default/style.css" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script   type="text/javascript" src="build/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <!--导航栏-->
        <div class="location divlefttop2">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>单日销售额折线图</span>
        </div>
        <!--/导航栏-->
        <div style="width: 90%; margin-left: auto; margin-right: auto;"><br/>
            <div  class="navclass">商家姓名<input type="text" class="input normal" style="width:150px;" runat="server" id="txt_name"  />&nbsp;&nbsp;&nbsp;起始日期<input type="text" class="input normal Wdate" style="width:150px;"  runat="server" id="Jxl" onClick="WdatePicker()" />&nbsp;&nbsp;&nbsp;结束日期<input type="text" class="input normal Wdate" style="width:150px;"  runat="server" id="Jx2"  onClick="    WdatePicker()"/> &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="sousuo" runat="server" Text="" OnClick="sousuo_Click" CssClass="btn"><span style="color:#ffffff;font-size:14px;">搜索</span></asp:LinkButton> </div>
        </div><br/>
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
                    'echarts/chart/line' // 使用柱状图就加载bar模块，按需加载
                ],
                function (ec) {
                    // 基于准备好的dom，初始化echarts图表
                    var myChart = ec.init(document.getElementById('main'));

                    var option = {
                        title: {
                            text: '单日销售额折线图',
                            subtext: '整体数据'
                        },
                        tooltip: {
                            trigger: 'axis'
                        },
                        legend: {
                            data: ['单日销售额折线图']
                        },

                        calculable: true,
                        xAxis: [
                            {
                                type: 'category',
                                data: [<%=strs%>]
                            }
                        ],
                        yAxis: [
                            {
                                type: 'value'
                            }
                        ],
                        series: [
                            {
                                name: '单日销售额折线图',
                                type: 'line',
                                data: [<%=str%>],
                                markPoint: {
                                    data: [
                                        { type: 'max', name: '最大值' },
                                        { type: 'min', name: '最小值' }
                                    ]
                                },
                                markLine: {
                                    data: [
                                        { type: 'average', name: '平均值' }
                                    ]
                                }
                            }
                        ]
                    };

                    // 为echarts对象加载数据
                    myChart.setOption(option);
                }
        );
        </script>

        <script type="text/javascript">
            laydate({
                elem: document.getElementById('Jxl')
            });
            laydate({
                elem: document.getElementById('Jx2')
            });
        </script>

    </form>
</body>
</html>
