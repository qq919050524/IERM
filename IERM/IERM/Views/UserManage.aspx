<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="IERM.Views.UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>用户管理</title>
    <link href="../css/Wizard/prettify.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/jquery-confirm.min.css" rel="stylesheet" />
    <style>
        #tab4 table tr td {
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <section id="userlist">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group">
                            <span class="input-group-addon">角色筛选：</span>
                            <select class="form-control" id="roleselect" runat="server">
                                <%-- <option value="0" selected>全部</option>
                                <%foreach (var item in rolelist)
                                    { %>
                                <option value="<%=item.rid %>"><%=item.roleName %></option>
                                <%} %>--%>
                            </select>
                        </div>
                        <div class="input-group" style="margin-left: 30px;">
                            <span class="input-group-addon">昵称筛选：</span>
                            <input id="nickname" type="text" class="form-control" placeholder="昵称关键字">
                        </div>
                        <button id="serach" type="button" class="btn btn-info" style="margin-left: 20px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                    <strong>操作提示</strong> <small></small>
                </div>
                <div id="toolbar" class="btn-group">
                    <button id="adduser" type="button" data-toggle="modal" data-target="#myModal" class="btn btn-success">
                        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>新增
                    </button>
                </div>
                <table id="tb_users"></table>
            </div>
        </div>
    </section>

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">编辑用户信息</h4>
                </div>
                <div class="modal-body">
                    <section id="wizard">
                        <div id="rootwizard">
                            <div id="navbar" class="navbar">
                                <div class="navbar-inner">
                                    <div class="container">
                                        <ul>
                                            <li><a href="#tab1" data-toggle="tab">基本信息</a></li>
                                            <li><a href="#tab2" data-toggle="tab">角色设置</a></li>
                                            <li><a href="#tab3" data-toggle="tab">小区授权</a></li>
                                            <li><a href="#tab4" data-toggle="tab">完成</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div id="bar" class="progress">
                                <div class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 25%"></div>
                            </div>
                            <form id="userform" class="form-horizontal" role="form">
                                <input type="hidden" id="hd_userid" name="uid" />
                                <div class="tab-content">
                                    <div class="tab-pane" id="tab1">
                                        <table class="table table-bordered">
                                            <tr>

                                                <td class="col-md-8">
                                                    <div class="form-group">
                                                        <label for="loginName" class="col-md-4 control-label">登录名:</label>
                                                        <div class="col-md-7">
                                                            <input type="text" class="form-control" id="loginName" name="loginName" placeholder="用于系统登录的名称">
                                                        </div>
                                                        <div style="float: left">
                                                            <span style="color: red;">*</span>
                                                        </div>

                                                    </div>

                                                    <div class="form-group">
                                                        <label for="password" class="col-md-4 control-label">密码:</label>
                                                        <div class="col-md-7">
                                                            <input type="password" class="form-control" id="password" name="password" placeholder="用于登录系统的密码">
                                                        </div>
                                                        <div style="float: left">
                                                            <span style="color: red;">*</span>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="nickName" class="col-md-4 control-label">昵称</label>
                                                        <div class="col-md-7">
                                                            <input type="text" class="form-control" id="nickName" name="nickName" placeholder="系统中用于显示用户的名称">
                                                        </div>
                                                        <div style="float: left">
                                                            <span style="color: red;">*</span>
                                                        </div>
                                                    </div>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <label for="mobile" class="col-md-4 control-label">电话:</label>
                                                        <div class="col-md-7">
                                                            <input type="tel" class="form-control" id="mobile" name="mobile" placeholder="联系电话">
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="property" class="col-md-4 control-label">所属公司:</label>
                                                        <div class="col-md-7">
                                                            <select id="property" name="property" class="form-control" style="width: 250px; margin-right: 20px;">
                                                                <%foreach (System.Data.DataRow item in propertyList.Rows)
                                                                    { %>
                                                                <option value="<%=item["propertyName"].ToString()%>"><%=item["propertyName"].ToString() %></option>
                                                                <%} %>
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="departmentname" class="col-md-4 control-label">所属部门:</label>
                                                        <div class="col-md-7">
                                                            <input type="text" class="form-control" id="departmentName" name="departmentName" placeholder="用户所属的部门名称">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="remark" class="col-md-4 control-label">备注:</label>
                                                        <div class="col-md-7">
                                                            <textarea class="form-control" id="remark" name="remark" rows="5" placeholder="用户情况说明"></textarea>
                                                        </div>
                                                    </div>
                                                </td>

                                            </tr>
                                        </table>
                                    </div>

                                    <div class="tab-pane" id="tab2">
                                        <table id="tb_role" class="table table-bordered table-hover">
                                            <tr class="danger">
                                                <td>
                                                    <div class="radio disabled">
                                                        <label class="h4 col-md-4">
                                                            <input disabled type="radio" name="radio_role" id="radio_admin" value="1">系统管理员
                                                        </label>
                                                        <label for="radio_admin" class="h4 col-md-8">
                                                            <small style="margin-left: 20px;">拥有所有操作权限</small>
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="radio">
                                                        <label class="h4 col-md-4">
                                                            <input type="radio" name="radio_role" id="radio_senior" value="2">公司高管
                                                        </label>
                                                        <label for="radio_senior" class="h4 col-md-8">
                                                            <small style="margin-left: 20px;">慧之美和智慧家高级管理者，拥有全部小区数据查看权限</small>
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="radio">
                                                        <label class="h4 col-md-4">
                                                            <input type="radio" name="radio_role" id="radio_minister" value="3">工程部部长
                                                        </label>
                                                        <label for="radio_minister" class="h4 col-md-8">
                                                            <small style="margin-left: 20px;">慧之美工程部部长，拥有全部小区数据查看、用户添加修改删除、报警确认权限</small>
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="radio">
                                                        <label class="h4 col-md-4">
                                                            <input type="radio" name="radio_role" id="radio_governor" value="4">工程部主管
                                                        </label>
                                                        <label for="radio_governor" class="h4 col-md-8">
                                                            <small style="margin-left: 20px;">慧之美工程部主管，拥有部分小区数据查看、用户添加修改删除、报警确认权限</small>
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="success">
                                                <td>
                                                    <div class="radio">
                                                        <label class="h4 col-md-4">
                                                            <input type="radio" name="radio_role" id="radio_staff" checked value="5">工程人员
                                                        </label>
                                                        <label for="radio_staff" class="h4 col-md-8">
                                                            <small style="margin: 20px;">慧之美工程部工程员或物业项目工程人员，拥有特定小区数据查看、报警确认权限</small>
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="radio">
                                                        <label class="h4 col-md-4">
                                                            <input type="radio" name="radio_role" id="radio_guest" value="6">游客
                                                        </label>
                                                        <label for="radio_guest" class="h4 col-md-8">
                                                            <small style="margin: 20px;">潜在客户，只能浏览指定虚拟小区数据</small>
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                    <div class="tab-pane" id="tab3">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="form-inline text-left" id="authcommunity">
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
                                                        <span class="input-group-addon">小区名筛选：</span>
                                                        <input id="cpartname" type="text" class="form-control" placeholder="小区名关键字">
                                                    </div>
                                                    <button id="cmtsearch" type="button" class="btn btn-info"><span class="glyphicon glyphicon-search"></span>筛选</button>
                                                </div>
                                            </div>
                                            <div id="cmtbody" class="panel-body">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab4">
                                        <table class="table table-bordered">
                                            <tr>
                                                <td rowspan="6" style="width: 100px; line-height: 200px; text-align: center;">基本信息</td>
                                                <td style="width: 120px; text-align: right;">登录名：</td>
                                                <td><span id="sp_loginname"></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">昵称：</td>
                                                <td><span id="sp_nickname"></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">电话：</td>
                                                <td><span id="sp_mobile"></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">所属公司：</td>
                                                <td><span id="sp_companyname"></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">所属部门：</td>
                                                <td><span id="sp_departmentname"></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">备注：</td>
                                                <td><span id="sp_remark"></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">角色信息</td>
                                                <td style="text-align: right;">系统角色：</td>
                                                <td><span id="sp_rolename"></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">授权项目</td>
                                                <td style="text-align: right;">小区名单：</td>
                                                <td><span id="sp_communityname"></span></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <ul class="pager wizard">
                                        <li class="previous"><a href="javascript:void();">上一步</a></li>
                                        <li class="next"><a href="javascript:void();">下一步</a></li>
                                        <li class="finish"><a href="javascript:void();">保 存</a></li>
                                    </ul>
                                </div>
                            </form>

                        </div>
                    </section>
                </div>
                <%--                <div class="modal-footer">
                    <button type="button" class="btn btn-success">提交</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                </div>--%>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">

    <script src="../js/Wizard/jquery.bootstrap.wizard.min.js"></script>
    <script src="../js/Wizard/prettify.js"></script>
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../js/jquery-confirm.min.js"></script>
    <script>
        $(function () {
            $('#rootwizard').bootstrapWizard({
                onTabShow: function (tab, navigation, index) {
                    var $total = navigation.find('li').length;
                    var $current = index + 1;
                    var $percent = ($current / $total) * 100;
                    $('#rootwizard .progress-bar').css({ width: $percent + '%' });

                    if (index == 2) {
                        if ($("#tb_role :checked").val() < 4) {
                            $('#authcommunity').hide();
                            $('#cmtbody').empty().append("<h3>已获取全部项目授权</h3>");

                        } else {
                            $('#authcommunity').show();
                            loadAuthCommunity();
                        }
                    }
                    else if (index == 3) {
                        $('#sp_loginname').html($('#loginName').val());
                        $('#sp_nickname').html($('#nickName').val());
                        $('#sp_mobile').html($('#mobile').val());
                        $('#sp_companyname').html($('#property').val());
                        $('#sp_departmentname').html($('#departmentName').val());
                        $('#sp_remark').html($('#remark').val());
                        $('#sp_rolename').html($("#tb_role input[name='radio_role']:checked").parent().text());
                        if ($('#cmtbody input[type="checkbox"]').length == 0) {
                            $('#sp_communityname').html("<font color='red'>已获取全部项目授权</font>");
                        }
                        else {
                            var chks = new Array();
                            $('#cmtbody input[type="checkbox"]:checked').each(function () {
                                chks.push(($(this).parent().text()));
                            });
                            $('#sp_communityname').html(chks.join(','));
                        }

                    }
                },
                onNext: function (tab, navigation, index) {
                    if (index == 1) {
                        if ($('#loginName').val().length == 0) {
                            $('#loginName').parent().addClass('has-error');
                            $('#loginName').focus();
                            return false;
                        }
                        else {
                            $('#loginName').parent().removeClass('has-error');
                        }

                        if ($('#password').val().length == 0 && $('#hd_userid').val() == "0") {
                            $('#password').parent().addClass('has-error');
                            $('#password').focus();
                            return false;
                        }
                        else {
                            $('#password').parent().removeClass('has-error');
                        }

                        if ($('#nickName').val().length == 0) {
                            $('#nickName').parent().addClass('has-error');
                            $('#nickName').focus();
                            return false;
                        }
                        else {
                            $('#nickName').parent().removeClass('has-error');
                        }
                    }
                    else if (index == 2) {
                        if ($("#tb_role :checked").val() < 4) {
                            $('#authcommunity').hide();
                            $('#cmtbody').empty().append("<h3>已获取全部项目授权</h3>");

                        } else {
                            $('#authcommunity').show();
                            loadAuthCommunity();
                        }
                    }
                }
            });

            $('#rootwizard .finish').click(function () {
                //保存设置
                if ($('#hd_userid').val() == "0") {
                    //新增操作
                    $.post("/Handler/User.ashx", $('#userform').serialize() + "&action=adduser", function (res) {
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();
                        if (res.IsSucceed) {
                            initTable();
                        }
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }, "json");
                }
                else {
                    //更新操作
                    $.post("/Handler/User.ashx", $('#userform').serialize() + "&action=updateuser", function (res) {
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();
                        if (res.IsSucceed) {
                            initTable();
                        }
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }, "json");
                }
                $('#myModal').modal('hide');
            });

            initTable();

            $("#tb_role :radio").click(function () {
                $(this).parent().parent().parent().parent().addClass('success').siblings().removeClass('success');
            });

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

            //添加用户按钮
            $('#adduser').click(function () {
                //初始化向导
                $('#rootwizard').bootstrapWizard('show', 0);
                $('#hd_userid').val(0);

                $('#userform')[0].reset();
                loadAuthCommunity();
            });

            //筛选授权小区
            $('#cmtsearch').click(function () {
                loadAuthCommunity();
            });

            ////用户名失去焦点后进行唯一性校验
            //$('#loginName').blur(function () {
            //    alert('ok');
            //});
        });


        //初始化用户表
        function initTable() {
            //先销毁表格  
            $('#tb_users').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_users").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "/Handler/User.ashx?action=getuserwithrole&r=" + Math.random(), //获取数据的Servlet地址  
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
                        roleType: $('#roleselect').val(),
                        nickName: $('#nickname').val()
                    };
                    return param;
                },
                onLoadSuccess: function () {  //加载成功时执行  

                },
                onLoadError: function () {  //加载失败时执行  

                },
                columns: [
                    {
                        field: 'uid',
                        title: 'uid',
                        visible: false
                    },
                    //{
                    //    field: 'headimg',
                    //    title: '头像',
                    //    align: 'center',
                    //    formatter: function (value, row, index) {
                    //        return '<img style="width:32px;height:32px;" src=' + row.headimg + ' alt=' + row.nickName + ' />';
                    //    }
                    //},
                    {
                        field: 'nickName',
                        title: '昵称',
                        align: 'center',
                        clickToSelect: false
                    },
                    {
                        field: 'remark',
                        title: 'remark',
                        visible: false
                    },
                    {
                        field: 'loginName',
                        title: '登录名',
                        align: 'center'
                    },
                    {
                        field: 'mobile',
                        title: '联系电话',
                        align: 'center',
                    },
                    {
                        field: 'companyName',
                        title: '所属公司名',
                        align: 'center',
                    },
                    {
                        field: 'departmentName',
                        title: '所属部门名',
                        align: 'center',
                    },
                    {
                        field: 'roleName',
                        title: '角色名',
                        align: 'center',
                        formatter: function (value, row, index) {
                            return "<p data-rid='" + row.rid + "'>" + value + "</p>";
                        }
                    },
                    {
                        title: '操作',
                        formatter: function (value, row, index) {
                            var e = '<a data-toggle="modal" href="javascript:void(0)"  data-target="#myModal" style="margin-right:10px;" onclick="edit(this,\'' + row.uid + '\',\'' + row.remark + '\')"><span class="glyphicon glyphicon-edit"></span>编辑</a> ';
                            var d = '<a href="javascript:void(0)" onclick="del(\'' + row.uid + '\',\'' + row.nickName + '\')"> <span class="glyphicon glyphicon-trash"></span>删除</a> ';
                            return e + d;
                        }
                    }
                ]
            });
        }

        //加载城市信息
        function initCityList(pid) {
            $.getJSON("/Handler/CityAndCommunity.ashx?action=getcitys&pid=" + pid + "&r=" + Math.random(), null, function (res) {
                $('#city option').remove();
                if (res.IsSucceed) {
                    $.map(res.Data, function (item) {
                        $('#city').append("<option value='" + item.areaID + "'>" + item.areaName + "</option>")
                    });
                }
            });
        }

        //加载授权小区
        function loadAuthCommunity() {
            //alert($('#hd_userid').val());
            $.getJSON("/Handler/User.ashx?action=getauthcommunity&r=" + Math.random(),
                {
                    "uid": $('#hd_userid').val(),
                    "cityid": $('#city').val(),
                    "partname": $('#cpartname').val()
                }, function (res) {
                    $('#cmtbody').empty();
                    if (res.IsSucceed) {
                        $.map(res.Data, function (item) {
                            if ($('#hd_userid').val() == "0") {

                                $('#cmtbody').append("<div class='col-md-2 col-sm-3 checkbox'><label for='chk" + item.communityID + "'><input name='authcommunity' type='checkbox' id='chk" + item.communityID + "' value='" + item.communityID + "'>" + item.communityName + "</label></div>");
                            }
                            else {
                                if (item.isauth) {
                                    $('#cmtbody').append("<div class='col-md-2 col-sm-3 checkbox'><label for='chk" + item.communityID + "'><input name='authcommunity' checked='checked' type='checkbox' id='chk" + item.communityID + "' value='" + item.communityID + "'>" + item.communityName + "</label></div>");
                                }
                                else {
                                    $('#cmtbody').append("<div class='col-md-2 col-sm-3 checkbox'><label for='chk" + item.communityID + "'><input name='authcommunity' type='checkbox' id='chk" + item.communityID + "' value='" + item.communityID + "'>" + item.communityName + "</label></div>");
                                }
                            }
                        });
                    }
                });
        }

        //删除用户
        function del(uid, nickname) {
            $.confirm({
                title: '警告',
                content: "您确定要删除<font color='red'>[" + nickname + "]</font>吗？",
                buttons: {
                    ok: {
                        text: "确定",
                        btnClass: 'btn-primary',
                        keys: ['enter'],
                        action: function () {
                            $.post("../Handler/User.ashx", { "action": "deleteuser", "uid": uid }, function (res) {
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

        //编辑用户
        function edit(obj, uid, remark) {
            $('#hd_userid').val(uid);
            var thisrow = $(obj).parent().parent();
            $('#userform')[0].reset();
            //初始化向导
            $('#rootwizard').bootstrapWizard('show', 0);

            loadAuthCommunity();

            $('#loginName').val(thisrow.find("td:eq(1)").text());
            $('#password').val("");
            //禁用密码
            $('#password').attr("disabled", "disabled");
            $('#nickName').val(thisrow.find("td:eq(0)").text());
            $('#mobile').val(thisrow.find("td:eq(2)").text());
            $('#companyName').val(thisrow.find("td:eq(3)").text());
            $('#departmentName').val(thisrow.find("td:eq(4)").text());
            $('#remark').val(remark);

            var roleradio = $("#tb_role :radio[value='" + thisrow.find("td:eq(5) p").data("rid") + "']");
            roleradio.click();
        }
    </script>
</asp:Content>
