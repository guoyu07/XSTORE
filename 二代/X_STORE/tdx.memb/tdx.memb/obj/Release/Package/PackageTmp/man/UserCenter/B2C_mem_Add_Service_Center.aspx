<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_mem_Add_Service_Center.aspx.cs" Inherits="tdx.memb.man.UserCenter.B2C_mem_Add_Service_Center" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑管理员</title>
    <script src="../../JS/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../JS/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="../JS/lhgdialog.js?skin=idialog" type="text/javascript"></script>
    <script src="../JS/layout.js" type="text/javascript"></script>
        <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/nei.css" rel="stylesheet" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="location">
            <a href="manager_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="B2C_mem_List.aspx"><span>会员管理</span></a>
            <i class="arrow"></i>
            <span>编辑会员</span>
        </div>
        <div class="line10"></div>

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑会员</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
           <input type="hidden" name="txt_M_no" id="txt_M_no" runat="server" value="" />
            <dl>
                <dt>会员等级：</dt>
                <dd>  <div class="rule-single-select">
                    <select name="drop_M_vip" id="drop_M_vip" size="1" class="select-field" runat="server" style="width: 180px">
                             
                     </select>&nbsp; 
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>手机：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_mobile" CssClass="input" runat="server"   ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        ControlToValidate="txt_M_mobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                </dd>

            </dl>
            <dl>
                <dt>登陆密码：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_psw" runat="server" CssClass="input"   ></asp:TextBox>

                    <asp:RegularExpressionValidator ID="Regulapwdne" runat="server"
                        ControlToValidate="txt_M_psw" ErrorMessage="6-20位字母数字，可以使用下划线"
                        ValidationExpression="^[\dA-Za-z(_)]{6,20}$"></asp:RegularExpressionValidator>
                </dd>

            </dl> 
            <dl>
                <dt>提现密码：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_psw2" runat="server" CssClass="input"  ></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="txt_M_psw2" ErrorMessage="6-20位字母数字，可以使用下划线"
                        ValidationExpression="^[\dA-Za-z(_)]{6,20}$"></asp:RegularExpressionValidator>
                </dd>

            </dl> 
            <dl>
                <dt>真实姓名：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_truename" runat="server" CssClass="input"   ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="txt_M_truename" ErrorMessage="*"></asp:RequiredFieldValidator>
                </dd>

            </dl><dl>
                <dt>性别：</dt>
                <dd>
                    <asp:RadioButton ID="radsexman" runat="server" Text="男" GroupName="sex"
                        Width="100px" Checked="true" />
                    <asp:RadioButton ID="radsexwoman" runat="server" Text="女" GroupName="sex"
                        Width="100px" />
                    <asp:RadioButton ID="radsexbaomi" runat="server" Text="保密" GroupName="sex"
                        Width="100px" />
                </dd>

            </dl>
            <dl>
                <dt>身份证号：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_IDCard" runat="server" CssClass="input"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="txt_M_IDCard" ErrorMessage="*"></asp:RequiredFieldValidator>
                </dd>

            </dl>
<%--            <dl>
                <dt>银行：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_bank" runat="server" CssClass="input"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                        ControlToValidate="txt_M_bank" ErrorMessage="*"></asp:RequiredFieldValidator>
                </dd>

            </dl>--%>
<%--            <dl>
                <dt>账号：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_card" runat="server" CssClass="input" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                        ControlToValidate="txt_M_card" ErrorMessage="*"></asp:RequiredFieldValidator>
                </dd>

            </dl>--%>
            <dl>
                <dt>收货地址：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_addr" runat="server" CssClass="input"   ></asp:TextBox>
                 
                </dd>

            </dl>
            <dl>
                <dt>邮编：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_zip" runat="server" CssClass="input"   ></asp:TextBox>
                
                </dd>

            </dl> 
            <dl>
                <dt>上级节点：</dt>
                <dd>
<%--                    <asp:TextBox ID="txt_ParentID" runat="server" CssClass="input"   ></asp:TextBox>
                   
                <asp:Button ID="btnSubmit0" runat="server" Text="检 查" CssClass="btn" 
                        onclick="btnSubmit0_Click"   />--%>
                   
                        <div class="rule-single-select">
                        <select id="txt_ParentID" name="txt_leibiehao" runat="server" class="select-field"></select>

                    </div>

                </dd>

            </dl>
<%--            <dl>
                <dt>介绍人：</dt>
                <dd>
                    <asp:TextBox ID="txt_jieshaoID" runat="server" CssClass="input"   ></asp:TextBox>
                   
                <asp:Button ID="btnSubmit1" runat="server" Text="检 查" CssClass="btn" 
                        onclick="btnSubmit1_Click"   />
                   
                </dd>
            </dl> --%>
<%--             <dl>
                <dt>物流中心：</dt>
                <dd>
                     <div class="rule-single-select">
                     <select name="ss_cityID" id="ss_cityID" size="1" class="select-field" runat="server" style="width: 180px">
                             
                     </select>
                     </div>
                </dd>

            </dl>--%>
            <dl>
                <dt>QQ：</dt>
                <dd>
                    <asp:TextBox ID="txtx_M_QQ" runat="server" CssClass="input"   ></asp:TextBox>
                 
                </dd>

            </dl>
            <dl>
                <dt>邮箱：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_email" runat="server" CssClass="input"   ></asp:TextBox>
                    
                </dd>

            </dl>
            <dl>
                <dt>头像：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_photo" runat="server" CssClass="input"   ></asp:TextBox>
                
                </dd>

            </dl> 
            <dl>
                <dt>生日：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_BirthDay" runat="server" CssClass="input"   ></asp:TextBox>
                  </dd>

            </dl>
            <dl>
                <dt>标签：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_tags" runat="server" CssClass="input"   ></asp:TextBox>
                    
                </dd>

            </dl>  
        </div>
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>

    </form>
</body>
</html>

