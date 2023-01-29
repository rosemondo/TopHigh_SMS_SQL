Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Students_Report_by_Class
    Inherits System.Web.UI.Page


    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            txtreopen.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")
            txtvacadate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            GetReports()
            CompInfo()
            GetClass()
            GetTerms()
            GetYears()
            GetMyAcademicInfo()

        End If

    End Sub

    Protected Sub GetPagefont()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from report_font_color_t"}
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

        GetStudFees()

        rptReportMain.DataSource = GetData("SELECT id,student_name,aca_term,aca_year,count(att_staus) as tot_count,sch_days,stud_id FROM attendance_v1 where `Class Name` = '" & ddlclass.Text & "' and aca_term = '" & ddlacaterm.Text & "' and aca_year = '" & ddlacayear.Text & "' group by id,student_name,aca_term,aca_year,sch_days,stud_id")
        rptReportMain.DataBind()

        CompInfo()

        GetClassPosition()
        ProcessMyData()
        GetClassCount()
        GetStudDebt()
        ShowStudentPhoto()
        GetAcademicInfo()
        GetAvg()


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
            Dim customerId As String = TryCast(e.Item.FindControl("lbllearners"), Label).Text
            Dim rptRepoDetails As Repeater = TryCast(e.Item.FindControl("rptRepoDetails"), Repeater)
            rptRepoDetails.DataSource = GetData(String.Format("SELECT * FROM exams_report_final_v WHERE student_name='{0}' and aca_year='{1}' and aca_term='{2}'", customerId, ddlacayear.Text, ddlacaterm.Text))
            rptRepoDetails.DataBind()
        End If


    End Sub

    Protected Sub GetAvg()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim lbllearners As Label = TryCast(item.FindControl("lbllearners"), Label)
                Dim lblaverage As Label = TryCast(item.FindControl("lblaverage"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select AVG(final_score_100) AS avg from exams_report_final_v where student_name = @student_name and aca_term = @aca_term and aca_year = @aca_year"}
                'insert product
                cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = lbllearners.Text
                cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = ddlacaterm.Text
                cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = ddlacayear.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    lblaverage.Text = dr.Item("avg")

                    lblaverage.Text = Format(lblaverage.Text, "Standard")

                End If

                cnn.Close()


            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ProcessMyData()

        For Each item As RepeaterItem In rptReportMain.Items

            Dim lblclass As Label = TryCast(item.FindControl("lblclass"), Label)
            Dim lblterms As Label = TryCast(item.FindControl("lblterms"), Label)
            Dim lblvacadate As Label = TryCast(item.FindControl("lblvacation"), Label)
            Dim lblreopendate As Label = TryCast(item.FindControl("lblnextterm"), Label)
            Dim lblnextfees As Label = TryCast(item.FindControl("lblnextfees"), Label)
            Dim lblarreas As Label = TryCast(item.FindControl("lblarreas"), Label)
            Dim lblduefees As Label = TryCast(item.FindControl("lblduefees"), Label)

            lblclass.Text = ddlclass.Text
            lblterms.Text = ddlacaterm.Text
            lblvacadate.Text = txtvacadate.Text
            lblreopendate.Text = txtreopen.Text
            lblnextfees.Text = txtfees.Text

            lblarreas.Text = Format(lblarreas.Text, "Standard")
            lblnextfees.Text = Format(lblnextfees.Text, "Standard")

            Dim tot1 As Double = lblnextfees.Text
            Dim tot2 As Double = lblarreas.Text

            Dim mysum As Double = tot1 + tot2

            lblduefees.Text = mysum

            lblduefees.Text = Format(lblduefees.Text, "Standard")

        Next

    End Sub

    Protected Sub GetClassCount()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim lblroll As Label = TryCast(item.FindControl("lblroll"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select count(Class) as roll from cur_class_v1 where Class = @Class"}
                'insert product
                cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = ddlclass.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    lblroll.Text = dr.Item("roll")

                End If

                cnn.Close()

            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetClassPosition()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim lbllearners As Label = TryCast(item.FindControl("lbllearners"), Label)
                Dim lblposition As Label = TryCast(item.FindControl("lblposition"), Label)
                Dim lbltotalmarks As Label = TryCast(item.FindControl("lbltotalmarks"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select rank_str,final_score_100 from exams_position_final_v where student_name = @student_name"}
                'insert product
                cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = lbllearners.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    lblposition.Text = dr.Item("rank_str")
                    lbltotalmarks.Text = dr.Item("final_score_100")

                End If

                lbltotalmarks.Text = Format(lbltotalmarks.Text, "Standard")

                cnn.Close()

            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetMyAcademicInfo()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select aca_year,aca_term,sch_days from academic_calendar_t where aca_status = @aca_status"}
            'insert product
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblmyacayear.Text = dr.Item("aca_year")
                lblmyacaterm.Text = dr.Item("aca_term")

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


            For Each item As RepeaterItem In rptReportMain.Items


                Dim lbloutof As Label = TryCast(item.FindControl("lbloutof"), Label)


                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select aca_year,aca_term,sch_days from academic_calendar_t where aca_status = @aca_status"}
                'insert product
                cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then


                    lbloutof.Text = dr.Item("sch_days")


                End If

                cnn.Close()

            Next


        Catch ex As Exception


        End Try

    End Sub

    Protected Sub ShowStudentPhoto()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim lblid As HiddenField = TryCast(item.FindControl("hfid"), HiddenField)
                Dim imgstudpic As Image = TryCast(item.FindControl("imgstudpic"), Image)

                Dim id As String = lblid.Value
                imgstudpic.Visible = id <> "0"
                If id <> "0" Then
                    Dim bytes As Byte() = DirectCast(GetData(Convert.ToString("SELECT stud_pic FROM student_photos_t WHERE myid =") & id).Rows(0)("stud_pic"), Byte())
                    Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                    imgstudpic.ImageUrl = Convert.ToString("data:image/png;base64,") & base64String
                End If

            Next

        Catch ex As Exception


        End Try


    End Sub

    Protected Sub CompInfo()

        Try
            Dim conString As New SqlConnection(sCon)

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select com_name,street,city,country,phone,email,website from company_t"), .Connection = conString}

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

                For Each item As RepeaterItem In rptReportMain.Items

                    Dim lblcomp As Label = TryCast(item.FindControl("lblcompname"), Label)
                    Dim lbladd As Label = TryCast(item.FindControl("lbladress"), Label)
                    Dim lblphone As Label = TryCast(item.FindControl("lblphone"), Label)
                    Dim lblonline As Label = TryCast(item.FindControl("lblonline"), Label)

                    lblcomp.Text = Comp
                    lbladd.Text = strt + "," + "" + cty + "-" + "" + cunt
                    lblphone.Text = WorkFon
                    lblonline.Text = email + "," + "" + web


                Next

                dr.Close()

            End If

        Catch ex As Exception

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
                    ddlclass.DataSource = ds
                    ddlclass.DataTextField = "ClassName"
                    ddlclass.DataValueField = "ClassName"
                    ddlclass.DataBind()
                    ddlclass.Items.Insert(0, "")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetTerms()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("select * from academic_calendar_t group by aca_term")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "academic_calendar_t")

                    ' BIND DATABASE TO SELECT.
                    ddlacaterm.DataSource = ds
                    ddlacaterm.DataTextField = "aca_term"
                    ddlacaterm.DataValueField = "aca_term"
                    ddlacaterm.DataBind()
                    ddlacaterm.Items.Insert(0, "")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetYears()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("select * from academic_calendar_t group by aca_year")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "academic_calendar_t")

                    ' BIND DATABASE TO SELECT.
                    ddlacayear.DataSource = ds
                    ddlacayear.DataTextField = "aca_year"
                    ddlacayear.DataValueField = "aca_year"
                    ddlacayear.DataBind()
                    ddlacayear.Items.Insert(0, "")

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

        For Each item As RepeaterItem In rptReportMain.Items

            Dim lblname As Label = TryCast(item.FindControl("lbllearners"), Label)
            Dim lblattendace As Label = TryCast(item.FindControl("lblattendace"), Label)

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "SELECT att_staus, COUNT(student_name) AS Att_count FROM  attendance_v1 WHERE student_name = @student_name and att_staus = 'P' and aca_term = @aca_term and aca_year = @aca_year group by att_staus"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = lblname.Text
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = ddlacayear.Text
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = ddlacaterm.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblattendace.Text = dr.Item("Att_count")

            End If

            cnn.Close()

        Next


    End Sub

    Protected Sub GetStudDebt()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim lblname As Label = TryCast(item.FindControl("lbllearners"), Label)
                Dim lblarreas As Label = TryCast(item.FindControl("lblarreas"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetMyDebt"}
                'insert product
                cmd.Parameters.Add("@students", SqlDbType.VarChar).Value = lblname.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    lblarreas.Text = dr.Item("balance")

                End If

                cnn.Close()

                Dim lblclass As Label = TryCast(item.FindControl("lblclass"), Label)
                Dim lblclassteacher As Label = TryCast(item.FindControl("lblclassteacher"), Label)
                Dim lblvacation As Label = TryCast(item.FindControl("lblvacation"), Label)
                Dim lblnextterm As Label = TryCast(item.FindControl("lblnextterm"), Label)
                Dim lblnextfees As Label = TryCast(item.FindControl("lblnextfees"), Label)
                Dim lblduefees As Label = TryCast(item.FindControl("lblduefees"), Label)

                lblclass.Text = ddlclass.Text
                lblvacation.Text = txtvacadate.Text
                lblnextterm.Text = txtreopen.Text
                lblnextfees.Text = txtfees.Text

                lblarreas.Text = Format(lblarreas.Text, "Standard")
                lblnextfees.Text = Format(lblnextfees.Text, "Standard")

                Dim tot1 As Double = lblnextfees.Text
                Dim tot2 As Double = lblarreas.Text

                Dim mysum As Double = tot1 + tot2

                lblduefees.Text = mysum

                lblduefees.Text = Format(lblduefees.Text, "Standard")

            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetStudFees()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from fees_bills_v where [Class Name] = @ClassName"}
            'insert product
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = ddlclass.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfees.Text = dr.Item("Tuition Fee")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnprocess_Click(sender As Object, e As EventArgs) Handles btnprocess.Click
        GetReports()
    End Sub
End Class