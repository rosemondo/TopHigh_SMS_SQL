﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Emp_List_by_Class.aspx.vb" Inherits="Top_High_Schools.Emp_List_by_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h4 class="h4 mb-0 text-gray-800">Teachers List By Class</h4>
    </div>

    <!-- Input rows -->
    <!--Row with two equal columns-->
    <div class="row">
        <div class="col-md-12">

            <!-- Horizontal Form -->
            <div class="card card-info">
                <div class="card-header">
                    <a href="Employee_List.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                        class="fa fa-list fa-sm text-white-50"></i>Teachers List</a>
                </div>
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">

                    <div>

                        <dx:ASPxGridView ID="dgvlistbyclass" runat="server" AutoGenerateColumns="False"
                            DataSourceID="SqlDataSource1" Width="100%" Theme="iOS">

                            <GroupSummary>
                                <dx:ASPxSummaryItem SummaryType="Count" />
                            </GroupSummary>

                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Employee" ReadOnly="True"
                                    VisibleIndex="0">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Class Name" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn FieldName="Class" VisibleIndex="2"
                                    GroupIndex="0" SortIndex="0" SortOrder="Ascending" Visible="False">
                                    <Settings AllowDragDrop="False" SortMode="Custom" />
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn FieldName="Gender" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>

                            </Columns>

                            <Settings ShowGroupedColumns="True" ShowGroupPanel="True" />
                        </dx:ASPxGridView>


                    </div>

                </div>
                <div>
                    <script src="lib/jquery/jquery.min.js"></script>
                    <script src="plugins/datatables/jquery.dataTables.js"></script>
                    <script src="js/dataTables.semanticui.min.js"></script>
                    <script src="plugins/datatables-responsive/js/dataTables.responsive.min.js"></script>
                    <script src="js/responsive.semanticui.min.js"></script>
                    <script type="text/javascript">
                        $(function () {
                            $('#students').DataTable({
                                responsive: {
                                    details: {
                                        display: $.fn.dataTable.Responsive.display.modal({
                                            header: function (row) {
                                                var data = row.data();
                                                return 'Details for ' + data[0] + ' ' + data[1];
                                            }
                                        }),
                                        renderer: $.fn.dataTable.Responsive.renderer.tableAll({
                                            tableClass: 'ui table'
                                        })
                                    }
                                }
                            });
                        });
                    </script>
                </div>

                <!-- /.card-body -->
                <div class="card-footer">
                </div>
                <!-- /.card-footer -->
            </div>

        </div>

    </div>

    <br />


</asp:Content>
