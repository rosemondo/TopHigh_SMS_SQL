<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Add_Arears_By_Class.aspx.vb" Inherits="Top_High_Schools.Add_Arears_By_Class" %>

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
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h4 class="h4 mb-0 text-gray-800">Student Attendance</h4>
         <a href="Attendance_List.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i>Attendace List</a>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-8">
                            <label id="lblclass">Class</label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ClientIDMode ="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                        </div>

                        <div class="col-sm-4">
                            <label id="lbldate">Date</label>
                            <asp:TextBox ID="txtdate" CssClass="form-control" runat="server" TextMode="Date" require="true"></asp:TextBox>
                        </div>

                       
                        <asp:TextBox runat="server" ID="txtclassid" Visible="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row">
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
                                    <th>Student Code</th>
                                    <th>Student</th>
                                    <th>Arrears</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterDB" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="studcode" runat="server" Text='<%# Eval("Student Code")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="studname" runat="server" Text='<%# Eval("Student")%>' />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtamt" runat="server" Text="0.00" CssClass="form-control"></asp:TextBox>
                                            </td>
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
            <asp:TextBox ID="txttimer" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtReceAcc" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtAdmAcc" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtbill" runat="server" Visible="false"></asp:TextBox>
        </div>
    </div>

     <asp:HiddenField ID="txtfont" runat="server"/>

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

                 document.getElementById("lblclass").style.fontFamily = fontstyle;
                 document.getElementById("lbldate").style.fontFamily = fontstyle;
                 document.getElementById("actstu").style.fontFamily = fontstyle;

                 window.setTimeout("countdown()", 1000);
             }
         }
         countdown();
     </script>


     <script type="text/javascript">

         $('#ddlClass').select2({
             placeholder: 'Select an option'
         });

     </script> 

</asp:Content>
