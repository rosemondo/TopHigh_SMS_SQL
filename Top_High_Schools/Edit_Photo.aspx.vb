Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Edit_Photo
    Inherits System.Web.UI.Page

    Public DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Public Class student_photos_t
        <Key>
        Public Property id As Integer
        Public Property myid As Integer
        Public Property stud_id As String
        Public Property stud_pic As Byte()
        Public Property filename As String
        Public Property contenttype As String
    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Text = IpassAstringfrompage2

            GetPagefont()
            GetStudents()

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
                    dplStudent.DataSource = ds
                    dplStudent.DataTextField = "student"
                    dplStudent.DataValueField = "student"
                    dplStudent.DataBind()
                    dplStudent.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetMYID(sender As Object, e As EventArgs)

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_My_ID"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = dplStudent.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtstudcode.Value = dr.Item("stud_id")
                txtid.Value = dr.Item("id")

            End If

            cnn.Close()

        Catch ex As Exception


        End Try

        ShowStudentPhoto()

    End Sub


    <WebMethod()>
    Public Shared Function SaveCapturedImage(ByVal data As String, ByVal stuid As String, ByVal studcoe As String, ByVal contat As String) As Boolean
        Dim fileName As String = DateTime.Now.ToString("dd-MM-yy hh-mm-ss")
        Dim imageBytes As Byte() = Convert.FromBase64String(data.Split(","c)(1))
        Dim filePath As String = HttpContext.Current.Server.MapPath(String.Format("~/Captures/{0}.jpg", fileName))
        File.WriteAllBytes(filePath, imageBytes)

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Updateadmissionphoto"}
            cmd.Parameters.AddWithValue("@myid", stuid)
            cmd.Parameters.AddWithValue("@filename", "Files/" + fileName)
            cmd.Parameters.AddWithValue("@contenttype", fileName)
            cmd.Parameters.AddWithValue("@stud_pic", imageBytes)
            cmd.Parameters.AddWithValue("@stud_id", studcoe)
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return True
    End Function

    Protected Sub ShowStudentPhoto()

        Try


            Dim id As String = txtid.Value
            imgstudpic.Visible = id <> "0"
            If id <> "0" Then
                Dim bytes As Byte() = DirectCast(GetData(Convert.ToString("SELECT stud_pic FROM student_photos_t WHERE myid =") & id).Rows(0)("stud_pic"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                imgstudpic.ImageUrl = Convert.ToString("data:image/png;base64,") & base64String
            End If


        Catch ex As Exception


        End Try


    End Sub

    Private Function GetData(query As String) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = sCon
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function

End Class