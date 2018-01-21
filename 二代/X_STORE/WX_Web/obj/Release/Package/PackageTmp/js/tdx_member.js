// JavaScript Document
$(function () {
    /**/
    /*JS控制DIV高度*/
    //    $(".nei_content").height($(window).height() - 68);
    //    $(window).resize(function () { $(".nei_content").height($(window).height() - 68); });
    /*JS控制DIV高度结束*/
    /*加载图片失败后*/
    //$("img").LoadImage(false, 0, 0, "../images4/avatar_logo.png");
    /*tsxx无内容隐藏*/
    if (trim($(".tsxx").children("span").text()) != null && trim($(".tsxx").children("span").text()) != "") {
        $(".tsxx").show();
    }
    if (trim($(".greenRemind").children("span").text()) != null && trim($(".greenRemind").children("span").text()) != "") {
        $(".greenRemind").show();
    }
    if (trim($(".yellowRemind").children("span").text()) != null && trim($(".yellowRemind").children("span").text()) != "") {
        $(".yellowRemind").show();
    }
    if (trim($(".redRemind").children("span").text()) != null && trim($(".redRemind").children("span").text()) != "") {
        $(".redRemind").show();
    }
    //    /*html自适应高度*/
    //    $("html,body").height($(window).height() - $("html").offset().top);
    //    $(window).resize(function () {
    //        $("html,body").height($(window).height() - $("html").offset().top);
    //    });
    /*编辑页面右侧提醒层定位*/
    //$(".enter_remind").html("");
    if ($(".enter_remind").length > 0 && $(".enter_table").length > 0) {
        $(".enter_remind").offset({ top: $(".enter_table").offset().top - 30, left: $(".enter_table").offset().left + $(".enter_table").width() });
        $(window).resize(function () {
            $(".enter_remind").offset({ top: $(".enter_table").offset().top - 30, left: $(".enter_table").offset().left + $(".enter_table").width() });
        });
    }
    //    else if ($(".enter_remind").length > 0 && $(".tdh").length > 0) {
    //        $(".enter_remind").offset({ top: $(".tdh").offset().top, left: $(".tdh").offset().left + $(".tdh").width() + 32 });
    //        $(window).resize(function () {
    //            $(".enter_remind").offset({ top: $(".tdh").offset().top, left: $(".tdh").offset().left + $(".tdh").width() + 32 });
    //        });
    //    }
    if ($(".enter_table").length > 0) {
        $(".phone_remind").height($("body").height());
    }
    if ($(".btn_container").length > 0 && $(".tdh").length > 0) {
        $(".phone_remind").height($(window).height() - $(".phone_remind").height())
        $(".phone_remind").offset({ top: $(".btn_container").eq(0).offset().top + 44, left: $(".tdh").offset().left + $(".tdh").width() + 32 });
        $(window).resize(function () {
            $(".phone_remind").offset({ top: $(".btn_container").eq(0).offset().top + 44, left: $(".tdh").offset().left + $(".tdh").width() + 32 });
        });
    }
    //处理左边的几个下拉位置
    if ($("#bg3").size() > 0) {
        $("#bg3").height($(window).height() - 596);
    }
    $(".tsxx_3,.greenRemind a,.yellowRemind a,.redRemind a").click(function () {
        var _this = $(this).parent();
        _this.animate({ "height": "0px", "paddingTop": "0px", "paddingBottom": "0px", opacity: 0 }, function () { _this.hide(); });
    });
    //菜单点击处理
    $(".mainMenu ul li").each(function (index, element) {
        $(this).click(function () {//点击操作
            $(".mainMenu ul li").removeClass("active");
            $(this).addClass("active");
            //操作成鼠标滑过状态
            //右边字菜单改变
            $("#lefter ul").hide();
            $("#lefter ul").slice(index, index + 1).show();
            //if(index>3){
            //    $("#lefter ul").slice(index, index + 1).css("margin-top", $(this).offset().top - $(".left-2 ul").slice(index, index + 1).height());
            //}
        });
    });
    //子菜单点击
    $("li.sub").each(function (index, element) {
        $(this).click(function () {//点击操作
            $("li.sub").removeClass("current");
            $(this).addClass("current");
            $("dd").removeClass("current");
            $("dd").slice(index, index + 1).addClass("current");

        });
    });
    //关闭提示信息
    //    $(".tsxx_3").click(function () {
    //        $(".tsxx").hide();
    //    });
    $(".tab_nav li a").click(function () {
        var _this = $(this);
        $(".qiehuanQu").children().each(function () { $(this).hide(); });
        $("#" + _this.parent().attr("_target")).show();
        $(".tab_nav li a").each(function () {
            $(this).removeClass("tab_nav_select");
        });
        _this.addClass("tab_nav_select");
    });
    $(".qiehuan1").click(function () {
        $(".div_Page").each(function () {
            $(this).hide();
        });
        $("#div_firstPage").show();
    });

    $(".qiehuan2").click(function () {
        $(".div_Page").each(function () {
            $(this).hide();
        });
        $("#div_liebiao").removeAttr("style");
        $("#div_liebiao").show();
    });
    $(".qiehuan3").click(function () {
        $(".div_Page").each(function () {
            $(this).hide();
        });
        $("#div_xiangqing").removeAttr("style");
        $("#div_xiangqing").show();
    });


    //收缩菜单
    if ($(".shousuo").size() > 0) {
        $(".shousuo").height($(window).height());
        $("#right").width($(window).width() - $(".zuiwai").width() - $(".shousuo").width() - 30);
        $(".nei").height($(window).height() - 120);
        $(".shousuo").click(function () {
            if ($(".zuiwai").is(":hidden")) {
                $(".zuiwai").show();
                $("#right").width($(window).width() - $(".zuiwai").width() - $(".shousuo").width() - 30);
            }
            else {
                $(".zuiwai").hide();
                $("#right").width($(window).width() - $(".shousuo").width() - 30);
            }

        });
    }
    //    //绑定输入框提醒时间
    //    if ($(".nei_content").size() > 0) {
    //        init_input(".nei_content");
    //    }
    //登录下拉菜单
    if ($(".userTitle").size() > 0) {
        $(".userTitle").click(function () {
            if ($(".userTitle ul").is(":hidden")) {
                $(".userTitle ul").show();
            }
            else {
                $(".userTitle ul").hide();
            }
        });
    }
    /*全局table颜色*/
    $(".tdh table tr:nth-child(even),.tdh table tbody tr:nth-child(even)").css("background-color", "#fff");
});
function sendfun() {
    if ($("#weixinname").val() == "") {
        alert("请输入微信号");
        return;
    }
    $(".wxrd").each(function () {
        if ($(this).attr("checked")) {

            var rnd = Math.random();
            var vxname = $("#weixinname").val();
            var appid = $(this).val();
            $.get("SendWxtw.ashx?r=" + rnd + "&vxname=" + vxname + "&appid=" + appid, function (data) {
                alert(data);
            })
        };
    })
}
function Qsendfun() {
    $(".wxrd").each(function () {
        if ($(this).attr("checked")) {

            var rnd = Math.random();
            var appid = $(this).val();
            $.get("SendWxtw.ashx?r=" + rnd + "&appid=" + appid, function (data) {
                alert(data);
            })
        };
    })
}

