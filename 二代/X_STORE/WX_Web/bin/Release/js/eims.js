
/*搜索*/
function CKSearch(){
var eType=trim(document.sform.eType.value);
var Title=trim(document.sform.Title.value);
if (Title==""){
	alert("请输入关键字");
	return false;
	exit;
}
window.location.href=eType+'List.asp?Title='+Title;
return true;
}

/*在线留言*/
function CKBook(){
   if (trim(document.eform.Title.value).length<3 || trim(document.eform.Title.value).length>30){
	  alert("标题为3~30个字符");
	  return false;
	  exit;
   }
   if (trim(document.eform.UserName.value).length<2 || trim(document.eform.UserName.value).length>10){
	  alert("昵称为2~10个字符");
	  return false;
	  exit;
   }
   return true;
}

/*删除空字符串*/
function trim(str){return str.replace(/(^\s*)|(\s*$)/g, "");} //删除左右两端的空格
function ltrim(str){return str.replace(/(^\s*)/g,"");} //删除左边的空格
function rtrim(str){return str.replace(/(\s*$)/g,"");} //删除右边的空格

function display(y){$(y).style.display=($(y).style.display=="none")?"":"none";}
function $Obj(objname){return document.getElementById(objname);}

/*会员登录*/
function CKLogin(){
   if (trim(document.Loginform.UserName.value).length<2 || trim(document.Loginform.UserName.value).length>15){
	  alert("用户名错误");
	  return false;
	  exit;
   }
   if (trim(document.Loginform.PassWord.value).length<5 || trim(document.Loginform.PassWord.value).length>18){
	  alert("密码错误");
	  return false;
	  exit;
   }
   if (trim(document.Loginform.Code.value) == ""){
	  alert("请填写验证码");
	  return false;
	  exit;
   }
   return true;
}

/*会员注册*/
function CKReg(){
   if (trim(document.Regform.UserName.value).length<2 || trim(document.Regform.UserName.value).length>15){
	  alert("用户名为2~15个字符");
	  return false;
	  exit;
   }
   if (trim(document.Regform.PassWord.value).length<6 || trim(document.Regform.PassWord.value).length>18){
	  alert("密码为6~18个字符");
	  return false;
	  exit;
   }
   var ispass=(/^\w+$/);   
   if (!ispass.test(document.Regform.PassWord.value)){
	  alert("密码只能包含字母数字");
	  return false;
	  exit;
   }   
   if (trim(document.Regform.PassWord.value) !== trim(document.Regform.fPassWord.value)){
	  alert("两次输入的密码不一致");
	  return false;
	  exit;
   }
   if (trim(document.Regform.Code.value) == ""){
	  alert("请填写验证码");
	  return false;
	  exit;
   }
   return true;
}

/*订购产品*/
function CKOrder(){
   if (trim(document.formOrder.ProductName.value) == ""){
	  alert("产品名称不能为空");
      document.formOrder.ProductName.focus();
	  return false;
	  exit;
   }
   if (trim(document.formOrder.Num.value) == ""){
	  alert("订购数量不能为空");
      document.formOrder.Num.focus();
	  return false;
	  exit;
   }
   if (trim(document.formOrder.UserName.value) == ""){
	  alert("真实姓名不能为空");
      document.formOrder.UserName.focus();
	  return false;
	  exit;
   }
   if (trim(document.formOrder.Address.value) == ""){
	  alert("详细地址不能为空");
      document.formOrder.Address.focus();
	  return false;
	  exit;
   }
   if (trim(document.formOrder.Tel.value) == ""){
	  alert("联系电话不能为空");
      document.formOrder.Tel.focus();
	  return false;
	  exit;
   }
   if (trim(document.formOrder.Code.value) == ""){
	  alert("请填写验证码");
      document.formOrder.Code.focus();
	  return false;
	  exit;
   }
   return true;
}