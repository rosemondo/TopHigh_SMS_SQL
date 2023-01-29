Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient

Public Class baseimg
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim reader As StreamReader = New StreamReader(Request.InputStream)
        Dim Data As String = Server.UrlDecode(reader.ReadToEnd())
        reader.Close()
        Dim nm As DateTime = DateTime.Now
        Dim mydate As String = nm.ToString("yyyymmddMMss")
        Session("capturedImageURL") = Server.MapPath("~/Userimages/") & mydate & ".jpeg"
        Session("Imagename") = mydate & ".jpeg"
        drawimg(Data.Replace("imgBase64=data:image/png;base64,", String.Empty), Session("capturedImageURL").ToString())
        insertImagePath(Session("Imagename").ToString(), "~/Userimages/" & Session("Imagename").ToString())

    End Sub

    Public Sub drawimg(ByVal base64 As String, ByVal filename As String)
        Using fs As FileStream = New FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write)

            Using bw As BinaryWriter = New BinaryWriter(fs)
                Dim data As Byte() = Convert.FromBase64String(base64)
                bw.Write(data)
                bw.Close()
            End Using
        End Using
    End Sub

    Public Sub insertImagePath(ByVal imagename As String, ByVal imagepath As String)
        Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Mycon").ToString())
        Dim cmd As SqlCommand = New SqlCommand("Update student_photos_t set filename = @filename, contenttype = @contenttype, stud_pic = @stud_pic where stud_id = @stud_id", con)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@filename", imagename)
        cmd.Parameters.AddWithValue("@UserImagePath", imagepath)
        cmd.Parameters.AddWithValue("@UserID", 1)
        cmd.Parameters.AddWithValue("@QueryID", 1)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

End Class