Imports System.Web.Http.Results
Imports System.Web.Mvc
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Admission
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Value = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Value = IpassAstringfrompage2

            admidate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            GetAdmisAcc()
            GetCashAcc()
            GetReceAcc()
            GetSchAcc()
            GetClass()
            GetStudents()
            GetAcaYear()
            GetAcaTerm()
            txttimer.Value = TimeString

            txttuition.Text = "0.00"
            txtadmission.Text = "0.00"
            txtcanteen.Text = "0.00"
            txtbusfee.Text = "0.00"
            txtfirstaid.Text = "0.00"
            txtpta.Text = "0.00"
            txtothers.Text = "0.00"
            txttotals.Text = "0.00"
            txtschfees.Text = "0.00"
            txtadmfee.Text = "0.00"
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

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

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

    Protected Sub GetCashAcc()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetTransAcc"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "pc"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtCashAcc.Value = dr.Item("coa_name")

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

    Protected Sub GetAdmisAcc()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetTransAcc"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "adfe"
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

                txtSchAcc.Value = dr.Item("coa_name")

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

    <WebMethod()>
    Public Shared Function InsertExemption(ByVal studid As String, ByVal exempted As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert_exemption"}
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = studid
            cmd.Parameters.Add("@exemption_type", SqlDbType.VarChar).Value = exempted
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
    Public Shared Function InsertAdmissionCollection(ByVal admidate As String, ByVal txttuition As String, ByVal txtadmission As String, ByVal txtcanteen As String, ByVal txtbusfee As String, ByVal txtfirstaid As String, ByVal txtpta As String, ByVal txtothers As String, ByVal txttotals As String, ByVal txtschfees As String, ByVal txtadmfee As String, ByVal txtclassid As String, ByVal txtstudid As String, ByVal txtusers As String, ByVal ddlacaterm As String, ByVal ddlacayear As String, ByVal txtlinkcode As String) As Boolean

        Try

            Dim paytot As Double = txtschfees
            Dim amtpay As Double = txtadmfee
            Dim totresults As Double = paytot + amtpay

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insertadmissioncollection"}
            cmd.Parameters.Add("@admi_date", SqlDbType.Date).Value = admidate
            cmd.Parameters.Add("@tuition_fee", SqlDbType.Float).Value = txttuition
            cmd.Parameters.Add("@admission_fee", SqlDbType.Float).Value = txtadmission
            cmd.Parameters.Add("@canteen_fee", SqlDbType.Float).Value = txtcanteen
            cmd.Parameters.Add("@bus_fee", SqlDbType.Float).Value = txtbusfee
            cmd.Parameters.Add("@first_aid", SqlDbType.Float).Value = txtfirstaid
            cmd.Parameters.Add("@pta", SqlDbType.Float).Value = txtpta
            cmd.Parameters.Add("@others", SqlDbType.Float).Value = txtothers
            cmd.Parameters.Add("@bill_totals", SqlDbType.Float).Value = txttotals
            cmd.Parameters.Add("@amt_fee_paid", SqlDbType.Float).Value = txtschfees
            cmd.Parameters.Add("@amt_admi_paid", SqlDbType.Float).Value = txtadmfee
            cmd.Parameters.Add("@amt_paid", SqlDbType.Float).Value = totresults
            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = ddlacaterm
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = ddlacayear
            cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode
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
    Public Shared Function InsertFinances(ByVal admidate As String, ByVal txttuition As String, ByVal txtadmission As String, ByVal txttotals As String, ByVal txtschfees As String, ByVal txtadmfee As String, ByVal txtlinkcode As String, ByVal txtCashAcc As String, ByVal txtReceAcc As String, ByVal txtSchAcc As String, ByVal txtAdmAcc As String, ByVal txttimer As String, ByVal txtusers As String) As Boolean

        Try

            Dim Ttot As Double = txttotals
            Dim paytot As Double = txtschfees
            Dim amtpay As Double = txtadmfee

            Dim totresults As Double = paytot + amtpay
            Dim totarresults As Double = Ttot - paytot - amtpay

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_all_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = admidate
            cmd.Parameters.Add("@cash_coa_name", SqlDbType.VarChar).Value = txtCashAcc
            cmd.Parameters.Add("@cash_debit", SqlDbType.Float).Value = totresults
            cmd.Parameters.Add("@cash_credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ar_coa_name", SqlDbType.VarChar).Value = txtReceAcc
            cmd.Parameters.Add("@ar_debit", SqlDbType.Float).Value = totarresults
            cmd.Parameters.Add("@ar_credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@sh_coa_name", SqlDbType.VarChar).Value = txtSchAcc
            cmd.Parameters.Add("@sh_debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@sh_credit", SqlDbType.Float).Value = txttuition
            cmd.Parameters.Add("@ad_coa_name", SqlDbType.VarChar).Value = txtAdmAcc
            cmd.Parameters.Add("@ad_debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ad_credit", SqlDbType.Float).Value = txtadmission
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
    Public Shared Function InsertCurrentClass(ByVal admidate As String, ByVal txtclassid As String, ByVal txtstudid As String, ByVal ddlacaterm As String, ByVal ddlacayear As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Current_Class"}
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid
            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid
            cmd.Parameters.Add("@date_in", SqlDbType.Date).Value = admidate
            cmd.Parameters.Add("@stu_status", SqlDbType.VarChar).Value = "New"
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = ddlacaterm
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = ddlacayear
            cmd.Parameters.Add("@active_status", SqlDbType.VarChar).Value = "Active"
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
    Public Shared Function Insert_tuition(ByVal admidate As String, ByVal txttuition As String, ByVal txtstudid As String, ByVal txtlinkcode As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = admidate
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = "New School fees"
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txttuition
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid
            cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode
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
    Public Shared Function Insert_admission(ByVal admidate As String, ByVal txtadmission As String, ByVal txtstudid As String, ByVal txtlinkcode As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = admidate
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = "New Admission fees"
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtadmission
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid
            cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode
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
    Public Shared Function Insert_payfes(ByVal admidate As String, ByVal txtschfees As String, ByVal txtstudid As String, ByVal txtlinkcode As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = admidate
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = "Payment of school fees"
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtschfees
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid
            cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode
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
    Public Shared Function Insert_payadmi(ByVal admidate As String, ByVal txtadmfee As String, ByVal txtstudid As String, ByVal txtlinkcode As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = admidate
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = "Payment of admission fee"
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtadmfee
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid
            cmd.Parameters.Add("@link_code", SqlDbType.VarChar).Value = txtlinkcode
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
    Public Shared Function Insert_fee_collection(ByVal txtadmission As String, ByVal txtadmfee As String, ByVal admidate As String, ByVal txtschfees As String, ByVal txtusers As String, ByVal ddlacayear As String, ByVal ddlacaterm As String, ByVal txtstudid As String) As Boolean

        Try

            Dim paytot As Double = txtadmission
            Dim amtpay As Double = txtadmfee
            Dim totresults As Double = paytot - amtpay


            Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert_sch_fee_col"}
            cmd.Parameters.Add("@col_date", SqlDbType.Date).Value = admidate
            cmd.Parameters.Add("@amount_paid", SqlDbType.Float).Value = txtschfees
            cmd.Parameters.Add("@sys_user", SqlDbType.VarChar).Value = txtusers
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = ddlacayear
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = ddlacaterm
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid
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
    Public Shared Function GetFeesData(ByVal classname As String) As Object

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Stud_Fees"}
            'insert product
            cmd.Parameters.Add("@classname", SqlDbType.VarChar).Value = classname
            cmd.Connection = cnn
            cnn.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If sdr.Read() Then
                Return New With {
                    .ClassID = sdr("ClassID"),
                    .TuitionFee = sdr("Tuition Fee"),
                    .AdmissionFee = sdr("Admission Fee"),
                    .CanteenFee = sdr("Canteen Fee"),
                    .BusFee = sdr("Bus Fee"),
                    .FirstAID = sdr("First AID"),
                    .PTA = sdr("PTA"),
                    .Others = sdr("Others"),
                    .ClassType = sdr("Class Type"),
                    .ClassName = sdr("Class Name")
                }
            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return Nothing
    End Function

    <WebMethod>
    Public Shared Function GetStudID(ByVal studname As String) As Object

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_My_ID"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = studname
            cmd.Connection = cnn
            cnn.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If sdr.Read() Then
                Return New With {
                    .StudentID = sdr("stud_id")
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