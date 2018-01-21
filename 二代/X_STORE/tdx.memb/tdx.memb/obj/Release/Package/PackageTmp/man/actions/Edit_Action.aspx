<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_Action.aspx.cs" Inherits="tdx.memb.man.actions.Edit_Action" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑活动</title>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script src="../../js/jQueryLoadImg.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/tdx_date.js"> </script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            <strong>编辑活动信息</strong></h1>
        <div class="nei_content" id="nei_content">
            <div class="greenRemind">
                <abbr>
                </abbr>
                <span>
                    <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                        href="javascript:void(0)"></a>
            </div>

            <!--center content-->
            <div class="tsxx">
                <img class="tsxx_1" src="/man/images4/ts.png">
                <span class="tsxx_2">
                    <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
                <img class="tsxx_3" src="/man/images4/xx.png">
            </div>
            <%--开始编辑--%>
            <table class="enter_table">
                <tr style="border-bottom: 1px solid #999;">
                    <td class="enter_title">编辑活动开始内容
                    </td>
                    <td class="enter_content"></td>

                </tr>
                <tr>
                    <td class="enter_title">活动类型:
                    </td>
                    <td class="enter_content">
                        <select name="Action_leibie" runat="server" id="Action_leibie" class="select-field_sousuo">
                        </select>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">开始图片:
                    </td>
                    <td class="enter_content">
                        <img style="margin-left: 0px; margin-top: 0px" id="kaishiimg" runat="server" src="aa"
                            alt="开始图片" />
                        <br />
                        <input type="file" name="t_zjxinxi" class="px" runat="server" id="t_kaishidizhi"
                            maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">活动名称:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_title" placeholder="请输入活动名称 请不要多于50字" runat="server" id="t_title"
                            class="px" maxlength="50" />
                        <br />
                        <span class="gray">请不要多于50字!</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">兑奖信息:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_djxinxi" placeholder="请输入兑奖信息" class="px" runat="server"
                            id="t_djxinxi" maxlength="100" />
                        <br />
                        <span class="gray">请不要多于100字！这个设定在用户输入兑奖时候的显示信息</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">中奖提示:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_zjxinxi" placeholder="中奖提示" class="px" runat="server"
                            id="t_zjxinxi" maxlength="255" />
                        <br />
                        <span class="gray">中奖后,提示信息</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">活动时间:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_kaishi" onfocus="HS_setDate(this)" readonly="readonly" runat="server" id="t_kaishi"
                            maxlength="50" class="sousuo_px" />
                        到
                    <input type="text" name="t_jieshu" onfocus="HS_setDate(this)" runat="server" id="t_jieshu"
                        readonly="readonly" maxlength="50" class="sousuo_px" />
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">活动说明:
                    </td>
                    <td class="enter_content">
                        <fckeditorv2:FCKeditor ID="t_hdjianjie" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
                            Height="250px">
                        </fckeditorv2:FCKeditor>
                        <br />
                        <span class="gray">换行请输入&lt;br&gt;</span>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">重复抽奖回复:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_zjxinxi" placeholder="亲继续努力哦！" class="px2" runat="server"
                            id="t_cfxinxi" maxlength="255" />
                        <br />
                        <span class="gray">备注:如果设置只允许抽一次奖的,请写:你已经玩过了,下次再来，如果设置可多次抽奖,请写:亲继续努力哦!</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
            </table>
            <h2></h2>
            <table class="enter_table">
                <tr style="border-bottom: 1px solid #999;">
                    <td class="enter_title">编辑活动结束内容
                    </td>
                    <td class="enter_content"></td>

                </tr>
                <tr>
                    <td class="enter_title">结束图片:
                    </td>
                    <td class="enter_content">
                        <img id="t_jieshutupiandizhi" style="margin-left: 0px; margin-top: 0px" runat="server"
                            src="" />
                        <br />
                        <input type="file" name="t_zjxinxi" class="px" runat="server" id="jieshufile" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">活动结束公告主题:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" placeholder="幸运大转盘已经结束了" runat="server"
                            id="t_jshuodonggonggao" class="px" maxlength="50" />
                        <br />
                        <span class="gray">请不要多于50字!</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">活动结束说明:
                    </td>
                    <td class="enter_content">
                        <fckeditorv2:FCKeditor ID="t_msg" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
                            Height="250px">
                        </fckeditorv2:FCKeditor>
                        <br />
                        <span class="gray">换行请输入&lt;br&gt;</span>
                    </td>
                </tr>
            </table>
            <h2></h2>
            <table class="enter_table">
                <tr style="border-bottom: 1px solid #999;">
                    <td class="enter_title">奖项设置
                    </td>
                    <td class="enter_content"></td>

                </tr>
                <tr>
                    <td class="enter_title">一等奖奖品设置:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" placeholder="一等奖名称 请不要多于50字" runat="server"
                            id="t_ydjsz" class="px" maxlength="50" />
                        <br />
                        <span class="gray">请不要多于50字!</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">一等奖奖品数量:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" value="" runat="server" id="t_ydjsl"
                            class="px" maxlength="50" />
                        <br />
                        <span class="gray">如果是100%中奖,请把一等奖的奖品数量[1000就代表前1000人都中奖]填写多点</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">二等奖奖品设置:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" value="" runat="server" id="t_edjsz"
                            class="px" maxlength="50" />
                        <br />
                        <br />
                        <span class="gray">请不要多于50字!</span>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">二等奖奖品数量:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" value="" runat="server" id="t_edjsl"
                            class="px" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">三等奖奖品设置:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" value="" runat="server" id="t_sdjsz"
                            class="px" maxlength="50" />
                        <br />
                        <span class="gray">请不要多于50字!</span>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">三等奖奖品数量:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" value="" runat="server" id="t_sdjsl"
                            class="px" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">预计活动的人数:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" placeholder="请填写数字" runat="server" id="t_yjhdrs"
                            class="px" maxlength="50" />
                        <br />
                        <span class="gray">预估活动人数直接影响抽奖概率:中奖概率=奖品总数/(预估活动人数*每人抽奖次数)如果要确保任何时候都100%中奖建议设置为1人参加！</span><span
                            class="gray">如果要确保任何时候都100%中奖建议设置为1人参加！并且奖项只设置一等奖.</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title">每人最多允许抽奖次数:
                    </td>
                    <td class="enter_content">
                        <input type="text" name="t_jshuodonggonggao" placeholder="必须1-5之间的数字" runat="server"
                            id="t_yxcimgr" class="px" maxlength="50" />
                        <br />
                        <span class="gray">必须1-5之间的数字</span>
                    </td>
                    <td class="rb">*</td>
                </tr>
                <tr>
                    <td class="enter_title"></td>
                    <td class="enter_content">
                        <input type="button" value="保 存" class="btnGreen" onserverclick="btn_baocun_ServerClick"
                            runat="server" id="btn_baocun" />
                        <input type="button" value="取 消" class="btnGray" runat="server" id="quxiao" />
                    </td>
                </tr>
            </table>
            <div class="enter_remind">
            </div>
        </div>
    </form>
</body>
</html>
