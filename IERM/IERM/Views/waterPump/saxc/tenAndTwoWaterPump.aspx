<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="tenAndTwoWaterPump.aspx.cs" Inherits="IERM.Views.waterPump.saxc.tenAndTwoWaterPump" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="/css/beng/ten.css" rel="stylesheet" />
    <script src="/js/Distribution/InitDistribution.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:Monitoring runat="server" ID="Monitoring" />
    <div class="introImg vertical">
        <form runat="server" id="ContentForm2">
            <input id="hidden_Attribute" type="hidden" value="0" runat="server" />
        </form>
        <!--警报-->
        <div class="warn">
            <p class="warnp"><span class="warnImg"></span>X<span class="warnNum">3</span></p>
        </div>
        <div class="ImgWarp">
            <img src="/img/beng/10beng/bac.png" class="bengImg">
            <!--高区供水-->
            <span class="highTem temperature">000.0</span>
            <span class="highTagOne tag tz"></span>
            <span class="highTagTwo tag tz"></span>
            <span class="highTagThree tag tz"></span>
            <!--中区供水-->
            <span class="midTem temperature">000.0</span>
            <span class="midTagOne tag tz"></span>
            <span class="midTagTwo tag tz"></span>
            <span class="midTagThree tag tz"></span>
            <!--低区供水-->
            <span class="downTem temperature">000.0</span>
            <span class="downTagOne tag tz"></span>
            <span class="downTagTwo tag tz"></span>
            <span class="downTagThree tag tz"></span>
            <span class="downTagFour tag tz"></span>
            <!--水箱温度-->
            <span class="tank">000.0</span>
            <!--泵状态-->
            <span class="pumpOne tag tz"></span>
            <span class="pumpTwo tag tz"></span>
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
                <a class="detailA">市政供水压力：<span class="szgsyl footertag">--</span>MPa</a>
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
            $.getJSON("/Handler/WCFHandler.ashx?action=getdatabydevhouseid&r=" + Math.random(), { "devhouseID": 18 }, function (res) {
                if (res.IsSucceed) {
                    var highStatus = res.Data.DI_HP_AL;//高区故障
                    var midStatus = res.Data.DI_MP_AL;//中区故障
                    var downStatus = res.Data.DI_LP_AL;//低区故障

                    //生活供水-高区供水压力
                    $(".highTem").text(res.Data.P_HI);
                    if (highStatus == true) {
                        $(".highTagOne").attr("class", "highTagOne tag gz");
                        $(".highTagTwo").attr("class", "highTagTwo tag gz");
                        $(".highTagThree").attr("class", "highTagThree tag gz");
                    } else {
                        res.Data.DI_HP1 ? $(".highTagOne").attr("class", "highTagOne tag yx") : $(".highTagOne").attr("class", "highTagOne tag tz");  //生活供水-高区1#泵运行
                        res.Data.DI_HP2 ? $(".highTagTwo").attr("class", "highTagTwo tag yx") : $(".highTagTwo").attr("class", "highTagTwo tag tz");  //生活供水-高区2#泵运行
                        res.Data.DI_HP3 ? $(".highTagThree").attr("class", "highTagThree tag yx") : $(".highTagThree").attr("class", "highTagThree tag tz");  //生活供水-高区3#泵运行
                    }

                    //生活供水-中区供水压力
                    $(".midTem").text(res.Data.P_MI);
                    if (midStatus == true) {
                        $(".midTagOne").attr("class", "midTagOne tag gz");
                        $(".midTagTwo").attr("class", "midTagTwo tag gz");
                        $(".midTagThree").attr("class", "midTagThree tag gz");
                    } else {
                        res.Data.DI_MP1 ? $(".midTagOne").attr("class", "midTagOne tag yx") : $(".midTagOne").attr("class", "midTagOne tag tz");  //生活供水-中区1#泵运行
                        res.Data.DI_MP2 ? $(".midTagTwo").attr("class", "midTagTwo tag yx") : $(".midTagTwo").attr("class", "midTagTwo tag tz");  //生活供水-中区2#泵运行
                        res.Data.DI_MP3 ? $(".midTagThree").attr("class", "midTagThree tag yx") : $(".midTagThree").attr("class", "midTagThree tag tz");  //生活供水-中区3#泵运行
                    }

                    //生活供水-低区供水压力
                    $(".downTem").text(res.Data.P_LO);
                    if (downStatus == true) {
                        $(".downTagOne").attr("class", "downTagOne tag gz");
                        $(".downTagTwo").attr("class", "downTagTwo tag gz");
                        $(".downTagThree").attr("class", "downTagThree tag gz");
                        $(".downTagFour").attr("class", "downTagFour tag gz");
                    } else {
                        res.Data.DI_LP1 ? $(".downTagOne").attr("class", "downTagOne tag yx") : $(".downTagOne").attr("class", "downTagOne tag tz");  //生活供水-中区1#泵运行
                        res.Data.DI_LP2 ? $(".downTagTwo").attr("class", "downTagTwo tag yx") : $(".downTagTwo").attr("class", "downTagTwo tag tz");  //生活供水-中区2#泵运行
                        res.Data.DI_LP3 ? $(".downTagThree").attr("class", "downTagThree tag yx") : $(".downTagThree").attr("class", "downTagThree tag tz");  //生活供水-中区3#泵运行
                        res.Data.DI_LP4 ? $(".downTagFour").attr("class", "downTagFour tag yx") : $(".downTagFour").attr("class", "downTagFour tag tz");  //生活供水-中区4#泵运行
                    }
                    //泵状态
                    res.Data.DI_HP_JNB ? $(".pumpOne").attr("class", "pumpOne tag yx") : $(".pumpOne").attr("class", "pumpOne tag tz");  //高区泵运行
                    res.Data.DI_LP_JNB ? $(".pumpTwo").attr("class", "pumpTwo tag yx") : $(".pumpTwo").attr("class", "pumpTwo tag tz");  //低区泵运行
                    //生活水箱液位
                    $(".tank").text(res.Data.L_SHSX);
                    //环境温度
                    $(".hjwd").text(res.Data.T_ROOM);
                    //环境湿度
                    $(".hjsd").text(res.Data.H_ROOM);
                    //生活水箱液位
                    $(".shsxyw").text(res.Data.L_SHSX);
                    //AB线电压
                    $(".ab").text(res.Data.UAB_SH);
                    //BC线电压
                    $(".bc").text(res.Data.UBC_SH);
                    //CA线电压
                    $(".ca").text(res.Data.UCA_SH);
                    //A线电流
                    $(".axdl").text(res.Data.IA_SH);
                    //B线电流
                    $(".bxdl").text(res.Data.IB_SH);
                    //C线电流
                    $(".cxdl").text(res.Data.IC_SH);
                    //有功电能
                    $(".ygdn").text(res.Data.KWH_SH);
                    //功率因素
                    $(".glys").text(res.Data.PF_SH);
                }
            });
        }
    </script>
</asp:Content>
