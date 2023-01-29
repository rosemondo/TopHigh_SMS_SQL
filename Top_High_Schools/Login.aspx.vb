Imports System.Security.Cryptography
Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page


    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            txtusername.Focus()


        End If

    End Sub

    Protected Sub btnsignin_Click(sender As Object, e As EventArgs) Handles btnsignin.Click

        Try

            Dim f_password = GetMD5(txtpassword.Text)

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetLogin"}
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtusername.Text
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = f_password
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtuser.Text = dr.Item("username")
                txtrole.Text = dr.Item("userrole")

                Session("roletest") = txtrole.Text
                Session("usertest") = txtuser.Text


                Response.Redirect("Dashboard.aspx")

            End If

            cnn.Close()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Function GetMD5(ByVal str As String) As String
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim fromData As Byte() = Encoding.UTF8.GetBytes(str)
        Dim targetData As Byte() = md5.ComputeHash(fromData)
        Dim byte2String As String = Nothing

        For i As Integer = 0 To targetData.Length - 1
            byte2String += targetData(i).ToString("x2")
        Next

        Return byte2String
    End Function

End Class