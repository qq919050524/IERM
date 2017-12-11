<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="DataCurve.aspx.cs" Inherits="IERM.Views.DataCurve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>数据曲线</title>
    <link href="../css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="../css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
    <link href="../css/Wizard/prettify.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
    <link href="../css/datetimepicker/bootstrap-datetimepicker.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <input type="hidden" id="hidTid" />
    <div class='container-fluid'>
        <section id="devList">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="form-inline">
                        <div class="text-left">
                            <div class="input-group">
                                <span class="input-group-addon">物业公司：</span>
                                <select class="form-control" id="selectppi">
                                    <%foreach (var item in lstproperty)
                                        { %>
                                    <option value="<%=item.propertyID %>"><%=item.propertyName %></option>
                                    <%} %>
                                </select>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">城市项目：</span>
                                <select id="test" class="form-control" style="width: 180px; margin-right: 20px;">
                                </select>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">系统筛选：</span>
                                <select class="form-control" id="selectsys">
                                    <%foreach (var item in dtypelsit)
                                        { %>
                                    <option value="<%=item.dtID %>"><%=item.devTypeName %></option>
                                    <%} %>
                                </select>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">选择设备房：</span>
                                <select class="form-control" id="devRoom">
                                </select>
                            </div>
                            <div class="input-group">
                                <div class="controls">
                                    <div class="input-prepend input-group">
                                        <span class="add-on input-group-addon">时间段:</span>
                                        <input type="text" readonly style="width: 200px" name="reservation" id="reservation" class="form-control" value='' />
                                    </div>
                                </div>

                            </div>
                            <div class="input-group" style="margin-left: 5px;">
                                <button id="btnSearch" type="button" class="btn  btn-info glyphicon glyphicon-search">筛选</button>
                            </div>
                        </div>
                        <div style="clear: both"></div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="panel-body" style="min-height: 750px;">
        <div class="row-fluid form-inline">
            <ul class="nav nav-tabs" role="tablist" id="eleTab">
                <%-- style='height: 100%;width:10%' <li role='presentation'><a data-tid="0" href='#eleinfo' role='tab' data-toggle='tab'>用电能耗汇总</a></li>--%>
            </ul>
            <div class="tab-content" id="elecontent">
                <div role='tabpanel' class='tab-pane fade in active' id='eleinfo'>
                    <div id='eleinfo-content' class='form-group col-lg-12'>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../js/daterangepicker/moment.min.js"></script>
    <script src="../js/daterangepicker/daterangepicker.js"></script>
    <script src="../js/daterangepicker/DateFormat.js"></script>
    <script src="../js/select2andtree/select2.min.js"></script>
    <script src="../js/select2andtree/i18n/zh-CN.js"></script>
    <script src="../js/select2andtree/select2tree.js"></script>
    <script src="../js/echarts.js"></script>

    <script type="text/javascript">
        $(function () {
            initSelectTree($('#selectppi').val());
            //根据物业公司选择显示小区 
            $('#selectppi').change(function () {
                $('#devRoom option').remove();
                initSelectTree($('#selectppi').val());
            });

            $('#test').change(function () {
                var communityid = $('#test option:selected').attr('data-value');
                var devtype = $('#selectsys').val();
                initDevRoomList(communityid, devtype)
            });

            //选择设备房类型  获取该小区下的泵房或者配电室
            $('#selectsys').change(function () {
                $("#hidTid").val("");
                var communityid = $('#test option:selected').attr('data-value');
                var devtype = $('#selectsys').val();
                initDevRoomList(communityid, devtype)
            });

            //点击查询筛选数据
            $('#btnSearch').click(function () {
                $('#eleTab').empty();
                if ($('#selectsys').val() == 1) {
                    //1是查看给排水泵房数据
                    initElePanel(0, 25);
                }
                else if ($('#selectsys').val() == 2) {
                    //2是查看配电室数据
                    initElePanel(0, 26);
                } else {
                    //3是查看消防泵房数据
                    initElePanel(0, 25);
                }
            });
        });

        //初始化省市小区列表  TODO
        function initSelectTree(propertyid) {
            $("#test option").remove();
            $.getJSON("../Handler/CityAndCommunity.ashx?action=GetProCPOT"
                + "&propertyid=" + propertyid
                + "&pcityid=0"
                + "&r=" + Math.random(), null, function (res) {
                    if (res.IsSucceed) {
                        $("#test").append(res.Data).select2tree();
                        //2017年5月16日 11:27:57 BY 潘阳 初始化显示设备房
                        $('#test').change();
                    }
                });
        }

        //加载选择设备房
        function initDevRoomList(communityid, devtype) {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcommunitydev&communityid=" + communityid +
                "&devtype=" + devtype +
                "&r=" + Math.random(), null, function (res) {
                    if (res.IsSucceed) {
                        $('#devRoom option').remove();
                        $.map(res.Data, function (item) {
                            $('#devRoom').append("<option value='" + item.devID + "'>" + item.devName + "</option>")
                        });
                    }
                });
        };

        //生成图表框架
        function initElePanel(index, pID) {
            $('#eleTab').empty();
            $.getJSON("../Handler/DataListHandler.ashx?action=getenrgypumpswitch&pID=" + pID + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $.each(res.Data, function () {
                        //画出标签  磅房：环境温度，环境湿度，三相电压，三相电流，供水压力，水箱液位
                        //配电室数据分类：环境温度，环境湿度，变压器温度，三相电压，三相电流，功率因数

                        $('#eleTab').append("<li role='presentation'><a data-tid='" + this.tID + "'   href='#e" + this.tID + "' role='tab' data-toggle='tab'>" + this.typeName + "</a></li>");
                        //$('#elecontent').append("<div role='tabpanel' class='tab-pane fade' id='e" + this.tID + "'><div id='e" + this.tID + "-content' class='form-group col-lg-12' style='min-height: 750px;'></div></div>");
                    });
                    $('#elecontent').append("<div role='tabpanel' class='tab-pane fade' id='eChart'><div id='eChartContent' class='form-group col-lg-12' style='min-height: 450px;'></div></div>");
                    //debugger;
                    $("#eleTab a[data-toggle='tab']").on('shown.bs.tab', function (e) {
                        var tid = $(e.target).attr("data-tid");
                        $("#hidTid").val(tid);
                        initChartsData(tid);
                    });
                    if ($("#hidTid").val() == "") {
                        //默认选中第一个
                        var tid = $("#eleTab a:first-child").attr("data-tid");
                        $("#hidTid").val(tid);
                    }

                    //把当前点击的父级选中
                    $("#eleTab a[data-tid='" + $("#hidTid").val() + "']").parent().attr("class", "active");
                    //将图标选项选中
                    $("#eChart").attr("class", "active");
                    $("#eChart").parent().attr("class", "in");
                    //清空charts
                    initChartsData($("#hidTid").val());

                }
            });
        }

        //加载选中视图
        function initChartsData(tid) {
            $.getJSON("../Handler/DataListHandler.ashx?action=getchartsdatalist&r=" + Math.random(), {
                "sysType": $('#selectsys').val(),
                "dataType": tid,
                "timeSpan": $('#reservation').val(),
                "commcommunityID": $('#cpartname').val(),
                "devID": $('#devRoom').val()
            }, function (res) {
                if ($('#selectsys').val() == "2") {
                    //配电室
                    if (tid == 33) {
                        DrawLineChartT_ROOM(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 34) {
                        DrawLineChartH_ROOM(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 35) {
                        DrawLineChartSwitchTransformerTemperature(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 36) {
                        DrawLineChartSwitchVoltage(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 37) {
                        DrawLineChartSwitchCurrent(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 38) {
                        DrawLineChartSwitchPower(document.getElementById("eChartContent"), res, tid);
                    }
                }
                else {
                    //泵房
                    if (tid == 27) {

                        DrawLineChartT_ROOM(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 28) {
                        DrawLineChartH_ROOM(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 29) {
                        DrawLineChartVoltage(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 30) {
                        DrawLineChartCurrent(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 31) {
                        DrawLineChartWaterGage(document.getElementById("eChartContent"), res, tid);
                    }
                    else if (tid == 32) {
                        DrawLineChartHydraulic(document.getElementById("eChartContent"), res, tid);
                    }
                }
            });
        }


        $('#reservation').val(new Date().Format('yyyy-MM-01') + "-" + new Date().Format('yyyy-MM-dd'));
        $('#reservation').daterangepicker(
             {
                 format: 'YYYY-MM-DD',
                 startDate: new Date().Format('yyyy-MM-01'),
                 endDate: new Date().Format('yyyy-MM-dd'),
                 locale: {
                     applyLabel: '确定',
                     cancelLabel: '取消',
                     fromLabel: '起始日期',
                     toLabel: '结束日期',
                     customRangeLabel: '自定义',
                     daysOfWeek: ['日', '一', '二', '三', '四', '五', '六'],
                     monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
                     '七月', '八月', '九月', '十月', '十一月', '十二月'],
                     firstDay: 1
                 },
             }
             //function (start, end, label) {
             //    //选择时间后更新曲线图数据
             //    if ($('#selectsys').val() == 2) {
             //        //1是查看配电室数据
             //        initElePanel(0, 26);
             //    }
             //    else {
             //        //2是查看泵房数据
             //        initElePanel(0, 25);
             //    }
             //}
             );


        //获取json的数据长度
        function getJsonLength(jsonData) {
            var jsonLength = 0;
            for (var item in jsonData) {
                jsonLength++;
            }
            return jsonLength;
        }

        var beginDate = null;
        var endDate = null;
        //返回天数
        function GetDateDiff(date) {
            beginDate = null;
            var beginyear = date.split("-")[0];
            var beginmonth = date.split("-")[1];
            var beginday = date.split("-")[2];
            var endyear = date.split("-")[3];
            var endmonth = date.split("-")[4];
            var endday = date.split("-")[5];
            var startDate1 = beginyear + "-" + beginmonth + "-" + beginday + "  00:00:00";
            var endDate1 = endyear + "-" + endmonth + "-" + endday + "  23:59:59";
            beginDate = beginyear + "-" + beginmonth + "-" + beginday;
            endDate = endyear + "-" + endmonth + "-" + endday;
            var startTime = new Date(Date.parse(startDate1.replace(/-/g, "/"))).getTime();
            var endTime = new Date(Date.parse(endDate1.replace(/-/g, "/"))).getTime();
            var days = Math.round(Math.abs((startTime - endTime)) / (1000 * 60 * 60 * 24));
            return days;
        }

        function getDate(datestr) {
            var temp = datestr.split("-");
            var date = new Date(temp[0], temp[1], temp[2]);
            return date;
        }
        var myDataArray = new Array()
        //输入启示和结束日期 获取这段时间每一天日期
        function getEveryDay(date) {
            var beginyear = date.split("-")[0];
            var beginmonth = date.split("-")[1];
            var beginday = date.split("-")[2];
            var endyear = date.split("-")[3];
            var endmonth = date.split("-")[4];
            var endday = date.split("-")[5];
            var startDate1 = beginyear + "-" + beginmonth + "-" + beginday;
            var endDate1 = endyear + "-" + endmonth + "-" + endday;
            var startTime = getDate(startDate1);
            var endTime = getDate(endDate1);
            var dys = -1;
            while ((endTime.getTime() - startTime.getTime()) >= 0) {
                dys++;
                var year = startTime.getFullYear();
                var month = startTime.getMonth().toString().length == 1 ? "0" + startTime.getMonth().toString() : startTime.getMonth();
                var day = startTime.getDate().toString().length == 1 ? "0" + startTime.getDate() : startTime.getDate();
                myDataArray[dys] = year + "-" + month + "-" + day;
                startTime.setDate(startTime.getDate() + 1);
            }
        }


        function data_string(str) {
            var d = eval('new ' + str.substr(1, str.length - 2));
            var ar_date = [d.getFullYear(), d.getMonth() + 1, d.getDate(), d.getHours(), d.getMinutes(), d.getSeconds()];
            for (var i = 0; i < ar_date.length; i++) ar_date[i] = dFormat(ar_date[i]);
            return ar_date.slice(0, 3).join('-') + ' ' + ar_date.slice(3).join(':');

            function dFormat(i) { return i < 10 ? "0" + i.toString() : i; }
        }

        //泵房
        //绘制折线图   T_room
        function DrawLineChartT_ROOM(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['设备房-环境温度']
                },
                grid: {
                    left: '1%',
                    right: '1%',
                    bottom: '8%',
                    containLabel: true
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                xAxis: [
                    {
                        show: false,
                        type: 'category',
                        axisLabel: {
                            rotate: 45,
                            interval: 0
                        },
                        axisTick: {
                            alignWithLabel: true
                        },
                        data: []
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '设备房-环境温度',
                          type: 'line',
                          // stack: '总量',
                          //areaStyle: { normal: {} },
                          data: [

                          ]
                      }
                ]
            };
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }

            for (var i = 0; i < data.length; i++) {

                option.series[0].data.push(data[i].T_ROOM);
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");

        };

        function DrawLineChartH_ROOM(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['设备房-环境湿度']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                    {
                        show: false,
                        type: 'category',
                        boundaryGap: false,
                        axisLabel: {
                            //X轴刻度配置
                            interval: 'auto' //0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                        },
                        data: []
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '设备房-环境湿度',
                          type: 'line',
                          //stack: '总量',
                          // areaStyle: { normal: {} },
                          data: []
                      }
                ]
            };

            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }

            for (var i = 0; i < data.length; i++) {
                option.series[0].data.push(data[i].H_ROOM);
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");

        };

        //三相电压
        function DrawLineChartVoltage(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['生活供水-电源柜AB线电压', '生活供水-电源柜BC线电压', '生活供水-电源柜CA线电压', '消防供水-电源柜AB线电压', '消防供水-电源柜BC线电压', '消防供水-电源柜CA线电压']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                   {
                       show: false,
                       type: 'category',
                       boundaryGap: false,
                       axisLabel: {
                           //X轴刻度配置
                           interval: 'auto' //0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                       },
                       data: []
                   }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      //{
                      //    name: '生活供水-电源柜AB线电压',
                      //    type: 'line',
                      //    //stack: '总量',
                      //    //  areaStyle: { normal: {} },
                      //    data: []
                      //},
                      // {
                      //     name: '生活供水-电源柜BC线电压',
                      //     type: 'line',
                      //     //stack: '总量',
                      //     //  areaStyle: { normal: {} },
                      //     data: []
                      // },
                      //  {
                      //      name: '生活供水-电源柜CA线电压',
                      //      type: 'line',
                      //      //stack: '总量',
                      //      //  areaStyle: { normal: {} },
                      //      data: []
                      //  },
                      //   {
                      //       name: '消防供水-电源柜AB线电压',
                      //       type: 'line',
                      //       //stack: '总量',
                      //       // areaStyle: { normal: {} },
                      //       data: []
                      //   },
                      //    {
                      //        name: '消防供水-电源柜BC线电压',
                      //        type: 'line',
                      //        //stack: '总量',
                      //        // areaStyle: { normal: {} },
                      //        data: []
                      //    },
                      //     {
                      //         name: '消防供水-电源柜CA线电压',
                      //         type: 'line',
                      //         //stack: '总量',
                      //         // areaStyle: { normal: {} },
                      //         data: []
                      //     },
                ]
            };
            //x轴DATA
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }

            //根据不同的设备类型展示不同的设备信息
            var sysType = $("#selectsys").val();//1给排水 3消防
            if (sysType == "1") {
                //清空
                option.legend.data.splice(0, option.legend.data.length);
                option.legend.data.push("生活供水-电源柜AB线电压");
                option.legend.data.push("生活供水-电源柜BC线电压");
                option.legend.data.push("生活供水-电源柜CA线电压");

                option.series.splice(0, option.series.length);
                option.series.push({
                    name: '生活供水-电源柜AB线电压',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '生活供水-电源柜BC线电压',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '生活供水-电源柜CA线电压',
                    type: 'line',
                    data: []
                });
                for (var i = 0; i < data.length; i++) {
                    //生活供水-电源柜AB线电压
                    option.series[0].data.push(data[i].UAB_SH);
                    option.series[1].data.push(data[i].UBC_SH);
                    option.series[2].data.push(data[i].UCA_SH);
                }
            } else if (sysType == "3") {
                //清空
                option.legend.data.splice(0, option.legend.data.length);
                option.legend.data.push("消防供水-电源柜AB线电压");
                option.legend.data.push("消防供水-电源柜BC线电压");
                option.legend.data.push("消防供水-电源柜CA线电压");
                //清空
                option.series.splice(0, option.series.length);
                option.series.push({
                    name: '消防供水-电源柜AB线电压',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '消防供水-电源柜BC线电压',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '消防供水-电源柜CA线电压',
                    type: 'line',
                    data: []
                });
                for (var i = 0; i < data.length; i++) {
                    //生活供水-电源柜AB线电压
                    option.series[0].data.push(data[i].UAB_XF);
                    option.series[1].data.push(data[i].UBC_XF);
                    option.series[2].data.push(data[i].UCA_XF);
                }
            }



            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");
        };

        //供水压力
        function DrawLineChartWaterGage(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            var colors = ['#000080', '#DC143C', '#00BFFF', '#B03060', '#ADFF2F', '#00FFFF', '#8B7500', '#FFFF00', '#7D26CD'];
            // 指定图表的配置项和数据
            option = {
                color: colors,
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['生活供水-市政进水压力', '生活供水-低区供水压力', '生活供水-中区供水压力', '生活供水-高区供水压力', '生活供水-超高区供水压力', '消防供水-消防1#供水压力', '消防供水-喷淋1#供水压力', '消防供水-消防2#供水压力', '消防供水-喷淋2#供水压力']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                   {
                       show: false,
                       type: 'category',
                       boundaryGap: false,
                       axisLabel: {
                           //X轴刻度配置
                           interval: 0 //0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                       },
                       data: []
                   }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '生活供水-市政进水压力',
                          type: 'line',
                          //stack: '总量',
                          // areaStyle: { normal: {} },
                          data: []
                      },
                       {
                           name: '生活供水-低区供水压力',
                           type: 'line',
                           // stack: '总量',
                           // areaStyle: { normal: {} },
                           data: []
                       },
                        {
                            name: '生活供水-中区供水压力',
                            type: 'line',
                            //stack: '总量',
                            // areaStyle: { normal: {} },
                            data: []
                        },
                         {
                             name: '生活供水-高区供水压力',
                             type: 'line',
                             // stack: '总量',
                             //  areaStyle: { normal: {} },
                             data: []
                         },
                          {
                              name: '生活供水-超高区供水压力',
                              type: 'line',
                              // stack: '总量',
                              //  areaStyle: { normal: {} },
                              data: []
                          },
                           {
                               name: '消防供水-消防1#供水压力',
                               type: 'line',
                               //stack: '总量',
                               // areaStyle: { normal: {} },
                               data: []
                           },
                             {
                                 name: '消防供水-喷淋1#供水压力',
                                 type: 'line',
                                 // stack: '总量',
                                 // areaStyle: { normal: {} },
                                 data: []
                             },
                               {
                                   name: '消防供水-消防2#供水压力',
                                   type: 'line',
                                   // stack: '总量',
                                   //areaStyle: { normal: {} },
                                   data: []
                               },
                                {
                                    name: '消防供水-喷淋2#供水压力',
                                    type: 'line',
                                    // stack: '总量',
                                    // areaStyle: { normal: {} },
                                    data: []
                                }
                ]
            };
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }
            //根据不同的设备类型展示不同的设备信息
            var sysType = $("#selectsys").val();//1给排水 3消防
            if (sysType == "1") {
                // data: ['生活供水-市政进水压力', '生活供水-低区供水压力', '生活供水-中区供水压力', '生活供水-高区供水压力', '生活供水-超高区供水压力', '消防供水-消防1#供水压力', '消防供水-喷淋1#供水压力', '消防供水-消防2#供水压力', '消防供水-喷淋2#供水压力']
                //清空
                option.legend.data.splice(0, option.legend.data.length);
                option.legend.data.push("生活供水-市政进水压力");
                option.legend.data.push("生活供水-低区供水压力");
                option.legend.data.push("生活供水-中区供水压力");
                option.legend.data.push("生活供水-高区供水压力");
                option.legend.data.push("生活供水-超高区供水压力");

                option.series.splice(0, option.series.length);
                option.series.push({
                    name: '生活供水-市政进水压力',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '生活供水-低区供水压力',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '生活供水-中区供水压力',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '生活供水-高区供水压力',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '生活供水-超高区供水压力',
                    type: 'line',
                    data: []
                });
                for (var i = 0; i < data.length; i++) {
                    option.series[0].data.push(data[i].P_IN);
                    option.series[1].data.push(data[i].P_LO);
                    option.series[2].data.push(data[i].P_MI);
                    option.series[3].data.push(data[i].P_HI);
                    option.series[4].data.push(data[i].P_SP);
                }
            } else if (sysType == "3") {
                option.legend.data.splice(0, option.legend.data.length);
                option.legend.data.push("消防供水-消防1#供水压力");
                option.legend.data.push("消防供水-喷淋1#供水压力");
                option.legend.data.push("消防供水-消防2#供水压力");
                option.legend.data.push("消防供水-喷淋2#供水压力");

                option.series.splice(0, option.series.length);
                option.series.push({
                    name: '消防供水-消防1#供水压力',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '消防供水-喷淋1#供水压力',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '消防供水-消防2#供水压力',
                    type: 'line',
                    data: []
                }); option.series.push({
                    name: '消防供水-喷淋2#供水压力',
                    type: 'line',
                    data: []
                });
                for (var i = 0; i < data.length; i++) {
                    option.series[0].data.push(data[i].P_XF1);
                    option.series[1].data.push(data[i].P_PL1);
                    option.series[2].data.push(data[i].P_XF2);
                    option.series[3].data.push(data[i].P_PL2);
                }
            }

            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");
        };

        //三相电流
        function DrawLineChartCurrent(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['生活供水-电源柜A相电流', '生活供水-电源柜B相电流', '生活供水-电源柜C相电流', '消防供水-电源柜A相电流', '消防供水-电源柜B相电流', '消防供水-电源柜C相电流']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                    {
                        show: false,
                        type: 'category',
                        boundaryGap: false,
                        //axisLabel: {
                        //    //X轴刻度配置
                        //    interval: 0//0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                        //},
                        data: []
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '生活供水-电源柜A相电流',
                          type: 'line',
                          //stack: '总量',
                          //areaStyle: { normal: {} },
                          data: []
                      },
                       {
                           name: '生活供水-电源柜B相电流',
                           type: 'line',
                           //stack: '总量',
                           // areaStyle: { normal: {} },
                           data: []
                       },
                        {
                            name: '生活供水-电源柜C相电流',
                            type: 'line',
                            // stack: '总量',
                            //  areaStyle: { normal: {} },
                            data: []
                        },
                         {
                             name: '消防供水-电源柜A相电流',
                             type: 'line',
                             //stack: '总量',
                             //  areaStyle: { normal: {} },
                             data: []
                         },
                          {
                              name: '消防供水-电源柜B相电流',
                              type: 'line',
                              //stack: '总量',
                              // areaStyle: { normal: {} },
                              data: []
                          },
                           {
                               name: '消防供水-电源柜C相电流',
                               type: 'line',
                               //stack: '总量',
                               //  areaStyle: { normal: {} },
                               data: []
                           }
                ]
            };
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }
            //根据不同的设备类型展示不同的设备信息
            var sysType = $("#selectsys").val();//1给排水 3消防
            if (sysType == "1") {
                //清空
                option.legend.data.splice(0, option.legend.data.length);
                option.legend.data.push("生活供水-电源柜AB线电压");
                option.legend.data.push("生活供水-电源柜BC线电压");
                option.legend.data.push("生活供水-电源柜CA线电压");

                option.series.splice(0, option.series.length);
                option.series.push({
                    name: '生活供水-电源柜AB线电压',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '生活供水-电源柜BC线电压',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '生活供水-电源柜CA线电压',
                    type: 'line',
                    data: []
                });
                for (var i = 0; i < data.length; i++) {
                    option.series[0].data.push(data[i].IA_SH);
                    option.series[1].data.push(data[i].IB_SH);
                    option.series[2].data.push(data[i].IC_SH);
                }
            } else if (sysType == "3") {
                //清空
                option.legend.data.splice(0, option.legend.data.length);
                option.legend.data.push("消防供水-电源柜AB线电压");
                option.legend.data.push("消防供水-电源柜BC线电压");
                option.legend.data.push("消防供水-电源柜CA线电压");
                //清空
                option.series.splice(0, option.series.length);
                option.series.push({
                    name: '消防供水-电源柜AB线电压',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '消防供水-电源柜BC线电压',
                    type: 'line',
                    data: []
                });
                option.series.push({
                    name: '消防供水-电源柜CA线电压',
                    type: 'line',
                    data: []
                });
                for (var i = 0; i < data.length; i++) {
                    option.series[0].data.push(data[i].IA_XF);
                    option.series[1].data.push(data[i].IB_XF);
                    option.series[2].data.push(data[i].IC_XF);
                }
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");
        };

        //液压
        function DrawLineChartHydraulic(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['生活供水-生活水箱液位', '消防供水-消防水箱液位']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                    {
                        show: false,
                        type: 'category',
                        boundaryGap: false,
                        axisLabel: {
                            //X轴刻度配置
                            interval: 0//0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                        },
                        data: []
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '生活供水-生活水箱液位',
                          type: 'line',
                          //stack: '总量',
                          // areaStyle: { normal: {} },
                          data: [

                          ]
                      },
                       {
                           name: '消防供水-消防水箱液位',
                           type: 'line',
                           //stack: '总量',
                           // areaStyle: { normal: {} },
                           data: [

                           ]
                       }
                ]
            };
            var begin = null;
            var end = null;
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }

            //根据不同的设备类型展示不同的设备信息
            var sysType = $("#selectsys").val();//1给排水 3消防
            if (sysType == "1") {
                //清空
                option.legend.data.splice(0, option.legend.data.length);
                option.legend.data.push("生活供水-生活水箱液位");

                option.series.splice(0, option.series.length);
                option.series.push({
                    name: '生活供水-生活水箱液位',
                    type: 'line',
                    data: []
                });
                for (var i = 0; i < data.length; i++) {
                    option.series[0].data.push(data[i].L_SHSX);
                }
            } else if (sysType == "3") {
                //清空
                option.legend.data.splice(0, option.legend.data.length);
                option.legend.data.push("消防供水-消防水箱液位");
                //清空
                option.series.splice(0, option.series.length);
                option.series.push({
                    name: '消防供水-消防水箱液位',
                    type: 'line',
                    data: []
                });
                for (var i = 0; i < data.length; i++) {
                    option.series[0].data.push(data[i].L_XFSX);
                }
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");
        };

        //配电室
        //变压器温度
        function DrawLineChartSwitchTransformerTemperature(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['变压器A相温度', '变压器B相温度', '变压器C相温度', '变压器A2相温度', '变压器B2相温度', '变压器C2相温度']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                    {

                        show: false,
                        type: 'category',
                        boundaryGap: false,
                        axisLabel: {
                            //X轴刻度配置
                            interval: 0 //0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                        },
                        data: []
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '变压器A相温度',
                          type: 'line',
                          //stack: '总量',
                          //   areaStyle: { normal: {} },
                          data: []
                      },
                       {
                           name: '变压器B相温度',
                           type: 'line',
                           //stack: '总量',
                           //  areaStyle: { normal: {} },
                           data: []
                       },
                        {
                            name: '变压器C相温度',
                            type: 'line',
                            //stack: '总量',
                            // areaStyle: { normal: {} },
                            data: []
                        },
                         {
                             name: '变压器A2相温度',
                             type: 'line',
                             stack: '总量',
                             // areaStyle: { normal: {} },
                             data: []
                         },
                          {
                              name: '变压器B2相温度',
                              type: 'line',
                              //stack: '总量',
                              //  areaStyle: { normal: {} },
                              data: []
                          },
                           {
                               name: '变压器C2相温度',
                               type: 'line',
                               //stack: '总量',
                               //  areaStyle: { normal: {} },
                               data: []
                           },
                ]
            };
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }
            for (var i = 0; i < data.length; i++) {
                //生活供水-电源柜AB线电压
                option.series[0].data.push(data[i].N1_T_A);
                option.series[1].data.push(data[i].N1_T_B);
                option.series[2].data.push(data[i].N1_T_C);
                option.series[3].data.push(data[i].N2_T_A);
                option.series[4].data.push(data[i].N2_T_B);
                option.series[5].data.push(data[i].N2_T_C);
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");
        }

        //配电室三项电压
        function DrawLineChartSwitchVoltage(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['进线柜AB线电压', '进线柜BC线电压', '进线柜CA线电压', '进线柜AB2线电压', '进线柜BC2线电压', '进线柜CA2线电压']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                   {
                       show: false,
                       type: 'category',
                       boundaryGap: false,
                       axisLabel: {
                           //X轴刻度配置
                           interval: 0//0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                       },
                       data: []
                   }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '进线柜AB线电压',
                          type: 'line',
                          //stack: '总量',
                          //  areaStyle: { normal: {} },
                          data: []
                      },
                       {
                           name: '进线柜BC线电压',
                           type: 'line',
                           //stack: '总量',
                           //     areaStyle: { normal: {} },
                           data: []
                       },
                        {
                            name: '进线柜CA线电压',
                            type: 'line',
                            //stack: '总量',
                            //   areaStyle: { normal: {} },
                            data: []
                        },
                         {
                             name: '进线柜AB2线电压',
                             type: 'line',
                             // stack: '总量',
                             //  areaStyle: { normal: {} },
                             data: []
                         },
                          {
                              name: '进线柜BC2线电压',
                              type: 'line',
                              //stack: '总量',
                              //   areaStyle: { normal: {} },
                              data: []
                          },
                           {
                               name: '进线柜CA2线电压',
                               type: 'line',
                               //stack: '总量',
                               //   areaStyle: { normal: {} },
                               data: []
                           },
                ]
            };
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }
            for (var i = 0; i < data.length; i++) {
                //生活供水-电源柜AB线电压
                option.series[0].data.push(data[i].N1_UAB);
                option.series[1].data.push(data[i].N1_UBC);
                option.series[2].data.push(data[i].N1_UCA);
                option.series[3].data.push(data[i].N2_UAB);
                option.series[4].data.push(data[i].N2_UBC);
                option.series[5].data.push(data[i].N2_UCA);
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");
        }

        //配电室三相电流
        function DrawLineChartSwitchCurrent(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['进线柜A相电流', '进线柜B相电流', '进线柜C相电流', '进线柜A2相电流', '进线柜B2相电流', '进线柜C2相电流']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                    {
                        show: false,
                        type: 'category',
                        boundaryGap: false,
                        axisLabel: {
                            //X轴刻度配置
                            interval: 0//0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                        },
                        data: []
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '进线柜A相电流',
                          type: 'line',
                          //stack: '总量',
                          //  areaStyle: { normal: {} },
                          data: []
                      },
                       {
                           name: '进线柜B相电流',
                           type: 'line',
                           //stack: '总量',
                           //   areaStyle: { normal: {} },
                           data: []
                       },
                        {
                            name: '进线柜C相电流',
                            type: 'line',
                            //stack: '总量',
                            // areaStyle: { normal: {} },
                            data: []
                        },
                         {
                             name: '进线柜A2相电流',
                             type: 'line',
                             //stack: '总量',
                             //    areaStyle: { normal: {} },
                             data: []
                         },
                          {
                              name: '进线柜B2相电流',
                              type: 'line',
                              //stack: '总量',
                              // areaStyle: { normal: {} },
                              data: []
                          },
                           {
                               name: '进线柜C2相电流',
                               type: 'line',
                               //stack: '总量',
                               //  areaStyle: { normal: {} },
                               data: []
                           }
                ]
            };
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }
            for (var i = 0; i < data.length; i++) {
                //生活供水-电源柜AB线电压
                option.series[0].data.push(data[i].N1_IA);
                option.series[1].data.push(data[i].N1_IB);
                option.series[2].data.push(data[i].N1_IC);
                option.series[3].data.push(data[i].N2_IA);
                option.series[4].data.push(data[i].N2_IB);
                option.series[5].data.push(data[i].N2_IC);
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");

        };

        //配电室功率因数
        function DrawLineChartSwitchPower(obj, data, tid) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            // 指定图表的配置项和数据
            option = {
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['进线柜功率因素', '进线柜2功率因素']
                },
                toolbox: {
                    feature: {
                        saveAsImage: {}
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                    {
                        show: false,
                        type: 'category',
                        boundaryGap: false,
                        axisLabel: {
                            //X轴刻度配置
                            interval: 0 //0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                        },
                        data: []
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                      {
                          name: '进线柜功率因素',
                          type: 'line',
                          //stack: '总量',
                          // areaStyle: { normal: {} },
                          data: []
                      },
                       {
                           name: '进线柜2功率因素',
                           type: 'line',
                           // stack: '总量',
                           // areaStyle: { normal: {} },
                           data: []
                       }
                ]
            };
            for (var i = 0; i < data.length; i++) {
                option.xAxis[0].data.push(data[i].InsertTime);
            }
            for (var i = 0; i < data.length; i++) {
                //生活供水-电源柜AB线电压
                option.series[0].data.push(data[i].N1_PF);
                option.series[1].data.push(data[i].N2_PF);
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            GetDateDiff($('#reservation').val());
            $("#eChartContent").append("<div font-size: 64px!important;>" + beginDate + "---------------" + endDate + "</div>");

        };
    </script>
</asp:Content>
