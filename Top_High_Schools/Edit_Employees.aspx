<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_Employees.aspx.vb" Inherits="Top_High_Schools.Edit_Employees" %>

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

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Employees Info</h4>
        <a href="Staff_List.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-list fa-sm text-white-50"></i>Employee List</a>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Edit Staff Form</h5>
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

                        <div class="col-sm-10">
                            <label>First Name</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtfirstname" placeholder="First Name" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label>Middle Name</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtmidname" placeholder="Middle Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label>Last Name</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtlastname" placeholder="Last name" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-4">
                            <label>Date of Birth</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdob" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-4">
                            <label>Gender</label>
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                <asp:ListItem Value="-1">Choose Gender</asp:ListItem>
                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-3">
                            <label>ID Type</label>
                            <asp:DropDownList ID="ddlidtype" runat="server" CssClass="form-control" ClientIDMode="Static" required="true">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Passport" Value="Passport" />
                                <asp:ListItem Text="Voter ID" Value="Voter ID" />
                                <asp:ListItem Text="Ghana Card" Value="Ghana Card" />
                                <asp:ListItem Text="NHIS" Value="NHIS" />
                                <asp:ListItem Text="Drivers License" Value="Drivers License" />

                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-3">
                            <label>ID Number</label>
                            <asp:TextBox ID="txtidnum" runat="server" CssClass="form-control capitalize" placeholder="ID Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-5">
                            <label>Qualification</label>
                            <asp:TextBox ID="txtqualification" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-sm-3">
                            <label>SSNIT Number</label>
                            <asp:TextBox ID="txtSsnit" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>

    <br />

    <div class="row" id="phrow3">
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
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txthouseaddress" placeholder="House Address" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <label>City</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtcity" placeholder="City" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <label>Country</label>
                            <asp:DropDownList ID="ddlcountries" runat="server" CssClass="form-control" ClientIDMode="Static" required="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-4">
                            <label>Mobile Number</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtmobile" placeholder="Mobile #" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-5">
                            <label>E-mail</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtemail" placeholder="E-mail Address"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-10">
                            <label>Next of Kin</label>
                            <asp:TextBox runat="server" CssClass="form-control capitalize" ID="txtnextofkin" placeholder="Next of Kin"></asp:TextBox>
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
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtnet" Text="0.00" ReadOnly ="true" BackColor="White"></asp:TextBox>
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
                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->

            </div>
            <!-- /.card -->

        </div>
        <asp:TextBox ID="txtdateyear" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtdays" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtmonths" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtmyID" runat="server" Visible="false" BackColor="#FFFF99"></asp:TextBox>
        <asp:TextBox ID="txtgender" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
        <asp:Label ID="lblImageName" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>
        <asp:HiddenField ID="hfentid" runat="server" />
        <asp:HiddenField ID="txtrate" runat="server" />
        <asp:HiddenField ID="txtdeuct" runat="server" />
        <asp:HiddenField ID="txtfotoid" runat="server" />
    </div>

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


    <br />

    <script type="text/javascript">

        $('#ddlcountries').select2({
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
