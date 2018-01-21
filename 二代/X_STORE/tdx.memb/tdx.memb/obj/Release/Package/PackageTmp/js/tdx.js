// JavaScript Document
$(function () {
    //处理首页滑动块
    if ($(".zjan ul li").size() > 0) {
        $(".zjan ul li").each(function (index, element) {
            $(this).click(function () {//点击操作
                $(".zjan ul li").find("img").each(function (index2, element2) {
                    var _src = $(".zjan ul li").find("img").slice(index2, index2 + 1).attr("src");
                    _src = _src.replace("-2.png", ".png");
                    $(".zjan ul li").find("img").slice(index2, index2 + 1).attr("src", _src);
                });
                $(this).find("img").attr("src", $(this).find("img").attr("src").replace(".png", "-2.png"));
                $(".ww").hide();
                $("#ww" + index).show();
            });
        });
    }
    if ($("#txtSubmit").size() > 0) {
        $("#txtSubmit").click(function () {
            //执行提交工作
            var isMobile = /^1[34589]\d{9}$/;
            var isEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if ($("#txtCompany").val() == "" || $("#txtCompany").val() == "例如:多歌信息技术（上海）有限公司") {
                alert("请输入您的公司名称.");
                $("#txtCompany").focus();
                return;
            }
            if ($("#txtUname").val() == "" || $("#txtUname").val() == "请输入你的名字") {
                alert("请输入您的姓名.");
                $("#txtUname").focus();
                return;
            }
            if (($("#txtTel").val() == "" || $("#txtTel").val() == "例如:138xxxxxxxx")) {
                alert("请输入您的手机号码.");
                $("#txtTel").focus();
                return;
            }
            if (!isMobile.test($("#txtTel").val())) {
                alert("请正确填写您的手机号码，例如:13812345678");
                return;
            }
            if ($("#txtEmail").val() == "" || $("#txtEmail").val() == "请填写你的邮箱") {
                alert("请输入您的Email地址.");
                $("#txtEmail").focus();
                return;
            }
            if (!isEmail.test($("#txtEmail").val())) {
                alert("请正确填写您的Email地址，例如:123@duoge.com.cn");
                return;
            }
            if ($("#txtJob").val() == "" || $("#txtJob").val() == "请输入你的职务") {
                alert("请输入您的请输入你的职务.");
                $("#txtJob").focus();
                return;
            }
            //执行ajax功能，提交到后台去处理
            $.ajax({
                async: true,
                cache: false,
                global: true,
                timeout: 120000,
                contentType: 'application/x-www-form-urlencoded',

                type: 'POST',
                url: '/reg.ashx',
                dataType: 'text',
                data: { "txtCompany": $("#txtCompany").val(), "txtUname": $("#txtUname").val(), "txtTel": $("#txtTel").val(), "txtJob": $("#txtJob").val(), "txtEmail": $("#txtEmail").val(), "choose": "1" },
                beforeSend: function () {
                    //显示等待层 
                    $("#txtSubmit").val("正在提交...").css("color", "#cccccc").attr("disabled", true);
                },
                success: function (data) {
                    var sr = data;
                    if (sr == "OK") {
                        alert("感谢您的注册,请返回您的邮箱收取账号密码信息.");
                        $("#txtCompany").val("");
                        $("#txtUname").val("");
                        $("#txtTel").val("");
                        $("#txtJob").val("");
                        $("#txtEmail").val("");
                    }
                    else {
                        alert(sr);
                    }
                },
                complete: function () {
                    $("#txtSubmit").val("开始免费使用").css("color", "#fff").attr("disabled", false);
                }
            });
        });
    }

});


