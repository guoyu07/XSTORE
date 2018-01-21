var reg = new RegExp("\"", "g");
$(function () {
    Save();
    Update();
});
//左右数据同步
function titleShow() {
    $("#txtTitle,#txtAuthor,#txtBodyUrl,#summary").keyup(function () {
        var _this = $(this);
        var _thisID = _this.attr("id");
        var _thisTarget = _this.parent().parent().parent().attr("target");
        if (_thisID == "txtTitle") {
            $("#" + _thisTarget + " .imgTitle span").text(_this.val());
            if (trim(_this.val()) == "") {
                $("#" + _thisTarget + " .imgTitle span").text("标题");
            }
        }
        saveToHidden();
    });
}
//点击更换编辑
function editOtherInfo() {
    $(".otherInfo .infoEdit,.titlePageInfo .infoEdit").unbind("click").click(function () {
        saveToHidden();
        var _this = $(this).parent().parent();
        var _top = _this.offset().top - $(".main").offset().top - 32 - 9;
        var arrow_top = _this.offset().top + 31;
        $(".main_edit").css("margin-top", _top + "px");
        $(".main_edit_arrow").offset({ top: arrow_top });
        $(".main_edit").attr("target", _this.attr("id"));
        hiddenToShow(_this.attr("id"));
        if (_this.attr("class") == "otherInfo") {
            $("html").animate({ "scrollTop": _this.offset().top - _this.prev().height() });
        }
        else {
            $("html").animate({ "scrollTop": 0 });
        }
    });
}
//点击删除
function delOtherInfo() {
    $(".otherInfo .infoDelete").unbind("click").click(function () {
        var _this = $(this).parent().parent();
        var _thisId = _this.attr("id");
        var _itemid = (_this.children("[name='hidden']").attr("_itemid") == null) ? "" : _this.children("[name='hidden']").attr("_itemid");
        $("#delItem").val($("#delItem").val() + "," + _itemid);
        _this.remove();
        var edit_target = $(".main_edit").attr("target");
        //结构变动重新定位
        if (_thisId == edit_target) {
            var _top = $(".titlePageInfo").offset().top - $(".main").offset().top - 32 - 9;
            var arrow_top = $(".titlePageInfo").offset().top + 40;
            $(".main_edit").css("margin-top", _top + "px");
            $(".main_edit_arrow").offset({ top: arrow_top });
            $(".main_edit").attr("target", "titlePageInfo");
            hiddenToShow("titlePageInfo");
        }
        else {
            var _top = $("#" + edit_target).offset().top - $(".main").offset().top - 32 - 9;
            var arrow_top = $("#" + edit_target).offset().top + 40;
            $(".main_edit").css("margin-top", _top + "px");
            $(".main_edit_arrow").offset({ top: arrow_top });
        }
    });
}
//保存到hidden中
function saveToHidden() {
    var _targte = $(".main_edit").attr("target");
    $("#" + _targte + " [name='hidden']").attr("_title", strEncode($(".main_edit #txtTitle").val())); /*标题*/
    $("#" + _targte + " [name='hidden']").attr("_pic", strEncode($(".main_edit #_thisImg").attr("src"))); /*图片地址*/
    $("#" + _targte + " [name='hidden']").attr("_author", strEncode($(".main_edit #txtAuthor").val())); /*作者*/
    $("#" + _targte + " [name='hidden']").html(strEncode(FCKeditorAPI.GetInstance("_msg").GetXHTML())); /*正文*/
    $("#" + _targte + " [name='hidden']").attr("_summary", strEncode($(".main_edit #summary").val())); /*摘要*/
    $("#" + _targte + " [name='hidden']").attr("_body_url", strEncode($(".main_edit #txtBodyUrl").val())); /*原文连接*/
}
//从hidden中提取并展现
function hiddenToShow(_targte) {
    /*标题*/
    $(".main_edit #txtTitle").val(strDecode($("#" + _targte + " [name='hidden']").attr("_title")));
    /*图片地址*/
    $(".main_edit #_thisImg").attr("src", strDecode($("#" + _targte + " [name='hidden']").attr("_pic")));
    if ($("#" + _targte + " [name='hidden']").attr("_pic") == "" || $("#" + _targte + " [name='hidden']").attr("_pic") == null) {
        $(".main_edit #_thisImg").attr("src", "");
        $(".main_edit #_thisImg").hide();
        $("#delImg").hide();
    }
    else {
        $(".main_edit #_thisImg").show();
        $("#delImg").show();
    }
    /*作者*/
    $(".main_edit #txtAuthor").val(strDecode($("#" + _targte + " [name='hidden']").attr("_author")));
    /*正文*/
    var oEditor = FCKeditorAPI.GetInstance('_msg');
    oEditor.SetHTML(($("#" + _targte + " [name='hidden']").html() == null) ? "" : strDecode($("#" + _targte + " [name='hidden']").html()), false);
    /*摘要*/
    $(".main_edit #summary").val(strDecode($("#" + _targte + " [name='hidden']").attr("_summary")));
    //$(".main_edit #txtBody").val($("#" + _targte + " [name='hidden']").attr("_body"));
    /*跳转连接*/
    $(".main_edit #txtBodyUrl").val(strDecode($("#" + _targte + " [name='hidden']").attr("_body_url")));
}
//添加一个
function getOtherInfo(num) {
    var html = "";
    html += "<div class=\"otherInfo\" id=\"otherItem" + num + "\">";
    html += "<div class=\"imgBg\"><span>缩略图</span><img></div>";
    html += "<div class=\"imgTitle\">";
    html += "<span>标题</span></div>";
    html += "<div class=\"imgEidt\">";
    html += "<a href=\"javascript:void(0)\" class=\"infoEdit\">编辑</a><a href=\"javascript:void(0)\" class=\"infoDelete\">删除</a></div>";
    html += "<div  name=\"hidden\" class=\"hidden_body\"><div>";
    html += "</div>";
    return html;
}
/*更新*/
function upload() {
    $("#selectFile").change(function () {
        if ($("#selectFile").val() != "") {
            var _target = $(".main_edit").attr("target");
            $("#_thisImg").show();
            $("#_thisImg").attr("src", "data:image/gif;base64,R0lGODlhEAAJALMPAIWFhXJycrGxsZqamubm5pKSknBwcNvb27m5uYCAgMvLy6ampmZmZgAAAP///////yH/C05FVFNDQVBFMi4wAwEAAAAh+QQFAAAPACwAAAAAEAAJAAAEIrDJSatMZiF1nP/elW0d+IkaZ54NlpYrSq5hO6q0jMdWP0UAIfkEBQAADwAsAQABAAQABwAABApwlWQktXXmq3EEACH5BAUAAA8ALAEAAQAGAAcAAAQPUKFVkpHU4non35oXZkYEACH5BAUAAA8ALAEAAQAIAAcAAAQTkByFVklGUot1vdn0dSIXbqBnRgAh+QQFAAAPACwBAAEACgAHAAAEGdA5chRaJRlJLdZcdWXbJH5lN4KmR4auFgEAIfkEBQAADwAsAwABAAoABwAABBnQOXIUWiUZSS3WXHVl2yR+ZTeCpkeGrhYBACH5BAUAAA8ALAUAAQAKAAcAAAQZ0DlyFFolGUkt1lx1ZdskfmU3gqZHhq4WAQAh+QQFAAAPACwHAAEACAAHAAAEE9A5chRaTFKLdb3Z9HUiF26gZ0YAIfkEBQAADwAsCQABAAYABwAABA/QOcICkNTieiffmhdmQAQAIfkEBQAADwAsCQABAAYABwAABA+QsQCGkNTieiffmhdmQgQAIfkEBQAADwAsBwABAAgABwAABBOQmVQWUkdSi3W92fR1IhduoGdGACH5BAUAAA8ALAUAAQAKAAcAAAQZkJlUFlLHOUkt1lx1ZdskfmU3gqZHhq4WAQAh+QQFAAAPACwDAAEACgAHAAAEGZCZVBZSxzlJLdZcdWXbJH5lN4KmR4auFgEAIfkEBQAADwAsAQABAAoABwAABBmQmVQWUsc5SS3WXHVl2yR+ZTeCpkeGrhYBADs=");
            var imgUrl = ajaxFileUpload(_target);
        }
    });
}
/*上传文件*/
function ajaxFileUpload(_target) {
    $("#form1").ajaxSubmit({
        url: "Ajax_B2C_Msg_Add.ashx?target=" + _target + "&type=addPic", /*设置post提交到的页面*/
        type: "post", /*设置表单以post方法提交*/
        dataType: "text", /*设置返回值类型为文本*/
        success: function (url) {
            $("#" + _target + " .imgBg span").hide();
            var img = new Image();
            img.src = url;
            if (img.complete) {
                $("#" + _target + " .imgBg img").attr("src", url);
                $("#" + _target + " .imgBg img").show();
                $("#" + _target + " .imgBg span").hide();
            }
            else {
                img.onload = function () {
                    $("#" + _target + " .imgBg img").attr("src", url);
                    $("#" + _target + " .imgBg img").show();
                    $("#" + _target + " .imgBg span").hide();
                }
            }
            $("#_thisImg").attr("src", url);
            $("#_thisImg").show();
            $("#delImg").show();
            $("#selectFile").val("");
            saveToHidden();
        },
        error: function (error) { alert(error); }
    });
}
/*删除文件*/
function delFile() {
    $("#delImg").click(function () {
        var _target = $(".main_edit").attr("target");
        $("#" + _target + " .imgBg span").show();
        $("#" + _target + " .imgBg img").hide();
        $("#" + _target + " .imgBg img").attr("src", "");
        $("#_thisImg").attr("src", "");
        $("#_thisImg").hide();
        $("#delImg").hide();
        saveToHidden();
    });
}

