<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admission_Receipt.aspx.vb" Inherits="Top_High_Schools.Admission_Receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 350px;
        }

        .auto-style2 {
            width: 88px;
        }

        .auto-style3 {
            width: 348px;
        }

       
        .auto-style4 {
            margin-left: 40px;
        }
        .auto-style5 {
            margin-left: 80px;
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

   <div id="printableArea" style="background-color: #FFFFFF">

        <table align="center" class="auto-style1" id="printTable">
            <tr>
                <td colspan="5" style="text-align: center" class="auto-style5">
                    <asp:Label ID="lblcompname" runat="server" Text="info" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center" class="auto-style5">
                    <asp:Label ID="lbladress" runat="server" Text="info" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center" class="auto-style5">
                    <asp:Label ID="lblcontacts" runat="server" Text="info" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center" class="auto-style5">
                    <asp:Label ID="lblonline" runat="server" Text="info" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center" class="auto-style5">
                    -----------------------------------------------------</td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center" class="auto-style5">
                    <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Receipt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center" class="auto-style5">
                    -----------------------------------------------------</td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center" class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Receipt No.:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="lblnumber" runat="server" Text="651363"></asp:Label>
                </td>
                <td class="auto-style2" style="width: 10px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Date :"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lbldate" runat="server" Text="2021-10-28"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="5" class="auto-style5">
                    <table align="center" class="auto-style3">
                        <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="Label6" runat="server" Text="Particulars" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="Label7" runat="server" Text="Amount" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="Label8" runat="server" Text="Tuition Fees"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lbltuition" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="Label9" runat="server" Text="Admission Fees"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lbladmission" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <hr />
                            </td>
                        </tr>
                         <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="Label1" runat="server" Text="Total Fee / Bill"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lbltotbill" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="Label10" runat="server" Text="Sch. Fees Pmt."></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblfeepay" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="Label11" runat="server" Text="Admis. Fee Pmt."></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lbladmpay" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="Label12" runat="server" Text="Balance Due" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblbaldue" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Label ID="Label13" runat="server" Text="Thank You." Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label14" runat="server" Text="Student :"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblstudents" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label16" runat="server" Text="Class :"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblclass" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label18" runat="server" Text="System User :"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lbluser" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>

    </div>
    <br />

    <asp:Button ID="Button1" runat="server" Text="Print" CssClass="form-control btn-primary" OnClientClick="printPageArea('printableArea')" />
  
</asp:Content>
