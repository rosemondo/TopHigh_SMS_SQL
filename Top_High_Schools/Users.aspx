<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Users.aspx.vb" Inherits="Top_High_Schools.Users" %>

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

          .select2-container .select2-selection--single {
            height: 34px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }

    </style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h4 class="h4 mb-0 text-gray-800" id="ul">Users List</h4>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="userlist">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#MyPopup">
                        Add New User</button>

                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>


                            <div class="table-responsive">

                                <asp:Repeater ID="rptstudent" runat="server">
                                    <HeaderTemplate>
                                        <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th scope="col">ID</th>
                                                    <th scope="col">User Name</th>
                                                    <th scope="col">Role</th>
                                                    <th scope="col">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("username") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblrole" runat="server" Text='<%# Eval("userrole") %>' />
                                            </td>
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
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>


                    <asp:HiddenField ID="txtfont" runat="server" />
                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />

    <!-- Modal Popup -->
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h5 class="card-title">New User</h5>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">
                                   
                                    <div class="form-group row">

                                        <div class="col-sm-12">
                                            <label for="inputPassword3">User</label>
                                            <asp:DropDownList ID="ddlUser" runat="server" class="form-control"  ClientIDMode="Static" required="true">
                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="form-group row">

                                        <div class="col-sm-6">
                                            <label for="inputEmail3">Password</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtpass" TextMode="Password"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-6">
                                            <label for="inputPassword3">Role</label>
                                            <asp:DropDownList ID="dplrole" runat="server" class="form-control" placeholder="Role" required="true">
                                                <asp:ListItem> - SELECT - </asp:ListItem>
                                                <asp:ListItem>Admin</asp:ListItem>
                                                <asp:ListItem>Assistant Admin</asp:ListItem>
                                                <asp:ListItem>Accountant</asp:ListItem>
                                                <asp:ListItem>Secretary</asp:ListItem>
                                                <asp:ListItem>Principal</asp:ListItem>
                                                <asp:ListItem>CEO</asp:ListItem>
                                                <asp:ListItem>Class Teacher</asp:ListItem>
                                                <asp:ListItem>Subject Teacher</asp:ListItem>
                                                <asp:ListItem>None Teaching Staff</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <hr />

                                </div>

                                <!-- /.card-body -->
                                <div class="card-footer">
                                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                                </div>
                                <!-- /.card-footer -->
                            </div>
                            <asp:TextBox ID="txtCashAcc" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtReceAcc" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtAdmAcc" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSchAcc" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtlinkcode" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txttimer" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtcomp" Text="Test Comp" runat="server" Visible="false"></asp:TextBox>
                        </div>

                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Popup -->


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

                document.getElementById("ul").style.fontFamily = fontstyle;
                document.getElementById("userlist").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
