<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelWarehousekw.aspx.cs" Inherits="tdx.memb.man.HotelWarehouse.HotelWarehousekw" %>
<%@ Register TagPrefix="Feli" Namespace="FeliControls" Assembly="tdx.memb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>doubi</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
            <link href="../css/pagerStyle.css" rel="stylesheet" />
    <style type="text/css">
         .icon-list li {
            font-family: 微软雅黑;
            color: #666;
            margin-right: 15px;
            font-size: 12px;
        }

        .icon-list li input {
            margin: 5px;
            border: 1px solid #dddddd;
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!--导航栏-->
   <div class="location">
             <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
              <a class="home"><i></i><span>首页</span></a>
              <i class="arrow"></i>
              <span>房间设置</span>
        </div>
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>关键词:<asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" /></li>
                    </ul>
                </div>
                  <div class="r-list">
                    <ul class="icon-list">
                        <li>
                            <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                        </li>
                    </ul>
                </div>
              <div class="clearfix">
                  
              </div>
               <div class="l-list">
                    <ul class="icon-list">
                      <li><a class="add" href="HotelWarehousekwAdd.aspx"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton>
                        </li>
                        </ul>
                </div>
            </div>

            <!--列表-->
            <table style="width:100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th style="width: 50px;">选择</th>
                    <th style="width: 150px; text-align: left;">酒店集团</th>
                    <th style="width:150px; text-align: left;">酒店名</th>
                    <th style="width:150px; text-align: left;">房间名称</th>
                    <th style="width:150px; text-align: left;">MAC</th>
                    <th style="width:150px; ">操作</th>
                </tr>
                <asp:Repeater ID="Rp_hotelwarehousebox" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                <asp:HiddenField ID="hidId" Value='<%#Eval("库位id")%>' runat="server" />
                            </td>
                            <td style="text-align: left;"><%#Eval("酒店全称")%><br />
                            </td>
                            <td style="text-align: left;"><%#Eval("仓库")%></td>
                            <td style="text-align: left;"><%#Eval("库位")%></td>
                             <td style="text-align: left;"><%#Eval("箱子MAC")%></td>
                            <td style="text-align: center;" runat="server">
                                    <a class="add" href="HotelWarehouseBoxEdit.aspx?id=<%#Eval("库位id")%>">修改</a>|
                                   <a class="add"  href='../Box/BoxManage.aspx?id=<%#Eval("库位id")%>' value='<%#Eval("库位id")%>'>箱子配置</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    <%#Rp_hotelwarehousebox.Items.Count == 0 ? "<tr><td align='center' colspan='6'>暂无记录</td></tr>" : ""%>
                </FooterTemplate>
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
