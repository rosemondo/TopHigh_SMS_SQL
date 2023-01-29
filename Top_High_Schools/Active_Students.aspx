<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Active_Students.aspx.vb" Inherits="Top_High_Schools.Active_Students" %>

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
        <h4 class="h4 mb-0 text-gray-800" id="stuact">Student Activation</h4>
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
                            <label id="lblclass">Class</label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <label id="lbldate">Date</label>
                            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" TextMode="Date" required="true"></asp:TextBox>
                        </div>

                        <asp:TextBox ID="txtclassid" runat="server" Visible="false"></asp:TextBox>
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

                    <asp:Button ID="btnapply" runat="server" Text="Apply" class="btn btn-success" OnClick="OnSave" Style="float: right" />

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
                                            <th>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true"
                                                    OnCheckedChanged="Check_UnCheckAll" />
                                            </th>
                                            <th id="thcode">Student Code</th>
                                            <th id="thstud">Student</th>
                                            <th id="thacti">Active</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="RepeaterDB" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="checkboxId" runat="server" AutoPostBack="true"
                                                            OnCheckedChanged="OnRowCheckedUnchecked" /></td>
                                                    <td>
                                                        <asp:Label ID="studcode" runat="server" Text='<%# Eval("stud_id") %>' />
                                                        <asp:Label ID="tbid" runat="server" Text='<%# Eval("id") %>' Visible="true" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="studname" runat="server" Text='<%# Eval("student_name")%>' /></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlactive" runat="server" ClientIDMode="Static">
                                                            <asp:ListItem Text="" Value="" />
                                                            <asp:ListItem Text="Active" Value="Active" />
                                                            <asp:ListItem Text="In Active" Value="In Active" />
                                                            <asp:ListItem Text="Dormant" Value="Dormant" />
                                                            <asp:ListItem Text="Graduated" Value="Graduated" />
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClass" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkAll" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="btnapply" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btn_Gen" runat="server" Text="Apply" class="btn btn-success" OnClick="OnSave" />
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
            <asp:HiddenField ID="txtfont" runat="server" />
        </div>
    </div>

    <script type="text/javascript">

        $('#ddlClass').select2({
            placeholder: 'Select an option'
        });

        $('#ddlactive').select2({
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
