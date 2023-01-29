Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Journal_Entries
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
            GetAccounts()
            BindJournals()
            txttimer.Text = TimeString

            If txtjvcode.Text = String.Empty Then

                OnDistinctNumber()

            End If

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
            txtjvcode.Text = number
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

    Protected Sub GetAccounts()

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
                    ddldebit.DataSource = ds
                    ddldebit.DataTextField = "coa_name"
                    ddldebit.DataValueField = "coa_name"
                    ddldebit.DataBind()
                    ddldebit.Items.Insert(0, New ListItem("", "0"))

                    ddlcredit.DataSource = ds
                    ddlcredit.DataTextField = "coa_name"
                    ddlcredit.DataValueField = "coa_name"
                    ddlcredit.DataBind()
                    ddlcredit.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub BindJournals()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Exp_Journal", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@jv_code", SqlDbType.VarChar).Value = txtjvcode.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        journalDB.DataSource = dt
                        journalDB.DataBind()
                    End Using
                End Using
            End Using


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub Insert_jou_ent_debit()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals_ent"}
            cmd.Parameters.Add("@jv_code", SqlDbType.VarChar).Value = txtjvcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@jv_account", SqlDbType.VarChar).Value = ddldebit.Text
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = txtdescription.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtamount.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_jou_ent_Credit()

    End Sub

    Protected Sub Insert_jou_ent_Credit()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals_ent"}
            cmd.Parameters.Add("@jv_code", SqlDbType.VarChar).Value = txtjvcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@jv_account", SqlDbType.VarChar).Value = ddlcredit.Text
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = txtdescription.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtamount.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        BindJournals()

        ddldebit.ClearSelection()
        ddlcredit.ClearSelection()
        txtdescription.Text = String.Empty
        txtamount.Text = "0"

    End Sub

    Private Sub txtadd_Click(sender As Object, e As EventArgs) Handles txtadd.Click

        If ddldebit.Text = "" = True Then

            Response.Write("<script type=""text/javascript"">alert(""Please Debit Account."");</script")

            Exit Sub

        End If

        If ddlcredit.Text = "" = True Then

            Response.Write("<script type=""text/javascript"">alert(""Please Credit Account."");</script")

            Exit Sub

        End If

        If txtamount.Text = "0" Or "0.00" = True Then

            Response.Write("<script type=""text/javascript"">alert(""Please Amount can not be zero."");</script")

            Exit Sub

        End If

        Insert_jou_ent_debit()

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Update_previous_education()
    End Sub

    Protected Sub Update_previous_education()

        Try

            For Each item As RepeaterItem In journalDB.Items
                Dim mydate As Label = TryCast(item.FindControl("lbldate"), Label)
                Dim myacc As Label = TryCast(item.FindControl("lblaccount"), Label)
                Dim mydebit As Label = TryCast(item.FindControl("lbldebit"), Label)
                Dim mycredit As Label = TryCast(item.FindControl("lblcredit"), Label)

                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("Insert_journals", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtjvcode.Text
                        cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = mydate.Text
                        cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = myacc.Text
                        cmd.Parameters.Add("@debit", SqlDbType.Float).Value = mydebit.Text
                        cmd.Parameters.Add("@credit", SqlDbType.Float).Value = mycredit.Text
                        cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
                        cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try



        txtjvcode.Text = String.Empty

        If txtjvcode.Text = String.Empty Then

            OnDistinctNumber()

        End If

        BindJournals()

    End Sub

End Class