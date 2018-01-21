<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelDailySalesRank.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.OrdersManage.HotelDailySalesRank" %>

<%@ Register TagPrefix="Feli" Namespace="FeliControls" Assembly="tdx.memb" %>
<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>酒店累计业绩排行</title>
        <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="build/My97DatePicker/WdatePicker.js"></script>

    <link href="../../css/pagerStyle.css" rel="stylesheet" />
    <style type="text/css">
         .icon-list li {
             font-family: 微软雅黑;
             color: #666;
             margin-right: 15px;
             font-size: 12px;
         }
         .icon-list li input{
             margin: 5px; 
             border: 1px solid #dddddd;
             height: 25px;
         }

         .timeclick {
             width: 100px;
         }
         .total-list li {

             margin: 5px;
             float: left;
         }
         .font-total {
             font-size: 18px;
              color: #50BDFF;
               font-weight: bolder;
         }

    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
             <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
              <a class="home"><i></i><span>首页</span></a>
              <i class="arrow"></i>
              <span>酒店单日业绩排行</span>
        </div>
        <!--工具栏-->
        
        
        <div class="hotelSalesRankList">
            
            <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th style="width: 10%">序号</th>
                    <th style="width: 10%">酒店</th>
                    <th style="width: 10%">房间数</th>
                    <th style="width: 10%">销量 </th>
                    <th style="width: 10%">金额</th>
                    <th style="width: 10%">日均房</th>
                    <th style="width: 10%">日期</th>
                </tr>
                <asp:Repeater ID="hotelSalesRankList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;"><%#Container.ItemIndex.ObjToInt(0)+1%></td>
                            <td style="text-align: center;"><%#Eval("酒店名称")%></td>
                             <td style="text-align: center;"><%#Eval("房间数")%></td>
                               <td style="text-align: center;"><%#Eval("销量")%></td>
                            <td style="text-align: center;"><%#Eval("当日销售额")%></td>
                            <td style="text-align: center;"><%#Eval("日均房")%></td>
                            <td style="text-align: center;"><%#string.IsNullOrEmpty(Eval("日期").ObjToStr())?"--":Eval("日期").ObjToStr()%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="page-footer">
                <div class="btn-list">
                    <Feli:Pager ID="fpgHistoryList" CssClass="pager" runat="server" OnPageIndexChanged="fpgHistoryList_PageIndexChanged" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>