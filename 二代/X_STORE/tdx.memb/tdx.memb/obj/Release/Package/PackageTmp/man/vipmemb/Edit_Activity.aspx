<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_Activity.aspx.cs" Inherits="tdx.memb.man.vipmemb.Edit_Activity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加会员活动</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%-- <script type="text/javascript" src="css/jquery.min.js"></script>--%>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/tdx_date.js"> </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#_Long").click(function () {
                $("#timeShow").hide();
            });
            $("#timeRange").click(function () {
                $("#timeshow").removeAttr("style");
                $("#timeShow").show();
            });
        });
    </script>
    <style type="text/css">
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>添加活动</strong></h1>
    <div id="nei_content" class="nei_content">
    <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>

        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <input type="hidden" id="beginDate" value="" runat="server" />
        <input type="hidden" id="endDate" value="" runat="server" />
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    活动名称
                </td>
                <td class="enter_content">
                    <input name="activity_name" placeholder="请输入活动名称" runat="server" id="activity_name"
                        class="px" maxlength="50" type="text" />                    
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    时间范围
                </td>
                <td class="enter_content">
                    <input name="timeRegion" id="_Long" runat="server" onselect="btn_long" type="radio" />长期有效
                    <input name="timeRegion" id="timeRange" runat="server" onselect="btn_time" type="radio" />时间范围
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <div runat="server" id="timeShow">
                        &nbsp;&nbsp;从 &nbsp;&nbsp;<input type="text" name="start_time" onfocus="HS_setDate(this)"
                            readonly="readonly" runat="server" id="start_time" value="" class="px" style="width: 85px;" />&nbsp;&nbsp;
                        至 &nbsp;&nbsp;<input type="text" runat="server" name="end_time" id="end_time" onfocus="HS_setDate(this)"
                            value="" readonly="readonly" class="px" style="width: 85px;" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    活动说明
                </td>
                <td class="enter_content">
                    <textarea id="activity_state" rows="2" name="activity_state" runat="server" placeholder="活动说明"
                        class="px2" ></textarea>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td>
                    <input name="btn_Add" runat="server" onserverclick="btn_Save_ServerClick" id="btn_Add"
                        value=" 保存 " class="btnSave" type="button" />
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div class="enter_remind">
        </div>
    </div>
    <!--内容-->
    <!--内容结束-->
    </form>
</body>
</html>
