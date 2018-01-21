<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Talk_head.ascx.cs" Inherits="Wx_NewWeb.Talk.Talk_head" %>
     

      <div class="t_head">
            <div class="wrap">
                <div class="back"><i class="icons" onclick="GoBack()"></i></div>
                <h3 class="title"><%=Title %></h3>
                <div class="home_tb"><i class="icons" onclick="Home()"></i></div>
            </div>
        </div>


<script>
    function GoBack() {
        history.go(-1);
    }

    function Home() {
        location.href = "Talk_Main.aspx";
    }
</script>