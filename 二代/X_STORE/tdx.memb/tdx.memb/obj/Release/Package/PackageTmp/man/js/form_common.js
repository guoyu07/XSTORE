/// <reference path="../../dialog/dialog_attach1.aspx" />
/// <reference path="../../dialog/dialog_attach1.aspx" />
/// <reference path=".." />
/// <reference path="../dialog/dialog_attach1.aspx" />
/// <reference path="../dialog/dialog_attach1.aspx" />

$(function () {

    $(".upload-album").each(function () {
        $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "51200", sendurl: "../tools/upload_ajax.ashx", flashurl: "../JS/swfupload/swfupload.swf", filetypes: "*.*;" });
    });
    $(".attach-btn").click(function () {
        showAttachDialog();
    });
});
//创建附件窗口
function showAttachDialog(obj) {
    var objNum = arguments.length;
    var attachDialog = $.dialog({
        id: 'attachDialogId',
        lock: true,
        max: false,
        min: false,
        title: "上传附件",
        //content: 'url:memb/Hotel/dialog/dialog_attach1.aspx',
        content:'url:/man/dialog/dialog_attach1.aspx',
        width: 500,
        height: 180
    });
    //如果是修改状态，将对象传进去
    if (objNum == 1) {
        attachDialog.data = obj;
    }
}
//删除附件节点
function delAttachNode(obj) {
    $(obj).parent().remove();
}