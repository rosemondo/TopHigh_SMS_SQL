<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Staff_List.aspx.vb" Inherits="Top_High_Schools.Staff_List" %>

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
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="listhd">
        <h4 class="h4 mb-0 text-gray-800">Employee List</h4>
        <a href="Staff_Form.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i>Add New</a>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="rowhd">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">

                    <div class="dropdown no-arrow" style="float: right">
                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="fas fa-ellipsis-v fa-sm fa-fw" style="color: white">more</i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in"
                            aria-labelledby="dropdownMenuLink" style="float: right">
                            <div class="dropdown-header">Export before Download or View:</div>
                            <div>
                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="Export" OnClick="ExportToExcel" Style="float: right; padding: 5px; margin: 5px" />
                            </div>
                        </div>
                    </div>


                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="table-responsive">

                        <asp:Repeater ID="rptemployees" runat="server">
                            <HeaderTemplate>
                                <table id="employees" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th scope="col">Employee Code</th>
                                            <th scope="col">Employee</th>
                                            <th scope="col">Date of Birth</th>
                                            <th scope="col">Gender</th>
                                            <th scope="col">Identification</th>
                                            <th scope="col">Address</th>
                                            <th scope="col">Contact</th>
                                            <th scope="col">E-mail</th>
                                            <th scope="col">Photo</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("EmployeeCode") %>' /></td>
                                    <asp:Label ID="lblemail" runat="server" Text='<%# Eval("email") %>' Visible="false" />
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Employee") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblODB" runat="server" Text='<%# Eval("DateofBirth", "{0: yyyy-MM-dd}") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblIdentification" runat="server" Text='<%# Eval("Identification") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblContact" runat="server" Text='<%# Eval("Contact") %>' /></td>
                                    <td>
                                        <asp:LinkButton ID="lnkemail" runat="server" OnClick="GetEmail" Text='<%# Eval("email") %>'></asp:LinkButton>
                                    <td>
                                        <img src='data:image/jpg;base64,<%# If(Not String.IsNullOrEmpty(Eval("Employee")), Convert.ToBase64String(CType(Eval("Photo"), Byte())), String.Empty) %>' alt="image" height="70" width="70" class='roundimage center-img' /></td>
                                    <td>
                                        <asp:ImageButton ID="btnedit" Text="Edit" runat="server" OnClick="GetValue" Style="padding: 5px" ImageUrl="~/img/edit-11-24.png" />
                                        <asp:ImageButton ID="btndelete" runat="server" OnClick="GetDelete" Text="Delete" OnClientClick="return confirm('Are You Sure to Delete?')" Style="padding: 5px" ImageUrl="~/img/delete-24.png" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtemail" runat="server" Visible="False"></asp:TextBox>
                    </div>

                </div>


                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />

    <asp:HiddenField ID="txtfont" runat="server" />

    <asp:Label ID="lblConfirm" runat="server" Text=""></asp:Label>

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

                document.getElementById("listhd").style.fontFamily = fontstyle;
                document.getElementById("rowhd").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>



</asp:Content>
