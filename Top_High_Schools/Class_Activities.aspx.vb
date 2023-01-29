Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Class_Activities
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            txtdate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            GetClass()
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

    Private Sub BindGrid()
        Dim constr As String = sCon
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select * from class_activity_t where my_type = 'Class & Home Work'"
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
                cmd.CommandText = "select * from class_activity_t where my_type = 'Class Assessment'"
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
                cmd.CommandText = "select * from class_activity_t where my_type = 'Terminal Reports'"
                cmd.Connection = con
                con.Open()
                dgvreport.DataSource = cmd.ExecuteReader()
                dgvreport.DataBind()
                con.Close()
            End Using
        End Using
    End Sub

    Protected Sub Upload(sender As Object, e As EventArgs)

        Dim fileName As String = Path.GetFileName(fuFileUploader.PostedFile.FileName)
        Dim fileExtension As String = Path.GetExtension(fuFileUploader.PostedFile.FileName)
        'first check if "uploads" folder exist or not, if not create it'
        Dim fileSavePath As String = Server.MapPath("Class_Activities_Files")
        If Not Directory.Exists(fileSavePath) Then
            Directory.CreateDirectory(fileSavePath)
        End If
        'after checking or creating folder it's time to save the file'
        fileSavePath = fileSavePath & "//" & fileName
        fuFileUploader.PostedFile.SaveAs(fileSavePath)
        Dim contentType As String = fuFileUploader.PostedFile.ContentType
        Dim file As HttpPostedFile = fuFileUploader.PostedFile
        Dim document As Byte() = New Byte(file.ContentLength - 1) {}
        file.InputStream.Read(document, 0, file.ContentLength)
        Using fs As Stream = fuFileUploader.PostedFile.InputStream
            Using br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(DirectCast(fs.Length, Long))
                Dim constr As String = sCon
                Using con As New SqlConnection(constr)
                    Dim query As String = "insert into class_activity_t (cw_date, item_name, content_type, item_data, class_type, file_path,my_type) values (@cw_date, @item_name, @content_type, @item_data, @class_type, @file_path,@my_type)"
                    Using cmd As New SqlCommand(query)
                        cmd.Connection = con
                        cmd.Parameters.Add("@cw_date", SqlDbType.Date).Value = txtdate.Text
                        cmd.Parameters.Add("@item_name", SqlDbType.VarChar).Value = fileName
                        cmd.Parameters.Add("@content_type", SqlDbType.VarChar).Value = contentType
                        cmd.Parameters.Add("@item_data", SqlDbType.VarBinary).Value = bytes
                        cmd.Parameters.Add("@class_type", SqlDbType.VarChar).Value = ddlClass.Text
                        cmd.Parameters.Add("@file_path", SqlDbType.VarChar).Value = "Class_Activities_Files/" + fileName
                        cmd.Parameters.Add("@my_type", SqlDbType.VarChar).Value = ddltype.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
            End Using
        End Using

        BindGrid()
        BindGridAssess()
        BindGridTermRep()

    End Sub

    Protected Sub GetDelete(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'Reference the Repeater Item using Button.
            Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

            'Reference the Label and TextBox.
            Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

            txtID.Text = message

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from class_activity_t where id = @id"}
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = txtID.Text

            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        BindGrid()
        BindGridAssess()
        BindGridTermRep()

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)

        Dim rowIndex As Integer = (CType(((TryCast(sender, Control))).NamingContainer, GridViewRow)).RowIndex
        Dim filelocation As String = dgvhw.Rows(rowIndex).Cells(5).Text
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

    Protected Sub dgvhw_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgvhw.RowDeleting
        Try
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim empId As Integer = Convert.ToInt32(dgvhw.DataKeys(e.RowIndex).Value)
            Dim cmd As New SqlCommand("delete from class_activity_t where id= @id", cnn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = empId
            cmd.CommandType = CommandType.Text
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()
            dgvhw.EditIndex = -1
            BindGrid()
            BindGridAssess()
            BindGridTermRep()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), Guid.NewGuid().ToString(), "alert('" & ex.Message.ToString() & "');", True)
        Finally

        End Try
    End Sub

    Protected Sub dgvassessment_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgvassessment.RowDeleting
        Try
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim empId As Integer = Convert.ToInt32(dgvassessment.DataKeys(e.RowIndex).Value)
            Dim cmd As New SqlCommand("delete from class_activity_t where id= @id", cnn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = empId
            cmd.CommandType = CommandType.Text
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()
            dgvassessment.EditIndex = -1
            BindGrid()
            BindGridAssess()
            BindGridTermRep()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), Guid.NewGuid().ToString(), "alert('" & ex.Message.ToString() & "');", True)
        Finally

        End Try
    End Sub

    Protected Sub dgvreport_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgvreport.RowDeleting
        Try
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim empId As Integer = Convert.ToInt32(dgvreport.DataKeys(e.RowIndex).Value)
            Dim cmd As New SqlCommand("delete from class_activity_t where id= @id", cnn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = empId
            cmd.CommandType = CommandType.Text
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()
            dgvreport.EditIndex = -1
            BindGrid()
            BindGridAssess()
            BindGridTermRep()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), Guid.NewGuid().ToString(), "alert('" & ex.Message.ToString() & "');", True)
        Finally

        End Try
    End Sub

End Class