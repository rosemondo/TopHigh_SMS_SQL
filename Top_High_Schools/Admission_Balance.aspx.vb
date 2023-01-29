Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Admission_Balance
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
            GetStudents()
            GetCurAsset()
            GetDiscAcc()
            GetReceAcc()
            GetAcaYearTerm()
            txttimer.Text = TimeString

            txtclass.Text = String.Empty
            ddlStudent.Text = " - Select -"
            ddlpaymeth.Text = " - Select -"
            ddlstatus.Text = " - Select -"
            txtbaldue.Text = "0.00"
            txtdiscount.Text = "0.00"
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

    Protected Sub GetAcaYearTerm()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from academic_calendar_t where aca_status = @aca_status"}
            'insert product
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtacaterm.Text = dr.Item("aca_term")
                txtacayear.Text = dr.Item("aca_year")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetStudents()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetStudentList")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetStudentList")

                    ' BIND DATABASE TO SELECT.
                    ddlStudent.DataSource = ds
                    ddlStudent.DataTextField = "student_name"
                    ddlStudent.DataValueField = "student_name"
                    ddlStudent.DataBind()
                    ddlStudent.Items.Insert(0, New ListItem("", "0"))

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

    Protected Sub GetReceBillData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetReceBillSData"}
            'insert product
            cmd.Parameters.Add("@Student", SqlDbType.VarChar).Value = ddlStudent.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtclassid.Text = dr.Item("Class ID")
                txtstudid.Text = dr.Item("Student ID")
                txtclass.Text = dr.Item("Class Name")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetReceBalDueData()
        GetClassType()

    End Sub

    Protected Sub GetReceBalDueData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetAdmReceBalDueData"}
            'insert product
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
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

    Protected Sub GetClassType()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from class_t where class_id = @class_id"}
            'insert product
            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtclasstype.Text = dr.Item("class_type")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetClassFees()

    End Sub

    Protected Sub GetClassFees()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from fees_bill_t where class_type_id = @class_type_id"}
            'insert product
            cmd.Parameters.Add("@class_type_id", SqlDbType.VarChar).Value = txtclasstype.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfees.Text = dr.Item("admission_fee")

            End If

            Dim mydue As Double = txtbaldue.Text
            Dim myfees As Double = txtfees.Text
            Dim myres As Double = myfees - mydue

            txtpaid.Text = myres

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

    Protected Sub GetDiscAcc()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetTransAcc"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "sd"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtAdmAcc.Text = dr.Item("coa_name")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub Insert_Credit_bill()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateAdmCreditBills"}
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = ddlstatus.Text
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
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

    Protected Sub Insert_Credit_Statement()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = txtdescription.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
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
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
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
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
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

    Protected Sub Insert_JV_Disc_Fees()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtAdmAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtdiscount.Text * -1
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Text
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
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

    Protected Sub Update_fee_collection()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "update_admi_admi_collections"}
            cmd.Parameters.Add("amt_admi_paid", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text

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

        If ddlStudent.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Learner."");</script")
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

        Insert_Credit_bill()
        Insert_Credit_Statement()
        Insert_JV_Cash()
        Insert_JV_Disc_Fees()
        Insert_JV_Recevables()
        Update_fee_collection()

        Dim tot1 As Double = txtbaldue.Text
        Dim tot2 As Double = txtdiscount.Text
        Dim tot3 As Double = txtpayment.Text

        Dim results As Double = tot1 - tot2 - tot3

        Session("Ptuitest") = txtbaldue.Text
        Session("Ptottest") = txtdiscount.Text
        Session("Ppmttest") = txtpayment.Text
        Session("Pbaltest") = results
        Session("Pstudtest") = ddlStudent.Text
        Session("Pclasstest") = txtclass.Text
        Session("Pusertest") = txtusers.Text
        Session("Pdatetest") = txtdate.Text
        Session("Pnumtest") = txtlinkcode.Text

        Response.Redirect("Payment_Receipt_Admission.aspx")

    End Sub

    Protected Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        txtbaldue.Text = "0.00"
        txtdiscount.Text = "0.00"
        txtpaid.Text = "0.00"
        txtpayment.Text = "0.00"
        txtdescription.Text = String.Empty
    End Sub

    Protected Sub ddlStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStudent.SelectedIndexChanged
        txtbaldue.Text = "0.00"
        txtdiscount.Text = "0.00"
        txtpaid.Text = "0.00"
        txtpayment.Text = "0.00"
        txtdescription.Text = String.Empty
        GetReceBillData()
    End Sub

    Private Sub ddlStudent_TextChanged(sender As Object, e As EventArgs) Handles ddlStudent.TextChanged
        txtbaldue.Text = "0.00"
        txtdiscount.Text = "0.00"
        txtpaid.Text = "0.00"
        txtpayment.Text = "0.00"
        txtdescription.Text = String.Empty
        GetReceBillData()
    End Sub


End Class