//通过函数
function Reg_online() {
    //执行提交工作
    var isMobile = /^1[34589]\d{9}$/;
    ///^((0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$/;
    var isEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if ($("#txtCompany").val() == "" || $("#txtCompany").val() == "例如:多歌信息技术（上海）有限公司") {
        alert("请输入您的公司名称.");
        $("#txtCompany").focus();
        return;
    }
    if ($("#txtUname").val() == "" || $("#txtUname").val() == "请输入你的名字") {
        alert("请输入您的姓名.");
        $("#txtUname").focus();
        return;
    }
    if (!isMobile.test($("#txtTel").val())) {
        alert("请正确填写您的手机号码，例如:13812345678");
        return;
    }
    if ($("#txtEmail").val() == "" || $("#txtEmail").val() == "请填写你的邮箱") {
        alert("请输入您的Email地址.");
        $("#txtEmail").focus();
        return;
    }
    if (!isEmail.test($("#txtEmail").val())) {
        alert("请正确填写您的Email地址，例如:123@duoge.com.cn");
        return;
    }
    if ($("#txtJob").val() == "" || $("#txtJob").val() == "请输入你的职务") {
        alert("请输入您的请输入你的职务.");
        $("#txtJob").focus();
        return;
    }
    if (($("#txtTel").val() == "" || $("#txtTel").val() == "例如:138xxxxxxxx")) {
        alert("请输入您的手机号码.");
        $("#txtTel").focus();
        return;
    }

    var choose;
    choose = $('input:radio[name="ss"]:checked').val();
    //执行ajax功能，提交到后台去处理
    $.ajax({
        async: true,
        cache: false,
        global: true,
        timeout: 120000,
        contentType: 'application/x-www-form-urlencoded',

        type: 'POST',
        url: '/reg.ashx',
        dataType: 'text',
        data: { "txtCompany": $("#txtCompany").val(), "txtUname": $("#txtUname").val(), "txtTel": $("#txtTel").val(), "txtJob": $("#txtJob").val(), "txtEmail": $("#txtEmail").val(), "choose": choose },
        // data: { "txtCompany": $("#txtCompany").val(), "txtUname": $("#txtUname").val(), "txtTel": $("#txtTel").val(), "txtJob": $("#txtJob").val(), "txtEmail": $("#txtEmail").val(),"choose": choose},	
        beforeSend: function () {
            //显示等待层 
            // $("#txtSubmit").val("正在提交...").css("color","#cccccc").attr("disabled",true);													   																   
        },
        success: function (data) {
            var sr = data;
            if (sr == "OK") {
                alert("感谢您的注册,请返回您的邮箱收取账号密码信息.");
                location.href = "http://www.tdx.cn/Login.aspx?uname=" + $("#txtEmail").val();
                $("#txtCompany").val("");
                $("#txtUname").val("");
                $("#txtTel").val("");
                $("#txtJob").val("");
                $("#txtEmail").val("");
            }
            else {
                alert(sr);
            }
        },
        complete: function () {
            // $("#txtSubmit").val("开始免费使用").css("color","#fff").attr("disabled",false);													   																			
        }
    });

}
function checkAll(field, c) {
    for (i = 0; i < field.length; i++)
        field[i].checked = c.checked;
}
function selectChange(th, th2) {
    $(th2).empty();
    if ($(th).val() == "") {
        $("#txtUrl_2").hide();
        $("#txturl").show();
    }
    else {
        $("#txtUrl_2").show();
        $("#txturl").hide();
    }
    $.get("GetFunc.ashx?q=" + $(th).val(), function (data) {
        $(th2).append(data);
    });
}
function selectChange2(th, th2) {
    var thValue = $(th).val();
    var th2Value = $(th2).val();
    switch (thValue) {
        case "newslist":
        case "prolist":
        case "teamlist":
        case "Goodslist":
        case "mslist":
        case "photolist":
            $("#txturl").val(thValue + ".aspx?cno=" + th2Value);
            break;
        case "honor_list":
            $("#txturl").val("honor_action.aspx?id=" + th2Value);
            break;
        case "tpage":
            $("#txturl").val(thValue + ".aspx?id=" + th2Value);
            break;
        default:
            $("#txtUrl_2").hide();
            $("#txturl").show();
            break;

    }
}