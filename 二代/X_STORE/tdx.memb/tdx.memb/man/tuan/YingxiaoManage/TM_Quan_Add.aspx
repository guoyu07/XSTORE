<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TM_Quan_Add.aspx.cs" Inherits="tdx.memb.man.Tuan.YingxiaoManage.TM_Quan_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑优惠券</title>
    <script src="../../../scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../scripts/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="../../../scripts/lhgdialog.js?skin=idialog" type="text/javascript"></script>
    <script src="../../JS/layout.js" type="text/javascript"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" />
    <link href="../../skin/nei.css" rel="stylesheet" />
    <script src="../OrdersManage/build/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" language="javascript">
        function checkRate(input) {
            var re = /^[0-9]+.?[0-9]*$/;   //判断字符串是否为数字     //判断正整数 /^[1-9]+[0-9]*]*$/  
            var nubmer = document.getElementById(input).value;

            if (!re.test(nubmer)) {
                alert("请输入数值型数据");
                document.getElementById(input).value = "";
                return false;
            }
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="TM_Quan_List.aspx"><span>优惠券管理</span></a>
            <i class="arrow"></i>
            <span>新增申请</span>
        </div>
        <div class="line10"></div>

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑优惠券</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">

            <dl>
                <dt>类别号</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList CssClass="input" ID="drp_types" runat="server"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>

            <dl>
                <dt>标题：</dt>
                <dd>
                    <asp:TextBox ID="txt_title" runat="server" class="px"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dl>
                    <dt>券获取条件：</dt>
                    <dd>
                        <asp:TextBox ID="txt_q_Getmoney" onkeyup="checkRate(this.id)" runat="server" class="px"></asp:TextBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>券使用条件：</dt>
                    <dd>
                        <asp:TextBox ID="txt_qTmoney" onkeyup="checkRate(this.id)" runat="server" class="px"></asp:TextBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>

                <dt>券金额：</dt>
                <dd>
                    <asp:TextBox ID="txt_Tmoney" onkeyup="checkRate(this.id)" runat="server" class="px"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>数量：</dt>
                <dd>
                    <asp:TextBox ID="txt_Jmoney" onkeyup="checkRate(this.id)" runat="server" class="px"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>开始日期：</dt>
                <dd>
                    <input type="text" class="input normal Wdate" runat="server" id="Jxl" onclick="WdatePicker()" />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>结束日期：</dt>
                <dd>
                    <input type="text" class="input normal  Wdate" runat="server" id="Jx2" onclick="    WdatePicker()" />
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
        </div>
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>

    </form>
</body>
</html>
