Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Project_Home_Work
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
            GetStudents()
            GetCourse()
            Get_Exams_Report_List()

        End If

    End Sub

    Protected Sub CheckClass()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Check_user_class_cont"}
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
                Get_Exams_Report_List()

            ElseIf txtmyclass.Value = "All Class" Then

                GetClassID()
                Get_Exams_Report_List()

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

    Private Sub btn_Gen_Click(sender As Object, e As EventArgs) Handles btn_Gen.Click


        If ddlClass.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Class."");</script")
            Exit Sub
        End If

        If ddlstudent.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Student."");</script")
            Exit Sub
        End If

        If ddlcourse.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Course."");</script")
            Exit Sub
        End If

        txtclass.Value = ddlClass.Text
        txtcourse.Value = ddlcourse.Text
        InsertAssesment()

    End Sub

    Protected Sub InsertAssesment()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Home_Work"}
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstsudid.Value
            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Parameters.Add("@sub_code", SqlDbType.VarChar).Value = txtcourseid.Text
            cmd.Parameters.Add("@homework_1", SqlDbType.Float).Value = txtexe1.Text
            cmd.Parameters.Add("@homework_2", SqlDbType.Float).Value = txtexe2.Text
            cmd.Parameters.Add("@homework_3", SqlDbType.Float).Value = txtexe3.Text
            cmd.Parameters.Add("@homework_4", SqlDbType.Float).Value = txtexe4.Text
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtterm.Value
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtyear.Value
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        txtexe1.Text = 0
        txtexe2.Text = 0
        txtexe3.Text = 0
        txtexe4.Text = 0
        Get_Exams_Report_()

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

    End Sub

    Protected Sub GetStudentID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetStudentID"}
            'insert product
            cmd.Parameters.Add("@Student", SqlDbType.VarChar).Value = ddlstudent.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtstsudid.Value = dr.Item("ID")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

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

                txtcourseid.Text = dr.Item("sub_code")

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
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_current_year"}
            'insert product
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtterm.Value = dr.Item("aca_term")
                txtyear.Value = dr.Item("aca_year")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub Get_Exams_Report_List()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_class_home_work_rep", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtterm.Value
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtyear.Value
                        cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = txtclass.Value
                        cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = txtcourse.Value
                        Dim dt As DataTable = New DataTable()
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

    Protected Sub Get_Exams_Report_()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_class_home_work_rep", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtterm.Value
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtyear.Value
                        cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = txtclass.Value
                        cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = txtcourse.Value
                        Dim dt As DataTable = New DataTable()
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


    Protected Sub Get_Exams_Report_List_Search()

        txtclass.Value = ddlClass.Text
        txtcourse.Value = ddlcourse.Text

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_homework_rep_search", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtterm.Value
                        cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtyear.Value
                        cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = txtclass.Value
                        cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = txtcourse.Value
                        Dim dt As DataTable = New DataTable()
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


    Private Sub ddlcourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcourse.SelectedIndexChanged
        GetCourseID()
        Get_Exams_Report_List()
    End Sub

    Private Sub ddlcourse_TextChanged(sender As Object, e As EventArgs) Handles ddlcourse.TextChanged
        GetCourseID()
        Get_Exams_Report_List()
    End Sub

    Private Sub ddlstudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlstudent.SelectedIndexChanged
        GetStudentID()
    End Sub

    Private Sub ddlstudent_TextChanged(sender As Object, e As EventArgs) Handles ddlstudent.TextChanged
        GetStudentID()
    End Sub

    Private Sub ddlClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClass.SelectedIndexChanged
        CheckClass
    End Sub

    Private Sub ddlClass_TextChanged(sender As Object, e As EventArgs) Handles ddlClass.TextChanged
        CheckClass
    End Sub


    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Get_Exams_Report_List_Search()
    End Sub

    Protected Sub GetValue(ByVal sender As Object, ByVal e As EventArgs)

        'Reference the Repeater Item using Button.
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

        'Reference the Label and TextBox.
        Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

        txtID.Value = message

        Session("StudID") = txtID.Value
        Response.Redirect("Edit_Homework.aspx")

    End Sub

End Class