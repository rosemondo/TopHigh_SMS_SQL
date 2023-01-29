<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Transfers.aspx.vb" Inherits="Top_High_Schools.Transfers" %>

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
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h4 class="h4 mb-0 text-gray-800" id="tbt">Bank Transfers</h4>

    </div>

    <!-- Input rows -->

    <div class="row" id="rowid">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title" id="ttsf">Transfers</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-6">
                            <label for="inputPassword3" id="tbf">Bank From</label>
                            <asp:DropDownList ID="dplbankname" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                            <label for="inputPassword3" id="tbkt">Bank To</label>
                            <asp:DropDownList ID="dplbnkto" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label for="inputEmail3" id="tacf">A/c From</label>
                            <asp:DropDownList ID="dplacname" runat="server" CssClass="form-control" onchange="getAcNum()" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <div class="col-sm-6">
                            <label for="inputEmail3" id="tact">A/c To</label>
                            <asp:DropDownList ID="ddlgen" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="getAcNumto()"></asp:DropDownList>
                        </div>

                    </div>

                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label for="inputEmail3" id="tacnumf">A/c Number From</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtacnum" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label for="inputEmail3" id="tacnumt">A/c Number To</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtnumto" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">

                        <div class="col-sm-6">
                            <label for="inputEmail3" id="tdt">Date</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdepdate" TextMode="Date" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-6">
                            <label for="inputPassword3" id="tamt">Amount</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtdepamt"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-12">
                            <label for="inputPassword3" id="tdesc">Description</label>
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
        <asp:HiddenField ID="txtfont" runat="server" />
    </div>


    <br />

    <script type="text/javascript">

        $('#dplbankname').select2({
            placeholder: 'Select an option'
        });

        $('#dplbnkto').select2({
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
                url: "/Transfers.aspx/GetAcnumber",
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

        function getAcNumto() {
            var acname = $("[id*=ddlgen]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Transfers.aspx/GetAcnumber",
                data: "{acname:'" + acname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtnumto]').val(data.d.AccNumber);
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };

    </script>

    <script type ="text/javascript">

        $("#btnSave").click(function () {
            var txtdepdate = $.trim($('#<%=txtdepdate.ClientID %>').val());
            var ddlgen = $.trim($('#<%=ddlgen.ClientID %>').val());
            var txtnumto = $.trim($('#<%=txtnumto.ClientID %>').val());
            var txtdepdes = $.trim($('#<%=txtdepdes.ClientID %>').val());
            var txtdepamt = $.trim($('#<%=txtdepamt.ClientID %>').val());
            var dplbnkto = $.trim($('#<%=dplbnkto.ClientID %>').val());
            $.ajax({
                type: "POST",
                url: "/Transfers.aspx/insert_deposit_to",
                data: "{txtdepdate: '" + txtdepdate + "','ddlgen':'" + ddlgen + "','txtnumto':'" + txtnumto + "','txtdepdes':'" + txtdepdes + "','txtdepamt':'" + txtdepamt + "','dplbnkto':'" + dplbnkto + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    insertwithdrawfrom()
                }
            });

        });

        function insertwithdrawfrom() {
            var txtdepdate = $.trim($('#<%=txtdepdate.ClientID %>').val());
            var dplacname = $.trim($('#<%=dplacname.ClientID %>').val());
            var txtacnum = $.trim($('#<%=txtacnum.ClientID %>').val());
            var txtdepdes = $.trim($('#<%=txtdepdes.ClientID %>').val());
            var txtdepamt = $.trim($('#<%=txtdepamt.ClientID %>').val());
            var dplbankname = $.trim($('#<%=dplbankname.ClientID %>').val());
            $.ajax({
                type: "POST",
                url: "/Transfers.aspx/insert_withdraw_from",
                data: "{txtdepdate: '" + txtdepdate + "','dplacname':'" + dplacname + "','txtacnum':'" + txtacnum + "','txtdepdes':'" + txtdepdes + "','txtdepamt':'" + txtdepamt + "','dplbankname':'" + dplbankname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    Insert_JV_Deb()
                }
            });

        };

        function Insert_JV_Deb() {
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());
            var txtdepdate = $.trim($('#<%=txtdepdate.ClientID %>').val());
            var dplacname = $.trim($('#<%=dplacname.ClientID %>').val());
            var txtdepamt = $.trim($('#<%=txtdepamt.ClientID %>').val());
            var txttimer = $.trim($('#<%=txttimer.ClientID %>').val());
            var txtusers = $.trim($('#<%=txtusers.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Transfers.aspx/Insert_JV_Depo_Credit",
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
                url: "/Transfers.aspx/Insert_JV_Depo_Debit",
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

                document.getElementById("tbt").style.fontFamily = fontstyle;
                document.getElementById("rowid").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
