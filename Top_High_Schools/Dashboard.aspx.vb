Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Dashboard
    Inherits System.Web.UI.Page


    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetAcademics()

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Value = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Value = IpassAstringfrompage2

            todaysdate.Value = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            GetAcademics()
            GetTotalStudents()
            GetTotalTeacher()
            GetTotaldebtors()
            GetTotalExpense()
            GetTotalFees()
            GetTotalCanteen()

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


    Protected Sub GetAcademics()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_current_year"}
            'insert product
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtstartdate.Value = dr.Item("start_date")
                txtenddate.Value = dr.Item("end_date")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetTotalStudents()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Count_Active_Students"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "sch"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lnktotalstud.Text = dr.Item("number")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetTotalTeacher()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Expect_Rece"}
            'insert product
            cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = txtstartdate.Value
            cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = txtenddate.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lnkexptrev.Text = dr.Item("debit")
                lnkexptrev.Text = Format(lnkexptrev.Text, "Standard")

                lnktotrevenue.Text = dr.Item("credit")
                lnktotrevenue.Text = Format(lnktotrevenue.Text, "Standard")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetTotaldebtors()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Total_Debt"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "sch"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lnkbebtors.Text = dr.Item("number")
                lnkbebtors.Text = Format(lnkbebtors.Text, "Standard")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetTotalCanteen()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Daily_Canteen"}
            'insert product
            cmd.Parameters.Add("@cantee_date", SqlDbType.Date).Value = todaysdate.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lnkcnt.Text = dr.Item("debit")
                lnkcnt.Text = Format(lnkcnt.Text, "Standard")


            End If

            cnn.Close()

        Catch ex As Exception

            'Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            'Dim script = String.Format("alert({0});", message)
            'ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub GetTotalFees()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Daily_Fees_Collection"}
            'insert product
            cmd.Parameters.Add("@col_date", SqlDbType.Date).Value = todaysdate.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lnkfees.Text = dr.Item("number")
                lnkfees.Text = Format(lnkfees.Text, "Standard")

            End If

            cnn.Close()

        Catch ex As Exception

            'Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            'Dim script = String.Format("alert({0});", message)
            'ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub GetTotalExpense()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Daily_Expenses"}
            'insert product
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = todaysdate.Value
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lnkexp.Text = dr.Item("number")
                lnkexp.Text = Format(lnkexp.Text, "Standard")

            End If

            cnn.Close()

        Catch ex As Exception

            'Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            'Dim script = String.Format("alert({0});", message)
            'ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

End Class