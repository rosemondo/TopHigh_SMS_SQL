<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_Data_Preview.aspx.vb" Inherits="Top_High_Schools.Student_Data_Preview" %>

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



            <table align="center" class="auto-style6" style="width: 800px">
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
                        <img src="images/solidhopelogo.jpg" style="width: 150px; height: 130px" /></td>
                    <td colspan="2">
                        <p style="text-align: center">
                            <strong>
                                <asp:Label ID="lblcompname" runat="server" Text="info"></asp:Label></strong>
                            <br />
                            <strong>
                                <asp:Label ID="lbladress" runat="server" Text="info"></asp:Label></strong>
                            <br />
                            <strong>
                                <asp:Label ID="lblcontacts" runat="server" Text="info"></asp:Label></strong>
                            <br />
                            <strong>
                                <asp:Label ID="lblonline" runat="server" Text="info"></asp:Label></strong>
                        </p>
                    </td>
                    <td colspan="2">
                        <asp:Image ID="imgstudpic" runat="server" Width="150px" Height="130px" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6"></td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center">
                        <p align="center" class="MsoNormal">
                            <b><u><span>ADMISSION FORM<o:p></o:p></span></u></b>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="6"></td>
                </tr>
                <tr>
                    <td>Pupil's Name :</td>
                    <td>
                        <asp:Label ID="txtnameofchild" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Date of Birth :</td>
                    <td>
                        <asp:Label ID="txtdateofbirth" runat="server" Text=""></asp:Label></td>
                    <td>Gender :</td>
                    <td>
                        <asp:Label ID="ddlGender" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Hometown :</td>
                    <td>
                        <asp:Label ID="txthometown" runat="server" Text=""></asp:Label></td>
                    <td>Region :</td>
                    <td>
                        <asp:Label ID="txtregion" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Nationality :</td>
                    <td>
                        <asp:Label ID="txtnationality" runat="server" Text=""></asp:Label></td>
                    <td>Religion :</td>
                    <td>
                        <asp:Label ID="txtreligion" runat="server" Text=""></asp:Label></td>
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
                    <td colspan="6" style="text-align: center"><b><span>PARTICULARS OF FATHER<o:p></o:p></span></b></td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td>Father's Name :</td>
                    <td>
                        <asp:Label ID="txtfathersname" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Address :</td>
                    <td colspan="5">
                        <asp:Label ID="txtaddress" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Father's Occupation :</td>
                    <td>
                        <asp:Label ID="txtfatOcupa" runat="server" Text=""></asp:Label></td>
                    <td>Father's Religion :</td>
                    <td>
                        <asp:Label ID="txtfatreligion" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Father's Education :</td>
                    <td>
                        <asp:Label ID="txtfateducation" runat="server" Text=""></asp:Label></td>
                    <td></td>
                    <td></td>
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
                    <td colspan="6" style="text-align: center"><b><span>PARTICULARS OF MOTHER<o:p></o:p></span></b></td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td>Mother's Name :</td>
                    <td>
                        <asp:Label ID="txtmatname" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Address :</td>
                    <td colspan="5">
                        <asp:Label ID="txtmataddress" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Mother's Occupation :</td>
                    <td>
                        <asp:Label ID="txtmatoccupation" runat="server" Text=""></asp:Label></td>
                    <td>Mother's Religion :</td>
                    <td>
                        <asp:Label ID="txtmatreligion" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Mother's Education :</td>
                    <td>
                        <asp:Label ID="txtmateducation" runat="server" Text=""></asp:Label></td>
                    <td></td>
                    <td></td>
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
                    <td colspan="6" style="text-align: center"><b><span>DECLARATION OF GUARDIAN<o:p></o:p></span></b></td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td>I</td>
                    <td>
                        <asp:Label ID="txtname" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">DO SINCERELY PROMISE THAT, I WILL&nbsp; <span>DO MY BEST TO HONOUR ALL FINANCIAL AND MORAL OBLIGATIONS TO ASSIST THE SCHOOL AUTHORITIES TO GIVE MY WARD THE BEST EDUCATION HE/SHE DESERVES. FAILURE ON MY PART TO KEEP THIS PROMISE WILL RESULT IN EXPULSION OF MY WARD FROM THE SCHOOL. </span></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Sign Date :</td>
                    <td>
                        <asp:Label ID="txtdate" runat="server" Text=""></asp:Label></td>
                    <td>Parent / Guardian :</td>
                    <td>
                        <asp:Label ID="txtsign" runat="server" Text=""></asp:Label></td>
                    <td>User :</td>
                    <td><asp:Label ID="txtuser" runat="server" Text=""></asp:Label></td>
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

    <asp:HiddenField ID="txtid" runat="server" />
    <asp:HiddenField ID="txtmyid" runat="server" />

    <asp:HiddenField ID="txtemp" runat="server" />
    <asp:HiddenField ID="txtids" runat="server" />
    <asp:HiddenField ID="txtdays" runat="server" />
    <asp:HiddenField ID="txtmonths" runat="server" />
    <asp:HiddenField ID="txtyears" runat="server" />

</asp:Content>
