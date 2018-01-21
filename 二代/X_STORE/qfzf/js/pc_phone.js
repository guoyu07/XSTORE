function IsPC(){  
			var userAgentInfo = navigator.userAgent;  
			var Agents = new Array("Android", "iPhone", "SymbianOS", "Windows Phone", "iPad", "iPod");  
			var flag = true;  
			for (var v = 0; v < Agents.length; v++) {  
               if (userAgentInfo.indexOf(Agents[v]) > 0) { flag = false; break; }  
			}  
			return flag;  
        } 
var y=IsPC();
//上面判断是否是移动端
if(y){
document.write('<script src="js/pc.js" type="text/javascript"></script>');


}else{
document.write('<script src="js/phone.js" type="text/javascript"></script>');
}