<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="peihuoxinxi.aspx.cs" Inherits="tdx.memb.man.jiesuan.peihuoxinxi" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="build/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        //查看物流
        function look_wuliu(sender) {
            var obj = $(sender);
            var wlgs = obj.attr("gs");//公司
            var wldh = obj.attr("dh");//单号
            $.ajax({
                type: "post",
                datatype: "text",
                url: "lookkd.ashx",
                data: {
                    wuliu: wlgs,
                    danhao: wldh
                },
                success: function (detail) {
                    location.href = detail;
                }
            });
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="location">
        </div>
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">酒店名</span>&nbsp;<asp:TextBox ID="txt_hotel" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                        </li>
                        <li><span style="font-size: 12px;">状态</span>&nbsp; 
                                <asp:DropDownList CssClass="input" ID="ddl_zt" runat="server"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">配货完成</asp:ListItem>
                                    <asp:ListItem Value="2">申请配货中</asp:ListItem>
                                    <asp:ListItem Value="3">发货中</asp:ListItem>
                                    <asp:ListItem Value="4">出库</asp:ListItem>
                                </asp:DropDownList>
                        </li>
                    </ul>
                    <br />
                    <ul class="icon-list">

                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">开始时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_start" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">结束时间</span>&nbsp;<input type="text" class="input normal Wdate" runat="server" id="txt_end" onclick="WdatePicker()" /></li>
                        <li>&nbsp;&nbsp;<asp:LinkButton runat="server" ID="sousuo_click" Text="搜索" OnClick="sousuo_Click" /></li>
                        <li>
                            <asp:LinkButton ID="LBtn_Export" runat="server" OnClick="LBtn_Export_Click" CssClass="add"><i></i><span>导出</span></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
            <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th style="width: 11%">选择</th>
                    <th style="width: 11%">配货员</th>
                    <th style="width: 11%">时间</th>
                    <th style="width: 11%">数量</th>
                    <th style="width: 11%">品名</th>
                    <th style="width: 11%">酒店</th>
                    <th style="width: 11%">酒店集团</th>
                    <th style="width: 11%">状态</th>
                </tr>
                <asp:Repeater ID="Rp_phxx" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                            </td>
                            <td style="text-align: center;"><%#Eval("操作员")%></td>
                            <td style="text-align: center;"><%#Eval("时间")%></td>
                            <td style="text-align: center;"><%#Eval("数量")%></td>
                            <td style="text-align: center;"><%#Eval("品名")%></td>
                            <td style="text-align: center;"><%#Eval("仓库名")%></td>
                            <td style="text-align: center;"><%#Eval("酒店全称")%></td>
                            <td style="text-align: center; display: <%#Getzt1(Eval("状态").ObjToStr())%>">
                                <%#Getzt(Eval("状态").ObjToStr())%>
                            </td>
                            <%--配货完成--%>
                            <td style="text-align: center; display: <%#Getzt2(Eval("状态").ObjToStr())%>">
                                <a href='Collocate.aspx?zt=<%#Eval("状态")%>&ckid=<%#Eval("仓库id") %>&id=<%#Eval("id") %>'><%#Getzt(Eval("状态").ObjToStr())%></a>
                            </td>
                            <%--配货申请清单--%>
                            <td style="text-align: center; display: <%#Getzt3(Eval("状态").ObjToStr())%>">
                                <a href="javascript:void(0);" onclick='look_wuliu(this)' gs='<%#Eval("物流公司") %>' dh='<%#Eval("物流单号") %>'><%#Getzt(Eval("状态").ObjToStr())%></a>
                            </td>
                            <%--物流单--%>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div id="tdh">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator"
                    NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>
        </div>

    </form>
</body>
</html>
