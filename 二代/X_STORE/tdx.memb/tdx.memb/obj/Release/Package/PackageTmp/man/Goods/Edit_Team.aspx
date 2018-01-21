<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_Team.aspx.cs" Inherits="tdx.memb.man.Goods.Edit_Team" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link href="../images4/nei.css" type="text/css" rel="stylesheet">
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../../js/tdx_date.js" type="text/javascript"></script>
    <title>后台管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>团购处理</strong></h1>
    <div class="nei_content" id="nei_content">
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
             
        <table class="enter_table">
            <tbody>
                <tr>
                    <td class="enter_title">
                        团购项目名称
                    </td>
                    <td class="enter_content">
                        <input name="tm_title" placeholder="团购项目名称,便于记忆,最多100个字符	" runat="Server" id="tm_title" class="px" maxlength="255" type="text" /><br />
                        <span class="gray">团购项目名称,便于记忆,最多100个字符</span><br />
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">
                        成团条件限制1
                    </td>
                    <td class="enter_content">
                        <input name="tm_tiaojian" runat="Server"  id="tm_tiaojian" class="px" maxlength="255"
                            type="text" placeholder="0" /><br />
                            <span class="gray">最低成团条件，最低几个人购买成团。</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        成团条件限制2
                    </td>
                    <td class="enter_content">
                        <input name="tm_tiaojian2" runat="Server" id="tm_tiaojian2" class="px" maxlength="255"
                            type="text" placeholder="0" />
                            <br />
                            <span class="gray">最低成团条件，最低购买了多少份才成团</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        市场价
                    </td>
                    <td class="enter_content">
                        <input name="tm_price_m" runat="Server" id="tm_price_m" class="px" maxlength="255"
                            type="text" placeholder="0.00" />
                            <br />
                            <span class="gray">市场价格，必须为数字。缺省为0.00</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        团购价
                    </td>
                    <td class="enter_content">
                        <input name="tm_price_t" runat="Server" id="tm_price_t" class="px" maxlength="255"
                            type="text" placeholder="0.00" />
                             <br />
                            <span class="gray">团购价格，必须为数字。缺省为0.00</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        虚拟购买人数
                    </td>
                    <td class="enter_content">
                        <input name="tm_AMT_xn" runat="Server" id="tm_AMT_xn" class="px" maxlength="255"
                            type="text" placeholder="1" />
                              <br />
                            <span class="gray">虚拟购买人数，即显示在前台多少人已购买</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        最少成团人数
                    </td>
                    <td class="enter_content">
                        <input name="tm_AMT_min" runat="Server" id="tm_AMT_min" class="px" maxlength="255"
                            type="text" placeholder="1" />
                             <br />
                            <span class="gray">最少成团人数，达到此人数才团购成功</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        最多可购买数量
                    </td>
                    <td class="enter_content">
                        <input name="tm_AMT_max" runat="Server" id="tm_AMT_max" class="px" maxlength="255"
                            type="text" placeholder="10" />
                             <br />
                            <span class="gray">最多可购买的数量，达到此数量，此次团购结束</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        每人限购数量
                    </td>
                    <td class="enter_content">
                        <input name="tm_AMT_per" runat="Server" id="tm_AMT_per" class="px" maxlength="255"
                            type="text" placeholder="1" />
                             <br />
                            <span class="gray">每个人最多可购买的数量</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        已经购买数量
                    </td>
                    <td class="enter_content">
                        <input name="tm_AMT_have" runat="Server" id="tm_AMT_have" class="px" maxlength="255"
                            type="text" placeholder="0" />
                             <br />
                            <span class="gray">已经购买了多少数量</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        开始时间
                    </td>
                    <td class="enter_content">
                        <input name="tm_Bdate" runat="Server" id="tm_Bdate" class="px" maxlength="255" type="text" readonly="readonly"
                            placeholder="2014-01-01" onfocus="HS_setDate(this);" />
                             <br />
                            <span class="gray">团购开始时间</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        结束时间
                    </td>
                    <td class="enter_content">
                        <input name="tm_Edate" runat="Server" id="tm_Edate" class="px" maxlength="255" type="text" readonly="readonly"
                            placeholder="2014-01-10" onfocus="HS_setDate(this);" />
                            <br />
                            <span class="gray">团购结束时间</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        券有效期
                    </td>
                    <td class="enter_content">
                        <input name="tm_Qdate" runat="Server" id="tm_Qdate" class="px" maxlength="255" type="text" readonly="readonly"
                            placeholder="2014-01-20" onfocus="HS_setDate(this);" />
                             <br />
                            <span class="gray">团购券可使用的截止期限</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        简介
                    </td>
                    <td class="enter_content">
                        <textarea name="tm_des" placeholder="简介信息" id="tm_des" class="px2" runat="server"></textarea>
                         <br />
                            <span class="gray">团购简单介绍</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        提示
                    </td>
                    <td class="enter_content">
                        <textarea name="tm_tip" placeholder="提示信息" id="tm_tip" class="px2" runat="server"></textarea>
                         <br />
                            <span class="gray">提示信息</span><br />
                        <td>
                        </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        品名
                    </td>
                    <td class="enter_content">
                        <input name="tm_Gname" runat="Server" placeholder="商品名称" id="tm_Gname" class="px" maxlength="255" type="text" />
                         <br />
                            <span class="gray">此次团购产品的名称</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片1地址
                    </td>
                    <td class="enter_content">
                        <input name="tm_gif" runat="Server" id="tm_gif" class="px" type="file" />
                         <br />
                            <span class="gray">	幻灯片图片1</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片2地址
                    </td>
                    <td class="enter_content">
                        <input name="tm_gif2" runat="Server" id="tm_gif2" class="px" type="file" />
                          <br />
                            <span class="gray">	幻灯片图片2</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片3地址
                    </td>
                    <td class="enter_content">
                        <input name="tm_gif3" runat="Server" id="tm_gif3" class="px" type="file" />
                          <br />
                            <span class="gray">	幻灯片图片3</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title"">
                        视频地址
                    </td>
                    <td class="enter_content">
                        <input name="tm_flv" placeholder="www.youku.com" runat="Server" id="tm_flv" class="px" maxlength="255" type="text" />
                          <br />
                            <span class="gray">	团购介绍的视频地址</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        本单详情
                    </td>
                    <td class="enter_content">
                        <textarea name="tm_msg" placeholder="本单详情" id="tm_msg" class="px2" runat="server"></textarea>
                        <br />
                            <span class="gray">团购项目的详细介绍</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        网友点评
                    </td>
                    <td class="enter_content">
                        <textarea name="tm_dp" id="tm_dp" placeholder="网友点评" class="px2" runat="server"></textarea>
                          <br />
                            <span class="gray">网友点评信息</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        推广词
                    </td>
                    <td class="enter_content">
                        <textarea name="tm_tg" id="tm_tg" placeholder="推广词" class="px2" runat="server"></textarea>
                           <br />
                            <span class="gray">团购宣传推广词</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                <td class="enter_title">
                       
                    </td>
                    <td  class="enter_content">
                        <input onserverclick="btn_baocun_ServerClick" name="Button1" id="Button1" value=" 保 存 "
                            class="btnSave" type="button" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
