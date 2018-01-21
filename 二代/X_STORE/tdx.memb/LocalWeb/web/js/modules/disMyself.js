$(function(){
	var disMyselfObj={
		init:function(){
			this.render();
			this.bindEvent();
			this.getData();
		},
		render:function(){
			$('#foot ul li').eq(2).addClass('clickOn').siblings().removeClass('clickOn');
		},
		bindEvent:function(){
			$('.cancellation').on('click',function(){
				layer.open({
					title:'注销',
					content:'确认您要注销用户吗？',
					btn:['确认','取消'],
					yes:function(index){
						layer.close(index);
						window.location.href="login.html"
					}
				})
			});
			$('.tip dl .l').on('click',function(e){
				$('.tip').hide();
			});
			$('.tip dl .r').on('click',function(e){
				$('.tip').hide();
			});
			$('.tip').on('click',function(){
				$('.tip').hide();
			});
			$('.tipBox').on('click',function(event){
				 event.stopPropagation();
			});
		},
		getData:function(){
			
		}
	};
	disMyselfObj.init();
})