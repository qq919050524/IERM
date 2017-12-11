<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="DataList.aspx.cs" Inherits="IERM.Views.DataList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>数据统计</title>
    <link href="../css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="../css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
    <link href="../css/Wizard/prettify.css" rel="stylesheet" />

    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
    <link href="../css/datetimepicker/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="../css/strap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
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
                                <select id="test" class="form-control" style="width: 170px;">
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
                                <select class="form-control" id="devRoom" style="min-width: 60px">
                                </select>
                            </div>
                            <div style="padding-top: 50px;">
                                <div class="input-group">
                                    <span class="add-on input-group-addon">开始时间：</span>
                                    <div class="controls input-append date form_datetime" data-date="" data-date-format="yyyy-mm-dd hh:ii" data-link-field="hid_begindate" style="float: left">
                                        <input type="text" id="input_begindate" value="<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm") %>" readonly class="form-control" style="width: 160px">
                                        <span class="add-on"><i class="icon-th"></i></span>
                                    </div>
                                    <input type="hidden" id="hid_begindate" value="" />

                                </div>
                                <div class="input-group">
                                    <span class="add-on input-group-addon">结束时间：</span>
                                    <div class="controls input-append date form_datetime" data-date="" data-date-format="yyyy-mm-dd hh:ii" data-link-field="hid_enddate" style="float: left">
                                        <input type="text" id="input_enddate" value="<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm") %>" readonly class="form-control" style="width: 145px">
                                        <span class="add-on"><i class="icon-th"></i></span>
                                    </div>
                                    <input type="hidden" id="hid_enddate" value="" />
                                </div>
                                <div class="input-group" style="margin-left: 5px;">
                                    <button id="btnSearch" type="button" class="btn  btn-info glyphicon glyphicon-search">筛选</button>
                                    <button id="Exprot" type="button" class="btn  btn-info glyphicon glyphicon-download" style="margin-left: 5px;">导出EXCEL </button>
                                </div>
                            </div>
                        </div>
                        <div style="clear: both"></div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="panel-body">
        <table id="tb_DataList" style="cursor: pointer;">
        </table>
        <div class="introDetail">
            <ul class="ulOne">
                <li>
                    <a>最高值：<span id="spMax"></span></a>
                </li>
                <li>
                    <a>最低值：<span id="spMin"></span></a>
                </li>
                <li>
                    <a>平均值：<span id="spavg"></span></a>
                </li>
                <li>
                    <a>差 值：<span id="spDiff"></span></a>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <link href="../css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../js/daterangepicker/moment.min.js"></script>
    <script src="../js/daterangepicker/daterangepicker.js"></script>
    <script src="../js/daterangepicker/DateFormat.js"></script>
    <script src="../js/select2andtree/select2.min.js"></script>
    <script src="../js/select2andtree/i18n/zh-CN.js"></script>
    <script src="../js/select2andtree/select2tree.js"></script>
    <script src="../js/datetimepicker/bootstrap-datetimepicker.min.js"></script>
    <script src="../js/datetimepicker/bootstrap-datetimepicker.zh-CN.js"></script>
    <script src="../js/echarts.js"></script>
    <script type="text/javascript">
        $(function () {
            initPumphouse_rdTable();

            initSelectTree($('#selectppi').val());

            $('#Exprot').click(function (e) {
                $.getJSON("../Handler/DataListHandler.ashx?action=getexcel&r=" + Math.random(), {
                    // "timeSpan": $('#reservation').val(),
                    "systype": $('#selectsys').val(),
                    "devid": $('#devRoom').val(),
                    "communityid": $('#cpartname').val(),
                    "begindate": $('#input_begindate').val(),
                    "enddate": $('#input_enddate').val()
                }, function (res) {
                    if (res[0] == 0) {
                        //下载excel
                        var url = '../upload/DataExcel/' + res[1]
                        var win = window.open(url, '_self');
                        win.location.href = url;
                        //下载成功
                        alert(res[1] + "数据下载成功....");
                    }
                    else if (res[0] == 1) {
                        alert(res[1] + "数据下载失败....");
                    }
                });

            });

            $('#btnSearch').click(function () {
                if ($('#selectsys').val() == 1) {
                    //1是查看给水泵房数据
                    initPumphouse_rdTable();
                }
                else if ($('#selectsys').val() == 2) {
                    //2是查看配电室数据
                    initSwitchroom_rdTable();
                } else {
                    //3是查看消防泵房数据
                    initFirePumphouse_rdTable();
                }
            });

            $('#test').change(function () {
                var communityid = $('#test option:selected').attr('data-value');
                var devtype = $('#selectsys').val();
                initDevRoomList(communityid, devtype);
            });

            //选择设备房类型  获取该小区下的泵房或者配电室
            $('#selectsys').change(function () {

                var communityid = $('#test option:selected').attr('data-value');
                var devtype = $('#selectsys').val();
                initDevRoomList(communityid, devtype);
            });

            //根据物业公司选择显示小区 
            $('#selectppi').change(function () {
                $('#devRoom option').remove();
                initSelectTree($('#selectppi').val());
            });

            $('.form_datetime').datetimepicker({
                language: 'zh-CN',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 2,
                startView: 2,
                forceParse: 0,
                showMeridian: 1,
                minuteStep: 5
            });

            $('.form_datetime').datetimepicker(new Date().Format('yyyy-MM-dd HH:mm'));
        })


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

        //初始化省市小区列表  TODO
        function initSelectTree(propertyid) {
            $("#test option").remove();
            $.getJSON("../Handler/CityAndCommunity.ashx?action=GetProCPOT"
                + "&propertyid=" + propertyid
                + "&pcityid=0"
                + "&r=" + Math.random(), null, function (res) {
                    if (res.IsSucceed) {
                        $("#test").append(res.Data).select2tree();

                        //初始化设备房数据
                        var communityid = $('#test option:selected').attr('data-value');
                        var devtype = $('#selectsys').val();
                        initDevRoomList(communityid, devtype);
                    }
                });
        }

        //初始化给排水泵房记录统计
        function initPumphouse_rdTable() {
            //先销毁表格  
            $('#tb_DataList').bootstrapTable('destroy');
            //清空最大值 最小值 平均值  差值
            $('#spMax').empty();
            $('#spMin').empty();
            $('#spavg').empty();
            $('#spDiff').empty();
            //初始化表格,动态从服务器加载数据  
            $("#tb_DataList").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/DataListHandler.ashx?action=getdevpump&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 195,
                //toolbar: '#toolbar',//工具按钮用哪个容器
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
                onClickCell: function (field, value, row) {
                    var columnName = field;
                    if (columnName != "num" && columnName != "InsertTime") {
                        $.getJSON("../Handler/DataListHandler.ashx?action=getdanalysis&columnname=" + columnName + "&tablename=pumphouse_rd&r=" + Math.random(), null, function (res) {
                            $('#spMax').html(res.rows[0].Max);
                            $('#spMin').html(res.rows[0].Min);
                            $('#spavg').html(res.rows[0].Avg);
                            $('#spDiff').html(res.rows[0].Difference);
                        });
                    }
                    else {
                        alert("请选择数据列");
                    }
                },
                queryParamsType: "undefined",
                queryParams: function queryParams(params) {   //设置查询参数  
                    var param = {
                        pageNumber: params.pageNumber,
                        pageSize: params.pageSize,
                        devid: $('#devRoom').val(),
                        //  timeSpan: $('#reservation').val(),
                        begindate: $('#input_begindate').val(),
                        enddate: $('#input_enddate').val()
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
                    field: 'InsertTime',
                    title: '时间（年-月-日 H-M-S)',
                    align: 'center',
                },
                {
                    field: 'T_ROOM',
                    title: '设备房<br/>环境温度',
                    align: 'center',

                },
                 {
                     field: 'H_ROOM',
                     title: '设备房<br/>环境湿度',
                     align: 'center',
                 },
                {
                    field: 'UAB_SH',
                    title: '生活供水<br/>电源柜AB线电压',
                    align: 'center'
                },
                {
                    field: 'UBC_SH',
                    title: '生活供水<br/>电源柜BC线电压',
                    align: 'center'
                },
                {
                    field: 'UCA_SH',
                    title: '生活供水<br/>电源柜CA线电压',
                    align: 'center'

                },
                {
                    field: 'IA_SH',
                    title: '生活供水<br/>电源柜A相电流',
                    align: 'center'

                },
                {
                    field: 'IB_SH',
                    title: '生活供水<br/>电源柜B相电流',
                    align: 'center'

                },
                {
                    field: 'IC_SH',
                    title: '生活供水<br/>电源柜C相电流',
                    align: 'center'

                },
                {
                    field: 'KWH_SH',
                    title: '生活供水<br/>电源柜有功电能',
                    align: 'center'

                },
                {
                    field: 'KVARH_SH',
                    title: '生活供水<br/>电源柜无功电能',
                    align: 'center'

                },
                 {
                     field: 'PF_SH',
                     title: '生活供水<br/>电源柜功率因素',
                     align: 'center'

                 },
                  {
                      field: 'L_SHSX',
                      title: '生活供水<br/>生活水箱液位',
                      align: 'center'

                  },
                   {
                       field: 'P_IN',
                       title: '生活供水<br/>市政进水压力',
                       align: 'center'

                   },
                    {
                        field: 'P_LO',
                        title: '生活供水<br/>低区供水压力',
                        align: 'center'

                    },
                     {
                         field: 'P_MI',
                         title: '生活供水<br/>中区供水压力',
                         align: 'center'

                     },
                    {
                        field: 'P_HI',
                        title: '生活供水<br/>高区供水压力',
                        align: 'center'

                    },
                    {
                        field: 'P_SP',
                        title: '生活供水<br/>超高区供水压力',
                        align: 'center'

                    },
                     //{
                     //    field: 'UAB_XF',
                     //    title: '消防供水<br/>电源柜AB线电压',
                     //    align: 'center'

                     //},
                     //{
                     //    field: 'UBC_XF',
                     //    title: '消防供水<br/>电源柜BC线电压',
                     //    align: 'center'

                     //},
                     //{
                     //    field: 'UCA_XF',
                     //    title: '消防供水<br/>电源柜CA线电压',
                     //    align: 'center'

                     //},
                     //{
                     //    field: 'IA_XF',
                     //    title: '消防供水<br/>电源柜A相电流',
                     //    align: 'center'

                     //},
                     //{
                     //    field: 'IB_XF',
                     //    title: '消防供水<br/>电源柜B相电流',
                     //    align: 'center'

                     //},
                     //{
                     //    field: 'IC_XF',
                     //    title: '消防供水<br/>电源柜C相电流',
                     //    align: 'center'

                     //},
                     // {
                     //     field: 'KWH_XF',
                     //     title: '消防供水<br/>电源柜有功电能',
                     //     align: 'center'

                     // },
                     //  {
                     //      field: 'KVARH_XF',
                     //      title: '消防供水<br/>电源柜无功电能',
                     //      align: 'center'

                     //  },
                     //   {
                     //       field: 'PF_XF',
                     //       title: '消防供水<br/>电源柜功率因素',
                     //       align: 'center'

                     //   },
                     //    {
                     //        field: 'L_XFSX',
                     //        title: '消防供水<br/>消防水箱液位',
                     //        align: 'center'

                     //    },
                     //     {
                     //         field: 'P_XF1',
                     //         title: '消防供水<br/>喷淋1#供水压力',
                     //         align: 'center'

                     //     },
                     //      {
                     //          field: 'P_PL1',
                     //          title: '消防供水<br/>喷淋1#供水压力',
                     //          align: 'center'

                     //      },
                     //       {
                     //           field: 'P_XF2',
                     //           title: '消防供水<br/>消防2#供水压力',
                     //           align: 'center'

                     //       },
                     //       {
                     //           field: 'P_PL2',
                     //           title: '消防供水<br/>喷淋2#供水压力',
                     //           align: 'center'
                     //       },
                ]
            });
        }

        //初始化配电室记录统计
        function initSwitchroom_rdTable() {
            //先销毁表格   
            $('#tb_DataList').bootstrapTable('destroy');
            //清空 最大值 最小值 差值 平均值
            $('#spMax').empty();
            $('#spMin').empty();
            $('#spavg').empty();
            $('#spDiff').empty();
            //初始化表格,动态从服务器加载数据  
            $("#tb_DataList").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/DataListHandler.ashx?action=getdevswitch&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 195,
                //toolbar: '#toolbar', //工具按钮用哪个容器
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
                onClickCell: function (field, value, row) {
                    var columnName = field;
                    if (columnName != "num" && columnName != "InsertTime") {
                        $.getJSON("../Handler/DataListHandler.ashx?action=getdanalysis&columnname=" + columnName + "&tablename=switchroom_rd&r=" + Math.random(), null, function (res) {
                            $('#spMax').html(res.rows[0].Max);
                            $('#spMin').html(res.rows[0].Min);
                            $('#spavg').html(res.rows[0].Avg);
                            $('#spDiff').html(res.rows[0].Difference);
                        });
                    }
                    else {
                        alert("请选择数据列");
                    }
                },
                queryParamsType: "undefined",
                queryParams: function queryParams(params) {   //设置查询参数  
                    var param = {
                        pageNumber: params.pageNumber,
                        pageSize: params.pageSize,
                        devID: $('#devRoom').val(),
                        //timeSpan: $('#reservation').val(),
                        begindate: $('#input_begindate').val(),
                        enddate: $('#input_enddate').val()
                    };
                    return param;
                },
                columns: [{
                    field: 'num',
                    title: '序号',
                    align: 'center',
                    formatter: function (value, row, index) {
                        return index + 1;
                    }
                },
                {
                    field: 'InsertTime',
                    title: '时间（年-月-日 H-M-S)',
                    align: 'center',
                    width: 100
                },
                {
                    field: 'T_ROOM',
                    title: '设备房-环境温度',
                    align: 'center',
                },
                 {
                     field: 'H_ROOM',
                     title: '设备房-环境湿度',
                     align: 'center',
                 },
                {
                    field: 'N1_T_A',
                    title: '变压器A相温度',
                    align: 'center',
                    clickToSelect: false
                },
                {
                    field: 'N1_T_B',
                    title: '变压器B相温度',
                    align: 'center'
                },
                {
                    field: 'N1_T_C',
                    title: '变压器C相温度',
                    align: 'center'

                },
                {
                    field: 'N1_UAB',
                    title: '进线柜AB线电压',
                    align: 'center'

                },
                {
                    field: 'N1_UBC',
                    title: '进线柜BC线电压',
                    align: 'center'

                },
                {
                    field: 'N1_UCA',
                    title: '进线柜CA线电压',
                    align: 'center'

                },
                {
                    field: 'N1_IA',
                    title: '进线柜A相电流',
                    align: 'center'

                },
                {
                    field: 'N1_IB',
                    title: '进线柜B相电流',
                    align: 'center'

                },
                 {
                     field: 'N1_IC',
                     title: '进线柜C相电流',
                     align: 'center'

                 },
                  {
                      field: 'N1_PF',
                      title: '进线柜功率因素',
                      align: 'center'

                  },
                   {
                       field: 'N1_KWH',
                       title: '进线柜有功电能',
                       align: 'center'

                   },
                    {
                        field: 'N1_KVARH',
                        title: '进线柜无功电能',
                        align: 'center'

                    },
                     {
                         field: 'N2_T_A',
                         title: '变压器A相温度',
                         align: 'center'

                     },
                    {
                        field: 'N2_T_B',
                        title: '变压器B相温度',
                        align: 'center'

                    },
                    {
                        field: 'N2_T_C',
                        title: '变压器C相温度',
                        align: 'center'

                    },
                     {
                         field: 'N2_UAB',
                         title: '进线柜AB线电压',
                         align: 'center'

                     },
                     {
                         field: 'N2_UBC',
                         title: '进线柜BC线电压',
                         align: 'center'

                     },
                     {
                         field: 'N2_UCA',
                         title: '进线柜CA线电压',
                         align: 'center'

                     },
                     {
                         field: 'N2_IA',
                         title: '进线柜A相电流',
                         align: 'center'

                     },
                     {
                         field: 'N2_IB',
                         title: '进线柜B相电流',
                         align: 'center'

                     },
                     {
                         field: 'N2_IC',
                         title: '进线柜C相电流',
                         align: 'center'

                     },
                    {
                        field: 'N2_PF',
                        title: '进线柜功率因素',
                        align: 'center'

                    },
                    {
                        field: 'N2_KWH',
                        title: '进线柜有功电能',
                        align: 'center'

                    },
                    {
                        field: 'N2_KVARH',
                        title: '进线柜无功电能',
                        align: 'center'

                    }]
            });
        }

        //初始化消防泵房记录统计
        function initFirePumphouse_rdTable() {
            //先销毁表格  
            $('#tb_DataList').bootstrapTable('destroy');
            //清空最大值 最小值 平均值  差值
            $('#spMax').empty();
            $('#spMin').empty();
            $('#spavg').empty();
            $('#spDiff').empty();
            //初始化表格,动态从服务器加载数据  
            $("#tb_DataList").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/DataListHandler.ashx?action=GetDeviceFirePump&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 195,
                //toolbar: '#toolbar',//工具按钮用哪个容器
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
                onClickCell: function (field, value, row) {
                    var columnName = field;
                    if (columnName != "num" && columnName != "InsertTime") {
                        $.getJSON("../Handler/DataListHandler.ashx?action=getdanalysis&columnname=" + columnName + "&tablename=pumphouse_rd&r=" + Math.random(), null, function (res) {
                            $('#spMax').html(res.rows[0].Max);
                            $('#spMin').html(res.rows[0].Min);
                            $('#spavg').html(res.rows[0].Avg);
                            $('#spDiff').html(res.rows[0].Difference);
                        });
                    }
                    else {
                        alert("请选择数据列");
                    }
                },
                queryParamsType: "undefined",
                queryParams: function queryParams(params) {   //设置查询参数  
                    var param = {
                        pageNumber: params.pageNumber,
                        pageSize: params.pageSize,
                        devid: $('#devRoom').val(),
                        //  timeSpan: $('#reservation').val(),
                        begindate: $('#input_begindate').val(),
                        enddate: $('#input_enddate').val()
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
                    field: 'InsertTime',
                    title: '时间（年-月-日 H-M-S)',
                    align: 'center',
                },
                {
                    field: 'T_ROOM',
                    title: '设备房<br/>环境温度',
                    align: 'center',

                },
                 {
                     field: 'H_ROOM',
                     title: '设备房<br/>环境湿度',
                     align: 'center',
                 },
                {
                    field: 'UAB_XF',
                    title: '消防供水<br/>电源柜AB线电压',
                    align: 'center'

                },
                {
                    field: 'UBC_XF',
                    title: '消防供水<br/>电源柜BC线电压',
                    align: 'center'

                },
                {
                    field: 'UCA_XF',
                    title: '消防供水<br/>电源柜CA线电压',
                    align: 'center'

                },
                {
                    field: 'IA_XF',
                    title: '消防供水<br/>电源柜A相电流',
                    align: 'center'

                },
                {
                    field: 'IB_XF',
                    title: '消防供水<br/>电源柜B相电流',
                    align: 'center'

                },
                {
                    field: 'IC_XF',
                    title: '消防供水<br/>电源柜C相电流',
                    align: 'center'

                },
                {
                    field: 'KWH_XF',
                    title: '消防供水<br/>电源柜有功电能',
                    align: 'center'

                },
                {
                    field: 'KVARH_XF',
                    title: '消防供水<br/>电源柜无功电能',
                    align: 'center'

                },
                {
                    field: 'PF_XF',
                    title: '消防供水<br/>电源柜功率因素',
                    align: 'center'

                },
                    {
                        field: 'L_XFSX',
                        title: '消防供水<br/>消防水箱液位',
                        align: 'center'

                    },
                    {
                        field: 'P_XF1',
                        title: '消防供水<br/>喷淋1#供水压力',
                        align: 'center'

                    },
                    {
                        field: 'P_PL1',
                        title: '消防供水<br/>喷淋1#供水压力',
                        align: 'center'

                    },
                    {
                        field: 'P_XF2',
                        title: '消防供水<br/>消防2#供水压力',
                        align: 'center'

                    },
                    {
                        field: 'P_PL2',
                        title: '消防供水<br/>喷淋2#供水压力',
                        align: 'center'
                    },
                ]
            });
        }

    </script>
</asp:Content>
