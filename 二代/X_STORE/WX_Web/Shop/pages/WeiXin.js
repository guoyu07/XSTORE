wx.ready(function () {
    // 9 寰俊鍘熺敓鎺ュ彛
    // 9.1.1 鎵弿浜岀淮鐮佸苟杩斿洖缁撴灉
    document.querySelector('#scanQRCode0').onclick = function () {
        wx.scanQRCode();
    };
    // 9.1.2 鎵弿浜岀淮鐮佸苟杩斿洖缁撴灉
    document.querySelector('#scanQRCode1').onclick = function () {
        wx.scanQRCode({
            needResult: 1,
            desc: 'scanQRCode desc',
            success: function (res) {
                alert(JSON.stringify(res));
            }
        });
    };

});

wx.error(function (res) {
    alert(res.errMsg);
});