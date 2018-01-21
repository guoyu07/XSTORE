<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_mp_add.aspx.cs" Inherits="tdx.memb.man.Sets.wx_mp_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../../js/wx_mp_add.js" type="text/javascript"></script>
</head>
<body>
    <!--中间开始-->
   
    <form id="form1" runat="server">
    <h1>
        <strong>公众号配置</strong>
    </h1>    
    <div class="nei_content" id="nei_content">
    <asp:Literal ID="daohang_Image" runat="server"></asp:Literal>
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
        <!--center content-->
        <table class="enter_table">
            <tbody>
                <tr>
                    <td class="enter_title">
                        微信号
                    </td>
                    <td class="enter_content">
                        <input type="text" name="txtName" placeholder="输入用户对应微信号" class="px" runat="server"
                            id="txtName" maxlength="50" point_url="../images4/wx_mp_add/txtName.jpg" />
                    </td>
                    <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        昵称
                    </td>
                    <td class="enter_content">
                        <input type="text" name="txtNichen" placeholder="名称" class="px" runat="server" id="txtNichen"
                            maxlength="50" point_url="../images4/wx_mp_add/txtNichen.jpg" />
                    </td>
                    <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        原始ID
                    </td>
                    <td class="enter_content">
                        <input type="text" name="txtGUID" placeholder="以gh_开头的15位字母数字组合" class="px" runat="server"
                            id="txtGUID" maxlength="50" point_url="../images4/wx_mp_add/txtGUID.jpg" /><br />
                        <span class="gray">必填,否则微网站无法正确显示</span>
                    </td>
                    <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        AppId
                    </td>
                    <td class="enter_content">
                        <input type="text" name="txtDID" placeholder="请输入AppId" class="px" runat="server"
                            id="txtDID" maxlength="50" point_url="../images4/wx_mp_add/txtDpsw.jpg" />
                        <br />
                        <span class="gray">认证订阅号、服务号、认证服务号此项必填。否则，公众号菜单等功能将失败</span>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        AppSecret
                    </td>
                    <td class="enter_content">
                        <input type="text" name="txtDpsw" placeholder="请输入AppSelect" class="px" runat="server"
                            id="txtDpsw" maxlength="50" point_url="../images4/wx_mp_add/txtDpsw.jpg" />
                        <br />
                        <span class="gray">认证订阅号、服务号、认证服务号此项必填。否则，公众号菜单等功能将失败</span>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        关键词回复模式
                    </td>
                    <td class="enter_content">
                        <input type="radio" id="RD_isGif1" value="0" name="RD_isGif" runat="server" />文字模式<input
                            type="radio" id="RD_isGif2" value="1" name="RD_isGif" runat="server" checked />图文模式
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        二维码
                    </td>
                    <td class="enter_content">
                        <input type="file" name="txtGif" class="px" runat="server" id="txtGif" maxlength="255"
                            point_url="../images4/wx_mp_add/txtGif.jpg" />
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        描述
                    </td>
                    <td class="enter_content">
                        <textarea id="txtms" cols="20" placeholder="请输入描述信息" rows="2" name="txtms" runat="server"
                            class="px2"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        类型
                    </td>
                    <td class="enter_content">
                        <input type="radio" id="RD_Cid1" value="0" name="RD_Cid" runat="server" checked />订阅号<input
                            type="radio" id="RD_Cid3" value="2" name="RD_Cid" runat="server" />认证订阅号<input
                            type="radio" id="RD_Cid2" value="1" name="RD_Cid" runat="server" />服务号<input
                            type="radio" id="RD_Cid4" value="1" name="RD_Cid" runat="server" />认证服务号
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        服务器配置
                    </td>
                    <td>                      
                        <div class="greenRemind">
                            <abbr>
                            </abbr>
                            <span  point_url="../images4/wx_mp_add/btnfwq.jpg" id="btnfwq">开发模式URL:
                                 <asp:Literal ID="lt_kfzURL" runat="server"></asp:Literal>
                                <br />
                                开发者Token: tdx8888889Z<br />
                               
                            点击查看如何配置服务器    </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input type="button" value=" 保 存 " class="btnSave" runat="server" id="Button1" onserverclick="Button1_ServerClick" />
                    </td>
                </tr>
                <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
            </tbody>
        </table>
        <div class="enter_remind">
        </div>
    </div>
    </form>
</body>
</html>
