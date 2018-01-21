$(function(){
	var cartObj={
		init:function(){
			this.render();
			this.bindEvent();
			this.getData();
		},
		render:function(){
			
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
			$("ul").on('click', '.del', function () {
			    alert(1);
			    var num = $(this).parents('li').find('#cart_id').text();
			    console.log(num);
			    $.ajax({
                    url: '/ashx/CartDel.ashx',
			        type: 'get',
			        data: {
			            CartId: num
			        },
			        success: function (result) {
			            // window.location.reload();
			            alert(result);
			        }
			    })
			})
		},
		getData:function(){

		}
	};
	cartObj.init();
})