Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Company
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Not IsPostBack Then

                GetPagefont()
                GetLocations()
                GetCountries()
                LoadCompany()

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


    Protected Sub GetLocations()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetLocations")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetLocations")

                    ' BIND DATABASE TO SELECT.
                    dpllocation.DataSource = ds
                    dpllocation.DataTextField = "location"
                    dpllocation.DataValueField = "location"
                    dpllocation.DataBind()
                    dpllocation.Items.Insert(0, New ListItem("", "0"))

                    ' SET THE DEFAULT VALUE.
                    dpllocation.Items.Insert(0, "- SELECT -")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetCountries()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetCountries")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetCountries")

                    ' BIND DATABASE TO SELECT.
                    dplcountry.DataSource = ds
                    dplcountry.DataTextField = "country"
                    dplcountry.DataValueField = "country"
                    dplcountry.DataBind()

                    ' SET THE DEFAULT VALUE.
                    dplcountry.Items.Insert(0, "- SELECT -")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub updateimage()

        Try

            Dim myid As String = txtid.Value
            Dim filename As String = Path.GetFileName(flupImage.PostedFile.FileName)
            Dim contentType As String = flupImage.PostedFile.ContentType
            Using fs As Stream = flupImage.PostedFile.InputStream
                Using br As New BinaryReader(fs)
                    Dim bytes As Byte() = br.ReadBytes(DirectCast(fs.Length, Long))

                    Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updatecompany_logo"}
                    cmd.Parameters.AddWithValue("@comp_id", myid)
                    cmd.Parameters.AddWithValue("@comp_logo", bytes)
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()

                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub UploadFile(sender As Object, e As EventArgs) Handles btnupload.Click

        updateimage()

    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        If txtid.Value = String.Empty Then

            InsertCompany()

        Else

            UpdateCompany()

        End If

    End Sub

    Protected Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        Try

            txtschname.Text = String.Empty
            txtstreet.Text = String.Empty
            txtcity.Text = String.Empty
            txtzip.Text = String.Empty
            txtmobile.Text = String.Empty
            txtemail.Text = String.Empty
            txtweb.Text = String.Empty

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub InsertCompany()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insertcompany"}
            cmd.Parameters.Add("@com_name", SqlDbType.VarChar).Value = txtschname.Text
            cmd.Parameters.Add("@street", SqlDbType.VarChar).Value = txtstreet.Text
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = txtcity.Text
            cmd.Parameters.Add("@zip_code", SqlDbType.VarChar).Value = txtzip.Text
            cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = dplcountry.Text
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtmobile.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtemail.Text
            cmd.Parameters.Add("@website", SqlDbType.VarChar).Value = txtweb.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = dpllocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub UpdateCompany()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updatecompany"}
            cmd.Parameters.Add("@com_name", SqlDbType.VarChar).Value = txtschname.Text
            cmd.Parameters.Add("@street", SqlDbType.VarChar).Value = txtstreet.Text
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = txtcity.Text
            cmd.Parameters.Add("@zip_code", SqlDbType.VarChar).Value = txtzip.Text
            cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = dplcountry.Text
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtmobile.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtemail.Text
            cmd.Parameters.Add("@website", SqlDbType.VarChar).Value = txtweb.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = dpllocation.Text
            cmd.Parameters.Add("@comp_id", SqlDbType.Int).Value = txtid.Value
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub LoadCompany()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM company_t"), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtid.Value = dr.Item("comp_id")
                txtschname.Text = dr.Item("com_name")
                txtstreet.Text = dr.Item("street")
                txtcity.Text = dr.Item("city")
                txtzip.Text = dr.Item("zip_code")
                dplcountry.Text = dr.Item("country")
                txtmobile.Text = dr.Item("phone")
                txtemail.Text = dr.Item("email")
                txtweb.Text = dr.Item("website")
                dpllocation.Text = dr.Item("location")

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
            Dim id As String = txtid.Value
            ImgPrv.Visible = id <> "0"
            If id <> "0" Then
                Dim bytes As Byte() = DirectCast(GetData(Convert.ToString("SELECT comp_logo FROM company_t WHERE comp_id =") & id).Rows(0)("comp_logo"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                ImgPrv.ImageUrl = Convert.ToString("data:image/png;base64,") & base64String
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