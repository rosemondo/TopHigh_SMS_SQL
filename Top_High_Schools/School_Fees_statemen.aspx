<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="School_Fees_statemen.aspx.vb" Inherits="Top_High_Schools.School_Fees_statemen" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">School Fees Statement</h4>
    </div>

    <div class="row" id="sfrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Statement</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-sm-3">
                            <label for="inputEmail3">Learner</label>
                            <asp:DropDownList ID="ddStudent" runat="server" CssClass="form-control" ClientIDMode ="Static" requide="true"></asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputEmail3">Date From</label>
                            <asp:TextBox ID="ASPxDatefrom" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputEmail3">Date To</label>
                            <asp:TextBox ID="ASPxDateto" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkbydate" runat="server" Text="By Date"></asp:CheckBox>
                            <asp:Button ID="btnsearch" runat="server" Text="Search"></asp:Button>
                        </div>

                    </div>

                </div>

                <!-- /.card-body -->

                <!-- /.card-footer -->
            </div>

        </div>


    </div>


    <br />

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="sfrow2">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <asp:Button ID="Button2" runat="server" Text="Print" Class="btn btn-primary" OnClientClick="printPageArea('printableArea')" Style="float: right" />
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div id="printableArea" style="background-color: #FFFFFF">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                    <div class="table-responsive">

                        <!-- info row -->
                        <div class="row invoice-info">
                            <div class="col-sm-4 invoice-col">
                                <br />
                                <address>
                                    <strong>School Info.</strong><br>
                                    <asp:Label ID="lblcompname" runat="server" Text="info" Font-Names="Nunito"></asp:Label><br>
                                    <asp:Label ID="lbladress" runat="server" Text="info" Font-Names="Nunito"></asp:Label><br>
                                    <asp:Label ID="lblcontacts" runat="server" Text="info" Font-Names="Nunito"></asp:Label><br>
                                    <asp:Label ID="lblonline" runat="server" Text="info" Font-Names="Nunito"></asp:Label>
                                </address>
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-4 invoice-col">
                                <br />
                                <address>
                                    <strong>Learner's Info</strong><br>
                                    Learner:
                                <asp:Label ID="lbllearner" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                                    Father's Contact:
                                <asp:Label ID="lblfPone" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                                     Mother's Contact:
                                <asp:Label ID="lblmPone" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                                    Email:
                                <asp:Label ID="lblPemail" runat="server" Text="" Font-Names="Nunito"></asp:Label>
                                </address>
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-4 invoice-col">
                                <br />
                                <b>Class:</b>
                                <asp:Label ID="lblclass" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                                <b>Balance Due:</b>
                                <asp:Label ID="lblbaldue" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->

                        <br />

                        <div class="card-body">

                            <div>

                                <asp:Repeater ID="rptstudent" runat="server">
                                    <HeaderTemplate>
                                        <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th scope="col" style="text-align: left">Date</th>
                                                    <th scope="col" style="text-align: left">Description</th>
                                                    <th scope="col" style="text-align: left">Debit</th>
                                                    <th scope="col" style="text-align: left">Credit</th>
                                                    <th scope="col" style="text-align: left">Balance</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("st_date", "{0: yyyy-MM-dd}") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("description") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("debit", "{0:N2}") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("credit", "{0:N2}") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Balance", "{0:N2}") %>' /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:TextBox ID="txtstudid" runat="server" Visible="False"></asp:TextBox>
                            </div>

                        </div>

                    </div>

                                 </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnsearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>
        <asp:TextBox ID="txtLastDatefrom" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
        <asp:TextBox ID="txtLastDateto" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
         <asp:HiddenField ID="txtfont" runat="server" />
    </div>

    <br />

      <script type="text/javascript">

          $('#ddStudent').select2({
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
                 document.getElementById("sfrow2").style.fontFamily = fontstyle;

                 window.setTimeout("countdown()", 1000);
             }
         }
         countdown();
     </script>

</asp:Content>
