Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Parents_Details
    Inherits System.Web.UI.Page


    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetStudents()
            GetContacta()
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

    Protected Sub GetStudents()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("Get_names_contacts")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "Get_names_contacts")

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
                    ddlclass.DataSource = ds
                    ddlclass.DataTextField = "ClassName"
                    ddlclass.DataValueField = "ClassName"
                    ddlclass.DataBind()
                    ddlclass.Items.Insert(0, New ListItem("", "0"))

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

                Using cmd As SqlCommand = New SqlCommand("Get_all_parents_contact", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        dvgparents.DataSource = dt
                        dvgparents.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetSearchContacta()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_all_parents_contact_by_name", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = ddlstudent.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        dvgparents.DataSource = dt
                        dvgparents.DataBind()
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
        dvgparents.PageIndex = e.NewPageIndex
        Me.GetContacta()
    End Sub


    Protected Sub GetSearchClass()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_all_parents_contact_by_class", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = ddlclass.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        dvgparents.DataSource = dt
                        dvgparents.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Private Sub ddlstudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlstudent.SelectedIndexChanged
        GetSearchContacta()
    End Sub

    Private Sub ddlstudent_TextChanged(sender As Object, e As EventArgs) Handles ddlstudent.TextChanged
        GetSearchContacta()
    End Sub

    Private Sub ddlclass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlclass.SelectedIndexChanged
        GetSearchClass()
    End Sub

    Private Sub ddlclass_TextChanged(sender As Object, e As EventArgs) Handles ddlclass.TextChanged
        GetSearchClass()
    End Sub

    Protected Sub ExportToExcel(sender As Object, e As EventArgs)

        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Parent_Contact_List.xls"))
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
            Dim cmd As New SqlCommand("SELECT * FROM contact_v", con)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            con.Close()
        End Using
        Return dt
    End Function


End Class