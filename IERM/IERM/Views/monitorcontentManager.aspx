<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="monitorcontentManager.aspx.cs" Inherits="IERM.Views.monitorcontentManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>运行监控展示信息</title>
    <link href="../css/Wizard/prettify.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class='container-fluid'>
        <section id="contentlist">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="form-inline">
                        <div class="text-left">
                            <div class="input-group">
                                <button id="addcontent" type="button" class="btn btn-success" style="margin-left: 20px;" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-plus"></span>添加</button>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                            <strong>操作提示</strong> <small></small>
                        </div>
                        <table id="tb_content"></table>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">编辑行监控展示信息</h4>
                </div>
                <div class="modal-body">
                    <section id="wizard">
                        <div id="rootwizard">
                            <div class="navbar">
                                <div class="navbar-inner">
                                    <div class="container">
                                        <ul>
                                            <li><a href="#tab1" data-toggle="tab">基本信息</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <form id="contentform" class="form-horizontal" role="form">
                                <input type="hidden" id="hd_contentid" name="hd_contentid" />
                                <div class="tab-content">
                                    <div class="tab-pane" id="tab1">
                                        <table class="table table-bordered">
                                            <tr>
                                                <td class="col-md-8">
                                                    <div class="form-group">
                                                        <label for="selectdev" class="col-md-4 control-label">所属设备房:</label>
                                                        <div class="col-md-8">
                                                            <select class="form-control" id="selectdev" name="selectdev">
                                                                <%foreach (var item in lstdevinfo)
                                                                    { %>
                                                                <option value="<%=item.devID %>"><%=item.devName %></option>
                                                                <%} %>
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="selectsystype" class="col-md-4 control-label">系统类型:</label>
                                                        <div class="col-md-8">
                                                            <select class="form-control" id="selectsystype" name="selectsystype">
                                                                <%foreach (var item in lstsystype)
                                                                    { %>
                                                                <option value="<%=item.tID %>"><%=item.typeName %></option>
                                                                <%} %>
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="selectcode" class="col-md-4 control-label">内容编码:</label>
                                                        <div class="col-md-8">
                                                            <select class="form-control" id="selectcode" name="selectcode">
                                                                <%foreach (var item in lstcode)
                                                                    { %>
                                                                        <option value="<%=item.CodeName %>"><%=item.Code %></option>
                                                                <%} %>
                                                            </select>
                                                            <%--<input type="text" class="form-control" id="contentCode" name="contentCode" placeholder="该数据的内容编码">--%>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="contentName" class="col-md-4 control-label">内容名称</label>
                                                        <div class="col-md-8">
                                                            <input type="text" class="form-control" readonly="readonly" id="contentName" name="contentName" placeholder="该数据的内容名称">
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="col-md-1">
                                                    <span style="color: red">必填</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <ul class="pager wizard">
                                        <li class="finish"><a href="javascript:void();">保 存</a></li>
                                    </ul>
                                </div>
                                <div class="panel-body">
                                    <div id="alertMsgContent" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                                        <strong>操作提示</strong> <small></small>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../js/Wizard/jquery.bootstrap.wizard.min.js"></script>
    <script src="../js/Wizard/prettify.js"></script>
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../js/select2andtree/select2.min.js"></script>
    <script src="../js/select2andtree/i18n/zh-CN.js"></script>
    <script src="../js/select2andtree/select2tree.js"></script>
    <script src="../js/echarts.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#selectcode').change(function () {
                $('#contentName').val($('#selectcode').val());
            });

            $('#rootwizard').bootstrapWizard({
            });

            $('#rootwizard .finish').click(function () {
                //保存设置
                if ($('#hd_contentid').val() == "0") {
                    //新增操作  selectdev  selectsystype  selectcode  contentName
                    $.post("../Handler/MonitorContent.ashx", {"action": "getaddcontent",
                        "devid": $('#selectdev').val(),
                        "systype": $('#selectsystype').val(),
                        "code": $('#selectcode').find("option:selected").text(),
                        "codename":$('#selectcode').val()
                    }, function (res) {
                        if (res.IsSucceed) {
                            $('#alertMsgContent small').html('添加运行监控展示信息成功！');
                            $('#alertMsgContent').show();
                            initTable();
                            setTimeout(function () { $('#myModal').hide(); }, 3000);
                        }
                        else {
                            $('#alertMsgContent small').html('添加运行监控展示信息失败！');
                        }
                        setTimeout(function () { $('#alertMsgContent').hide(); }, 3000);

                    }, "json");
                }
                else {
                    //更新操作 getupdatecontent
                    $.post("../Handler/MonitorContent.ashx", {
                        "action": "getupdatecontent",
                        "contentid": $('#hd_contentid').val(),
                        "devid": $('#selectdev').val(),
                        "systype": $('#selectsystype').val(),
                        "code": $('#selectcode').find("option:selected").text(),
                        "codename": $('#selectcode').val()
                    }, function (res) {
                        if (res.IsSucceed) {
                            $('#alertMsgContent small').html('编辑运行监控展示信息成功！');
                            $('#alertMsgContent').show();
                            initTable();
                            setTimeout(function () { $('#myModal').hide(); }, 3000);
                        }
                        else {
                            $('#alertMsgContent small').html('编辑运行监控展示信息失败！');
                        }
                        setTimeout(function () { $('#alertMsgContent').hide(); }, 3000);

                    }, "json");
                }
            });
            initTable();
        });

        //添加用户按钮
        $('#addcontent').click(function () {
            //初始化向导
            $('#rootwizard').bootstrapWizard('show', 0);

            $('#hd_contentid').val("0");
            $('#contentName').val($('#selectcode').val());
        });

        //初始化用户表
        function initTable() {
            //先销毁表格  
            $('#tb_content').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_content").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/MonitorContent.ashx?action=getallcontent&r=" + Math.random(), //获取数据的Servlet地址  
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
                onLoadSuccess: function () {  //加载成功时执行  

                },
                onLoadError: function () {  //加载失败时执行  

                },
                columns: [
                    {
                        field: 'tID',
                        visible: false
                    }, {
                        field: 'num',
                        title: '序号',
                        align: 'center',
                        formatter: function (value, row, index) {
                            return index + 1;
                        }
                    },
                {
                    field: 'DevName',
                    title: '设备房',
                    align: 'center',
                    clickToSelect: false
                },
                {
                    field: 'TypeName',
                    title: '系统类型',
                    align: 'center'
                },
                {
                    field: 'ContentCode',
                    title: '内容编码',
                    align: 'center',
                },
                {
                    field: 'ContentName',
                    title: '内容名称',
                    align: 'center',
                },
                {
                    title: '操作',
                    formatter: function (value, row, index) {
                        var e = '<a data-toggle="modal" href="javascript:void(0)"  data-target="#myModal" style="margin-right:10px;" onclick="edit(\'' + row.TID + '\')">编辑</a> ';
                        var d = '<a href="javascript:void(0)" onclick="del(\'' + row.TID + '\')">删除</a> ';
                        return e + d;
                    }
                }]
            });
        }

        //删除用户
        function del(uid) {
            $.post("../Handler/MonitorContent.ashx", { "action": "getdelcontent", "tID": uid }, function (res) {
                if (res.IsSucceed) {
                    $('#alertMsg small').html('删除运行监控展示信息成功！');
                    $('#alertMsg').show();
                    initTable();
                }
                else {
                    $('#alertMsg small').html('删除运行监控展示信息失败！');
                }
                setTimeout(function () { $('#alertMsg').hide(); }, 3000);
            }, "json");
        }

        //编辑用户
        function edit(uid) {
            $('#hd_contentid').val(uid);
            //初始化向导
            $('#rootwizard').bootstrapWizard('show', 0);
            //获取某一个小区信息
            $.post("../Handler/MonitorContent.ashx", { "action": "getcontentbyid", "tID": uid }, function (res) {
                if (res.IsSucceed) {
                    $('#selectdev').val(res.Data[0].DevhouseID).attr("selected", true);
                    $('#selectsystype').val(res.Data[0].SysType).attr("selected", true);
                    $('#selectsystype').val(res.Data[0].SysType).attr("selected", true);
                    $('#selectcode').val(res.Data[0].ContentName).attr("selected", true);
                    $('#contentName').val($('#selectcode').val());
                }
                else {
                    $('#alertMsgContent small').html('获取小区信息失败！');
                }
                setTimeout(function () { $('#alertMsgContent').hide(); }, 3000);
            }, "json");
        }
    </script>
</asp:Content>
