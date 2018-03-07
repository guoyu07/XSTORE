$(function(){
  var max = 200;
  $('#textarea_jj').on('input', function(){
     var text = $(this).val();
     var len = text.length;
    
     $('#count_jj').text(len);
    
     if(len > max){
       $(this).closest('.weui_cell').addClass('weui_cell_warn');
     }
     else{
       $(this).closest('.weui_cell').removeClass('weui_cell_warn');
     }
     
  });
})

$(function(){
  var max = 30;
  $('#textarea').on('input', function(){
     var text = $(this).val();
     var len = text.length;
    
     $('#count').text(len);
    
     if(len > max){
       $(this).closest('.weui_cell').addClass('weui_cell_warn');
     }
     else{
       $(this).closest('.weui_cell').removeClass('weui_cell_warn');
     }
     
  });
})