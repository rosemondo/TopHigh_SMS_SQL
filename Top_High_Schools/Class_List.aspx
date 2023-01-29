<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Class_List.aspx.vb" Inherits="Top_High_Schools.Class_List" %>

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
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Class Settings</h4>

    </div>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <!--Row with two equal columns-->
            <div class="row" id="nabyrow1">


                <div class="col-md-7">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title">Class List</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">



                            <div class="table-responsive">

                                <asp:Repeater ID="rptClasses" runat="server">
                                    <HeaderTemplate>
                                        <table id="studClass" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th scope="col">ID</th>
                                                    <th scope="col">Class Name</th>
                                                    <th scope="col">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblClassName" runat="server" Text='<%# Eval("ClassName") %>' /></td>
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



                        </div>

                        <!-- /.card-body -->
                        <div class="card-footer">
                        </div>
                        <!-- /.card-footer -->
                    </div>

                </div>

                <br />

                <div class="col-md-5">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title">Add Class</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">
                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Class</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Section</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A" />
                                        <asp:ListItem Text="B" Value="B" />
                                        <asp:ListItem Text="C" Value="C" />
                                        <asp:ListItem Text="D" Value="D" />
                                        <asp:ListItem Text="E" Value="E" />
                                        <asp:ListItem Text="F" Value="F" />
                                        <asp:ListItem Text="G" Value="G" />
                                        <asp:ListItem Text="H" Value="H" />
                                        <asp:ListItem Text="I" Value="I" />
                                        <asp:ListItem Text="J" Value="J" />
                                        <asp:ListItem Text="K" Value="K" />
                                        <asp:ListItem Text="L" Value="L" />
                                        <asp:ListItem Text="M" Value="M" />
                                        <asp:ListItem Text="N" Value="N" />
                                        <asp:ListItem Text="O" Value="O" />
                                        <asp:ListItem Text="P" Value="P" />
                                        <asp:ListItem Text="Q" Value="Q" />
                                        <asp:ListItem Text="R" Value="R" />
                                        <asp:ListItem Text="S" Value="S" />
                                        <asp:ListItem Text="T" Value="T" />
                                        <asp:ListItem Text="U" Value="U" />
                                        <asp:ListItem Text="V" Value="V" />
                                        <asp:ListItem Text="W" Value="W" />
                                        <asp:ListItem Text="X" Value="X" />
                                        <asp:ListItem Text="Y" Value="Y" />
                                        <asp:ListItem Text="Z" Value="Z" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Type</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="ddlTarcher" runat="server" CssClass="form-control" ClientIDMode="Static"  AutoPostBack="true" OnSelectedIndexChanged="ddlTarcher_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:TextBox ID="txtteacherID" runat="server" Visible="false"></asp:TextBox>
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

                </div>


                <asp:HiddenField ID="txtdateyear" runat="server" />
                <asp:HiddenField ID="txtdays" runat="server" />
                <asp:HiddenField ID="txtmonths" runat="server" />
                <asp:HiddenField ID="txtseconds" runat="server" />
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlTarcher" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:HiddenField ID="txtfont" runat="server" />

    <br />

    <script type="text/javascript">

        $('#ddlSection').select2({
            placeholder: 'Select an option'
        });

        $('#ddlTarcher').select2({
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