function init_input(id) {
    var inp = $(id).find("input");
    for (var i = 0; i < inp.length; i++) {
        if (inp.slice(i, i + 1).attr("type") == "text") {
            inp.slice(i, i + 1).focus(function () {
                $(this).attr("rel", this.defaultValue);
                if ($(this).val() == $(this).attr("rel")) {
                    $(this).val("");
                } else {
                    $(this).select();
                }
            });
            inp.slice(i, i + 1).blur(function () {
                if ($(this).val() == "") {
                    $(this).val($(this).attr("rel"));
                }
            });
        }
    }
}



//通过函数
function checkAll(field, c) {
    for (i = 0; i < field.length; i++)
        field[i].checked = c.checked;
} 
function wxselectChange(th) {
    var thValue = $(th).val();
    alert("进入获取中请稍后...");
    var rnd = Math.random();
    $.get("GetUpdateWX.ashx?r=" + thValue + "&w=" + rnd, function (data) {
        alert(data);
    });
}
function wxGetimage(th2) {

    var rnd = Math.random();
    $.get("GetWximage.ashx?w=" + rnd, function (data) {
        $(th2).val(data);
    });
}
function GettwList(th2) {

    var rnd = Math.random();
    $.get("GetWxtwList.ashx?w=" + rnd, function (data) {
        $(th2).html('');
        $(th2).append(data);
    });
}
function selectChange(th, th2) { 
    $(th2).empty(); 
    if ($(th).val() == "") { //如果当前选择项值为空,则显示输入框，隐藏下拉框
        $("#txtUrl_2").hide();
        $("#txturl").show();
    }
    else { //如果当前选择项值不为空,则显示第二个下拉框,输入框隐藏 
        $("#txturl").hide();
        $("#txtUrl_2").hide();
        $("#txtUrl_3").hide();
        //判断第一级选择的值,有些是直接填充如输入框的. 
        switch ($(th).val()) {
            case "index":
            case "newslist":
            case "prolist":
            case "tpage":
            case "photolist":
                $("#txturl").val($(th).val()+".aspx");
                break;
            case "Goodslist":
            case "teamlist":
            case "mslist":
                $("#txturl").val("/appx/" + $(th).val() + ".aspx");
                break;
            case "vote":
                $("#txturl").val("/tdxtp/");
                break;
            case "member":
                $("#txturl").val("/vip/myhome.aspx");
                break;
            case "honor_list":
                $("#txturl").val("honor_action.aspx");
                break;
            case "controls":
                $("#txturl").val("ShowControl.aspx");
                break;
            default:
                $("#txturl").val("index.aspx");
                break;
        } 
         
        switch($(th).val()){
            case "newslist":
            case "prolist":
            case "tpage":
            case "photolist":
            case "Goodslist":
            case "teamlist":
            case "mslist":
            case "honor_list":
            case "controls":
                $("#txtUrl_2").show(); 
                $.get("../sets/GetFunc.ashx?rnd=" + Math.random() + "&q=" + $(th).val(), function (data) { //将填充第二个下拉框  
                    $(th2).append(data);
                });
                break;
            default:
                break;
        }
        
    } 
    
}  
function selectChange2(th, th2, th3) {
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
            var _url2 = "honor_action";
            if($("#txtUrl_2").val()=="4")
                _url2 += "egg";
            else if($("#txtUrl_2").val()=="2")
                _url2 += "2";
            _url2 +=".aspx?typeid=" + th2Value;
            $("#txturl").val(_url2);

            $(th3).empty();
            if ($(th2).val() == "") {
                $("#txtUrl_2").hide();
                $("#txtUrl_3").hide();
                $("#txturl").show();
            }
            else {
                $("#txtUrl_2").show();
                $("#txtUrl_3").show();
                $("#txturl").hide();
            }
            $.get("../sets/GetFunc.ashx?q=" + $(th).val() + "&r=" + $(th2).val(), function (data) {
                $(th3).append(data);
            });
            break;
        case "controls":
            $("#txturl").val("ShowControl.aspx?id=" + th2Value);
            break;
        case "tpage": 
            $("#txturl").val(thValue + ".aspx?cno=" + th2Value);
            $(th3).empty();
            if ($(th2).val() == "") {
                $("#txtUrl_3").hide();
            }
            else {
                $("#txtUrl_3").show();
                $.get("../sets/GetFunc.ashx?q=tpage&r=" + $(th2).val(), function (data) {
                    $(th3).append(data);
                });
            } 
            break;
       
        default:
            $("#txtUrl_2").hide();
            $("#txturl").show();
            break;
    }
}


