Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Deduction_Setup
    Inherits System.Web.UI.Page


    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Public Class ssnit_deduction_t
        Public Property id As Integer
        Public Property dedu_items As String
        Public Property ssnit_rate As Double
        Public Property created As Byte()
        Public Property lastUpdated As Byte()

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

    Private Function GetSsnitDeduct() As List(Of ssnit_deduction_t)

        Dim constring As String = sCon
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("select * from ssnit_deduction_t", con)
                Dim ssnitllist As New List(Of ssnit_deduction_t)
                cmd.CommandType = CommandType.Text
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        ssnitllist.Add(New ssnit_deduction_t With {
                                      .id = sdr("id").ToString(),
                                      .dedu_items = sdr("dedu_items").ToString(),
                                      .ssnit_rate = Convert.ToDouble(sdr("ssnit_rate"))
                                    })
                    End While
                End Using
                con.Close()
                Return ssnitllist
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
        Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from ssnit_deduction_t where id = @id"}
        'insert product
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = txtid.Text
        cmd.Connection = cnn
        cnn.Open()

        Dim dr As SqlDataReader = cmd.ExecuteReader()
        ' If the record can be queried, it means passing verification, then open another form.   
        If (dr.Read() = True) Then

            txtitems.Text = dr.Item("dedu_items")
            txtrate.Text = dr.Item("ssnit_rate")

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
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from ssnit_deduction_t where id = @id"}
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
        txtitems.Text = String.Empty
        txtrate.Text = String.Empty
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
            Dim query As String = "INSERT INTO ssnit_deduction_t (dedu_items,ssnit_rate,created,lastUpdated) values(@dedu_items,@ssnit_rate,@created,@lastUpdated)"
            Using cmd As New SqlCommand(query)
                cmd.Connection = con
                cmd.Parameters.Add("@dedu_items", SqlDbType.VarChar).Value = txtitems.Text
                cmd.Parameters.Add("@ssnit_rate", SqlDbType.Float).Value = txtrate.Text
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
            Dim query As String = "Update ssnit_deduction_t Set dedu_items = @dedu_items,ssnit_rate = @ssnit_rate where id = @id"
            Using cmd As New SqlCommand(query)
                cmd.Connection = con
                cmd.Parameters.Add("@dedu_items", SqlDbType.VarChar).Value = txtitems.Text
                cmd.Parameters.Add("@ssnit_rate", SqlDbType.Float).Value = txtrate.Text
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = txtid.Text
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        loadData()

    End Sub

End Class