$(function () {

    var router = new Router({
      container: '#container',
	  // container: '#ActionSheet', 
        enterTimeout: 250,
        leaveTimeout: 250
    });
     
 
    // actionsheet
    var actionsheet = {
        url: '/',
        className: 'actionsheet',
        render: function () {
            return  $('#tpl_actionsheet').html();
        },
        bind: function () {
            $('#container').on('click', '#showActionSheet', function () {
                var mask = $('#mask');
                var weuiActionsheet = $('#weui_actionsheet');
                weuiActionsheet.addClass('weui_actionsheet_toggle');
                mask.show().addClass('weui_fade_toggle').one('click', function () {
                    hideActionSheet(weuiActionsheet, mask);
                });
                $('#actionsheet_cancel').one('click', function () {
                    hideActionSheet(weuiActionsheet, mask);
                });
                weuiActionsheet.unbind('transitionend').unbind('webkitTransitionEnd');

                function hideActionSheet(weuiActionsheet, mask) {
                    weuiActionsheet.removeClass('weui_actionsheet_toggle');
                    mask.removeClass('weui_fade_toggle');
                    weuiActionsheet.on('transitionend', function () {
                        mask.hide();
                    }).on('webkitTransitionEnd', function () {
                        mask.hide();
                    })
                }
            });
        }
    };
 
  


    router.push(actionsheet)
        .setDefault('/')
        .init();


    // .container 设置了 overflow 属性, 导致 Android 手机下输入框获取焦点时, 输入法挡住输入框的 bug
    // 相关 issue: https://github.com/weui/weui/issues/15
    // 解决方法:
    // 0. .container 去掉 overflow 属性, 但此 demo 下会引发别的问题
    // 1. 参考 http://stackoverflow.com/questions/23757345/android-does-not-correctly-scroll-on-input-focus-if-not-body-element
    //    Android 手机下, input 或 textarea 元素聚焦时, 主动滚一把
    if (/Android/gi.test(navigator.userAgent)) {
        window.addEventListener('resize', function () {
            if (document.activeElement.tagName == 'INPUT' || document.activeElement.tagName == 'TEXTAREA') {
                window.setTimeout(function () {
                    document.activeElement.scrollIntoViewIfNeeded();
                }, 0);
            }
        })
    }
});