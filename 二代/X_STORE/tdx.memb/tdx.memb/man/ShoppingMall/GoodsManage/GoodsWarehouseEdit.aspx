<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsWarehouseEdit.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GoodsManage.GoodsWarehouseEdit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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

    <!--百度编辑器!-->
    <script src="../../../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../../../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script src="../../../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var UEDITOR_HOME_URL = "./ueditor/"; //从项目的根目录开始
    </script>
    <script src="../../js/jquery-ui.js"></script>
    <script src="../../../scripts/swfupload/swfupload.js"></script>
    <script src="../../../scripts/swfupload/swfupload.handlers.js"></script>
    <script src="../../../scripts/swfupload/swfupload.queue.js"></script>
    <%--    <script src="../../js/form_common.js"></script>
    <script src="../../js/layout.js"></script>--%>
    <script src="../../../Scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">

        function AjaxAdd() {
            $("#Bindlist").val("1");
            var bianhao = $("#txt_bianhao").val();
            var leibie = $("#txt_leibiehao").val();
            var pinming = $("#txt_pinming").val();
            var danwei = $("#txt_danwei").val();
            var kucun = $("#txtcritical_value").val();
            var yunfeimoban = $("#yunfeimoban").val();
            var Bdate = $("#Jxl").val();
            var Edate = $("#Jx2").val();
            var isshow = $("#txt_shifoushangjia").val();
            var fenxiaolv = $("#txt_zhekou").val();
            var yunfei = $("#txt_yunfei").val();
            var baoyou = $("#txt_baoyou").val();
            var jsonstr = "[";
            var tableObj = document.getElementById("tabId");
            var AddorEdit = $("#AddorEdit").val();//编辑是0新增是1
            var starRow = "2";
            //if (AddorEdit != "1")
            //{
            //    starRow = "3";
            //}
            for (var i = starRow; i < tableObj.rows.length; i++) //遍历Table的所有Row
            {
                jsonstr += "{";
                //  for (var j = 0; j < tableObj.rows[i].cells.length; j++) {   //遍历Row中的每一列
                //tableInfo += tableObj.rows[i].cells[j].innerText;   //获取Table中单元格的内容
                jsonstr += "\"j编号new\":\"" + tableObj.rows[i].cells[0].getElementsByTagName("INPUT")[0].value + "?" + tableObj.rows[i].cells[0].getElementsByTagName("INPUT")[1].value + "\",\"jid\":\"" + tableObj.rows[i].cells[0].getElementsByTagName("INPUT")[1].value + "\",\"j规格\":\"" + tableObj.rows[i].cells[1].getElementsByTagName("INPUT")[0].value + "\",\"j重量\":\"" + tableObj.rows[i].cells[2].getElementsByTagName("INPUT")[0].value + "\",\"j市场价\":\"" + tableObj.rows[i].cells[3].getElementsByTagName("INPUT")[0].value + "\",\"j本站价\":\"" + tableObj.rows[i].cells[4].getElementsByTagName("INPUT")[0].value + "\",\"j库存\":\"" + tableObj.rows[i].cells[5].getElementsByTagName("INPUT")[0].value + "\"  ";
                // }
                jsonstr += "},";
            }
            jsonstr = jsonstr.substring(0, jsonstr.length - 1);
            jsonstr += "]";
            // alert(jsonstr + tableObj.rows.length);                     
            $.ajax({
                type: "post",
                datatype: "text",
                url: "Editrows.ashx",
                data: { jsonstr: jsonstr, bianhao: bianhao, leibie: leibie, pinming: pinming, danwei: danwei, kucun: kucun, yunfeimoban: yunfeimoban, Bdate: Bdate, Edate: Edate, isshow: isshow, fenxiaolv: fenxiaolv, yunfei: yunfei, baoyou: baoyou, AddorEdit: AddorEdit },
                async: false,
                success: function (data) {
                    if (data == "1") {
                        //alert('操作成功');
                        //location.reload(true);
                        //int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                        //BindList(id);
                        //ltrTr.Text = "";
                        //$("#Bindlist").val("0");
                        //location.replace(location.href);
                        //window.location.reload();
                    }
                }
            })
        }

        //$("#酒店aspx").change(function(){
        //    //在这里面进行异步提交
        //    $.ajax({
        //        type: "GET",//get提交
        //        url: "FuzzyQuery.ashx.cs",//服务器文件
        //        data: { "key": $("#酒店aspx").val() },
        //        dataType: "json",
        //        success: function (data) {
        //            //这里面就是你所得到的json数据，当然是个数组，进行遍历就好了     
        //        }
        //    });
        //});

    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>仓库管理</span> <i class="arrow"></i><span>仓库管理</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <%-- 商品 --%>
        <div class="tab-content   dropup">
                <dl>
                <dt>酒店</dt>
                <dd>
                    <input id="input1" runat="server" type="hidden" />
                    <ul class="icon-list"> 
                            <li class="rule-single-select">
                                                <asp:DropDownList ID="grogshop_name"  runat="server" CssClass="btn">
                                                <asp:ListItem Value="0">酒店名</asp:ListItem>
                                                </asp:DropDownList>
                                            </li>
                      </ul>
                </dd>
            </dl>
                <dl>
                <dt>仓库</dt>
                <dd>
                    <input id="input" runat="server" type="hidden" />
                    <asp:TextBox ID="warehouse" runat="server" placeholder="仓库名" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>

                </dd>
            </dl>
                <dl>
                <dt>库位</dt>
                <dd>
                    <input id="input3" runat="server" type="hidden" />
                    <asp:TextBox ID="storagelocation" runat="server" placeholder="库位名" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
                <dl>
                <dt>箱子</dt>
                <dd>
                    <input id="input4" runat="server" type="hidden" />
                    <asp:TextBox ID="box" runat="server" placeholder="箱子号" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
                <dl>
                <dt>MAC</dt>
                <dd>
                    <input id="input5" runat="server" type="hidden" />
                    <asp:TextBox ID="MACaspx" runat="server" placeholder="MAC" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
                <dl>
                <dt>位置</dt>
                <dd>
                    <input id="input6" runat="server" type="hidden" />
                    <asp:TextBox ID="location" runat="server" placeholder="位置" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
                <dl>
                <dt>默认商品</dt>
                <dd>
                    <ul class="icon-list">
                    <li class="rule-single-select">
                                        <asp:DropDownList ID="ddlA_default_goods"  runat="server" CssClass="btn" OnSelectedIndexChanged="ddlA_default_goods_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">类别</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                      
                    <li class="rule-single-select">
                                        <asp:DropDownList ID="ddlA_defaule_goods_name"  runat="server" CssClass="btn">
                                        <asp:ListItem Value="0">品名</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                        </ul>
               <%--     <input id="input7" runat="server" type="hidden" />
                    <asp:TextBox ID="default_goods" runat="server" placeholder="默认商品" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>--%>
                </dd>
            </dl>
                <dl>
                <dt>实际商品</dt>
                <dd>
                     <ul class="icon-list">
                    <li class="rule-single-select">
                                        <asp:DropDownList ID="ddlA_practical_goods"  runat="server" CssClass="btn" OnSelectedIndexChanged="ddlA_practical_goods_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">类别</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                         <li class="rule-single-select">
                                        <asp:DropDownList ID="ddlA_practical_goods_name"  runat="server" CssClass="btn">
                                        <asp:ListItem Value="0">品名</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                        </ul>
                 <%--   <input id="input8" runat="server" type="hidden" />
                    <asp:TextBox ID="practical_goods" runat="server" placeholder="实际商品" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>--%>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <br />
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="AjaxAdd()" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
        <!--/工具栏-->

     

    </form>
</body>
</html>
