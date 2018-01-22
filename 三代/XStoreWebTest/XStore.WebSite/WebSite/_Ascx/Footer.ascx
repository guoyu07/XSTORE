<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="XStore.WebSite.WebSite._Ascx.Footer" %>
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
						<div class="index_bot">
							<img class="picOff" src="../img/myself.png" alt="" />
							<img class="picOn" src="../img/myself_on.png" alt=""/>
						</div>
						<p>我的</p>
					</a>
				</li>
				<li>
					<a href="../Buyer/x-store.aspx">
						<div class="index_bot">
							<img class="picOff" src="../img/xs.png" alt="" />
							<img class="picOn" src="../img/xs_on.png"/>
						</div>
						<p>操作指南</p>
					</a>
				</li>
			</ul>
		</nav>
<script src="/Scripts/jquery-1.10.2.min.js"></script>
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