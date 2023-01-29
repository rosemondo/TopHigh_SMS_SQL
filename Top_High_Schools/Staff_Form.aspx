<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Staff_Form.aspx.vb" Inherits="Top_High_Schools.Staff_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="jquery.min_9.js"></script>

    <script src="WebCam.js"></script>

    <script src="webcam.min.js"></script>

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

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="fmhd">
        <h4 class="h4 mb-0 text-gray-800">Employees Info</h4>
        <a href="Staff_List.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-list fa-sm text-white-50"></i>Employee List</a>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="sfmrow1">
        <div class="col-md-7">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Staff Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label>First Name</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtfirstname" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label>Middle Name</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtmidname"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label>Last Name</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtlastname" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-5">
                            <label>Date of Birth</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdob" TextMode="Date" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-5">
                            <label>Gender</label>
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="custom-select">
                                <asp:ListItem Value="-1">Choose Gender</asp:ListItem>
                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-5">
                            <label>ID Type</label>
                            <asp:DropDownList ID="dplidtype" runat="server" CssClass="custom-select" required="true" ClientIDMode="Static">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Voter ID" Value="Voter ID"></asp:ListItem>
                                <asp:ListItem Text="Ghana Card" Value="Ghana Card"></asp:ListItem>
                                <asp:ListItem Text="NHIS" Value="NHIS"></asp:ListItem>
                                <asp:ListItem Text="Drivers License" Value="Drivers License"></asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-5">
                            <label>ID Number</label>
                            <asp:TextBox ID="txtidnum" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-5">
                            <label>Qualification</label>
                            <asp:TextBox ID="txtqualification" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-sm-5">
                            <label>SSNIT Number</label>
                            <asp:TextBox ID="txtSsnit" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>

        </div>

        <div class="col-md-5">

            <div class="card card-info">
                <div class="card-header">
                    <h6 class="card-title">Staff Photo</h6>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th align="center"><u>Live Camera</u></th>

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
                            <td align="center"></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <input type="button" id="btnCapture" value="Capture" />
                            </td>
                        </tr>
                    </table>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->

            </div>

        </div>
    </div>

    <br />

    <div class="row" id="sfmrow2">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Staff Address</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">

                        <div class="col-sm-4">
                            <label>House Address</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txthouseaddress" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <label>City</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtcity" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <label>Country</label>
                            <asp:DropDownList ID="dplcountries" runat="server" CssClass="form-control" required="true" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-4">
                            <label>Mobile Number</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtmobile" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-5">
                            <label>E-mail</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtemail"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label>Next of Kin</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtnextofkin"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-3">
                            <label>Basic Salary</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtsalary" Text="0.00"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label>Allowances</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtallowance" Text="0.00"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label>Net Salary</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtnet" Text="0.00" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label>Salary Entry Level</label>
                            <asp:DropDownList ID="ddlentlevel" runat="server" CssClass="form-control" ClientIDMode="Static" required="true" onchange="getStudID()"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group row">

                        <div class="col-sm-3">
                            <label>Bank Name</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtbank" Text=""></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label>Account Name</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtacname" Text=""></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label>Account Number</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtacnum" Text=""></asp:TextBox>
                        </div>
                    </div>

                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                    <button type="submit" class="btn btn-primary rounded-0" onclick="SaveRecord();return false">Save</button>
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success rounded-0 float-right" OnClientClick="resetAllControls()" OnClick="btncancel_Click" />
                </div>
                <!-- /.card-footer -->

            </div>
            <!-- /.card -->

        </div>
        <asp:HiddenField ID="txtemp" runat="server" Value="EMP" />
        <asp:HiddenField ID="txtdays" runat="server" />
        <asp:HiddenField ID="txtmonths" runat="server" />
        <asp:HiddenField ID="txtmyID" runat="server" />
        <asp:HiddenField ID="hfentid" runat="server" />
        <asp:HiddenField ID="txtrate" runat="server" />
        <asp:HiddenField ID="txtdeuct" runat="server" />
        <asp:HiddenField ID="txtdateyear" runat="server" />
        <asp:TextBox ID="txtgender" runat="server" Visible="False"></asp:TextBox>
        <asp:Label ID="lblImageName" runat="server" Text="" Visible="false"></asp:Label>
        <asp:HiddenField ID="txtentdate" runat="server" />
        <asp:HiddenField ID="txtfont" runat="server" />

        <asp:HiddenField ID="txtSnRate5" runat="server" />

        <asp:HiddenField ID="txsntempyer" runat="server" />

        <asp:HiddenField ID="txtsnttier1" runat="server" />

        <asp:HiddenField ID="txttteetier2" runat="server" />

        <asp:HiddenField ID="txtpftier3" runat="server" />

        <asp:HiddenField ID="txt365" runat="server" />
        <asp:HiddenField ID="txt0" runat="server" />
        <asp:HiddenField ID="txt110" runat="server" />
        <asp:HiddenField ID="txt5" runat="server" />
        <asp:HiddenField ID="txt130" runat="server" />
        <asp:HiddenField ID="txt10" runat="server" />
        <asp:HiddenField ID="txt3000" runat="server" />
        <asp:HiddenField ID="txt17" runat="server" />
        <asp:HiddenField ID="txt16395" runat="server" />
        <asp:HiddenField ID="txt25" runat="server" />
        <asp:HiddenField ID="txt20000" runat="server" />
        <asp:HiddenField ID="txt30" runat="server" />

        <asp:HiddenField ID="lblsalsub" runat="server" />
        <asp:HiddenField ID="lbl5p" runat="server" />
        <asp:HiddenField ID="lbl10p" runat="server" />
        <asp:HiddenField ID="lbl17p" runat="server" />
        <asp:HiddenField ID="lbl25p" runat="server" />
        <asp:HiddenField ID="lbl30p" runat="server" />
        <asp:HiddenField ID="lblsalsecsub" runat="server" />
        <asp:HiddenField ID="lblthirdsub" runat="server" />
        <asp:HiddenField ID="lblfourthdsub" runat="server" />
        <asp:HiddenField ID="lblfifthdsub" runat="server" />
        <asp:HiddenField ID="lblsixthdsub" runat="server" />


    </div>
    <br />

    <script type="text/javascript">

        function getStudID() {
            var studname = $("[id*=ddlentlevel]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Staff_Form.aspx/GetEntID",
                data: "{studname:'" + studname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=hfentid]').val(data.d.EntryID);
                    $('[id*=txtrate]').val(data.d.MyRate);
                    paysum()
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };

        function paysum() {
            var txt1 = document.getElementById('<%= txtsalary.ClientID %>').value;
            var txt2 = document.getElementById('<%= txtSnRate5.ClientID %>').value;
            var result = (parseFloat(txt1) * parseFloat(txt2)) / 100;

            if (!isNaN(result)) {
                document.getElementById('<%= txtdeuct.ClientID %>').value = result;
            }

            GRAsum()
        }

        function GRAsum() {
            var bsal = document.getElementById('<%= txtsalary.ClientID %>').value;
            var freeval = document.getElementById('<%= txt365.ClientID %>').value;
            var sn = document.getElementById('<%= txtdeuct.ClientID %>').value;
            var GRA110 = document.getElementById('<%= txt110.ClientID %>').value;
            var GRA130 = document.getElementById('<%= txt130.ClientID %>').value;
            var GRA3000 = document.getElementById('<%= txt3000.ClientID %>').value;
            var GRA16395 = document.getElementById('<%= txt16395.ClientID %>').value;
            var GRA20000 = document.getElementById('<%= txt20000.ClientID %>').value;
            var result = parseFloat(bsal) - parseFloat(sn) - parseFloat(freeval);
            var secondsub = parseFloat(bsal) - parseFloat(sn) - parseFloat(freeval) - parseFloat(GRA110);
            var thirdsub = parseFloat(bsal) - parseFloat(sn) - parseFloat(freeval) - parseFloat(GRA110) - parseFloat(GRA130);
            var forthsub = parseFloat(bsal) - parseFloat(sn) - parseFloat(freeval) - parseFloat(GRA110) - parseFloat(GRA130) - parseFloat(GRA3000);
            var fifthsub = parseFloat(bsal) - parseFloat(sn) - parseFloat(freeval) - parseFloat(GRA110) - parseFloat(GRA130) - parseFloat(GRA3000) - parseFloat(GRA16395);
            var sixthsub = parseFloat(bsal) - parseFloat(sn) - parseFloat(freeval) - parseFloat(GRA110) - parseFloat(GRA130) - parseFloat(GRA3000) - parseFloat(GRA16395) - parseFloat(GRA20000);
            if (!isNaN(result)) {
                document.getElementById('<%= lblsalsub.ClientID %>').value = result;
            }
            if (!isNaN(secondsub)) {
                document.getElementById('<%= lblsalsecsub.ClientID %>').value = secondsub;
            }
            if (!isNaN(thirdsub)) {
                document.getElementById('<%= lblthirdsub.ClientID %>').value = thirdsub;
            }
            if (!isNaN(forthsub)) {
                document.getElementById('<%= lblfourthdsub.ClientID %>').value = forthsub;
            }
            if (!isNaN(fifthsub)) {
                document.getElementById('<%= lblfifthdsub.ClientID %>').value = fifthsub;
            }
            if (!isNaN(sixthsub)) {
                document.getElementById('<%= lblsixthdsub.ClientID %>').value = sixthsub;
            }

            var salsub = document.getElementById('<%=lblsalsub.ClientID%>').value;
            var secsub = document.getElementById('<%=lblsalsecsub.ClientID%>').value;
            var thdsub = document.getElementById('<%=lblthirdsub.ClientID%>').value;
            var fothsub = document.getElementById('<%=lblfourthdsub.ClientID%>').value;
            var fithsub = document.getElementById('<%=lblfifthdsub.ClientID%>').value;
            var rate5 = document.getElementById('<%=txt5.ClientID%>').value;
            var rate10 = document.getElementById('<%=txt10.ClientID%>').value;
            var rate17 = document.getElementById('<%=txt17.ClientID%>').value;
            var rate25 = document.getElementById('<%=txt25.ClientID%>').value;
            var rate30 = document.getElementById('<%=txt30.ClientID%>').value;


            var numb5 = parseFloat(GRA110);

            if (salsub > numb5) {
                var result5 = (parseFloat(numb5) * parseFloat(rate5)) / 100;
            } else {
                var result5 = (parseFloat(salsub) * parseFloat(rate5)) / 100;
            }
            if (!isNaN(result5)) {
                document.getElementById('<%= lbl5p.ClientID %>').value = result5;
            }

            var numb05 = document.getElementById('<%=lbl5p.ClientID%>').value;
            var numb005 = parseFloat(numb05);
            if (numb005 < 0) {
                document.getElementById('<%= lbl5p.ClientID %>').value = 0;
            }

            var numb10 = parseFloat(GRA130);

            if (secsub > numb10) {
                var result10 = (parseFloat(numb10) * parseFloat(rate10)) / 100;
            } else {
                var result10 = (parseFloat(secsub) * parseFloat(rate10)) / 100;
            }
            if (!isNaN(result10)) {
                document.getElementById('<%= lbl10p.ClientID %>').value = result10;
            }

            var numb010 = document.getElementById('<%=lbl10p.ClientID%>').value;
            var numb0010 = parseFloat(numb010);
            if (numb0010 < 0) {
                document.getElementById('<%= lbl10p.ClientID %>').value = 0;
            }

            var numb17 = parseFloat(GRA3000);

            if (thdsub > numb17) {
                var result17 = (parseFloat(numb17) * parseFloat(rate17)) / 100;
            } else {
                var result17 = (parseFloat(thdsub) * parseFloat(rate17)) / 100;
            }
            if (!isNaN(result17)) {
                document.getElementById('<%= lbl17p.ClientID %>').value = result17;
            }

            var numb017 = document.getElementById('<%=lbl17p.ClientID%>').value;
            var numb0017 = parseFloat(numb017);
            if (numb0017 < 0) {
                document.getElementById('<%= lbl17p.ClientID %>').value = 0;
            }

            var numb25 = parseFloat(GRA16395);

            if (fothsub > numb25) {
                var result25 = (parseFloat(numb25) * parseFloat(rate25)) / 100;
            } else {
                var result25 = (parseFloat(fothsub) * parseFloat(rate25)) / 100;
            }
            if (!isNaN(result25)) {
                document.getElementById('<%= lbl25p.ClientID %>').value = result25;
            }

            var numb025 = document.getElementById('<%=lbl25p.ClientID%>').value;
            var numb0025 = parseFloat(numb025);
            if (numb0025 < 0) {
                document.getElementById('<%= lbl25p.ClientID %>').value = 0;
            }

            var numb30 = parseFloat(GRA20000);

            if (fifthsub > numb30) {
                var result30 = (parseFloat(numb30) * parseFloat(rate30)) / 100;
            } else {
                var result30 = (parseFloat(fifthsub) * parseFloat(rate30)) / 100;
            }
            if (!isNaN(result30)) {
                document.getElementById('<%= lbl30p.ClientID %>').value = result30;
            }

            var numb030 = document.getElementById('<%=lbl30p.ClientID%>').value;
            var numb0030 = parseFloat(numb030);
            if (numb0030 < 0) {
                document.getElementById('<%= lbl30p.ClientID %>').value = 0;
            }

            netsum()
        }

        function netsum() {
            var salary = document.getElementById('<%= txtsalary.ClientID %>').value;
            var allowance = document.getElementById('<%= txtallowance.ClientID %>').value;
            var snnit = document.getElementById('<%= txtdeuct.ClientID %>').value;
            var my5 = document.getElementById('<%= lbl5p.ClientID %>').value;
            var my10 = document.getElementById('<%= lbl10p.ClientID %>').value;
            var my17 = document.getElementById('<%= lbl17p.ClientID %>').value;
            var my25 = document.getElementById('<%= lbl25p.ClientID %>').value;
            var my30 = document.getElementById('<%= lbl30p.ClientID %>').value;

            var result = parseFloat(salary) + parseFloat(allowance) - parseFloat(snnit) - parseFloat(my5) - parseFloat(my10) - parseFloat(my17) - parseFloat(my25) - parseFloat(my30);
            if (!isNaN(result)) {
                document.getElementById('<%= txtnet.ClientID %>').value = result;
            }
        }

    </script>


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

        });

        function resetAllControls() {
            $("#form1").find('input:text, input:password, input:file, select, textarea').val('');
            $("#form1").find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
        };

    </script>

    <script type="text/javascript">

        function SaveRecord() {
            //Get control's values
            var myEmp = $.trim($('#<%=txtemp.ClientID %>').val());
            var myid = $.trim($('#<%=txtmyID.ClientID %>').val());
            var mydays = $.trim($('#<%=txtdays.ClientID %>').val());
            var mymonth = $.trim($('#<%=txtmonths.ClientID %>').val());
            var myyear = $.trim($('#<%=txtdateyear.ClientID %>').val());
            var salary = $.trim($('#<%=txtsalary.ClientID %>').val());
            var allowance = $.trim($('#<%=txtallowance.ClientID %>').val());
            var netsalary = $.trim($('#<%=txtnet.ClientID %>').val());
            var entid = $('#<%=hfentid.ClientID %>').val();
            var bank = $.trim($('#<%=txtbank.ClientID %>').val());
            var acname = $('#<%=txtacname.ClientID %>').val();
            var acnum = $.trim($('#<%=txtacnum.ClientID %>').val());
            var entdate = $.trim($('#<%=txtentdate.ClientID %>').val());

            var msg = "";
            //check for validation
            if (myid == '') {
                msg += "<li>Please enter book name</li>";
            }
            if (mydays == '') {
                msg += "<li>Please enter author name</li>";
            }
            if (mymonth == '') {
                msg += "<li>Please select book type</li>";
            }
            if (myyear == '') {
                msg += "<li>Please enter book price</li>";
            }

            if (salary == '') {
                msg += "<li>Please enter author name</li>";
            }
            if (allowance == '') {
                msg += "<li>Please select book type</li>";
            }
            if (entid == '') {
                msg += "<li>Please enter book price</li>";
            }

            if (bank == '') {
                msg += "<li>Please enter book name</li>";
            }
            if (acname == '') {
                msg += "<li>Please enter author name</li>";
            }
            if (acnum == '') {
                msg += "<li>Please select book type</li>";
            }
            if (entdate == '') {
                msg += "<li>Please enter book price</li>";
            }

            if (msg.length == 0) {
                //Jquery ajax call to server side method
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    //Url is the path of our web method (Page name/function name)
                    url: "/Staff_Form.aspx/SaveSalaryDetails",
                    //Pass paramenters to the server side function
                    data: "{'myEmp':'" + myEmp + "','myid':'" + myid + "', 'mydays':'" + mydays + "','mymonth':'" + mymonth + "','myyear':'" + myyear + "','salary':'" + salary + "','allowance':'" + allowance + "','netsalary':'" + netsalary + "','entid':'" + entid + "','bank':'" + bank + "','acname':'" + acname + "','acnum':'" + acnum + "','entdate':'" + entdate + "'}",
                    success: function (response) {
                        //Success or failure message e.g. Record saved or not saved successfully
                        if (response.d == true) {
                            SaveEmpInfo()

                        }
                        else {
                            msg += "Record could't be saved";
                        }
                        //Fade Out to disappear message after 6 seconds

                    },
                    error: function (xhr, textStatus, error) {
                        //Show error message(if occured)

                    }
                });
            }
            else {
                //Validation failure message
                $('#dvResult').html('');
                $('#dvResult').html(msg);
            }
            $('#dvResult').fadeIn();
        }

        function SaveEmpInfo() {
            var myEmp = $.trim($('#<%=txtemp.ClientID %>').val());
            var myid = $.trim($('#<%=txtmyID.ClientID %>').val());
            var mydays = $.trim($('#<%=txtdays.ClientID %>').val());
            var mymonth = $.trim($('#<%=txtmonths.ClientID %>').val());
            var myyear = $.trim($('#<%=txtdateyear.ClientID %>').val());
            var firstname = $.trim($('#<%=txtfirstname.ClientID %>').val());
            var midname = $.trim($('#<%=txtmidname.ClientID %>').val());
            var lastname = $('#<%=txtlastname.ClientID %>').val();
            var dob = $.trim($('#<%=txtdob.ClientID %>').val());
            var Gender = $('#<%=ddlGender.ClientID %>').val();
            var idtype = $.trim($('#<%=dplidtype.ClientID %>').val());
            var idnum = $.trim($('#<%=txtidnum.ClientID %>').val());
            var qualification = $('#<%=txtqualification.ClientID %>').val();
            var Ssnit = $.trim($('#<%=txtSsnit.ClientID %>').val());
            var entdate = $.trim($('#<%=txtentdate.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Staff_Form.aspx/SaveEmpDetails",
                data: "{'myEmp':'" + myEmp + "','myid':'" + myid + "', 'mydays':'" + mydays + "','mymonth':'" + mymonth + "','myyear':'" + myyear + "','firstname':'" + firstname + "','midname':'" + midname + "','lastname':'" + lastname + "','dob':'" + dob + "','Gender':'" + Gender + "','idtype':'" + idtype + "','idnum':'" + idnum + "','qualification':'" + qualification + "','Ssnit':'" + Ssnit + "','entdate':'" + entdate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    SaveAddresInfo()
                }
            });
        }

        function SaveAddresInfo() {
            var myEmp = $.trim($('#<%=txtemp.ClientID %>').val());
            var myid = $.trim($('#<%=txtmyID.ClientID %>').val());
            var mydays = $.trim($('#<%=txtdays.ClientID %>').val());
            var mymonth = $.trim($('#<%=txtmonths.ClientID %>').val());
            var myyear = $.trim($('#<%=txtdateyear.ClientID %>').val());
            var houseaddress = $.trim($('#<%=txthouseaddress.ClientID %>').val());
            var city = $.trim($('#<%=txtcity.ClientID %>').val());
            var countries = $('#<%=dplcountries.ClientID %>').val();
            var mobile = $.trim($('#<%=txtmobile.ClientID %>').val());
            var email = $('#<%=txtemail.ClientID %>').val();
            var nextofkin = $.trim($('#<%=txtnextofkin.ClientID %>').val());
            var entdate = $.trim($('#<%=txtentdate.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Staff_Form.aspx/SaveAddressDetails",
                data: "{'myEmp':'" + myEmp + "','myid':'" + myid + "', 'mydays':'" + mydays + "','mymonth':'" + mymonth + "','myyear':'" + myyear + "','houseaddress':'" + houseaddress + "','city':'" + city + "','countries':'" + countries + "','mobile':'" + mobile + "','email':'" + email + "','nextofkin':'" + nextofkin + "','entdate':'" + entdate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    SaveImage()
                }
            });
        }

        function SaveImage() {
            var myEmp = $.trim($('#<%=txtemp.ClientID %>').val());
            var myid = $.trim($('#<%=txtmyID.ClientID %>').val());
            var mydays = $.trim($('#<%=txtdays.ClientID %>').val());
            var mymonth = $.trim($('#<%=txtmonths.ClientID %>').val());
            var myyear = $.trim($('#<%=txtdateyear.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Staff_Form.aspx/SaveCapturedImage",
                data: "{data: '" + $("#imgCapture")[0].src + "','myEmp':'" + myEmp + "','myid':'" + myid + "','mydays':'" + mydays + "','mymonth':'" + mymonth + "','myyear':'" + myyear + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {

                    window.location.href = "/Staff_Data_Preview.aspx?myEmp=" + myEmp + "&myid=" + myid + "&mydays=" + mydays + "&mymonth=" + mymonth + "&myyear=" + myyear;

                }
            });
        }


    </script>


    <script type="text/javascript">

        $('#dplcountries').select2({
            placeholder: 'Select an option'
        });

        $('#ddlidtype').select2({
            placeholder: 'Select an option'
        });

        $('#ddlentlevel').select2({
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

                document.getElementById("fmhd").style.fontFamily = fontstyle;
                document.getElementById("sfmrow1").style.fontFamily = fontstyle;
                document.getElementById("sfmrow2").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
