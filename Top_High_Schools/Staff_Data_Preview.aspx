<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Staff_Data_Preview.aspx.vb" Inherits="Top_High_Schools.Staff_Data_Preview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style6 {
            width: 100px;
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

        <div class="container">



            <table align="center" class="auto-style6" style="width: 900px">
                <tr>
                    <td></td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <img src="images/solidhopelogo.jpg" style="width:150px;height:130px" /></td>
                    <td colspan="2"><p style="text-align: center">
                                    <strong><asp:Label ID="lblcompname" runat="server" Text="info"></asp:Label></strong>
                                    <br />
                                    <strong><asp:Label ID="lbladress" runat="server" Text="info"></asp:Label></strong>
                                    <br />
                                    <strong ><asp:Label ID="lblcontacts" runat="server" Text="info"></asp:Label></strong>
                                    <br />
                                    <strong><asp:Label ID="lblonline" runat="server" Text="info"></asp:Label></strong>
                                </p></td>
                    <td colspan="2"><asp:Image ID="imgstudpic" runat="server" Width="150px" Height="130px" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6"></td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center">
                        <p align="center" class="MsoNormal">
                            <b><u><span>STAFF FORM<o:p></o:p></span></u></b></p>
                    </td>
                </tr>
                <tr>
                    <td colspan="6"></td>
                </tr>
                <tr>
                    <td>First Name :</td>
                    <td>
                        <asp:Label ID="txtfirstname" runat="server" Text="Label"></asp:Label></td>
                    <td>Middle Name :</td>
                    <td><asp:Label ID="txtmidname" runat="server" Text="Label"></asp:Label></td>
                    <td>Last Name :</td>
                    <td><asp:Label ID="txtlastname" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Date of Birth :</td>
                    <td>
                        <asp:Label ID="txtdob" runat="server" Text="Label"></asp:Label></td>
                    <td>Gender :</td>
                    <td>
                        <asp:Label ID="ddlGender" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>ID Type :</td>
                    <td>
                        <asp:Label ID="ddlidtype" runat="server" Text="Label"></asp:Label></td>
                    <td>ID Number :</td>
                    <td>
                        <asp:Label ID="txtidnum" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Qualification :</td>
                    <td>
                        <asp:Label ID="txtqualification" runat="server" Text="Label"></asp:Label></td>
                    <td>SSNIT Number :</td>
                    <td>
                        <asp:Label ID="txtSsnit" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center">
                        <p class="MsoNormal">
                            &nbsp;
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center"><b><span>STAFF ADDRESS<o:p></o:p></span></b></td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td>House Address :</td>
                    <td>
                        <asp:Label ID="txthouseaddress" runat="server" Text="Label"></asp:Label></td>
                    <td>City :</td>
                    <td><asp:Label ID="txtcity" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Country :</td>
                    <td>
                        <asp:Label ID="ddlcountries" runat="server" Text="Label"></asp:Label></td>
                    <td>Mobile Number :</td>
                    <td>
                        <asp:Label ID="txtmobile" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>E-mail :</td>
                    <td>
                        <asp:Label ID="txtemail" runat="server" Text="Label"></asp:Label></td>
                    <td>Next of Kin :</td>
                    <td>
                        <asp:Label ID="txtnextofkin" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center">
                        <p class="MsoNormal">
                            &nbsp;
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center"><b><span>SALARY INFO<o:p></o:p></span></b></td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td>Basic Salary :</td>
                    <td>
                        <asp:Label ID="txtsalary" runat="server" Text="Label"></asp:Label></td>
                    <td>Allowances :</td>
                    <td><asp:Label ID="txtallowance" runat="server" Text="Label"></asp:Label></td>
                    <td>Net Salary :</td>
                    <td><asp:Label ID="txtnet" runat="server" Text="Label"></asp:Label></td>
                </tr>

                <tr>
                    <td>Salary Entry Level :</td>
                    <td>
                        <asp:Label ID="ddlentlevel" runat="server" Text="Label"></asp:Label></td>
                    <td>Bank Name :</td>
                    <td>
                        <asp:Label ID="txtbank" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Account Name :</td>
                    <td>
                        <asp:Label ID="txtacname" runat="server" Text="Label"></asp:Label></td>
                    <td>Account Number :</td>
                    <td>
                        <asp:Label ID="txtacnum" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
          
                 <tr>
                    <td></td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>


    </div>

    <asp:Button ID="Button1" runat="server" Text="Print" CssClass="btn btn-primary rounded-0 float-left" OnClientClick="printPageArea('printableArea')" />
    <asp:Button ID="Button2" runat="server" Text="Edit" CssClass="btn btn-success rounded-0 float-right" />

    <br />
    <br />

    <asp:HiddenField ID="txtid" runat="server" />
    <asp:HiddenField ID="txtmyid" runat="server" />

     <asp:HiddenField ID="txtemp" runat="server" />
    <asp:HiddenField ID="txtids" runat="server" />
     <asp:HiddenField ID="txtdays" runat="server" />
    <asp:HiddenField ID="txtmonths" runat="server" />
     <asp:HiddenField ID="txtyears" runat="server" />

</asp:Content>
