<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="Menulist.aspx.cs" Inherits="IERM.Views.Menulist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>菜单管理</title>
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
                        <li><a href="javascript:void(0)">系统管理</a></li>
                        <li><a href="javascript:void(0)">菜单管理</a></li>
                    </ul>
                </div>
                <button id="serach" type="button" class="btn btn-info" style="margin-left: 20px;" data-toggle="modal" data-target="#myModal_add">增加菜单</button>
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
                    <h4 class="modal-title" id="myModalLabel_add">增加菜单信息</h4>
                </div>
                <div class="modal-body">
                    <section id="wizard_add">
                        <div id="rootwizard_add">
                            <div id="navbar_add" class="navbar">
                                <div class="navbar-inner">
                                    <div class="container">
                                        <ul>
                                            <li style="list-style-type: none;">父级菜单: 
                                                <select id="menu">
                                                </select>
                                            </li>
                                            <li style="list-style-type: none;">菜单名称: 
                                                <input type="text" id="menuname_add" /></li>
                                            <li style="list-style-type: none;">图标地址: 
                                                <input type="text" id="menuico_add" /></li>
                                            <li style="list-style-type: none;">链接地址: 
                                                <input type="text" id="menuurl_add" style="width: 30%" /></li>
                                            <li style="list-style-type: none;">菜单排序: 
                                                <input type="text" id="msort_add" /></li>
                                            <li style="list-style-type: none;">
                                                <button id="addmenu_add" type="button" class="btn btn-info input-group" style="margin-right: 68px;" onclick="add()">确定添加</button>
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
                                                <label id="mid"></label>
                                            </li>
                                            <li style="list-style-type: none;">菜单名称: 
                                                <input type="text" id="menuname" /></li>
                                            <li style="list-style-type: none;">图标地址: 
                                                <input type="text" id="menuico" /></li>
                                            <li style="list-style-type: none;">链接地址: 
                                                <input type="text" id="menuurl" style="width: 30%" /></li>
                                            <li style="list-style-type: none;">菜单排序: 
                                                <input type="text" id="msort" /></li>
                                            <li style="list-style-type: none;">
                                                <button id="addmenu" type="button" class="btn btn-info input-group" style="margin-right: 68px;" onclick="update()"><span class="glyphicon glyphicon-search"></span>确定</button>

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
                url: "../../Handler/systemmenu.ashx?action=menulist&r=" + Math.random(), //获取数据的Servlet地址  
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
                        field: 'mid',
                        title: '序号',
                        align: 'center'
                        //formatter: function (value, row, index) {
                        //    return index + 1;
                        //}
                    },
                    {
                        field: 'menuName',
                        title: '菜单名',
                        align: 'center'
                    },
                    {
                        field: 'menuUrl',
                        title: '地址',
                        align: 'center'
                    },
                    {
                        field: 'mSort',
                        title: '排序',
                        align: 'center'
                    },
                    {
                        field: 'mPID',
                        title: '父ID',
                        align: 'center'
                    },
                    {
                        field: 'menuIco',
                        title: '菜单图片',
                        align: 'center'
                    },
                     {
                         title: '操作',
                         formatter: function (value, row, index) {
                             var e = '<a data-toggle="modal" href="javascript:void(0)"  data-target="#myModal" style="margin-right:10px;" onclick="edit(this,\'' + row.mid + '\',\'' + row.menuName + '\',\'' + row.menuUrl + '\',\'' + row.menuIco + '\',\'' + row.mSort + '\')"><span class="glyphicon glyphicon-edit"></span>编辑</a> ';
                             var d = '<a href="javascript:void(0)" onclick="del(\'' + row.mid + '\',\'' + row.menuName + '\')"> <span class="glyphicon glyphicon-trash"></span>删除</a> ';
                             return e + d;
                         }
                     }
                ]
            });
        }

        //删除菜单
        function del(mid, menuName) {
            $.confirm({
                title: '警告',
                content: "<div style='font-size:24px;'>您确定要删除<font color='red'>[" + menuName + "]</font>吗？</div>",
                buttons: {
                    ok: {
                        text: "确定",
                        btnClass: 'btn-primary',
                        keys: ['enter'],
                        action: function () {
                            $.post("../../Handler/systemmenu.ashx", { "action": "deletemenu", "mid": mid }, function (res) {
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

        //编辑菜单
        function edit(obj, mid, menuName, menuUrl, menuIco, mSort) {
            $('#mid').html(mid);
            $('#menuname').val(menuName);
            $('#menuico').val(menuIco);
            $('#menuurl').val(menuUrl);
            $('#msort').val(mSort);
        }

        //编辑菜单
        function update() {
            if (vail_update() == true) {
                var mid = $('#mid').html();
                var menuname = $('#menuname').val();
                var menuico = $('#menuico').val();
                var menuurl = $('#menuurl').val();
                var msort = $('#msort').val();
                //新增操作
                $.post("../../Handler/systemmenu.ashx", { "action": "updatemenu", "mid": mid, "menuname": menuname, "menuico": menuico, "menuurl": menuurl, "msort": msort }, function (res) {
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

        //增加菜单
        function add() {
            if (vail_add() == true) {
                var mpid = $('#menu').val();
                var menuname = $('#menuname_add').val();
                var menuico = $('#menuico_add').val();
                var menuurl = $('#menuurl_add').val();
                var msort = $('#msort_add').val();
                //新增操作
                $.post("../../Handler/systemmenu.ashx", { "action": "addmenu", "mpid": mpid, "menuname": menuname, "menuico": menuico, "menuurl": menuurl, "msort": msort }, function (res) {
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

        //加载增加中的菜单下拉框
        function inimenu() {
            $.getJSON("../../Handler/systemmenu.ashx?action=getmenu&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#menu option').remove();
                    $('#menu').append("<option value='0'>--请选择--</option>")
                    $.map(res.Data, function (item) {
                        $('#menu').append("<option value='" + item.mid + "'>" + item.menuName + "</option>")
                    });
                }
            });
        };


        //验证开始
        function vail_add() {
            if ($("#menuname_add").val() == "") {
                alert("菜单名必填！");
                return false;
            }
            return true;
        }
        function vail_update() {
            if ($("#menuname").val() == "") {
                alert("菜单名必填！");
                return false;
            }
            return true;
        }
        //验证结束
    </script>

</asp:Content>
