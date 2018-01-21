$(function(){
	var roomDetailObj={
		init:function(){
			this.render();
			this.bindEvent();
			this.getData();
		},
		render:function(){
			
		},
		bindEvent:function(){
			var that=this;
			/*$('dl').on('click','button',function(){
				if($(this).attr('flag')==0){
					$(this).css({'background':'#eee'});
				}else{
					$(this).css({'background':'ff6600'});
				}
				that.isFinish();
			});
			$('.finish').on('click',function(){
				$('.tips').show();
			});
			$('.okBtn span').on('click',function(){
				window.history.back();
			})*/
		},
		getData:function(){

		},
		isFinish:function(){
//			if($('dl').find('').length==$('dl').find('input[type="checkbox"]').length){
//				$('.finish').removeAttr('disabled').css('background','#FF6600');
//			}else{
//				$('.finish').attr('disabled','disabled').css('background','#EEEEEE');
//			}
		}
	};
	roomDetailObj.init();
})