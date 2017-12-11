<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="IERM.Views.Message.SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>系统设置</title>
    <link href="../css/Wizard/prettify.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/jquery-confirm.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_body" runat="server">

    <form id="form1" class="form-horizontal" runat="server">
        <section id="userlist">
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered">
                        <tr>
                            <td class="col-md-8">
                                <div class="form-group">
                                    <label for="loginName" class="col-md-4 control-label">发送短信:</label>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnStart" Text="开始" class="btn btn-success" runat="server" OnClick="btnStart_Click" />
                                        <asp:Button ID="btnStop" Text="停止" class="btn btn-success" runat="server" OnClick="btnStop_Click" />
                                    </div>
                                </div>


                            </td>
                        </tr>

                    </table>
                </div>
            </div>
        </section>

    </form>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_script" runat="server">
</asp:Content>
