<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Pay_roll.aspx.vb" Inherits="Top_High_Schools.Pay_roll1" %>

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
    </style>

    <script type="text/javascript">
        function printPageArea(areaID) {
            var printContent = document.getElementById(areaID);
            var WinPrint = window.open('', '', 'width=1000,height=1000');
            WinPrint.document.write(printContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Payroll Process</h4>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i></a>
    </div>

    <div class="row" id ="pyrow1">
        <div class="col-md-12">
            <div class="card card-info">
                <div class="card-header">
                    <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                        class="fa fa-list fa-sm text-white-50"></i></a>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">


                    <div class="form-group row">

                        <div class="col-sm-3">
                            <asp:Label ID="Label2" runat="server" class="col-form-label" Text="Month"></asp:Label>
                            <asp:DropDownList ID="dplmonths" CssClass="form-control" runat="server" required="true" AutoPostBack="true" ClientIDMode="Static">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>January</asp:ListItem>
                                <asp:ListItem>February</asp:ListItem>
                                <asp:ListItem>March</asp:ListItem>
                                <asp:ListItem>April</asp:ListItem>
                                <asp:ListItem>May</asp:ListItem>
                                <asp:ListItem>June</asp:ListItem>
                                <asp:ListItem>July</asp:ListItem>
                                <asp:ListItem>August</asp:ListItem>
                                <asp:ListItem>September</asp:ListItem>
                                <asp:ListItem>October</asp:ListItem>
                                <asp:ListItem>November</asp:ListItem>
                                <asp:ListItem>December</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Year"></asp:Label>
                            <asp:DropDownList ID="dplyear" CssClass="form-control" runat="server" AutoPostBack="true" ClientIDMode="Static"></asp:DropDownList>
                        </div>


                    </div>



                </div>
            </div>
        </div>
    </div>

    <br />

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="pyrow2">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
                    <asp:Button ID="Button2" runat="server" Text="Print" Class="btn btn-success" OnClientClick="printPageArea('printableArea')" Style="float: right" />
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div id="printableArea" style="background-color: #FFFFFF">

                        <div class="table-responsive">
                            <table class="table table-bordered table-striped table-responsive-sm" cellspacing="0" width="100%">
                                <thead class="text-primary" id="actstu">
                                    <tr>
                                        <th>Staff</th>
                                        <th>Basic Salary</th>
                                        <th>Allowance</th>
                                        <th>Gross Salary</th>
                                        <th>Ssnit</th>
                                        <th>Ssnit Employer</th>
                                        <th>Ssnit (1st Tier)</th>
                                        <th>Trustee (2nd Tier)</th>
                                        <th>PF Contribution</th>
                                        <th>Paye</th>
                                        <th>Loan</th>
                                        <th>Net Salary</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterDB" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Employee")%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblbasicsal" runat="server" Text='<%# Eval("basic_salary", "{0:N2}")%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblallowance" runat="server" Text='<%# Eval("allowance", "{0:N2}")%>'></asp:Label>
                                                <td>
                                                    <asp:Label ID="txtgross" runat="server" Text='<%# Eval("gross_salary", "{0:N2}")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtsnnit" runat="server" Text='<%# Eval("snnit_tier_5", "{0:N2}")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtpaye" runat="server" Text='<%# Eval("ssnit_emp", "{0:N2}")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtloan" runat="server" Text='<%# Eval("ssnit_t1", "{0:N2}")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtnet" runat="server" Text='<%# Eval("rusteetier2", "{0:N2}")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("pfcont", "{0:N2}")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("paye", "{0:N2}")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("loan", "{0:N2}")%>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("net_salary", "{0:N2}")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>

                    </div>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlinkcode" runat="server" Visible="false"></asp:TextBox>
             <asp:HiddenField ID="txtfont" runat="server" />
        </div>
    </div>

    <script type="text/javascript">

        $('#dplmonths').select2({
            placeholder: 'Select an option'
        });

        $('#dplyear').select2({
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
                document.getElementById("pyrow1").style.fontFamily = fontstyle;
                document.getElementById("pyrow1").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
