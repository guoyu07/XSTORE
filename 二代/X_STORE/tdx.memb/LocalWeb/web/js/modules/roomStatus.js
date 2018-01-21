$(function(){
	var roomStatusObj={
		init:function(){
			this.render();
			this.bindEvent();
			this.getData();
		},
		render:function(){
			$('#foot ul li').eq(0).addClass('clickOn').siblings().removeClass('clickOn');
		},
		bindEvent:function(){
			$('ul').on('click','li',function(){
				if($(this).hasClass('nep')){
					alert('调用微信扫码');
				}else{
					window.location.href="pages/operation.html";
				};
			});
		},
		getData:function(){
			
		}
	};
	roomStatusObj.init();
})