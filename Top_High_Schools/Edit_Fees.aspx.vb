Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Edit_Fees
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Value = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Value = IpassAstringfrompage2

            GetPagefont()
            GetStudents()
            txttimer.Value = TimeString


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


    Protected Sub GetStudents()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetStudentList")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetStudentList")

                    ' BIND DATABASE TO SELECT.
                    ddlStudent.DataSource = ds
                    ddlStudent.DataTextField = "student"
                    ddlStudent.DataValueField = "student"
                    ddlStudent.DataBind()
                    ddlStudent.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetStudentID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetStudentID"}
            'insert product
            cmd.Parameters.Add("@Student", SqlDbType.VarChar).Value = ddlStudent.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtStudid.Value = dr.Item("ID")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        BindRepeater()

    End Sub

    Private Sub BindRepeater()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Learners_fees_by_stud_id", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtStudid.Value
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        RepeaterDB.DataSource = dt
                        RepeaterDB.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub

    Protected Sub GetDelete(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'Reference the Repeater Item using Button.
            Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

            'Reference the Label and TextBox.
            Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

            txtID.Value = message

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Delete_Stud_Fees"}
            cmd.Parameters.Add("@stid", SqlDbType.Int).Value = txtID.Value

            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetStudentID()

    End Sub

    Protected Sub ddlStudent_SelectedIndexChanged(sender As Object, e As EventArgs)
        GetStudentID()
    End Sub


    Private Sub cmdsearch_Click(sender As Object, e As EventArgs) Handles cmdsearch.Click
        GetStudentID()
    End Sub

    Protected Sub OnSave(ByVal sender As Object, ByVal e As EventArgs)

        Try

            For Each item As RepeaterItem In RepeaterDB.Items
                Dim id As Label = TryCast(item.FindControl("lblID"), Label)
                Dim desc As TextBox = TryCast(item.FindControl("txtdescription"), TextBox)
                Dim deb As TextBox = TryCast(item.FindControl("txtdebit"), TextBox)
                Dim cred As TextBox = TryCast(item.FindControl("txtcredit"), TextBox)

                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("Update_Stud_Fees", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = desc.Text
                        cmd.Parameters.Add("@debit", SqlDbType.VarChar).Value = deb.Text
                        cmd.Parameters.Add("@credit", SqlDbType.VarChar).Value = cred.Text
                        cmd.Parameters.Add("@stid", SqlDbType.Int).Value = id.Text
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

        GetStudentID()

    End Sub

End Class