<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="EquipmentManager.aspx.cs" Inherits="IERM.Views.EquipmentManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>设备档案管理</title>
    <link href="../css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
    <link href="../css/datetimepicker/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="../css/webuploader.css" rel="stylesheet" />
    <link href="../css/jquery-confirm.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class='container-fluid'>
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group" >
                            <span class="input-group-addon">物业公司：</span>
                            <select id="property" class="form-control" style="width: 150px; margin-right: 20px;">
                                <option value="0">未选择</option>
                                <%foreach (System.Data.DataRow item in propertyList.Rows)
                                    { %>
                                <option value="<%=Convert.ToInt32(item["propertyID"])%>"><%=item["propertyName"].ToString() %></option>
                                <%} %>
                            </select>
                        </div>
                        <div class="input-group" >
                            <span class="input-group-addon">项目选择：</span>
                            <select id="test" style="width: 250px; margin-right: 20px;">
                            </select>
                        </div>
                        <div class="input-group" >
                            <span class="input-group-addon">选择设备房：</span>
                            <select class="form-control" id="devhouse">
                            </select>
                        </div>
                        <button id="serach" type="button" class="btn btn-info input-group" style="margin-right: 68px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>

            <div class="panel-body" style="min-height: 580px;">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <ul id="breadcrumb">
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                        </ul>
                    </div>
                    <div class="panel-body">
                        <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                            <strong>操作提示</strong> <small></small>
                        </div>
                        <div id="toolbar" class="btn-group">
                            <button id="btn_add" type="button" data-toggle="modal" data-target="#myModal" class="btn btn-success">
                                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>新增
                            </button>
                        </div>
                        <table id="tb_equ"></table>
                    </div>
                </div>

                <!--增加设备 start-->
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-lg modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="myModalLabel">设备档案管理</h4>
                            </div>
                            <div class="modal-body">
                                <form id="equform" class="form-horizontal" role="form">
                                    <input type="hidden" id="equid" name="eID" />
                                    <table class="table table-hover table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <td colspan="4">
                                                    <h4 class="text-center">设备档案</h4>
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td rowspan="4">
                                                    <img src="../img/logo.png" />
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="equName" class="col-sm-5 control-label">设备名称：</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control" id="equName" name="equName" placeholder="设备名称">
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="equCode" class="col-sm-5 control-label">设备编码：</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control" id="equCode" name="equCode" placeholder="设备编码">
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="equNum" class="col-sm-5 control-label">设备型号：</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control" id="equNum" name="equNum" placeholder="设备型号">
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="typeName" class="col-sm-5 control-label">所属系统：</label>
                                                        <div class="col-sm-7">
                                                            <select id="sysTypeID" name="sysTypeID" class="form-control">
                                                                <%foreach (var item in systemList)
                                                                    { %>
                                                                <option value="<%=item.tID %>"><%=item.typeName %></option>
                                                                <%} %>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="provinceID" class="col-sm-5 control-label">省份：</label>
                                                        <div class="col-sm-7">
                                                            <select id="provinceID" name="provinceID" class="form-control"></select>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="cityID" class="col-sm-5 control-label">城市：</label>
                                                        <div class="col-sm-7">
                                                            <select id="cityID" name="cityID" class="form-control"></select>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="propertyName" class="col-sm-5 control-label">物业公司：</label>
                                                        <div class="col-sm-7">
                                                            <select id="propertyID" name="propertyID" class="form-control">
                                                                <option value="0">无</option>
                                                                <%foreach (System.Data.DataRow item in propertyList.Rows)
                                                                    { %>
                                                                <option value="<%=Convert.ToInt32(item["propertyID"])%>"><%=item["propertyName"].ToString() %></option>
                                                                <%} %>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="communityID" class="col-sm-5 control-label">项目名称：</label>
                                                        <div class="col-sm-7">
                                                            <select id="communityID" name="communityID" class="form-control"></select>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="devhouseID" class="col-sm-5 control-label">安装地点：</label>
                                                        <div class="col-sm-7">
                                                            <select id="devhouseID" name="devhouseID" class="form-control"></select>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="setupDate" class="col-sm-5 control-label">安装日期：</label>
                                                        <div class="col-sm-7">
                                                            <input size="16" id="setupDate" name="setupDate" type="text" readonly class="form_datetime form-control">
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="startupDate" class="col-sm-5 control-label">投入日期：</label>
                                                        <div class="col-sm-7">
                                                            <input size="16" id="startupDate" name="startupDate" type="text" readonly class="form_datetime form-control">
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="agelimit" class="col-sm-5 control-label">使用年限：</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control" id="agelimit" name="agelimit" placeholder="使用年限">
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="mpName" class="col-sm-5 control-label">维护人：</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control" id="mpName" name="mpName" placeholder="维护人">
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="mPhoneNum" class="col-sm-5 control-label">维护电话：</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control" id="mPhoneNum" name="mPhoneNum" placeholder="维护电话">
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <div class="form-group">
                                                        <label for="mDepartment" class="col-sm-2 control-label">设备类型：</label>
                                                        <div class="col-sm-10">
                                                            <select id="device_type_code" name="device_type_code" class="form-control">
                                                                <%foreach (System.Data.DataRow item in devicetypelist.Rows)
                                                                    { %>
                                                                <option value="<%=item["device_type_code"]%>"><%=item["devide_type_name"].ToString() %></option>
                                                                <%} %>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <div class="form-group">
                                                        <label for="mDepartment" class="col-sm-2 control-label">维保部门：</label>
                                                        <div class="col-sm-10">
                                                            <input type="email" class="form-control" id="mDepartment" name="mDepartment" placeholder="维保部门">
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <div class="form-group">
                                                        <label for="manufacturer" class="col-sm-2 control-label">生产厂家：</label>
                                                        <div class="col-sm-10">
                                                            <input type="email" class="form-control" id="manufacturer" name="manufacturer" placeholder="生产厂家">
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <div class="form-group">
                                                        <label for="supplier" class="col-sm-2 control-label">供应商：</label>
                                                        <div class="col-sm-10">
                                                            <input type="email" class="form-control" id="supplier" name="supplier" placeholder="供应商">
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <div class="form-group">
                                                        <label for="supplierContact" class="col-sm-2 control-label">供应商联系人：</label>
                                                        <div class="col-sm-10">
                                                            <input type="email" class="form-control" id="supplierContact" name="supplierContact" placeholder="供应商联系人">
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <div id="accdiv" class="btn-group" style="margin-bottom: 10px;">
                                                        <button id="btn_acc_add" type="button" data-toggle="modal" data-target="#accModal" class="btn btn-success">
                                                            <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>添加附属设备
                                                        </button>
                                                    </div>
                                                    <table class="table table-hover table-bordered table-striped">
                                                        <thead>
                                                            <tr>
                                                                <td>序号</td>
                                                                <td>设备名称</td>
                                                                <td>设备型号</td>
                                                                <td>技术参数</td>
                                                                <td>其他信息</td>
                                                                <td>操作</td>
                                                            </tr>
                                                        </thead>
                                                        <tbody id="queacc">
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </form>
                            </div>
                            <div class="modal-footer">
                                <button id="rrsubmit" type="button" class="btn btn-success">提交</button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--增加设备 end-->

                <!--附属设备 start-->
                <div class="modal fade" id="accModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">添加附属设备</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="accName">设备名称</label>
                                    <input type="text" class="form-control" id="accName" placeholder="设备名称">
                                </div>
                                <div class="form-group">
                                    <label for="accNo">设备型号</label>
                                    <input type="text" class="form-control" id="accNo" placeholder="设备型号">
                                </div>
                                <div class="form-group">
                                    <label for="accParameter">技术参数</label>
                                    <input type="text" class="form-control" id="accParameter" placeholder="技术参数">
                                </div>
                                <div class="form-group">
                                    <label for="other">其他信息</label>
                                    <input type="text" class="form-control" id="other" placeholder="其他信息">
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" id="btnacc">保存</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--附属设备 end-->
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../js/select2andtree/select2.min.js"></script>
    <script src="../js/select2andtree/i18n/zh-CN.js"></script>
    <script src="../js/select2andtree/select2tree.js"></script>
    <script src="../js/webuploader.min.js"></script>
    <script src="../js/datetimepicker/bootstrap-datetimepicker.js"></script>
    <script src="../js/datetimepicker/bootstrap-datetimepicker.zh-CN.js"></script>
    <script src="../js/MyExt.js"></script>
    <script src="../js/jquery-confirm.min.js"></script>
    <script type="text/javascript">
        var accdata = [];
        $(function () {
            initSelectTree($('#property').val());
            initProvinceList();
            $("#test").change(function () {
                initDevHouse();
            });
            //物业公司改变
            $("#property").change(function () {
                initSelectTree($('#property').val());
            });

            $("#serach").click(function () {
                initTable($('#devhouse option:selected').val());
            });

            $('.form_datetime').datetimepicker({
                //startDate: new Date().toLocaleDateString(),
                language: 'zh-CN',
                format: 'yyyy-mm-dd',
                weekStart: 1,
                todayBtn: 1,
                clearBtn: true,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                minView: 2,
                forceParse: true,
            });

            //保存附属设备
            $("#btnacc").click(function () {
                $('#accModal').modal('hide');

                var item = {};
                item.equID = $('#equid').val();
                item.accName = $("#accName").val();
                item.accNo = $("#accNo").val();
                item.accParameter = $("#accParameter").val();
                item.other = $("#other").val();
                accdata.push(item);

                $('#queacc').append("<tr><td>...</td><td>" + $("#accName").val() + "</td><td>" + $("#accNo").val() + "</td><td>" + $("#accParameter").val() + "</td><td>" + $("#other").val() + "</td><td>...</td></tr>");

            });

            //新增设备按钮设备
            $("#btn_add").click(function () {
                accdata = [];
                $("#equid").val(0);
                $('#equform')[0].reset();
                $('#queacc').empty();
            });

            //新增附件按钮
            $("#btn_acc_add").click(function () {
                $("#accName").val("");
                $("#accNo").val("");
                $("#accParameter").val("");
                $("#other").val("");
            });

            //新增，修改设备信息
            $("#rrsubmit").click(function () {
                $('#myModal').modal('hide');
                var formdata = str2Json($("#equform").serialize());
                if ($("#equid").val() == 0) {
                    $.post("../Handler/EquipmentHandler.ashx?action=insertequipment", { "equdata": JSON.stringify(formdata), "accdata": JSON.stringify(accdata) }, function (res) {
                        $('#alertMsg small').html(res.Msg);
                        if (res.IsSucceed) {
                            $('#alertMsg').show();
                            initTable($('#devhouse option:selected').val());
                        }
                    }, "json");
                }
                else {
                    $.post("../Handler/EquipmentHandler.ashx?action=updateequipment", { "equdata": JSON.stringify(formdata), "accdata": JSON.stringify(accdata) }, function (res) {
                        $('#alertMsg small').html(res.Msg);
                        if (res.IsSucceed) {
                            $('#alertMsg').show();
                            initTable($('#devhouse option:selected').val());
                        }
                    }, "json");
                }

                setTimeout(function () { $('#alertMsg').hide(); }, 3000);
            });

            //切换小区载入不同设备房
            $('#communityID').change(function () {
                initDevHouseList($('#communityID').val());
            });
            //切换不同城市载入不同小区
            $('#cityID').change(function () {
                initCommunityList($('#cityID').val());
            });
            //切换不同省份载入不同城市
            $('#provinceID').change(function () {
                initCityList($('#provinceID').val());
            });
        });

        function str2Json(str) {
            str = str.replace(/&/g, "','");
            str = str.replace(/=/g, "':'");
            str = "({'" + str + "'})";
            obj = eval(str);
            return obj;
        }

        //初始化省市小区数列表
        function initSelectTree(pid) {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcpoe&r=" + Math.random(), { "propertyID": pid }, function (res) {
                if (res.IsSucceed) {
                    $("#test").append(res.Data).select2tree();
                    initDevHouse();
                }
            });
        }

        //获取设备房列表
        function initDevHouse() {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getdevbycid&r=" + Math.random(), {
                "pageNumber": 1,
                "pageSize": 20,
                "communityID": $('#test option:selected').data("value")
            }, function (res) {
                $("#devhouse").empty();
                if (res.total > 0) {
                    $.each(res.rows, function (key, value) {
                        if (key == 0) {
                            $("#devhouse").append("<option selected value='" + this.devID + "'>" + this.devName + "</option>");
                        }
                        else {
                            $("#devhouse").append("<option value='" + this.devID + "'>" + this.devName + "</option>");
                        }
                    });
                } else { $("#devhouse").append("<option value='0'>未设置</option>"); }

                $('#breadcrumb a:eq(4)').text($("#devhouse :selected").text());
                var community = $('#test option:selected');
                $('#breadcrumb a:eq(3)').text(community.text());
                var city = $("#test option[data-level=2][value='" + community.attr("parent") + "']");
                $('#breadcrumb a:eq(2)').text(city.text());
                var province = $("#test option[data-level=1][value='" + city.attr("parent") + "']");
                $('#breadcrumb a:eq(1)').text(province.text());


            });
        }

        //初始化设备表
        function initTable(houseid) {
            //先销毁表格  
            $('#tb_equ').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_equ").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/EquipmentHandler.ashx?action=getequinfobyhouseid&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 175,
                toolbar: '#toolbar',                //工具按钮用哪个容器
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
                        houseID: houseid,
                    };
                    return param;
                },
                rowStyle: function (row, index) {
                    var strclass = "";
                    switch (row.typeName) {
                        case "变配电":
                            //strclass = 'warning';
                            strclass = 'text-warning';
                            break;
                        case "给排水":
                            strclass = 'text-success';
                            //strclass = 'success';
                            break;
                        default:
                            strclass = 'text-danger';
                            //strclass = 'danger';
                            break;
                    }
                    return { classes: strclass }
                },
                columns: [{
                    field: 'eID',
                    title: '序号',
                    align: 'center'
                },
                {
                    field: 'equName',
                    title: '设备名称',
                    align: 'center'
                },
                {
                    field: 'equCode',
                    title: '设备编码',
                    align: 'center'
                },
                 {
                     field: 'typeName',
                     title: '所属系统',
                     align: 'center'
                 },
                {
                    field: 'setupDate',
                    title: '安装日期',
                    align: 'center',
                    formatter: function (value, row, index) {
                        return value.replace(/(\d{4}).(\d{1,2}).(\d{1,2}).+/mg, '$1-$2-$3');
                    }
                },
                {
                    field: 'agelimit',
                    title: '年限',
                    align: 'center'
                },
                {
                    field: 'mDepartment',
                    title: '维护部门',
                    align: 'center'
                },
                {
                    field: 'mpName',
                    title: '维护人',
                    align: 'center'
                },
                {
                    field: 'mPhoneNum',
                    title: '维保电话',
                    align: 'center'
                },
                {
                    title: '操作',
                    formatter: function (value, row, index) {
                        var e = '<a data-toggle="modal" href="javascript:void(0);"  data-target="#myModal" style="margin-right:18px;" onclick="edit(this)"><span class="glyphicon glyphicon-edit"></span> 编辑</a> ';
                        var d = '<a href="javascript:void(0)" onclick="del(this)"><span class="glyphicon glyphicon-trash"></span> 删除</a> ';
                        return e + d;
                    }
                }]
            });
        }


        //编辑设备
        function edit(obj) {
            accdata = [];
            var thisrow = $(obj).parent().parent();
            var equid = thisrow.find("td:eq(0)").text();
            $("#equid").val(equid);
            $.getJSON("../Handler/EquipmentHandler.ashx?action=getequinfo&equID=" + equid + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $("#equform").LoadDataToForm(res.Data);
                    $("#setupDate").val($("#setupDate").val().replace(/(\d{4}).(\d{1,2}).(\d{1,2}).+/mg, '$1-$2-$3'));
                    $("#startupDate").val($("#startupDate").val().replace(/(\d{4}).(\d{1,2}).(\d{1,2}).+/mg, '$1-$2-$3'));

                    LoadequAcc(equid);
                }
            });
        }

        //删除设备
        function del(obj) {
            var thisrow = $(obj).parent().parent();
            var equid = thisrow.find("td:eq(0)").text();
            var equname = thisrow.find("td:eq(1)").text();
            $.confirm({
                title: '警告',
                content: "您确定要删除<font color='red'>[" + equname + "]</font>吗？",
                buttons: {
                    ok: {
                        text: "确定",
                        btnClass: 'btn-primary',
                        keys: ['enter'],
                        action: function () {
                            $.post("../Handler/EquipmentHandler.ashx?action=deleteequipment", { "equid": equid }, function (res) {
                                if (res.IsSucceed) {
                                    thisrow.remove();
                                }
                                else {
                                    $.alert({
                                        title: '删除失败<hr/>',
                                        content: '操作出现异常！请稍候再试！',
                                    });
                                }
                            }, "json");

                        }
                    },
                    cancel: {
                        text: "取消",
                        btnClass: 'btn-default',
                        keys: ['Esc']
                    }
                }
            });
        }

        //加载省份信息
        function initProvinceList() {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getprovinces&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#provinceID').empty();
                    $.each(res.Data, function () {
                        $('#provinceID').append("<option value='" + this.areaID + "'>" + this.areaName + "</option>")
                    });

                    initCityList($('#provinceID').val());
                }
            });
        }

        //加载城市信息
        function initCityList(pid) {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcitys&pid=" + pid + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#cityID option').remove();
                    $.each(res.Data, function () {
                        $('#cityID').append("<option value='" + this.areaID + "'>" + this.areaName + "</option>")
                    });
                    initCommunityList($('#cityID').val());
                }
            });
        };

        ///加载对应小区列表
        function initCommunityList(pid) {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcommunity&cid=" + pid + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#communityID').empty();
                    $.each(res.Data, function () {
                        $('#communityID').append("<option value='" + this.communityID + "'>" + this.communityName + "</option>")
                    });

                    initDevHouseList($('#communityID').val());
                }
            });
        }

        ///加载对应小区设备房列表
        function initDevHouseList(pid) {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getdevbycid&communityID=" + pid + "&r=" + Math.random(), null, function (res) {
                if (res.total > 0) {
                    $('#devhouseID').empty();
                    $.each(res.rows, function () {
                        $('#devhouseID').append("<option value='" + this.devID + "'>" + this.devName + "</option>")
                    });
                }
            });
        }

        ///加载设备附件列表
        function LoadequAcc(pid) {
            $.getJSON("../Handler/EquipmentHandler.ashx?action=getequaccinfolist&equID=" + pid + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed > 0) {
                    $('#queacc').empty();
                    $.each(res.Data, function () {
                        $('#queacc').append("<tr><td>" + this.aID + "</td><td>" + this.accName + "</td><td>" + this.accNo + "</td><td>" + this.accParameter + "</td><td>" + this.other + "</td><td><a href='javascript:void(0)' onclick='accdel(this)'><span class='glyphicon glyphicon-trash'></span> 删除</a> </td></tr>")
                    });
                }
            });
        }

        ///删除设备附件
        function accdel(obj) {
            var thisrow = $(obj).parent().parent();
            var accid = thisrow.find("td:eq(0)").text();
            var accname = thisrow.find("td:eq(1)").text();

            $.confirm({
                title: '警告',
                content: "您确定要删除<font color='red'>[" + accname + "]</font>吗？",
                buttons: {
                    ok: {
                        text: "确定",
                        btnClass: 'btn-primary',
                        keys: ['enter'],
                        action: function () {
                            $.post("../Handler/EquipmentHandler.ashx?action=deleteequacc", { "accid": accid }, function (res) {
                                if (res.IsSucceed) {
                                    thisrow.remove();
                                }
                                else {
                                    $.alert({
                                        title: '删除失败<hr/>',
                                        content: '操作出现异常！请稍候再试！',
                                    });
                                }
                            }, "json");

                        }
                    },
                    cancel: {
                        text: "取消",
                        btnClass: 'btn-default',
                        keys: ['Esc']
                    }
                }
            });
        }

    </script>
</asp:Content>
