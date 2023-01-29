<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="StudentList.aspx.vb" Inherits="Top_High_Schools.StudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="jquery.min.js"></script>
    <script src="jquery.elevatezoom.min.js"></script>
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

        #zoomA {
            /* (A) OPTIONAL DIMENSIONS */
            width: 50px;
            height: 50px;
            /* (B) ANIMATE ZOOM */
            /* ease | ease-in | ease-out | linear */
            transition: transform ease-in-out 0.3s;
        }

            /* (C) ZOOM ON HOVER */
            #zoomA:hover {
                width: 200px;
                height: 200px;
            }
    </style>

     <script language="javascript" type="text/javascript">
         function tog1(Check) {
             if (Check == document.getElementById('<%=chkid1.ClientID%>')) {
                document.getElementById('<%=chkid2.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkid1.ClientID%>').checked = false;
             }

         }

     </script>

    <script language="javascript" type="text/javascript">
        function tog2(Check) {
            if (Check == document.getElementById('<%=chkid2.ClientID%>')) {
                 document.getElementById('<%=chkid1.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkid2.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog3(Check) {
            if (Check == document.getElementById('<%=chkdob1.ClientID%>')) {
                document.getElementById('<%=chkdob2.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkdob1.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog4(Check) {
            if (Check == document.getElementById('<%=chkdob2.ClientID%>')) {
                document.getElementById('<%=chkdob1.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkdob2.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog5(Check) {
            if (Check == document.getElementById('<%=chkgen1.ClientID%>')) {
                document.getElementById('<%=chkgen2.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkgen1.ClientID%>').checked = false;
            }

        }

    </script>

     <script language="javascript" type="text/javascript">
         function tog6(Check) {
             if (Check == document.getElementById('<%=chkgen2.ClientID%>')) {
                document.getElementById('<%=chkgen1.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkgen2.ClientID%>').checked = false;
             }

         }

     </script>

    <script language="javascript" type="text/javascript">
        function tog7(Check) {
            if (Check == document.getElementById('<%=chkfoto1.ClientID%>')) {
                 document.getElementById('<%=chkfoto2.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkfoto1.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog8(Check) {
            if (Check == document.getElementById('<%=chkfoto2.ClientID%>')) {
                document.getElementById('<%=chkfoto1.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkfoto2.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog9(Check) {
            if (Check == document.getElementById('<%=chkclass1.ClientID%>')) {
                document.getElementById('<%=chkclass2.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkclass1.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog10(Check) {
            if (Check == document.getElementById('<%=chkclass2.ClientID%>')) {
                document.getElementById('<%=chkclass1.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkclass2.ClientID%>').checked = false;
            }

        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id ="head">
        <h4 class="h4 mb-0 text-gray-800">Student List</h4>
        <a href="Registration_Form.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i>Add New</a>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="rowid">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <a href="Student_List_by_Class.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" data-toggle="modal" data-target="#MyPopup"><i
                        class="fa fa-list fa-sm text-white-50"></i>View Settings</a>

                    
                    <div class="dropdown no-arrow" style="float:right">
                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="fas fa-ellipsis-v fa-sm fa-fw" style="color: white">more</i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in"
                            aria-labelledby="dropdownMenuLink" style="float: right">
                            <div class="dropdown-header">Export before Download or View:</div>
                            <div>
                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="Export" OnClick="ExportToExcel" Style="float: right; padding: 5px; margin: 5px" />
                            </div>
                        </div>
                    </div>

                    <asp:TextBox ID="txtsearh" runat="server" Style="float: right; border-radius: 25px; border-color: dodgerblue;margin:7px" ToolTip="Search" AutoPostBack="True"></asp:TextBox>

                    <asp:Label ID="Label2" runat="server" Text="Search : " Style="float: right; color: white; padding: 5px"></asp:Label>
                    <asp:DropDownList ID="dplimit" runat="server" class="form-control" placeholder="Role" required="true" Style="float: right; width: 80px">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                    </asp:DropDownList>


                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="table-responsive">

                        <asp:GridView ID="dvgstudent" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="#E7E7FF" AllowPaging="True"
                            OnPageIndexChanging="OnPageIndexChanging" PageSize="50" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerSettings FirstPageText="First" PreviousPageText="Previous"
                                NextPageText="Next" LastPageText="Last" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Student ID" />
                                <asp:BoundField DataField="Student" HeaderText="Student" />
                                <asp:BoundField DataField="Date of Birth" HeaderText="Date of Birth" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                <asp:BoundField DataField="Class" HeaderText="Class" />
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <img src='data:image/jpg;base64,<%# If(Not String.IsNullOrEmpty(Eval("Name")), Convert.ToBase64String(CType(Eval("Pictures"), Byte())), String.Empty) %>' id="zoomA" alt="image" class='roundimage center-img' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" Text="Edit" runat="server" OnClick="GetValue" Style="padding: 5px" ImageUrl="~/img/edit-11-24.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btndelete" runat="server" OnClick="GetDelete" Text="Delete" OnClientClick="return confirm('Are You Sure to Delete?')" Style="padding: 5px" ImageUrl="~/img/delete-24.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                        <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtoffset" runat="server" Text="0" Visible="false"></asp:TextBox>
                    </div>
                    <div class="form-group row justify-content-center">
                        <%--<div class="col-sm-2">
                        </div>
                        <div class="col-sm-0.5">
                            <asp:Button ID="btnfirst" runat="server" Text="<<" class="btn btn-primary" Style="padding: 5px; margin: 5px; width: 60px" />
                        </div>
                        <div class="col-sm-0.5">

                            <asp:Button ID="btnprevious" runat="server" Text="<" class="btn btn-primary" Style="padding: 5px; margin: 5px; width: 60px" />
                        </div>--%>
                        <div class="col-sm-2 justify-content-center">
                            <asp:Label ID="Label1" runat="server" Text="Total Row(s)" Style="font-size: 14px; color: black; align-items: center" Font-Bold="true"></asp:Label>
                            <asp:Label ID="lbltotals" runat="server" Text="0" Style="font-size: 14px; color: black; align-items: center" Font-Bold="true"></asp:Label>
                        </div>
                       <%-- <div class="col-sm-0.5">
                            <asp:Button ID="btnnext" runat="server" Text=">" class="btn btn-primary" Style="padding: 5px; margin: 5px; width: 60px" />
                        </div>
                        <div class="col-sm-0.5">
                            <asp:Button ID="btnlast" runat="server" Text=">>" class="btn btn-primary" Style="padding: 5px; margin: 5px; width: 60px" />
                        </div>
                        <div class="col-sm-2">
                        </div>--%>
                    </div>
                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />

    <!-- Modal Popup -->
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h5 class="card-title">List Setting</h5>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">

                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <label>Student ID</label></td>
                                            <td>
                                                <asp:CheckBox ID="chkid1" runat="server" Text="Yes" onclick="tog1(this);" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkid2" runat="server" Text="No" onclick="tog2(this);" /></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <label>Date of Birth</label></td>
                                            <td>
                                                <asp:CheckBox ID="chkdob1" runat="server" Text="Yes" onclick="tog3(this);" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkdob2" runat="server" Text="No" onclick="tog4(this);" /></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <label>Gender</label></td>
                                            <td>
                                                <asp:CheckBox ID="chkgen1" runat="server" Text="Yes" onclick="tog5(this);" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkgen2" runat="server" Text="No" onclick="tog6(this);" /></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <label>Class</label></td>
                                            <td>
                                                <asp:CheckBox ID="chkclass1" runat="server" Text="Yes" onclick="tog9(this);" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkclass2" runat="server" Text="No" onclick="tog10(this);" /></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <label>Photo</label></td>
                                            <td>
                                                <asp:CheckBox ID="chkfoto1" runat="server" Text="Yes" onclick="tog7(this);" /></td>
                                            <td>
                                                <asp:CheckBox ID="chkfoto2" runat="server" Text="No" onclick="tog8(this);" /></td>
                                        </tr>
                                    </table>

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

            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">
                    Close</button>
            </div>
        </div>
    </div>

    <!-- Modal Popup -->

    <asp:HiddenField ID="hfid" runat="server" Value="0" />
    <asp:HiddenField ID="hfstudid" runat="server" Value="0" />
    <asp:HiddenField ID="hfdob" runat="server" Value="0" />
    <asp:HiddenField ID="hfgen" runat="server" Value="0" />
    <asp:HiddenField ID="hffoto" runat="server" Value="0" />
    <asp:HiddenField ID="hfcls" runat="server" Value="0" />
    <asp:HiddenField ID="txtfont" runat="server" />
    <asp:Label ID="lblConfirm" runat="server" Text=""></asp:Label>

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

                  document.getElementById("head").style.fontFamily = fontstyle;
                  document.getElementById("rowid").style.fontFamily = fontstyle;

                  window.setTimeout("countdown()", 1000);
              }
          }
          countdown();
      </script>

</asp:Content>
