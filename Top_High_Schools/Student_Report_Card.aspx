<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_Report_Card.aspx.vb" Inherits="Top_High_Schools.Student_Report_Card" %>

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

        .auto-style1 {
            width: 100%;
            float: left;
            border: 1px solid #000000;
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

    <script type="text/javascript">
        function ConvertToImage(btnExport) {
            html2canvas($('[id*=printableArea]')[0], {
                onrendered: function (canvas) {
                    var base64 = canvas.toDataURL();
                    $("[id*=hfImageData]").val(base64);
                    __doPostBack(btnExport.name, "");
                }
            });
            return false;
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


                        <div class="col-sm-6">
                            <label for="inputEmail3">Learner</label>
                            <asp:DropDownList ID="ddlstudent" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:HiddenField ID="txtclass" runat="server" Value="0" />
                            <asp:HiddenField ID="txttype" runat="server" Value="0" />
                            <asp:HiddenField ID="txtfees" runat="server" Value="0" />
                        </div>

                        <div class="col-sm-6">
                            <label for="inputEmail3">Promotet To</label>
                            <asp:DropDownList ID="ddlClassto" runat="server" CssClass="form-control" ClientIDMode="Static">
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

                    <div class="form-group row">

                        <div class="col-sm-12">
                            <label>Note</label>
                            <asp:TextBox ID="txtnote" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                    <asp:Button ID="btnsms" runat="server" UseSubmitBehavior="false" Text="Send SMS" Class="btn btn-warning" Style="float: left; margin: 5px" OnClick="ExportToImage" OnClientClick="return ConvertToImage(this)" />
                    <asp:Button ID="btnExport" runat="server" UseSubmitBehavior="false" Text="Send Report" Class="btn btn-warning" Style="float: left; margin: 5px" OnClick="ExportToImage" OnClientClick="return ConvertToImage(this)" />
                    <asp:HiddenField ID="hfImageData" runat="server" />
                    <asp:Button ID="Button2" runat="server" Text="Print" Class="btn btn-primary" OnClientClick="printPageArea('printableArea')" Style="float: right" />
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div id="printableArea" style="background-color: #FFFFFF">


                        <div class="table-responsive">

                            <div>
                                <asp:Table ID="tbinfo" runat="server" Style="width: 100%">
                                    <asp:TableRow>
                                        <asp:TableCell Style="width: 152px; align-content: center">
                                            <asp:Image ID="logo" runat="server" Width="150px" Height="130px" class="rounded img-center" />
                                        </asp:TableCell>
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
                                                        <asp:Label ID="lblemail" runat="server" Text="" Font-Bold="True" Font-Size="large" Style="padding: 15px; align-content: center; color: red"></asp:Label></strong></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>
                                                        <asp:Label ID="lblweb" runat="server" Text="" Font-Bold="True" Font-Size="large" Style="padding: 15px; align-content: center; color: red"></asp:Label></strong></td>
                                                </tr>
                                            </table>
                                        </asp:TableCell><asp:TableCell Style="width: 152px; align-content: center">
                                            <asp:Image ID="imgstudpic" runat="server" ImageUrl="~/Captures/image.png" Style="width: 150px; height: 130px" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>

                            <br />

                            <div>

                                <asp:Table ID="tbstudinfo" runat="server" GridLines="Both" Style="width: 100%">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label ID="Label1" runat="server" Text="NAME :" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="lbllearners" runat="server" Text="Name" Style="margin-left: 4px" />
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
                                            <asp:Label ID="lblstudid" runat="server" Text="Student ID" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="Label6" runat="server" Text="TERM :" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="lblterms" runat="server" Text="" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label ID="Label2" runat="server" Text="NO ON ROLL :" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="lblroll" runat="server" Text="0" Style="margin-left: 4px"></asp:Label><asp:Label ID="Label12" runat="server" Text=" STUDENTS"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="Label4" runat="server" Text="POSITION :" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="lblposition" runat="server" Text="" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label ID="Label7" runat="server" Text="TOTAL MARKS :" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="lbltotalmarks" runat="server" Text="0.00" Style="margin-left: 4px"></asp:Label><asp:Label ID="Label8" runat="server" Text=" OUT OF 1000"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="Label9" runat="server" Text="AVERAGE MARK :" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="lblaverage" runat="server" Text="0.00" Style="margin-left: 4px"></asp:Label><asp:Label ID="Label11" runat="server" Text=" %"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label ID="Label5" runat="server" Text="VACATION DATE :" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="lblvacation" runat="server" Text="00-00-00" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="Label10" runat="server" Text="NEXT TERM BEGINS :" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell><asp:TableCell>
                                            <asp:Label ID="lblnextterm" runat="server" Text="00-00-00" Style="margin-left: 4px"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                            <hr />

                            <div>
                                <asp:Repeater ID="rptstudent" runat="server">
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
                                    <FooterTemplate>
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>

                            <hr />

                            <div>
                                <table class="auto-style1" id="tbbills" width="100%">
                                    <tr>
                                        <td style="border: thin solid #000000">
                                            <asp:Label ID="Label13" runat="server" Text="Attendance :" Font-Size="Small" Style="padding: 10px"></asp:Label></td>
                                        <td style="border: thin solid #000000">
                                            <asp:Label ID="lblattendace" runat="server" Text="0" Font-Size="Small" Style="padding: 25px"></asp:Label><asp:Label ID="Label14" runat="server" Text="Out of  :" Font-Size="Small" Style="padding: 15px"></asp:Label><asp:Label ID="lbloutof" runat="server" Text="0" Font-Size="Small" Style="padding: 25px"></asp:Label></td>
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
                                    <asp:Label ID="Label17" runat="server" Text="NOTE:" Font-Bold="true" ForeColor="Black"></asp:Label><asp:Label ID="lblnote" runat="server" Text="" TextMode="MultiLine"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         
             <asp:HiddenField ID="txtid" runat="server" Value="0" />

            <asp:Button ID="Button1" runat="server" Text="Print" CssClass="form-control btn-primary" OnClientClick="printPageArea('printableArea')" />

            <asp:HiddenField ID="lblmyacayear" runat="server" Value="0" />
            <asp:HiddenField ID="lblmyacaterm" runat="server" Value="0" />

            <asp:HiddenField ID="hfsub" runat="server" Value="1" />
            <asp:HiddenField ID="txtfont" runat="server" />
            <asp:HiddenField ID="txtbgcolor" runat="server" Value="#16b60e" />

            <asp:TextBox ID="txtcompid" runat="server" Visible="false"></asp:TextBox>
            <script type="text/javascript">

                $('#ddlstudent').select2({
                    placeholder: 'Select an option'
                });

                $('#ddlClassto').select2({
                    placeholder: 'Select an option'
                });

            </script>
        </div>
    </div>
    <script type="text/javascript">
        var fontstyle = $.trim($('#<%=txtfont.ClientID %>').val());
        var bgcol = $.trim($('#<%=txtbgcolor.ClientID %>').val());
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
                document.getElementById("bgcolor").style.backgroundColor = bgcol;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>
</asp:Content>
