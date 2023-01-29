Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Student_List_by_Class_Parents
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Private pPamt As Double


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetReports()
            GetAgents()

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


    Protected Sub GetAgents()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("select [Class Name] from class_v ")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "class_v")

                    ' BIND DATABASE TO SELECT.
                    dlpyears.DataSource = ds
                    dlpyears.DataTextField = "Class Name"
                    dlpyears.DataValueField = "Class Name"
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


    Protected Sub GetReports()


        rptReportMain.DataSource = GetData("SELECT Class, count(Class) as Count FROM cur_class_v group by Class")
        rptReportMain.DataBind()

    End Sub

    Protected Sub GetReportsByDate()

        rptReportMain.DataSource = GetData("SELECT Class, count(Class) as Count FROM cur_class_v where Class = '" & dlpyears.Text & "' group by Class")
        rptReportMain.DataBind()

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
            rptRepoDetails.DataSource = GetData(String.Format("SELECT [Student Code], Student, Age, [Fathers #], [Mothers #], Active FROM cur_class_v WHERE Class ='{0}'", supdate))
            rptRepoDetails.DataBind()
        End If

    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        GetReportsByDate()
    End Sub
End Class