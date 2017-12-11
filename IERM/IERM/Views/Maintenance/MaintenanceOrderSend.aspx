<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceOrderSend.aspx.cs" Inherits="IERM.Views.Maintenance.MaintenanceOrderSend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>派单</title>
    <link href="../../css/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/select2andtree/select2.min.js"></script>
    <script src="../../js/select2andtree/i18n/zh-CN.js"></script>
    <script src="../../js/select2andtree/select2tree.js"></script>
    <style>
    </style>
    <script>
        $(function () {
            //加载用户
            $.getJSON("/Handler/User.ashx?action=getuserbycommunity&r=" + Math.random(), { communityID: $("#communityid").val() }, function (res) {
                if (res.IsSucceed) {
                    $('#user option').remove();
                    $.map(res.Data, function (item) {
                        $('#user').append("<option value='" + item.uid + "'>" + item.nickName + "</option>")
                    });
                    $('#user').select2tree();
                }
            });
        })
        var index = parent.layer.getFrameIndex(window.name);
        function exit() {
            parent.layer.close(index);
        }
        function commit() {
            $.post("/Handler/MaintenanceOrderHandler.ashx",
                {
                    "action": "SendMaintenanceOrder",
                    "orderID": $("#orderid").val(),
                    "userID": $("#user").val()
                },
                function (res) {
                    if (res.IsSucceed) {
                        parent.$('#alertMsg small').html('派单成功！');
                        parent.initTable();
                    }
                    else {
                        parent.$('#alertMsg small').html(res.Msg);
                    }
                    parent.$('#alertMsg').show();
                    parent.alertHide();
                    exit();
                }, "json");
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="orderid" type="hidden" runat="server" />
        <input id="communityid" type="hidden" runat="server" />

        <div class="input-group" style="margin: 20px;">
            <span class="input-group-addon">单&nbsp;&nbsp;&nbsp;&nbsp;号：</span>
            <input type="text" id="ordersn" class="form-control" runat="server" readonly="readonly" />
        </div>
        <div class="input-group" style="margin: 20px;">
            <span class="input-group-addon">责任人：</span>
            <select class="form-control" id="user">
            </select>
        </div>
        <div class="form-group btn-footer navbar-fixed-bottom">
            <div style="float: right; margin: 20px;">
                <button type="button" class="btn btn-primary btn-xl" onclick="commit()">
                    确认
                </button>
                <button type="button" class="btn btn-danger btn-xl" onclick="exit()">
                    关闭
                </button>
            </div>
        </div>
    </form>
</body>
</html>
