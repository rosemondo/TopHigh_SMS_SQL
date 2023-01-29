Imports System.IO
Imports System.Web.Script.Serialization
Imports Microsoft.Office.Interop
Imports Microsoft.ReportingServices.Rendering.ExcelRenderer
Imports System.Data.SqlClient

Public Class Staff_List
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString
    Public Property ExcelAutoFormat As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            GetPagefont()
            GetEmployeeList()

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

    Protected Sub GetEmail(ByVal sender As Object, ByVal e As EventArgs)

        'Reference the Repeater Item using Button.
        Dim item As RepeaterItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, RepeaterItem)

        'Reference the Label and TextBox.
        Dim emailmessage As String = (TryCast(item.FindControl("lblemail"), Label)).Text

        txtemail.Text = emailmessage

        Session("emails") = txtemail.Text
        Response.Redirect("Staff_Single_Email.aspx")

    End Sub

    Protected Sub GetValue(ByVal sender As Object, ByVal e As EventArgs)

        'Reference the Repeater Item using Button.
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

        'Reference the Label and TextBox.
        Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

        txtID.Text = message

        Session("EmpID") = txtID.Text
        Response.Redirect("Edit_Employees.aspx")

    End Sub

    Protected Sub GetDelete(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'Reference the Repeater Item using Button.
            Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

            'Reference the Label and TextBox.
            Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

            txtID.Text = message

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteEnpData"}
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = txtID.Text

            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Response.Redirect("Staff_List.aspx")

    End Sub

    Protected Sub GetEmployeeList()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Emp_details", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptemployees.DataSource = dt
                        rptemployees.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub ExportToExcel(sender As Object, e As EventArgs)

        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Staff_List.xls"))
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
            Dim cmd As New SqlCommand("SELECT * FROM employee_details_v", con)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            con.Close()
        End Using
        Return dt
    End Function

End Class