/*保存*/
function Save() {
    $("#btn_wxkey_AjaxSave").unbind().click(function () {
        updating($(this));
        saveToHidden();
        /*验证关键字*/
        var txt_gtitle = strEncode($("#txt_gtitle").val());
        if (trim(txt_gtitle) == "") {
            $(".nei_temp").hide();
            alert("关键字不能为空");
            $("html").scrollTop(0);
            $("#txt_gtitle").focus();
            return false;
        }
        /*wid*/
        var wid = $("#hfwid").val();
        if (wid == "") {
            location.href = "./main.aspx";
            return false;
        }
        /*验证结果*/
        var verification_result = "";
        /*封面信息*/
        var guid = $("#hfGuid").val(); /*总标识*/
        var itemid = ($(".titlePageInfo").children("[name='hidden']").attr("_itemid") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_itemid"); /*子标志*/
        var title = ($(".titlePageInfo").children("[name='hidden']").attr("_title") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_title"); /*标题*/
        var pic = ($(".titlePageInfo").children("[name='hidden']").attr("_pic") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_pic"); /*图片地址*/
        var author = ($(".titlePageInfo").children("[name='hidden']").attr("_author") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_author"); /*作者*/
        var body = ($(".titlePageInfo").children("[name='hidden']").html() == null) ? "" : $(".titlePageInfo").children("[name='hidden']").html(); /*正文*/
        var summary = ($(".titlePageInfo").children("[name='hidden']").attr("_summary") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_summary"); /*摘要*/
        var body_url = ($(".titlePageInfo").children("[name='hidden']").attr("_body_url") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_body_url"); /*跳转连接*/
        title = strZhengZe(title);
        pic = strZhengZe(pic);
        author = strZhengZe(author);
        body = strZhengZe(body);
        summary = strZhengZe(summary);
        body_url = strZhengZe(body_url);
        /*验证封面*/
        verification_result = verification(title, pic, author, body, summary, body_url);
        if (verification_result != "") {
            verification_result += "_titlePageInfo";
            ajaxSave(json, verification_result, "save");
            return false;
        }
        var json = "{"; /*json开始*/
        json += " \"guid\":\"" + guid + "\",\"keysname\":\"" + txt_gtitle + "\",\"wid\":" + parseInt(wid) + ","; /*guid*/
        json += "\"item\":[";  /*内容*/
        json += "{\"itemid\":\"" + itemid + "\",\"title\":\"" + title + "\",\"pic\":\"" + pic + "\",\"author\":\"" + author + "\",\"body\":\"" + body + "\",\"summary\":\"" + summary + "\",\"body_url\":\"" + body_url + "\"},";
        $(".otherInfo").each(function () {
            var _this = $(this);
            itemid = (_this.children("[name='hidden']").attr("_itemid") == null) ? "" : _this.children("[name='hidden']").attr("_itemid"); /*子标志*/
            title = (_this.children("[name='hidden']").attr("_title") == null) ? "" : _this.children("[name='hidden']").attr("_title"); /*标题*/
            pic = (_this.children("[name='hidden']").attr("_pic") == null) ? "" : _this.children("[name='hidden']").attr("_pic"); /*图片地址*/
            author = (_this.children("[name='hidden']").attr("_author") == null) ? "" : _this.children("[name='hidden']").attr("_author"); /*作者*/
            body = (_this.children("[name='hidden']").html() == null) ? "" : _this.children("[name='hidden']").html(); /*正文*/
            summary = ($(".titlePageInfo").children("[name='hidden']").attr("_summary") == null) ? "" : _this.children("[name='hidden']").attr("_summary"); /*摘要*/
            body_url = (_this.children("[name='hidden']").attr("_body_url") == null) ? "" : _this.children("[name='hidden']").attr("_body_url"); /*跳转连接*/
            title = strZhengZe(title);
            pic = strZhengZe(pic);
            author = strZhengZe(author);
            body = strZhengZe(body);
            summary = strZhengZe(summary);
            body_url = strZhengZe(body_url);
            json += "{\"itemid\":\"" + itemid + "\",\"title\":\"" + title + "\",\"pic\":\"" + pic + "\",\"author\":\"" + author + "\",\"body\":\"" + body + "\",\"summary\":\"" + summary + "\",\"body_url\":\"" + body_url + "\"},";
            verification_result = verification(title, pic, author, body, summary, body_url);
            if (verification_result != "") {
                verification_result += "_" + _this.attr("id");
                ajaxSave(json, verification_result, "save");
                return false;
            }
        });
        json = json.substr(0, json.length - 1);
        json += "],"/*内容收尾*/
        json += "\"del\":\"" + $("#delItem").val() + "\"";
        json += "}"; /*json收尾*/
        //$("#json").html(json);
        if (verification_result == "") {
            ajaxSave(json, "", "save");
        }
    });
}
/*保存AJAX事件*/
function ajaxSave(json, verification_result, post_type) {
    if (verification_result != "") {
        $(".nei_temp").hide();
        alert(verification_result.split('_')[0]);
        $("#" + verification_result.split('_')[2] + " .infoEdit").click();
    }
    else {
        $.ajax({
            url: "Ajax_B2C_Msg_Add.ashx?type=" + post_type,
            type: "post",
            data: json,
            dataType: "html",
            success: function (i) {
                if (i == "ok") {
                    location.href = "wx_keys_list.aspx?wid=" + $("#hfwid").val();
                }
                else {
                    $(".nei_temp").hide();
                    alert(i);
                }
            }
        });
    }
}
function Update() {
    $("#btn_wxkey_AjaxUpdate").click(function () {
        var btn_this = $(this);
        updating(btn_this);
        saveToHidden();
        /**/
        /*验证关键字*/
        var txt_gtitle = $("#txt_gtitle").val();
        txt_gtitle = strEncode(txt_gtitle);
        if (trim(txt_gtitle) == "") {
            $(".nei_temp").hide();
            alert("关键字不能为空");
            $("html").scrollTop(0);
            $("#txt_gtitle").focus();
            return false;
        }
        /*wid*/
        var wid = $("#hfwid").val();
        if (wid == "") {
            location.href = "./main.aspx";
            return false;
        }
        /*验证结果*/
        var verification_result = "";
        /*封面信息*/
        var guid = $("#hfGuid").val(); /*总标识*/
        var itemid = ($(".titlePageInfo").children("[name='hidden']").attr("_itemid") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_itemid"); /*子标志*/
        var title = ($(".titlePageInfo").children("[name='hidden']").attr("_title") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_title"); /*标题*/
        var pic = ($(".titlePageInfo").children("[name='hidden']").attr("_pic") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_pic"); /*图片地址*/
        var author = ($(".titlePageInfo").children("[name='hidden']").attr("_author") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_author"); /*作者*/
        var body = ($(".titlePageInfo").children("[name='hidden']").html() == null) ? "" : $(".titlePageInfo").children("[name='hidden']").html(); /*正文*/
        var summary = ($(".titlePageInfo").children("[name='hidden']").attr("_summary") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_summary"); /*摘要*/
        var body_url = ($(".titlePageInfo").children("[name='hidden']").attr("_body_url") == null) ? "" : $(".titlePageInfo").children("[name='hidden']").attr("_body_url"); /*原文连接*/
        title = strZhengZe(title);
        pic = strZhengZe(pic);
        author = strZhengZe(author);
        body = strZhengZe(body);
        summary = strZhengZe(summary);
        body_url = strZhengZe(body_url);
        /*验证封面*/
        verification_result = verification(title, pic, author, body, summary, body_url);
        if (verification_result != "") {
            verification_result += "_titlePageInfo";
            ajaxSave(json, verification_result, "update");
            return false;
        }
        var json = "{"; /*json开始*/
        json += " \"guid\":\"" + guid + "\",\"keysname\":\"" + txt_gtitle + "\",\"wid\":" + parseInt(wid) + ","; /*guid*/
        json += "\"item\":[";  /*内容*/
        json += "{\"itemid\":\"" + itemid + "\",\"title\":\"" + title + "\",\"pic\":\"" + pic + "\",\"author\":\"" + author + "\",\"body\":\"" + body + "\",\"summary\":\"" + summary + "\",\"body_url\":\"" + body_url + "\"},";
        $(".otherInfo").each(function () {
            var _this = $(this);
            itemid = (_this.children("[name='hidden']").attr("_itemid") == null) ? "" : _this.children("[name='hidden']").attr("_itemid"); /*子标志*/
            title = (_this.children("[name='hidden']").attr("_title") == null) ? "" : _this.children("[name='hidden']").attr("_title"); /*标题*/
            pic = (_this.children("[name='hidden']").attr("_pic") == null) ? "" : _this.children("[name='hidden']").attr("_pic"); /*图片地址*/
            author = (_this.children("[name='hidden']").attr("_author") == null) ? "" : _this.children("[name='hidden']").attr("_author"); /*作者*/
            body = (_this.children("[name='hidden']").html() == null) ? "" : _this.children("[name='hidden']").html(); /*正文*/
            summary = ($(".titlePageInfo").children("[name='hidden']").attr("_summary") == null) ? "" : _this.children("[name='hidden']").attr("_summary"); /*摘要*/
            body_url = (_this.children("[name='hidden']").attr("_body_url") == null) ? "" : _this.children("[name='hidden']").attr("_body_url"); /*原文连接*/
            title = strZhengZe(title);
            pic = strZhengZe(pic);
            author = strZhengZe(author);
            body = strZhengZe(body);
            summary = strZhengZe(summary);
            body_url = strZhengZe(body_url);
            json += "{\"itemid\":\"" + itemid + "\",\"title\":\"" + title + "\",\"pic\":\"" + pic + "\",\"author\":\"" + author + "\",\"body\":\"" + body + "\",\"summary\":\"" + summary + "\",\"body_url\":\"" + body_url + "\"},";
            verification_result = verification(title, pic, author, body, summary, body_url);
            if (verification_result != "") {
                verification_result += "_" + _this.attr("id");
                ajaxSave(json, verification_result, "update");
                return false;
            }
        });
        json = json.substr(0, json.length - 1);
        json += "],"/*内容收尾*/
        json += "\"del\":\"" + $("#delItem").val() + "\"";
        json += "}"; /*json收尾*/
        ajaxSave(json, verification_result, "update");
    });
}
//验证
function verification(title, pic, author, body, summary, body_url) {
    /*验证标题*/
    title = strDecode(title);
    if (trim(title) == "" || title.length > 64) {
        return "标题不能为空且长度不能超过34个字_title";
    }
    /*验证图片*/
    pic = strDecode(pic);
    if (pic != null) {
        //判断图片格式 只能是bmp, png, jpeg, jpg, gif
        var zhengze = /^.+\.bmp|.+\.png|.+\.jpeg|.+\.jpg|.+\.gif/;
        if (!zhengze.test(pic)) {
            return "请选择一张图片_pic";
        }
    }
    /*验证作者*/
    author = strDecode(author);
    if (trim(author) != "" && author.length > 8) {
        return "作者不能超过八个字_author";
    }
    /*验证摘要*/
    summary = strDecode(summary);
    if (trim(summary).lenght > 100) {
        return "原文链接不能超过100个字_summary";
    }
    /*验证原文连接*/
    if (body_url != "") {

    }
    return "";
}
/*文本域加载完成*/
function FCKeditor_OnComplete(editorInstance) {
    /*c创建编辑器*/
    if ($(".titlePageInfo [name='hidden']").attr("_body") != "") {
        hiddenToShow("titlePageInfo");
    }
    hiddenToShow("titlePageInfo");
    var otherInfoNum = $(".otherInfo").length;
    $(".otherAdd a").click(function () {
        if ($(".otherInfo").length == 8) {
            alert("最多只能添加八个");
        }
        else {
            otherInfoNum++;
            var _this = $(this).parent();
            _this.before(getOtherInfo(otherInfoNum));
            delOtherInfo();
            editOtherInfo();
        }
    });
    delOtherInfo();
    editOtherInfo();
    titleShow();
    upload();
    delFile();
}
function strZhengZe(str) {
    //str = strDecode(str);
    //str = enhtml(str, "");
    //var _str = str.replace(reg, "\\\"");
    return str;
}
function strEncode(str) {
    if (str == "" || str == null) {
        return "";
    }
    else {
        //先转HTML
        //str = enhtml(str, "");
        //再转URI
        str = encodeURIComponent(encodeURIComponent(str));
        return str;
    }
}
function strDecode(str) {
    if (str == "" || str == null) {
        return "";
    }
    else {
        //先解URI
        str = decodeURIComponent(decodeURIComponent(str));
        //再解HTML
        //str = dehtml(str)
        return str;
    }
}
/**
* 将str中的html符号转义,默认将转义''&<">''四个字符，可自定义reg来确定需要转义的字符
* @name unhtml
* @grammar UE.utils.unhtml(str); => String
* @grammar UE.utils.unhtml(str,reg) => String
* @example
* var html = '<body>You say:"你好！Baidu & UEditor!"</body>';
* UE.utils.unhtml(html); ==> &lt;body&gt;You say:&quot;你好！Baidu &amp; UEditor!&quot;&lt;/body&gt;
* UE.utils.unhtml(html,/[<>]/g) ==> &lt;body&gt;You say:"你好！Baidu & UEditor!"&lt;/body&gt;
*/
function enhtml(str, reg) {
    return str ? str.replace(reg || /[&<">'](?:(amp|lt|quot|gt|#39|nbsp);)?/g, function (a, b) {
        if (b) {
            return a;
        } else {
            return {
                '<': '&lt;',
                '&': '&amp;',
                '"': '&quot;',
                '>': '&gt;',
                "'": '&#39;'
            }[a]
        }
    }) : '';
}
/**
* 将str中的转义字符还原成html字符
* @name html
* @grammar UE.utils.html(str) => String //详细参见<code><a href = '#unhtml'>unhtml</a></code>
*/
function dehtml(str) {
    return str ? str.replace(/&((g|l|quo)t|amp|#39);/g, function (m) {
        return {
            '&lt;': '<',
            '&amp;': '&',
            '&quot;': '"',
            '&gt;': '>',
            '&#39;': "'"
        }[m]
    }) : '';
}
