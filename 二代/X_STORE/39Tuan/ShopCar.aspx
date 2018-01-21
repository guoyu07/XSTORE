<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopCar.aspx.cs" Inherits="Tuan.ShopCar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>购物车</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="js/swipe.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" src="js/menu_min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".menu ul li").menu();
            refresh();
            // setInterval(refresh(), 1000);
        });
    </script>

    
    <script>
        function refresh()
        {
            var openid = '<%=openid%>';
     
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'ReFreshCar.ashx', //目标地址
                data: { openid: openid },
                error: function (msg) { alert(1111); },
                success: function (msg) {
               
                    $("#<%=CarInfo.ClientID%>").html(msg); 
                   
             

                }
            });
        }
   
        function leijia(id)
        { 
            var check=document.getElementById(id);
         
            //alert($("[name=che]").length);
            //alert($("[name=che]:checked").length);
           
            if ($("[name=che]:checked").length == $("[name=che]").length)
            {
                var qx = document.getElementById("qx");
                qx.checked = true;
            }
            if (check.checked == true) {
                
                $.ajax({
                    type: "POST", //用POST方式传输
                    dataType: "text", //数据格式:JSON
                    url: 'TotalMoney.ashx', //目标地址
                    data: { id: id, type: "dan" },
                    error: function (msg) { alert(111); },
                    success: function (msg) {
                         
                        var total = $("#<%=totalmoney.ClientID%>").text();
                       
                        var all = (total-0) + (msg-0);
                        
                        $("#<%=totalmoney.ClientID%>").html(all.toFixed(2));
                }
                 });
            }
            else {
                var qx = document.getElementById("qx");
                qx.checked = false;
                $.ajax({
                    type: "POST", //用POST方式传输
                    dataType: "text", //数据格式:JSON
                    url: 'TotalMoney.ashx', //目标地址
                    data: { id: id,type:"dan" },
                    error: function (msg) { alert(111); },
                    success: function (msg) {
                         
                       var total = $("#<%=totalmoney.ClientID%>").text();
                        var all = (total - 0) - (msg - 0);
                        $("#<%=totalmoney.ClientID%>").html(all.toFixed(2));
                }
                 });
            }
           
        }
        function del() {
     
            $("[name=che]:checked").each(function () {
               
               
                $.ajax({
                    async: false,
                    type: "POST", //用POST方式传输
                    dataType: "text", //数据格式:JSON
                    url: 'Car.ashx', //目标地址
                    data: { id: this.id, type: "del" },
                    error: function (msg) { },
                    success: function (msg) {
                      
                    
                    }
                 });
            });
            refresh();
        }


        function jiesuan() {
            var ddbh = '<%=ddbh%>';
            var openid = '<%=openid%>';
            var tz = "";
              $("[name=che]:checked").each(function () {
                
                  $.ajax({
                      type: "POST", //用POST方式传输
                      async: false,
                      dataType: "text", //数据格式:JSON
                      url: 'Car.ashx', //目标地址
                      data: { id: this.id, type: "jiesuan",ddbh:ddbh },
                      error: function (msg) { alert("error"); },
                      success: function (msg) {
                        
                        //  $("#<%=totalmoney.ClientID%>").html(0);
                          tz = msg;
                         
                    }
                   });

              });
            
            window.location = (tz);
          }
          function quanxuan() {
              if ($("#qx").attr("checked") == "checked") {
                  $("input[name='che']").attr("checked", 'true');
                  var openid = '<%=openid%>';
                  $.ajax({
                      async: false,
                      type: "POST", //用POST方式传输
                      dataType: "text", //数据格式:JSON
                      url: 'TotalMoney.ashx', //目标地址
                      data: { openid: openid, type: "all" },
                      error: function (msg) {   },
                      success: function (msg) {
                          if (msg.length > 0)
                              $("#<%=totalmoney.ClientID%>").html(msg);
                          else
                              $("#<%=totalmoney.ClientID%>").html(0);
                      }
                   });

              }
              else {
                  $("input[name='che']").removeAttr("checked");
                
                  $("#<%=totalmoney.ClientID%>").html(0);
              }
          }


          function bj() {

              if ($(".pcount").css("display") == "block") {
                  $(".pcount").css("display", "none");
                  bianji.value = "完成";
                  $(".dcount").css("display", "block");
                  $("#js").hide();
                  $("#del").show();
                  $("#heji").hide();



              }
              else {  //完成点击事件

                  $(".dcount").css("display", "none");
                  $(".pcount").css("display", "block");
                  bianji.value = "编辑";
                  $("#del").hide();
                  $("#heji").show();
                  $("#js").show();

                  var openid = '<%=openid%>';
                  
                 $("[name=buycount]").each(function () {
                     var a = this.id.replace("buy_num", "");
                     //alert(this.value + "  " + a);
                     
                     $.ajax({
                         type: "POST", //用POST方式传输
                         async: false,
                         dataType: "text", //数据格式:JSON
                         url: 'Car.ashx', //目标地址
                         data: { id: a, openid: openid, count: this.value, type: "changecount" },
                         error: function (msg) {
                           
                         },
                         success: function (msg) {
                             $("input[name='che']").removeAttr("checked");
                             $("#qx").removeAttr("checked");
                             $("#<%=totalmoney.ClientID%>").html(0);
                         }
                     });
                 });
                 refresh();
             }

         }

    </script>
</head>
<body>
   
    <div class="container">
        <div class="cart_list">
            <div class="wrap padd_10">
                <div class="editor clear">
                    <input type="button" class="bianji" onclick="bj()" value="编辑" id="bianji"/> 
                </div>
            </div>
        </div>


        <asp:Label ID="CarInfo" runat="server" Text=""></asp:Label>
        <script>
            function count(type, i_id) {
                var shul = i_id.value - 0;
                if (type == 'jia') {
                    shul += 1;
                }
                else {
                    if (i_id.value <= 1) {
                        shul = 1;

                    }
                    else

                        shul -= 1;
                }
                i_id.value = shul;

            }
        </script>


        <div class="hei_15"></div>

    </div>
    <div class="m_15">
        <div class="copyright">红豆万花城</div>
    </div>
    <div class="bott cart_bott">
        <div class="wrap padd_10 clear">
            <div class="choose fl">
                <input class="checkall" id="qx" type="checkbox" onclick="quanxuan()" value="" /><span>全选</span>
            </div>
            <div id="heji" class="price fl all"><span>合计：</span><strong>¥ <asp:Label ID="totalmoney" runat="server" Text="0"></asp:Label></strong></div>
            <div id="js" class="cart_bt fr">
                <input id="btnjs" type="button" onclick="jiesuan()" value="结算" />
            </div>
            <div id="del" style="display: none" class="cart_bt fr">
                <input id="btndel" type="button" onclick="del()" value="删除" />
            </div>
        </div>
    </div>
   
</body>
</html>
