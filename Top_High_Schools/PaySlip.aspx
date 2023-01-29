<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PaySlip.aspx.vb" Inherits="Top_High_Schools.PaySlip" %>

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

    <script type="text/javascript">
        function printPageArea(areaID) {
            var printContent = document.getElementById(areaID);
            var WinPrint = window.open('', '', 'width=800,height=800');
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
        <h4 class="h4 mb-0 text-gray-800">Pay Slip</h4>

    </div>


    <div class="row" id="prrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Pay Slip Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-3">
                            <label for="inputEmail3">Staff</label>
                            <asp:DropDownList ID="dplstaff" runat="server" CssClass="form-control" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputEmail3">Month</label>
                            <asp:DropDownList ID="dplmonths" runat="server" CssClass="form-control" ClientIDMode="Static">
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
                            <label id="lab1" runat="server">Year</label>
                            <asp:DropDownList ID="dplyear" runat="server" CssClass="form-control" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>

                        <asp:Button ID="txtadd" runat="server" Text="Search" class="btn btn-success float-right" OnClick="GetPayRollData" />

                    </div>


                    <hr />

                </div>

                <!-- /.card-body -->

                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />

    <div class="row" id="prrow2">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div id="printableArea" style="background-color: #FFFFFF">

                        <div class="form-group row">

                            <div class="col-sm-4">
                                <p><strong>Company Info</strong></p>
                                <p style="text-align: left">
                                    <asp:Label ID="lblcompname" runat="server" Text="info"></asp:Label>
                                    <br />
                                    <asp:Label ID="lbladress" runat="server" Text="info"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblcontacts" runat="server" Text="info"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblonline" runat="server" Text="info"></asp:Label>
                                </p>
                               
                            </div>

                            <hr />

                            <div class="col-sm-4">
                                <p><strong>Employee Info</strong></p>
                                <p style="text-align: left">
                                    <asp:Label ID="lblemp" runat="server" Text="info"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblempadd" runat="server" Text="info"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblempcont" runat="server" Text="info"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblbnkname" runat="server" Text="info"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblacname" runat="server" Text="info"></asp:Label>
                                    <br />
                                     <asp:Label ID="lblacnum" runat="server" Text="info"></asp:Label>
                                </p>
                            
                            </div>

                            <div class="col-sm-4">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="PAY DATE" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="PAY TYPE" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="PERIOD" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtdate" runat="server" TextMode="Date" required="true" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td>Monthly</td>
                                        <td>Days 30</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="PAYROLL #" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="NI NUMBER" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text="TAX CODE" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpnum" runat="server" Text="0"></asp:Label></td>
                                        <td>MHC89332</td>
                                        <td>1250L</td>
                                    </tr>
                                </table>
                            </div>

                        </div>

                        <hr />

                        <div class="form-group row">

                            <div class="col-sm-4">
                            </div>

                            <div class="col-sm-4">
                            </div>

                            <div class="col-sm-4">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>Payment Method</td>
                                        <td>
                                            <asp:CheckBox ID="CheckBox1" Text="Cheque" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="CheckBox2" Text="Cash" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="CheckBox3" Text="Bank Transfer" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </div>

                        <hr />

                        <div class="table-responsive">
                            <table class="table">
                                <thead class="text-primary" id="actstu">
                                    <tr>
                                        <th scope="col" align="left">EARNING</th>
                                        <th></th>
                                        <th scope="col" align="left">HOURS</th>
                                        <th></th>
                                        <th scope="col" align="left">RATE</th>
                                        <th></th>
                                        <th scope="col" align="left">CURRENT</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Basic Salary
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtbhour" runat="server" CssClass="form-control" Text="" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtbrate" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtbcurrent" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Allowances
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtahour" runat="server" CssClass="form-control" Text="" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtarate" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtacurrent" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Overtime Pay
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtohour" runat="server" CssClass="form-control" Text="" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtorate" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtocurrent" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Holiday Pay
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txthhour" runat="server" CssClass="form-control" Text="" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txthrate" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txthcurrent" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Commission and Bonus
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtcbhour" runat="server" CssClass="form-control" Text="" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtcbrate" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtcbcurrent" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Sick Pay
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtshour" runat="server" CssClass="form-control" Text="" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtsrate" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtscurrent" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Expenses
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtehour" runat="server" CssClass="form-control" Text="" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txterate" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtecurrent" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="GROSS PAY" Style="color: black" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtgross" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table">
                                <thead class="text-primary" id="tblgross">
                                    <tr>
                                        <th scope="col" align="left">DEDUCTIONS</th>
                                        <th></th>
                                        <th scope="col" align="left">
                                            <asp:Label ID="lbl1" Text ="" runat ="server" ></asp:Label>
                                        </th>
                                        <th></th>
                                        <th scope="col" align="left">
                                            <asp:Label ID="Label3" Text ="" runat ="server" ></asp:Label>
                                        </th>
                                        <th></th>
                                        <th scope="col" align="left">CURRENT</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>PAYE Tax
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox22" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox23" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td >
                                            <asp:TextBox ID="txtpaye" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>SSNIT
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtsnnit" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Loan Repayment
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtloan" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Pension
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtpension" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Union Fee
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" Text="" BorderStyle="None" ReadOnly="true" BackColor="White"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtunion" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="TOTAL DEDUCTION" Style="color: black" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txttotdeduct" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="NET PAY" Style="color: black" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtnet" runat="server" CssClass="form-control" Text="0" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <hr />

                    </div>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnsave" runat="server" Text="Print" class="btn btn-primary float-right" OnClientClick="printPageArea('printableArea')" />
                </div>
                <!-- /.card-footer -->
            </div>

            <asp:HiddenField ID="txtfont" runat="server" />
        </div>

    </div>

    <br />

    <script type="text/javascript">

        $('#dplstaff').select2({
            placeholder: 'Select an option'
        });

        $('#dplmonths').select2({
            placeholder: 'Select an option'
        });

        $('#dplyear').select2({
            placeholder: 'Select an option'
        });

        $('#dplpaymeth').select2({
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
                document.getElementById("prrow1").style.fontFamily = fontstyle;
                document.getElementById("prrow2").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
