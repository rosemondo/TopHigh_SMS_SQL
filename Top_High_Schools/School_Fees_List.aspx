<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="School_Fees_List.aspx.vb" Inherits="Top_High_Schools.School_Fees_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="select2/select2.min.css" rel="stylesheet" />
    <script src="select2/jquery.min.js"></script>
    <script src="select2/select2.min.js"></script>

    <script type="text/javascript">
        function printPageArea(areaID) {
            var printContent = document.getElementById(areaID);
            var WinPrint = window.open('', '', 'width=1500,height=1500');
            WinPrint.document.write(printContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }

        $(function () {
            $("#Select1").select2();
        });

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

        .capitalize {
            text-transform: capitalize;
        }

        .auto-style1 {
            height: 26px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">School Fees List (Full & Part Payment)</h4>

    </div>

    <div class="row" id="sfrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title"></h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-sm-3">
                            <label for="inputEmail3">Date From</label>
                            <asp:TextBox ID="txtdatefrom" runat="server" CssClass="form-control" required="true" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label for="inputEmail3">Date To</label>
                            <asp:TextBox ID="txtdateto" runat="server" CssClass="form-control" required="true" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label for="inputEmail3">Search by name</label>
                            <asp:DropDownList ID="ddlstudent" runat="server" CssClass="form-control" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkname" runat="server" Text="By Name" />
                            <br />
                            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary right" />
                            <asp:Button ID="Button1" runat="server" Text="Print" CssClass="btn btn-primary" OnClientClick="printPageArea('printableArea')" />
                        </div>
                    </div>

                </div>

            </div>

        </div>

    </div>

    <br />

    <div id="printableArea" style="background-color: #FFFFFF">


        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>


                <div class="table-responsive">

                    <asp:Repeater ID="rptReportMain" runat="server" OnItemDataBound="OnItemDataBound">


                        <ItemTemplate>


                            <table id="students" class="table table-bordered table-striped" border="0" cellspacing="0" width="100%">

                                <thead>

                                    <tr>
                                        <td colspan="6"></td>
                                    </tr>

                                    <tr>
                                        <td colspan="6">
                                            <hr style="border: thin dotted #000000" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="6" style="text-align: center" class="auto-style5">
                                            <asp:Label ID="Label11" runat="server" Text="School Fees List" Font-Bold="True" Font-Underline="true" Font-Size="large" Style="padding: 15px"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="6">
                                            <hr style="border: thin dotted #000000" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <th colspan="6" align="left">Date : 
                                    <asp:Label ID="lbldate" runat="server" Text='<%# Eval("col_date", "{0:yyyy-MM-dd}") %>' />
                                            <asp:Label ID="Label7" runat="server" Text=' , ' />
                                            <asp:Label ID="Label5" runat="server" Text='Academic Year :' />
                                            <asp:Label ID="lblyear" runat="server" Text='<%# Eval("aca_year") %>' />
                                            <asp:HiddenField ID="hfdate" runat="server" Value='<%# Eval("col_date", "{0:yyyy-MM-dd}") %>' />
                                            <asp:HiddenField ID="hfyear" runat="server" Value='<%# Eval("aca_year") %>' />
                                        </th>
                                    </tr>

                                    <tr>
                                        <td colspan="6">
                                            <hr style="border: thin dotted #000000" />
                                        </td>
                                    </tr>

                                    <tr style="border: thin">
                                        <th scope="col" align="left">Learner</th>
                                        <th scope="col" align="left">Amount</th>
                                        <th scope="col" align="left">Aca. Term</th>
                                        <th scope="col" align="left">Aca. Year</th>
                                        <th scope="col" align="left">Date</th>
                                        <th scope="col" align="left">System User</th>
                                    </tr>

                                    <tr>
                                        <td colspan="6">
                                            <hr style="border: thin dotted #000000" />
                                        </td>
                                    </tr>

                                </thead>


                                <asp:Repeater ID="rptRepoDetails" runat="server">

                                    <ItemTemplate>
                                        <tr style="border: thin">
                                            <td>
                                                <asp:Label ID="lblsubjects" runat="server" Text='<%# Eval("student_name") %>' Style="float: left" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblclass" runat="server" Text='<%# Eval("amount_paid", "{0:N2}") %>' Style="float: left" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("aca_term") %>' Style="float: left" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("aca_year") %>' Style="float: left" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("col_date", "{0:yyyy-MM-dd}") %>' Style="float: left" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("sys_user") %>' Style="float: left" />
                                            </td>
                                        </tr>

                                    </ItemTemplate>


                                </asp:Repeater>

                                <tr>
                                    <tr>
                                        <td colspan="6">
                                            <hr style="border: thin dotted #000000" />
                                        </td>
                                    </tr>
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="Totals :" Font-Bold="true" Style="float: left"></asp:Label></td>
                                    <td align="left">
                                        <asp:Label ID="lbltotbukets" runat="server" Text="0.00" Font-Bold="true" Style="float: left"></asp:Label></td>
                                    <td align="left">
                                        <asp:Label ID="lbltotcans" runat="server" Text="0.00" Font-Bold="true" Style="float: left"></asp:Label></td>
                                    <td align="left"></td>
                                    <td align="left"></td>
                                    <td align="left"></td>
                                </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>

                    </asp:Repeater>

                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnsearch" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>


        <br />

    </div>

    <asp:Button ID="Button2" runat="server" Text="Print" CssClass="form-control btn-primary" OnClientClick="printPageArea('printableArea')" />
    <asp:HiddenField ID="txtfont" runat="server" />
    <br />

    <script type="text/javascript">

        $('#ddlstudent').select2({
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
                document.getElementById("sfrow1").style.fontFamily = fontstyle;
                document.getElementById("printableArea").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
