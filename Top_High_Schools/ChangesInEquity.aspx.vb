Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class ChangesInEquity
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Private sender As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim YearTrial = Year(Now)
            txtsdate.Text = YearTrial
            txtdate2.Text = YearTrial - 1
            txtdate3.Text = YearTrial - 2
            GetPagefont()
            BindGrid()
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



    Protected Sub BindGrid()

        Try

            Dim conString As String = sCon
            Dim cmd As SqlCommand = New SqlCommand("GetEqityChangeCurYear")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                    cmd.Connection = con
                    cmd.Parameters.Add("@PrevDate2016", SqlDbType.Int).Value = txtdate3.Text
                    cmd.Parameters.Add("@PrevDate2017", SqlDbType.Int).Value = txtdate2.Text
                    cmd.Parameters.Add("@Date2018", SqlDbType.Int).Value = txtsdate.Text
                    sda.SelectCommand = cmd

                    Dim dt As New DataTable()
                    sda.Fill(dt)
                    rptCashFlow.DataSource = dt
                    rptCashFlow.DataBind()

                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub

    Protected Sub CashSalesbyDate()

        txtsdate.Text = String.Empty
        txtdate2.Text = String.Empty
        txtdate3.Text = String.Empty

        rptCashFlow.DataSource = Nothing

        Try


            Dim conString As String = sCon
            Dim cmd As SqlCommand = New SqlCommand("GetEqityChangeByDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                    cmd.Connection = con
                    cmd.Parameters.Add("@PrevDate2016", SqlDbType.Date).Value = txtpdateto22019.Text
                    cmd.Parameters.Add("@PrevDatefrom2017", SqlDbType.Date).Value = txtRevExpDateto2020.Text
                    cmd.Parameters.Add("@PrevDateTo2017", SqlDbType.Date).Value = txtRevExpLastDateto2020.Text
                    cmd.Parameters.Add("@DateCurFro2018", SqlDbType.Date).Value = txtLastDatefrom2021.Text
                    cmd.Parameters.Add("@DateCurTo2018", SqlDbType.Date).Value = txtLastDateto2021.Text
                    sda.SelectCommand = cmd

                    Dim dt As New DataTable()
                    sda.Fill(dt)
                    rptCashFlow.DataSource = dt
                    rptCashFlow.DataBind()

                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

        If ASPxDatefrom.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Date."");</script")
            Exit Sub
        End If

        If ASPxDateto.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Date."");</script")
            Exit Sub
        End If


        txtsdate.Text = String.Empty
        txtdate2.Text = String.Empty

        Dim todays As Date = ASPxDatefrom.Text
        Dim mydateday As Date = ASPxDateto.Text

        Dim mydaysdate = todays
        Dim Myanswers = mydateday

        txtLastDatefrom2021.Text = mydaysdate.ToString("yyyy-MM-dd")
        txtLastDateto2021.Text = Myanswers.ToString("yyyy-MM-dd")

        Dim toMyanswers = todays.AddYears(-1)
        Dim toMyanswersto = mydateday.AddYears(-1)
        txtRevExpDateto2020.Text = toMyanswers.ToString("yyyy-MM-dd")
        txtRevExpLastDateto2020.Text = toMyanswersto.ToString("yyyy-MM-dd")

        Dim toMyanswers1 = todays.AddYears(-2)
        Dim toMyanswersto1 = mydateday.AddYears(-2)
        txtpdate22019.Text = toMyanswers1.ToString("yyyy-MM-dd")
        txtpdateto22019.Text = toMyanswersto1.ToString("yyyy-MM-dd")

        CashSalesbyDate()

    End Sub

    Protected Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Dim YearTrial = Year(Now)
        txtsdate.Text = YearTrial
        txtdate2.Text = YearTrial - 1
        txtdate3.Text = YearTrial - 2
        BindGrid()
    End Sub

End Class