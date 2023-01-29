<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Deposite.aspx.vb" Inherits="Top_High_Schools.Deposite" %>

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
        <h4 class="h4 mb-0 text-gray-800">Bank Deposit</h4>

    </div>

    <!-- Input rows -->

    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Deposit</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-12">
                            <label for="inputPassword3">Bank Name</label>
                            <asp:DropDownList ID="dplbankname" runat="server" CssClass="form-control" required="true" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label for="inputEmail3">A/c Name</label>
                            <asp:DropDownList ID="dplacname" runat="server" CssClass="form-control"  onchange="getAcNum()" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <div class="col-sm-6">
                            <label for="inputEmail3">General A/c</label>
                            <asp:DropDownList ID="ddlgen" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                    </div>

                    <div class="form-group row">
                        <div class="col-sm-12">
                            <label for="inputEmail3">A/c Number</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtacnum" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group row">

                        <div class="col-sm-6">
                            <label for="inputEmail3">Date</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdepdate" TextMode="Date" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-6">
                            <label for="inputPassword3">Amount</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtdepamt"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-12">
                            <label for="inputPassword3">Description</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdepdes" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <hr />

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                     <input type="button" id="btnSave" value="Save" class="btn btn-primary" />
                    <input type="button" id="btncancel" value="Cancel" class="btn btn-success float-right" onclick="resetAllControls()" />
                </div>
                <!-- /.card-footer -->
            </div>

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
    </div>

    <asp:HiddenField ID="txtfont" runat="server" />
    <br />

    <script type="text/javascript">

        $('#dplbankname').select2({
            placeholder: 'Select an option'
        });

        $('#dplacname').select2({
            placeholder: 'Select an option'
        });

        $('#ddlgen').select2({
            placeholder: 'Select an option'
        });

        function getAcNum() {
            var acname = $("[id*=dplacname]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Deposite.aspx/GetAcnumber",
                data: "{acname:'" + acname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtacnum]').val(data.d.AccNumber);
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };


        $("#btnSave").click(function () {
            var txtdepdate = $.trim($('#<%=txtdepdate.ClientID %>').val());
            var dplacname = $.trim($('#<%=dplacname.ClientID %>').val());
            var txtacnum = $.trim($('#<%=txtacnum.ClientID %>').val());
            var txtdepdes = $.trim($('#<%=txtdepdes.ClientID %>').val());
            var txtdepamt = $.trim($('#<%=txtdepamt.ClientID %>').val());
            var dplbankname = $.trim($('#<%=dplbankname.ClientID %>').val());
             $.ajax({
                 type: "POST",
                 url: "/Deposite.aspx/insert_deposit",
                 data: "{txtdepdate: '" + txtdepdate + "','dplacname':'" + dplacname + "','txtacnum':'" + txtacnum + "','txtdepdes':'" + txtdepdes + "','txtdepamt':'" + txtdepamt + "','dplbankname':'" + dplbankname + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (r) {
                     Insert_JV_Deb()
                 }
             });

        });

        function Insert_JV_Deb() {
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());
            var txtdepdate = $.trim($('#<%=txtdepdate.ClientID %>').val());
            var dplacname = $.trim($('#<%=dplacname.ClientID %>').val());
            var txtdepamt = $.trim($('#<%=txtdepamt.ClientID %>').val());
            var txttimer = $.trim($('#<%=txttimer.ClientID %>').val());
            var txtusers = $.trim($('#<%=txtusers.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Deposite.aspx/Insert_JV_Depo_Debit",
                data: "{txtlinkcode: '" + txtlinkcode + "','txtdepdate':'" + txtdepdate + "','dplacname':'" + dplacname + "','txtdepamt':'" + txtdepamt + "','txttimer':'" + txttimer + "','txtusers':'" + txtusers + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    Insert_JV_Cred()
                }
            });

        };

        function Insert_JV_Cred() {
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());
            var txtdepdate = $.trim($('#<%=txtdepdate.ClientID %>').val());
            var ddlgen = $.trim($('#<%=ddlgen.ClientID %>').val());
            var txtdepamt = $.trim($('#<%=txtdepamt.ClientID %>').val());
            var txttimer = $.trim($('#<%=txttimer.ClientID %>').val());
            var txtusers = $.trim($('#<%=txtusers.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Deposite.aspx/Insert_JV_Depo_Credit",
                data: "{txtlinkcode: '" + txtlinkcode + "','txtdepdate':'" + txtdepdate + "','ddlgen':'" + ddlgen + "','txtdepamt':'" + txtdepamt + "','txttimer':'" + txttimer + "','txtusers':'" + txtusers + "'}",
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
