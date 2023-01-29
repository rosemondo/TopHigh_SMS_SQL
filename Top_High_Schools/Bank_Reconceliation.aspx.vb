Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Bank_Reconceliation
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
            GetBanks()
            GetAccounts()
            GetGeneAccounts()

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
                    ddlbank.DataSource = ds
                    ddlbank.DataTextField = "bank"
                    ddlbank.DataValueField = "bank"
                    ddlbank.DataBind()
                    ddlbank.Items.Insert(0, New ListItem("", "0"))

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
            Using cmd As SqlCommand = New SqlCommand("select * from bank_t where bank = '" & ddlbank.Text & "' group by accname")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "bank_t")

                    ' BIND DATABASE TO SELECT.
                    ddlaccname.DataSource = ds
                    ddlaccname.DataTextField = "accname"
                    ddlaccname.DataValueField = "accname"
                    ddlaccname.DataBind()
                    ddlaccname.Items.Insert(0, New ListItem("", "0"))

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
                    ddlexpinc.DataSource = ds
                    ddlexpinc.DataTextField = "coa_name"
                    ddlexpinc.DataValueField = "coa_name"
                    ddlexpinc.DataBind()
                    ddlexpinc.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()


                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetAcNumber()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetAcNumber"}
            'insert product
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = ddlaccname.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtaccnum.Text = dr.Item("accnum")


            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetAcBalance()

    End Sub

    Protected Sub GetAcBalance()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetAcBalance"}
            'insert product
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = ddlaccname.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = txtaccnum.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtcurbal.Text = dr.Item("balance")


            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetOpenBalance()

    End Sub

    Protected Sub GetOpenBalance()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetOpenBalance"}
            'insert product
            cmd.Parameters.Add("@account", SqlDbType.VarChar).Value = ddlaccname.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = txtaccnum.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtObal.Text = dr.Item("openbal")


            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub

    Protected Sub GetCheck()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetCheckMe"}
            'insert product
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = ddlexpinc.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtcheck.Text = dr.Item("coa_sub_group")


            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub


    Private Sub ddlbank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlbank.SelectedIndexChanged
        GetAccounts()
    End Sub

    Private Sub ddlbank_TextChanged(sender As Object, e As EventArgs) Handles ddlbank.TextChanged
        GetAccounts()
    End Sub

    Private Sub ddlaccname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlaccname.SelectedIndexChanged
        GetAcNumber()
    End Sub

    Private Sub ddlaccname_TextChanged(sender As Object, e As EventArgs) Handles ddlaccname.TextChanged
        GetAcNumber()
    End Sub

    Private Sub ddlexpinc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlexpinc.SelectedIndexChanged
        GetCheck()
    End Sub

    Private Sub ddlexpinc_TextChanged(sender As Object, e As EventArgs) Handles ddlexpinc.TextChanged
        GetCheck()
    End Sub
End Class