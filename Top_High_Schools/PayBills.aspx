<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PayBills.aspx.vb" Inherits="Top_High_Schools.PayBills" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Pay Bills</h4>
        <a href="Suppliers_List.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i>New Supplier</a>
    </div>

    <!-- Input rows -->

    <div class="row" id="prow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Payment Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">


                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Suppliers</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="ddlSuppliers" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlSuppliers_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <asp:TextBox runat="server" ID="txtclassid" Visible="false"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtstudid" Visible="false"></asp:TextBox>
                            </div>
                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Balance Due</label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtbaldue" onkeyup="sum()"></asp:TextBox>
                                </div>
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Amount Paid</label>
                                <div class="col-sm-3">
                                    <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtpaid" onkeyup="sum()"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Date</label>
                                <div class="col-sm-2">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtdate" TextMode="Date" required="true"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1.5 col-form-label">Payment Status</label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Text="Unpaid" Value="Unpaid" />
                                        <asp:ListItem Text="Part Payment" Value="Part Payment" />
                                        <asp:ListItem Text="Paid" Value="Paid" />

                                    </asp:DropDownList>
                                </div>
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Payment Method</label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlpaymeth" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Description</label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtdescription" required="true"></asp:TextBox>
                                </div>
                            </div>

                            <hr />

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlSuppliers" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>


                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:TextBox ID="txtCashAcc" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtReceAcc" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtAdmAcc" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtSchAcc" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlinkcode" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txttimer" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtcomp" Text="Test Comp" runat="server" Visible="false"></asp:TextBox>
            <asp:HiddenField ID="txtfont" runat="server" />
        </div>

    </div>

    <br />

    <script type="text/javascript">

        $('#ddlpaymeth').select2({
            placeholder: 'Select an option'
        });

        $('#ddlstatus').select2({
            placeholder: 'Select an option'
        });

        $('#ddlSuppliers').select2({
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
                document.getElementById("prow1").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
