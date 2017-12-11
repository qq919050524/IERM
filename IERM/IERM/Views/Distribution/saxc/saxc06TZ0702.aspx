<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="saxc06TZ0702.aspx.cs" Inherits="IERM.Views.saxc.saxc06T702" %>

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
        <div class="ele">
            <a class="elegui">11号柜</a>
            <span class="heBefore eleBe"></span>
            <span class="sideHe eleHe"></span>
            <span class="heAfter eleAf"></span>
            <a class="tengui">10号柜</a>
            <span class="eleLogo">
                <img src="/img/bpd/tengui.jpg" class="eleImg"></span>
        </div>
        <div class="twe">
            <ul class="introOne">
                <li class="introOneLi">
                    <a class="introOneA">功率因数: <span class="temWord">--</span></a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">有功电能: <span class="temWord">--</span>Kw·h</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">无功电能: <span class="temWord">--</span>Kvar·h</a>
                </li>
            </ul>
            <ul class="introTwo">
                <li class="introOneLi">
                    <a class="introOneA">AB电压线: <span class="temWord">--</span>V</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">BC电压线: <span class="temWord">--</span>V</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">CA电压线: <span class="temWord">--</span>V</a>
                </li>
            </ul>
            <ul class="introThree">
                <li class="introOneLi">
                    <a class="introOneA">A线电流: <span class="temWord">--</span>A</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">B线电流: <span class="temWord">--</span>A</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">C线电流: <span class="temWord">--</span>A</a>
                </li>
            </ul>
            <a class="projectNum">T7-1</a>
            <a class="byq">变压器温度： <span class="temWord">44.2</span>℃</a>

        </div>
        <div class="thre">
            <a class="twegui gui">13号柜</a>
            <span class="threBefore"></span>
            <span class="sideHe threHe"></span>
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
                    <a class="bg">G11-2消防梯</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G11-1消防梯</a>
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
                    <a class="bg">G12-1消防梯</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G12-1消防梯</a>
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
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>
        <div class="center">
            <a class="centerDesk gui">15号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G11-2客梯</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G11-1客梯</a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G12-1客梯</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G12-2客梯</a>
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
                    <a class="bg">6#地下室生活水泵</a>
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
                    <a class="xfdt"></a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">无标识</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">无标识</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">AT6-3-4</a>
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
                    <a class="bg">AT6-1-2</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">AT6-6</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">大商铺应急照明</a>
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
                    <a class="xfdt"></a>
                    <a class="bg">园林动力</a>
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
                    <a class="bg">超市照明大商铺</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">本位酒店</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">净水机组</a>
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
                    <a class="bg">G11应急照明</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">无标识</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">6#地下室应急照明</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">无标识</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">无标识</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">6#地下室应急照明</a>
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
            <a class="centerDesk gui">19号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">园林动力</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G12-2景观照明</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G12-1景观照明</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G11-1景观照明</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G11-2景观照明</a>
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
            $.getJSON("/Handler/WCFHandler.ashx?action=getdatabydevhouseid&r=" + Math.random(), { "devhouseID": 11 }, function (res) {
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
                    res.Data.N2_JXG ? $(".ele span:eq(1)").attr("class", "sideHe eleHe") : $(".ele span:eq(1)").attr("class", "sideFen eleFen");
                    //联络柜断路器状态
                    res.Data.N2_LLG ? $(".twe span:eq(1)").attr("class", "sideHe eleHe") : $(".twe span:eq(1)").attr("class", "sideFen eleFen");

                    //14号柜
                    res.Data.N2_G1.f1 ? $(".centerUl:eq(0) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f2 ? $(".centerUl:eq(0) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f3 ? $(".centerUl:eq(0) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f4 ? $(".centerUl:eq(0) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f5 ? $(".centerUl:eq(0) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f6 ? $(".centerUl:eq(0) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f7 ? $(".centerUl:eq(0) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulFen status");

                    //15号柜
                    res.Data.N2_G2.f1 ? $(".centerUl:eq(1) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f2 ? $(".centerUl:eq(1) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f3 ? $(".centerUl:eq(1) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f4 ? $(".centerUl:eq(1) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f5 ? $(".centerUl:eq(1) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f6 ? $(".centerUl:eq(1) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f7 ? $(".centerUl:eq(1) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulFen status");

                    //16号柜
                    res.Data.N2_G3.f1 ? $(".centerUl:eq(2) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G3.f2 ? $(".centerUl:eq(2) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G3.f3 ? $(".centerUl:eq(2) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G3.f4 ? $(".centerUl:eq(2) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G3.f5 ? $(".centerUl:eq(2) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G3.f6 ? $(".centerUl:eq(2) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G3.f7 ? $(".centerUl:eq(2) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G3.f8 ? $(".centerUl:eq(2) .centerLi:eq(7)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(7)").find("span:eq(0)").attr("class", "ulFen status");

                    //17号柜
                    res.Data.N2_G4.f1 ? $(".centerUl:eq(3) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G4.f2 ? $(".centerUl:eq(3) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G4.f3 ? $(".centerUl:eq(3) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G4.f4 ? $(".centerUl:eq(3) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G4.f5 ? $(".centerUl:eq(3) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G4.f6 ? $(".centerUl:eq(3) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(3) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");


                    //18号柜
                    res.Data.N2_G5.f1 ? $(".centerUl:eq(4) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f2 ? $(".centerUl:eq(4) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f3 ? $(".centerUl:eq(4) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f4 ? $(".centerUl:eq(4) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f5 ? $(".centerUl:eq(4) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f6 ? $(".centerUl:eq(4) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G5.f7 ? $(".centerUl:eq(4) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(4) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulFen status");


                    //19号柜
                    res.Data.N2_G6.f1 ? $(".centerUl:eq(5) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(5) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f2 ? $(".centerUl:eq(5) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(5) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f3 ? $(".centerUl:eq(5) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(5) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f4 ? $(".centerUl:eq(5) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(5) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f5 ? $(".centerUl:eq(5) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(5) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G6.f6 ? $(".centerUl:eq(5) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(5) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");

                }
            });
        };
    </script>
</asp:Content>
