<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="IERM.Views.RoleManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>角色管理</title>
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
    <link href="../../css/jquery-confirm.min.css" rel="stylesheet" />
    <link href="../../css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="form-inline">
                <div class="panel-heading">
                    <ul id="breadcrumb">
                        <li><a href="javascript:void(0)">系统管理</a></li>
                        <li><a href="javascript:void(0)">角色管理</a></li>
                    </ul>
                </div>
                <button id="serach" type="button" class="btn btn-info" style="margin-left: 20px;" data-toggle="modal" data-target="#myModal_add">增加角色</button>
            </div>
        </div>
        <div class="panel-body" style="padding-bottom: 0px;">
            <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                <strong>操作提示</strong> <small></small>
            </div>
            <table id="tb_roles"></table>
        </div>
    </div>
    <!--角色编辑 start-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">编辑角色信息</h4>
                </div>
                <div class="modal-body">
                    <form role="form">
                        <input type="hidden" id="rid" name="rid" />
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="aName">角色名称</label>
                                    <input type="text" class="form-control" id="roleName" name="roleName" placeholder="角色名称">
                                </div>
                                <div class="form-group">
                                    <label for="amount">角色编码</label>
                                    <input type="text" class="form-control" id="roleCode" name="roleCode" placeholder="角色编码">
                                </div>
                                <div class="form-group">
                                    <label for="rpcount">角色介绍</label>
                                    <textarea class="form-control" rows="5" id="intro" name="intro" placeholder="角色介绍"></textarea>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>选择权限</label>
                                    <div id="right_content" class="panel panel-default text-center" style="min-height: 282px;">
                                    </div>
                                </div>

                            </div>
                        </div>

                    </form>
                </div>
                <div class="modal-footer">
                    <button id="rrsubmit" type="button" class="btn btn-success">提交</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <!--角色编辑 end-->

    <!--角色添加 start-->
    <div class="modal fade" id="myModal_add" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel_add">添加角色信息</h4>
                </div>
                <div class="modal-body">
                    <form role="form">
                        <input type="hidden" id="rid_add" name="rid" />
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="aName">物业公司</label>
                                    <select id="property">
                                        <%foreach (System.Data.DataRow item in propertyList.Rows)
                                            { %>
                                        <option value="<%=item["propertyID"].ToString()%>"><%=item["propertyName"].ToString() %></option>
                                        <%} %>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="aName">角色名称</label>
                                    <input type="text" class="form-control" id="roleName_add" name="roleName" placeholder="角色名称">
                                </div>
                                <div class="form-group">
                                    <label for="amount">角色编码</label>
                                    <input type="text" class="form-control" id="roleCode_add" name="roleCode" placeholder="角色编码">
                                </div>
                                <div class="form-group">
                                    <label for="rpcount">角色介绍</label>
                                    <textarea class="form-control" rows="5" id="intro_add" name="intro" placeholder="角色介绍"></textarea>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>选择权限</label>
                                    <div id="right_content_add" class="panel panel-default text-center" style="min-height: 282px;">
                                    </div>
                                </div>
                            </div>
                        </div>

                    </form>
                </div>
                <div class="modal-footer">
                    <button id="rrsubmit_add" type="button" class="btn btn-success">提交</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <!--角色添加 end-->

    <!--关联菜单 start-->
    <div class="modal fade" id="myModal_menu" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel_menu">关联权限 菜单</h4>
                </div>
                <div class="modal-body">
                    <form role="form">
                        <input type="hidden" id="rid_menu" name="rid" />
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="aName">ID:</label>
                                    <label for="aName" id="menuID"></label>
                                </div>
                                <div class="form-group">
                                    <label for="amount">角色名：</label>
                                    <label for="aName" id="menuName"></label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>选择权限</label>
                                    <div id="devtree"></div>
                                </div>
                            </div>
                        </div>

                    </form>
                </div>
                <div class="modal-footer">
                    <button id="rrsubmit_menu" type="button" class="btn btn-success" onclick="getNodeCheckValue();">提交</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <!--关联菜单 end-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript" src="../../js/treeview/bootstrap-treeview.min.js"></script>
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../js/jquery-confirm.min.js"></script>
    <script type="text/javascript">
        $(function () {
            initTable();
            initRightList();
            initTreeView();

            //编辑按钮提交事件
            $('#rrsubmit').click(function () {
                if (vail_update() == true) {
                    var chks = new Array();
                    $("#right_content :checked").each(function () {
                        chks.push($(this).val());
                    });
                    $.post("../Handler/RoleRelated.ashx",
                        {
                            "action": "updaterole",
                            "roleid": $('#rid').val(),
                            "roleCode": $('#roleCode').val(),
                            "roleName": $('#roleName').val(),
                            "intro": $('#intro').val(),
                            "rights": chks.join(',')
                        },
                    function (res) {
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();
                        if (res.IsSucceed) {
                            initTable();
                        }
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }, "json");
                    $('#myModal').modal('hide');
                }
            });


            //添加按钮提交事件
            $('#rrsubmit_add').click(function () {
                if (vail_add() == true) {
                    alert($('#property').val());
                    var chks = new Array();
                    $("#right_content_add :checked").each(function () {
                        chks.push($(this).val());
                    });
                    $.post("../Handler/RoleRelated.ashx",
                        {
                            "action": "addrole",
                            "propertyID": $('#property').val(),
                            //"roleid": $('#rid').val(),
                            "roleCode": $('#roleCode_add').val(),
                            "roleName": $('#roleName_add').val(),
                            "intro": $('#intro_add').val(),
                            "rights": chks.join(',')
                        },
                    function (res) {
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();
                        if (res.IsSucceed) {
                            initTable();
                        }
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }, "json");
                    $('#myModal_add').modal('hide');
                }
            });
        });

        //初始化角色列表
        function initTable() {
            //先销毁表格  
            $('#tb_roles').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_roles").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/RoleRelated.ashx?action=getallroles&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 175,
                //toolbar: '#toolbar',                //工具按钮用哪个容器
                clickToSelect: true,
                pagination: true, //启动分页  
                pageSize: 10,  //每页显示的记录数  
                pageNumber: 1, //当前第几页  
                pageList: [10, 20, 30],  //记录数可选列表  
                search: false,  //是否启用查询  
                //showColumns: true,  //显示下拉框勾选要显示的列  
                showRefresh: true,  //显示刷新按钮  
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
                    };
                    return param;
                },
                columns: [{
                    field: 'rid',
                    title: '序号',
                    align: 'center',
                },
                {
                    field: 'roleName',
                    title: '角色名',
                    align: 'center',
                },
                {
                    field: 'roleCode',
                    title: '角色编码',
                    align: 'center'
                },
                {
                    field: 'intro',
                    title: '角色说明',
                    align: 'center',
                },
                {
                    title: '操作',
                    align: 'center',
                    formatter: function (value, row, index) {
                        if (index != 0) {
                            var r = '<a href="javascript:void(0)" data-toggle="modal" data-target="#myModal_menu" onclick="relationmenu(\'' + row.rid + '\',\'' + row.roleName + '\')">关联菜单</a> ';//关联菜单
                            var e = '<a data-toggle="modal" href="javascript:void(0)"  data-target="#myModal" style="margin-right:10px;" onclick="edit(this)"><span class="glyphicon glyphicon-edit"></span>编辑</a> ';//编辑
                            var d = '<a href="javascript:void(0)" onclick="del(\'' + row.rid + '\',\'' + row.roleName + '\')">删除</a> ';//删除
                            return r + e + d;
                        }
                    }
                }]
            });
        }
        //初始化权限列表
        function initRightList() {
            $.getJSON("../Handler/RoleRelated.ashx?action=getallright&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $.map(res.Data, function (item) {
                        $('#right_content').append("<div class='checkbox'><label><input name='rightchks' value='" + item.rid + "' type='checkbox'>" + item.rightName + "</label></div>");
                        $('#right_content_add').append("<div class='checkbox'><label><input name='rightchks' value='" + item.rid + "' type='checkbox'>" + item.rightName + "</label></div>");
                    });
                }
            });
        }

        //编辑角色
        function edit(obj) {

            var thisrow = $(obj).parent().parent();
            $('#rid').val(thisrow.find('td:eq(0)').text());
            $('#roleName').val(thisrow.find('td:eq(1)').text());
            $('#roleCode').val(thisrow.find('td:eq(2)').text());
            $('#intro').val(thisrow.find('td:eq(3)').text());

            //清空权限列表
            $('#right_content :checkbox').removeAttr('checked');
            //获取权限
            $.getJSON("../Handler/RoleRelated.ashx?action=gerrightsbyroleid&r=" + Math.random(), { "roleID": $('#rid').val() }, function (res) {
                if (res.IsSucceed) {
                    $.map(res.Data, function (val) {
                        $("#right_content :checkbox[value='" + val.rid + "']").prop('checked', true);
                    });
                }
            });
        }

        //删除角色
        function del(id, name) {
            $.confirm({
                title: '警告',
                content: "<div style='font-size:24px;'>您确定要删除<font color='red'>[" + name + "]</font>吗？</div>",
                buttons: {
                    ok: {
                        text: "确定",
                        btnClass: 'btn-primary',
                        keys: ['enter'],
                        action: function () {
                            $.post("../Handler/RoleRelated.ashx", { "rid": id, "action": "delroles" }, function (res) {
                                if (res.IsSucceed) {
                                    initTable();
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

        //关联菜单
        function relationmenu(id, name) {
            $("#menuID").html(id);
            $("#menuName").html(name);
        }

        //菜单树菜单
        function initTreeView() {
            $.getJSON("../Handler/systemmenu.ashx?action=getmenutreelist&r=" + Math.random(),
                {
                    "pid":1,
                    "cid":2,
                    "cmid":1,
                }, function (res) {
                    if (res.IsSucceed) {
                        var $selectableTree = $('#devtree').treeview({
                            data: res.Data,         // data is not optional
                            //levels: 0,                            
                            showCheckbox:true,
                            //selectable: true,
                            onhoverColor: "#E8E8E8",
                            highlightSelected: true,
                            onNodeChecked: function (event, node) { //选中节点
                                //$('#devtree').treeview('checkAll', { silent: true });
                                var selectNodes = getNodeIdArr(node);//获取所有子节点
                                if(selectNodes){ //子节点不为空，则选中所有子节点
                                    $('#devtree').treeview('checkNode', [selectNodes, { silent: true }]);
                                }
                            },
                            onNodeUnchecked: function (event, node) { //取消选中节点
                                var selectNodes = getNodeIdArr(node);//获取所有子节点
                                if (selectNodes) { //子节点不为空，则取消选中所有子节点
                                    $('devtree').treeview('uncheckNode', [selectNodes, { silent: true }]);
                                }
                            },
                            onNodeSelected: function (event, node) {
                                ////alert(node.id + "---" + node.text);
                                //var c = $('#devtree').treeview('getParent', node);
                                //var p = $('#devtree').treeview('getParent', c);
                                ////标题头
                                //$('#breadcrumb a:eq(1)').text(p.text);
                                //$('#breadcrumb a:eq(2)').text(c.text);
                                //$('#breadcrumb a:eq(3)').text(node.text);
                                ////编辑框
                                //$('#_province').val(p.text);
                                //$('#_city').val(c.text);
                                //$('#_community').val(node.text);

                                //initTable(node.id);
                                //$('#hd_community').val(node.id);                                
                            },
                            onNodeExpanded: function (event, node) {
                                //$('#devtree').treeview('getSiblings', node).treeview('collapseNode');
                            }
                        });
                    }
                });
        }

        //递归获取所有的结点id
        function getNodeIdArr(node) {
            var ts = [];
            if (node.nodes) {
                for (x in node.nodes) {
                    ts.push(node.nodes[x].nodeId)
                    if (node.nodes[x].nodes) {
                        var getNodeDieDai = getNodeIdArr(node.nodes[x]);
                        for (j in getNodeDieDai) {
                            ts.push(getNodeDieDai[j]);
                        }
                    }
                }
            } else {
                ts.push(node.nodeId);
            }
            return ts;
        }

        //授权
        function getNodeCheckValue() {
            //获取选中的值
            var arr = $('#devtree').treeview('getChecked', 0);
            if (arr.length > 0) {
                var ids = "";
                $.each(arr, function (index, obj) {
                    ids += obj.id + ",";
                });
                ids = ids.substring(0, ids.length - 1);//组合选中的值，格式为：1,2,3,4
                //addrolemenu
                //授权
                $.post("../Handler/RoleRelated.ashx", { "action": "addrolemenu", "mid": $("#menuID").html(), "ids": ids }, function (res) {
                    if (res.IsSucceed) {
                        $('#myModal_menu').modal('hide');
                        $('#alertMsg small').html(res.Msg);
                        $('#alertMsg').show();    
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }
                }, "json");
            }
            else { alert("请勾选菜单");}
        }

        //验证开始
        function vail_add()
        {
            if ($("#roleName_add").val() == "")
            {
                alert("角色名必填！");
                return false;
            }
            if ($("#roleCode_add").val() == "") {
                alert("角色编码必填！");
                return false;
            }
            return true;
        }
        function vail_update() {
            if ($("#roleName").val() == "") {
                alert("角色名必填！");
                return false;
            }
            if ($("#roleCode").val() == "") {
                alert("角色编码必填！");
                return false;
            }
            return true;
        }
        //验证结束
    </script>
</asp:Content>
