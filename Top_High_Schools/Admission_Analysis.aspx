<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admission_Analysis.aspx.vb" Inherits="Top_High_Schools.Admission_Analysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />

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

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">New Admission By Year</h4>

    </div>

    <div class="row" id="nabyrow1">
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
                        <div class="col-sm-6">
                            <label for="inputEmail3">Select Year</label>
                            <asp:DropDownList ID="dlpyears" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                        <div class="col-sm-3">
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

        <div>

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
                                    <asp:Label ID="Label11" runat="server" Text="Admission Analysis By Year" Font-Bold="True" Font-Underline="true" Font-Size="large" Style="padding: 15px"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="6">
                                    <hr style="border: thin dotted #000000" />
                                </td>
                            </tr>

                            <tr>
                                <th colspan="8" align="left">Term : 
                                     <asp:Label ID="lblproduct" runat="server" Text='<%# Eval("aca_year") %>' />
                                    <asp:HiddenField ID="hfdate" runat="server" Value='<%# Eval("aca_year") %>' />
                                </th>
                            </tr>

                            <tr>
                                <td colspan="6">
                                    <hr style="border: thin dotted #000000" />
                                </td>
                            </tr>

                            <tr style="border: thin">
                                <th scope="col" style="text-align:center">Learner Count</th>
                                <th scope="col" align="left">Amt. sch. Fees Paid</th>
                                <th scope="col" align="left">Amt. Adm. Fee Paid</th>
                                <th scope="col" style="text-align:center">Total Male(s)</th>
                                <th scope="col" style="text-align:center">Total Female(s)</th>
                                <th scope="col" align="left">Class</th>
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
                                   <td align="center">
                                        <asp:Label ID="lblsubjects" runat="server" Text='<%# Eval("new_learners_count") %>'/>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("amt_fee_paid", "{0:N2}") %>' Style="float:left"/>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblexems" runat="server" Text='<%# Eval("amt_admi_paid", "{0:N2}") %>' Style="float:left"/>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Male") %>'/>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Female") %>'/>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("class_name") %>' Style="float:left"/>
                                    </td>
                                </tr>

                            </ItemTemplate>


                        </asp:Repeater>

                </ItemTemplate>

                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>

            </asp:Repeater>

        </div>

        <br />

    </div>

    <asp:Button ID="Button2" runat="server" Text="Print" CssClass="form-control btn-primary" OnClientClick="printPageArea('printableArea')" />
      <asp:HiddenField ID="txtfont" runat="server" />
    <br />

     <script type="text/javascript">

         $('#dlpyears').select2({
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
                 document.getElementById("printableArea").style.fontFamily = fontstyle;

                 window.setTimeout("countdown()", 1000);
             }
         }
         countdown();
     </script>

</asp:Content>
