<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="WebForm1.aspx.vb" Inherits="Top_High_Schools.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Select/jquery.min_4.js"></script>
    <script src="Select/select2.js"></script>
    <link href="Select/select2.min_2.css" rel="stylesheet" />


    <script>
        function sum() {
            var txt1 = document.getElementById('<%= txtexe1.ClientID %>').value;
             var txt2 = document.getElementById('<%= txtexe2.ClientID %>').value;
             var txt3 = document.getElementById('<%= txtexe3.ClientID %>').value;
             var txt4 = document.getElementById('<%= txtexe4.ClientID %>').value;
             var result = parseFloat(txt1) + parseFloat(txt2) + parseFloat(txt3) + parseFloat(txt4);
             if (!isNaN(result)) {
                 document.getElementById('<%= txttotals.ClientID %>').value = result;
            }
        }
    </script>

    <%--     <script>
         function addsum() {
            
             var txt9 = document.getElementById('<%= txtexam100.ClientID %>').value;
             var mytxt = document.getElementById('<%= txt2.ClientID %>').value;
             var myresult = parseFloat(txt9) / mytxt;
            if (!isNaN(result)) {
                document.getElementById('<%= txtexam50.ClientID %>').value = myresult;
             }
         }
     </script>

     <script>
         function myFunction(txt) {

             var txt12 = document.getElementById('txttot50').value;
             var txt13 = document.getElementById('txtexam50').value;
             var myaddresult = parseFloat(txt12) + parseFloat(txt13);
            if (!isNaN(result)) {
                document.getElementById('txttot100').value = myaddresult;
             }
         }
     </script>--%>


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
        <h4 class="h4 mb-0 text-gray-800">Class Assesment Sheet</h4>
    </div>

    <div class="row" id="nabyrow1">
        <div class="col-md-12">
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-4">
                            <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Class"></asp:Label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                            <asp:TextBox ID="txtclassid" runat="server" Visible="false"></asp:TextBox>
                        </div>

                        <div class="col-sm-6">
                            <asp:Label ID="Label2" runat="server" class="col-form-label" Text="Student"></asp:Label>
                            <asp:DropDownList ID="ddlstudent" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                            <asp:HiddenField ID="txtstsudid" runat="server" />
                            <asp:HiddenField ID="txtclass" runat="server" />
                            <asp:HiddenField ID="txtcourse" runat="server" />
                        </div>



                    </div>

                    <asp:TextBox runat="server" ID="txtproclassid" Visible="false"></asp:TextBox>
                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-success" Style="float: right" />
                </div>
                <!-- /.card-footer -->

            </div>
        </div>
    </div>

    <br />

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row" id="phrow3">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">

                        <div class="col-sm-2">
                            <asp:Label ID="Label7" runat="server" class="col-form-label" Text="Subject"></asp:Label>
                            <asp:DropDownList ID="ddlcourse" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" requide="true"></asp:DropDownList>
                            <asp:TextBox ID="txtcourseid" runat="server" Visible="false"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <asp:Label ID="Label10" runat="server" class="col-form-label" Text="Exercise 10%"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtexe1" Text="0" required="true" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <asp:Label ID="Label11" runat="server" class="col-form-label" Text="Exercise 10%"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtexe2" Text="0" required="true" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <asp:Label ID="Label12" runat="server" class="col-form-label" Text="Exercise 10%"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtexe3" Text="0" required="true" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <asp:Label ID="Label3" runat="server" class="col-form-label" Text="Exercise 10%"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtexe4" Text="0" required="true" onkeyup="sum()"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <asp:Label ID="Label4" runat="server" class="col-form-label" Text="Total 40%"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txttotals" Text="0" required="true" ReadOnly="true" Style="background-color: white"></asp:TextBox>
                        </div>
                    </div>

                    <br />

                </div>
                <div>
                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <input type="button" id="btnSave" value="Process" class="btn btn-success float-right" />
                </div>
                <!-- /.card-footer -->
            </div>
            <asp:TextBox ID="txtusers" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtlinkcode" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtgrade" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtremark" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txt2" runat="server" Text="2" Visible="false"></asp:TextBox>
            <asp:HiddenField ID="txtyear" runat="server" />
            <asp:HiddenField ID="txtterm" runat="server" />
            <asp:HiddenField ID="txtuseraccess" runat="server" />
            <asp:HiddenField ID="txtmyclass" runat="server" />
        </div>
    </div>

    <br />

    <div class="row" id="phrow4">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                       
                        <asp:Repeater runat="server" ID="rptCustomers">
                            <HeaderTemplate>
                                <table id="tblCustomers">
                                    <thead>
                                        <th>Customer Id</th>
                                        <th>Name</th>
                                        <th>Country</th>
                                        <th></th>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="customerid">
                                        <asp:Label Text='<%# Eval("customerid") %>' runat="server" /></td>
                                    <td class="name">
                                        <asp:Label Text='<%# Eval("name") %>' runat="server" />
                                        <asp:TextBox Text='<%# Eval("name") %>' runat="server" Style="display: none" /></td>
                                    <td class="country">
                                        <asp:Label Text='<%# Eval("country") %>' runat="server" />
                                        <asp:TextBox Text='<%# Eval("country") %>' runat="server" Style="display: none" /></td>
                                    <td>
                                        <asp:LinkButton Text="Edit" runat="server" CssClass="Edit" />
                                        <asp:LinkButton Text="Update" runat="server" CssClass="Update" Style="display: none" />
                                        <asp:LinkButton Text="Cancel" runat="server" CssClass="Cancel" Style="display: none" />
                                        <asp:LinkButton Text="Delete" runat="server" CssClass="Delete" /></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
        </table>
                            </FooterTemplate>
                        </asp:Repeater>
                       

                      <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                            <tr>
                                <td style="width: 150px">Name:<br />
                                    <asp:TextBox ID="txtName" runat="server" Width="140" />
                                </td>
                                <td style="width: 150px">Country:<br />
                                    <asp:TextBox ID="txtCountry" runat="server" Width="140" />
                                </td>
                                <td style="width: 100px">
                                    <br />
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" />
                                </td>
                            </tr>
                        </table>


                </div>

            </div>

        </div>
    </div>

    <asp:HiddenField ID="txtID" runat="server" />
    <asp:HiddenField ID="txtfont" runat="server" />

    <script type="text/javascript">

        $('#ddlcourse').select2({
            placeholder: 'Select an option'
        });

        $('#ddlstudent').select2({
            placeholder: 'Select an option'
        });

        $('#ddlClass').select2({
            placeholder: 'select an option'
        });

    </script>



    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "/WebForm1.aspx/GetCustomers",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess
            });
        });

        function OnSuccess(response) {
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var customers = xml.find("Table");
            var row = $("[id*=tblCustomers] tbody tr:last-child");
            if (customers.length > 0) {
                $.each(customers, function () {
                    var customer = $(this);
                    AppendRow(row, $(this).find("customerid").text(), $(this).find("name").text(), $(this).find("country").text())
                    row = $("[id*=tblCustomers] tbody tr:last-child").clone(true);
                });
            } else {
                row.find(".Edit").hide();
                row.find(".Delete").hide();
                row.find("span").html('&nbsp;');
            }
        }

        function AppendRow(row, customerid, name, country) {
            //Bind CustomerId.
            $(".customerid", row).find("span").html(customerid);

            //Bind Name.
            $(".name", row).find("span").html(name);
            $(".name", row).find("input").val(name);

            //Bind Country.
            $(".country", row).find("span").html(country);
            $(".country", row).find("input").val(country);

            row.find(".Edit").show();
            row.find(".Delete").show();
            $("[id*=tblCustomers]").append(row);
        }

        //Add event handler.
        $("body").on("click", "[id*=btnAdd]", function () {
            var txtName = $("[id*=txtName]");
            var txtCountry = $("[id*=txtCountry]");
            $.ajax({
                type: "POST",
                url: "/WebForm1.aspx/InsertCustomer",
                data: '{name: "' + txtName.val() + '", country: "' + txtCountry.val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var row = $("[id*=tblCustomers] tr:last-child");
                    if ($("[id*=tblCustomers] tr:last-child span").eq(0).html() != "&nbsp;") {
                        row = row.clone();
                    }
                    AppendRow(row, response.d, txtName.val(), txtCountry.val());
                    txtName.val("");
                    txtCountry.val("");
                }
            });
            return false;
        });

        //Edit event handler.
        $("body").on("click", "[id*=tblCustomers] .Edit", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find("input").length > 0) {
                    $(this).find("input").show();
                    $(this).find("span").hide();
                }
            });
            row.find(".Update").show();
            row.find(".Cancel").show();
            row.find(".Delete").hide();
            $(this).hide();
            return false;
        });

        //Update event handler.
        $("body").on("click", "[id*=tblCustomers] .Update", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find("input").length > 0) {
                    var span = $(this).find("span");
                    var input = $(this).find("input");
                    span.html(input.val());
                    span.show();
                    input.hide();
                }
            });
            row.find(".Edit").show();
            row.find(".Delete").show();
            row.find(".Cancel").hide();
            $(this).hide();

            var customerId = row.find(".CustomerId").find("span").html();
            var name = row.find(".Name").find("span").html();
            var country = row.find(".Country").find("span").html();
            $.ajax({
                type: "POST",
                url: "/WebForm1.aspx/UpdateCustomer",
                data: '{customerId: ' + customerId + ', name: "' + name + '", country: "' + country + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            });

            return false;
        });

        //Cancel event handler.
        $("body").on("click", "[id*=tblCustomers] .Cancel", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find("input").length > 0) {
                    var span = $(this).find("span");
                    var input = $(this).find("input");
                    input.val(span.html());
                    span.show();
                    input.hide();
                }
            });
            row.find(".Edit").show();
            row.find(".Delete").show();
            row.find(".Update").hide();
            $(this).hide();
            return false;
        });

        //Delete event handler.
        $("body").on("click", "[id*=tblCustomers] .Delete", function () {
            if (confirm("Do you want to delete this row?")) {
                var row = $(this).closest("tr");
                var customerId = row.find("span").html();
                $.ajax({
                    type: "POST",
                    url: "/WebForm1.aspx/DeleteCustomer",
                    data: '{customerId: ' + customerId + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if ($("[id*=tblCustomers] tr").length > 2) {
                            row.remove();
                        } else {
                            row.find(".Edit").hide();
                            row.find(".Delete").hide();
                            row.find("span").html('&nbsp;');
                        }
                    }
                });
            }

            return false;
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

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
