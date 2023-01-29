<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="School_Calendar.aspx.vb" Inherits="Top_High_Schools.School_Calendar" %>

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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Academic Calendar Settings</h4>

    </div>

    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">School Calendar</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">


                    <div class="form-group row">

                        <div class="col-sm-9">
                            <label for="inputEmail3" class="col-sm-2 col-form-label">Academic Term</label>
                            <asp:DropDownList ID="ddlterm" runat="server" CssClass="form-control" ClientIDMode="Static">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="First Term" Value="First Term" />
                                <asp:ListItem Text="Second Term" Value="Second Term" />
                                <asp:ListItem Text="Third Term" Value="Third Term" />
                            </asp:DropDownList>
                            <asp:TextBox ID="txtclassid" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtstudid" runat="server" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-9">
                            <label for="inputEmail3" class="col-sm-2 col-form-label">Academic Year</label>
                            <asp:DropDownList ID="ddlyear" runat="server" CssClass="form-control" ClientIDMode="Static">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="2021" Value="2021" />
                                <asp:ListItem Text="2022" Value="2022" />
                                <asp:ListItem Text="2023" Value="2023" />
                                <asp:ListItem Text="2024" Value="2024" />
                                <asp:ListItem Text="2025" Value="2025" />
                                <asp:ListItem Text="2026" Value="2026" />
                                <asp:ListItem Text="2027" Value="2027" />
                                <asp:ListItem Text="2028" Value="2028" />
                                <asp:ListItem Text="2029" Value="2029" />
                                <asp:ListItem Text="2030" Value="2030" />
                                <asp:ListItem Text="2031" Value="2031" />
                                <asp:ListItem Text="2032" Value="2031" />
                                <asp:ListItem Text="2033" Value="2033" />
                                <asp:ListItem Text="2034" Value="2034" />
                                <asp:ListItem Text="2035" Value="2035" />
                                <asp:ListItem Text="2036" Value="2036" />
                                <asp:ListItem Text="2037" Value="2037" />
                                <asp:ListItem Text="2038" Value="2038" />
                                <asp:ListItem Text="2039" Value="2039" />
                                <asp:ListItem Text="2040" Value="2040" />
                                <asp:ListItem Text="2041" Value="2041" />
                                <asp:ListItem Text="2042" Value="2042" />
                                <asp:ListItem Text="2043" Value="2043" />
                                <asp:ListItem Text="2044" Value="2044" />
                                <asp:ListItem Text="2045" Value="2045" />
                                <asp:ListItem Text="2046" Value="2046" />
                                <asp:ListItem Text="2047" Value="2047" />
                                <asp:ListItem Text="2048" Value="2048" />
                                <asp:ListItem Text="2049" Value="2049" />
                                <asp:ListItem Text="2050" Value="2050" />
                                <asp:ListItem Text="2051" Value="2051" />
                                <asp:ListItem Text="2052" Value="2052" />
                                <asp:ListItem Text="2053" Value="2053" />
                                <asp:ListItem Text="2054" Value="2054" />
                                <asp:ListItem Text="2055" Value="2055" />
                                <asp:ListItem Text="2056" Value="2056" />
                                <asp:ListItem Text="2057" Value="2057" />
                                <asp:ListItem Text="2058" Value="2058" />
                                <asp:ListItem Text="2060" Value="2060" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group row">

                        <div class="col-sm-9">
                            <label for="inputEmail3" class="col-sm-2 col-form-label">Start Date</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtstartdate" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">

                        <div class="col-sm-9">
                            <label for="inputPassword3" class="col-sm-2 col-form-label">End Date</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtenddate" TextMode="Date" OnTextChanged="txtenddate_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>

                    <hr />



                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" OnClick="InsertCalenderYear" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->
            </div>
        </div>

        <asp:HiddenField ID="lblid" runat="server" />
        <asp:HiddenField ID="lblmonthcount" runat="server" />
        <asp:HiddenField ID="lbldays" runat="server" Value="0" />
        <asp:HiddenField ID="lblweekends" runat="server" Value="0" />
        <asp:HiddenField ID="lblmultiple" runat="server" Value="2" />
        <asp:HiddenField ID="lblfindays" runat="server" Value="0" />
        <asp:HiddenField ID="txtfont" runat="server" />
    </div>

    <script type="text/javascript">

        $('#ddlterm').select2({
            placeholder: 'Select an option'
        });

        $('#ddlyear').select2({
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
