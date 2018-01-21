<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegionEdit.aspx.cs" Inherits="tdx.memb.man.HotelWarehouse.RegionEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $('#txt_AreaCode').on('blur', function () {
                reg = /^\d{4}$/;
                if (!reg.test($('#txt_AreaCode').val())) {
                    alert($('#txt_AreaCode').val());
                    $("#qh").html("<b>您输入的区号格式错误，请重新输入</b>");   
                } else {
                    alert('2');
                    $.ajax({
                        url: 'AreaCode.ashx',
                        type: 'Post',
                        data: {
                            qh: $('#txt_AreaCode').val()
                        },
                        dataType: 'json',
                        success: function (result) {
                            $("#qh").html(result.info);
                        }
                    })
                }   
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>地区管理</span>
        </div>
        <div class="tab-content">
           <dl>
                <dt>地区&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txt_region" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>区号&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txt_AreaCode" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                    <span class="Validform_checktip" runat="server" id="qh"></span>
                </dd>
            </dl>
        </div>
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button runat="server" Text="提交保存" CssClass="btn" ID="btnSave" OnClick="btnSave_Click"/>
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" 
                    onclick="javascript: history.back(-1);" />
            </div>
        </div>
    </form>
    
</body>
</html>
