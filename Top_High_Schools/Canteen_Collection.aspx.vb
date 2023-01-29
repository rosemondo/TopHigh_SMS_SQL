Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Canteen_Collection
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Text = IpassAstringfrompage2

            txtstartdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")

            GetCtnfees()
            GetPagefont()
            GetStudents()
            GetRevAcc()
            GetCashAcc()
            txttimer.Text = TimeString
            OnDistinctNumber()

        End If

    End Sub

    Protected Sub GetCtnfees()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_cantee_fee"}
            'insert product
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfees.Value = dr.Item("cantee")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

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

    Protected Sub GetStudInfo()

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
                txtstudid.Text = dr.Item("ID")
                txtclass.Text = dr.Item("Class Name")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub txtamount_TextChanged(sender As Object, e As EventArgs) Handles txtamount.TextChanged

        ListBox1.Items.Clear()

        Dim canteenAmt As Double = txtamount.Text
        Dim canteenfee As Double = txtfees.Value
        Dim theNumber = canteenAmt \ canteenfee
        Dim theRounded = Math.Sign(theNumber) * Math.Floor(Math.Abs(theNumber) * 100) \ 100
        txtdays.Text = theRounded

        Dim curdate As Date = txtstartdate.Text
        Dim mydays As Integer = Val(txtdays.Text)
        Dim daysmin As Integer = 1
        Dim daysum As Integer = mydays - daysmin
        txtenddate.Text = DateAdd(DateInterval.Day, daysum, curdate)


        Dim totdays As Double = txtdays.Text
        Dim cnte As Double = txtfees.Value
        Dim myres As Double = totdays * cnte
        txtcanteefees.Text = myres
        Dim canteen As Double = txtcanteefees.Text
        Dim myamt As Double = txtamount.Text
        txtchange.Text = myamt - canteen

        Dim startDate As Date = txtstartdate.Text
        Dim endDate As Date = txtenddate.Text

        Dim days As Integer = txtdays.Text

        txtsat.Text = days

        For g = 0 To days
            Dim testDate = startDate.AddDays(g)

            Select Case testDate.DayOfWeek
                Case DayOfWeek.Saturday, DayOfWeek.Sunday

                    ListBox1.Items.Add(testDate.ToShortDateString())

            End Select

        Next

        txtsun.Text = ListBox1.Items.Count

        Dim myenddate As DateTime = endDate
        Dim mycount As Integer = Val(txtsun.Text)

        txtdate2.Text = endDate
        txtdate2.Text = DateAdd(DateInterval.Day, mycount, myenddate).ToString("yyyy-MM-dd")


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

                txtCashAcc.Text = dr.Item("coa_name")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetRevAcc()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetTransAcc"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "ctn"
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

    Private Sub ddlStudent_TextChanged(sender As Object, e As EventArgs) Handles ddlStudent.TextChanged
        GetStudInfo()
    End Sub

    Protected Sub Insert_Canteen_fees()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert_cantee_collection"}
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = txtlinkcode.Text
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtstudid.Text
            cmd.Parameters.Add("@cantee_date", SqlDbType.Date).Value = txtstartdate.Text
            cmd.Parameters.Add("@amount", SqlDbType.Float).Value = txtamount.Text
            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = ddlstatus.Text
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = txtusers.Text
            cmd.Parameters.Add("@amt_paid", SqlDbType.Float).Value = txtcanteefees.Text
            cmd.Parameters.Add("@start_date", SqlDbType.Date).Value = txtstartdate.Text
            cmd.Parameters.Add("@end_date", SqlDbType.Date).Value = txtdate2.Text
            cmd.Parameters.Add("@status_code", SqlDbType.VarChar).Value = "1"
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Insert_JV_Cash()


    End Sub

    Protected Sub Insert_JV_Cash()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtstartdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtCashAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = txtcanteefees.Text
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

        Insert_JV_Rev()

    End Sub

    Protected Sub Insert_JV_Rev()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_journals"}
            cmd.Parameters.Add("@cash_code", SqlDbType.VarChar).Value = txtlinkcode.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = txtstartdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtReceAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = txtcanteefees.Text
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

        Session("Pstatus") = ddlstatus.Text
        Session("Pcantfees") = txtcanteefees.Text
        Session("Pstudtest") = ddlStudent.Text
        Session("Pclasstest") = txtclass.Text
        Session("Pusertest") = txtusers.Text
        Session("Pamount") = txtamount.Text
        Session("Pchange") = txtchange.Text
        Session("Pdays") = txtdays.Text
        Session("Pstartdate") = txtstartdate.Text
        Session("Penddate") = txtdate2.Text
        Session("Pnumtest") = txtlinkcode.Text

        Response.Redirect("Canteen_Receipt.aspx")

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Insert_Canteen_fees()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        txtlinkcode.Text = String.Empty
        txtstudid.Text = String.Empty
        txtamount.Text = 0
        txtclassid.Text = String.Empty
        ddlstatus.Text = String.Empty
        txtcanteefees.Text = 0

    End Sub
End Class