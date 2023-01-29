<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Class_Activities.aspx.vb" Inherits="Top_High_Schools.Class_Activities" %>

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


    <div class="row" id="myhd">
        <div class="col-md-12">
            <div class="card card-info">
                <div class="card-header">
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div class="form-group row">
                        
                        <div class="col-sm-6">

                            <asp:Label ID="Label3" runat="server" Text="Type"></asp:Label>
                            <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control" ClientIDMode="Static">
                                <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Text="Class & Home Work" Value="Class & Home Work"></asp:ListItem>
                                    <asp:ListItem Text="Class Assessment" Value="Class Assessment"></asp:ListItem>
                                    <asp:ListItem Text="Terminal Reports" Value="Terminal Reports"></asp:ListItem>
                              
                            </asp:DropDownList>


                            <br />

                            <asp:FileUpload ID="fuFileUploader" runat="server" />
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-success" OnClick="Upload" />

                        </div>

                        <div class="col-sm-4">
                            <asp:Label ID="Label2" runat="server" Text="Class"></asp:Label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                        <asp:TextBox ID="txtclassid" runat="server" Visible="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />

    <div class="row" id="nabyrow1">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Class & Home Work</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

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

                            <asp:TemplateField HeaderText="Delete">
                                <HeaderStyle Width="100px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete-24.png" OnClientClick="return confirm('Are you sure you want to delete selected record ?')" ToolTip="Delete" CausesValidation="false" />
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

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>
    </div>

    <br />

    <div class="row" id="phrow3">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Class Assessment</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:GridView ID="dgvassessment" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id">

                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("item_name") %>' OnClick="LinkButton_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete">
                                <HeaderStyle Width="100px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete-24.png" OnClientClick="return confirm('Are you sure you want to delete selected record ?')" ToolTip="Delete" CausesValidation="false" />
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

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>
    </div>

    <br />

    <div class="row" id="phrow4">
        <div class="col-md-12">

            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Terminal Reports</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:GridView ID="dgvreport" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id" EmptyDataText="No Data">

                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("item_name") %>' OnClick="LinkButtons_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete">
                                <HeaderStyle Width="100px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete-24.png" OnClientClick="return confirm('Are you sure you want to delete selected record ?')" ToolTip="Delete" CausesValidation="false" />
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

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>
    </div>


    <div>
        <asp:Literal ID="ltEmbed" runat="server" />
    </div>

    <asp:TextBox ID="txtdate" runat="server" TextMode="Date" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
    <asp:HiddenField ID="txtfont" runat="server" />
    <br />

    <script type="text/javascript">

        $('#ddlClass').select2({
            placeholder: 'Select an option'
        });

        $('#ddltype').select2({
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

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
