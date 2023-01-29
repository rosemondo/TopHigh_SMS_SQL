<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_Users.aspx.vb" Inherits="Top_High_Schools.Edit_Users" %>

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
        <h4 class="h4 mb-0 text-gray-800">Users List</h4>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div>

                        <asp:Repeater ID="rptstudent" runat="server">
                            <HeaderTemplate>
                                <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th scope="col">ID</th>
                                            <th scope="col">User Name</th>
                                            <th scope="col">Password</th>
                                            <th scope="col">Role</th>
                                            <th scope="col">Location #</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>' /></td>
                                    <td>
                                        <asp:TextBox ID="txtname" runat="server" CssClass="form-control" Text='<%# Eval("username") %>'></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtpass" runat="server" CssClass="form-control"  Text='<%# Eval("password") %>' TextMode="Password"></asp:TextBox> </td>
                                    <td>
                                        <asp:DropDownList ID="dplrole" runat="server" class="form-control" placeholder="Role" required="true" ClientIDMode="Static">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Admin</asp:ListItem>
                                        <asp:ListItem>Assistant Admin</asp:ListItem>
                                        <asp:ListItem>Accountant</asp:ListItem>
                                        <asp:ListItem>Secretary</asp:ListItem>
                                        <asp:ListItem>Teacher</asp:ListItem>
                                        <asp:ListItem>I.T Personnel</asp:ListItem>
                                    </asp:DropDownList> 

                                    </td>

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
                    <asp:Button ID="btnsave" runat="server" Text="Update" class="btn btn-primary" />
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <asp:HiddenField ID="txtfont" runat="server" />

    <br />

     <script type="text/javascript">

         $('#dplrole').select2({
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
                 document.getElementById("nabyrow1").style.fontFamily = fontstyle;

                 window.setTimeout("countdown()", 1000);
             }
         }
         countdown();
     </script>

</asp:Content>
