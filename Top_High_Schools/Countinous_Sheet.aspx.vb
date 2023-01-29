Imports System.Web.Script.Serialization
Imports DevExpress.Web
Imports System.Data.SqlClient

Public Class Countinous_Sheet
    Inherits System.Web.UI.Page


    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("usertest"))

            txtuseraccess.Value = IpassAstringfrompage2


            GetPagefont()
            GetAcademics()
            GetClass()
            GetCourse()

        End If
    End Sub

    Protected Sub CheckClass()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from user_control_t where users = @users"}
            'insert product
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtuseraccess.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtmyclass.Value = dr.Item("class")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        CheckClass2()

    End Sub

    Protected Sub CheckClass2()

        Try

            If txtmyclass.Value = ddlClass.Text = True Then

                GetClassID()

            ElseIf txtmyclass.Value = "All Class" Then

                GetClassID()

            Else

                Response.Redirect("Dashboard.aspx")

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


    Protected Sub GetClass()

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
                    ddlClass.DataSource = ds
                    ddlClass.DataTextField = "ClassName"
                    ddlClass.DataValueField = "ClassName"
                    ddlClass.DataBind()
                    ddlClass.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetCourse()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("Get_Courses")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "Get_Courses")

                    ' BIND DATABASE TO SELECT.
                    ddlcourse.DataSource = ds
                    ddlcourse.DataTextField = "subject"
                    ddlcourse.DataValueField = "subject"
                    ddlcourse.DataBind()
                    ddlcourse.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetClassID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassID"}
            'insert product
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = ddlClass.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtclassid.Text = dr.Item("ID")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        BindRepeater()

    End Sub

    Protected Sub GetCourseID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetCourseID"}
            'insert product
            cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = ddlcourse.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtcourse.Value = dr.Item("sub_code")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetAcademics()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from academic_calendar_t where aca_status = @aca_status"}
            'insert product
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtterm.Text = dr.Item("aca_term")
                txtyear.Text = dr.Item("aca_year")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Private Sub BindRepeater()

        Try

            Dim conString As String = sCon
            Dim query As String = "SELECT * FROM cur_class_v where Class_ID = '" & txtclassid.Text & "'"
            Using con As SqlConnection = New SqlConnection(conString)
                Dim cmd As SqlCommand = New SqlCommand(query)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        RepeaterDB.DataSource = dt
                        RepeaterDB.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Private Sub ddlClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClass.SelectedIndexChanged
        CheckClass()
    End Sub

    Private Sub ddlClass_TextChanged(sender As Object, e As EventArgs) Handles ddlClass.TextChanged
        CheckClass()
    End Sub

    Private Sub ddlcourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcourse.SelectedIndexChanged
        GetCourseID()
    End Sub

    Private Sub ddlcourse_TextChanged(sender As Object, e As EventArgs) Handles ddlcourse.TextChanged
        GetCourseID()
    End Sub

    Protected Sub OnClassAssesment(ByVal sender As Object, ByVal e As EventArgs)

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim studcode As Label = TryCast(item.FindControl("studcode"), Label)
                Dim txtexe1 As TextBox = TryCast(item.FindControl("txtexe1"), TextBox)
                Dim txtexe2 As TextBox = TryCast(item.FindControl("txtexe2"), TextBox)
                Dim txtexe3 As TextBox = TryCast(item.FindControl("txtexe3"), TextBox)
                Dim txtexe4 As TextBox = TryCast(item.FindControl("txtexe4"), TextBox)

                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("insert into class_assesment_sheet_t(stud_id,class_id,sub_code,class_exe_1,class_exe_2,class_exe_3,class_exe_4,aca_term,aca_year) values(@stud_id,@class_id,@sub_code,@class_exe_1,@class_exe_2,@class_exe_3,@class_exe_4,@aca_term,@aca_year)", con)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = studcode.Text
                        cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid.Text
                        cmd.Parameters.Add("@sub_code", SqlDbType.VarChar).Value = txtcourse.Value
                        cmd.Parameters.Add("@class_exe_1", SqlDbType.Float).Value = txtexe1.Text
                        cmd.Parameters.Add("@class_exe_2", SqlDbType.Float).Value = txtexe2.Text
                        cmd.Parameters.Add("@class_exe_3", SqlDbType.Float).Value = txtexe3.Text
                        cmd.Parameters.Add("@class_exe_4", SqlDbType.Float).Value = txtexe4.Text
                        cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtterm.Text
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtyear.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        OnClassTest()

    End Sub

    Protected Sub OnClassTest()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim studcode As Label = TryCast(item.FindControl("studcode"), Label)
                Dim txtexe5 As TextBox = TryCast(item.FindControl("txtexe5"), TextBox)
                Dim txtexe6 As TextBox = TryCast(item.FindControl("txtexe6"), TextBox)
                Dim txtexe7 As TextBox = TryCast(item.FindControl("txtexe7"), TextBox)

                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("insert into class_test_sheet_t(stud_id,class_id,sub_code,class_test_20,class_test_1,class_test_2,aca_term,aca_year) values(@stud_id,@class_id,@sub_code,@class_test_20,@class_test_1,@class_test_2,@aca_term,@aca_year)", con)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = studcode.Text
                        cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid.Text
                        cmd.Parameters.Add("@sub_code", SqlDbType.VarChar).Value = txtcourse.Value
                        cmd.Parameters.Add("@class_test_20", SqlDbType.Float).Value = txtexe5.Text
                        cmd.Parameters.Add("@class_test_1", SqlDbType.Float).Value = txtexe6.Text
                        cmd.Parameters.Add("@class_test_2", SqlDbType.Float).Value = txtexe7.Text
                        cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtterm.Text
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtyear.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        OnHomeWork()

    End Sub

    Protected Sub OnHomeWork()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim studcode As Label = TryCast(item.FindControl("studcode"), Label)
                Dim txtexe8 As TextBox = TryCast(item.FindControl("txtexe8"), TextBox)
                Dim txtexe9 As TextBox = TryCast(item.FindControl("txtexe9"), TextBox)
                Dim txtexe10 As TextBox = TryCast(item.FindControl("txtexe10"), TextBox)
                Dim txtexe11 As TextBox = TryCast(item.FindControl("txtexe11"), TextBox)

                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("insert into homework_sheet_t(stud_id,class_id,sub_code,homework_1,homework_2,homework_3,homework_4,aca_term,aca_year) values(@stud_id,@class_id,@sub_code,@homework_1,@homework_2,@homework_3,@homework_4,@aca_term,@aca_year)", con)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = studcode.Text
                        cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid.Text
                        cmd.Parameters.Add("@sub_code", SqlDbType.VarChar).Value = txtcourse.Value
                        cmd.Parameters.Add("@homework_1", SqlDbType.Float).Value = txtexe8.Text
                        cmd.Parameters.Add("@homework_2", SqlDbType.Float).Value = txtexe9.Text
                        cmd.Parameters.Add("@homework_3", SqlDbType.Float).Value = txtexe10.Text
                        cmd.Parameters.Add("@homework_4", SqlDbType.Float).Value = txtexe11.Text
                        cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtterm.Text
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtyear.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        OnExamSheet()

    End Sub

    Protected Sub OnExamSheet()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim studcode As Label = TryCast(item.FindControl("studcode"), Label)
                Dim txtexe12 As TextBox = TryCast(item.FindControl("txtexe12"), TextBox)

                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("insert into exams_sheet_t(stud_id,class_id,sub_code,exams_score,teachers_remarks,princ_remarks,aca_term,aca_year) values(@stud_id,@class_id,@sub_code,@exams_score,@teachers_remarks,@princ_remarks,@aca_term,@aca_year)", con)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = studcode.Text
                        cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid.Text
                        cmd.Parameters.Add("@sub_code", SqlDbType.VarChar).Value = txtcourse.Value
                        cmd.Parameters.Add("@exams_score", SqlDbType.Float).Value = txtexe12.Text
                        cmd.Parameters.Add("@teachers_remarks", SqlDbType.VarChar).Value = txtlectremarks.Text
                        cmd.Parameters.Add("@princ_remarks", SqlDbType.VarChar).Value = txtprincipalremarks.Text
                        cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtterm.Text
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtyear.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Response.Redirect("Countinous_Sheet.aspx")

    End Sub

End Class