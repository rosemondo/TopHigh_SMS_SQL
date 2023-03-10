<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_Exams.aspx.vb" Inherits="Top_High_Schools.Edit_Exams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />

   <%--  <script>
         function sum() {
             var txt1 = document.getElementById('<%= txtexe1.ClientID %>').value;
             var txt2 = document.getElementById('<%= txtexe2.ClientID %>').value;
             var txt3 = document.getElementById('<%= txtexe3.ClientID %>').value;
             var txt4 = document.getElementById('<%= txtexe4.ClientID %>').value;
             var result = parseFloat(txt1) + parseFloat(txt2) + parseFloat(txt3) + parseFloat(txt4);
            if (!isNaN(result)) {
                document.getElementById('<%= txttotals.ClientID %>').value = result;
             }
         }
     </script>--%>

<%--     <script>
         function addsum() {
            
             var txt9 = document.getElementById('<%= txtexam100.ClientID %>').value;
             var mytxt = document.getElementById('<%= txt2.ClientID %>').value;
             var myresult = parseFloat(txt9) / mytxt;
            if (!isNaN(result)) {
                document.getElementById('<%= txtexam50.ClientID %>').value = myresult;
             }
         }
     </script>

     <script>
         function myFunction(txt) {

             var txt12 = document.getElementById('txttot50').value;
             var txt13 = document.getElementById('txtexam50').value;
             var myaddresult = parseFloat(txt12) + parseFloat(txt13);
            if (!isNaN(result)) {
                document.getElementById('txttot100').value = myaddresult;
             }
         }
     </script>--%>
       

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
        <h4 class="h4 mb-0 text-gray-800">Exams Sheet</h4>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="row" id="nabyrow1">
                <div class="col-md-12">
                    <div class="card card-info">
                        <div class="card-header">
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">

                                <div class="col-sm-4">
                                    <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Class"></asp:Label>
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:HiddenField ID="txtclassid" runat="server" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:Label ID="Label2" runat="server" class="col-form-label" Text="Student"></asp:Label>
                                    <asp:DropDownList ID="ddlstudent" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlstudent_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:HiddenField ID="txtstsudid" runat="server" />
                                    <asp:HiddenField ID="txtclass" runat="server" />
                                    <asp:HiddenField ID="txtcourse" runat="server" />
                                </div>



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

                            <asp:HiddenField ID="txtproclassid" runat="server" />
                        </div>

                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-success" Style="float: right" />
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

                    <div class="card card-info">
                        <div class="card-header">
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">

                                <div class="col-sm-6">
                                    <asp:Label ID="Label7" runat="server" class="col-form-label" Text="Subject"></asp:Label>
                                    <asp:DropDownList ID="ddlcourse" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:HiddenField ID="txtcourseid" runat="server" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:Label ID="Label10" runat="server" class="col-form-label" Text="Exams Score 100%"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtexe1" Text="0" required="true" onkeyup="sum()"></asp:TextBox>
                                </div>

                            </div>

                            <br />

                        </div>
                        <div>
                        </div>

                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:Button ID="btn_Gen" runat="server" Text="Process" class="btn btn-success" OnClick="InsertAssesment" />
                        </div>
                        <!-- /.card-footer -->
                    </div>
                    <asp:HiddenField ID="txtusers" runat="server" />
                    <asp:HiddenField ID="txtlocation" runat="server" />
                    <asp:HiddenField ID="txtlinkcode" runat="server" />
                    <asp:HiddenField ID="txtgrade" runat="server" />
                    <asp:HiddenField ID="txtremark" runat="server" />
                    <asp:HiddenField ID="txt2" runat="server" Value="2" />
                    <asp:HiddenField ID="txtyear" runat="server" />
                    <asp:HiddenField ID="txtterm" runat="server" />
                    <asp:HiddenField ID="txtuseraccess" runat="server" />
                    <asp:HiddenField ID="txtmyclass" runat="server" />
                </div>
            </div>

            <br />

            <div class="row" id="phrow4">
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
                                            <th>Student</th>
                                            <th>Subject</th>
                                            <th>Exams Score 100%</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="RepeaterDB" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="studcode" runat="server" Text='<%# Eval("student_name") %>' />
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="studname" runat="server" Text='<%# Eval("subject")%>' /></td>
                                                    <td>
                                                        <asp:Label ID="Label23" runat="server" Text='<%# Eval("exams_score") %>' /></td>
                                                    <td>
                                                        <asp:ImageButton ID="btnedit" Text="Edit" runat="server" OnClick="GetValue" Style="padding: 5px" ImageUrl="~/img/edit-11-24.png" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>

                        </div>

                    </div>

                </div>
            </div>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlClass" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlstudent" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlcourse" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnsearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_Gen" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:HiddenField ID="txtID" runat="server" />
    <asp:HiddenField ID="txtfont" runat="server" />

    <script type="text/javascript">

        $('#ddlClass').select2({
            placeholder: 'Select an option'
        });

        $('#ddlstudent').select2({
            placeholder: 'Select an option'
        });

        $('#ddlcourse').select2({
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
                document.getElementById("phrow4").style.fontFamily = fontstyle;


                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
