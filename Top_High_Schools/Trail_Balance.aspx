<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Trail_Balance.aspx.vb" Inherits="Top_High_Schools.Trail_Balance" %>

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


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h4 class="h4 mb-0 text-gray-800" id="tbr">Trial Balance Report</h4>
    </div>

    <div class="row">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title" id="ttb">Trial Balance</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">

                        <div class="col-sm-4">
                            <label for="inputEmail3" id="dtfm">Date From</label>
                            <asp:TextBox ID="ASPxDatefrom" runat="server" CssClass="form-control" DisplayFormatString="yyyy-MM-dd" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-sm-4">
                            <label for="inputEmail3" id="dtt">Date To</label>
                            <asp:TextBox ID="ASPxDateto" runat="server" CssClass="form-control" DisplayFormatString="yyyy-MM-dd" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <asp:CheckBox ID="chkrefresh" runat="server" Text="Refresh" Checked="True"></asp:CheckBox>
                            <asp:Button ID="btnrefresh" runat="server" Text="Refresh"></asp:Button>
                        </div>

                        <div class="col-sm-2">
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
    <div class="row">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                 <div class="table-responsive">

                        <asp:Repeater ID="rptTBStatement" runat="server">
                            <HeaderTemplate>
                                <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th scope="col">Code</th>
                                            <th scope="col">Accounts</th>
                                            <th scope="col">Debit</th>
                                            <th scope="col">Credit</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Code") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Accounts") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblODB" runat="server" Text='<%# Eval("Debit", "{0:N2}") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Credit", "{0:N2}") %>' /></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                    </div>

                </div>
                

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:TextBox ID="txtsdate" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtdate2" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtdate3" runat="server" Visible="false"></asp:TextBox>

            <asp:TextBox ID="txtLastDatefrom" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtLastDateto" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtRevExpDateto" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtRevExpLastDateto" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
        </div>
        <asp:HiddenField ID="txtfont" runat="server"/>
    </div>

    <br />

      <script type="text/javascript">

          $('#ddlUser').select2({
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

                 document.getElementById("tbr").style.fontFamily = fontstyle;
                 document.getElementById("ttb").style.fontFamily = fontstyle;
                 document.getElementById("dtfm").style.fontFamily = fontstyle;
                 document.getElementById("dtt").style.fontFamily = fontstyle;
                 document.getElementById("students").style.fontFamily = fontstyle;

                 window.setTimeout("countdown()", 1000);
             }
         }
         countdown();
     </script>


</asp:Content>
