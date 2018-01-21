<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="honor_action.aspx.cs" Inherits="tdx.caimi.honor_action" %>  
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
        <asp:Literal ID="lt_keywords" runat="server"></asp:Literal>
        <asp:Literal ID="lt_description" runat="server"></asp:Literal>
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta name="apple-mobile-web-app-status-bar-style" content="default" />
        <meta name="apple-mobile-web-app-capable" content="yes" />
        <link href="css/common.css" rel="stylesheet" type="text/css" />
        <script language="javascript" src="js/jquery-1.7.2.min.js" charset="utf-8"></script> 
        <script src="honoraction/honor.js" type="text/javascript"></script>
</head>
<body class="nei_body">
    <input type="hidden" id="h_WWV" runat="server" />
    <input type="hidden" id="h_acID" runat="server" />
    <input type="hidden" id="chjnum" runat="server" />
    <input type="hidden" id="h_guidno" runat="server" /> 
    <div class="Appcontent">
        <h1>
            <asp:Literal ID="lt_proTitle" runat="server" EnableViewState="false"></asp:Literal>
        </h1>
        <p>
            <asp:Literal ID="lt_newsContent" runat="server" EnableViewState="false"></asp:Literal>
            <link href="honoraction/images/activity-style.css" rel="stylesheet" type="text/css">
            <div id="mainpan" runat="Server" class="main">
                <div id="outercont">
                    <div id="outer-cont">
                        <div id="outer">
                            <img src="honoraction/images/activity-lottery-1.png" width="310px"></div>
                    </div>
                    <div id="inner-cont">
                        <div id="inner">
                            <img src="honoraction/images/activity-lottery-2.png"></div>
                    </div>
                </div>
                <div class="content">
                    <div id="zjl" style="display: none" class="boxcontent boxwhite">
                        <div id="zjbox" class="box">
                            <div class="title-red">
                                <span>恭喜你中奖了 </span>
                            </div>
                            <div class="Detail">
                                <p>
                                    你中了： <span class="red" id="prizetype">一等奖</span>
                                </p>
                            </div>
                            <p>
                                兑奖SN码： <span class="red" id="sncode"></span>
                            </p>
                            <p class="red">
                            </p>
                            <p>
                                <input name="" class="px" id="name" value="" type="text" placeholder="请输入您的姓名">
                            </p>
                            <p>
                                <input name="" class="px" id="tel" value="" type="text" placeholder="请输入您的手机号">
                            </p>
                            <p>
                                <input name="" class="px" id="comp" value="" type="text" placeholder="请输入您的身份证号">
                            </p>
                            <p>
                                <input name="" class="px" id="addr" value="" type="text" placeholder="请输入您的地址">
                            </p>
                            <p>
                                <input name="" class="px" id="email" value="" type="text" placeholder="请输入您的email">
                            </p>
                            <p>
                                <input class="pxbtn" name="提 交" id="save-btn" type="button" value="用户提交">
                                <span id="servspan"></span>
                            </p>
                          
                        </div>
                    </div>
                    <div class="boxcontent boxwhite">
                        <div class="box">
                            <div class="title-green">
                                <span>奖项设置： </span>
                            </div>
                            <div class="Detail">
                                <p>
                                    <asp:Literal ID="lt_jp1" runat="server"></asp:Literal>
                                </p>
                                <p>
                                    <asp:Literal ID="lt_jp2" runat="server"></asp:Literal>
                                </p>
                                <p>
                                    <asp:Literal ID="lt_jp3" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="boxcontent boxwhite">
                        <div class="box">
                            <div class="title-green">
                                活动说明：
                            </div>
                            <div class="Detail">
                                <p class="red">
                                    <asp:Literal ID="lt_shuoming" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
              
            </div>
        </p>
    </div> 
</body>
</html>
