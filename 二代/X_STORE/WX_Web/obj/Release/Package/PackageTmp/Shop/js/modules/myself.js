$(function(){
	var myselfObj={
		init:function(){
			this.render();
			this.bindEvent();
		},
		bindEvent:function(){
		    $("body").on('click',".openBox",function () {
		        $.ajax({
		            url: '../ashx/openbox.ashx',
		            data: {
		                openid: $('#order_lbl').text(),
		                mac: $(".mac_input").val()
		            },
		            type: 'get',
		            success: function (result) {
		                layer.open({
		                    content: result,
		                    time: 2
		                });
		                window.location.href = "myself.aspx";
		            }
		        })
		    })
		},
		render:function(){
			$('#foot ul li').eq(2).addClass('clickOn').siblings().removeClass('clickOn');
            $("a[name='con']").eq(2).addClass("on");
		}
	}
	myselfObj.init();
})
