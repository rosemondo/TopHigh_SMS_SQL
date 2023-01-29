Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class PayBills
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Text = IpassAstringfrompage2

            GetPagefont()
            GetSuppliers()

            GetCurAsset()

            GetReceAcc()
            txttimer.Text = TimeString

            ddlSuppliers.Text = " - Select -"
            ddlpaymeth.Text = " - Select -"
            ddlstatus.Text = " - Select -"
            txtbaldue.Text = "0.00"
            txtpaid.Text = "0.00"
            txtdescription.Text = String.Empty
            txtstudid.Text = String.Empty
            txtclassid.Text = String.Empty
            txtclassid.Text = String.Empty
            txtstudid.Text = String.Empty
            txttimer.Text = TimeString
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

    Protected Sub GetSuppliers()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetSuppliers")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetSuppliers")

                    ' BIND DATABASE TO SELECT.
                    ddlSuppliers.DataSource = ds
                    ddlSuppliers.DataTextField = "cust"
                    ddlSuppliers.DataValueField = "cust"
                    ddlSuppliers.DataBind()
                    ddlSuppliers.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetCurAsset()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetCurAsset")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetCurAsset")

                    ' BIND DATABASE TO SELECT.
                    ddlpaymeth.DataSource = ds
                    ddlpaymeth.DataTextField = "coa_name"
                    ddlpaymeth.DataValueField = "coa_name"
                    ddlpaymeth.DataBind()
                    ddlpaymeth.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetCust_Code()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetCust_Code"}
            'insert product
            cmd.Parameters.Add("@cust", SqlDbType.VarChar).Value = ddlSuppliers.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtclassid.Text = dr.Item("cust_code")


            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetReceBalDueData()

    End Sub

    Protected Sub GetReceBalDueData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetExpBalDueData"}
            'insert product
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtbaldue.Text = dr.Item("Amount")
                txtbaldue.Text = Format(txtbaldue.Text, "Standard")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetReceAcc()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetTransAcc"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "ap"
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

    Protected Sub Insert_Credit_Statement()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert_debit_statement_t"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = txtdescription.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtpaid.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@cust_id", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
            cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode.Text
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

    Protected Sub Insert_JV_Cash()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = ddlpaymeth.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtpaid.Text
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


    End Sub

    Protected Sub Insert_JV_Recevables()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtReceAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtpaid.Text
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


    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        If ddlSuppliers.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Supplier."");</script")
            Exit Sub
        End If

        If txtpaid.Text = "0" Or "0.00" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please Amount paid can not be zero or empty."");</script")
            Exit Sub
        End If

        If ddlstatus.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select payment status."");</script")
            Exit Sub
        End If

        If ddlpaymeth.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select payment method."");</script")
            Exit Sub
        End If

        txttimer.Text = TimeString

        Insert_Credit_Statement()
        Insert_JV_Cash()
        Insert_JV_Recevables()

    End Sub

    Protected Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

    End Sub

    Protected Sub ddlSuppliers_SelectedIndexChanged(sender As Object, e As EventArgs)
        GetCust_Code()
    End Sub

End Class