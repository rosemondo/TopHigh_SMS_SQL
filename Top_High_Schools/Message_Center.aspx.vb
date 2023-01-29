Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Message_Center
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetStudents()
            GetContacta()

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


    Protected Sub GetStudents()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("select * from contact_v")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "contact_v")

                    ' BIND DATABASE TO SELECT.
                    ddlstudent.DataSource = ds
                    ddlstudent.DataTextField = "name"
                    ddlstudent.DataValueField = "name"
                    ddlstudent.DataBind()
                    ddlstudent.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetContacta()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("SELECT * FROM contact_v", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptClasses.DataSource = dt
                        rptClasses.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    <WebMethod>
    Public Shared Function GetParentContact(ByVal contacts As String) As Object

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetParentConts"}
            'insert product
            cmd.Parameters.Add("@student_name", SqlDbType.VarChar).Value = contacts
            cmd.Connection = cnn
            cnn.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If sdr.Read() Then
                Return New With {
                    .FathMobile = sdr("mobile"),
                    .MothMobile = sdr("math_mobile")
                }
            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return Nothing

    End Function


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        If chkboradcast.Checked = True Then

            Broadcast_Message()

        ElseIf chksingle.Checked = True Then

            Single_Message()

        Else

            Response.Write("<script type=""text/javascript"">alert(""Select Single or Broadcast."");</script")

        End If

    End Sub

    Protected Sub Broadcast_Message()

        For Each item As RepeaterItem In rptClasses.Items
            Dim mycontacts As Label = TryCast(item.FindControl("lblcontacts"), Label)

            Dim apikey As String = ""
            Dim sendername As String = "SDH"
            Dim numbers As String = mycontacts.Text.Trim()
            Dim message As String = txtmessage.Text

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

        Broadcast_Message_mother()

    End Sub

    Protected Sub Broadcast_Message_mother()

        For Each item As RepeaterItem In rptClasses.Items
            Dim mycontacts As Label = TryCast(item.FindControl("lblmoncon"), Label)

            Dim apikey As String = ""
            Dim sendername As String = "SDH"
            Dim numbers As String = mycontacts.Text.Trim()
            Dim message As String = txtmessage.Text

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

    Protected Sub Single_Message()


        Dim apikey As String = ""
        Dim sendername As String = "SDH"
        Dim numbers As String = txtcontac.Text.Trim()
        Dim message As String = txtmessage.Text

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

        Single_Message_mother()

    End Sub

    Protected Sub Single_Message_mother()


        Dim apikey As String = ""
        Dim sendername As String = "SDH"
        Dim numbers As String = txtmother.Text.Trim()
        Dim message As String = txtmessage.Text

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

    End Sub


    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        ddlstudent.Text = String.Empty
        ddlstudent.ClearSelection()
        txtcontac.Text = String.Empty
        txtsubject.Text = String.Empty
        txtmessage.Text = String.Empty

    End Sub

End Class