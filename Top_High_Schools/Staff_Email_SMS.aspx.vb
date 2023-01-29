Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Staff_Email_SMS
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetContacta()

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

    Protected Sub GetContacta()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Emp_details", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
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

    Protected Sub Broadcast_Emails(ByVal sender As Object, ByVal e As EventArgs)

        Try


            For Each item As RepeaterItem In rptClasses.Items

                Dim mycontacts As Label = TryCast(item.FindControl("lblemail"), Label)

                Dim message As MailMessage = New MailMessage()
                Dim smtpClient As SmtpClient = New SmtpClient()


                Dim fromAddress As MailAddress = New MailAddress("")
                message.From = fromAddress
                message.[To].Add(mycontacts.Text)
                message.Subject = txtsubject.Text
                If fuAttachment.HasFile Then
                    For Each file As HttpPostedFile In fuAttachment.PostedFiles
                        Dim fileName As String = Path.GetFileName(file.FileName)
                        file.SaveAs(Server.MapPath("~/Captures/") & fileName)
                        message.Attachments.Add(New Attachment(file.InputStream, fileName))
                    Next
                End If
                message.IsBodyHtml = True
                message.Body = txtmessage.Text
                smtpClient.Host = "mail5009.site4now.net"
                smtpClient.Port = 25
                smtpClient.EnableSsl = False
                smtpClient.UseDefaultCredentials = True
                smtpClient.Credentials = New System.Net.NetworkCredential("SHB@solidhopeschools.com", "Solmalik2022##")
                smtpClient.Send(message)

            Next

        Catch wex As Exception

            Dim messages = New JavaScriptSerializer().Serialize(wex.Message.ToString())
            Dim script = String.Format("alert({0});", messages)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Dim msmessages As String = "Success"
        ScriptManager.RegisterStartupScript(CType(sender, Control), Me.GetType(), "alert", "alert('" & msmessages & "');", True)


    End Sub

    Protected Sub Broadcast_Message(ByVal sender As Object, ByVal e As EventArgs)

        For Each item As RepeaterItem In rptClasses.Items
            Dim mycontacts As Label = TryCast(item.FindControl("lblcontact"), Label)

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

        Dim msmessages As String = "Success"
        ScriptManager.RegisterStartupScript(CType(sender, Control), Me.GetType(), "alert", "alert('" & msmessages & "');", True)

    End Sub


End Class