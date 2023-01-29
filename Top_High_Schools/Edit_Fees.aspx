<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_Fees.aspx.vb" Inherits="Top_High_Schools.Edit_Fees" %>

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
        <h4 class="h4 mb-0 text-gray-800">Edit School Fees</h4>
    </div>

    <div class="row" id="nabyrow1">
        <div class="col-md-12">
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-6">
                            <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Learners"></asp:Label>
                            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" requide="true" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <asp:Button ID="cmdsearch" runat="server" Text="Search" CssClass="btn btn-success" />
                        <asp:HiddenField ID="txtStudid" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="phrow3">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>


                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="text-primary" id="actstu">
                                        <tr>
                                            <th>ID</th>
                                            <th>Date</th>
                                            <th>Description</th>
                                            <th>Debit</th>
                                            <th>Credit</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="RepeaterDB" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("stid") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("st_date", "{0: yyyy-MM-dd}") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdescription" runat="server" CssClass="form-control" Text='<%# Eval("description")%>'></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdebit" runat="server" CssClass="form-control" Text='<%# Eval("debit")%>'></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtcredit" runat="server" CssClass="form-control" Text='<%# Eval("credit")%>'></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="btndelete" runat="server" OnClick="GetDelete" Text="Delete" OnClientClick="return confirm('Are You Sure to Delete?')" Style="padding: 5px" ImageUrl="~/img/delete-24.png" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlStudent" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="cmdsearch" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btn_Gen" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btn_Gen" runat="server" Text="Update" class="btn btn-primary" Style="float: right" OnClick="OnSave" />
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:HiddenField ID="txtusers" runat="server" />
            <asp:HiddenField ID="txtlocation" runat="server" />
            <asp:HiddenField ID="txtID" runat="server" />
            <asp:HiddenField ID="txttimer" runat="server" />
        </div>
    </div>
    <asp:HiddenField ID="txtfont" runat="server" />

    <script type="text/javascript">

        $('#ddlStudent').select2({
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
                document.getElementById("phrow3").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
