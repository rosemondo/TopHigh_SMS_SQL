<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Bank_Reconceliation.aspx.vb" Inherits="Top_High_Schools.Bank_Reconceliation" %>

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

        .capitalize {
            text-transform: capitalize;
        }
    </style>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Bank Reconceliation</h4>

    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Reconceliation Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label for="inputEmail3">Date</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdate" required="true" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">

                        <div class="col-sm-5">
                            <label for="inputPassword3">Bank</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlbank" AutoPostBack="true" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <div class="col-sm-5">
                            <label for="inputPassword3">Account Name</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlaccname" AutoPostBack="true" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                    </div>

                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label for="inputPassword3">Account Number</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtaccnum" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">

                        <div class="col-sm-5">
                            <label for="inputPassword3">Open Balance</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtObal" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>

                        <div class="col-sm-5">
                            <label for="inputPassword3">Current Balance</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtcurbal" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group row">

                        <div class="col-sm-5">
                            <label for="inputEmail3">Income or Expense</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlexpinc" AutoPostBack="true" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <div class="col-sm-5">
                            <label for="inputEmail3">Amount</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtamount" Text="0.00"></asp:TextBox>
                        </div>

                    </div>

                     <div class="form-group row">

                        <div class="col-sm-10">
                            <label for="inputEmail3">Description</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdescription" required="true"></asp:TextBox>
                        </div>

                    </div>

                </div>

            </div>
            <!-- /.card-body -->
            <div class="card-footer">
                <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
            </div>
            <!-- /.card-footer -->
        </div>


    </div>


    <asp:TextBox ID="txtdateyear" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtdays" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtmonths" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtmyID" runat="server" Visible="false" BackColor="#FFFF99"></asp:TextBox>
    <asp:TextBox ID="txtcheck" runat="server" Visible="False"></asp:TextBox>
    <asp:TextBox ID="txtusers" runat="server" Visible="False"></asp:TextBox>
    <asp:TextBox ID="txtlocation" runat="server" Visible="False"></asp:TextBox>
    <asp:TextBox ID="txttimer" runat="server" Visible="False"></asp:TextBox>
    <asp:HiddenField ID="txtfont" runat="server" />

    <br />

    <script type="text/javascript">

        $('#ddlexpinc').select2({
            placeholder: 'Select an option'
        });

        $('#ddlaccname').select2({
            placeholder: 'Select an option'
        });

        $('#ddlbank').select2({
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

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>


</asp:Content>
