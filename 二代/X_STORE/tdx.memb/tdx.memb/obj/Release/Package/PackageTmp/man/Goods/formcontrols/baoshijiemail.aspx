<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baoshijiemail.aspx.cs" Inherits="tdx.memb.man.formcontrols.baoshijiemail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
       <title>实创科技后台管理系统</title>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js" charset="utf-8"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>邮件发送路径设置</h1>

    <div id="nei_content" class="nei_content">
      
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
                    <tbody>
                        <tr>
                            <td align="center" height="40" width="20%">
                                活动邮箱配置
                            </td>
                            <td width="50%">
                             
                               <textarea cols="80" rows="10" name="t_sort" id="huodong1" runat="Server"  placeholder="baoshijie@sina.com.cn"  ></textarea><br /><span style="color:Red">*邮箱之间务必用英文分号(;)间隔</span>
                            </td>
                                 <td  align="center" height="30">
                                <input name="btn_save" runat="server" id="Button1" value="测试活动邮件" class="btnGreen"  onserverclick="huodongsave"
                                    type="button" />
                            </td>
                        </tr>
                        <tr>
                            
                            <td align="center" height="40" width="20%">
                                服务邮箱配置
                            </td>
                            <td>
                                
                                 <textarea cols="80" rows="10" name="t_sort" id="fuwu1" runat="Server"  placeholder="baoshijie@sina.com.cn"  ></textarea><br /><span style="color:Red">*邮箱之间务必用英文分号(;)间隔</span>
                            </td>
                             <td  align="center" height="30">
                                <input name="btn_save" runat="server" id="Button2" value="测试服务邮件" class="btnGreen"  onserverclick="fuwusave"
                                    type="button" />
                            </td>
                        </tr>
                        <tr >
                            <td align="center" height="40" width="20%">
                                试驾邮箱配置
                            </td>
                            <td  height="100px">
                                <textarea cols="80" rows="10" name="t_sort" id="shiji" runat="Server"  placeholder="baoshijie@sina.com.cn"  ></textarea><br /><span style="color:Red">*邮箱之间务必用英文分号(;)间隔</span>
                            </td>
                            <td  align="center" height="30">
                                <input name="btn_save" runat="server" id="Button3" value="测试试驾邮件" class="btnGreen"  onserverclick="shijiasave"
                                    type="button" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" height="30">
                                <input name="btn_save" runat="server" id="btn_save" value=" 保 存 " class="btnGreen"  onserverclick="save"
                                    type="button" />
                            </td>
                        </tr>
                    </tbody>
                </table>
    </div>
    </form>
</body>
</html>
