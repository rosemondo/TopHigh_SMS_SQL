<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Assesment_Sheet.aspx.vb" Inherits="Top_High_Schools.Assesment_Sheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />

    <script type="text/javascript">
        function printPageArea(areaID) {
            var printContent = document.getElementById(areaID);
            var WinPrint = window.open('', '', 'width=800,height=800');
            WinPrint.document.write(printContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
    </script>


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
        <h4 class="h4 mb-0 text-gray-800">Continuous Assesment Sheet</h4>
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
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ClientIDMode="Static" requide="true"></asp:DropDownList>
                               <asp:HiddenField ID ="txtclassid" runat ="server" />
                        </div>

                        <div class="col-sm-6">
                            <asp:Label ID="Label7" runat="server" class="col-form-label" Text="Subject"></asp:Label>
                            <asp:DropDownList ID="ddlcourse" runat="server" CssClass="form-control" ClientIDMode ="Static" requide="true"></asp:DropDownList>
                            <asp:HiddenField ID ="txtcourseid" runat ="server" />
                        </div>



                    </div>
                    <asp:HiddenField ID ="txtproclassid" runat ="server" />

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
                     <asp:Button ID="Button1" runat="server" Text="Print" CssClass="btn btn-primary" OnClientClick="printPageArea('printableArea')" style="float:right"/>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div id="printableArea" style="background-color: #FFFFFF">


                        <div class="form-group row">

                            <div class="col-sm-4">
                            </div>

                            <div class="col-sm-4">
                                <p style="text-align: center"><strong>Continuous Assesment at Basic Education Level</strong></p>
                                <p style="text-align: center"><strong>Terminal Assesment Plan</strong></p>
                                <p style="text-align: center"><strong>
                                    <asp:Label ID="lblAssClass" runat="server" Text="" /></strong></p>
                                <p style="text-align: center"><strong>
                                    <asp:Label ID="lblAssSub" runat="server" Text="" /></strong></p>
                            </div>

                            <div class="col-sm-4">
                            </div>

                        </div>



                        <br />

                        <div class="table-responsive">
                            <table class="table table-responsive">
                                <thead class="text-primary" id="actstu">
                                    <tr>
                                        <th>Student</th>
                                        <th>Exercise 10%</th>
                                        <th>Exercise 10%</th>
                                        <th>Exercise 10%</th>
                                        <th>Exercise 10%</th>
                                        <th>Exercise Total 40%</th>
                                        <th>Test 20%</th>
                                        <th>Test 10%</th>
                                        <th>Test 10%</th>
                                        <th>Test Total 40%</th>
                                        <th>H.Work 5%</th>
                                        <th>H.Work 5%</th>
                                        <th>H.Work 5%</th>
                                        <th>H.Work 5%</th>
                                        <th>H.Work Total 20%</th>
                                        <th>Sch. Work Total 100%</th>
                                        <th>Sch. Work Total 50%</th>
                                        <th>End of Term Exams 100%</th>
                                        <th>End of Term Exams 50%</th>
                                        <th>Over-All Total 100%</th>
                                        <th>Grades</th>
                                        <th>Remarks</th>
                                        <th font-bold="true">Subject Positions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterDB" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="studcode" runat="server" Text='<%# Eval("student_name") %>' /></td>
                                                <td>
                                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("class_exe_1") %>' /></td>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("class_exe_2")%>' /></td>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("class_exe_3") %>' /></td>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("class_exe_4")%>' /></td>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("class_total_40") %>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" Text='<%# Eval("class_test_20")%>' /></td>
                                                <td>
                                                    <asp:Label ID="Label25" runat="server" Text='<%# Eval("class_test_1") %>' /></td>
                                                <td>
                                                    <asp:Label ID="Label26" runat="server" Text='<%# Eval("class_test_2")%>' /></td>
                                                <td>
                                                    <asp:Label ID="Label27" runat="server" Text='<%# Eval("class_test_total_40") %>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label28" runat="server" Text='<%# Eval("homework_1")%>' /></td>
                                                <td>
                                                    <asp:Label ID="Label29" runat="server" Text='<%# Eval("homework_2")%>' /></td>
                                                <td>
                                                    <asp:Label ID="Label30" runat="server" Text='<%# Eval("homework_3")%>' /></td>
                                                <td>
                                                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("homework_4")%>' /></td>
                                                <td>
                                                    <asp:Label ID="Label32" runat="server" Text='<%# Eval("homework_total_20")%>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("class_wk_100")%>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("class_wk_50")%>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("exams_score")%>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("exams_50")%>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("final_score_100")%>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("grades")%>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("remarks")%>' Font-Bold="true" ForeColor="Black" /></td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("rank_str")%>' Font-Bold="true" ForeColor="Black" /></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <!-- /.card-body -->
                 <div class="card-footer">
                    <asp:Button ID="Button2" runat="server" Text="Print" CssClass="btn btn-primary" OnClientClick="printPageArea('printableArea')" style="float:right"/>
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
        </div>
    </div>

 </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnsearch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

         <asp:HiddenField ID="txtfont" runat="server" />

    <script type="text/javascript">

        $('#ddlClass').select2({
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

                 window.setTimeout("countdown()", 1000);
             }
         }
         countdown();
     </script>

</asp:Content>
