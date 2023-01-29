<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Portal.Master" CodeBehind="Learners_Portal.aspx.vb" Inherits="Top_High_Schools.Learners_Portal" %>

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

        .capitalize {
            text-transform: capitalize;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper" id="myhd">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Profile</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">User Profile</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content" id ="nabyrow1">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-4">

                        <!-- Profile Image -->
                        <div class="card card-primary card-outline">
                            <div class="card-body box-profile">
                                <div class="text-center">
                                    <fieldset style="width: 150px;">
                                        <div style="text-align: center;">
                                            <asp:Image ID="ImgPrv" Height="150" Width="150" runat="server" alt="image" class='roundimage center-img' ImageUrl="~/img/your_logo.png" ImageAlign="Middle" /><br />

                                        </div>

                                    </fieldset>
                                </div>

                                <h3 class="profile-username text-center">
                                    <asp:Repeater ID="rptprofile" runat="server">
                                        <HeaderTemplate>
                                            <table id="students" class="table table-bordered table-striped" cellspacing="0" width="10%">
                                                <thead>
                                                    <tr>
                                                        <th scope="col">Student Name</th>
                                                        <th scope="col">Photo</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblmyid" runat="server" Text='<%# Eval("Student ID") %>' Visible="false" />
                                                    <asp:LinkButton ID="lnkname" runat="server" Text='<%# Eval("Student") %>' OnClick="GetValue"></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src='data:image/jpg;base64,<%# If(Not String.IsNullOrEmpty(Eval("Name")), Convert.ToBase64String(CType(Eval("Pictures"), Byte())), String.Empty) %>' alt="image" height="70" width="70" class='roundimage center-img' />
                                                </td>

                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </h3>

                                <p class="text-muted text-center">Basic Info</p>

                                <ul class="list-group list-group-unbordered mb-3">

                                    <li class="list-group-item">
                                        <b>Age</b> <a class="float-right">
                                            <asp:Label ID="lblage" runat="server" Text="0">Year(s)</asp:Label></a>
                                    </li>

                                    <li class="list-group-item">
                                        <b>Class</b> <a class="float-right">
                                            <asp:Label ID="lblclass" runat="server" Text="0"></asp:Label></a>
                                    </li>

                                    <li class="list-group-item">
                                        <b>Balance Due</b> <a class="float-right">
                                            <asp:Label ID="lblbaldue" runat="server" Text="0.00"></asp:Label></a>
                                    </li>
                                </ul>

                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->

                        <br />

                        <!-- About Me Box -->
                        <div class="card card-primary">
                            <div class="card-header">
                                <h5 class="card-title">About Me</h5>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <strong><i class="fas fa-male mr-1"></i>Father</strong>

                                <p class="text-muted">
                                    <asp:Label ID="lblfather" runat="server" Text="Father"></asp:Label>
                                </p>

                                <hr>

                                <strong><i class="fas fa-female mr-1"></i>Mother</strong>

                                <p class="text-muted">
                                    <asp:Label ID="lblmother" runat="server" Text="Mother"></asp:Label>
                                </p>

                                <hr>

                                <strong><i class="fas fa-map-marker-alt mr-1"></i>Location</strong>

                                <asp:Label ID="lbllocation" runat="server" Text="Location"></asp:Label>

                                <hr>

                                <strong><i class="fas fa-pencil-alt mr-1"></i>Contacts</strong>

                                <p class="text-muted">
                                    <asp:Label ID="lblcontfa" runat="server" Text="0000 000 000"></asp:Label>
                                </p>


                                <hr>

                                <strong><i class="far fa-file-alt mr-1"></i>Notes</strong>

                                <p class="text-muted">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam fermentum enim neque.</p>
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->
                    </div>

                    <br />

                    <!-- /.col -->
                    <div class="col-sm-8">
                        <div class="card">
                            <div class="card-header p-2" style="background-color: white">
                                <ul class="nav nav-pills">
                                    <li class="nav-item"><a class="nav-link active" href="#activity" data-toggle="tab">Activity</a></li>
                                    <li class="nav-item"><a class="nav-link" href="#timeline" data-toggle="tab">School Fees Log</a></li>
                                    <li class="nav-item"><a class="nav-link" href="#settings" data-toggle="tab">Your Message</a></li>
                                </ul>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <div class="tab-content">
                                    <div class="active tab-pane" id="activity">
                                        <!-- Post -->
                                        <div class="post">

                                            <h5>Class & Home Work</h5>

                                            <asp:GridView ID="dgvhw" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id">

                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Download">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("item_name") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="cw_date" HeaderText="Date" DataFormatString="{0: yyyy-MM-dd}">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="item_name" HeaderText="File Name" />
                                                    <asp:BoundField DataField="class_type" HeaderText="Class">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="file_path" HeaderText="File Location" />
                                                </Columns>
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>

                                            <br />

                                        </div>
                                        <!-- /.post -->

                                        <!-- Post -->
                                        <div class="post clearfix">

                                            <h5>Class Assessment Sheet</h5>


                                            <asp:GridView ID="dgvassessment" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id">

                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Download">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("item_name") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="cw_date" HeaderText="Date" DataFormatString="{0: yyyy-MM-dd}">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="item_name" HeaderText="File Name" />
                                                    <asp:BoundField DataField="class_type" HeaderText="Class">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="file_path" HeaderText="File Location" />
                                                </Columns>
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>

                                            <br />

                                        </div>
                                        <!-- /.post -->

                                        <!-- Post -->
                                        <div class="post">

                                            <h5>Terminal Reports</h5>

                                            <asp:GridView ID="dgvreport" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id">

                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Download">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("item_name") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="cw_date" HeaderText="Date" DataFormatString="{0: yyyy-MM-dd}">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="item_name" HeaderText="File Name" />
                                                    <asp:BoundField DataField="class_type" HeaderText="Class">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="file_path" HeaderText="File Location" />
                                                </Columns>
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>

                                            <br />

                                        </div>
                                        <!-- /.post -->
                                    </div>


                                    <!-- /.tab-pane -->
                                    <div class="tab-pane" id="timeline">
                                        <!-- The timeline -->
                                        <div class="timeline timeline-inverse">
                                            <!-- timeline time label -->

                                            <!-- info row -->
                                            <div class="row invoice-info">
                                                <div class="col-sm-4 invoice-col">
                                                    <br />
                                                    <address>
                                                        <strong>School Info.</strong><br>
                                                        <asp:Label ID="lblcompname" runat="server" Text="CAPS" Font-Names="Nunito"></asp:Label><br>
                                                        <asp:Label ID="lbladress" runat="server" Text="CAPS" Font-Names="Nunito"></asp:Label><br>
                                                        <asp:Label ID="lblcontacts" runat="server" Text="CAPS" Font-Names="Nunito"></asp:Label><br>
                                                        <asp:Label ID="lblonline" runat="server" Text="CAPS" Font-Names="Nunito"></asp:Label>
                                                    </address>
                                                </div>
                                                <!-- /.col -->
                                                <div class="col-sm-4 invoice-col">
                                                    <br />
                                                    <address>
                                                        <strong>Learner's Info</strong><br>
                                                        <asp:Label ID="lblPAdd" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                                                        Phone:
                                <asp:Label ID="lblPPone" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                                                        Email:
                                <asp:Label ID="lblPemail" runat="server" Text="" Font-Names="Nunito"></asp:Label>
                                                    </address>
                                                </div>
                                                <!-- /.col -->
                                                <div class="col-sm-4 invoice-col">
                                                    <br />
                                                    <b>Class:</b>
                                                    <asp:Label ID="Label1" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                                                    <b>Balance Due:</b>
                                                    <asp:Label ID="Label2" runat="server" Text="" Font-Names="Nunito"></asp:Label><br>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->

                                            <br />

                                            <div class="card-body">

                                                <div>

                                                    <asp:Repeater ID="rptstudent" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="students" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th scope="col" style="text-align: left">Date</th>
                                                                        <th scope="col" style="text-align: left">Description</th>
                                                                        <th scope="col" style="text-align: left">Debit</th>
                                                                        <th scope="col" style="text-align: left">Credit</th>
                                                                        <th scope="col" style="text-align: left">Balance</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("st_date", "{0: yyyy-MM-dd}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="lblGender" runat="server" Text='<%# Eval("description") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("debit", "{0:N2}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("credit", "{0:N2}") %>' /></td>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Balance", "{0:N2}") %>' /></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody> </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                    <asp:TextBox ID="txtstudid" runat="server" Visible="False"></asp:TextBox>
                                                </div>

                                            </div>

                                            <!-- END timeline item -->
                                            <div>
                                                <i class="far fa-clock bg-gray"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.tab-pane -->

                                    <div class="tab-pane" id="settings">

                                        <div class="form-group row">
                                            <label for="inputName" class="col-sm-2 col-form-label">Subject</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtsubject" runat="server" CssClass="form-control" placeholder="Your Subject" required="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="inputName" class="col-sm-2 col-form-label">Name</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Your Name" required="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="inputEmail" class="col-sm-2 col-form-label">Email</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Your E-mail" TextMode="Email" required="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="inputExperience" class="col-sm-2 col-form-label">Message</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtmessage" runat="server" CssClass="form-control" placeholder="Your Message" TextMode="MultiLine" required="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="offset-sm-2 col-sm-10">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox">
                                                        I agree to the <a href="#">terms and conditions</a>
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="offset-sm-2 col-sm-10">
                                                <asp:Button ID="btnsubmit" runat="server" Text="Submit"  CssClass="btn btn-primary" OnClick="Insert_mails"/>
                                            </div>
                                        </div>

                                    </div>
                                    <!-- /.tab-pane -->
                                </div>
                                <!-- /.tab-content -->
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>

    <asp:TextBox ID="txtuser" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
     <asp:HiddenField ID="txtfont" runat="server" />

    <br />

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
