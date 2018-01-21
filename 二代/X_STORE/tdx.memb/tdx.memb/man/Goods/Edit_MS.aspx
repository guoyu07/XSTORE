<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_MS.aspx.cs" Inherits="tdx.memb.man.Goods.Edit_MS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="../images4/nei.css" type="text/css" rel="stylesheet">
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../../js/tdx_date.js" type="text/javascript"></script>
    <title>后台管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript" language="javascript" src="../../js/calendar.js" charset="utf-8"></script>
    <h1>
        <strong>秒杀活动</strong></h1>
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
                        秒杀项目名称
                    </td>
                    <td class="enter_content">
                        <input name="ms_title" runat="Server" placeholder="秒杀项目名称" id="ms_title" class="px" maxlength="255"
                            type="text" />
                            <br />
                            <span class="gray">	秒杀项目名称，便于记忆,最多100个字符</span><br />
                    </td>
                   <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">
                        成团条件限制
                    </td>
                    <td class="enter_content">
                        <input name="ms_tiaojian" runat="Server" id="ms_tiaojian" class="px" maxlength="255"
                            type="text" placeholder="0" />
                              <br />
                            <span class="gray">最低成团条件，最低几个人购买成团。</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        市场价
                    </td>
                    <td class="enter_content">
                        <input name="ms_price_m" runat="Server" id="ms_price_m" class="px" maxlength="255"
                            type="text" placeholder="0.00" />
                              <br />
                            <span class="gray">市场价格，必须为数字。缺省为0.00</span><br />
                            	

                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        秒杀价
                    </td>
                    <td class="enter_content">
                        <input name="ms_price_t" runat="Server" id="ms_price_t" class="px" maxlength="255"
                            type="text" placeholder="0.00" />                            
                             <br />
                            <span class="gray">团购价格，必须为数字。缺省为0.00	</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        虚拟购买人数
                    </td>
                    <td class="enter_content">
                        <input name="ms_AMT_xn" runat="Server" id="ms_AMT_xn" class="px" maxlength="255"
                            type="text" placeholder="0" />
                              <br />
                            <span class="gray">虚拟购买人数，即显示在前台多少人已购买</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        最多可购买数量
                    </td>
                    <td class="enter_content">
                        <input name="ms_AMT_max" runat="Server" id="ms_AMT_max" class="px" maxlength="255"
                            type="text" placeholder="1" />
                              <br />
                            <span class="gray">最多可购买的数量，达到此数量，此次秒杀结束</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        每人限购数量
                    </td>
                    <td class="enter_content">
                        <input name="ms_AMT_per" runat="Server" id="ms_AMT_per" class="px" maxlength="255"
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
                        <input name="ms_AMT_have" runat="Server" id="ms_AMT_have" class="px" maxlength="255"
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
                        <input name="ms_Bdate" runat="Server" id="ms_Bdate" class="px" maxlength="255" type="text" readonly="readonly"
                            onfocus="HS_setDate(this)" placeholder="2014-01-01" />
                              <br />
                            <span class="gray">秒杀开始时间</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        结束时间
                    </td>
                    <td class="enter_content">
                        <input name="ms_Edate" runat="Server" id="ms_Edate" class="px" maxlength="255" type="text" readonly="readonly"
                            onfocus="HS_setDate(this)" placeholder="2014-01-10" />
                             <br />
                            <span class="gray">秒杀结束时间</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        券有效期
                    </td>
                    <td class="enter_content">
                        <input name="ms_Qdate" runat="Server" id="ms_Qdate" class="px" maxlength="255" type="text" readonly="readonly"
                            onfocus="HS_setDate(this)" placeholder="2014-01-20" />
                              <br />
                            <span class="gray">秒杀券可使用的截止期限</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        简介
                    </td>
                    <td class="enter_content">
                        <textarea id="ms_des" name="ms_des" runat="server" class="px2"></textarea>
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
                        <textarea id="ms_tip" name="ms_tip" placeholder="秒杀提示信息" runat="server" class="px2"></textarea>
                         <br />
                            <span class="gray">提示信息</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        品名
                    </td>
                    <td class="enter_content">
                        <input name="ms_Gname" runat="Server" placeholder="产品名称" id="ms_Gname" class="px" maxlength="255"
                            type="text" />
                              <br />
                            <span class="gray">此次秒杀产品的名称</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片1预览
                    </td>
                    <td class="enter_content">
                        <asp:Image Height="150px" Width="200px" ID="ms_gif_show" runat="server" />                        
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片1地址
                    </td>
                    <td class="enter_content">
                        <input name="ms_gif" runat="Server" id="ms_gif" class="px" type="file" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片2预览
                    </td>
                    <td wclass="enter_content">
                        <asp:Image Height="150px" Width="200px" ID="ms_gif2_show" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片2地址
                    </td>
                    <td class="enter_content">
                        <input name="ms_gif2" runat="Server" id="ms_gif2" class="px" type="file" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片3预览
                    </td>
                    <td class="enter_content">
                        <asp:Image Height="150px" Width="200px" ID="ms_gif3_show" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片3地址
                    </td>
                    <td class="enter_content">
                        <input name="ms_gif3" runat="Server" id="ms_gif3" class="px" type="file" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        视频地址
                    </td>
                    <td class="enter_content">
                        <input name="ms_flv" runat="Server" placeholder="www.youku.com" id="ms_flv" class="px"
                            maxlength="255" type="text" />
                              <br />
                            <span class="gray">秒杀介绍的视频地址</span><br />
                            	
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        本单详情
                    </td>
                    <td class="enter_content">
                        <textarea id="ms_msg" name="ms_msg" placeholder="本单详情" runat="server" class="px2"></textarea>
                          <br />
                            <span class="gray">秒杀项目的详细介绍</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        网友点评
                    </td>
                    <td class="enter_content">
                        <textarea id="ms_dp" placeholder="网友点评" name="ms_dp" runat="server" class="px2"></textarea>
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
                        <textarea id="ms_tg" name="ms_tg" placeholder="推广词" runat="server" class="px2"></textarea>
                        <br />
                            <span class="gray">秒杀宣传推广词</span><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                <td class="enter_title">
                        
                    </td>
                    <td class="enter_content">
                        <input onserverclick="btn_baocun_ServerClick" name="Button1" id="Button1" value=" 保 存 "
                            class="btnGreen" type="button" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
