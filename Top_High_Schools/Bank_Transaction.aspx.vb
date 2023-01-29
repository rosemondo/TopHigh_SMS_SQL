Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Bank_Transaction
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Text = IpassAstringfrompage2

            txttimer.Text = TimeString

            GetPagefont()
            GetBankList()
            GetCode()
            GetEquAcc()

            OnDistinctNumber()

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


    Protected Sub OnDistinctNumber()
        Dim result As List(Of String) = New List(Of String)()
        If Session("Numbers") IsNot Nothing Then
            result = CType(Session("Numbers"), List(Of String))
        End If
        Dim number As String = GetAutoNumber()
        If Not result.Contains(number) Then
            result.Add(number)
            Session("Numbers") = result
            txtlinkcode.Text = number
        End If
    End Sub

    Private Function GetAutoNumber() As String
        Dim numbers As String = "1234567890"
        Dim characters As String = numbers
        Dim length As Integer = 7
        Dim id As String = String.Empty
        For i As Integer = 0 To length - 1
            Dim character As String = String.Empty
            Do
                Dim index As Integer = New Random().Next(0, characters.Length)
                character = characters.ToCharArray()(index).ToString()
            Loop While id.IndexOf(character) <> -1
            id += character
        Next

        Return id
    End Function


    Protected Sub GetBankList()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("SELECT * FROM bank_t", con)

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

    Protected Sub GetCode()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetAcCode"}
            'insert product
            cmd.Parameters.Add("@coa_sub_group", SqlDbType.VarChar).Value = "ASS"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtcode.Text = dr.Item("code")


            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub

    Protected Sub GetEquAcc()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetTransAcc"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "cp"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtReceAcc.Text = dr.Item("coa_name")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub Insert_Open_Bal()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank_Obal"}
            cmd.Parameters.Add("@ob_date", SqlDbType.Date).Value = txtbkdate.Text
            cmd.Parameters.Add("@account", SqlDbType.VarChar).Value = txtacname.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = txtnumber.Text
            cmd.Parameters.Add("@openbal", SqlDbType.Float).Value = txtbkamt.Text
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = txtbank.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_Setup()

    End Sub

    Protected Sub Insert_Setup()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = txtbkdate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = txtacname.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = txtnumber.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = txtdescription.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtbkamt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = txtbank.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_ChartofAcc()

    End Sub

    Protected Sub Insert_ChartofAcc()

        Try

            Dim mycode As Double = txtcode.Text
            Dim mynum As Double = 2
            Dim myadd As Double = mycode + mynum

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertChart"}
            cmd.Parameters.Add("@coa_code", SqlDbType.VarChar).Value = myadd
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtacname.Text
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = "CURRENT ASSETS"
            cmd.Parameters.Add("@coa_sub_group", SqlDbType.VarChar).Value = "ASS"
            cmd.Parameters.Add("@coa_cate", SqlDbType.VarChar).Value = "BS"
            cmd.Parameters.Add("@coa_cf", SqlDbType.VarChar).Value = "CABNE"
            cmd.Parameters.Add("@coa_ocbfy", SqlDbType.VarChar).Value = ""
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = ""
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_JV_Setup_Debit()

    End Sub

    Protected Sub Insert_JV_Setup_Debit()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtbkdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtacname.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtbkamt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_JV_Setup_Credit()

    End Sub

    Protected Sub Insert_JV_Setup_Credit()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtbkdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtReceAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtbkamt.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        txtdescription.Text = String.Empty
        txtnumber.Text = String.Empty
        txtacname.Text = String.Empty
        txtbkamt.Text = "0"
        txtbank.Text = String.Empty

        Response.Redirect("Bank_Transaction.aspx")

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Insert_Open_Bal()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        txtdescription.Text = String.Empty
        txtnumber.Text = String.Empty
        txtacname.Text = String.Empty
        txtbkamt.Text = "0"
        txtbank.Text = String.Empty

    End Sub


End Class