<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserFooter.ascx.cs" Inherits="Wx_NewWeb.Shop.ascx.UserFooter" %>
<!--用户-->
		<nav id="foot">
			<ul class="clearfix">
				<li>
					<a href="../Buyer/mySpace.aspx">
						<div class="index_bot">
							<img class="picOff" src="../img/mySpace.png" alt="" />
							<img class="picOn" src="../img/mySpace_on.png"/>
						</div>
						<p>私享空间</p>
					</a>
				</li>
				<li>
					<a href="../Buyer/cart.aspx">
						<div class="index_bot">
							<img class="picOff" src="../img/cart.png" alt="" />
							<img class="picOn" src="../img/cart_on.png"/>
						</div>
						<p>购物车</p>
					</a>
				</li>
				<li>
					<a href="../Buyer/myself.aspx">
					<!--<i class="iconfont icon-iconfont02"></i>-->
						<div class="index_bot">
							<img class="picOff" src="../img/myself.png" alt="" />
							<img class="picOn" src="../img/myself_on.png" alt=""/>
						</div>
						<p>我的</p>
					</a>
				</li>
				<li>
					<a href="../Buyer/x-store.aspx">
						<!--<i class="iconfont icon-wodehui"></i>-->
						<div class="index_bot">
							<img class="picOff" src="../img/xs.png" alt="" />
							<img class="picOn" src="../img/xs_on.png"/>
						</div>
						<p>操作指南</p>
					</a>
				</li>
			</ul>
		</nav>
<script src="../js/jquery-1.7.2.min.js"></script>
<script type="text/javascript">
    $(function () {

        $("a[name='con']").each(function () {

            $(this).removeClass("");

            switch (page) {

                case "mySpace":

                    $("a[name='con']").eq(0).addClass("on");
                    break;
                case "cart":

                    $("a[name='con']").eq(1).addClass("on");
                    break;
                case "myself":

                    $("a[name='con']").eq(2).addClass("on");
                    break;
                case "x-store":

                    $("a[name='con']").eq(3).addClass("on");
                    break;
            }



        })
     
    })
</script>
