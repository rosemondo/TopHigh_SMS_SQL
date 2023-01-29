Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports DevExpress.Web
Imports DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames
Imports System.Data.SqlClient

Public Class Debtors_List
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            txtdate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            BindRepeater()
            GetClass()

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
                    dplclass.DataSource = ds
                    dplclass.DataTextField = "ClassName"
                    dplclass.DataValueField = "ClassName"
                    dplclass.DataBind()
                    dplclass.Items.Insert(0, New ListItem("", "0"))

                    ' SET THE DEFAULT VALUE.
                    dplclass.Items.Insert(0, "- Search by class -")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub


    Private Sub BindRepeater()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Debtor_list", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        feesdb.DataSource = dt
                        feesdb.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Private Sub BindRepeaterbyclass()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Debtor_list_by_class", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = dplclass.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        feesdb.DataSource = dt
                        feesdb.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Private Sub btnsend_Click(sender As Object, e As EventArgs) Handles btnsend.Click

        For Each item As RepeaterItem In feesdb.Items
            Dim mycontacts As Label = TryCast(item.FindControl("contacs"), Label)
            Dim mysum As Label = TryCast(item.FindControl("fees"), Label)

            Dim apikey As String = ""
            Dim sendername As String = ""
            Dim numbers As String = mycontacts.Text.Trim()
            Dim message As String = ""

            Dim URL As String = "https://apps.mnotify.net/smsapi?key=" & apikey & "&sender_id=" & sendername & "&to=" & numbers & "&msg=" & message
            Dim req As HttpWebRequest = WebRequest.Create(URL)

            Try
                Dim resp As HttpWebResponse = req.GetResponse()
                Dim sr As New StreamReader(resp.GetResponseStream())
                Dim results As String = sr.ReadToEnd()
                sr.Close()

            Catch wex As WebException

                Dim messages = New JavaScriptSerializer().Serialize(wex.Message.ToString())
                Dim script = String.Format("alert({0});", messages)
                ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

            End Try

        Next

        send_moters()

    End Sub

    Private Sub send_moters()

        For Each item As RepeaterItem In feesdb.Items
            Dim mycontacts As Label = TryCast(item.FindControl("momcont"), Label)
            Dim mysum As Label = TryCast(item.FindControl("fees"), Label)

            Dim apikey As String = ""
            Dim sendername As String = ""
            Dim numbers As String = mycontacts.Text.Trim()
            Dim message As String = ""

            Dim URL As String = "https://apps.mnotify.net/smsapi?key=" & apikey & "&sender_id=" & sendername & "&to=" & numbers & "&msg=" & message
            Dim req As HttpWebRequest = WebRequest.Create(URL)

            Try
                Dim resp As HttpWebResponse = req.GetResponse()
                Dim sr As New StreamReader(resp.GetResponseStream())
                Dim results As String = sr.ReadToEnd()
                sr.Close()

            Catch wex As WebException

                Dim messages = New JavaScriptSerializer().Serialize(wex.Message.ToString())
                Dim script = String.Format("alert({0});", messages)
                ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

            End Try

        Next

    End Sub

    Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs)
        BindRepeaterbyclass()
    End Sub

End Class