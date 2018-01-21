$(function(){
	var cartObj={
		init:function(){
			this.render();
			this.bindEvent();
			this.getData();
		},
		render:function(){
			$('#foot ul li').eq(1).addClass('clickOn').siblings().removeClass('clickOn');
		},
		bindEvent:function(){
			$('.editor').on('click',function(){
				$('.del').show();
				$(this).hide();
				$('.finish').show();
			});
			$('.finish').on('click',function(){
				$(this).hide();
				$('.editor').show();
				$('.del').hide();
			});
			$('ul').on('click','li .del',function(){
				var that=this;
				layer.open({
					content:'是否删除该商品？',
					btn:['确认','取消'],
					yes:function(index){
						$(that).parent().remove();
						layer.close(index);
					}
				})
			});
		},
		getData:function(){

		}
	};
	cartObj.init();
})