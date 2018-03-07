$(function(){
    $('#button').on('click', function(e){
        var pairs = $('form').serialize().split(/&/gi);
        var data = {};
        pairs.forEach(function(pair) {
            pair = pair.split('=');
            data[pair[0]] = decodeURIComponent(pair[1] || '');
        });
        if(!data.name){
            $.weui.topTips('请输入姓名');
            return;
        }
        if(!data.idcard || !/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/.test(data.idcard)){
            $.weui.topTips('请输入正确的身份证号码');
            return;
        }
    })
})