function select_Change3(th, th2, th3) {
    var thValue = $(th).val();
    th2Value = $(th2).val();
    var th3Value = $(th3).val();
    switch (thValue) { 
        case "honor_list":
            //$("#txturl").val(thValue + ".aspx?cno=" + th2Value + "&typeID=" + th3Value);
            $("#txturl").val($("#txturl").val() + "&cno=" + th2Value + "&id=" + th3Value);
            break;
        case "tpage":
            if (th3Value == "")
                $("#txturl").val(thValue + ".aspx?cno=" + th2Value);
            else
                $("#txturl").val(thValue + ".aspx?id=" + th3Value);
            break;
        default:
            $("#txtUrl_3").hide();
            $("#txtUrl_2").hide();
            $("#txturl").show();
            break;

    }
}

function point(_this, attr, to) {
    to = $(".enter_remind");
    to.stop();
    to.html("<div _from=\"" + _this.attr("id") + "\" style=\"opacity: 0;position: absolute; filter:alpha(opacity=0);background-color:#fff; background-repeat: no-repeat; background-image: url(&quot;data:image/gif;base64,R0lGODlhEAAJALMPAIWFhXJycrGxsZqamubm5pKSknBwcNvb27m5uYCAgMvLy6ampmZmZgAAAP///////yH/C05FVFNDQVBFMi4wAwEAAAAh+QQFAAAPACwAAAAAEAAJAAAEIrDJSatMZiF1nP/elW0d+IkaZ54NlpYrSq5hO6q0jMdWP0UAIfkEBQAADwAsAQABAAQABwAABApwlWQktXXmq3EEACH5BAUAAA8ALAEAAQAGAAcAAAQPUKFVkpHU4non35oXZkYEACH5BAUAAA8ALAEAAQAIAAcAAAQTkByFVklGUot1vdn0dSIXbqBnRgAh+QQFAAAPACwBAAEACgAHAAAEGdA5chRaJRlJLdZcdWXbJH5lN4KmR4auFgEAIfkEBQAADwAsAwABAAoABwAABBnQOXIUWiUZSS3WXHVl2yR+ZTeCpkeGrhYBACH5BAUAAA8ALAUAAQAKAAcAAAQZ0DlyFFolGUkt1lx1ZdskfmU3gqZHhq4WAQAh+QQFAAAPACwHAAEACAAHAAAEE9A5chRaTFKLdb3Z9HUiF26gZ0YAIfkEBQAADwAsCQABAAYABwAABA/QOcICkNTieiffmhdmQAQAIfkEBQAADwAsCQABAAYABwAABA+QsQCGkNTieiffmhdmQgQAIfkEBQAADwAsBwABAAgABwAABBOQmVQWUkdSi3W92fR1IhduoGdGACH5BAUAAA8ALAUAAQAKAAcAAAQZkJlUFlLHOUkt1lx1ZdskfmU3gqZHhq4WAQAh+QQFAAAPACwDAAEACgAHAAAEGZCZVBZSxzlJLdZcdWXbJH5lN4KmR4auFgEAIfkEBQAADwAsAQABAAoABwAABBmQmVQWUsc5SS3WXHVl2yR+ZTeCpkeGrhYBADs=&quot;); background-position: center center;\"></div>");
    to.children().width(to.width());
    to.children().height(to.height());
    to.children().offset(to.offset());
    to.children().stop();
    to.children().animate({ "opacity": "0.6" }, 200, function () {
        var obj = new Image();
        obj.src = _this.attr(attr);
        if (obj.complete) {
            to.width(obj.width);
            to.height(obj.height);
            to.css("background-image", "url( " + obj.src + " )");
            to.children().animate({ opacity: 0 }, 200, function () {
                to.children().remove();
            });
        }
        else {
            obj.onload = function () {
                to.width(obj.width);
                to.height(obj.height);
                to.css("background-image", "url( " + obj.src + " )");
                obj.onload = null;
                to.children().animate({ opacity: 0 }, 200, function () {
                    to.children().remove();
                });
            }
        }
    });
}

