<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_Fees_Bills.aspx.vb" Inherits="Top_High_Schools.Edit_Fees_Bills" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id ="myhd">
        <h4 class="h4 mb-0 text-gray-800">Fees & Bills Settings</h4>
        
    </div>

    <!-- Input rows -->

    <div class="row" id="nabyrow1">
        <div class="col-md-10">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Add Fees & Bills</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">
                        <label for="inputEmail3" class="col-sm-2 col-form-label">Class Type</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlClass" required="true" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        <asp:TextBox runat="server" ID="txtclassid" Visible ="false"></asp:TextBox>
                        <asp:TextBox ID="txtclasid" runat="server" Visible ="false" AutoPostBack="True"></asp:TextBox>
                    </div>
                    <div class="form-group row">
                        <label for="inputEmail3" class="col-sm-2 col-form-label">Tuition Fee</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" class="form-control" ID="txttuition" Text="0"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">Admission Fee</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" class="form-control" ID="txtadmission" Text="0"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">Canteen Fee</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" class="form-control" ID="txtcanteen" Text="0"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">Bus Fee</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" TextMode="Number" class="form-control" ID="txtbusfee" Text="0"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">First AID</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" class="form-control" ID="txtfirstaid" Text="0"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">P.T.A</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" class="form-control" ID="txtpta" Text="0"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">Others</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" class="form-control" ID="txtothers" Text="0"></asp:TextBox>
                        </div>
                    </div>

                    <hr />

                </div>
                 
                <!-- /.card-body -->
                <div class="card-footer">
                     <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />

    <!--Row with two equal columns-->
    <div class="row" id="phrow3">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Fees / Bills List</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div>

                        <asp:Repeater ID="rptFeeBill" runat="server">
                            <HeaderTemplate>
                                <table id="studbills" class="table table-bordered table-striped" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th scope="col">ID</th>
                                            <th scope="col">Tuition Fee</th>
                                            <th scope="col">Admission Fee</th>
                                            <th scope="col">Canteen Fee</th>
                                            <th scope="col">Bus Fee</th>
                                            <th scope="col">First AID</th>
                                            <th scope="col">P.T.A</th>
                                            <th scope="col">Others</th>
                                            <th scope="col">Class Type</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblTuition" runat="server" Text='<%# Eval("Tuition Fee") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblAdmission" runat="server" Text='<%# Eval("Admission Fee") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblCanteen" runat="server" Text='<%# Eval("Canteen Fee") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblBuss" runat="server" Text='<%# Eval("Bus Fee") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblFirstAid" runat="server" Text='<%# Eval("First AID") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblPTA" runat="server" Text='<%# Eval("PTA") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblOthers" runat="server" Text='<%# Eval("Others") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblClass" runat="server" Text='<%# Eval("Class Type") %>' /></td>
                                    <td>
                                        <asp:ImageButton ID="btnedit" Text="Edit" runat="server" OnClick="GetValue" Style="padding: 5px" ImageUrl="~/img/edit-11-24.png" />
                                        <asp:ImageButton ID="btndelete" runat="server" OnClick="GetDelete" Text="Delete" OnClientClick="return confirm('Are You Sure to Delete?')" Style="padding: 5px" ImageUrl="~/img/delete-24.png" />
                                    </td>
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

    </div>
    <asp:HiddenField ID="txtfont" runat="server" />
    <br />

    <script type="text/javascript">

        $('#ddlClass').select2({
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

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
