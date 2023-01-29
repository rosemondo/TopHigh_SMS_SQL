<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="New_Accounts.aspx.vb" Inherits="Top_High_Schools.New_Accounts" %>

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

    <script language="javascript" type="text/javascript">
        function tog1(Check) {
            if (Check == document.getElementById('<%=chkcurass.ClientID%>')) {
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog2(Check) {
            if (Check == document.getElementById('<%=chkrecevables.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog3(Check) {
            if (Check == document.getElementById('<%=chkinven.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog4(Check) {
            if (Check == document.getElementById('<%=chkprepaid.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog5(Check) {
            if (Check == document.getElementById('<%=chkfixass.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog6(Check) {
            if (Check == document.getElementById('<%=chkpaya.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog7(Check) {
            if (Check == document.getElementById('<%=chkbebt.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog8(Check) {
            if (Check == document.getElementById('<%=chkequ.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog9(Check) {
            if (Check == document.getElementById('<%=chkrev.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog10(Check) {
            if (Check == document.getElementById('<%=chkcogs.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog11(Check) {
            if (Check == document.getElementById('<%=chkopexp.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog12(Check) {
            if (Check == document.getElementById('<%=chkotherexp.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkotherexp.ClientID%>').checked = false;
            }

        }

    </script>

    <script language="javascript" type="text/javascript">
        function tog13(Check) {
            if (Check == document.getElementById('<%=chkaccum.ClientID%>')) {
                document.getElementById('<%=chkcurass.ClientID%>').checked = false;
                document.getElementById('<%=chkrecevables.ClientID%>').checked = false;
                document.getElementById('<%=chkinven.ClientID%>').checked = false;
                document.getElementById('<%=chkprepaid.ClientID%>').checked = false;
                document.getElementById('<%=chkfixass.ClientID%>').checked = false;
                document.getElementById('<%=chkpaya.ClientID%>').checked = false;
                document.getElementById('<%=chkbebt.ClientID%>').checked = false;
                document.getElementById('<%=chkequ.ClientID%>').checked = false;
                document.getElementById('<%=chkrev.ClientID%>').checked = false;
                document.getElementById('<%=chkcogs.ClientID%>').checked = false;
                document.getElementById('<%=chkopexp.ClientID%>').checked = false;
            }
            else {
                document.getElementById('<%=chkaccum.ClientID%>').checked = false;
            }

        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4" id="myhd">
        <h4 class="h4 mb-0 text-gray-800">New Account</h4>
         <a href="ChartofAccount.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fa fa-plus fa-sm text-white-50"></i>Account List</a>
    </div>

    <!-- Input rows -->

    <div class="row" id="nabyrow1">

        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Account Group Settings</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">


                    <div class="form-group row">
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkcurass" runat="server" onclick="tog1(this);" Text="CURRENT ASSETS" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkrecevables" runat="server" onclick="tog2(this);" Text="RECEIVABLES" Value="RECEIVABLES" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkinven" runat="server" onclick="tog3(this);" Text="INVENTORIES" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkprepaid" runat="server" onclick="tog4(this);" Text="PREPAID EXPENSES" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkfixass" runat="server" onclick="tog5(this);" Text="FIXED ASSETS" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkpaya" runat="server" onclick="tog6(this);" Text="PAYABLES" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkbebt" runat="server" onclick="tog7(this);" Text="DEBTS" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkequ" runat="server" onclick="tog8(this);" Text="EQUITIES" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkrev" runat="server" onclick="tog9(this);" Text="REVENUE" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkcogs" runat="server" onclick="tog10(this);" Text="COST of GOODS SOLD" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkopexp" runat="server" onclick="tog11(this);" Text="OPERATING EXPENSES" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                        <div class="col-sm-3">
                            <asp:CheckBox ID="chkotherexp" runat="server" onclick="tog12(this);" Text="OTHER EXPENSES" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-sm-6">
                            <asp:CheckBox ID="chkaccum" runat="server" onclick="tog13(this);" Text="ACCUMULATED DEPRECIATION and AMORTIZATION" AutoPostBack="true" OnCheckedChanged="Get_CheckChanged" />
                        </div>
                    </div>

                </div>

            </div>

        </div>

    </div>

    <br />

    <div class="row" id="phrow3">


        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <h5 class="card-title">Account Form</h5>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>


                            <div class="form-group row">

                                <label for="inputEmail3" class="col-sm-2 col-form-label">Account Code</label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtAcCode" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>
                                <asp:TextBox runat="server" ID="txtclassid" Visible="false"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtstudid" Visible="false"></asp:TextBox>
                            </div>
                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Account Name</label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtAcName"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-2 col-form-label">Account Group</label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtAcagroup" required="true" AutoPostBack="true" ReadOnly="true" BackColor="White"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-2 col-form-label">Cash Flow</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="ddlcashflow" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Text="CASH FLOWS FROM OPERATING ACTIVITIES Cash Receipts" Value="OPACR" />
                                        <asp:ListItem Text="CASH FLOWS FROM OPERATING ACTIVITIES Cash Payments" Value="OPACP" />
                                        <asp:ListItem Text="CASH FLOWS FROM INVESTING ACTIVITIES Sale of Assets" Value="INASA" />
                                        <asp:ListItem Text="CASH FLOWS FROM INVESTING ACTIVITIES Purchase of Assets" Value="INAPA" />
                                        <asp:ListItem Text="CASH FLOWS FROM FINANCING ACTIVITIES Cash Receipts" Value="FINCR" />
                                        <asp:ListItem Text="CASH FLOWS FROM FINANCING ACTIVITIES Cash Paid" Value="FINCP" />
                                        <asp:ListItem Text="CASH FLOWS FROM CURRENT ASSETS" Value="CABNE" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <hr />

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="chkcurass" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkrecevables" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkinven" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkprepaid" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkfixass" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkpaya" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkbebt" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkequ" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkrev" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkcogs" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkopexp" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkotherexp" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chkaccum" EventName="CheckedChanged" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                    <input type="button" id="btnSave" value="Save" class="btn btn-primary" />
                    <input type="button" id="btncancel" value="Cancel" class="btn btn-success float-right" onclick="resetAllControls()" />
                    <%--<asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" />--%>
                  <%--  <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-success float-right" />--%>
                </div>
                <!-- /.card-footer -->
            </div>

            <asp:HiddenField ID="txtAcSubGroup" runat="server" />
            <asp:HiddenField ID="txtAcCate" runat="server" />
            <asp:HiddenField ID="txtocbfy" runat="server" />
            <asp:HiddenField ID="txtcogm" runat="server" />
            <asp:HiddenField ID="txtusers" runat="server" />
            <asp:HiddenField ID="txttimer" runat="server" />
            <asp:HiddenField ID="txtlocation" runat="server" />
            <asp:HiddenField ID="txtcomp" runat="server" />
            <asp:HiddenField ID="txtfont" runat="server" />
        </div>



    </div>

    <br />

    <script type="text/javascript">

        $('#ddlcashflow').select2({
            placeholder: 'Select an option'
        });

        $("#btnSave").click(function () {
            var txtAcCode = $.trim($('#<%=txtAcCode.ClientID %>').val());
            var txtAcName = $.trim($('#<%=txtAcName.ClientID %>').val());
            var txtAcagroup = $.trim($('#<%=txtAcagroup.ClientID %>').val());
            var txtAcSubGroup = $.trim($('#<%=txtAcSubGroup.ClientID %>').val());
            var txtAcCate = $.trim($('#<%=txtAcCate.ClientID %>').val());
            var ddlcashflow = $.trim($('#<%=ddlcashflow.ClientID %>').val());
            var txtocbfy = $.trim($('#<%=txtocbfy.ClientID %>').val());
            var txtcogm = $.trim($('#<%=txtcogm.ClientID %>').val());
             $.ajax({
                 type: "POST",
                 url: "/New_Accounts.aspx/InsertChartAcct",
                 data: "{txtAcCode: '" + txtAcCode + "','txtAcName':'" + txtAcName + "','txtAcagroup':'" + txtAcagroup + "','txtAcSubGroup':'" + txtAcSubGroup + "','txtAcCate':'" + txtAcCate + "','ddlcashflow':'" + ddlcashflow + "','txtocbfy':'" + txtocbfy + "','txtcogm':'" + txtcogm + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (r) {
                 }
             });
            $("#form1").find('input:text, input:password, input:file, select, textarea,select2').val('');
            $("#form1").find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
         });


        function resetAllControls() {
            $("#form1").find('input:text, input:password, input:file, select, textarea,select2').val('');
            $("#form1").find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
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
                document.getElementById("phrow3").style.fontFamily = fontstyle;

                window.setTimeout("countdown()", 1000);
            }
        }
        countdown();
    </script>

</asp:Content>
