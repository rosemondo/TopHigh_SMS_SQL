<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Company.aspx.vb" Inherits="Top_High_Schools.Company" %>

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
    </style>

    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrv.ClientID%>').prop('src', e.target.result)
                        .width(150)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Company Info</h4>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-9">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Company Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">School Name</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" class="form-control" ID="txtschname" placeholder="School Name" required="true"></asp:TextBox>
                                    <asp:HiddenField ID="txtid" runat="server" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Street Address</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" class="form-control" ID="txtstreet" placeholder="Street Address" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">City</label>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" class="form-control" ID="txtcity" placeholder="City" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Zip Code</label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" class="form-control" ID="txtzip" placeholder="Zip Code" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Country</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="dplcountry" runat="server" class="form-control" required="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Mobile #</label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" class="form-control" ID="txtmobile" placeholder="Mobile #" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">E-mail</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" class="form-control" ID="txtemail" placeholder="E-mail"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Website</label>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" class="form-control" ID="txtweb" placeholder="Website"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Location</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="dpllocation" runat="server" class="form-control" required="true" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->

            </div>
            <!-- /.card -->

        </div>

        <div class="col-md-3">

            <div class="card card-info">
                <div class="card-header">
                    <h6 class="card-title">Company's Logo</h6>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:Image ID="ImgPrv" runat="server" CssClass="img-thumbnail" ImageUrl="~/images/default-avatar.png" Width="150" Height="175" />

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                   <asp:FileUpload ID="flupImage" runat="server" class="form-control" onchange="ShowImagePreview(this);" />
                    <br />

                    <asp:Button ID="btnupload" runat="server" Text="Upload" class="btn btn-success float-right" Style="width: 200px" />

                </div>
                <!-- /.card-footer -->

            </div>

        </div>
    </div>
    <asp:HiddenField ID="txtfont" runat="server" />
    <br />

    <script type="text/javascript">

        $('#dpllocation').select2({
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
