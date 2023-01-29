<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Deduction_Setup.aspx.vb" Inherits="Top_High_Schools.Deduction_Setup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="jquery.min.js"></script>
    <script src="jquery.elevatezoom.min.js"></script>

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

        .capitalize {
            text-transform: capitalize;
        }

        #zoomA {
            /* (A) OPTIONAL DIMENSIONS */
            width: 50px;
            height: 50px;
            /* (B) ANIMATE ZOOM */
            /* ease | ease-in | ease-out | linear */
            transition: transform ease-in-out 0.3s;
        }

            /* (C) ZOOM ON HOVER */
            #zoomA:hover {
                width: 200px;
                height: 200px;
            }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Ssnit Deduction Setup</h4>
        <a href="Deduction_Setup.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i>Refresh</a>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Add" />
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <div class="table-responsive">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dvgssnit" runat="server" Width="100%"
                                    AutoGenerateColumns="false" AlternatingRowStyle-BackColor="White"
                                    HeaderStyle-BackColor="dodgerblue" HeaderStyle-ForeColor="White" AllowPaging="true"
                                    OnPageIndexChanging="OnPaging"
                                    PageSize="10">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="#" HtmlEncode="true" />
                                        <asp:BoundField DataField="dedu_items" HeaderText="List" HtmlEncode="true" />
                                         <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrate" runat="server" Text='<%# Eval("ssnit_rate") %>'></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text='%'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnedit" Text="Edit" runat="server" OnClick="Edit" Style="padding: 5px" ImageUrl="~/img/edit-11-24.png" />
                                                <asp:ImageButton ID="btndelete" runat="server" OnClick="Delete" Text="Delete" OnClientClick="return confirm('Are You Sure to Delete?')" Style="padding: 5px" ImageUrl="~/img/delete-24.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>


                                <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" Style="display: none">
                                    <asp:Label Font-Bold="true" ID="Label4" runat="server" Text="Deduction Setup"></asp:Label>
                                    <br />
                                    <table align="center">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Items"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtitems" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtid" Width="40px" MaxLength="5" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="Rate"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtrate" runat="server" Text="0.00"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Save" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>

                                <asp:ModalPopupExtender ID="popup" runat="server" DropShadow="false" PopupControlID="pnlAddEdit" TargetControlID="lnkFake"
                                    BackgroundCssClass="modalBackground">
                                </asp:ModalPopupExtender>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dvgssnit" />
                                <asp:AsyncPostBackTrigger ControlID="btnSave" />
                            </Triggers>
                        </asp:UpdatePanel>


                    </div>
                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />

    <link href="css/CSSes.css" rel="stylesheet" />
    <script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
                        '<img src="images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.6
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        }
        $(document).ready(function () {

            BlockUI("<%=pnlAddEdit.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function Hidepopup() {
            $find("popup").hide();
            return false;
        }
    </script>

    <asp:HiddenField ID="hfid" runat="server" Value="0" />
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

                 window.setTimeout("countdown()", 1000);
             }
         }
         countdown();
     </script>

</asp:Content>
