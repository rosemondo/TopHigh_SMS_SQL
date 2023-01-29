Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class EditStudent
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("StudID"))

            txtid.Value = IpassAstringfrompage1

            GetEmp()
            GetPagefont()
            ShowStudentData()

            txtnameofchild.Focus()

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

    Protected Sub GetEmp()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetEmpList")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetEmpList")

                    ' BIND DATABASE TO SELECT.
                    ddlUers.DataSource = ds
                    ddlUers.DataTextField = "emp"
                    ddlUers.DataValueField = "emp"
                    ddlUers.DataBind()
                    ddlUers.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub ShowStudentData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM admission_students_t WHERE  stud_id='{0}'", txtid.Value), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtnameofchild.Text = dr.Item("student_name")
                txtdateofbirth.Text = DateTime.Parse(dr.Item("dob")).ToString("yyyy-MM-dd")
                txthometown.Text = dr.Item("hometown")
                txtregion.Text = dr.Item("region")
                txtnationality.Text = dr.Item("nationality")
                txtreligion.Text = dr.Item("religion")
                ddlGender.Text = dr.Item("gender")
                txtpicid.Value = dr.Item("id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowfathersData()

    End Sub

    Protected Sub ShowfathersData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM admission_fathers_info_t WHERE  stud_id='{0}'", txtid.Value), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfathersname.Text = dr.Item("fathers_name")
                txtaddress.Text = dr.Item("fath_address")
                txtmobile.Text = dr.Item("mobile")
                txtfatOcupa.Text = dr.Item("fathers_occupa")
                txtfatreligion.Text = dr.Item("fath_religion")
                txtfateducation.Text = dr.Item("fath_education")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowmothersData()

    End Sub

    Protected Sub ShowmothersData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM admission_mothers_info_t WHERE  stud_id='{0}'", txtid.Value), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtmatname.Text = dr.Item("mathers_name")
                txtmataddress.Text = dr.Item("math_address")
                txtmatmobile.Text = dr.Item("math_mobile")
                txtmatoccupation.Text = dr.Item("mathers_occupa")
                txtmatreligion.Text = dr.Item("math_religion")
                txtmateducation.Text = dr.Item("math_education")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowDeclaData()

    End Sub

    Protected Sub ShowDeclaData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM admission_declaration_t WHERE  stud_id='{0}'", txtid.Value), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtname.Text = dr.Item("decs_name")
                txtdate.Text = DateTime.Parse(dr.Item("decs_date")).ToString("yyyy-MM-dd")
                txtsign.Text = dr.Item("decs_sign")
                ddlUers.Text = dr.Item("sys_user")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowStudentPhoto()

    End Sub

    <WebMethod()>
    Public Shared Function Updateadmissionstudents(ByVal txtid As String, ByVal txtnameofchild As String, ByVal txtdate As Date, ByVal ddlGender As String, ByVal txthometown As String, ByVal txtregion As String, ByVal txtnationality As String, ByVal txtreligion As String) As Boolean

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Updateadmissionstudents"}
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = txtnameofchild
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = txtdate
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = ddlGender
            cmd.Parameters.Add("@hometown", SqlDbType.VarChar).Value = txthometown
            cmd.Parameters.Add("@region", SqlDbType.VarChar).Value = txtregion
            cmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = txtnationality
            cmd.Parameters.Add("@religion", SqlDbType.VarChar).Value = txtreligion
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtid
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

    <WebMethod()>
    Public Shared Function Updateadmissionparentsfather(ByVal txtid As String, ByVal txtfathersname As String, ByVal txtaddress As String, ByVal txtmobile As String, ByVal txtfatOcupa As String, ByVal txtfatreligion As String, ByVal txtfateducation As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Updateadmissionparentsfather"}
            cmd.Parameters.Add("@fathers_name", SqlDbType.VarChar).Value = txtfathersname
            cmd.Parameters.Add("@fath_address", SqlDbType.VarChar).Value = txtaddress
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = txtmobile
            cmd.Parameters.Add("@fathers_occupa", SqlDbType.VarChar).Value = txtfatOcupa
            cmd.Parameters.Add("@fath_religion", SqlDbType.VarChar).Value = txtfatreligion
            cmd.Parameters.Add("@fath_education", SqlDbType.VarChar).Value = txtfateducation
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtid
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

    <WebMethod()>
    Public Shared Function Updateadmissionparentsmother(ByVal txtid As String, ByVal txtmatname As String, ByVal txtmataddress As String, ByVal txtmatmobile As String, ByVal txtmatoccupation As String, ByVal txtmatreligion As String, ByVal txtmateducation As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Updateadmissionparentsmother"}
            cmd.Parameters.Add("@mathers_name", SqlDbType.VarChar).Value = txtmatname
            cmd.Parameters.Add("@math_address", SqlDbType.VarChar).Value = txtmataddress
            cmd.Parameters.Add("@math_mobile", SqlDbType.VarChar).Value = txtmatmobile
            cmd.Parameters.Add("@mathers_occupa", SqlDbType.VarChar).Value = txtmatoccupation
            cmd.Parameters.Add("@math_religion", SqlDbType.VarChar).Value = txtmatreligion
            cmd.Parameters.Add("@math_education", SqlDbType.VarChar).Value = txtmateducation
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtid
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

    <WebMethod()>
    Public Shared Function Updateadmissiondeclaration(ByVal txtid As String, ByVal txtname As String, ByVal txtdate As Date, ByVal txtsign As String, ByVal txtuser As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Updateadmissiondeclaration"}
            cmd.Parameters.Add("@decs_name", SqlDbType.VarChar).Value = txtname
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtid
            cmd.Parameters.Add("@decs_date", SqlDbType.Date).Value = txtdate
            cmd.Parameters.Add("@decs_sign", SqlDbType.VarChar).Value = txtsign
            cmd.Parameters.Add("@sys_user", SqlDbType.VarChar).Value = txtuser
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


            Dim id As String = txtpicid.Value
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