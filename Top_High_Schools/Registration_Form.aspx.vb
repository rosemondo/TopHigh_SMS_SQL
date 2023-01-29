Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services
Imports System.Web.Script.Serialization

Public Class Registration_Form
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try


            If Not IsPostBack Then

                txtnameofchild.Focus()

                GetPagefont()
                GetAdmiID()
                GetEmp()

                Dim YearTrial = Year(Now)
                txtdateyear.Value = YearTrial
                txtdays.Value = DateTime.Now.Day
                txtmonths.Value = DateTime.Now.Month

            End If

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

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

    Protected Sub GetAdmiID()

        Try

            Dim conString As New SqlConnection
            Dim cmd As New SqlCommand
            conString.ConnectionString = sCon
            cmd.Connection = conString
            conString.Open()

            Dim number As Integer
            cmd.CommandText = "select MAX(id)from admission_students_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                txtmyID.Value = number
            Else
                number = cmd.ExecuteScalar + 1
                txtmyID.Value = number
            End If
            cmd.Dispose()
            conString.Close()
            conString.Dispose()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    <WebMethod()>
    Public Shared Function Insertadmissionstudents(ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String, ByVal txtnameofchild As String, ByVal txtdate As Date, ByVal ddlGender As String, ByVal txthometown As String, ByVal txtregion As String, ByVal txtnationality As String, ByVal txtreligion As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insertadmissionstudents"}
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = "TSMS" + myid + mydays + mymonth + myyear
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = txtnameofchild
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = txtdate
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = ddlGender
            cmd.Parameters.Add("@hometown", SqlDbType.VarChar).Value = txthometown
            cmd.Parameters.Add("@region", SqlDbType.VarChar).Value = txtregion
            cmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = txtnationality
            cmd.Parameters.Add("@religion", SqlDbType.VarChar).Value = txtreligion
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
    Public Shared Function Insertadmissionparentsfather(ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String, ByVal txtfathersname As String, ByVal txtaddress As String, ByVal txtmobile As String, ByVal txtfatOcupa As String, ByVal txtfatreligion As String, ByVal txtfateducation As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insertadmissionparentsfather"}
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = "TSMS" + myid + mydays + mymonth + myyear
            cmd.Parameters.Add("@fathers_name", SqlDbType.VarChar).Value = txtfathersname
            cmd.Parameters.Add("@fath_address", SqlDbType.VarChar).Value = txtaddress
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = txtmobile
            cmd.Parameters.Add("@fathers_occupa", SqlDbType.VarChar).Value = txtfatOcupa
            cmd.Parameters.Add("@fath_religion", SqlDbType.VarChar).Value = txtfatreligion
            cmd.Parameters.Add("@fath_education", SqlDbType.VarChar).Value = txtfateducation
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
    Public Shared Function Insertadmissionparentsmother(ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String, ByVal txtmatname As String, ByVal txtmataddress As String, ByVal txtmatmobile As String, ByVal txtmatoccupation As String, ByVal txtmatreligion As String, ByVal txtmateducation As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insertadmissionparentsmother"}
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = "TSMS" + myid + mydays + mymonth + myyear
            cmd.Parameters.Add("@mathers_name", SqlDbType.VarChar).Value = txtmatname
            cmd.Parameters.Add("@math_address", SqlDbType.VarChar).Value = txtmataddress
            cmd.Parameters.Add("@math_mobile", SqlDbType.VarChar).Value = txtmatmobile
            cmd.Parameters.Add("@mathers_occupa", SqlDbType.VarChar).Value = txtmatoccupation
            cmd.Parameters.Add("@math_religion", SqlDbType.VarChar).Value = txtmatreligion
            cmd.Parameters.Add("@math_education", SqlDbType.VarChar).Value = txtmateducation
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
    Public Shared Function Insertadmissiondeclaration(ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String, ByVal txtname As String, ByVal txtdate As Date, ByVal txtsign As String, ByVal txtuser As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_admission_declaration"}
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = "TSMS" + myid + mydays + mymonth + myyear
            cmd.Parameters.Add("@decs_name", SqlDbType.VarChar).Value = txtname
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

        'Session("tuitest") = "SDH" + txtmyID.Value + txtdays.Value + txtmonths.Value + txtdateyear.Value

        'Response.Redirect("Student_Data_Preview.aspx")

        Return True
    End Function


    <WebMethod()>
    Public Shared Function SaveCapturedImage(ByVal data As String, ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String) As Boolean
        Dim fileName As String = DateTime.Now.ToString("dd-MM-yy hh-mm-ss")
        Dim imageBytes As Byte() = Convert.FromBase64String(data.Split(","c)(1))
        Dim filePath As String = HttpContext.Current.Server.MapPath(String.Format("~/Captures/{0}.jpg", fileName))
        File.WriteAllBytes(filePath, imageBytes)

        Dim mystudid As String = "TSMS" + myid + mydays + mymonth + myyear

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Updateadmissionphoto"}
            cmd.Parameters.Add("@myid", SqlDbType.VarChar).Value = myid
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = mystudid
            cmd.Parameters.Add("@filename", SqlDbType.VarChar).Value = "Files/" + fileName
            cmd.Parameters.Add("@contenttype", SqlDbType.VarChar).Value = fileName
            cmd.Parameters.Add("@stud_pic", SqlDbType.VarBinary).Value = imageBytes
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


End Class