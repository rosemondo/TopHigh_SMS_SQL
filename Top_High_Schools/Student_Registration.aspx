<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_Registration.aspx.vb" Inherits="Top_High_Schools.Student_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="jquery.min_9.js"></script>

    <script src="WebCam.js"></script>

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

    <script src="webcamjs/webcam.min.js"></script>

    <script src="webcamjs/webcam.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h4 class="h4 mb-0 text-gray-800">Students & Parents Info</h4>
        <a href="StudentList.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-list fa-sm text-white-50"></i>Student List</a>
    </div>


    <div class="row">


        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Snap & Save Leaner's Photo</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group">

                        <div class="col-md-12">


                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th align="center"><u>Live Camera</u></th>
                                    <th align="center"><u>Captured Picture</u></th>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="webcam"></div>
                                    </td>
                                    <td></td>
                                    <td>
                                        <img id="imgCapture" src="" /></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <input type="button" id="btnCapture" value="Capture" />
                                    </td>
                                </tr>
                            </table>


                        </div>

                    </div>

                    <div class="form-group row">

                        <div class="col-md-8">
                            <div class="form-group">
                                <label>Pupil's Name</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-user"></i></span>
                                    </div>
                                    <asp:TextBox runat="server" class="form-control capitalize" ID="txtnameofchild" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Date of Birth</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                                </div>
                                <asp:TextBox ID="txtdateofbirth" CssClass="form-control" runat="server" TextMode="Date" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Gender</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text"><i class="fa fa-user"></i></span>
                                </div>
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="custom-select">
                                    <asp:ListItem Value="-1">Choose Gender</asp:ListItem>
                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Age</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text"><i class="fa fa-child" aria-hidden="true"></i></span>
                                </div>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtage" required="true" Text="0" ReadOnly="true" BackColor="White"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="form-group row">

                        <div class="col-sm-6">
                            <label for="inputPassword3">Hometown</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text"><i class="fa fa-home" aria-hidden="true"></i></span>
                                </div>
                                <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txthometown"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <label>Region</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text"><i class="fa fa-globe" aria-hidden="true"></i></span>
                                </div>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtregion"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group row">

                        <div class="col-sm-6">
                            <label>Nationality</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text"><i class="fa fa-flag" aria-hidden="true"></i></span>
                                </div>
                                <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtnationality"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <label>Religion</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text"><i class="fa fa-church" aria-hidden="true"></i></span>
                                </div>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtreligion"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                </div>


            </div>
            <!-- /.card -->

        </div>

    </div>

    <br />

    <div class="row">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Particulars Of Father</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">


                    <div class="form-group row">

                        <div class="col-md-10">
                            <div class="form-group">
                                <label>Father's Name</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-male"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtfathersname" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="form-group row">


                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Address</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-map-marker"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtaddress" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Mobile #</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-phone"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtmobile" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>

                    <div class="form-group row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Father's Occupation</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-toolbox"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtfatOcupa" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Father's Religion</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-church"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtfatreligion" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Father's Education</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-book"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtfateducation" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Dead/Alive</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-user"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtfatdeadalive" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>

                </div>


            </div>
            <!-- /.card -->

        </div>

    </div>

    <br />

    <div class="row">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Particulars Of Mother</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">


                    <div class="form-group row">

                        <div class="col-md-10">
                            <div class="form-group">
                                <label>Mother's Name</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-female"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtmatname" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="form-group row">


                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Address</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-map-marker"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtmataddress" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Mobile #</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-phone"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtmatmobile" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>

                    <div class="form-group row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Mother's Occupation</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-toolbox"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtmatoccupation" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Mother's Religion</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-church"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtmatreligion" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Mother's Education</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-book"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtmateducation" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Dead/Alive</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-user"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtmatdeadalive" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>

                </div>

            </div>
            <!-- /.card -->

        </div>

    </div>

    <br />

    <div class="row">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">DECLARATION OF GUARDIAN</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>I</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-user"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtname" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="col-sm-8">
                            <label id="decs">DO SINCERELY PROMISE THAT, I WILL DO MY BEST TO HONOUR ALL FINANCIAL AND MORAL OBLIGATIONS TO ASSIST THE SCHOOL AUTHORITIES TO GIVE MY WARD THE BEST EDUCATION HE/SHE DESERVES. FAILURE ON MY PART TO KEEP THIS PROMISE WILL RESULT IN EXPULSION OF MY WARD FROM THE SCHOOL. </label>
                        </div>
                    </div>

                    <div class="form-group row" id="45">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Sign Date</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtdate" CssClass="form-control" runat="server" TextMode="Date" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Signature</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-user"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtsign" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>

                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="Button3" runat="server" Text="Save" class="btn btn-primary" />
                    <asp:Button ID="Button4" runat="server" Text="Cancel" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->

            </div>
            <!-- /.card -->

        </div>
        <asp:TextBox ID="TextBox13" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="TextBox14" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="TextBox15" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="TextBox16" runat="server" Visible="false" BackColor="#FFFF99"></asp:TextBox>
        <asp:TextBox ID="TextBox17" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="txtdateyear" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtdays" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtmonths" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtmyID" runat="server" Visible="false" BackColor="#FFFF99"></asp:TextBox>
        <asp:TextBox ID="txtgender" runat="server" Visible="False"></asp:TextBox>
        <asp:Label ID="lblImageName" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
    </div>

    <br />

    <script type="text/javascript">
        $(function () {
            Webcam.set({
                width: 240,
                height: 160,
                image_format: 'jpeg',
                jpeg_quality: 90
            });
            Webcam.attach('#webcam');
            $("#btnCapture").click(function () {
                Webcam.snap(function (data_uri) {
                    $("#imgCapture")[0].src = data_uri;
                    $("#btnUpload").removeAttr("disabled");
                });
            });
            $("#btnUpload").click(function () {
                $.ajax({
                    type: "POST",
                    url: "/Edit_Photo.aspx/SaveCapturedImage",
                    data: "{data: '" + $("#imgCapture")[0].src + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) { }
                });
            });
        });
    </script>

</asp:Content>

