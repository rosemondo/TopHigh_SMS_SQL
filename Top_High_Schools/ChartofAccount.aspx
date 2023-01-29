<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ChartofAccount.aspx.vb" Inherits="Top_High_Schools.ChartofAccount" %>

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
        <h4 class="h4 mb-0 text-gray-800">Account List</h4>
        <a href="New_Accounts.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
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
                            <a href="ChartofAccount.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                                class="fa fa-list fa-sm text-white-50"></i></a>

                            <asp:TextBox ID="txtsearh" runat="server" Style="float: right; border-radius: 25px" ToolTip="Search" AutoPostBack="True"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtsearh" ServiceMethod="FetchQualifications" MinimumPrefixLength="1" CompletionSetCount="20" CompletionInterval="0" EnableCaching="true"></cc1:AutoCompleteExtender>
                            <asp:Label ID="Label2" runat="server" Text="Search : " Style="float: right; color: white; padding: 5px"></asp:Label>
                            <%-- <asp:DropDownList ID="dplimit" runat="server" class="form-control" placeholder="Role" required="true" Style="float: right; width: 80px">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                    </asp:DropDownList>--%>
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
                                                    <th scope="col">ID</th>
                                                    <th scope="col">Account Code</th>
                                                    <th scope="col">Account Name</th>
                                                    <th scope="col">Account Group</th>
                                                    <th scope="col">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("coa_id") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("coa_code") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblODB" runat="server" Text='<%# Eval("coa_name") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("coa_group") %>' /></td>
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
                                <asp:TextBox ID="txtoffset" runat="server" Text="0" Visible="false"></asp:TextBox>
                            </div>
                            <div class="form-group row justify-content-center">
                                <%--<div class="col-sm-2">
                        </div>
                        <div class="col-sm-0.5">
                            <asp:Button ID="btnfirst" runat="server" Text="<<" class="btn btn-primary" Style="padding: 5px; margin: 5px; width: 60px" />
                        </div>
                        <div class="col-sm-0.5">

                            <asp:Button ID="btnprevious" runat="server" Text="<" class="btn btn-primary" Style="padding: 5px; margin: 5px; width: 60px" />
                        </div>--%>
                                <div class="col-sm-2 justify-content-center">
                                    <asp:Label ID="Label1" runat="server" Text="Total Row(s)" Style="font-size: 14px; color: black; align-items: center" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="lbltotals" runat="server" Text="0" Style="font-size: 14px; color: black; align-items: center" Font-Bold="true"></asp:Label>
                                </div>
                                <%--<div class="col-sm-0.5">
                            <asp:Button ID="btnnext" runat="server" Text=">" class="btn btn-primary" Style="padding: 5px; margin: 5px; width: 60px" />
                        </div>
                        <div class="col-sm-0.5">
                            <asp:Button ID="btnlast" runat="server" Text=">>" class="btn btn-primary" Style="padding: 5px; margin: 5px; width: 60px" />
                        </div>
                        <div class="col-sm-2">
                        </div>--%>
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

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
