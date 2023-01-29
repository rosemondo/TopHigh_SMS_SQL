Imports System.Configuration
Imports System.Web.Script.Serialization
Imports System.Data.SqlClient
Imports System.Web.Services
Imports Microsoft.Office.Interop
Imports System.IO

Public Class StudentList
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            txtsearh.Focus()

            GetPagefont()

            GetStudentList()
            GetTotalStudents()
            GetStuListSettings()

            If hfstudid.Value = 0 Then

                dvgstudent.Columns(0).Visible = False
                chkid2.Checked = True
            Else
                chkid1.Checked = True

            End If

            If hfdob.Value = 0 Then

                dvgstudent.Columns(2).Visible = False
                chkdob2.Checked = True
            Else
                chkdob1.Checked = True

            End If

            If hfgen.Value = 0 Then

                dvgstudent.Columns(3).Visible = False
                chkgen2.Checked = True
            Else
                chkgen1.Checked = True

            End If

            If hffoto.Value = 0 Then

                dvgstudent.Columns(5).Visible = False
                chkfoto2.Checked = True
            Else
                chkfoto1.Checked = True

            End If

            If hfcls.Value = 0 Then

                dvgstudent.Columns(4).Visible = False
                chkclass2.Checked = True
            Else
                chkclass1.Checked = True

            End If

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


    Protected Sub GetStuListSettings()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_student_list_settings"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "sch"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                hfid.Value = dr.Item("id")
                hfstudid.Value = dr.Item("lst_id")
                hfdob.Value = dr.Item("lst_dob")
                hfgen.Value = dr.Item("lst_gen")
                hffoto.Value = dr.Item("lst_fot")
                hfcls.Value = dr.Item("lst_cls")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetTotalStudents()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_total_students"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "sch"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lbltotals.Text = dr.Item("number")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetValue(ByVal sender As Object, ByVal e As EventArgs)

        Dim row As GridViewRow = (TryCast((TryCast(sender, ImageButton)).NamingContainer, GridViewRow))
        Dim studentID As String = row.Cells(0).Text

        txtID.Text = studentID

        Session("StudID") = txtID.Text
        Response.Redirect("EditStudent.aspx")

    End Sub

    Protected Sub GetDelete(ByVal sender As Object, ByVal e As EventArgs)

        Try

            Dim row As GridViewRow = (TryCast((TryCast(sender, ImageButton)).NamingContainer, GridViewRow))
            Dim studentID As String = row.Cells(0).Text

            txtID.Text = studentID

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteStudentData"}
            cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtID.Text

            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetStudentList()

    End Sub

    Protected Sub GetStudentList()

        Try


            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("GetStudentList", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        dvgstudent.DataSource = dt
                        dvgstudent.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub
    Protected Sub GetSearchStudentList()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("GetSearchStudent", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@Student", SqlDbType.VarChar).Value = txtsearh.Text
                        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtsearh.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        dvgstudent.DataSource = dt
                        dvgstudent.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        dvgstudent.PageIndex = e.NewPageIndex
        Me.GetStudentList()
    End Sub

    Private Sub txtsearh_TextChanged(sender As Object, e As EventArgs) Handles txtsearh.TextChanged
        GetSearchStudentList()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click


        If chkid2.Checked = True Then
            hfstudid.Value = 0
        Else
            hfstudid.Value = 1
        End If

        If chkdob2.Checked = True Then
            hfdob.Value = 0
        Else
            hfdob.Value = 1
        End If

        If chkgen2.Checked = True Then
            hfgen.Value = 0
        Else
            hfgen.Value = 1
        End If

        If chkclass2.Checked = True Then
            hfcls.Value = 0
        Else
            hfcls.Value = 1
        End If

        If chkfoto2.Checked = True Then
            hffoto.Value = 0
        Else
            hffoto.Value = 1
        End If

        If hfid.Value > 0 Then

            UpdatelistSet()

            Exit Sub

        Else

            InsertlistSet()

        End If

    End Sub

    Protected Sub InsertlistSet()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert_student_list_settings_t"}
            cmd.Parameters.Add("@lst_id", SqlDbType.VarChar).Value = hfstudid.Value
            cmd.Parameters.Add("@lst_dob", SqlDbType.VarChar).Value = hfdob.Value
            cmd.Parameters.Add("@lst_gen", SqlDbType.VarChar).Value = hfgen.Value
            cmd.Parameters.Add("@lst_fot", SqlDbType.VarChar).Value = hffoto.Value
            cmd.Parameters.Add("@lst_cls", SqlDbType.VarChar).Value = hfcls.Value
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetStudentList()

    End Sub

    Protected Sub UpdatelistSet()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "update_student_list_settings_t"}
            cmd.Parameters.Add("@lst_id", SqlDbType.VarChar).Value = hfstudid.Value
            cmd.Parameters.Add("@lst_dob", SqlDbType.VarChar).Value = hfdob.Value
            cmd.Parameters.Add("@lst_gen", SqlDbType.VarChar).Value = hfgen.Value
            cmd.Parameters.Add("@lst_fot", SqlDbType.VarChar).Value = hffoto.Value
            cmd.Parameters.Add("@lst_cls", SqlDbType.VarChar).Value = hfcls.Value
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = hfid.Value
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        GetStudentList()

    End Sub

    Protected Sub ExportToExcel(sender As Object, e As EventArgs)

        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Student_info.xls"))
        Response.ContentType = "application/ms-excel"
        Dim dt As DataTable = GetDatafromDatabase()
        Dim str As String = String.Empty
        For Each dtcol As DataColumn In dt.Columns
            Response.Write(str + dtcol.ColumnName)
            str = vbTab
        Next
        Response.Write(vbLf)
        For Each dr As DataRow In dt.Rows
            str = ""
            For j As Integer = 0 To dt.Columns.Count - 1
                Response.Write(str & Convert.ToString(dr(j)))
                str = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.[End]()
    End Sub
    Protected Function GetDatafromDatabase() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(sCon)
            con.Open()
            Dim cmd As New SqlCommand("GetStudentList", con)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            con.Close()
        End Using
        Return dt
    End Function

End Class