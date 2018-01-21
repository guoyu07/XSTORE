function onUploadImgChange(sender,view1,view2,view3,reduce,w,h){     
    if( !sender.value.match( /.jpg|.gif|.png|.bmp/i ) ){ 
        alert('图片格式无效！');     
        return false;     
    }     
    var objPreview = document.getElementById(view1); //
    var objPreviewFake = document.getElementById(view2);//     
    var objPreviewSizeFake = document.getElementById(view3);
    
    if( sender.files &&  sender.files[0] ){     
        objPreview.style.display = 'block';
        objPreview.style.width ='auto';
        objPreview.style.height = 'auto';
        
        var file;
        var objectURL;
        if(window.XMLHttpRequest){
        	objectURL = window.URL.createObjectURL(sender.files[0]);
        	objPreview.src = objectURL;
        }else if(window.ActiveXObject){//IE
	        objPreview.src = sender.files[0].getAsDataURL();
        }
    }else if( objPreviewFake.filters ){      
        sender.select();     
        var imgSrc = document.selection.createRange().text;     
             
        objPreviewFake.filters.item('DXImageTransform.Microsoft.AlphaImageLoader').src = imgSrc;     
        objPreviewSizeFake.filters.item('DXImageTransform.Microsoft.AlphaImageLoader').src = imgSrc;     
        autoSizePreview( objPreviewFake,objPreviewSizeFake.offsetWidth, objPreviewSizeFake.offsetHeight);     
        objPreview.style.display = 'none';     
    }     
}     

function onPreviewLoad(sender,reduce_w,reduce_h){
    autoSizePreview( sender, sender.offsetWidth/reduce_w, sender.offsetHeight/reduce_h);     
}

function onPreviewLoad_(sender,w,h){
    autoSizePreview( sender, w, h);
}

function autoSizePreview( objPre, originalWidth, originalHeight){     
    var zoomParam = clacImgZoomParam( 300, 300, originalWidth, originalHeight );     
    objPre.style.width = zoomParam.width + 'px';     
    objPre.style.height = zoomParam.height + 'px';     
    objPre.style.marginTop = zoomParam.top + 'px';     
    objPre.style.marginLeft = zoomParam.left + 'px';   
}     
function clacImgZoomParam_(position_){
	
}
function clacImgZoomParam( maxWidth, maxHeight, width, height ){     
    var param = { width:width, height:height, top:0, left:0 };     
         
    if( width>maxWidth || height>maxHeight ){     
        rateWidth = width / maxWidth;     
        rateHeight = height / maxHeight;     
             
        if( rateWidth > rateHeight ){     
            param.width =  maxWidth;     
            param.height = height / rateWidth;     
        }else{     
            param.width = width / rateHeight;     
            param.height = maxHeight;     
        }     
    }     
    param.left = (maxWidth - param.width) / 2;     
    param.top = (maxHeight - param.height) / 2;     
         
    return param;     
}