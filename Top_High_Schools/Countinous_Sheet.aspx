<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Countinous_Sheet.aspx.vb" Inherits="Top_High_Schools.Countinous_Sheet" %>

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
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Student Activation</h4>
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
                            <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Class"></asp:Label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <asp:Label ID="Label2" runat="server" class="col-form-label" Text="subject"></asp:Label>
                            <asp:DropDownList ID="ddlcourse" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                            <asp:HiddenField ID="txtstsudid" runat="server" />
                            <asp:HiddenField ID="txtclass" runat="server" />
                            <asp:HiddenField ID="txtcourse" runat="server" />
                        </div>
                     
                        <asp:TextBox ID="txtclassid" runat="server" Visible="false"></asp:TextBox>
                    </div>

                    <div class="form-group row">

                        <div class="col-sm-6">
                            <asp:Label ID="Label3" runat="server" class="col-form-label" Text="Tutor Remarks"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtlectremarks" ViewStateMode="Disabled" EnableViewState="False"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <asp:Label ID="Label6" runat="server" class="col-form-label" Text="Principals Remarks"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtprincipalremarks" ViewStateMode="Disabled" EnableViewState="False"></asp:TextBox>
                        </div>
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

                     <asp:Button ID="btnapply" runat="server" Text="Apply" class="btn btn-success" OnClick="OnClassAssesment"  style="float:right"/>

                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="table-responsive">
                        <table class="table">
                            <thead class="text-primary" id="actstu">
                                <tr>
                                    <th>Student</th>
                                    <th>Exercise 10%</th>
                                    <th>Exercise 10%</th>
                                    <th>Exercise 10%</th>
                                    <th>Exercise 10%</th>
                                    <th>Class Test 20%</th>
                                    <th>Class Test 10%</th>
                                    <th>Class Test 10%</th>
                                    <th>Home Work 5%</th>
                                    <th>Home Work 5%</th>
                                    <th>Home Work 5%</th>
                                    <th>Home Work 5%</th>
                                    <th>Exams 100%</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterDB" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="studname" runat="server" Text='<%# Eval("Student")%>' />
                                                <asp:Label ID="studcode" runat="server" Text='<%# Eval("Student Code") %>' Visible="false" /></td>
                                            <td>
                                                <asp:TextBox ID="txtexe1" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe2" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe3" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe4" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                             <td>
                                                <asp:TextBox ID="txtexe5" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe6" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe7" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe8" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe9" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                             <td>
                                                <asp:TextBox ID="txtexe10" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe11" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtexe12" CssClass="form-control" Text ="0" runat="server"></asp:TextBox></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                </div>
             
                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btn_Gen" runat="server" Text="Apply" class="btn btn-success" OnClick ="OnClassAssesment" />
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtyear" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtterm" runat="server" Text ="2" Visible="false"></asp:TextBox>
              <asp:HiddenField ID="txtuseraccess" runat="server" />
    <asp:HiddenField ID="txtmyclass" runat="server" />
        </div>
    </div>

    <asp:HiddenField ID="txtfont" runat="server" />

     <script type="text/javascript">

         $('#ddlcourse').select2({
             placeholder: 'Select an option'
         });

         $('#ddlClass').select2({
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
