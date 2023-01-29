<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Check_Class_Duplicate.aspx.vb" Inherits="Top_High_Schools.Check_Class_Duplicate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />
    <link href="jquery-ui_3.css" rel="stylesheet" />
    <script src="jquery-ui.min_2.js"></script>


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

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Student List</h4>
        <a href="Registration_Form.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i>Add New</a>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <a href="Student_List_by_Class.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                                class="fa fa-list fa-sm text-white-50"></i>List By Class</a>

                            <asp:TextBox ID="txtsearh" runat="server" Style="float: right; border-radius: 25px" ToolTip="Search" AutoPostBack="True"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtsearh" ServiceMethod="FetchQualifications" MinimumPrefixLength="1" CompletionSetCount="20" CompletionInterval="0" EnableCaching="true"></cc1:AutoCompleteExtender>
                            <asp:Label ID="Label2" runat="server" Text="Search : " Style="float: right; color: white; padding: 5px"></asp:Label>

                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="table-responsive">

                                <asp:Repeater ID="rptstudent" runat="server">
                                    <HeaderTemplate>
                                        <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th scope="col">Student ID</th>
                                                    <th scope="col">Student Name</th>
                                                    <th scope="col">Date of Birth</th>
                                                    <th scope="col">Gender</th>
                                                    <th scope="col">Age</th>
                                                    <th scope="col">Class</th>
                                                    <th scope="col">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("stud_id") %>' />
                                                <asp:Label ID="lblmyid" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Student") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblODB" runat="server" Text='<%# Eval("Date of Birth", "{0: yyyy-MM-dd}") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Age") %>' /></td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Class Name") %>' /></td>
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
                                <asp:TextBox ID="txtoffset" runat="server" Text="0" Visible="false"></asp:TextBox>
                            </div>

                        </div>

                        <!-- /.card-body -->
                        <div class="card-footer">
                        </div>
                        <!-- /.card-footer -->
                    </div>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtsearh" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>


        </div>

    </div>

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

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>


</asp:Content>
