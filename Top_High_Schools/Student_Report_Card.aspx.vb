Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Script.Serialization

Public Class Student_Report_Card
    Inherits System.Web.UI.Page


    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            LoadCompany()
            GetPagefont()
            GetMyAcademicInfo()
            GetReports()
            CompInfo()
            GetClass()
            GetEmp()
            GetMyAcademicInfo()

        End If

    End Sub

    Protected Sub LoadCompany()



        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand("Get_Comp_info")
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtcompid.Text = dr.Item("comp_id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Showcomplogo()

    End Sub

    Protected Sub Showcomplogo()

        Try
            Dim id As String = txtcompid.Text
            logo.Visible = id <> "0"
            If id <> "0" Then
                Dim bytes As Byte() = DirectCast(GetData(Convert.ToString("SELECT comp_logo FROM company_t WHERE comp_id =") & id).Rows(0)("comp_logo"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                logo.ImageUrl = Convert.ToString("data:image/png;base64,") & base64String
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
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_report_font_color"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "pc"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfont.Value = dr.Item("font_style")
                txtbgcolor.Value = dr.Item("color")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub GetReports()

        GetClassType()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Learners_Report_By_Name", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = ddlstudent.Text
                        cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = lblmyacaterm.Value
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = lblmyacayear.Value
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


        CompInfo()
        GetStuIDIdent()
        GetClassType()
        ProcessMyData()
        GetAcademicInfo()
        GetStudAttendace()
        GetAgeInfo()
        GetClassCount()
        GetStudDebt()

    End Sub

    Protected Sub ProcessMyData()

        lblclass.Text = txtclass.Value
        lblnextfees.Text = txtfees.Value

        lblarreas.Text = Format(lblarreas.Text, "Standard")
        lblnextfees.Text = Format(lblnextfees.Text, "Standard")

        Dim tot1 As Double = lblnextfees.Text
        Dim tot2 As Double = lblarreas.Text

        Dim mysum As Double = tot1 + tot2

        lblduefees.Text = mysum

        lblduefees.Text = Format(lblduefees.Text, "Standard")


    End Sub

    Protected Sub GetClassPosition()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassPosition"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = ddlstudent.Text
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = lblmyacaterm.Value
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = lblmyacayear.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblposition.Text = dr.Item("rank_str")
                lbltotalmarks.Text = dr.Item("final_score_100")

            End If

            cnn.Close()


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetAvg()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetAvg_Score"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = ddlstudent.Text
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = lblmyacaterm.Value
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = lblmyacayear.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblaverage.Text = dr.Item("avg")
                lblclassteacherrec.Text = dr.Item("teachers_remarks")
                lblprincrec.Text = dr.Item("princ_remarks")

            End If

            cnn.Close()


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetClassCount()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Number_Onroll"}
            'insert product
            cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = txtclass.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblroll.Text = dr.Item("roll")

            End If

            cnn.Close()


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetAgeInfo()

        'Try

        '    Dim connetionString As String = sCon
        '    Dim cnn As SqlConnection = New SqlConnection(connetionString)
        '    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetstudentAge"}
        '    'insert product
        '    cmd.Parameters.Add("@Student", SqlDbType.VarChar).Value = lbllearners.Text
        '    cmd.Connection = cnn
        '    cnn.Open()

        '    Dim dr As SqlDataReader = cmd.ExecuteReader()
        '    ' If the record can be queried, it means passing verification, then open another form.   
        '    If (dr.Read() = True) Then

        '        lblage.Text = dr.Item("Age")

        '    End If

        '    cnn.Close()


        'Catch ex As Exception

        '    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        '    Dim script = String.Format("alert({0});", message)
        '    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        'End Try

    End Sub

    Protected Sub GetStuIDIdent()


        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_My_ID"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = ddlstudent.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtid.Value = dr.Item("id")

            End If

            cnn.Close()


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowStudentPhoto()

    End Sub

    Protected Sub GetMyAcademicInfo()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_current_year"}
            'insert product
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblmyacayear.Value = dr.Item("aca_year")
                lblmyacaterm.Value = dr.Item("aca_term")

            End If

            cnn.Close()


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub GetAcademicInfo()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_current_year"}
            'insert product
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblterms.Text = dr.Item("aca_term")
                lbloutof.Text = dr.Item("sch_days")


            End If

            cnn.Close()


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

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

    Protected Sub CompInfo()

        Try
            Dim conString As New SqlConnection(sCon)

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Get_Comp_Details"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim Comp, strt, cty, cunt, WorkFon, email, web As String

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("com_name")
                strt = dr.Item("street")
                cty = dr.Item("city")
                cunt = dr.Item("country")
                WorkFon = dr.Item("phone")
                email = dr.Item("email")
                web = dr.Item("website")

                lblcompname.Text = Comp
                lbladress.Text = strt + "," + "" + cty + "-" + "" + cunt
                lblphone.Text = WorkFon
                lblemail.Text = email
                lblweb.Text = web

                dr.Close()

            End If

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetClass()

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

    Protected Sub GetEmp()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetClass")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetClass")

                    ' BIND DATABASE TO SELECT.
                    ddlClassto.DataSource = ds
                    ddlClassto.DataTextField = "ClassName"
                    ddlClassto.DataValueField = "ClassName"
                    ddlClassto.DataBind()
                    ddlClassto.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetStudAttendace()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetMyAttendance"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = ddlstudent.Text
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = lblmyacayear.Value
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = lblmyacaterm.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblattendace.Text = dr.Item("Att_count")

            End If

            cnn.Close()
        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetStudDebt()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetMyDebt"}
            'insert product
            cmd.Parameters.Add("@students", SqlDbType.VarChar).Value = ddlstudent.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblarreas.Text = dr.Item("balance")

            End If

            cnn.Close()



            lblclass.Text = txtclass.Value
            lblnextfees.Text = txtfees.Value

            lblarreas.Text = Format(lblarreas.Text, "Standard")
            lblnextfees.Text = Format(lblnextfees.Text, "Standard")

            Dim tot1 As Double = lblnextfees.Text
            Dim tot2 As Double = lblarreas.Text

            Dim mysum As Double = tot1 + tot2

            lblduefees.Text = mysum

            lblduefees.Text = Format(lblduefees.Text, "Standard")


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetClassType()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_My_Class_Type"}
            'insert product
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = txtclass.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txttype.Value = dr.Item("type")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetStudFees()

    End Sub


    Protected Sub GetStudFees()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_My_Term_Fees"}
            'insert product
            cmd.Parameters.Add("@ClassType", SqlDbType.VarChar).Value = txttype.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfees.Value = dr.Item("Tuition Fee")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetStudClass()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_My_Class"}
            'insert product
            cmd.Parameters.Add("@Student", SqlDbType.VarChar).Value = ddlstudent.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lbllearners.Text = ddlstudent.Text
                txtclass.Value = dr.Item("Class Name")
                lblclass.Text = dr.Item("Class Name")
                lblstudid.Text = dr.Item("ID")
            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Private Sub btnprocess_Click(sender As Object, e As EventArgs) Handles btnprocess.Click
        lblvacation.Text = txtvacadate.Text
        lblnextterm.Text = txtreopen.Text
        lblnote.Text = txtnote.Text
        lblpromo.Text = ddlClassto.Text
        If lblpromo.Text = "0" = True Then
            lblpromo.Text = String.Empty
        End If
        GetClassPosition()
        GetAvg()
        GetReports()
    End Sub

    Private Sub ddlstudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlstudent.SelectedIndexChanged
        GetStudClass()
    End Sub

    Private Sub ddlstudent_TextChanged(sender As Object, e As EventArgs) Handles ddlstudent.TextChanged
        GetStudClass()
    End Sub

    Protected Sub ExportToImage(ByVal sender As Object, ByVal e As EventArgs)
        'Dim base64 As String = Request.Form(hfImageData.UniqueID).Split(","c)(1)
        'Dim bytes As Byte() = Convert.FromBase64String(base64)
        'Dim mm As MailMessage = New MailMessage("SHB@solidhopeschools.com", "SHB@solidhopeschools.com")
        'mm.Subject = "Div Image"
        'mm.Body = "Image Attachment"
        'mm.Attachments.Add(New Attachment(New MemoryStream(bytes), "name.png"))
        'mm.IsBodyHtml = True
        'Dim smtp As SmtpClient = New SmtpClient()
        'smtp.Host = "smtp.mail.solidhopeschools.com"
        'smtp.EnableSsl = True
        'Dim NetworkCred As NetworkCredential = New NetworkCredential()
        'NetworkCred.UserName = "SHB@solidhopeschools.com"
        'NetworkCred.Password = "Solmalik2022##"
        'smtp.UseDefaultCredentials = True
        'smtp.Credentials = NetworkCred
        'smtp.Port = 587
        'smtp.Send(mm)
    End Sub

End Class