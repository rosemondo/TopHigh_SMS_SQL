Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Income_Tax_Entry
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Public Class income_tax_list_t
        Public Property id As Integer
        Public Property entry_name As String
        Public Property lower_lim_val As Double
        Public Property upper_lim_val As Double
        Public Property inc_tax_rate As Double
        Public Property created As DateTime()
        Public Property lastUpdated As DateTime()

    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            loadData()

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


    Protected Sub loadData()

        dvgssnit.DataSource = GetSsnitDeduct()
        dvgssnit.DataBind()

    End Sub

    Private Function GetSsnitDeduct() As List(Of income_tax_list_t)

        Dim constring As String = sCon
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("select * from income_tax_list_t", con)
                Dim inctax As New List(Of income_tax_list_t)
                cmd.CommandType = CommandType.Text
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        inctax.Add(New income_tax_list_t With {
                                      .id = sdr("id").ToString(),
                                      .entry_name = sdr("entry_name").ToString(),
                                      .lower_lim_val = Convert.ToDouble(sdr("lower_lim_val")),
                                      .upper_lim_val = Convert.ToDouble(sdr("upper_lim_val")),
                                      .inc_tax_rate = Convert.ToDouble(sdr("inc_tax_rate"))
                                    })
                    End While
                End Using
                con.Close()
                Return inctax
            End Using
        End Using
    End Function

    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Me.loadData()
        dvgssnit.PageIndex = e.NewPageIndex
        dvgssnit.DataBind()
    End Sub

    Protected Sub Edit(ByVal sender As Object, ByVal e As EventArgs)

        Dim row As GridViewRow = (TryCast((TryCast(sender, ImageButton)).NamingContainer, GridViewRow))

        txtid.Text = row.Cells(0).Text

        Dim connetionString As String = sCon
        Dim cnn As SqlConnection = New SqlConnection(connetionString)
        Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from income_tax_list_t where id = @id"}
        'insert product
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = txtid.Text
        cmd.Connection = cnn
        cnn.Open()

        Dim dr As SqlDataReader = cmd.ExecuteReader()
        ' If the record can be queried, it means passing verification, then open another form.   
        If (dr.Read() = True) Then

            txtentname.Text = dr.Item("entry_name")
            txtlowlimval.Text = dr.Item("lower_lim_val")
            txtupplimval.Text = dr.Item("upper_lim_val")
            txtrate.Text = dr.Item("inc_tax_rate")

        End If

        cnn.Close()

        popup.Show()

    End Sub

    Protected Sub Delete(ByVal sender As Object, ByVal e As EventArgs)

        Try

            Dim row As GridViewRow = (TryCast((TryCast(sender, ImageButton)).NamingContainer, GridViewRow))
            Dim studentID As String = row.Cells(0).Text

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from income_tax_list_t where id = @id"}
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = studentID

            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        loadData()

    End Sub


    Protected Sub Add(ByVal sender As Object, ByVal e As EventArgs)
        txtid.ReadOnly = False
        txtid.Text = String.Empty
        txtentname.Text = String.Empty
        txtlowlimval.Text = 0
        txtupplimval.Text = 0
        txtrate.Text = 0
        popup.Show()
    End Sub

    Protected Sub Save(ByVal sender As Object, ByVal e As EventArgs)

        If txtid.Text > "" Then

            Update()

        Else

            Add()

        End If

    End Sub

    Private Sub Add()

        Using con As New SqlConnection(sCon)
            Dim query As String = "INSERT INTO income_tax_list_t (entry_name,lower_lim_val,upper_lim_val,inc_tax_rate,created,lastUpdated) values(@entry_name,@lower_lim_val,@upper_lim_val,@inc_tax_rate,@created,@lastUpdated)"
            Using cmd As New SqlCommand(query)
                cmd.Connection = con
                cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = txtentname.Text
                cmd.Parameters.Add("@lower_lim_val", SqlDbType.Float).Value = txtlowlimval.Text
                cmd.Parameters.Add("@upper_lim_val", SqlDbType.Float).Value = txtupplimval.Text
                cmd.Parameters.Add("@inc_tax_rate", SqlDbType.Float).Value = txtrate.Text
                cmd.Parameters.Add("@created", SqlDbType.Date).Value = DateTime.Now.Date
                cmd.Parameters.Add("@lastUpdated", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        loadData()

    End Sub

    Private Sub Update()

        Using con As New SqlConnection(sCon)
            Dim query As String = "Update income_tax_list_t Set entry_name = @entry_name,lower_lim_val = @lower_lim_val, upper_lim_val = @upper_lim_val, inc_tax_rate = @inc_tax_rate,lastUpdated = @lastUpdated where id = @id"
            Using cmd As New SqlCommand(query)
                cmd.Connection = con
                cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = txtentname.Text
                cmd.Parameters.Add("@lower_lim_val", SqlDbType.Float).Value = txtlowlimval.Text
                cmd.Parameters.Add("@upper_lim_val", SqlDbType.Float).Value = txtupplimval.Text
                cmd.Parameters.Add("@inc_tax_rate", SqlDbType.Float).Value = txtrate.Text
                cmd.Parameters.Add("@lastUpdated", SqlDbType.Date).Value = DateTime.Now.Date
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = txtid.Text
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        loadData()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadData()
    End Sub
End Class