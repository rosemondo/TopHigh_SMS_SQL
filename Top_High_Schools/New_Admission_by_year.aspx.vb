Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class New_Admission_by_year
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Private pPamt As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetReports()
            Getyear_date()

        End If

    End Sub

    Protected Sub GetPagefont()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from page_settings_t"}
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


        rptReportMain.DataSource = GetData("SELECT myyear FROM new_admission_by_year_v group by myyear")
        rptReportMain.DataBind()

        GetTotalCost()

    End Sub

    Protected Sub GetReportsByDate()


        rptReportMain.DataSource = GetData("SELECT myyear FROM new_admission_by_year_v where myyear = '" & dlpyears.Text & "' group by myyear")
        rptReportMain.DataBind()

        GetTotalCost()

    End Sub

    Protected Sub Getyear_date()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("select myyear from new_admission_by_year_v group by myyear")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "new_admission_by_year_v")

                    ' BIND DATABASE TO SELECT.
                    dlpyears.DataSource = ds
                    dlpyears.DataTextField = "myyear"
                    dlpyears.DataValueField = "myyear"
                    dlpyears.DataBind()

                    dlpyears.Items.Insert(0, "")

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


                Dim lblproduct As Label = TryCast(item.FindControl("lblproduct"), Label)
                Dim lbltotbukets As Label = TryCast(item.FindControl("lbltotbukets"), Label)
                Dim lbltotcans As Label = TryCast(item.FindControl("lbltotcans"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select sum(amt_fee_paid) as amt_fee_paid,sum(amt_admi_paid) as amt_admi_paid from new_admission_by_year_v where myyear = @myyear"}
                'insert product
                cmd.Parameters.Add("@myyear", SqlDbType.Int).Value = lblproduct.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    lbltotbukets.Text = dr.Item("amt_fee_paid")
                    lbltotbukets.Text = Format(lbltotbukets.Text, "Standard")
                    lbltotcans.Text = dr.Item("amt_admi_paid")
                    lbltotcans.Text = Format(lbltotcans.Text, "Standard")

                End If

                cnn.Close()

            Next

        Catch ex As Exception

        End Try


    End Sub


    Protected Function GetData(query As String) As DataTable
        Dim constr As String = sCon
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = query
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        Dim dt As New DataTable()
                        sda.Fill(dt)
                        Return dt
                    End Using
                End Using
            End Using
        End Using
    End Function

    Protected Sub OnItemDataBound(sender As Object, e As RepeaterItemEventArgs)

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim supdate As String = TryCast(e.Item.FindControl("hfdate"), HiddenField).Value
            Dim rptRepoDetails As Repeater = TryCast(e.Item.FindControl("rptRepoDetails"), Repeater)
            rptRepoDetails.DataSource = GetData(String.Format("SELECT student_name, tuition_fee, amt_fee_paid, admission_fee, amt_admi_paid, gender, class_name, aca_term FROM new_admission_by_year_v WHERE myyear ='{0}'", supdate))
            rptRepoDetails.DataBind()
        End If

    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        GetReportsByDate()
    End Sub
End Class