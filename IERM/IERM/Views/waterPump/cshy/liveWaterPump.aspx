<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="liveWaterPump.aspx.cs" Inherits="IERM.Views.waterPump.cshy.liveWaterPump" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="/css/beng/xf.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:Monitoring runat="server" ID="Monitoring" />
    <div class="introImg vertical">
        <form runat="server" id="ContentForm2">
            <input id="hidden_Attribute" type="hidden" value="0" runat="server" />
        </form>
        <div class="ImgWarp">
            <img src="/img/beng/xf/xfbac.png" class="bengImg">
            <!--消防管网供水-->
            <span class="xfgwTem temperature">--</span>
            <span class="xfgwTagOne tag tz"></span>
            <span class="xfgwTagTwo tag tz"></span>
            <!--喷淋管网供水-->
            <span class="plgwTem temperature">--</span>
            <span class="plgwTagOne tag tz"></span>
            <span class="plgwTagTwo tag tz"></span>
            <!--水箱温度-->
            <span class="tank">--</span>
        </div>
    </div>
    <div class="introDetail">
        <ul class="ulOne">
            <li class="detaiLi firstLi">
                <a class="detailA">环境温度：<span class="hjwd footertag">--</span>℃</a>
            </li>
            <li class="detaiLi">
                <a class="detailA">环境湿度：<span class="hjsd footertag">--</span>RH%</a>
            </li>
            <li class="detaiLi">
                <a class="detailA">生活水箱液位：<span class="shsxyw footertag">--</span>m</a>
            </li>
            <span class="xfline"></span>
        </ul>
        <ul class="ulTwo">
            <li class="detaiLi fistLi">
                <a class="detailA">电合闸状态：<span class="dhz footertag">--</span></a>
            </li>
            <li class="detaiLi">
                <a class="detailA">有功电能：<span class="ygdn footertag">--</span>kW•h</a>
            </li>
            <li class="detaiLi">
                <a class="detailA">功率因数：<span class="glys footertag">--</span></a>
            </li>
        </ul>
        <ul class="ulThree">
            <li class="detaiLi fistLi">
                <a class="detailA">AB线电压：<span class="ab footertag">--</span>V</a>
            </li>
            <li class="detaiLi">
                <a class="detailA">BC线电压：<span class="bc footertag">--</span>V</a>
            </li>
            <li class="detaiLi">
                <a class="detailA">CA线电压：<span class="ca footertag">--</span>V</a>
            </li>
        </ul>
        <ul class="ulFour">
            <li class="detaiLi fistLi">
                <a class="detailA">A线电流：<span class="axdl footertag">--</span>A</a>
            </li>
            <li class="detaiLi">
                <a class="detailA">B线电流：<span class="bxdl footertag">--</span>A</a>
            </li>
            <li class="detaiLi">
                <a class="detailA">C线电流：<span class="cxdl footertag">--</span>A</a>
            </li>
            <span class="xfline"></span>
        </ul>
        <ul class="ulFive">
            <li class="detaiLi fistLi">
                <a class="detailA">消防供水压力：<span class="szgsyl footertag">--</span>MPa</a>
            </li>
            <li class="detaiLi">
                <a class="detailA">喷淋供水压力：<span class="dqgsyl footertag">--</span>MPa</a>
            </li>
        </ul>
        <div style="clear: both;">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript">
        $(function () {
            LoadData();
            setInterval(function () { LoadData(); }, 10000);
        });

        function LoadData() {
            $.getJSON("/Handler/WCFHandler.ashx?action=getdatabydevhouseid&r=" + Math.random(), { "devhouseID": 15 }, function (res) {
                if (res.IsSucceed) {
                    //消防供水-消防1#供水压力
                    $(".xfgwTem").text(res.Data.P_XF1);
                    //消防供水-喷淋1#供水压力
                    $(".plgwTem").text(res.Data.P_PL1);
                    //消防管网运行状态
                    $(".xfgwTagOne").attr("class", "tz tag xfgwTagOne");
                    $(".xfgwTagTwo").attr("class", "tz tag xfgwTagTwo");
                    //喷淋管网运行状态
                    $(".plgwTagOne").attr("class", "tz tag plgwTagOne");
                    $(".plgwTagTwo").attr("class", "tz tag plgwTagTwo");
                    //生活水箱液位
                    $(".tank").text(res.Data.L_XFSX);
                    //环境温度
                    $(".hjwd").text(res.Data.T_ROOM);
                    //环境湿度
                    $(".hjsd").text(res.Data.H_ROOM);
                    //生活水箱液位
                    $(".shsxyw").text(res.Data.P_PL1);
                    //AB线电压
                    $(".ab").text(res.Data.UAB_XF);
                    //BC线电压
                    $(".bc").text(res.Data.UBC_XF);
                    //CA线电压
                    $(".ca").text(res.Data.UCA_XF);
                    //A线电流
                    $(".axdl").text(res.Data.IA_XF);
                    //B线电流
                    $(".bxdl").text(res.Data.IB_XF);
                    //C线电流
                    $(".cxdl").text(res.Data.IC_XF);
                    //消防供水压力
                    $(".szgsyl").text(res.Data.P_XF1);
                    //喷淋供水压力
                    $(".dqgsyl").text(res.Data.P_PL1);
                    //有功电能
                    $(".ygdn").text(res.Data.KWH_XF);
                    //功率因素
                    $(".glys").text(res.Data.PF_XF);
                }
            });
        }
    </script>
</asp:Content>
