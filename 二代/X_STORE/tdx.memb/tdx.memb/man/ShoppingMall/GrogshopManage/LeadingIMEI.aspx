<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeadingIMEI.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GrogshopManage.LeadingIMEI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>题目导入</title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <script type="text/javascript" src="js/layout.js"></script>
<link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();


        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
            <asp:HiddenField ID="hideid" runat="server" />
            <!--导航栏-->
            <div class="location">
                <a href="student_info_manage.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="center.aspx"
                    class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="ks_tiku_manage.aspx">
                        <span>公司人员</span></a> <i class="arrow"></i><span>导入员工</span>
            </div>
            <div class="line10">
            </div>
            <!--/导航栏-->
            <!--内容-->
            <div class="content-tab-wrap">
                <div id="floatHead" class="content-tab">
                    <div class="content-tab-ul-wrap">
                        <ul>
                            <li><a href="javascript:void(0);" class="selected">导入IMEI信息</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="tab-content">
                <dl>
                    <dt>IMEI导入</dt>
                    <dd>
                         <asp:FileUpload ID="FileUpload1" runat="server"/>
                    </dd>
                </dl>
                <dl>
                    <dt>Excel模板下载</dt>
                    <dd>
                        <asp:LinkButton ID="lbtdown" runat="server" onclick="lbtdown_Click">employee.xlsx</asp:LinkButton>
                    </dd>
                </dl>
            </div>
            <!--工具栏-->
            <div class="page-footer">
                <div class="btn-list">
                    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: window.history.back(-1)" />
                    <asp:Button ID="btnInsert" runat="server" Text="提交" CssClass="btn" OnClick="btnInsert_Click"  />
                </div>
                <div class="clear">
                </div>
            </div>
            <!--/工具栏-->

    </form>
</body>
</html>

