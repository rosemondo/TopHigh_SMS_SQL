<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ChangesInEquity.aspx.vb" Inherits="Top_High_Schools.ChangesInEquity" %>

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
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Cashflow Statement Report</h4>
    </div>

    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Cashflow Statement</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">

                        <div class="col-sm-4">
                            <label for="inputEmail3">Date From</label>
                            <asp:TextBox ID="ASPxDatefrom" runat="server" CssClass="form-control" DisplayFormatString="yyyy-MM-dd" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-sm-4">
                            <label for="inputEmail3">Date To</label>
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
    <div class="row" id="phrow3">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                  <div class="table-responsive">

                        <asp:Repeater ID="rptCashFlow" runat="server">
                            <HeaderTemplate>
                                <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th scope="col">Accounts</th>
                                            <th scope="col">Amount</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Accounts") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblODB" runat="server" Text='<%# Eval("Amount", "{0:N2}") %>' /></td>
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

            <asp:TextBox ID="txtLastDatefrom2021" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtLastDateto2021" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtRevExpDateto2020" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtRevExpLastDateto2020" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtpdate22019" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtpdateto22019" runat="server" Visible="false" DisplayDateFormat="yyyy-MM-dd"></asp:TextBox>
        </div>

    </div>
    <asp:HiddenField ID="txtfont" runat="server" />
     <asp:HiddenField ID="HiddenField1" runat="server" />

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
                document.getElementById("nabyrow1").style.fontFamily = fontstyle;
                document.getElementById("phrow3").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>

