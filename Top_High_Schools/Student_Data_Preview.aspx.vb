Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Student_Data_Preview
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            'GetCompInfo()
            txtemp.Value = Request.QueryString("myEmp")
            txtids.Value = Request.QueryString("myid")
            txtdays.Value = Request.QueryString("mydays")
            txtmonths.Value = Request.QueryString("mymonth")
            txtyears.Value = Request.QueryString("myyear")

            txtid.Value = txtemp.Value + txtids.Value + txtdays.Value + txtmonths.Value + txtyears.Value

            GetCompInfo()
            ShowStudentData()

        End If


    End Sub

    Protected Sub GetCompInfo()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Comp_info"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "sch"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblcompname.Text = dr.Item("com_name")
                lbladress.Text = dr.Item("address")
                lblcontacts.Text = dr.Item("contact")
                lblonline.Text = dr.Item("online")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

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
                txtdateofbirth.Text = DateTime.Parse(dr.Item("dob"))
                txthometown.Text = dr.Item("hometown")
                txtregion.Text = dr.Item("region")
                txtnationality.Text = dr.Item("nationality")
                txtreligion.Text = dr.Item("religion")
                ddlGender.Text = dr.Item("gender")
                txtmyid.Value = dr.Item("id")

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
                'txtmobile.Text = dr.Item("mobile")
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
                'txtmatmobile.Text = dr.Item("math_mobile")
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
                txtdate.Text = dr.Item("decs_date")
                txtsign.Text = dr.Item("decs_sign")
                txtuser.Text = dr.Item("sys_user")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowStudentPhoto()

    End Sub

    Protected Sub ShowStudentPhoto()

        Try


            Dim id As String = txtmyid.Value
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Admission.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session("StudID") = txtid.Value
        Response.Redirect("EditStudent.aspx")
    End Sub

End Class