<%@ Page Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="ElevatorHistoryAlarm.aspx.cs" Inherits="IERM.Views.Elevator.ElevatorHistoryAlarm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>实时报警</title>
    <link href="/css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="/css/table/bootstrap-table.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class="panel panel-default heightAll">
        <div class="panel-heading">
            <div class="form-inline">
                <div class="text-left">
                    <div class="input-group" >
                        <div class="controls">
                            <div class="input-prepend input-group">
                                <span class="add-on input-group-addon">时间段:</span>
                                <input type="text" readonly style="width: 200px" name="reservation" id="reservation" class="form-control" value='' />
                            </div>
                        </div>
                    </div>
                    <div class="input-group" >
                        <span class="input-group-addon">省份：</span>
                        <select class="form-control" id="province">
                        </select>
                    </div>
                    <div class="input-group" >
                        <span class="input-group-addon">城市：</span>
                        <select class="form-control" id="city">
                        </select>
                    </div>
                    <div class="input-group" >
                        <span class="input-group-addon">物业公司：</span>
                        <select class="form-control" id="selectppi">
                            <option value="0" selected>全部</option>
                            <%foreach (System.Data.DataRow item in dtb_ppi.Rows)
                                { %>
                            <option value="<%=item["propertyID"].ToString() %>"><%=item["propertyName"].ToString() %></option>
                            <%} %>
                        </select>
                    </div>
                    <div class="input-group" >
                        <span class="input-group-addon">项目：</span>
                        <input id="cpartname" type="text" class="form-control" placeholder="小区名关键字">
                    </div>
                    <button id="serach" type="button" class="btn btn-info input-group" style="margin-left: 20px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                </div>
                <div style="clear: both"></div>
            </div>
        </div>
        <div class="panel-body">
            <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                <strong>操作提示</strong> <small></small>
            </div>
            <table id="tb_alarm"></table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="/js/table/bootstrap-table.min.js"></script>
    <script src="/js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="/js/daterangepicker/moment.min.js"></script>
    <script src="/js/daterangepicker/daterangepicker.js"></script>
    <script src="/js/daterangepicker/DateFormat.js"></script>
    <script type="text/javascript">
        $(function () {

            $('#province').change(function () {
                $('#city option').remove();
                initCityList($('#province').val());
            });
            //加载省份信息
            $.getJSON("/Handler/CityAndCommunity.ashx?action=getprovinces&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#province option').remove();
                    $.map(res.Data, function (item) {
                        $('#province').append("<option value='" + item.areaID + "'>" + item.areaName + "</option>")
                    });

                    initCityList($('#province').val());
                }
            });

            $('#serach').click(function () {
                initTable();
            });

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
                    }

                },
                function (start, end, label) {

                });
        });

        //加载城市信息
        function initCityList(pid) {
            $.getJSON("/Handler/CityAndCommunity.ashx?action=getcitys&pid=" + pid + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#city option').remove();
                    $.map(res.Data, function (item) {
                        $('#city').append("<option value='" + item.areaID + "'>" + item.areaName + "</option>")
                    });

                    initTable();
                }
            });
        };

        //初始化用户表
        function initTable() {
            //先销毁表格  
            $('#tb_alarm').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_alarm").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "/Handler/ElevatorHandler.ashx?action=gethistoryalarmelevator&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 175,
                //toolbar: '#toolbar',                //工具按钮用哪个容器
                pagination: true, //启动分页  
                pageSize: 10,  //每页显示的记录数  
                pageNumber: 1, //当前第几页  
                pageList: [10, 20, 30],  //记录数可选列表  
                search: false,  //是否启用查询  
                //showColumns: true,  //显示下拉框勾选要显示的列  
                //showRefresh: true,  //显示刷新按钮  
                sidePagination: "server", //表示服务端请求  
                minimumCountColumns: 2, //最少允许的列数
                //showToggle: true,  //是否显示详细视图和列表视图的切换按钮
                //设置为undefined可以获取pageNumber，pageSize，searchText，sortName，sortOrder  
                //设置为limit可以获取limit, offset, search, sort, order  
                queryParamsType: "undefined",
                queryParams: function queryParams(params) {   //设置查询参数  
                    var param = {
                        pageNumber: params.pageNumber,
                        pageSize: params.pageSize,
                        cityID: $('#city').val(),
                        propertyID: $('#selectppi').val(),
                        partName: $('#cpartname').val(),
                        timeSpan: $('#reservation').val()
                    };
                    return param;
                },
                columns: [
                    {
                        field: 'num',
                        title: '序号',
                        align: 'center',
                        formatter: function (value, row, index) {
                            return index + 1;
                        }
                    },
                    {
                        field: 'provinceName',
                        title: '省份',
                        align: 'center'
                    },
                    {
                        field: 'cityName',
                        title: '城市',
                        align: 'center'
                    },
                    {
                        field: 'propertyName',
                        title: '物业公司',
                        align: 'center'
                    },
                    {
                        field: 'communityName',
                        title: '项目',
                        align: 'center'
                    },
                    {
                        field: 'elevatorPosition',
                        title: '报警位置',
                        align: 'center',
                    },
                    {
                        field: 'errorCodeMean',
                        title: '报警信息',
                        align: 'center',
                    },
                    {
                        field: 'alarmState',
                        title: '报警状态',
                        align: 'center',
                        formatter: function (value, row, index) {
                            var ainfo = "";
                            switch (value) {
                                case -1:
                                    ainfo = "异常";
                                    break;
                                case 1:
                                    ainfo = "正常";
                                    break;
                                default:
                                    ainfo = "未定义";
                                    break;
                            }
                            return ainfo;
                        },
                        cellStyle: function cellStyle(value, row, index) {
                            var cstyle = null;
                            switch (value) {
                                case -1:
                                    cstyle = { css: { "color": "orange" } };
                                    break;
                                default:
                                    cstyle = { css: { "color": "black" } };
                                    break;
                            }
                            return cstyle;
                        }
                    },
                    {
                        field: 'insertTime',
                        title: '报警时间',
                        align: 'center',
                    }]
            });
        }
    </script>
</asp:Content>
