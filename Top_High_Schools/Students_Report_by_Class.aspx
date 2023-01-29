<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Students_Report_by_Class.aspx.vb" Inherits="Top_High_Schools.Students_Report_by_Class" %>

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

    <div class="row" id="myhd">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Report</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">


                        <div class="col-sm-4">
                            <label for="inputEmail3">Class</label>
                            <asp:DropDownList ID="ddlclass" runat="server" CssClass="form-control" ClientIDMode="Static">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtfees" Text="0" runat="server" Visible="false"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputEmail3">Academic Term</label>
                            <asp:DropDownList ID="ddlacaterm" runat="server" CssClass="form-control" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputEmail3">Academic Year</label>
                            <asp:DropDownList ID="ddlacayear" runat="server" CssClass="form-control" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="form-group row">

                        <div class="col-sm-6">
                            <label for="inputEmail3">Vacation Date</label>
                            <asp:TextBox ID="txtvacadate" CssClass="form-control" runat="server" TextMode="Date" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-6">
                            <label for="inputEmail3">Re-Open Date</label>
                            <asp:TextBox ID="txtreopen" CssClass="form-control" runat="server" TextMode="Date" required="true"></asp:TextBox>
                        </div>
                    </div>


                    <hr />

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnprocess" runat="server" Text="Process" class="btn btn-success" Style="float: right" />
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />

    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <asp:Button ID="Button2" runat="server" Text="Print" Class="btn btn-primary" OnClientClick="printPageArea('printableArea')" Style="float: right" />
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div id="printableArea" style="background-color: #FFFFFF">

                        <div class="table-responsive">

                            <asp:Repeater ID="rptReportMain" runat="server" OnItemDataBound="OnItemDataBound">


                                <ItemTemplate>


                                    <table id="students" class="table table-bordered table-striped" border="0" cellspacing="0" width="100%">

                                        <thead>

                                            <tr>

                                                <asp:Table ID="tbinfo" runat="server" Style="width: 100%">
                                                    <asp:TableRow>
                                                        <asp:TableCell Style="width: 152px; align-content: center"><img src="images/solidhopelogo.jpg" style="width:150px;height:130px" /></asp:TableCell>
                                                        <asp:TableCell>
                                                            <table style="width: 100%; text-align: center">
                                                                <tr>
                                                                    <td><strong>
                                                                        <asp:Label ID="lblcompname" runat="server" Text="" Font-Bold="True" Font-Size="large" Style="padding: 15px; align-content: center; color: red"></asp:Label></strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>
                                                                        <asp:Label ID="lbladress" runat="server" Text="" Font-Bold="True" Font-Size="large" Style="padding: 15px; align-content: center; color: red"></asp:Label></strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>
                                                                        <asp:Label ID="lblphone" runat="server" Text="" Font-Bold="True" Font-Size="large" Style="padding: 15px; align-content: center; color: red"></asp:Label></strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>
                                                                        <asp:Label ID="lblonline" runat="server" Text="" Font-Bold="True" Font-Size="large" Style="padding: 15px; align-content: center; color: red"></asp:Label></strong></td>
                                                                </tr>
                                                            </table>
                                                        </asp:TableCell><asp:TableCell Style="width: 152px; align-content: center">
                                                            <asp:Image ID="imgstudpic" runat="server" ImageUrl="~/Captures/image.png" Style="width: 150px; height: 130px" />
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>

                                            </tr>

                                            <tr>
                                                <td colspan="7" style="text-align: center" class="auto-style5">
                                                    <hr style="border: thin dotted #000000" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="7" style="text-align: center" class="auto-style5"></td>
                                            </tr>

                                            <asp:Table ID="tbstudinfo" runat="server" GridLines="Both" Style="width: 100%">
                                                <asp:TableRow>
                                                    <asp:TableCell>
                                                        <asp:Label ID="Label1" runat="server" Text="NAME :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lbllearners" runat="server" Text='<%# Eval("student_name") %>' Style="margin-left: 4px" />
                                                        <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="Label28" runat="server" Text="CLASS :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lblclass" runat="server" Text="Class" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell>
                                                        <asp:Label ID="Label3" runat="server" Text="STUDENT ID :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lblstudid" runat="server" Text='<%# Eval("stud_id") %>' Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="Label2" runat="server" Text="TERM :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lblterms" runat="server" Text="" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell>
                                                        <asp:Label ID="Label4" runat="server" Text="NO ON ROLL :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lblroll" runat="server" Text="0" Style="margin-left: 4px"></asp:Label><asp:Label ID="Label5" runat="server" Text=" STUDENTS"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="Label7" runat="server" Text="POSITION :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lblposition" runat="server" Text="" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell>
                                                        <asp:Label ID="Label9" runat="server" Text="TOTAL MARKS :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lbltotalmarks" runat="server" Text="0.00" Style="margin-left: 4px"></asp:Label><asp:Label ID="Label10" runat="server" Text=" OUT OF 1000"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="Label17" runat="server" Text="AVERAGE MARK :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lblaverage" runat="server" Text="0.00" Style="margin-left: 4px"></asp:Label><asp:Label ID="Label18" runat="server" Text=" %"></asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell>
                                                        <asp:Label ID="Label19" runat="server" Text="VACATION DATE :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lblvacation" runat="server" Text="00-00-00" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="Label20" runat="server" Text="NEXT TERM BEGINS :" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell><asp:TableCell>
                                                        <asp:Label ID="lblnextterm" runat="server" Text="00-00-00" Style="margin-left: 4px"></asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                            <tr>
                                                <td colspan="7">
                                                    <hr style="border: thin dotted #000000" />
                                                </td>
                                            </tr>


                                            <div class="row">
                                                <div class="col-md-4">
                                                </div>
                                                <div class="col-md-4">
                                                    <h5>LEARNER'S TERMINAL REPORT</h5>
                                                </div>
                                                <div class="col-md-4">
                                                </div>
                                            </div>

                                            <tr>
                                                <td colspan="7">
                                                    <hr style="border: thin dotted #000000" />
                                                </td>
                                            </tr>

                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="rptRepoDetails" runat="server">

                                                <HeaderTemplate>
                                                    <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%" style="border: thin solid black; color: black">
                                                        <thead style="background-color: #16b60e; color: yellow; border: thin" id="bgcolor">
                                                            <tr>
                                                                <th scope="col" align="left" style="font-size: small" id="thsub">Subject</th>
                                                                <th scope="col" align="left" style="font-size: small" id="thcscore">Class Score 50%</th>
                                                                <th scope="col" align="left" style="font-size: small" id="thescore">Exams Score 50%</th>
                                                                <th scope="col" align="left" style="font-size: small" id="thtotal">Total 100%</th>
                                                                <th scope="col" align="left" style="font-size: small" id="thgrade">Grade</th>
                                                                <th scope="col" align="left" style="font-size: small" id="thsubpos">Subject Position</th>
                                                                <th scope="col" align="left" style="font-size: small" id="thremarks">Remarks</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="border: thin solid #000000" id="tdsub">
                                                            <asp:Label ID="lblsubjects" runat="server" Text='<%# Eval("subject") %>' /></td>
                                                        <td align="center" style="border: thin solid #000000" id="tscscore">
                                                            <asp:Label ID="lblclass" runat="server" Text='<%# Eval("class_wk_50") %>' /></td>
                                                        <td align="center" style="border: thin solid #000000" id="tdescore">
                                                            <asp:Label ID="lblexems" runat="server" Text='<%# Eval("exams_50") %>' /></td>
                                                        <td align="center" style="border: thin solid #000000" id="tdtotal">
                                                            <asp:Label ID="lbltotalexamclass" runat="server" Text='<%# Eval("final_score_100") %>' /></td>
                                                        <td align="center" style="border: thin solid #000000" id="tdgrade">
                                                            <asp:Label ID="lblgrade" runat="server" Text='<%# Eval("grades") %>' /></td>
                                                        <td align="center" style="border: thin solid #000000" id="tdposi">
                                                            <asp:Label ID="lblposition" runat="server" Text='<%# Eval("rank_str") %>' /></td>
                                                        <td style="border: thin solid #000000" id="tdremarks">
                                                            <asp:Label ID="lblremarks" runat="server" Text='<%# Eval("remarks") %>' /></td>
                                                    </tr>

                                                </ItemTemplate>
                                                <SeparatorTemplate>
                                                    <hr />
                                                </SeparatorTemplate>

                                            </asp:Repeater>

                                            <tr>
                                                <td colspan="7">
                                                    <hr style="border: thin dotted #000000" />
                                                </td>
                                            </tr>

                                            <div>
                                                <table class="auto-style1" id="tbbills" width="100%">
                                                    <tr>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="Label13" runat="server" Text="Attendance :" Font-Size="Small" Style="padding: 10px"></asp:Label></td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lblattendace" runat="server" Text='<%# Eval("tot_count") %>' Font-Size="Small" Style="padding: 25px"></asp:Label><asp:Label ID="Label14" runat="server" Text="Out of  :" Font-Size="Small" Style="padding: 15px"></asp:Label><asp:Label ID="lbloutof" runat="server" Text="0" Font-Size="Small" Style="padding: 25px"></asp:Label></td>
                                                        <td style="border: thin solid #000000" colspan="3">
                                                            <asp:Label ID="Label15" runat="server" Text="Promoted To :" Font-Size="Small" Style="padding: 25px"></asp:Label></td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lblpromo" runat="server" Text="" Font-Size="Small" Style="padding: 25px"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="Label29" runat="server" Font-Size="Small" Style="padding: 10px" Text="Class teacher's remarks :"></asp:Label></td>
                                                        <td colspan="5" style="border: thin solid #000000">
                                                            <asp:Label ID="lblclassteacherrec" runat="server" Font-Size="Small" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="Label30" runat="server" Font-Size="Small" Style="padding: 10px" Text="Principal's remarks :"></asp:Label></td>
                                                        <td colspan="5" style="border: thin solid #000000">
                                                            <asp:Label ID="lblprincrec" runat="server" Font-Size="Small" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="Label31" runat="server" Font-Size="Small" Style="padding: 10px" Text="Next term school fees :"></asp:Label></td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lblnextfees" runat="server" Font-Size="Small" Style="padding: 25px" Text="0"></asp:Label></td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="Label16" runat="server" Font-Size="Small" Style="padding: 10px" Text="Arreas of school fees :"></asp:Label></td>
                                                        <td colspan="3" style="border: thin solid #000000">
                                                            <asp:Label ID="lblarreas" runat="server" Font-Size="Small" Style="padding: 25px" Text="0"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="Label32" runat="server" Font-Size="Small" Style="padding: 10px" Text="School fees for next term"></asp:Label></td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="Label33" runat="server" Font-Size="Small" Style="padding: 10px" Text="School fees + Arrears = :"></asp:Label></td>
                                                        <td colspan="2" style="border: thin solid #000000">
                                                            <asp:Label ID="lblduefees" runat="server" Font-Size="Small" Style="padding: 25px" Text="0"></asp:Label></td>
                                                        <td colspan="2" style="border: thin solid #000000">&nbsp;</td>
                                                    </tr>
                                                </table>
                                                <hr />
                                                <div>
                                                    <asp:Label ID="Label6" runat="server" Text="NOTE:" Font-Bold="true" ForeColor="Black"></asp:Label><asp:TextBox ID="lblnote" CssClass="form-control" runat="server" Text="" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                </div>
                                            </div>
                                </ItemTemplate>

                                <SeparatorTemplate>
                                    <hr />
                                </SeparatorTemplate>

                                <FooterTemplate>
                                    <tr>
                                        <td colspan="7">
                                            <hr style="border: thin dotted #000000" />
                                        </td>
                                    </tr>
                                    <hr />
                                    <br />
                                    </tbody> </table>
                                </FooterTemplate>
                                <SeparatorTemplate>
                                    <hr />
                                </SeparatorTemplate>
                            </asp:Repeater>

                        </div>

                        <br />

                    </div>

                </div>

            </div>

            <!-- /.card-body -->
            <div class="card-footer">
            </div>
            <!-- /.card-footer -->
        </div>



    </div>


    <br />

    <asp:Button ID="Button1" runat="server" Text="Print" CssClass="form-control btn-primary" OnClientClick="printPageArea('printableArea')" />

    <asp:Label ID="lblmyacayear" runat="server" Text="0" Font-Size="Small" Style="padding: 15px" Visible="false"></asp:Label>
    <asp:Label ID="lblmyacaterm" runat="server" Text="0" Font-Size="Small" Style="padding: 15px" Visible="false"></asp:Label>

     <asp:HiddenField ID="hfsub" runat="server" Value="1" />
             <asp:HiddenField ID="txtfont" runat="server" />
             <asp:HiddenField ID="txtbgcolor" runat="server" Value="#16b60e" />

    <script type="text/javascript">

        $('#ddlclass').select2({
            placeholder: 'Select an option'
        });

        $('#ddlacayear').select2({
            placeholder: 'Select an option'
        });

        $('#ddlacaterm').select2({
            placeholder: 'Select an option'
        });

    </script>
</asp:Content>
