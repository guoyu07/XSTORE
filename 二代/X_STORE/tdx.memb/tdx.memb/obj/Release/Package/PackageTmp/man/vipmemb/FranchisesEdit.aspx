<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FranchisesEdit.aspx.cs" Inherits="tdx.memb.man.vipmemb.FranchisesEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript">
        function getSelectedValue_long() {
            var obj = document.getElementById("is_long");
            document.getElementById("long").value = obj.value;
        }
        function getSelectedValue_hf() {
            var obj = document.getElementById("group_id");
            document.getElementById("hf").value = obj.value;
        }
        function getFanWei() {
            var input = document.getElementsByName("fanwei");
            rank.value = "";
            //var input = document.getElementsByTagName("input");
            for (var i = 0; i < input.length; i++) {
                if (input[i].checked) {
                    if (rank.value != "" && rank.value != null) {
                        rank.value = rank.value + "," + input[i].value;
                    } else {
                        rank.value = rank.value + input[i].value;
                    }
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>配置会员卡特权信息</strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <asp:HiddenField ID="_csh" Value="" runat="server" />
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    特权名称
                </td>
                <td class="enter_content">
                    <input name="name"  placeholder="会员特权名称" id="name" runat="server"
                        class="px" maxlength="50" type="text" />
                    
                </td>
                <td class="rb">
                    *
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    特权范围
                </td>
                <td class="enter_content">
                    <asp:Literal ID="ylList" runat="server" EnableViewState="false"></asp:Literal>
                </td>
                <td>
                    <asp:HiddenField ID="rank" Value="" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    分组信息
                </td>
                <td class="enter_content">
                    <select name="group_id" runat="server" id="group_id" enableviewstate="false" onchange="getSelectedValue_hf();"
                        class="select-field_sousuo">
                    </select>
                     <a href="Group_franEdit.aspx">
                        <asp:Image ID="Image2" runat="server" ImageUrl="/man/images4/wh.png" />没有您想要的？点此添加
                    </a>
                </td>
                <td>
                    <asp:HiddenField ID="hf" Value="1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    描述
                </td>
                <td class="enter_content">
                    <textarea id="des" runat="server"  placeholder="会员特权的描述说明" class="px2"
                        cols="20" rows="2"></textarea>
                   
                </td>               
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                        value=" 保 存 " class="btnSave" type="button" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
