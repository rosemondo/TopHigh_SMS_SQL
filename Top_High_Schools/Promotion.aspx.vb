Imports System.Web.Script.Serialization
Imports DevExpress.Web
Imports System.Data.SqlClient

Public Class Promotion
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Text = IpassAstringfrompage2

            txtdate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            BindRepeater()
            GetClass()
            GetAcaTerm()
            GetAcaYear()
            GetSchAcc()
            GetReceAcc()

            txttimer.Text = TimeString

            OnDistinctNumber()

        End If

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


    Private Sub BindRepeater()

        Try

            Dim conString As String = sCon
            Dim query As String = "SELECT * FROM cur_class_v where Class_ID = '" & txttypeid.Text & "'"
            Using con As SqlConnection = New SqlConnection(conString)
                Dim cmd As SqlCommand = New SqlCommand(query)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        RepeaterDB.DataSource = dt
                        RepeaterDB.DataBind()
                    End Using
                End Using
            End Using

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
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "ar"
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

    Protected Sub GetSchAcc()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetTransAcc"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "sch"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtSchAcc.Text = dr.Item("coa_name")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub OnSave(ByVal sender As Object, ByVal e As EventArgs)

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = True Then
                    Dim conString As String = sCon
                    Using con As SqlConnection = New SqlConnection(conString)
                        Using cmd As SqlCommand = New SqlCommand("Update_Current_Class", con)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txttypeproid.Text
                            cmd.Parameters.Add("@stu_status", SqlDbType.VarChar).Value = "Old"
                            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = ddlacaterm.Text
                            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = ddlacayear.Text
                            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = id.Text
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_Pro_Credit_bill()

        For Each item As RepeaterItem In RepeaterDB.Items
            If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = False Then

                OnStaSave()

            Else
                Exit Sub

            End If
        Next

    End Sub

    Protected Sub OnStaSave()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = False Then
                    Dim conString As String = sCon
                    Using con As SqlConnection = New SqlConnection(conString)
                        Using cmd As SqlCommand = New SqlCommand("Update_Current_Class", con)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txttypeid.Text
                            cmd.Parameters.Add("@stu_status", SqlDbType.VarChar).Value = "Old"
                            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = ddlacaterm.Text
                            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = ddlacayear.Text
                            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = id.Text
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


        Insert_sta_Credit_bill()


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

                    ddlproclass.DataSource = ds
                    ddlproclass.DataTextField = "ClassName"
                    ddlproclass.DataValueField = "ClassName"
                    ddlproclass.DataBind()
                    ddlproclass.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetOurClassID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetOurClassID"}
            'insert product
            cmd.Parameters.Add("@class_type", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txttypeid.Text = dr.Item("ID")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        BindRepeater()

    End Sub

    Protected Sub GetOurProClassID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetOurClassID"}
            'insert product
            cmd.Parameters.Add("@class_type", SqlDbType.VarChar).Value = txtproclassid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txttypeproid.Text = dr.Item("ID")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub


    Protected Sub GetClassID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassTypeID_pro"}
            'insert product
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = ddlClass.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtclassid.Text = dr.Item("class_type")
                txttypeid.Text = dr.Item("ID")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetClassTuition()

    End Sub

    Protected Sub GetClassTuition()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Tuition_fee"}
            'insert product
            cmd.Parameters.Add("@class_type_id", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txttuition.Text = dr.Item("tuition_fee")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        BindRepeater()
        'GetOurClassID()

    End Sub


    Protected Sub GetproClassID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassTypeID_pro"}
            'insert product
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = ddlproclass.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtproclassid.Text = dr.Item("class_type")
                txttypeproid.Text = dr.Item("ID")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetproClassTuition()

    End Sub

    Protected Sub GetproClassTuition()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Tuition_fee"}
            'insert product
            cmd.Parameters.Add("@class_type_id", SqlDbType.VarChar).Value = txtproclassid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtprotuition.Text = dr.Item("tuition_fee")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetAcaYear()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetAcademicYear")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetAcademicYear")

                    ' BIND DATABASE TO SELECT.
                    ddlacayear.DataSource = ds
                    ddlacayear.DataTextField = "aca_year"
                    ddlacayear.DataValueField = "aca_year"
                    ddlacayear.DataBind()
                    ddlacayear.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetAcaTerm()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetAcademicTerm")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetAcademicTerm")

                    ' BIND DATABASE TO SELECT.
                    ddlacaterm.DataSource = ds
                    ddlacaterm.DataTextField = "aca_term"
                    ddlacaterm.DataValueField = "aca_term"
                    ddlacaterm.DataBind()
                    ddlacaterm.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub Check_UnCheckAll(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As RepeaterItem In RepeaterDB.Items
            TryCast(item.FindControl("checkboxId"), CheckBox).Checked = chkAll.Checked
        Next
    End Sub

    Protected Sub OnRowCheckedUnchecked(ByVal sender As Object, ByVal e As EventArgs)
        Dim isAllChecked As Boolean = True
        For Each item As RepeaterItem In RepeaterDB.Items
            If Not (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked Then
                isAllChecked = False
                Exit For
            End If
        Next
        chkAll.Checked = isAllChecked
    End Sub

    Protected Sub Insert_Pro_Credit_bill()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = True Then

                    Dim connetionString As String = sCon
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditBills"}
                    cmd.Parameters.Add("@ent_date", SqlDbType.Date).Value = txtdate.Text
                    cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = id.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtprotuition.Text
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = "Unpaid"
                    cmd.Parameters.Add("@timer", SqlDbType.VarChar).Value = txttimer.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
                    cmd.Parameters.Add("@bal_due", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode.Text
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()

                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_Pro_Credit_Statement()

    End Sub

    Protected Sub Insert_Pro_Credit_Statement()

        Try
            Dim myspace As String = "' '"

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = True Then

                    Dim connetionString As String = sCon
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
                    cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = txtdate.Text
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = "School fees for" + myspace + ddlacaterm.Text + myspace + ddlacayear.Text + myspace + "not yet paid"
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtprotuition.Text
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = id.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
                    cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode.Text
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()


                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_JV_Pro_Recevables()

    End Sub

    Protected Sub Insert_JV_Pro_Recevables()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = True Then

                    Dim connetionString As String = sCon
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
                    cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
                    cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
                    cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtReceAcc.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtprotuition.Text
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
                    cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()


                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_JV_Pro_Sch_Fees()

    End Sub

    Protected Sub Insert_JV_Pro_Sch_Fees()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = True Then

                    Dim connetionString As String = sCon
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
                    cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
                    cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
                    cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtSchAcc.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtprotuition.Text
                    cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
                    cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()


                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub

    Protected Sub Insert_sta_Credit_bill()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = False Then

                    Dim connetionString As String = sCon
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditBills"}
                    cmd.Parameters.Add("@ent_date", SqlDbType.Date).Value = txtdate.Text
                    cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = id.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txttuition.Text
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = "Unpaid"
                    cmd.Parameters.Add("@timer", SqlDbType.VarChar).Value = txttimer.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
                    cmd.Parameters.Add("@bal_due", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode.Text
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()

                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_sta_Credit_Statement()

    End Sub

    Protected Sub Insert_sta_Credit_Statement()

        Try
            Dim myspace As String = "' '"

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = False Then

                    Dim connetionString As String = sCon
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
                    cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = txtdate.Text
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = "School fees for" + myspace + ddlacaterm.Text + myspace + ddlacayear.Text + myspace + "not yet paid"
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txttuition.Text
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = id.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
                    cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode.Text
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()


                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_JV_sta_Recevables()

    End Sub

    Protected Sub Insert_JV_sta_Recevables()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = False Then

                    Dim connetionString As String = sCon
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
                    cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
                    cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
                    cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtReceAcc.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txttuition.Text
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
                    cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()


                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_JV_sta_Sch_Fees()

    End Sub

    Protected Sub Insert_JV_sta_Sch_Fees()

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("studcode"), Label)
                If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = False Then

                    Dim connetionString As String = sCon
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
                    cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
                    cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
                    cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtSchAcc.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txttuition.Text
                    cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
                    cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtlocation.Text
                    cmd.Connection = cnn

                    cnn.Open()
                    cmd.ExecuteNonQuery()
                    cnn.Close()


                End If
            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        txtclassid.Text = String.Empty
        txtproclassid.Text = String.Empty

        Response.Redirect("Promotion.aspx")

    End Sub

    Private Sub ddlClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClass.SelectedIndexChanged
        GetClassID()
    End Sub

    Private Sub ddlClass_TextChanged(sender As Object, e As EventArgs) Handles ddlClass.TextChanged
        GetClassID()
    End Sub

    Private Sub ddlproclass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlproclass.SelectedIndexChanged
        GetproClassID()
    End Sub

    Private Sub ddlproclass_TextChanged(sender As Object, e As EventArgs) Handles ddlproclass.TextChanged
        GetproClassID()
    End Sub


End Class