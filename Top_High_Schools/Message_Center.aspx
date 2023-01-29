<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Message_Center.aspx.vb" Inherits="Top_High_Schools.Message_Center" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />

     <script language="javascript" type="text/javascript">
         function tog1(Check) {
             if (Check == document.getElementById('<%=chkboradcast.ClientID%>')) {
                 document.getElementById('<%=chksingle.ClientID%>').checked = false;
             }
             else {
                 document.getElementById('<%=chkboradcast.ClientID%>').checked = false;
             }

         }

     </script>

    <script language="javascript" type="text/javascript">
        function tog2(Check) {
            if (Check == document.getElementById('<%=chksingle.ClientID%>')) {
                 document.getElementById('<%=chkboradcast.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chksingle.ClientID%>').checked = false;
            }

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
                                            <th scope="col">Student</th>
                                            <th scope="col">Father's Name</th>
                                             <th scope="col">Mother's Name</th>
                                            <th scope="col">Father's #</th>
                                            <th scope="col">Mother's #</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><asp:Label ID="lblstudent" runat="server" Text='<%# Eval("student_name") %>' /></td>
                                    <td><asp:Label ID="lblfather" runat="server" Text='<%# Eval("fathers_name") %>' /></td>
                                    <td><asp:Label ID="lblmother" runat="server" Text='<%# Eval("mathers_name") %>' /></td>
                                    <td><asp:Label ID="lblcontacts" runat="server" Text='<%# Eval("mobile") %>' /></td>
                                    <td><asp:Label ID="lblmoncon" runat="server" Text='<%# Eval("math_mobile") %>' /></td>
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
                    <label for="inputEmail3" style="float:left;color:white"><h5>Send Text Message(s)</h5></label>
                    <asp:CheckBox ID="chksingle" runat="server" onclick="tog1(this);" Text=" Single" style="float:right;color:white;padding:5px" />
                    <asp:CheckBox ID="chkboradcast" runat="server" onclick="tog2(this);" Text=" Broadcast" style="float:right;color:white;padding:5px" />
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-sm-4">
                            <label for="inputEmail3">Student</label>
                             <asp:DropDownList ID="ddlstudent" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="getContact()">
                            </asp:DropDownList>
                        </div> 
                        <div class="col-sm-4">
                            <label for="inputEmail3">Father's Contacts</label>
                             <asp:TextBox ID="txtcontac" runat="server" CssClass="form-control"></asp:TextBox>
                        </div> 
                        <div class="col-sm-4">
                            <label for="inputEmail3">Mother's Contacts</label>
                             <asp:TextBox ID="txtmother" runat="server" CssClass="form-control"></asp:TextBox>
                        </div> 
                    </div>

                    <div class="form-group row">
                        <div class="col-sm-12">
                            <label for="inputPassword3" class="col-sm-2 col-form-label">Subject</label>
                          <asp:TextBox ID="txtsubject" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-sm-12">
                            <label for="inputPassword3" class="col-sm-2 col-form-label">Message</label>
                          <asp:TextBox ID="txtmessage" runat="server" CssClass="form-control" TextMode="MultiLine" Height="300px" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <hr />

                </div>
                 
                <!-- /.card-body -->
                <div class="card-footer">
                     <asp:Button ID="btnsave" runat="server" Text="Send" class="btn btn-primary" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->
            </div>

        </div>
        <asp:TextBox ID="txtdateyear" runat="server" Visible ="false"></asp:TextBox>
        <asp:TextBox ID="txtdays" runat="server" Visible ="false"></asp:TextBox>
        <asp:TextBox ID="txtmonths" runat="server" Visible ="false"></asp:TextBox>
        <asp:TextBox ID="txtseconds" runat="server" Visible ="false"></asp:TextBox>
        <asp:HiddenField ID="txtfont" runat="server" />
    </div>

    <br />

     <script type="text/javascript">

         $('#ddlstudent').select2({
             placeholder: 'Select an option'
         });

     </script> 

    <script type ="text/javascript">

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
