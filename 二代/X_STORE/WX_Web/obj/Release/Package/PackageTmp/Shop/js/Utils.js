var Util = {
    Deserialize: function (utldata) { //反序列化
        var paramsString = utldata.replace("?", "");
        var paramsTempObj = paramsString.split("&");
        var paramsObj = {};

        for (var i = 0; i < paramsTempObj.length; i++) {
            paramsObj[paramsTempObj[i].split("=")[0]] = paramsTempObj[i].split("=")[1]
        }
        return paramsObj;
    }
}
var urlparamStr = location.search;
var commonSelf = Util.Deserialize(urlparamStr);
console.log('commonSelf', commonSelf)