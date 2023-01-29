Imports System.Web.Script.Serialization
Imports System.Data.SqlClient
Imports System.Web.Services

Public Class Withdrawal
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Value = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Value = IpassAstringfrompage2

            txttimer.Value = TimeString

            GetPagefont()
            GetBanks()
            GetAccounts()
            GetGeneAccounts()
            GetEquAcc()

            OnDistinctNumber()

        End If

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


    Protected Sub OnDistinctNumber()
        Dim result As List(Of String) = New List(Of String)()
        If Session("Numbers") IsNot Nothing Then
            result = CType(Session("Numbers"), List(Of String))
        End If
        Dim number As String = GetAutoNumber()
        If Not result.Contains(number) Then
            result.Add(number)
            Session("Numbers") = result
            txtlinkcode.Value = number
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

                txtReceAcc.Value = dr.Item("coa_name")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetBanks()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetBankName")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetBankName")

                    ' BIND DATABASE TO SELECT.
                    dplbankname.DataSource = ds
                    dplbankname.DataTextField = "bank"
                    dplbankname.DataValueField = "bank"
                    dplbankname.DataBind()

                    ' SET THE DEFAULT VALUE.
                    dplbankname.Items.Insert(0, "")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetAccounts()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetAcName")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetAcName")

                    ' BIND DATABASE TO SELECT.
                    dplacname.DataSource = ds
                    dplacname.DataTextField = "accname"
                    dplacname.DataValueField = "accname"
                    dplacname.DataBind()

                    ' SET THE DEFAULT VALUE.
                    dplacname.Items.Insert(0, "")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetGeneAccounts()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetCOAList")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetCOAList")

                    ' BIND DATABASE TO SELECT.
                    ddlgen.DataSource = ds
                    ddlgen.DataTextField = "coa_name"
                    ddlgen.DataValueField = "coa_name"
                    ddlgen.DataBind()

                    ddlgen.Items.Insert(0, "")

                    cmd.Connection = con : con.Close()


                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    <WebMethod()>
    Public Shared Function insert_deposit(ByVal txtdepdate As Date, ByVal dplacname As String, ByVal txtdepamt As Double, ByVal txtacnum As String, ByVal txtdepdes As String, ByVal dplbankname As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = txtdepdate
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = dplacname
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = txtacnum
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = txtdepdes
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtdepamt
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = dplbankname
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return True
    End Function


    <WebMethod()>
    Public Shared Function Insert_JV_Depo_Debit(ByVal txtdepdate As Date, ByVal dplacname As String, ByVal txtdepamt As Double, ByVal txtlinkcode As String, ByVal txttimer As String, ByVal txtusers As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdepdate
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = dplacname
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtdepamt
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return True
    End Function


    <WebMethod()>
    Public Shared Function Insert_JV_Depo_Credit(ByVal txtdepdate As Date, ByVal ddlgen As String, ByVal txtdepamt As Double, ByVal txtlinkcode As String, ByVal txttimer As String, ByVal txtusers As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdepdate
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = ddlgen
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtdepamt
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return True
    End Function

    <WebMethod>
    Public Shared Function GetAcnumber(ByVal acname As String) As Object

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetAcNumber"}
            'insert product
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = acname
            cmd.Connection = cnn
            cnn.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If sdr.Read() Then
                Return New With {
                    .AccNumber = sdr("accnum")
                }
            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return Nothing

    End Function

End Class
