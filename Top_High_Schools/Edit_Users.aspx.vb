Imports System.Security.Cryptography
Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Edit_Users
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("UserID"))

            txtID.Text = IpassAstringfrompage1

            GetPagefont()
            GetSupList()

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


    Protected Sub GetSupList()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("SELECT * FROM users_t where id = '" & Trim(txtID.Text) & "'", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptstudent.DataSource = dt
                        rptstudent.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub Update_Users()

        Try

            For Each item As RepeaterItem In rptstudent.Items
                Dim id As Label = TryCast(item.FindControl("lblid"), Label)
                Dim mycollege As TextBox = TryCast(item.FindControl("txtname"), TextBox)
                Dim mydate As TextBox = TryCast(item.FindControl("txtpass"), TextBox)
                Dim myoffice As DropDownList = TryCast(item.FindControl("dplrole"), DropDownList)
                Dim mylocation As Label = TryCast(item.FindControl("lbllocation"), Label)


                Dim f_password = GetMD5(mydate.Text)

                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("Update_Users", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = mycollege.Text
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = f_password
                        cmd.Parameters.Add("@userrole", SqlDbType.VarChar).Value = myoffice.Text
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Response.Redirect("Users.aspx")

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Update_Users()
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