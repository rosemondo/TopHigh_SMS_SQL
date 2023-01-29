Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class School_Fees_List
    Inherits System.Web.UI.Page


    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Private pPamt As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetReports()
            GetStudents()
            GetPagefont()

        End If

    End Sub

    Protected Sub GetPagefont()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_page_settings"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "pc"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfont.Value = dr.Item("font_style")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub GetReports()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_fees_collections", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptReportMain.DataSource = dt
                        rptReportMain.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetTotalCost()

    End Sub

    Protected Sub GetReportsByDate()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_fees_collections_by_dates", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@col_datefrom", SqlDbType.Date).Value = txtdatefrom.Text
                        cmd.Parameters.Add("@col_dateto", SqlDbType.Date).Value = txtdateto.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptReportMain.DataSource = dt
                        rptReportMain.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetTotalCost()

    End Sub

    Protected Sub GetReportsByName()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_fees_collections_by_names", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = ddlstudent.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptReportMain.DataSource = dt
                        rptReportMain.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetTotalCost()

    End Sub

    Protected Sub GetStudents()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetStudentList")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetStudentList")

                    ' BIND DATABASE TO SELECT.
                    ddlstudent.DataSource = ds
                    ddlstudent.DataTextField = "student"
                    ddlstudent.DataValueField = "student"
                    ddlstudent.DataBind()
                    ddlstudent.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetTotalCost()

        Try

            For Each item As RepeaterItem In rptReportMain.Items


                Dim lbldate As Label = TryCast(item.FindControl("lbldate"), Label)
                Dim lblyear As Label = TryCast(item.FindControl("lblyear"), Label)
                Dim lbltotbukets As Label = TryCast(item.FindControl("lbltotbukets"), Label)
                Dim lbltotcans As Label = TryCast(item.FindControl("lbltotcans"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetTotal_Fees"}
                'insert product
                cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = lblyear.Text
                cmd.Parameters.Add("@col_date", SqlDbType.Date).Value = lbldate.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    lbltotbukets.Text = dr.Item("amount_paid")
                    lbltotbukets.Text = Format(lbltotbukets.Text, "Standard")

                End If

                cnn.Close()

            Next

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub OnItemDataBound(sender As Object, e As RepeaterItemEventArgs)

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim supdate As String = TryCast(e.Item.FindControl("hfdate"), HiddenField).Value
            Dim supyeardate As String = TryCast(e.Item.FindControl("hfyear"), HiddenField).Value
            Dim rptRepoDetails As Repeater = TryCast(e.Item.FindControl("rptRepoDetails"), Repeater)

            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

                Using cmd As SqlCommand = New SqlCommand("Get_fees_by_year_date", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = supyeardate
                        cmd.Parameters.Add("@col_date", SqlDbType.VarChar).Value = supdate
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptRepoDetails.DataSource = dt
                        rptRepoDetails.DataBind()
                    End Using
                End Using
            End Using


        End If

    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        If chkname.Checked = True Then
            GetReportsByName()
        Else
            GetReportsByDate()
        End If
    End Sub
End Class