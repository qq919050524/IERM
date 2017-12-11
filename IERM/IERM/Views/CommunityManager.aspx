<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="CommunityManager.aspx.cs" Inherits="IERM.Views.CommunityManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>小区管理</title>
    <link href="../css/Wizard/prettify.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class='container-fluid'>
        <section id="communitylist">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="form-inline">
                        <div class="text-left">
                            <div class="input-group">
                                <button id="addcommunity" type="button" class="btn btn-success" style="margin-left: 20px;margin-bottom: 10px;" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-plus"></span>添加</button>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                            <strong>操作提示</strong> <small></small>
                        </div>
                        <table id="tb_community"></table>
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
                    <h4 class="modal-title" id="myModalLabel">编辑小区信息</h4>
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
                            <form id="communityform" class="form-horizontal" role="form">
                                <input type="hidden" id="hd_communityid" name="hd_communityid" />
                                <div class="tab-content">
                                    <div class="tab-pane" id="tab1">
                                        <table class="table table-bordered">
                                            <tr>
                                                <td class="col-md-8">
                                                    <div class="form-group">
                                                        <label for="communityName" class="col-md-4 control-label">小区名:</label>
                                                        <div class="col-md-8">
                                                            <input type="text" class="form-control" id="communityName" name="communityName" placeholder="用于小区的名称">
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="selectcity" class="col-md-4 control-label">所属城市:</label>
                                                        <div class="col-md-8">
                                                            <select id="selectcity" name="selectcity" style="width: 130px;">
                                                            </select>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="selectppi" class="col-md-4 control-label">所属公司:</label>
                                                        <div class="col-md-8">
                                                            <select class="form-control" id="selectppi" name="selectppi">
                                                                <%foreach (var item in lstproperty)
                                                                    { %>
                                                                <option value="<%=item.propertyID %>"><%=item.propertyName %></option>
                                                                <%} %>
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cuLongitude" class="col-md-4 control-label">小区经度:</label>
                                                        <div class="col-md-8">
                                                            <input type="tel" class="form-control" id="cuLongitude" name="cuLongitude" placeholder="小区所在的经度">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cuLatitude" class="col-md-4 control-label">小区纬度:</label>
                                                        <div class="col-md-8">
                                                            <input type="text" class="form-control" id="cuLatitude" name="cuLatitude" placeholder="小区所在的纬度">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="acreage" class="col-md-4 control-label">小区面积（单位：平方米）:</label>
                                                        <div class="col-md-8">
                                                            <input type="text" class="form-control" id="acreage" name="acreage" placeholder="小区的面积">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="address" class="col-md-4 control-label">小区地址:</label>
                                                        <div class="col-md-8">
                                                            <input type="text" class="form-control" id="address" name="address" placeholder="小区所在的地址">
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="col-md-1">
                                                    <span style="color: red">必填</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="intro" class="col-md-4 control-label">备注:</label>
                                                        <div class="col-md-8">
                                                            <textarea class="form-control" id="intro" name="intro" rows="5" placeholder="小区情况说明"></textarea>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <span></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <ul class="pager wizard">
                                        <li class="finish"><a href="javascript:void();">保 存</a></li>
                                    </ul>
                                </div>
                                <div class="panel-body">
                                    <div id="alertMsgCommunity" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
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
    <script>
        $(function () {
            initSelectTree();
            $('#rootwizard').bootstrapWizard({
            });

            $('#rootwizard .finish').click(function () {
                var re = /^\d{1,4}(\.\d{1,6})?$/;
                var re1 = /^\d{1,8}(\.\d{1,2})?$/;
                if ($('#communityName').val().length == 0) {
                    $('#communityName').parent().addClass('has-error');
                    $('#communityName').focus();
                    return false;
                }
                else {
                    $('#communityName').parent().removeClass('has-error');
                }
                if ($('#cuLongitude').val().length == 0) {
                    $('#cuLongitude').parent().addClass('has-error');
                    $('#cuLongitude').focus();
                    return false;
                }
                else if (re.test($('#cuLongitude').val()) == false) {
                    $('#cuLongitude').parent().addClass('has-error');
                    $('#cuLongitude').focus();
                    $('#alertMsgCommunity small').html('小区经度必须由小数点和数字组成，小数点前4位小数点后6位！');
                    $('#alertMsgCommunity').show();
                    setTimeout(function () { $('#alertMsgCommunity').hide(); }, 3000);
                    return false;
                }
                else {
                    $('#cuLongitude').parent().removeClass('has-error');
                }
                if ($('#cuLatitude').val().length == 0) {
                    $('#cuLatitude').parent().addClass('has-error');
                    $('#cuLatitude').focus();
                    return false;
                }
                else if (re.test($('#cuLatitude').val()) == false) {
                    $('#cuLatitude').parent().addClass('has-error');
                    $('#cuLatitude').focus();
                    $('#alertMsgCommunity small').html('小区纬度必须由小数点和数字组成，小数点前4位小数点后6位！');
                    $('#alertMsgCommunity').show();
                    setTimeout(function () { $('#alertMsgCommunity').hide(); }, 3000);
                    return false;
                }
                else {
                    $('#cuLatitude').parent().removeClass('has-error');
                }
                if ($('#acreage').val().length == 0) {
                    $('#acreage').parent().addClass('has-error');
                    $('#acreage').focus();
                    return false;
                }
                else if (re1.test($('#acreage').val()) == false) {
                    $('#acreage').parent().addClass('has-error');
                    $('#acreage').focus();
                    $('#alertMsgCommunity small').html('小区面积必须由小数点和数字组成，小数点前8位小数点后2位！');
                    $('#alertMsgCommunity').show();
                    setTimeout(function () { $('#alertMsgCommunity').hide(); }, 3000);
                    return false;
                }
                else {
                    $('#acreage').parent().removeClass('has-error');
                }
                if ($('#address').val().length == 0) {
                    $('#address').parent().addClass('has-error');
                    $('#address').focus();
                    return false;
                }
                else {
                    $('#address').parent().removeClass('has-error');
                }
                //保存设置
                if ($('#hd_communityid').val() == "0") {
                    //新增操作
                    $.post("../Handler/CityAndCommunity.ashx", $('#communityform').serialize() + "&action=getaddcommunity", function (res) {
                        if (res.IsSucceed) {
                            $('#alertMsgCommunity small').html('添加小区成功！');
                            $('#alertMsgCommunity').show();
                            initTable();
                            setTimeout(function () { $('#myModal').hide(); }, 3000);
                        }
                        else {
                            $('#alertMsgCommunity small').html('添加小区失败！');
                        }
                        setTimeout(function () { $('#alertMsgCommunity').hide(); }, 3000);

                    }, "json");
                }
                else {
                    //更新操作
                    $.post("../Handler/CityAndCommunity.ashx", $('#communityform').serialize() + "&action=updatecomm", function (res) {
                        if (res.IsSucceed) {
                            $('#alertMsgCommunity small').html('编辑小区成功！');
                            $('#alertMsgCommunity').show();
                            initTable();
                            setTimeout(function () { $('#myModal').hide(); }, 3000);
                        }
                        else {
                            $('#alertMsgCommunity small').html('编辑小区失败！');
                        }
                        setTimeout(function () { $('#alertMsgCommunity').hide(); }, 3000);

                    }, "json");
                }
            });
            initTable();
        });

        //添加用户按钮
        $('#addcommunity').click(function () {
            //初始化向导
            $('#rootwizard').bootstrapWizard('show', 0);

            $('#hd_communityid').val("0");
            $('#communityName').val("");
            $('#cuLongitude').val("");
            $('#cuLatitude').val("");
            $('#acreage').val("");
            $('#address').val("");
            $('#intro').val("");
        });

        //初始化用户表
        function initTable() {
            //先销毁表格  
            $('#tb_community').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_community").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/CityAndCommunity.ashx?action=getallommunity&r=" + Math.random(), //获取数据的Servlet地址  
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
                        field: 'communityID',
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
                    field: 'communityName',
                    title: '小区名称',
                    align: 'center',
                    clickToSelect: false
                },
                {
                    field: 'cityname',
                    title: '所属城市',
                    align: 'center'
                },
                {
                    field: 'Propertyname',
                    title: '所属公司',
                    align: 'center',
                },
                {
                    field: 'cuLongitude',
                    title: '小区经度',
                    align: 'center',
                },
                {
                    field: 'cuLatitude',
                    title: '小区纬度',
                    align: 'center',
                },
                {
                    field: 'acreage',
                    title: '小区面积（单位：平方米）',
                    align: 'center',
                },
                 {
                     field: 'address',
                     title: '小区地址',
                     align: 'center',
                 },
                  {
                      field: 'intro',
                      title: '备     注',
                      align: 'center',
                  },
                {
                    title: '操作',
                    formatter: function (value, row, index) {
                        var e = '<a data-toggle="modal" href="javascript:void(0)"  data-target="#myModal" style="margin-right:10px;" onclick="edit(\'' + row.communityID + '\')">编辑</a> ';
                        var d = '<a href="javascript:void(0)" onclick="del(\'' + row.communityID + '\')">删除</a> ';
                        return e + d;
                    }
                }]
            });
        }

        //删除用户
        function del(uid) {
            $.post("../Handler/CityAndCommunity.ashx", { "action": "deletecomm", "communityid": uid }, function (res) {
                if (res.IsSucceed) {
                    $('#alertMsg small').html('删除小区成功！');
                    $('#alertMsg').show();
                    initTable();
                }
                else {
                    $('#alertMsg small').html('删除小区失败！');
                }
                setTimeout(function () { $('#alertMsg').hide(); }, 3000);
            }, "json");
        }

        //编辑用户
        function edit(uid) {
            $('#hd_communityid').val(uid);
            //初始化向导
            $('#rootwizard').bootstrapWizard('show', 0);
            //获取某一个小区信息
            $.post("../Handler/CityAndCommunity.ashx", { "action": "getcommunitybyid", "communityid": uid }, function (res) {
                if (res.IsSucceed) {
                    $('#communityName').val(res.Data[0].communityName);
                    $('#selectppi').val(res.Data[0].propertyMId).attr("selected", true);
                    $('#cuLongitude').val(res.Data[0].cuLongitude);
                    $('#cuLatitude').val(res.Data[0].cuLatitude);
                    $('#acreage').val(res.Data[0].acreage);
                    $('#address').val(res.Data[0].address);
                    $('#intro').val(res.Data[0].intro);
                }
                else {
                    $('#alertMsgCommunity small').html('获取小区信息失败！');
                }
                setTimeout(function () { $('#alertMsgCommunity').hide(); }, 3000);
            }, "json");
        }

        function initSelectTree() {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcity&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $("#selectcity").append(res.Data).select2tree();
                }
            });
        }
    </script>
</asp:Content>
