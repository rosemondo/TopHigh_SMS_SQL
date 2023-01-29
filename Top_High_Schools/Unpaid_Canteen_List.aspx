<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Unpaid_Canteen_List.aspx.vb" Inherits="Top_High_Schools.Unpaid_Canteen_List" %>

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

        .Grid, .ChildGrid {
            border: 1px solid #ccc;
        }

            .Grid td, .Grid th {
                border: 1px solid #ccc;
            }

            .Grid th {
                background-color: #B8DBFD;
                color: #333;
                font-weight: bold;
            }

            .ChildGrid td, .ChildGrid th {
                border: 1px solid #ccc;
            }

            .ChildGrid th {
                background-color: #ccc;
                color: #333;
                font-weight: bold;
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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Canteen Debtors List</h4>
        <a href="Canteen_Collection.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i>New Canteen</a>
    </div>


    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header" id="mycard">
                    <asp:Button ID="Button2" runat="server" Text="Print" Class="btn btn-primary" OnClientClick="printPageArea('printableArea')" Style="float: right" />
                    <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" TextMode="Date" required="true" DateFormat="yyyy-MM-dd" DisplayDateFormat="yyyy-MM-dd" Style="float: left; width: 180px; margin: 5px"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" Class="btn btn-primary" Style="float: left; margin: 5px" />
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Exemption_Unpaid_List.aspx" Style="color: white; padding: 5px; margin: 5px">Exemption List</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink3" runat="server" Style="color: white; padding: 5px; margin: 5px" NavigateUrl="~/Unpaid_Canteen_List.aspx">Canteen Debtors</asp:HyperLink>
                </div>
                <!-- /.card-header -->
                <!-- form start -->


                <div class="card-body">

                    <div id="printableArea" style="background-color: #FFFFFF">


                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="table-responsive">

                                    <asp:Repeater ID="rptReportMain" runat="server" OnItemDataBound="OnItemDataBound">


                                        <ItemTemplate>


                                            <table id="students" class="table table-bordered table-striped" border="0" cellspacing="0" width="100%">

                                                <thead>

                                                    <th colspan="7" align="left">Class Name:
                                            <asp:Label ID="lbllearners" runat="server" Text='<%# Eval("Class") %>' />
                                                        <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("Class") %>' />
                                                        <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox>
                                                    </th>


                                                    <tr style="border: thin">
                                                        <th scope="col" align="left" style="font-size: small">Student Code</th>
                                                        <th scope="col" align="left" style="font-size: small">Student</th>
                                                        <th scope="col" align="left" style="font-size: small">Class</th>
                                                        <th scope="col" align="left" style="font-size: small">Canteen</th>
                                                        <th scope="col" align="left" style="font-size: small">Date</th>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="7">
                                                            <hr style="border: thin dotted #000000" />
                                                        </td>
                                                    </tr>

                                                </thead>


                                                <asp:Repeater ID="rptRepoDetails" runat="server">

                                                    <ItemTemplate>
                                                        <tr style="border: thin">
                                                            <td>
                                                                <asp:Label ID="lblsubjects" Style="float: left" runat="server" Text='<%# Eval("Student Code") %>' /></td>
                                                            <td align="center">
                                                                <asp:Label ID="lblclass" Style="float: left" runat="server" Text='<%# Eval("Student") %>' /></td>
                                                            <td align="center">
                                                                <asp:Label ID="lblexems" Style="float: left" runat="server" Text='<%# Eval("Class") %>' /></td>
                                                            <td align="center">
                                                                <asp:Label ID="lbltotalexamclass" Style="float: left" runat="server" Text='<%# Eval("canteen", "{0:N2}") %>' /></td>
                                                            <td align="center">
                                                                <asp:Label ID="lblgrade" Style="float: left" runat="server" Text='<%# Eval("Date", "{0: yyyy-MM-dd}") %>' /></td>
                                                        </tr>

                                                    </ItemTemplate>


                                                </asp:Repeater>

                                                <tr>
                                                    <td colspan="7">
                                                        <hr style="border: thin dotted #000000" />
                                                    </td>
                                                </tr>

                                                <tr>

                                                    <table align="center" class="auto-style1" border="0" cellspacing="2" style="width: 100%;">

                                                        <tr>
                                                            <td></td>
                                                            <td colspan="1" style="font-weight: bold"></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                </tr>

                                                <tr>
                                                    <td colspan="7">
                                                        <hr style="border: thin dotted #000000" />
                                                    </td>
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

                    </div>

                </div>

            </div>



            <!-- /.card-body -->
            <div class="card-footer">
            </div>
            <!-- /.card-footer -->
        </div>

    </div>
    <asp:TextBox ID="txtLastDatefrom" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtmydate" runat="server" Visible="false"></asp:TextBox>
    <asp:HiddenField ID="txtfont" runat="server" />

    <br />

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
                document.getElementById("printableArea").style.fontFamily = fontstyle;
                document.getElementById("mycard").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>



</asp:Content>
