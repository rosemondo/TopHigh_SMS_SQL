<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Add_Debt.aspx.vb" Inherits="Top_High_Schools.Add_Debt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />

    <style type="text/css">
        .card-header {
            background-color: #16b60e;
        }

        .card-title {
            color: white;
        }

        .roundimage {
            border-radius: 50%;
        }

        .center-img {
            display: block;
            margin-left: auto;
            margin-right: auto;
        }

        .select2-container .select2-selection--single {
            height: 34px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800" id="lar">Learner's Arreas</h4>

    </div>

    <!-- Input rows -->

    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title" id="arf">Arreas Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">

                        <div class="col-sm-4">
                            <label id="lblstud">Student</label>
                            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="getStudID()" requide="true"></asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <label id="lblclass">Class</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtclass" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label id="lbldate">Date</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtdate" TextMode="Date"></asp:TextBox>
                        </div>
                        <asp:HiddenField ID="txtstudid" runat="server" />
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-3">
                            <label id="lblArreas">Arreas</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtarreas"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-6">
                            <label id="lblDescription">Description</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdecsription" required="true"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <input type="button" id="btnSave" value="Save & Print" class="btn btn-primary" />
                    <input type="button" id="btncancel" value="Cancel" class="btn btn-success float-right" onclick="resetAllControls()" />
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:HiddenField ID="txtCashAcc" runat="server" />
            <asp:HiddenField ID="txtReceAcc" runat="server" />
            <asp:HiddenField ID="txtAdmAcc" runat="server" />
            <asp:HiddenField ID="txtSchAcc" runat="server" />
            <asp:HiddenField ID="txtlinkcode" runat="server" />
            <asp:HiddenField ID="txtusers" runat="server" />
            <asp:HiddenField ID="txttimer" runat="server" />
            <asp:HiddenField ID="txtlocation" runat="server" />
            <asp:HiddenField ID="txtcomp" runat="server" />
            <asp:HiddenField ID="txtfont" runat="server" />
        </div>

    </div>

    <br />

    <script type="text/javascript">

        $('#ddlStudent').select2({
            placeholder: 'Select an option'
        });

        function getStudID() {
            var studname = $("[id*=ddlStudent]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Add_Debt.aspx/GetStudID",
                data: "{studname:'" + studname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtstudid]').val(data.d.StudentID);
                    $('[id*=txtclass]').val(data.d.ClassName);
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };

        $("#btnSave").click(function () {
            var txtdate = $.trim($('#<%=txtdate.ClientID %>').val());
            var txtdecsription = $.trim($('#<%=txtdecsription.ClientID %>').val());
            var txtarreas = $.trim($('#<%=txtarreas.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var txttimer = $.trim($('#<%=txttimer.ClientID %>').val());
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Add_Debt.aspx/Insert_Credit_Statement",
                data: "{txtdate: '" + txtdate + "','txtdecsription':'" + txtdecsription + "','txtarreas':'" + txtarreas + "','txtstudid':'" + txtstudid + "','txttimer':'" + txttimer + "','txtlinkcode':'" + txtlinkcode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    Insert_JV_Deb()
                }
            });

        });

        function Insert_JV_Deb() {
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());
            var txtdate = $.trim($('#<%=txtdate.ClientID %>').val());
            var txtReceAcc = $.trim($('#<%=txtReceAcc.ClientID %>').val());
            var txtarreas = $.trim($('#<%=txtarreas.ClientID %>').val());
            var txttimer = $.trim($('#<%=txttimer.ClientID %>').val());
            var txtusers = $.trim($('#<%=txtusers.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Add_Debt.aspx/Insert_JV_Recevables",
                data: "{txtlinkcode: '" + txtlinkcode + "','txtdate':'" + txtdate + "','txtReceAcc':'" + txtReceAcc + "','txtarreas':'" + txtarreas + "','txttimer':'" + txttimer + "','txtusers':'" + txtusers + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    Insert_JV_Cred()
                }
            });

        };

        function Insert_JV_Cred() {
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());
            var txtdate = $.trim($('#<%=txtdate.ClientID %>').val());
            var txtSchAcc = $.trim($('#<%=txtSchAcc.ClientID %>').val());
            var txtarreas = $.trim($('#<%=txtarreas.ClientID %>').val());
            var txttimer = $.trim($('#<%=txttimer.ClientID %>').val());
            var txtusers = $.trim($('#<%=txtusers.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Add_Debt.aspx/Insert_JV_Sch_Fees",
                data: "{txtlinkcode: '" + txtlinkcode + "','txtdate':'" + txtdate + "','txtSchAcc':'" + txtSchAcc + "','txtarreas':'" + txtarreas + "','txttimer':'" + txttimer + "','txtusers':'" + txtusers + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    resetAllControls()
                }
            });

        };

        function resetAllControls() {
            $("#form1").find('input:text, input:password, input:file, select, textarea,select2').val('');
            $("#form1").find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
        };

    </script>

    <script type="text/javascript">
        var fontstyle = $.trim($('#<%=txtfont.ClientID %>').val());
        var seconds = 3;
        function countdown() {
            seconds = seconds - 1;
            if (seconds < 0) {
                PageMethods.name(function (response, userContext, methodName) {
                    document.getElementById("hd").style.fontFamily = "Algerian";
                });
            } else {

                document.getElementById("myhd").style.fontFamily = fontstyle;
                document.getElementById("nabyrow1").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
