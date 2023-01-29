Imports System.Net
Imports System.Net.Mail
Imports System.Configuration
Imports System.Net.Configuration
Imports System.IO

Public Class Staff_Single_Email
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("emails"))

            txtemail.Text = IpassAstringfrompage1

        End If

    End Sub

    Protected Sub SendEmail(ByVal sender As Object, ByVal e As EventArgs)

        Dim message As MailMessage = New MailMessage()
        Dim smtpClient As SmtpClient = New SmtpClient()
        Dim msg As String = String.Empty

        Try
            Dim fromAddress As MailAddress = New MailAddress("SHB@solidhopeschools.com")
            message.From = fromAddress
            message.[To].Add(txtemail.Text)
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
        Catch ex As Exception
            msg = ex.Message
        End Try



    End Sub

End Class