<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admission.aspx.vb" Inherits="Top_High_Schools.Admission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />

    <script type="text/javascript">
        function sum() {
            var txt1 = document.getElementById('<%= txttuition.ClientID %>').value;
            var txt2 = document.getElementById('<%= txtadmission.ClientID %>').value;
            var txt3 = document.getElementById('<%= txtcanteen.ClientID %>').value;
            var txt4 = document.getElementById('<%= txtbusfee.ClientID %>').value;
            var txt5 = document.getElementById('<%= txtfirstaid.ClientID %>').value;
            var txt6 = document.getElementById('<%= txtpta.ClientID %>').value;
            var txt7 = document.getElementById('<%= txtothers.ClientID %>').value;
            var result = parseFloat(txt1) + parseFloat(txt2) + parseFloat(txt3) + parseFloat(txt4) + parseFloat(txt5) + parseFloat(txt6) + parseFloat(txt7);
            if (!isNaN(result)) {
                document.getElementById('<%= txttotals.ClientID %>').value = result;
                document.getElementById('<%= txtbaldue.ClientID %>').value = result;
            }
        }

        function paysum() {
            var txt1 = document.getElementById('<%= txttotals.ClientID %>').value;
            var txt2 = document.getElementById('<%= txtschfees.ClientID %>').value;
            var txt3 = document.getElementById('<%= txtadmfee.ClientID %>').value;
            var result = parseFloat(txt1) - parseFloat(txt2) - parseFloat(txt3);
            if (!isNaN(result)) {
                document.getElementById('<%= txtbaldue.ClientID %>').value = result;
            }
        }

    </script>

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
        <h4 class="h4 mb-0 text-gray-800">Admission & Payments (Assign class to learner)</h4>

    </div>

    <!-- Input rows -->

    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Payment Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">

                        <div class="col-sm-5">
                            <label for="inputEmail3">Class</label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" requide="true" ClientIDMode="Static" onchange="getFees()"></asp:DropDownList>
                        </div>

                        <div class="col-sm-5">
                            <label for="inputEmail3">Student</label>
                            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="getStudID()" requide="true"></asp:DropDownList>
                        </div>
                        <asp:HiddenField ID="txtclassid" runat="server" />
                        <asp:HiddenField ID="txttype" runat="server" />
                        <asp:HiddenField ID="txtstudid" runat="server" />
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-3">
                            <label for="inputEmail3">Tuition Fee</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txttuition" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputPassword3">Admission Fee</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtadmission" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputPassword3">Canteen Fee</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtcanteen" onkeyup="sum()"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">

                        <div class="col-sm-3">
                            <label for="inputPassword3">Bus Fee</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtbusfee" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputPassword3">First AID</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtfirstaid" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputPassword3">P.T.A</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtpta" onkeyup="sum()"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-3">
                            <label for="inputPassword3">Others</label>
                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtothers" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputPassword3">Totals</label>
                            <asp:TextBox ID="txttotals" runat="server" CssClass="form-control" DisplayFormatString="N2" Text="0.00" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputPassword3">Date</label>
                            <asp:TextBox ID="admidate" runat="server" TextMode="Date" required="true" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>

                    <hr />

                    <div class="form-group row">

                        <div class="col-sm-2">
                            <label for="inputPassword3">Pay School Fee</label>
                            <asp:TextBox ID="txtschfees" runat="server" CssClass="form-control" DisplayFormatString="N2" Text="0.00" onkeyup="paysum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <label for="inputPassword3">Pay Admission Fee</label>
                            <asp:TextBox ID="txtadmfee" runat="server" CssClass="form-control" DisplayFormatString="N2" Text="0.00" onkeyup="paysum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <label for="inputPassword3">Balance Due</label>
                            <asp:TextBox ID="txtbaldue" runat="server" CssClass="form-control" DisplayFormatString="N2" Text="0.00" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <label for="inputPassword3">Academic Year</label>
                            <asp:DropDownList ID="ddlacayear" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <div class="col-sm-2">
                            <label for="inputPassword3">Academic Term</label>
                            <asp:DropDownList ID="ddlacaterm" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <div class="col-sm-2">
                            <label for="inputPassword3">Exempted From</label>
                            <asp:DropDownList ID="ddlexempted" runat="server" CssClass="form-control" ClientIDMode="Static">

                                <asp:ListItem Text=" " Value=" " />
                                <asp:ListItem Text="School Fees" Value="School Fees" />
                                <asp:ListItem Text="Canteen" Value="Canteen" />

                            </asp:DropDownList>
                        </div>
                    </div>

                    <hr />

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

        </div>

    </div>

       <asp:HiddenField ID="txtfont" runat="server" />

    <br />

    <script type="text/javascript">

        $('#ddlClass').select2({
            placeholder: 'Select an option'
        });

        $('#ddlStudent').select2({
            placeholder: 'Select an option'
        });

        $('#ddlacayear').select2({
            placeholder: 'Select an option'
        });

        $('#ddlacaterm').select2({
            placeholder: 'Select an option'
        });

        $('#ddlexempted').select2({
            placeholder: 'Select an option'
        });



    </script>

    <script type="text/javascript">

        function getFees() {
            var classname = $("[id*=ddlClass]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Admission.aspx/GetFeesData",
                data: "{classname:'" + classname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtclassid]').val(data.d.ClassID);
                    $('[id*=txttuition]').val(data.d.TuitionFee);
                    $('[id*=txtadmission]').val(data.d.AdmissionFee);
                    $('[id*=txtcanteen]').val(data.d.CanteenFee);
                    $('[id*=txtbusfee]').val(data.d.BusFee);
                    $('[id*=txtfirstaid]').val(data.d.FirstAID);
                    $('[id*=txtpta]').val(data.d.PTA);
                    $('[id*=txtothers]').val(data.d.Others);
                    $('[id*=txttype]').val(data.d.ClassType);

                    var txt1 = document.getElementById('<%= txttuition.ClientID %>').value;
                    var txt2 = document.getElementById('<%= txtadmission.ClientID %>').value;
                    var txt3 = document.getElementById('<%= txtcanteen.ClientID %>').value;
                    var txt4 = document.getElementById('<%= txtbusfee.ClientID %>').value;
                    var txt5 = document.getElementById('<%= txtfirstaid.ClientID %>').value;
                    var txt6 = document.getElementById('<%= txtpta.ClientID %>').value;
                    var txt7 = document.getElementById('<%= txtothers.ClientID %>').value;
                    var result = parseFloat(txt1) + parseFloat(txt2) + parseFloat(txt3) + parseFloat(txt4) + parseFloat(txt5) + parseFloat(txt6) + parseFloat(txt7);
                    if (!isNaN(result)) {
                        document.getElementById('<%= txttotals.ClientID %>').value = result;
                        document.getElementById('<%= txtbaldue.ClientID %>').value = result;
                    }
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };


        function getStudID() {
            var studname = $("[id*=ddlStudent]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Admission.aspx/GetStudID",
                data: "{studname:'" + studname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtstudid]').val(data.d.StudentID);
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };

    </script>


    <script type="text/javascript">

       $("#btnSave").click(function () {
            var studid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var exempted = $.trim($('#<%=ddlexempted.ClientID %>').val());
            $.ajax({
                type: "POST",
                url: "/Admission.aspx/InsertExemption",
                data: "{studid: '" + studid + "','exempted':'" + exempted + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    InsertAdmissionCollection()
                }
            });

        });

        function InsertAdmissionCollection() {
            var admidate = $.trim($('#<%=admidate.ClientID %>').val());
            var txttuition = $.trim($('#<%=txttuition.ClientID %>').val());
            var txtadmission = $.trim($('#<%=txtadmission.ClientID %>').val());
            var txtcanteen = $.trim($('#<%=txtcanteen.ClientID %>').val());
            var txtbusfee = $.trim($('#<%=txtbusfee.ClientID %>').val());
            var txtfirstaid = $.trim($('#<%=txtfirstaid.ClientID %>').val());
            var txtpta = $.trim($('#<%=txtpta.ClientID %>').val());
            var txtothers = $.trim($('#<%=txtothers.ClientID %>').val());
            var txttotals = $.trim($('#<%=txttotals.ClientID %>').val());
            var txtschfees = $.trim($('#<%=txtschfees.ClientID %>').val());
            var txtadmfee = $.trim($('#<%=txtadmfee.ClientID %>').val());
            var txtclassid = $.trim($('#<%=txtclassid.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var txtusers = $.trim($('#<%=txtusers.ClientID %>').val());
            var ddlacaterm = $.trim($('#<%=ddlacaterm.ClientID %>').val());
            var ddlacayear = $.trim($('#<%=ddlacayear.ClientID %>').val());
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Admission.aspx/InsertAdmissionCollection",
                data: "{admidate: '" + admidate + "','txttuition':'" + txttuition + "','txtadmission':'" + txtadmission + "','txtcanteen':'" + txtcanteen + "','txtbusfee':'" + txtbusfee + "','txtfirstaid':'" + txtfirstaid + "','txtpta':'" + txtpta + "','txtothers':'" + txtothers + "','txttotals':'" + txttotals + "','txtschfees':'" + txtschfees + "','txtadmfee':'" + txtadmfee + "','txtclassid':'" + txtclassid + "','txtstudid':'" + txtstudid + "','txtusers':'" + txtusers + "','ddlacaterm':'" + ddlacaterm + "','ddlacayear':'" + ddlacayear + "','txtlinkcode':'" + txtlinkcode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    Insertfeecollection()
                }
            });

        };

        function Insertfeecollection() {
            var admidate = $.trim($('#<%=admidate.ClientID %>').val());
            var txtschfees = $.trim($('#<%=txtschfees.ClientID %>').val());
            var txtusers = $.trim($('#<%=txtusers.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var txtadmission = $.trim($('#<%=txtadmission.ClientID %>').val());
            var ddlacaterm = $.trim($('#<%=ddlacaterm.ClientID %>').val());
            var ddlacayear = $.trim($('#<%=ddlacayear.ClientID %>').val());
            var txtadmfee = $.trim($('#<%=txtadmfee.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Admission.aspx/Insert_fee_collection",
                data: "{admidate: '" + admidate + "','txtschfees':'" + txtschfees + "','txtusers':'" + txtusers + "','txtstudid':'" + txtstudid + "','txtadmission':'" + txtadmission + "','ddlacaterm':'" + ddlacaterm + "','ddlacayear':'" + ddlacayear + "','txtadmfee':'" + txtadmfee + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    InsertCurrentClass()
                }
            });

        };

        function InsertCurrentClass() {
            var admidate = $.trim($('#<%=admidate.ClientID %>').val());
            var txtclassid = $.trim($('#<%=txtclassid.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var ddlacaterm = $.trim($('#<%=ddlacaterm.ClientID %>').val());
            var ddlacayear = $.trim($('#<%=ddlacayear.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Admission.aspx/InsertCurrentClass",
                data: "{admidate: '" + admidate + "','txtclassid':'" + txtclassid + "','txtstudid':'" + txtstudid + "','ddlacaterm':'" + ddlacaterm + "','ddlacayear':'" + ddlacayear + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    InsertFinances()
                }
            });

        };

        function InsertFinances() {
            var admidate = $.trim($('#<%=admidate.ClientID %>').val());
            var txttuition = $.trim($('#<%=txttuition.ClientID %>').val());
            var txtadmission = $.trim($('#<%=txtadmission.ClientID %>').val());
            var txttotals = $.trim($('#<%=txttotals.ClientID %>').val());
            var txtschfees = $.trim($('#<%=txtschfees.ClientID %>').val());
            var txtadmfee = $.trim($('#<%=txtadmfee.ClientID %>').val());
            var txtCashAcc = $.trim($('#<%=txtCashAcc.ClientID %>').val());
            var txtReceAcc = $.trim($('#<%=txtReceAcc.ClientID %>').val());
            var txtusers = $.trim($('#<%=txtusers.ClientID %>').val());
            var txtSchAcc = $.trim($('#<%=txtSchAcc.ClientID %>').val());
            var txtAdmAcc = $.trim($('#<%=txtAdmAcc.ClientID %>').val());
            var txttimer = $.trim($('#<%=txttimer.ClientID %>').val());
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Admission.aspx/InsertFinances",
                data: "{admidate: '" + admidate + "','txttuition':'" + txttuition + "','txtadmission':'" + txtadmission + "','txttotals':'" + txttotals + "','txtschfees':'" + txtschfees + "','txtadmfee':'" + txtadmfee + "','txtCashAcc':'" + txtCashAcc + "','txtReceAcc':'" + txtReceAcc + "','txtusers':'" + txtusers + "','txtSchAcc':'" + txtSchAcc + "','txtAdmAcc':'" + txtAdmAcc + "','txttimer':'" + txttimer + "','txtlinkcode':'" + txtlinkcode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    insertcreditstatmenttuition()
                }
            });

        };

        function insertcreditstatmenttuition() {
            var admidate = $.trim($('#<%=admidate.ClientID %>').val());
            var txttuition = $.trim($('#<%=txttuition.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Admission.aspx/Insert_tuition",
                data: "{admidate: '" + admidate + "','txttuition':'" + txttuition + "','txtstudid':'" + txtstudid + "','txtlinkcode':'" + txtlinkcode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    insertcreditstatmentadmission()
                }
            });
        };

        function insertcreditstatmentadmission() {
            var admidate = $.trim($('#<%=admidate.ClientID %>').val());
            var txtadmission = $.trim($('#<%=txtadmission.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Admission.aspx/Insert_admission",
                data: "{admidate: '" + admidate + "','txtadmission':'" + txtadmission + "','txtstudid':'" + txtstudid + "','txtlinkcode':'" + txtlinkcode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    insertcreditstatmentpayfees()
                }
            });
        };

        function insertcreditstatmentpayfees() {
            var admidate = $.trim($('#<%=admidate.ClientID %>').val());
            var txtschfees = $.trim($('#<%=txtschfees.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Admission.aspx/Insert_payfes",
                data: "{admidate: '" + admidate + "','txtschfees':'" + txtschfees + "','txtstudid':'" + txtstudid + "','txtlinkcode':'" + txtlinkcode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    insertcreditstatmentpayadmi()
                }
            });
        };

        function insertcreditstatmentpayadmi() {
            var admidate = $.trim($('#<%=admidate.ClientID %>').val());
            var txtadmfee = $.trim($('#<%=txtadmfee.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());
            var txtlinkcode = $.trim($('#<%=txtlinkcode.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Admission.aspx/Insert_payadmi",
                data: "{admidate: '" + admidate + "','txtadmfee':'" + txtadmfee + "','txtstudid':'" + txtstudid + "','txtlinkcode':'" + txtlinkcode + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    alert("Save Success!");
                    myredirect()
                }
            });
        };

        function myredirect() {
            var tuit = document.getElementById('<%= txttuition.ClientID %>').value;
            var admi = document.getElementById('<%= txtadmission.ClientID %>').value;
            var tot = document.getElementById('<%= txttotals.ClientID %>').value;
            var schfe = document.getElementById('<%= txtschfees.ClientID %>').value;
            var admife = document.getElementById('<%= txtadmfee.ClientID %>').value;
            var baldu = document.getElementById('<%= txtbaldue.ClientID %>').value;
            var stu = document.getElementById('<%= ddlStudent.ClientID %>').value;
            var cls = document.getElementById('<%= ddlClass.ClientID %>').value;
            var dtes = document.getElementById('<%= admidate.ClientID %>').value;
            var num = document.getElementById('<%= txtlinkcode.ClientID %>').value;

            window.location.href = "/Admission_Receipt.aspx?tuit=" + tuit + "&admi=" + admi + "&tot=" + tot + "&schfe=" + schfe + "&admife=" + admife + "&baldu=" + baldu + "&stu=" + stu + "&cls=" + cls + "&dtes=" + dtes + "&num=" + num;

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
