Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Services

Public Class WebForm1
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.BindDummyRow()
        End If
    End Sub

    Private Sub BindDummyRow()
        Dim dummy As New DataTable()
        dummy.Columns.Add("customerid")
        dummy.Columns.Add("name")
        dummy.Columns.Add("country")
        dummy.Rows.Add()
        rptCustomers.DataSource = dummy
        rptCustomers.DataBind()
    End Sub

    <WebMethod()>
    Public Shared Function GetCustomers() As String
        Dim query As String = "SELECT customerid, name, country FROM customer_t"
        Dim cmd As New SqlCommand(query)
        Dim constr As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Using con As New SqlConnection(constr)
            Using sda As New SqlDataAdapter()
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    Return ds.GetXml()
                End Using
            End Using
        End Using
    End Function

    <WebMethod()>
    Public Shared Function InsertCustomer(name As String, country As String) As Integer
        Dim constr As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("INSERT INTO customer_t VALUES(@name, @country) SELECT SCOPE_IDENTITY()")
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@country", country)
                cmd.Connection = con
                con.Open()
                Dim customerid As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                con.Close()
                Return customerid
            End Using
        End Using
    End Function

    <WebMethod()>
    Public Shared Sub UpdateCustomer(customerId As Integer, name As String, country As String)
        Dim constr As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("UPDATE customer_t SET name = @name, country = @country WHERE customerid = @customerid")
                cmd.Parameters.AddWithValue("@customerid", customerId)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@country", country)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    <WebMethod()>
    Public Shared Sub DeleteCustomer(customerId As Integer)
        Dim constr As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("DELETE FROM customer_t WHERE customerid = @customerid")
                cmd.Parameters.AddWithValue("@customerid", customerId)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

End Class