Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Add_Subjects
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            GetPagefont()
            GetSearchStudentList()
            OnDistinctNumber()

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


    Protected Sub OnDistinctNumber()
        Dim result As List(Of String) = New List(Of String)()
        If Session("Numbers") IsNot Nothing Then
            result = CType(Session("Numbers"), List(Of String))
        End If
        Dim number As String = GetAutoNumber()
        If Not result.Contains(number) Then
            result.Add(number)
            Session("Numbers") = result
            txtcode.Text = number
        End If
    End Sub

    Private Function GetAutoNumber() As String
        Dim numbers As String = "1234567890"
        Dim characters As String = numbers
        Dim length As Integer = 7
        Dim id As String = String.Empty
        For i As Integer = 0 To length - 1
            Dim character As String = String.Empty
            Do
                Dim index As Integer = New Random().Next(0, characters.Length)
                character = characters.ToCharArray()(index).ToString()
            Loop While id.IndexOf(character) <> -1
            id += character
        Next

        Return id
    End Function

    Protected Sub InsertSubjects()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_subject"}
            cmd.Parameters.Add("@sub_code", SqlDbType.VarChar).Value = txtcode.Text
            cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = txtsubject.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        txtcode.Text = String.Empty
        txtsubject.Text = String.Empty
        OnDistinctNumber()

        GetSearchStudentList()

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        InsertSubjects()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        txtcode.Text = String.Empty
        txtsubject.Text = String.Empty
        txtclassid.Text = "- Select -"
        OnDistinctNumber()

    End Sub

    Protected Sub GetSearchStudentList()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Courses_list", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptSubjects.DataSource = dt
                        rptSubjects.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetDelete(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'Reference the Repeater Item using Button.
            Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

            'Reference the Label and TextBox.
            Dim message As String = (TryCast(item.FindControl("lblid"), Label)).Text

            txtID.Text = message

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "delete_Courses"}
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = txtID.Text

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


End Class