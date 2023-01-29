<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_Staff_Foto.aspx.vb" Inherits="Top_High_Schools.Edit_Staff_Foto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />

    <script src="jquery.min_9.js"></script>

    <script src="WebCam.js"></script>

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

        .select2-container .select2-selection--single {
            height: 34px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }
    </style>

    <script type="text/javascript">

        const image = document.getElementById('imgCapture');

        function ShowImagePreview(input) {
            if (image && image[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrv.ClientID%>').prop('src', e.target.result)
                        .width(150)
                        .height(150);
                };
                reader.readAsDataURL(image[0]);
            }
        }
    </script>

    <script src="webcamjs/webcam.min.js"></script>

    <script src="webcamjs/webcam.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">Update Staff Photo</h4>
        <a href="Staff_List.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-list fa-sm text-white-50"></i>Staff List</a>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="nabyrow1">
        <div class="col-md-8">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Staff Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="form-group row">

                                <div class="col-md-7">
                                    <div class="form-group">
                                        <label>Staff</label>
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fa fa-user"></i></span>
                                            </div>
                                            <asp:DropDownList ID="dplStudent" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="GetEmpID" requide="true"></asp:DropDownList>
                                            <asp:HiddenField ID="txtid" runat="server" />
                                            <asp:HiddenField ID="txtstudcode" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-5">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:Image ID="imgstudpic" runat="server" Width="200px" Height="200px" />
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="dplStudent" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>

            </div>

        </div>

    </div>

    <br />

    <div class="row" id="phrow3">

        <div class="col-md-6">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title" id="upf">Upload Staff's Photo</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">


                    <fieldset style="width: 150px;">
                        <div style="text-align: center;">
                            <asp:Image ID="ImgPrv" runat="server" Style="visibility: hidden; width: 320px; height: 240px" /><br />
                            <asp:FileUpload ID="flupImage" runat="server" onchange="ShowImagePreview(this);" />



                        </div>

                    </fieldset>


                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->

            </div>
            <!-- /.card -->

        </div>



        <div class="col-md-6">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Snap & Save Staff's Photo</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <fieldset style="width: 150px;">

                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <th align="center"><u>Live Camera</u></th>
                                <th align="center"><u>Captured Picture</u></th>
                            </tr>
                            <tr>
                                <td>
                                    <div id="webcam"></div>
                                </td>
                                <td>
                                    <img id="imgCapture" src="no image" /></td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <input type="button" id="btnCapture" value="Capture" />
                                </td>
                            </tr>
                        </table>


                    </fieldset>
                    <span id="msg"></span>
                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                    <input type="button" id="btnSave" value="Update" class="btn btn-primary" />
                    <input type="button" id="btncancel" value="Cancel" class="btn btn-success float-right" />

                </div>
                <!-- /.card-footer -->

            </div>
            <!-- /.card -->

        </div>

        <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txttimer" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
        <asp:HiddenField ID="txtfont" runat="server" />
    </div>
    <br />


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
                });
            });
        });
    </script>

    <script type="text/javascript">

        $("#btnSave").click(function () {
            var stuid = $.trim($('#<%=txtid.ClientID %>').val());
            var studcoe = $.trim($('#<%=txtstudcode.ClientID %>').val());
            $.ajax({
                type: "POST",
                url: "/Edit_Staff_Foto.aspx/SaveCapturedImage",
                data: "{data: '" + $("#imgCapture")[0].src + "','studcoe':'" + studcoe + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    window.location.href = "/Edit_Staff_Foto.aspx";
                }
            });

        });

        $("#btncancel").click(function () {
            $("#form1").find('input:text, input:password, input:file, select, textarea').val('');
            $("#form1").find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
        });



    </script>

    <script type="text/javascript">

        $('#dplStudent').select2({
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