function mask(_this) {
    var mask_alertHtml = "<div class=\"mask_alert\"><h1 class=\"mask_Title\">" + _this.attr("_title") + "<a href='javascript:void(0)'>关闭</a></h1><div><iframe src=\"" + _this.attr("_target") + "\"></iframe></div></div>";
    $("body").append("<div class=\"mask\"></div>");
    $(".nei_content").append(mask_alertHtml);
    var alertTop = 0, alertLeft = 0;
    alertTop = ($(".mask").height() - $(".mask_alert").height() - 8) / 2;
    alertLeft = ($(".mask").width() - $(".mask_alert").width() - 8) / 2;
    $(".mask_alert").offset({ top: alertTop, left: alertLeft });
    $(".mask_Title a").click(function () { $(".mask_alert,.mask").remove(); });
}

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}
function ltrim(stringToTrim) {
    return stringToTrim.replace(/^\s+/, "");
}
function rtrim(stringToTrim) {
    return stringToTrim.replace(/\s+$/, "");
}
/*添加幻灯片顶部幻灯片预览*/
function ads_show() {
    $(".ads_show ul li").each(function (i) {
        if (i > 0) {
            $(".ads_show ol").append("<li></li>");
        }
        else {
            $(".ads_show ol").append("<li class=\"on\"></li>");
        }
    });
    $(".ads_show ul").width(($(".ads_show ul li").width() * $(".ads_show ul li").length));
    $(".ads_show ol li").click(function () {
        var _this = $(this);
        $(".ads_show ol li").removeClass("on");
        _this.addClass("on");
        var _left = ($(".ads_show ol li").index(_this) * $(".ads_show ul li").width());
        $(".ads_show ul").animate({ "left": "-" + _left + "px" });
    });
    $(".ads_show ol li").eq($(".ads_show ol li").length - 1).click()
    /*添加 修改切换*/
    $(".ads_show ul li .ads_edit .infoEdit").unbind().click(function () {
        var _this = $(this);
        $("body").append("<div id=\"temp\"></div>");
        $("#temp").css("position", "absolute");
        $("#temp").css("border", "8px solid #ddd");
        $("#temp").width($(".ads_show").width());
        $("#temp").height($(".ads_show").height());
        $("#temp").offset($(".ads_show").offset());
        $("#temp").animate({ top: $(".ads_content .enter_table").offset().top - 8, left: $(".ads_content .enter_table").offset().left - 8, width: $(".ads_content .enter_table").width(), heifht: $(".ads_content .enter_table").height() }, function () {
            $("#temp").remove();
            $("#txtname").val(_this.parent().attr("ads_name"));
            $("#txturl").val(_this.parent().attr("ads_url"));
            $("#txtsort").val(_this.parent().attr("ads_sort"));
            $("#btnsave").attr("ads_id", _this.parent().attr("ads_id"));
            $("#btnsave").attr("ads_pic", encodeURIComponent(_this.parent().prev().attr("src")));
        });
    });
    /*删除*/
    $(".ads_show ul li .ads_edit .infoDelete").unbind().click(function () {
        var r = confirm("是否删除");
        if (r) {
            //ads_id
            var ads_id = $(this).parent().attr("ads_id");
            $.ajax({
                url: "Ajax_B2C_ADS_ADD.ashx?type=del&adsid=" + ads_id, /*设置post提交到的页面*/
                type: "get", /*设置表单以post方法提交*/
                success: function (str) {
                    if (parseInt(str) > 0) {
                        var url = window.location.href;
                        window.location.href = url;
                    }
                    else {
                        //$("#btnsave").before("<div class=\"tsxx temp_tsxx\" style=\"display:block; width:300px;\">" + str + "</div><script>setTimeout(function(){$('.temp_tsxx').remove()},1000)</script>");
                    }
                },
                error: function (error) { alert(error); }
            });
        }
    });
    $(".btnAdd").click(function () {
        $(".enter_table[_type='edit']").stop().animate({ top: "-" + ($(".enter_table[_type='edit']").height() + 8) + "px" }, 500, function () {
            $("#txtname").val("");
            $("#txturl").val("");
            $("#txtsort").val("");
            $("#fileimg").val("")
            $("#btnsave").attr("ads_id", "");
            $("#btnsave").attr("ads_pic", "");
            $(".enter_table[_type='edit']").animate({ "top": "0px" }, 250);
        });
        //$(".enter_table[_type='add']").show().animate({ "opacity": "1" });
    });
    /*添加修改切换 结束*/
    /*添加按钮*/
    $("#btnsave").click(function () {
        updating($(this));
        var json = ads_json($(this));
        $.ajax({
            url: "Ajax_B2C_ADS_ADD.ashx?type=save", /*设置post提交到的页面*/
            type: "post", /*设置表单以post方法提交*/
            data: json, /**/
            dataType: "html", /*设置返回值类型为文本*/
            success: function (str) {
                if (parseInt(str) == 1) {
                    var url = window.location.href;
                    window.location.href = url;
                }
                else {
                    $(".nei_temp").hide();
                    $("#btnsave").after("<div class=\"tsxx temp_tsxx\" style=\"display:block; \">" + str + "</div><script>setTimeout(function(){$('.temp_tsxx').remove();$('#btnsave').next().remove()},1000)</script>");
                }
            },
            error: function (error) { alert(error); }
        });
    });
    $("#fileimg").change(function () {
        $("#form1").ajaxSubmit({
            url: "Ajax_B2C_ADS_ADD.ashx?type=pic", /*设置post提交到的页面*/
            type: "post", /*设置表单以post方法提交*/
            dataType: "text", /*设置返回值类型为文本*/
            success: function (str) {
                $("#btnsave").attr("ads_pic", encodeURIComponent(str));
            },
            error: function (error) { alert(error); }
        });
    });
}
function ads_json(_this) {
    var ads_id = (_this.attr("ads_id") == null) ? "" : _this.attr("ads_id");
    var ads_name = ($("#txtname").val() == null) ? "" : $("#txtname").val();
    var ads_url = ($("#txturl").val() == null) ? "" : $("#txturl").val();
    var ads_sort = ($("#txtsort").val() == null) ? "" : $("#txtsort").val();
    var ads_pic = (_this.attr("ads_pic") == null) ? "" : _this.attr("ads_pic");
    var json = "{";
    json += "\"ads_id\":\"" + ads_id + "\",";
    json += "\"ads_name\":\"" + ads_name + "\",";
    json += "\"ads_url\":\"" + encodeURIComponent(ads_url) + "\","; 
    json += "\"ads_sort\":\"" + ads_sort + "\",";
    json += "\"ads_pic\":\"" + ads_pic + "\"";
    json += "}"
    return json;
}

