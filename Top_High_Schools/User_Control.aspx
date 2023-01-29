<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="User_Control.aspx.vb" Inherits="Top_High_Schools.User_Control" %>

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


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800" id="usctl">User Control</h4>

    </div>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <!-- Input rows -->

            <div class="row" id="nabyrow1">
                <div class="col-md-12">
                    <div class="card card-info">
                        <div class="card-header">
                            <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                                class="fa fa-list fa-sm text-white-50"></i></a>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">


                            <div class="form-group row">

                                <div class="col-sm-6">
                                    <label id="lblstaff">Staff</label>
                                    <asp:DropDownList ID="ddlstaff" runat="server" CssClass="form-control" ClientIDMode="Static" requide="true" AutoPostBack="true" OnSelectedIndexChanged="ddlstaff_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="col-sm-6">
                                    <label>Class Control</label>
                                    <asp:DropDownList ID="ddlclass" runat="server" CssClass="form-control" ClientIDMode="Static" requide="true"></asp:DropDownList>
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
                            <h5 class="card-title" id="adh">Admistration</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkregs" runat="server" Text="Registration Form" />
                                    <asp:TextBox ID="txtregs" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chknewadmi" runat="server" Text="New Admission" />
                                    <asp:TextBox ID="txtnewadmi" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkstudlist" runat="server" Text="Student List" />
                                    <asp:TextBox ID="txtstudlist" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkstudlistbyclass" runat="server" Text="Student List by Class" />
                                    <asp:TextBox ID="txtstudlistbyclass" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkadmianayr" runat="server" Text="Admission Analysis by Year" />
                                    <asp:TextBox ID="txtadmianayr" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkadmibyterm" runat="server" Text="Admission List by Term" />
                                    <asp:TextBox ID="txtadmibyterm" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkadmilistbyyr" runat="server" Text="Admission List by Year" />
                                    <asp:TextBox ID="txtadmilistbyyr" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkeditphoto" runat="server" Text="Edit Learner' Photo" />
                                    <asp:TextBox ID="txtphoto" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

            <br />

            <div class="row" id="phrow4">

                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title" id="aca">Academics</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkattendance" runat="server" Text="Mark Attendance" />
                                    <asp:TextBox ID="txtattendance" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkclsass" runat="server" Text="Class Assessment" />
                                    <asp:TextBox ID="txtclsass" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkcltst" runat="server" Text="Class Test" />
                                    <asp:TextBox ID="txtcltst" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkhmwrk" runat="server" Text="Home Work" />
                                    <asp:TextBox ID="txthmwrk" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkexmhet" runat="server" Text="Exams Sheet" />
                                    <asp:TextBox ID="txtexmhet" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkcontsheet" runat="server" Text="Continuous Assessment Sheet" />
                                    <asp:TextBox ID="txtcontsheet" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkindrep" runat="server" Text="Individual Report Card" />
                                    <asp:TextBox ID="txtindrep" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkrepbycls" runat="server" Text="Group Report By Class" />
                                    <asp:TextBox ID="txtrepbycls" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkuploa" runat="server" Text="Upload Class Activities" />
                                    <asp:TextBox ID="txtuploa" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkcmtent" runat="server" Text="Cont. Assessment. Entry" />
                                    <asp:TextBox ID="txtcmtent" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>

            <br />

            <div class="row" id="phrow5">

                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title" id="stm">Staff Management</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkstfform" runat="server" Text="Staff Form" />
                                    <asp:TextBox ID="txtstfform" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkstflist" runat="server" Text="Staff List" />
                                    <asp:TextBox ID="txtstflist" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chksnit" runat="server" Text="Ssnit, PF, TUC" />
                                    <asp:TextBox ID="txtssnit" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkincome" runat="server" Text="Income Tax Entry Level" />
                                    <asp:TextBox ID="txtincome" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkprlpros" runat="server" Text="Pay Roll Process" />
                                    <asp:TextBox ID="txtprlpros" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkpayroll" runat="server" Text="Pay Roll" />
                                    <asp:TextBox ID="txtpayroll" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkslip" runat="server" Text="Pay Slip" />
                                    <asp:TextBox ID="txtslip" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>

            <br />

            <div class="row" id="phrow6">

                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title" id="acct">Accounting</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkchtacc" runat="server" Text="Chart of Account" />
                                    <asp:TextBox ID="txtchtacc" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkcntlist" runat="server" Text="Canteen Fee List" />
                                    <asp:TextBox ID="txtcntlist" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkschfeestam" runat="server" Text="School Fees Statement" />
                                    <asp:TextBox ID="txtschfeestam" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkjrnent" runat="server" Text="Journal Entries" />
                                    <asp:TextBox ID="txtjrnent" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkrecschpay" runat="server" Text="Receive Payments (Sch. Fees)" />
                                    <asp:TextBox ID="txtrecschpay" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkrecadmpay" runat="server" Text="Receive Payments (Adm. Fee)" />
                                    <asp:TextBox ID="txtrecadmpay" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkschfeelst" runat="server" Text="School Fees List" />
                                    <asp:TextBox ID="txtschfeelst" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkdeblst" runat="server" Text="Debtors List" />
                                    <asp:TextBox ID="txtdeblst" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkpaybills" runat="server" Text="Pay Bills" />
                                    <asp:TextBox ID="txtpaybills" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkeditschfee" runat="server" Text="Edit Sch. Fees Statement" />
                                    <asp:TextBox ID="txteditschfee" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>

            <br />

            <div class="row" id="phrow7">

                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title">Banking</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chksetup" runat="server" Text="Bank Setup" />
                                    <asp:TextBox ID="txtsetup" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkdepsit" runat="server" Text="Deposit" />
                                    <asp:TextBox ID="txtdepsit" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkwtdrw" runat="server" Text="Withdrawal" />
                                    <asp:TextBox ID="txtwtdrw" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chktrnsf" runat="server" Text="Transfers" />
                                    <asp:TextBox ID="txttrnsf" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkbnkstam" runat="server" Text="Bank Statement" />
                                    <asp:TextBox ID="txtbnkstam" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>

            <br />

            <div class="row" id="phrow8">

                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title">Financial Report</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chktb" runat="server" Text="Trail Balance" />
                                    <asp:TextBox ID="txttb" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkpl" runat="server" Text="Profit & Loss" />
                                    <asp:TextBox ID="txtpl" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkbls" runat="server" Text="Balance Sheet" />
                                    <asp:TextBox ID="txtbls" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkchflw" runat="server" Text="Cash Flow" />
                                    <asp:TextBox ID="txtchflw" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkchngequ" runat="server" Text="Changes in Equity" />
                                    <asp:TextBox ID="txtchngequ" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>

            <br />

            <div class="row" id="phrow9">

                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">
                        <div class="card-header">
                            <h5 class="card-title">School Settings</h5>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->

                        <div class="card-body">

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkschinfo" runat="server" Text="School Info" />
                                    <asp:TextBox ID="txtschinfo" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkmsgcnt" runat="server" Text="Message Center" />
                                    <asp:TextBox ID="txtmsgcnt" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkacadar" runat="server" Text="Academic Calender" />
                                    <asp:TextBox ID="txtacadar" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkadfeesbill" runat="server" Text="Add Fees & Bills" />
                                    <asp:TextBox ID="txtadfeesbill" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chklnrares" runat="server" Text="Add Learner's Arrears" />
                                    <asp:TextBox ID="txtlnrares" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkadclas" runat="server" Text="Add Class" />
                                    <asp:TextBox ID="txtadclas" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkedtcurclass" runat="server" Text="Edit Learner Current Class" />
                                    <asp:TextBox ID="txtedtcurclass" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkadsubjt" runat="server" Text="Add Subjects" />
                                    <asp:TextBox ID="txtadsubjt" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkuserlst" runat="server" Text="Users List" />
                                    <asp:TextBox ID="txtuserlst" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkacscontrl" runat="server" Text="User Access Control" />
                                    <asp:TextBox ID="txtacscontrl" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkpromo" runat="server" Text="Learners Promotions" />
                                    <asp:TextBox ID="txtpromo" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkactive" runat="server" Text="Learner Activation" />
                                    <asp:TextBox ID="txtactive" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="chkpage" runat="server" Text="Learner Activation" />
                                    <asp:TextBox ID="txtpage" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>

            <br />

            <div class="row" id="phrow10">
                <div class="col-md-12">

                    <!-- Horizontal Form -->
                    <div class="card card-info">


                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                        </div>
                        <!-- /.card-footer -->
                    </div>

                    <asp:TextBox ID="txtAcSubGroup" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtAcCate" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtocbfy" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtcogm" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txttimer" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtcomp" Text="Test Comp" runat="server" Visible="false"></asp:TextBox>
                    <asp:HiddenField ID="txtid" Value="0" runat="server" />
                    <asp:HiddenField ID="txtfont" runat="server" />
                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlstaff" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <br />

    <script type="text/javascript">

        $('#ddlstaff').select2({
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
                document.getElementById("phrow3").style.fontFamily = fontstyle;
                document.getElementById("phrow4").style.fontFamily = fontstyle;
                document.getElementById("phrow5").style.fontFamily = fontstyle;
                document.getElementById("phrow6").style.fontFamily = fontstyle;
                document.getElementById("phrow7").style.fontFamily = fontstyle;
                document.getElementById("phrow8").style.fontFamily = fontstyle;
                document.getElementById("phrow9").style.fontFamily = fontstyle;
                document.getElementById("phrow10").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>



</asp:Content>
