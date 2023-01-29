<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Pay_roll_process.aspx.vb" Inherits="Top_High_Schools.Pay_roll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="jquery.min_11.js"></script>

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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id ="myhd">
        <h4 class="h4 mb-0 text-gray-800">Payroll Process</h4>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i></a>
    </div>

    <div class="row" id="pprow1">
        
       
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

                        <div class="col-sm-6">
                            <asp:Label ID="Label2" runat="server" class="col-form-label" Text="Months"></asp:Label>
                            <asp:DropDownList ID="dplmonths" CssClass="form-control" runat="server" required="true" ClientIDMode="Static">
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

                        <div class="col-sm-6">
                            <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Year"></asp:Label>
                            <asp:DropDownList ID="ddlacayear" CssClass="form-control" runat="server" required="true" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>

                        <asp:HiddenField ID="txtSnRate5" runat="server" />

                        <asp:HiddenField ID="txsntempyer" runat="server" />

                        <asp:HiddenField ID="txtsnttier1" runat="server" />

                        <asp:HiddenField ID="txttteetier2" runat="server" />

                        <asp:HiddenField ID="txtpftier3" runat="server" />

                        <asp:HiddenField ID="txt365" runat="server" />
                        <asp:HiddenField ID="txt0" runat="server" />
                        <asp:HiddenField ID="txt110" runat="server" />
                        <asp:HiddenField ID="txt5" runat="server" />
                        <asp:HiddenField ID="txt130" runat="server" />
                        <asp:HiddenField ID="txt10" runat="server" />
                        <asp:HiddenField ID="txt3000" runat="server" />
                        <asp:HiddenField ID="txt17" runat="server" />
                        <asp:HiddenField ID="txt16395" runat="server" />
                        <asp:HiddenField ID="txt25" runat="server" />
                        <asp:HiddenField ID="txt20000" runat="server" />
                        <asp:HiddenField ID="txt30" runat="server" />



                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id ="pprow2">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
            <%--        <input type="button" id="btnprocess" value="Process" class="btn btn-success float-right" />--%>
                </div>

                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="table-responsive">

                        <asp:Repeater ID="rptPayRoll" runat="server">
                            <HeaderTemplate>
                                <table id="tblPayroll" class="table table-bordered table-striped table-responsive-sm" cellspacing="0" width="100%">
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
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblstaff" runat="server" Text='<%# Eval("Employee")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbasicsal" CssClass="form-control" runat="server" ReadOnly="true" BackColor="White" Text='<%# Eval("bisac_sal")%>' />
                                        <asp:Label ID="lblsalsub" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtallowance" CssClass="form-control" runat="server" ReadOnly="true" BackColor="White" Text='<%# Eval("allowances")%>'></asp:TextBox>
                                        <asp:Label ID="lbl5p" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                        <asp:Label ID="lbl10p" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                        <asp:Label ID="lbl17p" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                        <asp:Label ID="lbl25p" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                        <asp:Label ID="lbl30p" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                    <td>
                                        <asp:Label ID="lblgross" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                        <asp:Label ID="lblsalsecsub" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblssnit" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                        <asp:Label ID="lblthirdsub" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblssnitemp" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                        <asp:Label ID="lblfourthdsub" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblssnittier1" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                        <asp:Label ID="lblfifthdsub" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltrusteetier2" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                        <asp:Label ID="lblsixthdsub" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpfcont" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtpaye" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtloan" CssClass="form-control" runat="server" Text="0"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblnet" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                      <asp:Button ID="btn_Gen" runat="server" Text="Save" class="btn btn-primary" Style="float: right" OnClick="InsertPayRoll"/>
                   <%-- <input type="button" id="btnSave" value="Save" class="btn btn-primary float-right" />--%>
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

        $('#ddlstaff').select2({
            placeholder: 'Select an option'
        });

        $('#dplmonths').select2({
            placeholder: 'Select an option'
        });

        $('#ddlacayear').select2({
            placeholder: 'Select an option'
        });

    </script>

    <script type="text/javascript">

        $("#btnprocess").click(function () {
            var Srate = $.trim($('#<%=txtSnRate5.ClientID %>').val());
            var Semp = $.trim($('#<%=txsntempyer.ClientID %>').val());
            var Stier1 = $.trim($('#<%=txtsnttier1.ClientID %>').val());
            var Stier2 = $.trim($('#<%=txttteetier2.ClientID %>').val());
            var PFtier3 = $.trim($('#<%=txtpftier3.ClientID %>').val());
            $('[id*=tblPayroll] tr:has(td)').each(function () {
                var basicsal = $(this).find('[id*=txtbasicsal]').val();
                var allowance = $(this).find('[id*=txtallowance]').val();
                var paye = $(this).find('[id*=txtpaye]').val();
                var loan = $(this).find('[id*=txtloan]').val();
                $(this).find('[id*=lblgross]').html(parseFloat(basicsal) + parseFloat(allowance));
                $(this).find('[id*=lblssnit]').html((parseFloat(basicsal) * parseFloat(Srate)) / 100);
                $(this).find('[id*=lblssnitemp]').html((parseFloat(basicsal) * parseFloat(Semp)) / 100);
                $(this).find('[id*=lblssnittier1]').html((parseFloat(basicsal) * parseFloat(Stier1)) / 100);
                $(this).find('[id*=lbltrusteetier2]').html((parseFloat(basicsal) * parseFloat(Stier2)) / 100);
                $(this).find('[id*=lblpfcont]').html((parseFloat(basicsal) * parseFloat(PFtier3)) / 100);
                $(this).find('[id*=lblnet]').html((((((parseFloat(basicsal) + parseFloat(allowance))) - ((parseFloat(basicsal) * parseFloat(Srate)) / 100)) - ((parseFloat(basicsal) * parseFloat(PFtier3)) / 100)) - parseFloat(paye)) - parseFloat(loan));
            });
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
                document.getElementById("pprow1").style.fontFamily = fontstyle;
                document.getElementById("pprow2").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

<%--    <script type="text/javascript">

        $("#btnSave").click(function () {
            var Srate = $.trim($('#<%=txtSnRate5.ClientID %>').val());
            var Semp = $.trim($('#<%=txsntempyer.ClientID %>').val());
            var Stier1 = $.trim($('#<%=txtsnttier1.ClientID %>').val());
            var Stier2 = $.trim($('#<%=txttteetier2.ClientID %>').val());
            var PFtier3 = $.trim($('#<%=txtpftier3.ClientID %>').val());
            var Pmonth = $.trim($('#<%=dplmonths.ClientID %>').val());
            $('[id*=tblPayroll] tr:has(td)').each(function () {
                var staff = $(this).find('[id*=lblstaff]').text();
                var basicsal = $(this).find('[id*=txtbasicsal]').val();
                var allowance = $(this).find('[id*=txtallowance]').val();
                var gross = $(this).find('[id*=lblgross]').text();
                var paye = $(this).find('[id*=txtpaye]').val();
                var loan = $(this).find('[id*=txtloan]').val();

                $.ajax({
                    type: "POST",
                    url: "/Pay_roll_process.aspx/SavePayRoll",
                    data: "{'staff':'" + staff + "','basicsal':'" + basicsal + "','allowance':'" + allowance + "','gross':'" + gross + "','Srate':'" + Srate + "','Semp':'" + Semp + "','Stier1':'" + Stier1 + "','Stier2':'" + Stier2 + "','PFtier3':'" + PFtier3 + "','paye':'" + paye + "','loan':'" + loan + "','Pmonth':'" + Pmonth + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {
                    }
                });

            });
        });

    </script>--%>

</asp:Content>
