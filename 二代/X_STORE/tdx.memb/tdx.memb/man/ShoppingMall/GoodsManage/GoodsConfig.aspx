<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsConfig.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GoodsManage.GoodsConfig" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/select2.js"></script>
    <link href="../../css/select2.css" rel="stylesheet" />


      <script type="text/javascript">
          $(function () {
              $('table').on('onchange', '.hidid_class', function () {
                  alert("1");
                  var number = "";
                  $(".hidid_class").each(function () {
                      number += $(this).val() + ",";//数量
                  });
                  document.getElementById("Bindlist_hidd").value = number;//所有值
                  var id = "";
                  $("#table_add").find(":hidden").each(function () {
                      id += $(this).val() + ",";
                  });
                  document.getElementById("all_id").value = id;//所有id
                  document.getElementById("bt_click").click();

              });
          });
          </script>
          <script language="JavaScript">
          function load(){
              window.location.reload();
          }

      

        </script>
    <%--<style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <%--<telerik:RadAjaxPanel runat="server">--%>
        <asp:HiddenField ID="hidd_goods_id" runat="server" Value=""/>
         <asp:HiddenField ID="Bindlist_hidd" runat="server" Value=""/><%--获取所有的input中的值--%>
        <asp:HiddenField ID="all_id" runat="server" Value="" /><%--所有id--%>
    <div>

     <table style="width:100%" border="1" class="ltable" id="table_add">
                    <tr>
                        <th style="width:10%">选择</th>
                        <%--<th style="width:30%">组名</th>--%>
                        <th style="width:15%">品名</th>
                        <th style="width:15%">规格</th>
                        <th style="width:10%">单位</th>
                        <th style="width:10%">数量</th>
                    </tr>
                    <asp:Repeater ID="sptList1" runat="server">
                        <ItemTemplate>
                            <tr id="tr_add">
                                <td style="text-align: center;">
                                <asp:CheckBox name="angel" ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />

                                    <asp:HiddenField ID="hidId" Value='<%#Eval("主商品id")%>' runat="server" />
                                </td>
                                <%--<td style="text-align: center;"><%#Eval("组名")%></td>--%>
                                <td style="text-align: center;"><%#Eval("品名")%></td>
                                <td style="text-align: center;"><%#Eval("规格")%></td>
                                <td style="text-align: center;"><%#Eval("单位")%></td>
                                <td style="text-align: center;">
                                    <asp:TextBox runat="server" OnTextChanged="num_TextChanged" product-id ='<%#Eval("主商品id")%>'  AutoPostBack="true" value='<%#Eval("数量") %>'></asp:TextBox>
                                    <%--<input id="input_a" name="number" style="text-align: center;" class="hidid_class" value='<%#   Eval("数量")%>' />--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
    </div>
        <div>
                <telerik:RadComboBox style="width:150px"  ID="group_name" runat="server" MaxHeight="203" LocalizationPath="~/Language" DataTextField="品名" DataValueField="id" Filter="Contains" MarkFirstMatch="true" AppendDataBoundItems="true" ShowToggleImage="false" AllowCustomText="true" AutoPostBack="true">
                        <ItemTemplate>
                            <%# Eval("品名") %><span style="display: none;"><%# Eval("品名") %></span>
                        </ItemTemplate>
                    </telerik:RadComboBox>
            <%--<asp:LinkButton ID="lb_add" runat="server" Text="添加" class="btn" OnClick="add_click"></asp:LinkButton> --%>
            <asp:LinkButton ID="lb_save" runat="server" Text="添加" class="btn" OnClick="save_combo" OnClientClick="load();"></asp:LinkButton> 
             <asp:LinkButton ID="lb_del" runat="server" Text="删除" class="btn" OnClick="del_goods"></asp:LinkButton> 
           <%-- <asp:LinkButton ID="bt_click" runat="server" OnClick="update_combo"  visibility="false"></asp:LinkButton>--%>
            </div>
           <%-- </telerik:RadAjaxPanel>--%>
    </form>
</body>
</html>
