<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Staff_Email_SMS.aspx.vb" Inherits="Top_High_Schools.Staff_Email_SMS" %>

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

        .select2-container .select2-selection--single {
            height: 34px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Messaging Center</h4>

    </div>

    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-6">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Contact List</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div>

                        <asp:Repeater ID="rptClasses" runat="server">
                            <HeaderTemplate>
                                <table id="studClass" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th scope="col">Staff</th>
                                            <th scope="col">Contact</th>
                                            <th scope="col">Email</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblstaff" runat="server" Text='<%# Eval("Employee") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("Contact") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblemail" runat="server" Text='<%# Eval("email") %>' /></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                    </div>

                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

        <br />

        <div class="col-md-6">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <label for="inputEmail3" style="float: left; color: white">
                        <h5>Send Text Message(s) & E-mails</h5>
                    </label>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <label>Attachment</label>
                                    <asp:FileUpload ID="fuAttachment" runat="server" CssClass="form-control" AllowMultiple="true" />
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <label>Subject</label>
                                    <asp:TextBox ID="txtsubject" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <label>Message</label>
                                    <asp:TextBox ID="txtmessage" runat="server" CssClass="form-control" TextMode="MultiLine" Height="300px" required="true"></asp:TextBox>
                                </div>
                            </div>

                            <hr />

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
                             <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnsave" runat="server" Text="Send SMS" class="btn btn-primary" OnClick="Broadcast_Message" />
                    <asp:Button ID="btncancel" runat="server" Text="Send Email" class="btn btn-success float-right" OnClick="Broadcast_Emails" />
                </div>
                <!-- /.card-footer -->
            </div>

        </div>
        <asp:TextBox ID="txtdateyear" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtdays" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtmonths" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtseconds" runat="server" Visible="false"></asp:TextBox>
        <asp:HiddenField ID="txtfont" runat="server" />
    </div>

    <br />

    <script type="text/javascript">

        $('#ddlstudent').select2({
            placeholder: 'Select an option'
        });

    </script>

    <script type="text/javascript">

        function getContact() {
            var contacts = $("[id*=ddlstudent]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Message_Center.aspx/GetParentContact",
                data: "{contacts:'" + contacts + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtcontac]').val(data.d.FathMobile);
                    $('[id*=txtmother]').val(data.d.MothMobile);
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };

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
