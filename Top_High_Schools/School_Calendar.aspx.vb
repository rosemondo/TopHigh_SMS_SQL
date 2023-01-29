Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class School_Calendar
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetMonthCnt()

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


    Protected Sub GetMonthCnt()

        Try
            Dim conString As New SqlConnection(sCon)

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Get_max_aca_id"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                Dim myid As Integer

                myid = dr.Item("id")

                lblid.Value = myid

                dr.Close()

            End If

        Catch EX As Exception
            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)
        End Try

    End Sub

    Protected Sub txtenddate_TextChanged(sender As Object, e As EventArgs)

        Try

            Dim dt1 As Date = Date.Parse(txtstartdate.Text)
            Dim dt2 As Date = Date.Parse(txtenddate.Text)

            ' here we suppose the month is 30 days

            lblmonthcount.Value = Math.Abs(CInt(dt1.Subtract(dt2).TotalDays / 30))

        Catch ex As Exception

        End Try

        Try

            Dim dtstart As DateTime = Convert.ToDateTime(txtstartdate.Text)
            Dim dtend As DateTime = Convert.ToDateTime(txtenddate.Text)

            Dim ts As TimeSpan = dtend.Subtract(dtstart)

            If Convert.ToInt32(ts.Days) >= 0 Then

                lbldays.Value = Convert.ToInt32(ts.Days)

            Else

                Response.Write("<script type=""text/javascript"">alert(""Invalid Input."");</script")

            End If

        Catch ex As Exception

        End Try

        Try

            Dim dtstart As Date = Date.Parse(txtstartdate.Text)
            Dim dtend As Date = Date.Parse(txtenddate.Text)

            lblweekends.Value = DateDiff(DateInterval.WeekOfYear, dtstart, dtend)

            Dim tot1 As Double = lblmultiple.Value
            Dim tot2 As Double = lblweekends.Value
            Dim tot3 As Double = lbldays.Value
            Dim results As Double = tot3 - (tot2 * tot1)

            lblfindays.Value = results

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub InsertCalenderYear(sender As Object, e As EventArgs)

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertcalendaryear"}
            cmd.Parameters.Add("@start_date", SqlDbType.Date).Value = txtstartdate.Text
            cmd.Parameters.Add("@end_date", SqlDbType.Date).Value = txtenddate.Text
            cmd.Parameters.Add("@aca_term", SqlDbType.VarChar).Value = ddlterm.Text
            cmd.Parameters.Add("@aca_year", SqlDbType.VarChar).Value = ddlyear.Text
            cmd.Parameters.Add("@mon_cont", SqlDbType.VarChar).Value = "4"
            cmd.Parameters.Add("@sch_days", SqlDbType.VarChar).Value = lblfindays.Value
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "New"
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                Dim script = String.Format("alert({0});", message)
                ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)
            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception
            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)
        End Try

        UpdateCalenderYear()

    End Sub

    Public Sub UpdateCalenderYear()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateCalenderYear"}
            cmd.Parameters.Add("@aca_status", SqlDbType.VarChar).Value = "Old"
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = lblid.Value
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                Dim script = String.Format("alert({0});", message)
                ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)
            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception
            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)
        End Try

        Response.Redirect("Dashboard.aspx")

    End Sub


End Class