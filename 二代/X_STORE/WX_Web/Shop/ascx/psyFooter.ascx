<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="psyFooter.ascx.cs" Inherits="Wx_NewWeb.Shop.ascx.psyFooter" %>
<!--配送员-->

       		<nav id="foot">
			<ul class="clearfix">
				<li style="display:none;">
					<a href="../Distributer/roomSatus.aspx" class="current">
						<div class="index_bot">
							<img class="picOff" src="../img/disRoom.png" alt="" />
							<img class="picOn" src="../img/disRoom_on.png" alt=""/>
						</div>
						<p>开箱验货</p>
					</a>
				</li>
				<li style="width:50%;">
					<%--<a href="../Distributer/PickUp.aspx" class="current">--%>
                    <a href="../Distributer/roomSelect.aspx" class="current">
                    
						<div class="index_bot">
							<img class="picOff" src="../img/pickUp.png" alt="" />
							<img class="picOn" src="../img/pickUp_on.png" alt=""/>
						</div>
						<p>常规补货</p>
					</a>
				</li>
				<li style="width:50%;">
					<a href="../Distributer/disMyself.aspx">
						<div class="index_bot">
							<img class="picOff" src="../img/myself.png" alt="" />
							<img class="picOn" src="../img/myself_on.png"/>
						</div>
						<p>我的</p>
					</a>
				</li>
				<%--<li>
					<a href="../Distributer/news.aspx">
						<!--<i class="iconfont icon-wodehui"></i>-->
						<div class="index_bot">
							<img class="picOff" src="../img/news.png" alt="" />
							<img class="picOn" src="../img/news_on.png"/>
						</div>
						<p>消息</p>
					</a>
				</li>--%>
			</ul>
		</nav>
<script src="../js/jquery-1.7.2.min.js"></script>
<script type="text/javascript">
    $(function () {

        $("a[name='con']").each(function () {

            $(this).removeClass("");
<%--          //  var page = "<%=page %>";--%>

            switch (page) {

                case "roomStatus":

                    $("a[name='con']").eq(0).addClass("on");
                    break;
                case "PickUp":

                    $("a[name='con']").eq(1).addClass("on");
                    break;
                case "disMyself":

                    $("a[name='con']").eq(2).addClass("on");
                    break;
                //case "car":

                //    $("a[name='con']").eq(2).addClass("on");
                //    break;
                //case "news":

                //    $("a[name='con']").eq(3).addClass("on");
                //    break;
            }



        })
     
    })
</script>
