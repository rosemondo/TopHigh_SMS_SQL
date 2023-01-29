<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Promotion.aspx.vb" Inherits="Top_High_Schools.Promotion" %>

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
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id ="myhd">
        <h4 class="h4 mb-0 text-gray-800">Student Promotions</h4>
    </div>

    <div class="row" id="prow1">
        <div class="col-md-12">
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-3">
                            <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Class"></asp:Label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <asp:Label ID="Label2" runat="server" class="col-form-label" Text="Promoted To"></asp:Label>
                            <asp:DropDownList ID="ddlproclass" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                        </div>

                        <div class="col-sm-2">
                            <asp:Label ID="Label3" runat="server" class="col-form-label" Text="Date"></asp:Label>
                            <asp:TextBox ID="txtdate" CssClass="form-control" runat="server" TextMode="Date" require="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <asp:Label ID="Label4" runat="server" class="col-form-label" Text="Academic Year"></asp:Label>
                            <asp:DropDownList ID="ddlacayear" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <div class="col-sm-2">
                            <asp:Label ID="Label5" runat="server" class="col-form-label" Text="Academic Term"></asp:Label>
                            <asp:DropDownList ID="ddlacaterm" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                        <asp:TextBox runat="server" ID="txttypeid" Visible="false"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txttypeproid" Visible="false"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtclassid" Visible="false"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtproclassid" Visible="false"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txttuition" Visible="false"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtprotuition" Visible="false"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txttimer" Visible="false"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtSchAcc" Visible="false"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtReceAcc" Visible="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="prow2">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="table-responsive">
                        <table class="table">
                            <thead class="text-primary" id="actstu">
                                <tr>
                                    <th>
                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true"
                                            OnCheckedChanged="Check_UnCheckAll" />
                                    </th>
                                    <th>Student Code</th>
                                    <th>Student</th>
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
                                                <asp:Label ID="studcode" runat="server" Text='<%# Eval("Student Code") %>' /></td>
                                            <td>
                                                <asp:Label ID="studname" runat="server" Text='<%# Eval("Student")%>' /></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btn_Gen" runat="server" Text="Apply" class="btn btn-success" OnClick="OnSave" />
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlinkcode" runat="server" Visible="false"></asp:TextBox>
            <asp:HiddenField ID="txtfont" runat="server" />
        </div>
    </div>

    <script type="text/javascript">

        $('#ddlClass').select2({
            placeholder: 'Select an option'
        });

        $('#ddlproclass').select2({
            placeholder: 'Select an option'
        });

        $('#ddlacayear').select2({
            placeholder: 'Select an option'
        });

        $('#ddlacaterm').select2({
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
                document.getElementById("prow1").style.fontFamily = fontstyle;
                document.getElementById("prow2").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>


</asp:Content>
