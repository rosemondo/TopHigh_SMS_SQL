<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Page_Settings.aspx.vb" Inherits="Top_High_Schools.Page_Settings" %>


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

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800" id ="usctl">Page Settings</h4>

    </div>


    <div class="row" id="phrow3">

        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title" id="adh">All Page Fonts Style</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">
                        <div class="col-sm-6">
                             <label id ="lblstaff">Fonts</label>
                            <asp:DropDownList ID="ddlfonts" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                             <label id ="lblst">Add Fonts</label>
                            <asp:TextBox ID="txtaddfont" runat="server" CssClass ="form-control"></asp:TextBox>
                        </div>
                    </div>
     
                </div>

                  <!-- /.card-body -->
                <div class="card-footer">
                   <input type="button" id="btnSaveFont" value="Save Fonts Style" class="btn btn-primary" />
                   <input type="button" id="btnAdFont" value="Add to Fonts" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->

            </div>

        </div>

    </div>

    <br />

     <div class="row" id="phrow4">

        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title" >Report Card Fonts & Colour</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">
                        <div class="col-sm-6">
                             <label>Report Card Font</label>
                            <asp:DropDownList ID="ddlcardfont" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                             <label">Details Header Colour</label>
                            <asp:DropDownList ID="ddlcolor" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="getColorCode()"></asp:DropDownList>
                        </div>
                    </div>
     
                </div>

                  <!-- /.card-body -->
                <div class="card-footer">
                   <input type="button" id="btnSaveRepSet" value="Save Fonts Style" class="btn btn-primary" />
                </div>
                <!-- /.card-footer -->

            </div>

        </div>

    </div>


    <br />

   
    <br />

    <asp:HiddenField ID="txtmyid" runat="server" Value ="0" />
    <asp:HiddenField ID="txtmycolorid" runat="server" Value ="0" />
    <asp:HiddenField ID="txtfont" runat="server" />
    <asp:HiddenField ID="txtcolor" runat="server" Value ="#16b60e"/>

    <script type="text/javascript">

        $('#ddlfonts').select2({
            placeholder: 'Select an option'
        });

        $('#ddlcardfont').select2({
            placeholder: 'Select an option'
        });

        $('#ddlcolor').select2({
            placeholder: 'Select an option'
        });

    </script> 


    <script type ="text/javascript">

        function getColorCode() {
            var studname = $("[id*=ddlcolor]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Page_Settings.aspx/GetColorCoe",
                data: "{studname:'" + studname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtcolor]').val(data.d.MyColors);
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };

        $("#btnSaveFont").click(function () {
            var txtmyid = $.trim($('#<%=txtmyid.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Page_Settings.aspx/DeletePagesSettings",
                data: "{'txtmyid':'" + txtmyid + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    InsertPagesSettings()
                }
            });

        });

        function InsertPagesSettings() {
            var ddlfonts = $.trim($('#<%=ddlfonts.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Page_Settings.aspx/InsertPagesSettings",
                data: "{'ddlfonts':'" + ddlfonts + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {

                }
            });

        };

        $("#btnAdFont").click(function () {
            var txtaddfont = $.trim($('#<%=txtaddfont.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Page_Settings.aspx/AddFontd",
                data: "{'txtaddfont':'" + txtaddfont + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
 
                }
            });

        });

        $("#btnSaveRepSet").click(function () {
            var txtmycolorid  = $.trim($('#<%=txtmycolorid.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Page_Settings.aspx/DeleteColorSettings",
                data: "{'txtmycolorid':'" + txtmycolorid + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    InsertColorSettings()
                }
            });

        });

        function InsertColorSettings() {
            var ddlcardfont = $.trim($('#<%=ddlcardfont.ClientID %>').val());
            var txtcolor = $.trim($('#<%=txtcolor.ClientID %>').val());

            $.ajax({
                type: "POST",
                url: "/Page_Settings.aspx/InsertColorSettings",
                data: "{'ddlcardfont':'" + ddlcardfont + "','txtcolor':'" + txtcolor + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {

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
                 document.getElementById("phrow3").style.fontFamily = fontstyle;
                 document.getElementById("phrow4").style.fontFamily = fontstyle;

                 window.setTimeout("countdown()", 1000);
             }
         }
         countdown();
     </script>
    


</asp:Content>
