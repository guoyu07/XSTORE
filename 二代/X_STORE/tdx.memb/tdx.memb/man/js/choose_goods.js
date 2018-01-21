function choose_goods(obj, choose) {
    var ctl = "";
    var btn = "";
    var val = "";
    var obj = $(obj).parent();
    switch (choose) {
        case "single":
            ctl = $(obj).attr("hide");
            btn = $(obj).attr("id");
            var url = $(obj).find("input[id*=url]").eq(0).attr("id");
            val = url;
            break;
        case "multiple":
            ctl = $(obj).parent().find("table").eq(0).attr("id");
            btn = $(obj).attr("id");
            break;
    }
    var objNum = arguments.length;
    var show = $.dialog({
        id: 'goods_info_dialog',
        lock: true,
        max: false,
        min: false,
        title: "商品信息",
        content: 'url:Shop/goods_choose.aspx?ctl=' + ctl + '&choose=' + choose + '&btn=' + btn + "&val=" + val,
        width: 1000,
        height: 500
    });
    show.data = window.document;
}
