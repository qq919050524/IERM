<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="DeviceType.aspx.cs" Inherits="IERM.Views.DeviceType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>设备类型管理</title>
    <link href="../../css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="../../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
    <link href="../../css/jquery-confirm.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="form-inline">
                <div class="panel-heading">
                    <ul id="breadcrumb">
                        <li><a href="javascript:void(0)">设备管理</a></li>
                        <li><a href="javascript:void(0)">设备类型管理</a></li>
                    </ul>
                </div>
                <button id="serach" type="button" class="btn btn-info" style="margin-left: 20px;" data-toggle="modal" data-target="#myModal_add">增加类型</button>
            </div>
        </div>
        <div class="panel-body">
            <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                <strong>操作提示</strong> <small></small>
            </div>
            <table id="tb_alarm"></table>
        </div>
    </div>

    <!--增加菜单 start-->
    <div class="modal fade" id="myModal_add" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel_add">增加类型信息</h4>
                </div>
                <div class="modal-body">
                    <section id="wizard_add">
                        <div id="rootwizard_add">
                            <div id="navbar_add" class="navbar">
                                <div class="navbar-inner">
                                    <div class="container">
                                        <ul>
                                            <li style="list-style-type: none;">类型编码: 
                                                <input type="text" id="devicecode_add" />
                                            </li>
                                            <li style="list-style-type: none;">类型名称: 
                                                <input type="text" id="devicename_add" /></li>
                                            <li style="list-style-type: none;">
                                                <button id="devicetype_add" type="button" class="btn btn-info input-group" style="margin-right: 68px;" onclick="add()">确定添加</button>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
    <!--增加菜单 end-->



    <!--编辑菜单 start-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">编辑菜单信息</h4>
                </div>
                <div class="modal-body">
                    <section id="wizard">
                        <div id="rootwizard">
                            <div id="navbar" class="navbar">
                                <div class="navbar-inner">
                                    <div class="container">
                                        <ul>
                                            <li style="list-style-type: none;">菜单ID  : 
                                                <label id="tid"></label>
                                            </li>
                                             <li style="list-style-type: none;">类型编码: 
                                                <input type="text" id="devicecode_edit" />
                                            </li>
                                            <li style="list-style-type: none;">类型名称: 
                                                <input type="text" id="devicename_edit" /></li>
                                            <li style="list-style-type: none;">
                                                <button id="devicetype_edit" type="button" class="btn btn-info input-group" style="margin-right: 68px;" onclick="update()"><span class="glyphicon glyphicon-search"></span>确定</button>

                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
    <!--编辑菜单 end-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../../js/table/bootstrap-table.min.js"></script>
    <script src="../../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../js/daterangepicker/moment.min.js"></script>
    <script src="../../js/daterangepicker/daterangepicker.js"></script>
    <script src="../../js/daterangepicker/DateFormat.js"></script>
    <script src="../../js/jquery-confirm.min.js"></script>
    <script type="text/javascript">
        $(function () {
            initTable();
            inimenu();
        });

        //初始化
        function initTable() {
            //先销毁表格  
            $('#tb_alarm').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_alarm").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../../Handler/DeviceHandler.ashx?action=getdevicetype&r=" + Math.random(), //获取数据的Servlet地址  
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
                        pageSize: params.pageSize
                    };
                    return param;
                },
                columns: [
                    //{
                    //    field: 'checkbox',
                    //    checkbox: true
                    //},
                    {
                        field: 'type_id',
                        title: '类型ID号',
                        align: 'center'
                        //formatter: function (value, row, index) {
                        //    return index + 1;
                        //}
                    },
                    {
                        field: 'device_type_code',
                        title: '类型编码',
                        align: 'center'
                    },
                    {
                        field: 'devide_type_name',
                        title: '类型名字',
                        align: 'center'
                    },
                     {
                         title: '操作',
                         formatter: function (value, row, index) {
                             var e = '<a data-toggle="modal" href="javascript:void(0)"  data-target="#myModal" style="margin-right:10px;" onclick="edit(this,\'' + row.type_id + '\',\'' + row.device_type_code + '\',\'' + row.devide_type_name + '\')"><span class="glyphicon glyphicon-edit"></span>编辑</a> ';
                             var d = '<a href="javascript:void(0)" onclick="del(\'' + row.type_id + '\')"> <span class="glyphicon glyphicon-trash"></span>删除</a> ';
                             return e + d;
                         }
                     }
                ]
            });
        }

        //删除设备类型
        function del(id) {
            $.confirm({
                title: '警告',
                content: "<div style='font-size:24px;'>您确定要删除吗？</div>",
                buttons: {
                    ok: {
                        text: "确定",
                        btnClass: 'btn-primary',
                        keys: ['enter'],
                        action: function () {
                            $.post("../../Handler/DeviceHandler.ashx", { "action": "deletedevicetype", "id": id }, function (res) {
                                $('#alertMsg small').html(res.Msg); $('#alertMsg').show();
                                if (res.IsSucceed) {
                                    initTable();
                                }
                                setTimeout(function () { $('#alertMsg').hide(); }, 3000);
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

        //编辑设备类型
        function edit(obj, sid, type, txt) {
            $('#tid').html(sid);
            $('#devicecode_edit').val(type);
            $('#devicename_edit').val(txt);
        }

        //编辑设备类型
        function update() {
            if (vail_update() == true) {
                var id = $('#tid').html();
                var code = $('#devicecode_edit').val();
                var name = $('#devicename_edit').val();
                //新增操作
                $.post("../../Handler/DeviceHandler.ashx", { "action": "updatedevicetype", "id": id, "code": code, "name": name }, function (res) {
                    if (res.IsSucceed) {
                        $('#myModal').modal("hide");
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();
                        initTable();
                    }
                    else {
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();
                    }
                    setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                }, "json");
            }
        }

        //增加设备类型
        function add() {
            if (vail_add() == true) {
                var code = $('#devicecode_add').val();
                var name = $('#devicename_add').val();
                //新增操作
                $.post("../../Handler/DeviceHandler.ashx", { "action": "adddevicetype", "code": code, "name": name }, function (res) {
                    if (res.IsSucceed) {
                        $('#myModal_add').modal("hide");
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();
                        initTable();
                    }
                    else {
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();
                    }
                    setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                }, "json");
            }
        }


        //验证开始
        function vail_add() {
            if ($("#devicecode_add").val() == "") {
                alert("类型编码必填！");
                return false;
                                                }
            if ($("#devicename_add").val() == "") {
                alert("类型名称必填！");
                return false;
            }
            return true;
        }
        function vail_update() {
            if ($("#devicecode_edit").val() == "") {
                alert("类型编码必填！");
                return false;
            }
            if ($("#devicename_edit").val() == "") {
                alert("类型名称必填！");
                return false;
            }
            return true;
        }
        //验证结束
    </script>

</asp:Content>
