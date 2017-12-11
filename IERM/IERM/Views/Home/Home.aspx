<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IERM.Views.Home.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <img src="/img/home.png" class="indexImg" style="width: 100%; height: 100%;">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript">
        (function () {
            $(".introImg").css("display", "inline-block");
            $(".detailSearch").css("display", "none");
            $(".introImg").css("height", "100%");
            $(".wordWarp").css("height", "0");
        })();
    </script>
</asp:Content>
