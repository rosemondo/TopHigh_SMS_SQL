Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Admission_Analysis
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


        rptReportMain.DataSource = GetData("SELECT aca_year FROM admission_analysis_1_v group by aca_year")
        rptReportMain.DataBind()

    End Sub

    Protected Sub GetReportsByDate()


        rptReportMain.DataSource = GetData("SELECT aca_year FROM admission_analysis_1_v where aca_year = '" & dlpyears.Text & "' group by aca_year")
        rptReportMain.DataBind()

    End Sub

    Protected Sub Getyear_date()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("select aca_year from admission_analysis_1_v group by aca_year")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "admission_analysis_1_v")

                    ' BIND DATABASE TO SELECT.
                    dlpyears.DataSource = ds
                    dlpyears.DataTextField = "aca_year"
                    dlpyears.DataValueField = "aca_year"
                    dlpyears.DataBind()
                    dlpyears.Items.Insert(0, New ListItem("", "0"))


                    dlpyears.Items.Insert(0, "- SELECT -")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

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
            rptRepoDetails.DataSource = GetData(String.Format("SELECT new_learners_count, amt_fee_paid, amt_admi_paid, Male, Female,class_name FROM admission_analysis_1_v WHERE aca_year ='{0}'", supdate))
            rptRepoDetails.DataBind()
        End If

    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        GetReportsByDate()
    End Sub
End Class