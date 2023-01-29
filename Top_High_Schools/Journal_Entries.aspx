<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Journal_Entries.aspx.vb" Inherits="Top_High_Schools.Journal_Entries" %>

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
        <h4 class="h4 mb-0 text-gray-800">Journal Entry</h4>

    </div>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="row" id="nabyrow1">
                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title">Account Form</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">

                                <label for="inputEmail3" class="col-sm-2 col-form-label">Journal Code</label>
                                <div class="col-sm-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtjvcode" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 col-form-label">Date</label>
                                <div class="col-sm-5">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtdate" TextMode="Date" required="true"></asp:TextBox>
                                </div>
                                <asp:TextBox runat="server" ID="txtclassid" Visible="false"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtstudid" Visible="false"></asp:TextBox>
                            </div>
                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Debit A/c</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddldebit" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                                <label for="inputPassword3" class="col-sm-1 col-form-label">Credit A/c</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlcredit" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Description</label>
                                <div class="col-sm-5">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtdescription" requied="true"></asp:TextBox>
                                </div>
                                <label for="inputPassword3" class="col-sm-1 col-form-label">Amount</label>
                                <div class="col-sm-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtamount" Text="0"></asp:TextBox>
                                </div>
                            </div>


                            <hr />



                        </div>

                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:Button ID="txtadd" runat="server" Text="Add to List" class="btn btn-success float-right" />
                        </div>
                        <!-- /.card-footer -->
                    </div>

                </div>

            </div>

            <br />

            <div class="row" id="phrow3">
                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="text-primary" id="actstu">
                                        <tr>
                                            <th>Date</th>
                                            <th>Accounts</th>
                                            <th>Description</th>
                                            <th>Debit</th>
                                            <th>Credit</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="journalDB" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbldate" runat="server" Text='<%# Eval("jv_date", "{0:yyyy-MM-dd}")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblaccount" runat="server" Text='<%# Eval("jv_account")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("description")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbldebit" runat="server" Text='<%# Eval("debit", "{0:N2}")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcredit" runat="server" Text='<%# Eval("credit", "{0:N2}")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>

                            <hr />


                        </div>

                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:Button ID="btnsave" runat="server" Text="Process Jounals" class="btn btn-primary float-right" />
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
                </div>

            </div>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtadd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="txtfont" runat="server" />

    <br />

    <script type="text/javascript">

        $('#ddldebit').select2({
            placeholder: 'Select an option'
        });

        $('#ddlcredit').select2({
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
                document.getElementById("nabyrow1").style.fontFamily = fontstyle;
                document.getElementById("phrow3").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>


</asp:Content>
