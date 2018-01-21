<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoxGoods.aspx.cs" Inherits="tdx.memb.man.Box.BoxGoods" %>
<%--<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="location">
        </div>
         <!--工具栏-->
       &nbsp;&nbsp;&nbsp;&nbsp;  <div class="toolbar-wrap">
                <div class="rule-single-select"  style="float:left;margin-top:10px;" >
                     <ul class="icon-list">
                        <li>
                                <asp:DropDownList ID="ddlA_is_name"  runat="server" CssClass="btn">
                                <asp:ListItem Value="1">酒店</asp:ListItem>
                                <asp:ListItem Value="2">仓库</asp:ListItem>
                                <asp:ListItem Value="3">库位</asp:ListItem>
                                </asp:DropDownList>
                         </li>
                       </ul>
                  </div>
                <div class="toolbar" >
                    <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">名称</span>&nbsp;<asp:TextBox ID="txt_mingcheng" runat="server" CssClass="input" datatype="*0-100" sucmsg=" "/></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">mac</span>&nbsp;<asp:TextBox ID="txt_mac" runat="server" CssClass="input" datatype="*0-100" sucmsg=" "/></li>
                    </ul>
                    </div>
                <div class="l-list" >
                    <ul class="icon-list">
                         <li> &nbsp;&nbsp;&nbsp;&nbsp; 
                             <asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click">搜索
                             </asp:LinkButton>
                         </li>
                    </ul>
                </div>
            </div>

            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="BoxEdit.aspx?boxid=0"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        <%--<li>
                            <asp:LinkButton ID="LBtn_Export" runat="server" OnClick="LBtn_Export_Click" CssClass="add"><i></i><span>导出</span></asp:LinkButton></li>--%>
                    </ul>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th align="center">选择</th>
                <th align="center">酒店</th>
                <th align="center">仓库</th>
                <th align="center">库位</th>
                <th align="center">MAC</th>
                <th align="center">位置<br />
                    默认商品<br />
                    实际商品</th>
                <th align="center" colspan="3">操作</th>
            </tr>
            <asp:Repeater ID="sptList1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox name="angel" ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" runat="server" Value='<%#Eval("箱子id") %>' />
                        </td>
                        <td style="text-align: center">
                            <%#Eval("酒店全称") %>
                        </td>
                        <td style="text-align: center;"><%#Eval("仓库")%></td>
                        <td style="text-align: center;"><%#Eval("库位")%></td>
                        <td style="text-align: center;"><%#Eval("mac") %></td>
                        <td style="text-align: center;"><%#Eval("位置")%><br />
                            <%#Eval("默认商品")%><br />
                            <%#Eval("实际商品")%><br />
                        </td>
                        <td style="text-align: center;"><a href='BoxEdit.aspx?kw=<%#Eval("库位id")%>&boxid=<%#Eval("箱子id") %>&wz=<%#Eval("位置") %>'>修改</a></td>
                    </tr>
                </ItemTemplate>
                   <FooterTemplate>
                            <%#sptList1.Items.Count == 0 ? "<tr><td align='center' colspan='6'>暂无记录</td></tr>" : ""%>
                     </FooterTemplate>
                <FooterTemplate>
                              <% %>
                </FooterTemplate>
            </asp:Repeater>
            <%-- 分页 --%>
        </table>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="" LastPageText=""
                        NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CssClass="pages" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                      </webdiyer:AspNetPager>
        <!--/列表-->
    </form>
</body>
</html>
