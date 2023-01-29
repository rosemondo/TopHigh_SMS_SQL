Imports System.Data.SqlClient

Public Class Log_in_Portal
    Inherits System.Web.UI.Page




    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            txtusers.Focus()

        End If

    End Sub


    Protected Sub btnsignin_Click(sender As Object, e As EventArgs) Handles btnsignin.Click

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetParentLogin"}
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = txtusers.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtlocation.Text = dr.Item("stud_id")
                txtuser.Text = dr.Item("mobile")

                Session("usertest") = txtuser.Text
                Session("locationtest") = txtlocation.Text


                Response.Redirect("Learners_Portal.aspx")

            End If

            cnn.Close()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class