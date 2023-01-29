<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_leatners_Current_Class.aspx.vb" Inherits="Top_High_Schools.Edit_leatners_Current_Class" %>

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

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id ="myhd">
        <h4 class="h4 mb-0 text-gray-800">Update Learner's Class</h4>

    </div>

    <!-- Input rows -->

    <div class="row" id ="nabyrow1">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Update Learner's Class</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="form-group row">
                        
                        <div class="col-sm-3">
                            <label>Student</label>
                            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" ClientIDMode="Static" requide="true" onchange="getStudID()"></asp:DropDownList>
                        </div>
                        <div class="col-sm-3">
                            <label>Current Class</label>
                            <asp:TextBox runat="server" ID="txtmyclass" CssClass="form-control" ReadOnly="true" BackColor="White"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                             <label>Set New Class</label>
                           <asp:DropDownList ID="ddlclass" runat="server" CssClass="form-control" ClientIDMode="Static" requide="true" onchange="getClassID()"></asp:DropDownList>
                        </div>
                         <asp:HiddenField ID="txtstudid" runat="server" />
                         <asp:HiddenField ID="txtclassid" runat="server" />
                    </div>
                  
                    <hr />

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <input type="button" id="btnSave" value="Save" class="btn btn-primary" />
                    <input type="button" id="btncancel" value="Cancel" class="btn btn-success float-right" onclick="resetAllControls()" />
                </div>
                <!-- /.card-footer -->
            </div>
           
        </div>

    </div>

    <br />

     <asp:HiddenField ID="txtfont" runat="server" />

    <script type="text/javascript">

        $('#ddlStudent').select2({
            placeholder: 'Select an option'
        });

        $('#ddlclass').select2({
            placeholder: 'Select an option'
        });

        $("#btnSave").click(function () {
            var txtclassid = $.trim($('#<%=txtclassid.ClientID %>').val());
            var txtstudid = $.trim($('#<%=txtstudid.ClientID %>').val());;
             $.ajax({
                 type: "POST",
                 url: "/Edit_leatners_Current_Class.aspx/Update_Class",
                 data: "{txtclassid: '" + txtclassid + "','txtstudid':'" + txtstudid + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (r) {
                     resetAllControls()
                 }
             });

        });

        function resetAllControls() {
            $("#form1").find('input:text, input:password, input:file, select, textarea,select2').val('');
            $("#form1").find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
        };

    </script> 

    <script type="text/javascript">

        function getStudID() {
            var studname = $("[id*=ddlStudent]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Edit_leatners_Current_Class.aspx/GetStudID",
                data: "{studname:'" + studname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtstudid]').val(data.d.StudentID);
                    $('[id*=txtmyclass]').val(data.d.ClsName);
                },
                error: function (response) {
                    alert(response.responseText)
                }
            });
        };

        function getClassID() {
            var classname = $("[id*=ddlclass]").find("option:selected").text();
            $.ajax({
                type: "POST",
                url: "/Edit_leatners_Current_Class.aspx/GetClassID",
                data: "{classname:'" + classname + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('[id*=txtclassid]').val(data.d.ClassID);
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