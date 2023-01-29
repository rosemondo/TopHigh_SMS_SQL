<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Bank_Transaction.aspx.vb" Inherits="Top_High_Schools.Bank_Transaction" %>

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

        .capitalize {
            text-transform: capitalize;
        }
    </style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Transactions</h4>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#MyPopup">
                        Set-up</button>

                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div>

                        <asp:Repeater ID="rptstudent" runat="server">
                            <HeaderTemplate>
                                <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th scope="col">Date</th>
                                            <th scope="col">Accounts Name</th>
                                            <th scope="col">Account #</th>
                                            <th scope="col">Transaction</th>
                                            <th scope="col">Debit</th>
                                            <th scope="col">Credit</th>
                                            <th scope="col">Bank</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("depdate", "{0: yyyy-MM-dd}") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("accname") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblODB" runat="server" Text='<%# Eval("accnum") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("details") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("debit", "{0:N2}") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("credit", "{0:N2}") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("bank") %>' /></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                    </div>

                </div>
 
                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />

    <!-- Modal Popup bank setup-->
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h5 class="card-title">New Account</h5>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">

                                    <div class="form-group row">

                                        <div class="col-sm-12">
                                            <label for="inputPassword3">Bank Name</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtbank" required="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-12">
                                            <label for="inputEmail3">A/c Name</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtacname"></asp:TextBox>
                                        </div>

                                        <asp:TextBox runat="server" ID="txtcode" Visible="false"></asp:TextBox>
                                    </div>

                                    <div class="form-group row">
                                        <div class="col-sm-12">
                                            <label for="inputEmail3">A/c Number</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtnumber"></asp:TextBox>
                                        </div>

                                    </div>

                                    <div class="form-group row">

                                        <div class="col-sm-6">
                                            <label for="inputEmail3">Date</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtbkdate" TextMode="Date"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-6">
                                            <label for="inputPassword3">A/c Balance</label>
                                            <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtbkamt"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">

                                        <div class="col-sm-12">
                                            <label for="inputPassword3">Description</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdescription" required="true"></asp:TextBox>
                                        </div>
                                    </div>

                                    <hr />

                                </div>

                                <!-- /.card-body -->
                                <div class="card-footer">
                                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary"/>
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
                        </div>

                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Popup bank setup-->
       
     <asp:HiddenField ID="txtfont" runat="server" />

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
