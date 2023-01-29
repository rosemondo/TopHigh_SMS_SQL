<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Parents_Details.aspx.vb" Inherits="Top_High_Schools.Parents_Details" %>

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

        .select2-container .select2-selection--single {
            height: 34px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }
    </style>

    <script type="text/javascript">
        function printPageArea(areaID) {
            var printContent = document.getElementById(areaID);
            var WinPrint = window.open('', '', 'width=1500,height=1500');
            WinPrint.document.write(printContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Parent Contact List</h4>

    </div>

    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">

                    <div class="dropdown no-arrow" style="float: right">
                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="fas fa-ellipsis-v fa-sm fa-fw" style="color: white">more</i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in"
                            aria-labelledby="dropdownMenuLink" style="float: right">
                            <div class="dropdown-header">Export</div>
                            <div>
                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="Export" OnClick="ExportToExcel" Style="float: right; padding: 5px; margin: 5px" />
                            </div>
                        </div>
                    </div>

                    <h5 class="card-title">Contact List</h5>

                    <div>
                        <asp:Button ID="Button2" runat="server" Text="Print" CssClass="btn btn-primary" OnClientClick="printPageArea('printableArea')" Style="float: right" />
                    </div>

                    <div class="col-sm-4" style="float: left">
                        <label style="color: white">Name</label>
                        <asp:DropDownList ID="ddlstudent" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="true" Style="float: left; width: 300px" ToolTip="Search y Name">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-4" style="float: right">
                        <label style="color: white">Class</label>
                        <asp:DropDownList ID="ddlclass" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="true" Style="float: right; width: 300px" ToolTip="Search by Class">
                        </asp:DropDownList>
                    </div>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div id="printableArea" style="background-color: #FFFFFF">

                    <div class="card-body">

                       <div class="table-responsive">

                        <asp:GridView ID="dvgparents" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="#E7E7FF" AllowPaging="True"
                            OnPageIndexChanging="OnPageIndexChanging" PageSize="50" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerSettings FirstPageText="First" PreviousPageText="Previous"
                                NextPageText="Next" LastPageText="Last" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:BoundField DataField="student_name" HeaderText="Student" />
                                <asp:BoundField DataField="fathers_name" HeaderText="Father's Name" />
                                <asp:BoundField DataField="mathers_name" HeaderText="Mother's Name" />
                                <asp:BoundField DataField="mobile" HeaderText="Father's #" />
                                <asp:BoundField DataField="math_mobile" HeaderText="Mother's #" />
                            </Columns>
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>

                            <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                        </div>

                    </div>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

        <br />



        <asp:TextBox ID="txtdateyear" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtdays" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtmonths" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtseconds" runat="server" Visible="false"></asp:TextBox>
        <asp:HiddenField ID="txtfont" runat="server" />
    </div>

    <br />

    <script type="text/javascript">

        $('#ddlstudent').select2({
            placeholder: 'Seacrh by name'
        });

        $('#ddlclass').select2({
            placeholder: 'Search by class'
        });

    </script>

    <script type="text/javascript">

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
