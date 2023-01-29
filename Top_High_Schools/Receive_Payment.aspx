<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Receive_Payment.aspx.vb" Inherits="Top_High_Schools.Receive_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />

    <script type="text/javascript">
        function sum() {
            var txt1 = document.getElementById('<%= txtbaldue.ClientID %>').value;
            var txt2 = document.getElementById('<%= txtdiscount.ClientID %>').value;
            var txt3 = document.getElementById('<%= txtpayment.ClientID %>').value;
            var result = parseFloat(txt1) - parseFloat(txt2) - parseFloat(txt3);
            if (!isNaN(result)) {
                document.getElementById('<%= txtbalance.ClientID %>').value = result;
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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Receive Payments</h4>

    </div>

    <!-- Input rows -->

    <div class="row" id="rrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Payment Form (School Fees)</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="form-group row">

                                <div class="col-sm-4">
                                    <label for="inputEmail3">Student</label>
                                    <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="col-sm-4">
                                    <label for="inputEmail3">Class</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtclass" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>
                                <asp:TextBox runat="server" ID="txtclassid" Visible="false"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtstudid" Visible="false"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtclasstype" Visible="false"></asp:TextBox>
                            </div>

                            <div class="form-group row">


                                <div class="col-sm-2">
                                    <label for="inputPassword3">Fees</label>
                                    <asp:TextBox runat="server" Text="0.00" CssClass="form-control" ID="txtfees" onkeyup="sum()" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>

                                <div class="col-sm-2">
                                    <label for="inputPassword3">Arrears</label>
                                    <asp:TextBox runat="server" Text="0.00" CssClass="form-control" ID="txtarrears" onkeyup="sum()" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>

                                <div class="col-sm-2">
                                    <label for="inputEmail3">Balance Due</label>
                                    <asp:TextBox runat="server" Text="0.00" CssClass="form-control" ID="txtbaldue" onkeyup="sum()" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>

                                <div class="col-sm-2">
                                    <label for="inputPassword3">Amount Paid</label>
                                    <asp:TextBox runat="server" Text="0.00" CssClass="form-control" ID="txtpaid" onkeyup="sum()" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>

                                <div class="col-sm-2">
                                    <label for="inputPassword3">Apply Discount</label>
                                    <asp:TextBox runat="server" Text="0.00" CssClass="form-control" ID="txtdiscount" onkeyup="sum()"></asp:TextBox>
                                </div>

                                <div class="col-sm-2">
                                    <label for="inputPassword3">Payment</label>
                                    <asp:TextBox runat="server" Text="0.00" CssClass="form-control" ID="txtpayment" onkeyup="sum()"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">

                                <div class="col-sm-3">
                                    <label for="inputPassword3">Date</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtdate" TextMode="Date" required="true"></asp:TextBox>
                                </div>

                                <div class="col-sm-3">
                                    <label for="inputEmail3">Payment Status</label>
                                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Text="Unpaid" Value="Unpaid" />
                                        <asp:ListItem Text="Part Payment" Value="Part Payment" />
                                        <asp:ListItem Text="Paid" Value="Paid" />

                                    </asp:DropDownList>
                                </div>

                                <div class="col-sm-3">
                                    <label for="inputEmail3">Payment Method</label>
                                    <asp:DropDownList ID="ddlpaymeth" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                                </div>

                                <div class="col-sm-3">
                                    <label for="inputEmail3">Balance on credit</label>
                                    <asp:TextBox runat="server" Text="0.00" CssClass="form-control" ID="txtbalance" onkeyup="sum()" ReadOnly="true" BackColor="white"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-group row">

                                <div class="col-sm-12">
                                    <label for="inputPassword3">Description</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtdescription" required="true"></asp:TextBox>
                                </div>
                            </div>

                            <hr />

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlStudent" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnsave" runat="server" Text="Save & Print" class="btn btn-primary" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:HiddenField ID="txttimeago" runat="server" Value="1800-01-01" />
            <asp:HiddenField ID="txtCashAcc" runat="server" />
            <asp:HiddenField ID="txtReceAcc" runat="server" />
            <asp:HiddenField ID="txtAdmAcc" runat="server" />
            <asp:HiddenField ID="txtSchAcc" runat="server" />
            <asp:HiddenField ID="txtlinkcode" runat="server" />
            <asp:HiddenField ID="txtusers" runat="server" />
            <asp:HiddenField ID="txttimer" runat="server" />
            <asp:HiddenField ID="txtlocation" runat="server" />
            <asp:HiddenField ID="txtcomp" runat="server" />
            <asp:HiddenField ID="txtacayear" runat="server" />
            <asp:HiddenField ID="txtacaterm" runat="server" />
            <asp:HiddenField ID="txtacadate" runat="server" />
            <asp:HiddenField ID="txtstartdate" runat="server" />
            <asp:HiddenField ID="txtenddate" runat="server" />
            <asp:HiddenField ID="txtfont" runat="server" />
        </div>

    </div>

    <br />

    <script type="text/javascript">

        $('#ddlStudent').select2({
            placeholder: 'Select an option'
        });

        $('#ddlstatus').select2({
            placeholder: 'Select an option'
        });

        $('#ddlpaymeth').select2({
            placeholder: 'Select an option'
        });

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
                document.getElementById("rrow1").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
