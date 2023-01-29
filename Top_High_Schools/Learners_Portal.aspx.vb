Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Learners_Portal
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtuser.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Text = IpassAstringfrompage2

            GetPagefont()
            GetBankStatementByAcc()
            GetSearchStudentList()
            GetBasicInfo()
            BindGrid()
            BindGridAssess()
            BindGridTermRep()
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


    Private Sub BindGrid()
        Dim constr As String = sCon
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select * from class_activity_t where class_type = '" & lblclass.Text & "' and my_type = 'Class & Home Work'"
                cmd.Connection = con
                con.Open()
                dgvhw.DataSource = cmd.ExecuteReader()
                dgvhw.DataBind()
                con.Close()
            End Using
        End Using
    End Sub

    Private Sub BindGridAssess()
        Dim constr As String = sCon
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select * from class_activity_t where class_type = '" & lblclass.Text & "' and my_type = 'Class Assessment'"
                cmd.Connection = con
                con.Open()
                dgvassessment.DataSource = cmd.ExecuteReader()
                dgvassessment.DataBind()
                con.Close()
            End Using
        End Using
    End Sub

    Private Sub BindGridTermRep()
        Dim constr As String = sCon
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select * from class_activity_t where class_type = '" & lblclass.Text & "' and my_type = 'Terminal Reports'"
                cmd.Connection = con
                con.Open()
                dgvreport.DataSource = cmd.ExecuteReader()
                dgvreport.DataBind()
                con.Close()
            End Using
        End Using
    End Sub


    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)

        Dim rowIndex As Integer = (CType(((TryCast(sender, Control))).NamingContainer, GridViewRow)).RowIndex
        Dim filelocation As String = dgvhw.Rows(rowIndex).Cells(4).Text
        Dim FilePath As String = Server.MapPath("~/" & filelocation)
        Dim User As WebClient = New WebClient()
        Dim FileBuffer As Byte() = User.DownloadData(FilePath)

        If FileBuffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", FileBuffer.Length.ToString())
            Response.BinaryWrite(FileBuffer)
        End If

    End Sub

    Protected Sub LinkButton_Click(sender As Object, e As EventArgs)

        Dim rowIndex As Integer = (CType(((TryCast(sender, Control))).NamingContainer, GridViewRow)).RowIndex
        Dim filelocation As String = dgvassessment.Rows(rowIndex).Cells(5).Text
        Dim FilePath As String = Server.MapPath("~/" & filelocation)
        Dim User As WebClient = New WebClient()
        Dim FileBuffer As Byte() = User.DownloadData(FilePath)

        If FileBuffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", FileBuffer.Length.ToString())
            Response.BinaryWrite(FileBuffer)
        End If

    End Sub

    Protected Sub LinkButtons_Click(sender As Object, e As EventArgs)

        Dim rowIndex As Integer = (CType(((TryCast(sender, Control))).NamingContainer, GridViewRow)).RowIndex
        Dim filelocation As String = dgvreport.Rows(rowIndex).Cells(5).Text
        Dim FilePath As String = Server.MapPath("~/" & filelocation)
        Dim User As WebClient = New WebClient()
        Dim FileBuffer As Byte() = User.DownloadData(FilePath)

        If FileBuffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", FileBuffer.Length.ToString())
            Response.BinaryWrite(FileBuffer)
        End If

    End Sub


    Protected Sub GetBankStatementByAcc()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("SELECT * FROM credit_statement_v where stud_id = '" & txtlocation.Text & "'", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
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

    Protected Sub GetSearchStudentList()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Select * FROM student_current_details_v where `Contact Number` = '" & Trim(txtuser.Text) & "'", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptprofile.DataSource = dt
                        rptprofile.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetValue(ByVal sender As Object, ByVal e As EventArgs)

        'Reference the Repeater Item using Button.
        Dim item As RepeaterItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, RepeaterItem)

        'Reference the Label and TextBox.
        Dim message As String = (TryCast(item.FindControl("lblmyid"), Label)).Text

        txtlocation.Text = message

        GetBankStatementByAcc()
        GetBasicInfo()
        BindGrid()
        BindGridAssess()
        BindGridTermRep()
    End Sub

    Protected Sub GetBasicInfo()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "Select * FROM student_current_details_v where `Student ID` = '" & Trim(txtlocation.Text) & "'"}
            'cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = txtusers.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblage.Text = dr.Item("Age")
                lblclass.Text = dr.Item("Class Name")
                lblbaldue.Text = dr.Item("Balance Due")
                lblfather.Text = dr.Item("Fathers Name")
                lblmother.Text = dr.Item("Mothers Name")
                lbllocation.Text = dr.Item("parent_address")
                lblcontfa.Text = dr.Item("Contact Number")

            End If

            cnn.Close()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub Insert_mails(sender As Object, e As EventArgs)

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert_mails"}
            cmd.Parameters.Add("@subjects", SqlDbType.VarChar).Value = txtsubject.Text.Trim()
            cmd.Parameters.Add("@parents", SqlDbType.VarChar).Value = txtname.Text.Trim()
            cmd.Parameters.Add("@emails", SqlDbType.VarChar).Value = txtemail.Text.Trim()
            cmd.Parameters.Add("@messages", SqlDbType.VarChar).Value = txtmessage.Text.Trim()
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        BindGrid()
        BindGridAssess()
        BindGridTermRep()

        Response.Redirect("Learners_Portal.aspx")

    End Sub


End Class