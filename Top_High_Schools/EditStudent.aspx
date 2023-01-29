<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditStudent.aspx.vb" Inherits="Top_High_Schools.EditStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="jquery.min_9.js"></script>

    <script src="WebCam.js"></script>

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

    <script src="webcamjs/webcam.min.js"></script>

    <script src="webcamjs/webcam.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Students & Parents Info</h4>
        <a href="StudentList.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-list fa-sm text-white-50"></i>Student List</a>
    </div>


    <div class="row" id="nabyrow1">


        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Edit Student Registration Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-5">
                            <div class="input-group">
                                <asp:Image ID="imgstudpic" runat="server" Width="250px" Height="200px" />
                            </div>
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
                                <asp:TextBox ID="txtdateofbirth" CssClass="form-control" runat="server" required="true"></asp:TextBox>
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

    <div class="row" id="phrow3">
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

                        <div class="col-md-4">
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

                        <div class="col-md-4">
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

                        <div class="col-md-4">
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

                    </div>

                </div>


            </div>
            <!-- /.card -->

        </div>

    </div>

    <br />

    <div class="row" id="phrow4">
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

                        <div class="col-md-4">
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

                        <div class="col-md-4">
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

                        <div class="col-md-4">
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


                    </div>

                </div>

            </div>
            <!-- /.card -->

        </div>

    </div>

    <br />

    <div class="row" id="phrow5">
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
                                    <asp:TextBox ID="txtdate" CssClass="form-control" runat="server" required="true"></asp:TextBox>
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

                    <div class="form-group row" id="46">

                        <div class="col-sm-5">
                            <label for="inputEmail3">Supervisor</label>
                            <asp:DropDownList ID="ddlUers" runat="server" CssClass="form-control" requide="true" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                    </div>

                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                    <input type="button" id="btnSave" value="Save" class="btn btn-primary" />
                    <input type="button" id="btncancel" value="Cancel" class="btn btn-success float-right" onclick="resetAllControls()" />
                </div>
                <!-- /.card-footer -->

            </div>
            <!-- /.card -->

        </div>

        <asp:HiddenField ID="txtid" runat="server" />
        <asp:HiddenField ID="txtdays" runat="server" />
        <asp:HiddenField ID="txtmonths" runat="server" />
        <asp:HiddenField ID="txtmyID" runat="server" />
        <asp:HiddenField ID="txtdateyear" runat="server" />
        <asp:HiddenField ID="txtgender" runat="server" />
        <asp:HiddenField ID="lblImageName" runat="server" />
        <asp:HiddenField ID="txtpicid" runat="server" />
        <asp:HiddenField ID="txtfont" runat="server" />
    </div>

    <br />

    <script type="text/javascript">

        $('#ddlUers').select2({
            placeholder: 'Select an option'
        });

    </script>


    <script type="text/javascript">
        function DateSelectionChanged() {
            var today = new Date();
            var dob = new Date(document.getElementById('<%=txtdateofbirth.ClientID%>').value);
            var months = (today.getMonth() - dob.getMonth() + (12 * (today.getFullYear() - dob.getFullYear())));
            document.getElementById('<%=txtage.ClientID%>').value = Math.round(months / 12);
        }
    </script>

    <script type="text/javascript">

        function ageCalculator() {
            var userinput = document.getElementById("txtdateofbirth").value;
            var myyears = document.getElementById("txtdateyear").value;
            var dob = new Date(userinput);
            if (userinput == null || userinput == '') {
                document.getElementById("message").innerHTML = "**Choose a date please!";
                return false;
            } else {

                //calculate month difference from current date in time  
                var month_diff = Date.now() - dob.getTime();

                //convert the calculated difference in date format  
                var age_dt = new Date(month_diff);

                //extract year from date      
                var year = age_dt.getUTCFullYear();

                //now calculate the age of the user  
                var age = Math.abs(year - myyears);

                //display the calculated age  
                return document.getElementById("txtage").innerHTML = age;
            }
        }

    </script>


    <script type="text/javascript">

        function resetAllControls() {
            $("#form1").find('input:text, input:password, input:file, select, textarea').val('');
            $("#form1").find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
        };

    </script>

    <script type="text/javascript">

        $("#btnSave").click(function () {
            var txtid = $.trim($('#<%=txtid.ClientID %>').val());
            var txtnameofchild = $.trim($('#<%=txtnameofchild.ClientID %>').val());
            var txtdate = $.trim($('#<%=txtdateofbirth.ClientID %>').val());
            var ddlGender = $.trim($('#<%=ddlGender.ClientID %>').val());
            var txthometown = $.trim($('#<%=txthometown.ClientID %>').val());
            var txtregion = $.trim($('#<%=txtregion.ClientID %>').val());
            var txtnationality = $.trim($('#<%=txtnationality.ClientID %>').val());
            var txtreligion = $.trim($('#<%=txtreligion.ClientID %>').val());


            $.ajax({
                type: "POST",
                url: "/EditStudent.aspx/Updateadmissionstudents",
                data: "{'txtid':'" + txtid + "','txtnameofchild':'" + txtnameofchild + "','txtdate':'" + txtdate + "','ddlGender':'" + ddlGender + "','txthometown':'" + txthometown + "','txtregion':'" + txtregion + "','txtnationality':'" + txtnationality + "','txtreligion':'" + txtreligion + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    Updateadmissionparentsfather()
                }
            });

        });

        function Updateadmissionparentsfather() {
            var txtid = $.trim($('#<%=txtid.ClientID %>').val());
            var txtfathersname = $.trim($('#<%=txtfathersname.ClientID %>').val());
            var txtaddress = $.trim($('#<%=txtaddress.ClientID %>').val());
            var txtmobile = $.trim($('#<%=txtmobile.ClientID %>').val());
            var txtfatOcupa = $.trim($('#<%=txtfatOcupa.ClientID %>').val());
            var txtfatreligion = $.trim($('#<%=txtfatreligion.ClientID %>').val());
            var txtfateducation = $.trim($('#<%=txtfateducation.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/EditStudent.aspx/Updateadmissionparentsfather",
                data: "{'txtid':'" + txtid + "','txtfathersname': '" + txtfathersname + "', 'txtaddress': '" + txtaddress + "', 'txtmobile': '" + txtmobile + "','txtfatOcupa': '" + txtfatOcupa + "', 'txtfatreligion': '" + txtfatreligion + "', 'txtfateducation': '" + txtfateducation + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    Updateadmissionparentsmother()
                }
            });

        };

        function Updateadmissionparentsmother() {
            var txtid = $.trim($('#<%=txtid.ClientID %>').val());
            var txtmatname = $.trim($('#<%=txtmatname.ClientID %>').val());
            var txtmataddress = $.trim($('#<%=txtmataddress.ClientID %>').val());
            var txtmatmobile = $.trim($('#<%=txtmatmobile.ClientID %>').val());
            var txtmatoccupation = $.trim($('#<%=txtmatoccupation.ClientID %>').val());
            var txtmatreligion = $.trim($('#<%=txtmatreligion.ClientID %>').val());
            var txtmateducation = $.trim($('#<%=txtmateducation.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/EditStudent.aspx/Updateadmissionparentsmother",
                data: "{'txtid':'" + txtid + "','txtmatname': '" + txtmatname + "', 'txtmataddress': '" + txtmataddress + "', 'txtmatmobile': '" + txtmatmobile + "','txtmatoccupation': '" + txtmatoccupation + "', 'txtmatreligion': '" + txtmatreligion + "', 'txtmateducation': '" + txtmateducation + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    Updateadmissiondeclaration()
                }
            });

        };

        function Updateadmissiondeclaration() {
            var txtid = $.trim($('#<%=txtid.ClientID %>').val());
            var txtname = $.trim($('#<%=txtname.ClientID %>').val());
            var txtdate = $.trim($('#<%=txtdate.ClientID %>').val());
            var txtsign = $.trim($('#<%=txtsign.ClientID %>').val());
            var txtuser = $.trim($('#<%=ddlUers.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/EditStudent.aspx/Updateadmissiondeclaration",
                data: "{'txtid':'" + txtid + "','txtname':'" + txtname + "','txtdate':'" + txtdate + "','txtsign':'" + txtsign + "','txtuser':'" + txtuser + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    alert("Update Success!");
                    window.location.href = "/StudentList.aspx";
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
                document.getElementById("phrow3").style.fontFamily = fontstyle;
                document.getElementById("phrow4").style.fontFamily = fontstyle;
                document.getElementById("phrow5").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