function updating(_this) {
    $(".nei_temp").show();
    //_this.after("<div class=\"nei_temp\"></div>");
    $(".nei_temp img").attr("src", "data:image/gif;base64,R0lGODlhEAAJALMPAIWFhXJycrGxsZqamubm5pKSknBwcNvb27m5uYCAgMvLy6ampmZmZgAAAP///////yH/C05FVFNDQVBFMi4wAwEAAAAh+QQFAAAPACwAAAAAEAAJAAAEIrDJSatMZiF1nP/elW0d+IkaZ54NlpYrSq5hO6q0jMdWP0UAIfkEBQAADwAsAQABAAQABwAABApwlWQktXXmq3EEACH5BAUAAA8ALAEAAQAGAAcAAAQPUKFVkpHU4non35oXZkYEACH5BAUAAA8ALAEAAQAIAAcAAAQTkByFVklGUot1vdn0dSIXbqBnRgAh+QQFAAAPACwBAAEACgAHAAAEGdA5chRaJRlJLdZcdWXbJH5lN4KmR4auFgEAIfkEBQAADwAsAwABAAoABwAABBnQOXIUWiUZSS3WXHVl2yR+ZTeCpkeGrhYBACH5BAUAAA8ALAUAAQAKAAcAAAQZ0DlyFFolGUkt1lx1ZdskfmU3gqZHhq4WAQAh+QQFAAAPACwHAAEACAAHAAAEE9A5chRaTFKLdb3Z9HUiF26gZ0YAIfkEBQAADwAsCQABAAYABwAABA/QOcICkNTieiffmhdmQAQAIfkEBQAADwAsCQABAAYABwAABA+QsQCGkNTieiffmhdmQgQAIfkEBQAADwAsBwABAAgABwAABBOQmVQWUkdSi3W92fR1IhduoGdGACH5BAUAAA8ALAUAAQAKAAcAAAQZkJlUFlLHOUkt1lx1ZdskfmU3gqZHhq4WAQAh+QQFAAAPACwDAAEACgAHAAAEGZCZVBZSxzlJLdZcdWXbJH5lN4KmR4auFgEAIfkEBQAADwAsAQABAAoABwAABBmQmVQWUsc5SS3WXHVl2yR+ZTeCpkeGrhYBADs=")
    $(".nei_temp").offset(_this.offset());
    $(".nei_temp").width(_this.width() + 20);
    $(".nei_temp").height(_this.height() + 8);
    $(".nei_temp").css("line-height", $(".nei_temp").height() + "px");
}