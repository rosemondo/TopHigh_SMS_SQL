<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Exemption_Unpaid_List.aspx.vb" Inherits="Top_High_Schools.Exemption_Unpaid_List" %>

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

        .capitalize {
            text-transform: capitalize;
        }
    </style>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Exemption List</h4>
        <a href="Canteen_list.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-list fa-sm text-white-50"></i>List</a>
    </div>



    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Exemption List</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">


                    <div id="printableArea" style="background-color: #FFFFFF">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>


                                <div class="table-responsive">

                                    <asp:Repeater ID="rptReportMain" runat="server" OnItemDataBound="OnItemDataBound">


                                        <ItemTemplate>


                                            <table id="students" class="table table-bordered table-striped" border="0" cellspacing="0" width="100%">

                                                <thead>

                                                    <tr>
                                                        <td colspan="8"></td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="8">
                                                            <hr style="border: thin dotted #000000" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="8" style="text-align: center" class="auto-style5">
                                                            <asp:Label ID="Label11" runat="server" Text="Exemption List by Class" Font-Bold="True" Font-Underline="true" Font-Size="large" Style="padding: 15px"></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="8">
                                                            <hr style="border: thin dotted #000000" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <th colspan="8" align="left">Class : 
                                     <asp:Label ID="lblproduct" runat="server" Text='<%# Eval("Class Name") %>' />
                                                            <asp:Label ID="Label4" runat="server" Text=' - ' />
                                                            <asp:Label ID="Label2" runat="server" Text='Count : ' />
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Count") %>' />
                                                            <asp:HiddenField ID="hfdate" runat="server" Value='<%# Eval("Class Name") %>' />
                                                        </th>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="8">
                                                            <hr style="border: thin dotted #000000" />
                                                        </td>
                                                    </tr>

                                                    <tr style="border: thin">
                                                        <th scope="col" align="left">Student Code</th>
                                                        <th scope="col" align="left">Student</th>
                                                        <th scope="col" align="left">Exemption Type</th>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="8">
                                                            <hr style="border: thin dotted #000000" />
                                                        </td>
                                                    </tr>

                                                </thead>


                                                <asp:Repeater ID="rptRepoDetails" runat="server">

                                                    <ItemTemplate>
                                                        <tr style="border: thin">
                                                            <td>
                                                                <asp:Label ID="lblsubjects" runat="server" Text='<%# Eval("stud_id") %>' Style="float: left" />
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblclass" runat="server" Text='<%# Eval("Student") %>' Style="float: left" />
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblexems" runat="server" Text='<%# Eval("exemption_type") %>' Style="float: left" />
                                                            </td>
                                                        </tr>

                                                    </ItemTemplate>


                                                </asp:Repeater>

                                                <tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <hr style="border: thin dotted #000000" />
                                                        </td>
                                                    </tr>

                                                </tr>
                                        </ItemTemplate>

                                        <FooterTemplate>
                                            </tbody> </table>
                                        </FooterTemplate>

                                    </asp:Repeater>

                                </div>

                                <br />

                            </ContentTemplate>
                            
                        </asp:UpdatePanel>

                    </div>

                </div>

            </div>

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
                document.getElementById("printableArea").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>


</asp:Content>
