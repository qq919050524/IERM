<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="IERM.Views.Map.Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="/css/map/style.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class="main">
        <div class="map">
            <img src="/img/map/map.png" usemap="#Map" border="0" class="bac" />
            <div class="city">
                <img class="citybg" src="/img/map/anhui.png" style="top: 52.773%; left: 73.044%; width: 10.474%; height: 15.126%;">
                <a style="position: absolute; top: 59.663%; left: 76.117%; z-index: 10;" href="javascript:void(0);" title="安徽" class="titleHover">安徽
                    <span class="xm ah"><i class="ahNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/neimeng.png" style="top: 1.512%; left: 41.34%; width: 44.413%; height: 51.714%;">
                <a style="position: absolute; top: 35.462%; left: 59.217%; z-index: 10;" href="javascript:void(0);" title="内蒙" class="titleHover">内蒙
                    <span class="xm nm"><i class="xnNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/heilongjiang.png" style="top: 0.168%; left: 76.815%; width: 23.044%; height: 25.378%;">
                <a style="position: absolute; top: 13.613%; left: 87.150%; z-index: 10;" href="javascript:void(0);" title="黑龙江" class="titleHover">黑龙江
                    <span class="xm hlj"><i class="hljNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/xinjiang.png" style="top: 12.268%; left: 0px; width: 40.782%; height: 37.478%;">
                <a style="position: absolute; top: 35.462%; left: 17.318%; z-index: 10;" href="javascript:void(0);" title="新疆" class="titleHover">新疆
                    <span class="xm xj"><i class="xjNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/xizang.png" style="top: 46.218%; left: 4.329%; width: 39.245%; height: 29.411%;">
                <a style="position: absolute; top: 60.672%; left: 20.251%; z-index: 10;" href="javascript:void(0);" title="西藏">西藏
                    <span class="xm xz"><i class="xzNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/qinghai.png" style="top: 40.336%; left: 25.418%; width: 25.837%; height: 22.689%;">
                <a style="position: absolute; top: 50.42%; left: 35.474%; z-index: 10;" href="javascript:void(0);" title="青海">青海
                    <span class="xm qh"><i class="qhNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/gansu.png" style="top: 31.428%; left: 32.96%; width: 28.91%; height: 29.747%;">
                <a style="position: absolute; top: 52.10%; left: 50.837%; z-index: 10;" href="javascript:void(0);" title="甘肃">甘肃
                    <span class="xm gs"><i class="gsNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/ningxia.png" style="top: 41.176%; left: 52.932%; width: 6.843%; height: 12.605%;">
                <a style="position: absolute; top: 45.714%; left: 54.469%; z-index: 10;" href="javascript:void(0);" title="宁夏">宁夏
                    <span class="xm nx"><i class="nxNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/shanghai.png" style="top: 59.495%; left: 85.195%; width: 3.212%; height: 3.697%;">
                <a style="position: absolute; top: 59.159%; left: 85.893%; z-index: 10;" href="javascript:void(0);" title="上海">上海
                    <span class="xm sh"><i class="shNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/liaoning.png" style="top: 27.058%; left: 77.793%; width: 12.709%; height: 14.621%;">
                <a style="position: absolute; top: 30.252%; left: 83.798%; z-index: 10;" href="javascript:void(0);" title="辽宁">辽宁
                    <span class="xm ln"><i class="lnNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/guangdong.png" style="top: 78.991%; left: 64.804%; width: 15.502%; height: 14.789%;">
                <a style="position: absolute; top: 82.352%; left: 69.832%; z-index: 10;" href="javascript:void(0);" title="广东">广东
                    <span class="xm gd"><i class="gdNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/guangxi.png" style="top: 76.302%; left: 53.351%; width: 16.48%; height: 15.462%;">
                <a style="position: absolute; top: 82.016%; left: 60.335%; z-index: 10;" href="javascript:void(0);" title="广西">广西
                    <span class="xm gx"><i class="gxNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/henan.png" style="top: 48%; left: 64.385%; width: 12.5%; height: 15.462%;">
                <a style="position: absolute; top: 53.781%; left: 68.435%; z-index: 10;" href="javascript:void(0);" title="河南">河南
                    <span class="xm hn"><i class="hnNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/shanxi.png" style="top: 40.672%; left: 55.307%; width: 11.033%; height: 22.689%;">
                <a style="position: absolute; top: 53.949%; left: 60.055%; z-index: 10;" href="javascript:void(0);" title="陕西">陕西
                    <span class="xm sx"><i class="sxNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/shanxi2.png" style="top: 36.806%; left: 63.966%; width: 7.821%; height: 18.823%;">
                <a style="position: absolute; top: 45.546%; left: 65.642%; z-index: 10;" href="javascript:void(0);" title="山西">山西
                    <span class="xm sxxNum"><i class="sxxNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/hebei.png" style="top: 30.924%; left: 69.413%; width: 11.871%; height: 19.831%;">
                <a style="position: absolute; top: 41.512%; left: 70.949%; z-index: 10;" href="javascript:void(0);" title="河北">河北
                    <span class="xm heb"><i class="hebNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/jilin.png" style="top: 18.991%; left: 80.307%; width: 17.458%; height: 14.789%;">
                <a style="position: absolute; top: 25.21%; left: 89.664%; z-index: 10;" href="javascript:void(0);" title="吉林">吉林
                    <span class="xm jl"><i class="jlNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/beijing.png" style="top: 35.294%; left: 71.508%; width: 6.983%; height: 6.386%;">
                <a style="position: absolute; top: 36.134%; left: 71.927%; z-index: 10;" href="javascript:void(0);" title="北京">北京
                    <span class="xm bj"><i class="bjNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/tianjin.png" style="top: 37.647%; left: 74.72%; width: 3.631%; height: 5.714%;">
                <a style="position: absolute; top: 38.487%; left: 74.72%; z-index: 10;" href="javascript:void(0);" title="天津">天津
                    <span class="xm tj"><i class="tjNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/shandong.png" style="top: 43.025%; left: 72.765%; width: 14.385%; height: 11.428%;">
                <a style="position: absolute; top: 47.226%; left: 75.418%; z-index: 10;" href="javascript:void(0);" title="山东">山东
                    <span class="xm sd"><i class="sdNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/jiangsu.png" style="top: 51.26%; left: 75.279%; width: 12.988%; height: 12.1%;">
                <a style="position: absolute; top: 53.949%; left: 79.608%; z-index: 10;" href="javascript:void(0);"title="江苏">江苏
                    <span class="xm js"><i class="jsNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/hainan.png" style="top: 93.445%; left: 62.15%; width: 6%; height: 6.7%;">
                <a style="position: absolute; top: 94.957%; left: 62.849%; z-index: 10;" href="javascript:void(0);"title="海南">海南
                    <span class="xm hann"><i class="hannNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/hubei.png" style="top: 57.983%; left: 61.173%; width: 16.061%; height: 12.605%; display: block;">
                <a style="position: absolute; top: 61.344%; left: 67.039%; z-index: 10;" href="javascript:void(0);" title="湖北">湖北
                    <span class="xm hub"><i class="hubNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/yunnan.png" style="top: 69.243%; left: 39.106%; width: 18.435%; height: 23.193%;">
                <a style="position: absolute; top: 81.512%; left: 44.692%; z-index: 10;" href="javascript:void(0);" title="云南">云南
                    <span class="xm yn"><i class="ynNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/sichuan.png" style="top: 55.126%; left: 39.664%; width: 22.486%; height: 24.033%;">
                <a style="position: absolute; top: 64.705%; left: 48.184%; z-index: 10;" href="javascript:void(0);" title="四川">四川
                    <span class="xm sc"><i class="scNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/guizhou.png" style="top: 68.739%; left: 51.256%; width: 12.988%; height: 13.613%;">
                <a style="position: absolute; top: 74.789%; left: 56.564%; z-index: 10;" href="javascript:void(0);" title="贵州">贵州
                    <span class="xm gz"><i class="gzNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/taiwan.png" style="top: 76.638%; left: 85.614%; width: 4.469%; height: 10.924%;">
                <a style="position: absolute; top: 79.831%; left: 86.592%; z-index: 10;" href="javascript:void(0);" title="台湾">台湾
                    <span class="xm tw"><i class="twNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/fujian.png" style="top: 69.747%; left: 75.536%; width: 11%; height: 14.117%;">
                <a style="position: absolute; top: 74.789%; left: 78.91%; z-index: 10;" href="javascript:void(0);" title="福建">福建
                    <span class="xm fj"><i class="fjNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/hunan.png" style="top: 66.218%; left: 62.15%; width: 11.592%; height: 16.134%;">
                <a style="position: absolute; top: 71.428%; left: 66.34%; z-index: 10;" href="javascript:void(0);" title="湖南">湖南
                    <span class="xm hun"><i class="hunNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/zhejiang.png" style="top: 61.68%; left: 80.167%; width: 8.659%; height: 11.764%;">
                <a style="position: absolute; top: 66.386%; left: 82.122%; z-index: 10;" href="javascript:void(0);" title="浙江">浙江
                    <span class="xm zj"><i class="zjNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/jiangxi.png" style="top: 65.546%; left: 71.648%; width: 10.614%; height: 16.47%;">
                <a style="position: absolute; top: 71.428%; left: 73.324%; z-index: 10;" href="javascript:void(0);" title="江西">江西
                    <span class="xm jx"><i class="jxNum"></i>个项目</span></a>
            </div>
            <div class="city">
                <img class="citybg" src="/img/map/chongqing.png" style="top: 61.008%; left: 55.446%; width: 9.776%; height: 13.445%;">
                <a style="position: absolute; top: 65.546%; left: 58.659%; z-index: 10;" href="javascript:void(0);" title="重庆">重庆
                    <span class="xm cq"><i class="cqNum"></i>个项目</span></a>
            </div>
        </div>
    </div>
    <div class="cityNav">
        <ul class="cityNavUl">
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../../js/Map/jqnav.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".detailSearch").css("display", "none");
            $(".wordWarp").css("display", "none");
            $(".introImg").removeClass("vertical");
            $(".introImg").css({ "display": "inline-block", "height": "100%" });

        });
        //取得当前省份下面的项目信息
        function GetProvinceCommunity(province, num) {

            $.getJSON("../../Handler/MapHandler.ashx?action=GetProvinceCommunity&province=" + escape(province) + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    num.innerText = res.Data.length;
                    var cityHtml = "";
                    //遍历集合
                    $.each(res.Data, function (index, item) {
                        if (index == 0) {
                            cityHtml += '<li class="cityNavLi">';
                            cityHtml += '<a href="#"><span>' + item.cityname + '</span></a>';
                            cityHtml += '<ul class="citySubNavUl test">';
                            cityHtml += '<li class="citySubNavLi whLi">';
                            cityHtml += '<a href="#">' + item.communityName + '</a>';
                            cityHtml += '</li>';
                        }
                        else {
                            if (item.cityname == res.Data[index - 1].cityname) {
                                cityHtml += '<li class="citySubNavLi whLi">';
                                cityHtml += '<a href="#">' + item.communityName + '</a>';
                                cityHtml += '</li>';
                            } else {
                                cityHtml += '</ul>';
                                cityHtml += '</li>';
                                cityHtml += '<li class="cityNavLi">';
                                cityHtml += '<a href="#"><span>' + item.cityname + '</span></a>';
                                cityHtml += '<ul class="citySubNavUl test">';
                                cityHtml += '<li class="citySubNavLi whLi">';
                                cityHtml += '<a href="#">' + item.communityName + '</a>';
                                cityHtml += '</li>';
                            }
                        }
                    });

                    cityHtml += '</ul>';
                    cityHtml += '</li>';
                    //先清空内容
                    $(".cityNavUl").empty();
                    $(".cityNavUl").append(cityHtml);

                    //添加绑定事件
                    $(".cityNavLi").click(function () {
                        //debugger;
                        var index = $(this).index();
                        var citySubNavUl = $(this).find(".citySubNavUl").height();
                        $(".citySubNavUl").eq(index).slideToggle("slow");
                        $(".citySubNavUl").eq(index).parent().siblings().children(".citySubNavUl").slideUp("slow");
                        if (index == 0) {
                            $(".cityNav").css("marginTop", "10px");
                            $(".whLi").css("padding", "7px");
                        }
                    });
                }
            });
        }
    </script>
</asp:Content>
