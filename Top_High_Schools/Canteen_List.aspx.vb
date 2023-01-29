Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Canteen_List
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            txtdate.Text = Date.Now.Date.ToString("yyyy-MM-dd")

            txtLastDatefrom.Text = Date.Now.Date.ToString("yyyy-MM-dd")

            txtmydate.Text = txtLastDatefrom.Text

            GetPagefont()
            Search_canteen_by_date()


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


    Protected Sub GetClasscount()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim Label3 As Label = TryCast(item.FindControl("Label3"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Classcount"}
                'insert product
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    Label3.Text = dr.Item("Count")

                End If

                cnn.Close()


            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetTotalPaid()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim Label3 As Label = TryCast(item.FindControl("Label3"), Label)
                Dim Label4 As Label = TryCast(item.FindControl("Label4"), Label)
                Dim Label6 As HyperLink = TryCast(item.FindControl("HyperLink1"), HyperLink)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Classcount_by_Date"}
                'insert product
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtLastDatefrom.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    Label4.Text = dr.Item("Count")

                    Dim tot1 As Integer = Label3.Text
                    Dim tot2 As Integer = Label4.Text
                    Dim rest As Integer = tot1 - tot2
                    Label6.Text = rest

                End If

                cnn.Close()


            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetTotalPaidSearch()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim Label3 As Label = TryCast(item.FindControl("Label3"), Label)
                Dim Label4 As Label = TryCast(item.FindControl("Label4"), Label)
                Dim Label6 As HyperLink = TryCast(item.FindControl("HyperLink1"), HyperLink)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Classcount_by_Date"}
                'insert product
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtmydate.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    Label4.Text = dr.Item("Count")

                    Dim tot1 As Integer = Label3.Text
                    Dim tot2 As Integer = Label4.Text
                    Dim rest As Integer = tot1 - tot2
                    Label6.Text = rest

                End If

                cnn.Close()


            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Search_canteen_by_date()

        Try
            txtmydate.Text = txtdate.Text

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Canteen_by_Date", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtmydate.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptReportMain.DataSource = dt
                        rptReportMain.DataBind()
                    End Using
                End Using
            End Using


            GetClasscount()
            GetTotalPaidSearch()
            GetSearchCanteenSum()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub

    Protected Sub OnItemDataBound(sender As Object, e As RepeaterItemEventArgs)

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim customerId As String = TryCast(e.Item.FindControl("hfCustomerId"), HiddenField).Value
            Dim rptRepoDetails As Repeater = TryCast(e.Item.FindControl("rptRepoDetails"), Repeater)

            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

                Using cmd As SqlCommand = New SqlCommand("Get_Canteen_by_Date_Class", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtmydate.Text
                        cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = customerId
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptRepoDetails.DataSource = dt
                        rptRepoDetails.DataBind()
                    End Using
                End Using
            End Using

        End If

    End Sub

    Protected Sub GetCanteenSum()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim lblname As Label = TryCast(item.FindControl("lbllearners"), Label)
                Dim lblsum As Label = TryCast(item.FindControl("lblsum"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Canteen_sum_by_Date_Class"}
                'insert product
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtmydate.Text
                cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = lblname.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    lblsum.Text = dr.Item("tot")

                    lblsum.Text = Format(lblsum.Text, "Standard")

                End If

                cnn.Close()


            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetSearchCanteenSum()

        Try

            For Each item As RepeaterItem In rptReportMain.Items

                Dim lblname As Label = TryCast(item.FindControl("lbllearners"), Label)
                Dim lblsum As Label = TryCast(item.FindControl("lblsum"), Label)

                Dim connetionString As String = sCon
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Canteen_sum_by_Date_Class"}
                'insert product
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtdate.Text
                cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = lblname.Text
                cmd.Connection = cnn
                cnn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                ' If the record can be queried, it means passing verification, then open another form.   
                If (dr.Read() = True) Then

                    lblsum.Text = dr.Item("tot")

                    lblsum.Text = Format(lblsum.Text, "Standard")

                End If

                cnn.Close()


            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

        Search_canteen_by_date()

    End Sub

End Class