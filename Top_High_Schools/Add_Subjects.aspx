<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Add_Subjects.aspx.vb" Inherits="Top_High_Schools.Add_Subjects" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">All Subjects</h4>
    </div>


    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>


            <div class="row" id="nabyrow1">
                <div class="col-md-12">
                    <div class="card card-info">
                        <div class="card-header">
                            <label style="color: white">Add Subject</label>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">
                                <label>Subject Code</label>
                                <div class="col-sm-2">
                                    <asp:TextBox runat="server" ID="txtcode" CssClass="form-control" ReadOnly="true" Style="background-color: white;"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 col-form-label">Subject</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtsubject" CssClass="form-control"></asp:TextBox>
                                </div>

                                <asp:TextBox runat="server" ID="txtclassid" CssClass="form-control" Visible="false"></asp:TextBox>
                            </div>

                        </div>

                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                        </div>
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
                            <a href="Add_Subjects.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                                class="fa fa-list fa-sm text-white-50"></i>Subject List</a>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="table-responsive">

                                <asp:Repeater ID="rptSubjects" runat="server">
                                    <HeaderTemplate>
                                        <table id="employees" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th scope="col">Subject Code</th>
                                                    <th scope="col">Subject</th>
                                                    <th scope="col">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcode" runat="server" Text='<%# Eval("Subject Code") %>' />
                                                <asp:Label ID="lblid" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Subject") %>' /></td>
                                            <td>
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

                        </div>

                        <!-- /.card-body -->
                        <div class="card-footer">
                        </div>
                        <!-- /.card-footer -->
                    </div>

                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <br />
    <asp:HiddenField ID="txtfont" runat="server" />

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
