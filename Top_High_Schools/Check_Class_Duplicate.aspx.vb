Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Check_Class_Duplicate
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            txtsearh.Focus()
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

    Protected Sub GetValue(ByVal sender As Object, ByVal e As EventArgs)

        'Reference the Repeater Item using Button.
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

        'Reference the Label and TextBox.
        Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

        txtID.Text = message

        Session("StudID") = txtID.Text
        Response.Redirect("EditStudent.aspx")

    End Sub

    Protected Sub GetDelete(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'Reference the Repeater Item using Button.
            Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

            'Reference the Label and TextBox.
            Dim message As String = (TryCast(item.FindControl("lblmyid"), Label)).Text

            txtID.Text = message

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteClassDuplicate"}
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = txtID.Text

            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetSearchStudentList()

    End Sub


    <System.Web.Script.Services.ScriptMethod>
    <System.Web.Services.WebMethod>
    Public Shared Function FetchQualifications(prefixText As String) As List(Of String)
        Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ToString()
        Dim cnn As SqlConnection = New SqlConnection(connetionString)
        Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "NameAutoComplete"}
        cmd.Parameters.Add("@QualName", SqlDbType.VarChar).Value = prefixText
        cmd.Connection = cnn

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        Dim QualNames As New List(Of String)()
        For i As Integer = 0 To dt.Rows.Count - 1
            QualNames.Add(dt.Rows(i)(2).ToString())
        Next
        Return QualNames
    End Function



    Protected Sub GetSearchStudentList()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("SearchDuplicate", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@Student", SqlDbType.VarChar).Value = txtsearh.Text
                        cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtsearh.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptstudent.DataSource = dt
                        rptstudent.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Private Sub txtsearh_TextChanged(sender As Object, e As EventArgs) Handles txtsearh.TextChanged
        GetSearchStudentList()
    End Sub

End Class