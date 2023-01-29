<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Canteen_Collection.aspx.vb" Inherits="Top_High_Schools.Canteen_Collection" %>

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
        <h4 class="h4 mb-0 text-gray-800">Canteen Fee</h4>

    </div>

    <!-- Input rows -->

    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Canteen Collection Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="form-group row">

                                <div class="col-sm-8">
                                    <label for="inputEmail3">Student</label>
                                    <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                                </div>

                                <div class="col-sm-4">
                                    <label for="inputEmail3">Class</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtclass" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>
                                <asp:TextBox runat="server" ID="txtclassid" Visible="false"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtstudid" Visible="false"></asp:TextBox>
                            </div>
                            <div class="form-group row">

                                <div class="col-sm-3">
                                    <label for="inputEmail3">Amount</label>
                                    <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtamount" AutoPostBack="true"></asp:TextBox>
                                </div>

                                <div class="col-sm-3">
                                    <label for="inputPassword3">Canteen Fee</label>
                                    <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtcanteefees"></asp:TextBox>
                                </div>

                                <div class="col-sm-3">
                                    <label for="inputPassword3">Change</label>
                                    <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtchange" BackColor="White" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <label for="inputPassword3">No. of Days</label>
                                    <asp:TextBox runat="server" Text="0" CssClass="form-control" ID="txtdays" BackColor="White" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">

                                <div class="col-sm-4">
                                    <label for="inputPassword3">Start Date</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtstartdate" BackColor="White" ReadOnly="true" DateFormat="yyyy-MM-dd" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
                                </div>

                                <div class="col-sm-4">
                                    <label for="inputPassword3">End Date</label>
                                    <asp:TextBox ID="txtenddate" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtdate2" BackColor="White" ReadOnly="true" DateFormat="yyyy-MM-dd" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
                                </div>

                                <div class="col-sm-4">
                                    <label for="inputEmail3">Payment Status</label>
                                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control" ClientIDMode="Static">

                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Text="Advance Payment" Value="Unpaid" />
                                        <asp:ListItem Text="Paid" Value="Part Payment" />

                                    </asp:DropDownList>
                                </div>

                            </div>

                            <hr />

                             <script type="text/javascript">

                                 $('#ddlstatus').select2({
                                     placeholder: 'Select an option'
                                 });

                                 $('#ddlStudent').select2({
                                     placeholder: 'Select an option'
                                 });

                             </script>

                        </ContentTemplate>
                        <Triggers>
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

            <asp:HiddenField ID="txtfees" runat="server" Value="1" />
            <asp:TextBox ID="txtCashAcc" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtReceAcc" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlinkcode" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txttimer" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtacayear" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtacaterm" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtsat" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtsun" runat="server" Visible="false"></asp:TextBox>

            <asp:ListBox ID="ListBox1" runat="server" Visible="false"></asp:ListBox>

        </div>

    </div>

    <asp:HiddenField ID="txtfont" runat="server" />

    <br />

    <script type="text/javascript">

        $('#ddlstatus').select2({
            placeholder: 'Select an option'
        });

        $('#ddlStudent').select2({
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
