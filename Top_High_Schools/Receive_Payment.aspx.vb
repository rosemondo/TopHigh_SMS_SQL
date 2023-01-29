Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Receive_Payment
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Value = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Value = IpassAstringfrompage2

            txtdate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            GetAcaDate()

            GetStudents()
            GetCurAsset()
            GetDiscAcc()
            GetReceAcc()
            GetAcaYearTerm()

            txttimer.Value = TimeString

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
            txttimer.Value = TimeString
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


    Protected Sub GetAcaDate()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_End_Date"}
            'insert product
            'cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtacadate.Value = dr.Item("end_date")
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

    Protected Sub GetAcaYearTerm()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Academics"}
            'insert product
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtstartdate.Value = dr.Item("start_date")
                txtenddate.Value = dr.Item("end_date")
                txtacaterm.Value = dr.Item("aca_term")
                txtacayear.Value = dr.Item("aca_year")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

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
                    ddlStudent.DataTextField = "student"
                    ddlStudent.DataValueField = "student"
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

    Protected Sub GetStudID()

        Try

            txtbaldue.Text = "0.00"
            txtdiscount.Text = "0.00"
            txtpaid.Text = "0.00"
            txtpayment.Text = "0.00"
            txtdescription.Text = String.Empty

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_My_ID"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = ddlStudent.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then


                txtstudid.Text = dr.Item("stud_id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetReceBalDueData()
        GetClassType()
        GetReceArrearsData()
        GetPaymentData()
        GetClassID()

    End Sub

    Protected Sub GetClassID()

        Try

            txtbaldue.Text = "0.00"
            txtdiscount.Text = "0.00"
            txtpaid.Text = "0.00"
            txtpayment.Text = "0.00"
            txtdescription.Text = String.Empty

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassID2"}
            'insert product
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then


                txtclassid.Text = dr.Item("class_id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetClassName()
        GetReceBalDueData()
        GetClassType()
        GetReceArrearsData()
        GetPaymentData()

    End Sub

    Protected Sub GetClassName()

        Try

            txtbaldue.Text = "0.00"
            txtdiscount.Text = "0.00"
            txtpaid.Text = "0.00"
            txtpayment.Text = "0.00"
            txtdescription.Text = String.Empty

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Learners_Class"}
            'insert product
            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then


                txtclass.Text = dr.Item("Class")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetReceBalDueData()
        GetClassType()
        GetReceArrearsData()
        GetPaymentData()

    End Sub



    Protected Sub GetReceArrearsData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Fees_Balanace"}
            'insert product
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
            cmd.Parameters.Add("@st_datefrom", SqlDbType.Date).Value = txttimeago.Value
            cmd.Parameters.Add("@st_dateto", SqlDbType.Date).Value = txtacadate.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtarrears.Text = dr.Item("amt")
                txtarrears.Text = Format(txtarrears.Text, "Standard")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetPaymentData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_amount_paid"}
            'insert product
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
            cmd.Parameters.Add("@st_datefrom", SqlDbType.Date).Value = txtstartdate.Value
            cmd.Parameters.Add("@st_dateto", SqlDbType.Date).Value = txtenddate.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtpaid.Text = dr.Item("amt")
                txtpaid.Text = Format(txtpaid.Text, "Standard")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub GetReceBalDueData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetReceBalDueData"}
            'insert product
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtbaldue.Text = dr.Item("balance")

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
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassType_by_cls_id"}
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
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClass_Fee"}
            'insert product
            cmd.Parameters.Add("@class_type_id", SqlDbType.VarChar).Value = txtclasstype.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfees.Text = dr.Item("tuition_fee")

            End If

            'Dim mydue As Double = txtbaldue.Text
            'Dim myfees As Double = txtfees.Text
            'Dim myres As Double = myfees - mydue

            'txtpaid.Text = myres

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

                txtReceAcc.Value = dr.Item("coa_name")

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

                txtAdmAcc.Value = dr.Item("coa_name")

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
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = txtdescription.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
            cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode.Value
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
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Value
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = ddlpaymeth.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Value
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Value
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
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Value
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtReceAcc.Value
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Value
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Value
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
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Value
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtAdmAcc.Value
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtdiscount.Text * -1
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = txttimer.Value
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Value
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

    Protected Sub Insert_fee_collection()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert_sch_fee_col"}
            cmd.Parameters.Add("@col_date", SqlDbType.Date).Value = txtdate.Text
            cmd.Parameters.Add("@amount_paid", SqlDbType.Float).Value = txtpayment.Text
            cmd.Parameters.Add("@sys_user", SqlDbType.VarChar).Value = txtusers.Value
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = txtacayear.Value
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = txtacaterm.Value
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

    Protected Sub Update_fee_collection()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "update_admi_collections"}
            cmd.Parameters.Add("@amt_fee_paid", SqlDbType.Float).Value = txtpayment.Text
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


        txttimer.Value = TimeString

        Insert_Credit_Statement()
        Insert_JV_Cash()
        Insert_JV_Disc_Fees()
        Insert_JV_Recevables()
        Insert_fee_collection()
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
        Session("Pusertest") = txtusers.Value
        Session("Pdatetest") = txtdate.Text
        Session("Pnumtest") = txtlinkcode.Value

        Response.Redirect("Payment_Receipt.aspx")

    End Sub

    Protected Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        txtbaldue.Text = "0.00"
        txtdiscount.Text = "0.00"
        txtpaid.Text = "0.00"
        txtpayment.Text = "0.00"
        txtdescription.Text = String.Empty
    End Sub

    Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs)
        txtbaldue.Text = "0.00"
        txtdiscount.Text = "0.00"
        txtpaid.Text = "0.00"
        txtpayment.Text = "0.00"
        txtdescription.Text = String.Empty
        GetStudID()
    End Sub

    'Private Sub ddlStudent_TextChanged(sender As Object, e As EventArgs) Handles ddlStudent.TextChanged
    '    txtbaldue.Text = "0.00"
    '    txtdiscount.Text = "0.00"
    '    txtpaid.Text = "0.00"
    '    txtpayment.Text = "0.00"
    '    txtdescription.Text = String.Empty
    '    GetStudID()
    'End Sub


End Class