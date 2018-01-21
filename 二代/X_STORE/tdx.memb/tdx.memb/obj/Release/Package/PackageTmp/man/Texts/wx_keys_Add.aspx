<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_keys_Add.aspx.cs" Inherits="tdx.memb.man.Texts.wx_keys_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../images4/B2C_msg_Add.css" />
    <script src="../../js/jquery.form.js" type="text/javascript"></script>
    <script src="../../js/B2C_msg_Add.js" type="text/javascript"></script>
    <asp:Literal ID="lt_jqu" runat="server"></asp:Literal>
    <script type="text/javascript">
        $(function () {
            $("[name='rd_type']").click(function () {
                if ($(this).attr("id") == "rd_type4") {
                    $(".enter_remind").hide();
                }
                else {
                    $(".enter_remind").show();
                    $(".enter_remind").offset({ top: $(".enter_table").offset().top - 30, left: $(".enter_table").offset().left + $(".enter_table").width() });
                }
            });
        })
    </script>
</head>
<body>
    <!--中间开始-->
    <asp:Literal ID="daohang_Image" runat="server"></asp:Literal>
    <form id="form1" runat="server">
    <h1>
        <strong>编辑关键字回复:</strong>
        <asp:Literal ID="lt_mp" runat="server" EnableViewState="false"></asp:Literal></h1>
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
        <input type="hidden" name="txtWID" id="txtWID" runat="server" enableviewstate="false" />
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    关键词
                </td>
                <td class="enter_content">
                    <input type="text" name="txt_gtitle" placeholder="关键字" class="px" size="30" runat="server"
                        id="txt_gtitle" maxlength="255" /><br />
                    <span class="gray">多个关键词之间，请用,分隔</span>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    答案形式
                </td>
                <td class="enter_content">
                    <input type="radio" id="rd_type1" name="rd_type" value="0" runat='server' checked
                        onclick="javascript:d1.style.display='';d2.style.display='none';d3.style.display='none';d4.style.display='none';btn_save_wxkey.style.display='';" />
                    <label for="rd_type1">
                        文本内容</label>
                    <input type="radio" id="rd_type2" name="rd_type" value="1" runat="server" onclick="javascript:d1.style.display='none';d2.style.display='';d3.style.display='none';d4.style.display='none';btn_save_wxkey.style.display='';" />
                    <label for="rd_type2">
                        功能函数</label>
                    <input type="radio" id="rd_type3" name="rd_type" value="2" runat="server" onclick="javascript:d1.style.display='none';d2.style.display='none';d3.style.display='';d4.style.display='none';btn_save_wxkey.style.display='';" />
                    <label for="rd_type3">
                        外部接口</label>
                    <input type="radio" id="rd_type4" name="rd_type" value="3" runat='server' onclick="javascript:d1.style.display='none';d2.style.display='none';d3.style.display='none';d4.style.display='';btn_save_wxkey.style.display='none';" />
                    <label for="rd_type4">
                        图文信息</label><br />
                    <span class="gray">支持各种形式，如文本、图文。<br />
                        功能函数，指回复在产品库或新闻库中模糊查询结果返回给网友。<br />
                        外部接口，支持从外部返回答案信息，例如您的ERP系统返回订单信息等。</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tbody name="d1" id="d1" style="display: '';">
                <tr>
                    <td class="enter_title">
                        内 容
                    </td>
                    <td class="enter_content">
                        <textarea id="des" name="des" placeholder="内容信息" runat="server" class="px2" rows="6"></textarea><br />
                        <span class="gray">最多可输入300字</span><br />
                        <br />
                    </td>
                </tr>
            </tbody>
            <tbody name="d2" id="d2" style="display: none;">
                <tr>
                    <td class="enter_title">
                        功 能
                    </td>
                    <td class="enter_content">
                        <select id="ss_fid" size="1" name="ss_fid" runat="server" class="select-field">
                        </select>
                    </td>
                    <td>
                    </td>
                </tr>
            </tbody>
            <tbody name="d3" id="d3" style="display: none;">
                <tr>
                    <td class="enter_title">
                        链接地址
                    </td>
                    <td class="enter_content">
                        <textarea id="txtKURL" name="txtKURL" placeholder="链接地址" runat="server" class="px2"></textarea><br />
                        <span class="gray">链接的字符长度不能超过500</span><br />
                        <br />
                    </td>
                </tr>
            </tbody>
            <tbody name="d4" id="d4" style="display: none;">
                <tr>
                    <td colspan="3">
                        <div class="main">
                            <asp:HiddenField ID="hfGuid" runat="server" />
                            <asp:HiddenField ID="hfwid" runat="server" />
                            <input type="hidden" id="delItem" value="" />
                            <div class="main_left">
                                <div class="titlePageInfo" id="titlePageInfo">
                                    <div class="imgTitle">
                                        <span>标题</span>
                                    </div>
                                    <div class="imgBg">
                                        <img />
                                        <span>封面图片</span></div>
                                    <div class="imgEidt">
                                        <a href="javascript:void(0)" class="infoEdit">编辑</a></div>
                                    <div name="hidden" class="hidden_body">
                                    </div>
                                </div>
                                <div class="otherAdd">
                                    <a href="javascript:void(0)">添加</a>
                                </div>
                            </div>
                            <div class="main_right">
                                <div class="main_edit" target="titlePageInfo">
                                    <div class="edit_item">
                                        <p>
                                            标题</p>
                                        <div class="edit_item_msgbg">
                                            <input type="text" id="txtTitle" maxlength="34" />
                                        </div>
                                    </div>
                                    <span class="gray">标题最长不能超过34个字符</span>
                                    <div class="edit_item" style="display: none;">
                                        <p>
                                            作者</p>
                                        <div class="edit_item_msgbg">
                                            <input type="text" id="txtAuthor" /></div>
                                    </div>
                                    <div class="edit_item">
                                        <p>
                                            上传图片</p>
                                        <div class="edit_item_msgbg">
                                            <input type="file" id="selectFile" accept="image/*" runat="server" />
                                            <div style="margin: 8px;">
                                                <img id="_thisImg" src="" />
                                                <a href="javascript:void(0)" id="delImg">删除</a>
                                            </div>
                                        </div>
                                        <span class="gray">最大宽高：720*400,支持格式jpg,gif,png</span>
                                    </div>
                                    <div class="edit_item">
                                        <p>
                                            摘要</p>
                                        <div class="edit_item_msgbg">
                                            <textarea id="summary" rows="4"></textarea>
                                        </div>
                                    </div>
                                    <div class="edit_item">
                                        <p>
                                            正文</p>
                                        <div class="edit_item_msgbg">
                                            <fckeditorv2:FCKeditor ID="_msg" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
                                                Width="548px" Height="350px">
                                            </fckeditorv2:FCKeditor>
                                        </div>
                                    </div>
                                    <div class="edit_item">
                                        <p>
                                            跳转链接</p>
                                        <div class="edit_item_msgbg">
                                            <input type="text" id="txtBodyUrl" /></div>
                                        <div class="edit_item_tip">
                                            填写此项,正文内容将无效</div>
                                    </div>
                                </div>
                                <div class="main_edit_arrow">
                                </div>
                            </div>
                            <p id="json">
                            </p>
                            <div style="text-align: center;">
                                <input type="button" value=" 保 存 " class="btnGreen" id="btn_wxkey_AjaxSave" /></div>
                        </div>
                    </td>
                </tr>
            </tbody>
            <%--<tbody name="d4" id="d4" style="display: none;">
                <tr>
                    <td width="20%" align="center" height="40">
                        图片信息
                    </td>
                    <td colspan="2">
                        <input id="title_image" runat="server" class="px" maxlength="255" name="title_image"
                            style="height: 30px;" type="file" /><br />
                        <img src="" alt="图文信息" width="90" height="60" runat="server" id="img" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40">
                        排序
                    </td>
                    <td colspan="2">
                        <input type="text" class="px" id="sort" value="99" placeholder="排序编号,越小越靠前；缺省99" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40">
                        回答内容
                    </td>
                    <td colspan="2">
                        <textarea id="des2" runat="server" placeholder="内容信息" style="height: 70px;" class="px2" cols="20" rows="2"></textarea>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40">
                        描述
                    </td>
                    <td colspan="2">
                        <textarea id="k_des3" runat="server" placeholder="描述信息" style="height: 70px;" class="px2" cols="20"
                            rows="2"></textarea>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40">
                        内容
                    </td>
                    <td colspan="2">
                        <fckeditorv2:FCKeditor ID="_msg" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
                            Width="570px" Height="350px">
                        </fckeditorv2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" height="40">
                        URL
                    </td>
                    <td colspan="2">
                        <input type="text" class="sssort" id="URL" placeholder="URL" runat="server" />
                    </td>
                </tr>
            </tbody>--%>
            <tbody name="d5" id="d5">
                <tr>
                    <td colspan="3" align="center" style="height: 30px">
                        <input type="button" value=" 保 存 " class="btnSave" runat="server" id="btn_save_wxkey"
                            name="btn_save_wxkey" onserverclick="Button1_ServerClick" />
                    </td>
                </tr>
            </tbody>
            <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
        </table>
    </div>
    <div class="nei_temp">
        <img /></div>
    <div class="enter_remind phone_remind">
        <img src="../images4/wxkey_phone.jpg"/>
    </div>
    </form>
    <!--中间结束-->
</body>
</html>

