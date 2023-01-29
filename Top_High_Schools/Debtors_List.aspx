﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Debtors_List.aspx.vb" Inherits="Top_High_Schools.Debtors_List" %>

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

    <script type="text/javascript">
        function printPageArea(areaID) {
            var printContent = document.getElementById(areaID);
            var WinPrint = window.open('', '', 'width=1500,height=1500');
            WinPrint.document.write(printContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Debtors List By Class</h4>
        <a href="" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-list fa-sm text-white-50"></i>Debtors List</a>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <!-- Horizontal Form -->
                    <div class="card card-info">


                        <div class="card-header">

                            <br />

                            <div>
                                <asp:Button ID="Button2" runat="server" Text="Print" CssClass="btn btn-primary" OnClientClick="printPageArea('printableArea')" Style="float: right" />
                            </div>
                            <div>
                                <asp:Button ID="btnsend" runat="server" CssClass="form-control btn-success" Text="Send School Fees Reminders" Style="float: right; width: 250px; color: white; padding: 5px; margin: 5px"></asp:Button>
                            </div>
                            <div>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" Style="float: right; width: 170px; padding: 5px; margin: 5px" TextMode="Date" required="true"></asp:TextBox>
                            </div>
                            <div>
                                <asp:DropDownList ID="dplclass" runat="server" CssClass="form-control" Style="width: 250px;" ClientIDMode="Static" AutoPostBack ="true" OnSelectedIndexChanged="OnSelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->


                        <div id="printableArea" style="background-color: #FFFFFF">

                            <div class="card-body">

                                <div class="table-responsive">
                                    <table class="table">
                                        <thead class="text-primary" id="actstu">
                                            <tr>
                                                <th style="text-align: left">Student</th>
                                                <th style="text-align: left">Class</th>
                                                <th style="text-align: center">Fees Due</th>
                                                <th style="text-align: left">Father's Contact</th>
                                                <th style="text-align: left">Mother's Contact</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="feesdb" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="name" runat="server" Text='<%# Eval("students")%>' /></td>
                                                        <td>
                                                            <asp:Label ID="class" runat="server" Text='<%# Eval("class")%>' /></td>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="fees" runat="server" Text='<%# Eval("balance", "{0:N2}")%>' />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="contacs" runat="server" Text='<%# Eval("fathers mobile")%>' /></td>
                                                        <td>
                                                            <asp:Label ID="momcont" runat="server" Text='<%# Eval("mothers mobile")%>' /></td>
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
                        </div>
                        <!-- /.card-footer -->
                    </div>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="dplclass" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>

        </div>

    </div>

    <asp:HiddenField ID="txtfont" runat="server" />
    <br />

    <script type="text/javascript">

        $('#dplclass').select2({
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
