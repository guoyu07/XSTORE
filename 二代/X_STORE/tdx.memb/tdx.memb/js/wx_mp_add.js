$(function () {
    $("#txtName,#txtNichen,#txtGUID,#txtDID,#txtDpsw").click(function () {
        point($(this), "point_url", $(".wxmpadd_point"));
    });
    var c = 0;
    $("#txtGif").hover(function () {
        var _this = $(this);
        c = setTimeout(function () { point(_this, "point_url", $(".wxmpadd_point")); }, 500);
    }, function () {
        clearTimeout(c);
    });
    $("#btnfwq").click(function () {
        point($(this), "point_url", $(".wxmpadd_point"));
    });
    $("#txtName").click();
    $("#txtName").focus();
});

