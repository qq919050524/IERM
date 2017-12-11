<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="cshyT202.aspx.cs" Inherits="IERM.Views.Distribution.cshy.cshyT202" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="/css/Distribution/bpd.css" rel="stylesheet" />
    <script src="/js/Distribution/InitDistribution.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:Monitoring runat="server" ID="Monitoring" />
    <div class="introImg vertical">
        <form runat="server" id="ContentForm2">
            <input id="hidden_Attribute" type="hidden" value="0" runat="server" />
        </form>
        <div class="twe" style="width: 8%;">
        </div>
        <div class="thre">
            <a class="twegui gui">13号柜</a>
            <span class="threBefore"></span>
            <span class="sideHe threFen"></span>
            <span class="threAfter"></span>
            <span class="trangleImg"></span>
            <a class="fourWord">无功补偿</a>
        </div>
        <div class="four">
        </div>
        <div class="center">
            <a class="centerDesk gui">14号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">4#地下室风机</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">4#楼会所5楼游泳池</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">4#楼会所动力二</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">1#楼人动力</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">办公动力计量</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>
        <div class="center">
            <a class="centerDesk gui">15号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt">3#楼水泵房</a>
                    <a class="bg">动力主供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">4#楼水泵房</a>
                    <a class="bg">动力一</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">消防泵7</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">中心花园广场</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>
        <div class="center">
            <a class="centerDesk gui">16号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt">3#楼消防动力</a>
                    <a class="bg">主供一</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">3#楼电梯</a>
                    <a class="bg">主供一</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">3#楼消防动力</a>
                    <a class="bg">主供二</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">3#楼电梯</a>
                    <a class="bg">主供二</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">3#楼消防动力</a>
                    <a class="bg">主供三</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">备供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>
        <div class="center">
            <a class="centerDesk gui">17号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">无标识</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">4#楼消防动力</a>
                    <a class="bg">主供一</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">4#楼消防动力</a>
                    <a class="bg">主供二</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">4#楼电梯</a>
                    <a class="bg">主供二</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">4#楼电梯</a>
                    <a class="bg">主供三</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>
        <div class="center">
            <a class="centerDesk gui">18号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">4#楼无机房电梯</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">1#楼电梯</a>
                    <a class="bg">主供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">2#楼电梯</a>
                    <a class="bg">主供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">1#楼消防动力</a>
                    <a class="bg">主供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">2#楼消防动力</a>
                    <a class="bg">主供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>

        <div class="input-group" style="width: 180px; margin-right: 10px;">
            <span class="input-group-addon">变压器：</span>
            <select class="form-control" id="byqsl">
                <%=urls.ToString() %>
            </select>
        </div>
    </div>
    <ul class="introFour">
        <li class="introOneLi">
            <a class="introOneA">环境温度: <span class="temWord">--</span>℃</a>
        </li>
    </ul>
    <ul class="introFive">
        <li class="introOneLi">
            <a class="introOneA">环境湿度: <span class="temWord">--</span>RH%</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript">
        (function () {
            $(".introImg").removeClass("vertical");
            $(".twe").css("borderRight", "none");
            $(".thre").css("width", "0.15%");
            $(".introImg").css({ "paddingTop": "0.45rem", "height": "86%" });
            $(".wordWarp").css("height", "7.2%");
            LoadData();
            setInterval(function () { LoadData(); }, 10000);
        })();

        function LoadData() {
            $.getJSON("/Handler/WCFHandler.ashx?action=getdatabydevhouseid&r=" + Math.random(), { "devhouseID": 16 }, function (res) {
                if (res.IsSucceed) {
                    //功率因数
                    $('.introOne span:eq(0)').text(res.Data.N2_PF);
                    //有功电能
                    $('.introOne span:eq(1)').text(res.Data.N2_KWH);
                    //无功电能
                    $('.introOne span:eq(2)').text(res.Data.N2_KVARH);
                    //AB电压线
                    $('.introTwo span:eq(0)').text(res.Data.N2_UAB);
                    //BC电压线
                    $('.introTwo span:eq(1)').text(res.Data.N2_UBC);
                    //CA电压线
                    $('.introTwo span:eq(2)').text(res.Data.N2_UCA);
                    //A线电流
                    $('.introThree span:eq(0)').text(res.Data.N2_IA);
                    //B线电流
                    $('.introThree span:eq(1)').text(res.Data.N2_IB);
                    //C线电流
                    $('.introThree span:eq(2)').text(res.Data.N2_IC);
                    //变压器温度
                    $('.byq span').text(res.Data.N2_T_A);
                    //环境温度
                    $(".introFour li:eq(0)").find(".temWord").text(res.Data.T_ROOM);
                    //环境湿度
                    $(".introFive li:eq(0)").find(".temWord").text(res.Data.H_ROOM);

                    //进线柜断路器状态
                    res.Data.N2_JXG ? $(".ele span:eq(1)").attr("class", "sideHe eleHe") : $(".ele span:eq(1)").attr("class", "sideHe eleFen");
                    //电容柜断路器状态
                    res.Data.N2_LLG ? $(".thre span:eq(1)").attr("class", "sideHe threHe") : $(".thre span:eq(1)").attr("class", "sideHe threHe");
                    //联络柜断路器状态
                    res.Data.N2_DRG ? $(".twe span:eq(1)").attr("class", "sideHe tweHe") : $(".twe span:eq(1)").attr("class", "sideHe tweHe");


                    //14号柜
                    res.Data.N2_G5.f1 ? $(".centerUl:eq(0) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f2 ? $(".centerUl:eq(0) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f3 ? $(".centerUl:eq(0) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f4 ? $(".centerUl:eq(0) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f5 ? $(".centerUl:eq(0) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");


                    //15号柜
                    res.Data.N2_G6.f1 ? $(".centerUl:eq(1) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f2 ? $(".centerUl:eq(1) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f3 ? $(".centerUl:eq(1) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f4 ? $(".centerUl:eq(1) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f5 ? $(".centerUl:eq(1) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f6 ? $(".centerUl:eq(1) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");


                    //16号柜
                    res.Data.N2_G7.f1 ? $(".centerUl:eq(2) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G7.f2 ? $(".centerUl:eq(2) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G7.f3 ? $(".centerUl:eq(2) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G7.f4 ? $(".centerUl:eq(2) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G7.f5 ? $(".centerUl:eq(2) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G7.f6 ? $(".centerUl:eq(2) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");


                    //17号柜
                    res.Data.N2_G8.f1 ? $(".centerUl:eq(3) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G8.f2 ? $(".centerUl:eq(3) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G8.f3 ? $(".centerUl:eq(3) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G8.f4 ? $(".centerUl:eq(3) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G8.f5 ? $(".centerUl:eq(3) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G8.f6 ? $(".centerUl:eq(3) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");

                    //18号柜
                    res.Data.N2_G9.f1 ? $(".centerUl:eq(4) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G9.f2 ? $(".centerUl:eq(4) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G9.f3 ? $(".centerUl:eq(4) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G9.f4 ? $(".centerUl:eq(4) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G9.f5 ? $(".centerUl:eq(4) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G9.f6 ? $(".centerUl:eq(4) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");

                }
            });
        };
    </script>
</asp:Content>
