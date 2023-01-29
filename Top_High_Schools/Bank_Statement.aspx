<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Bank_Statement.aspx.vb" Inherits="Top_High_Schools.Bank_Statement" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Bank Statement</h4>
    </div>

    <div class="row" id="nabyrow1">
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
                            <label for="inputEmail3">A/c Name</label>
                            <asp:DropDownList ID="dplacname" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputEmail3">Date From</label>
                            <asp:TextBox ID="ASPxDatefrom" runat="server" CssClass="form-control" DisplayFormatString="yyyy-MM-dd" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label for="inputEmail3">Date To</label>
                            <asp:TextBox ID="ASPxDateto" runat="server" CssClass="form-control" DisplayFormatString="yyyy-MM-dd" TextMode="Date"></asp:TextBox>
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
    <div class="row" id="phrow3">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div>

                                <asp:Repeater ID="rptstudent" runat="server">
                                    <HeaderTemplate>
                                        <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th scope="col">Date</th>
                                                    <th scope="col">Accounts Name</th>
                                                    <th scope="col">Account #</th>
                                                    <th scope="col">Transaction</th>
                                                    <th scope="col">Debit</th>
                                                    <th scope="col">Credit</th>
                                                    <th scope="col">Balance</th>
                                                    <th scope="col">Bank</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("depdate", "{0: yyyy-MM-dd}") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("accname") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblODB" runat="server" Text='<%# Eval("accnum") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("details") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("debit", "{0:N2}") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("credit", "{0:N2}") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Balance", "{0:N2}") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("bank") %>' /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
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
    </div>

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
                document.getElementById("nabyrow1").style.fontFamily = fontstyle;
                document.getElementById("phrow3").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
