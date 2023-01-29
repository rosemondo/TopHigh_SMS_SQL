Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class ProfitLoss
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


    Private Sub BindGrid()

        Try

            Dim conString As String = sCon
            Dim cmd As SqlCommand = New SqlCommand("GetIncStaCurYear")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                    cmd.Connection = con
                    cmd.Parameters.Add("@Dateto", SqlDbType.Int).Value = txtsdate.Text
                    sda.SelectCommand = cmd

                    Dim dt As New DataTable()
                    sda.Fill(dt)
                    rptTBStatement.DataSource = dt
                    rptTBStatement.DataBind()

                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub

    Protected Sub CashSalesbyDate()

        txtsdate.Text = String.Empty
        txtdate2.Text = String.Empty

        rptTBStatement.DataSource = Nothing

        Try


            Dim conString As String = sCon
            Dim cmd As SqlCommand = New SqlCommand("GetIncStatbydate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                    cmd.Connection = con
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtLastDatefrom.Text
                    cmd.Parameters.Add("@Dateto", SqlDbType.Date).Value = txtLastDateto.Text
                    sda.SelectCommand = cmd

                    Dim dt As New DataTable()
                    sda.Fill(dt)
                    rptTBStatement.DataSource = dt
                    rptTBStatement.DataBind()

                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

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

        txtLastDatefrom.Text = mydaysdate.ToString("yyyy-MM-dd")
        txtLastDateto.Text = Myanswers.ToString("yyyy-MM-dd")

        Dim todates As Date = ASPxDateto.Text
        Dim toMyanswers = todates.AddYears(-1)
        txtRevExpDateto.Text = toMyanswers.ToString("yyyy-MM-dd")

        CashSalesbyDate()

    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Dim YearTrial = Year(Now)
        txtsdate.Text = YearTrial
        txtdate2.Text = YearTrial - 1
        BindGrid()
    End Sub


End Class